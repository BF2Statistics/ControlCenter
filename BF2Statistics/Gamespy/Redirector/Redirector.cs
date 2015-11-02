﻿using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using BF2Statistics.Gamespy.Redirector;
using BF2Statistics.Net;

namespace BF2Statistics
{
    /// <summary>
    /// Provides Methods to apply and remove Gamespy Redirects
    /// </summary>
    public static class Redirector
    {
        /// <summary>
        /// We only initialize once, so store that here
        /// </summary>
        private static bool IsInitialized = false;

        /// <summary>
        /// Gets whether the redirects are currently active
        /// </summary>
        public static bool RedirectsEnabled 
        {
            get
            {
                // Return false if we havent initialized
                if (!IsInitialized) return false;

                // DNS Server is always considered enabled
                if (RedirectMethod == RedirectMode.DnsServer) return true;

                // Grab hosts file base
                HostsFile hFile = (RedirectMethod == RedirectMode.HostsFile)
                    ? HostsFileSys as HostsFile
                    : HostsFileIcs as HostsFile;

                // Check for entries
                return hFile.HasEntry(Bf2StatsHost) || hFile.HasAnyEntry(GamespyHosts);
            }
        }

        /// <summary>
        /// Gets the current redirect method
        /// </summary>
        public static RedirectMode RedirectMethod { get; private set; }

        /// <summary>
        /// Gets the system hosts file object
        /// </summary>
        public static SysHostsFile HostsFileSys { get; private set; }

        /// <summary>
        /// Gets the hosts.ics file object
        /// </summary>
        public static HostsFileIcs HostsFileIcs { get; private set; }

        /// <summary>
        /// Gets or Sets the Stats Server address. If redirects are enabled,
        /// changes will not take effect until they are removed.
        /// </summary>
        public static IPAddress StatsServerAddress;

        /// <summary>
        /// Gets or Sets the Gamespy Server address. If redirects are enabled,
        /// changes will not take effect until they are removed.
        /// </summary>
        public static IPAddress GamespyServerAddress;

        /// <summary>
        /// Returns an array of all gamespy related service hostnames
        /// </summary>
        public static readonly string[] GamespyHosts = {
                "gamespy.com",
                "gpcm.gamespy.com",
                "gpsp.gamespy.com",
                "motd.gamespy.com",
                "master.gamespy.com",
                "gamestats.gamespy.com",
                "battlefield2.ms14.gamespy.com",
                "battlefield2.master.gamespy.com",
                "battlefield2.available.gamespy.com"
            };

        /// <summary>
        /// Returns the hostname for the battlefield 2 stats server
        /// </summary>
        public static readonly string Bf2StatsHost = "bf2web.gamespy.com";

        /// <summary>
        /// Gets the last DnsCacheReport object generated by the <see cref="VerifyDNSCache()"/> method
        /// </summary>
        public static GamespyDnsReport DnsCacheReport = new GamespyDnsReport();

        /// <summary>
        /// The main entry point for the redirector
        /// </summary>
        /// <returns>Returns wether the DNS cache results match the selected IPAddresses</returns>
        public static Task<bool> Initialize()
        {
            return Task.Run<bool>(() =>
            {
                // Only initialize once
                if (!IsInitialized)
                {
                    IsInitialized = true;

                    // Set the System.Net DNS Cache refresh timeout to 1 millisecond
                    ServicePointManager.DnsRefreshTimeout = 1;

                    // Get config options
                    RedirectMethod = Program.Config.RedirectMode;

                    // Create new Instances
                    HostsFileSys = new SysHostsFile();
                    HostsFileIcs = new HostsFileIcs();

                    // Detect redirects
                    bool IcsHasRedirects = HostsFileIcs.HasAnyEntry(GamespyHosts) || HostsFileIcs.HasEntry(Bf2StatsHost);
                    bool HostsHasRedirects = HostsFileSys.HasAnyEntry(GamespyHosts) || HostsFileSys.HasEntry(Bf2StatsHost);

                    // Both files cannot have redirects!
                    if (IcsHasRedirects && HostsHasRedirects)
                    {
                        try
                        {
                            // Remove all redirects
                            RemoveRedirects(HostsFileIcs);
                            RemoveRedirects(HostsFileSys);
                        }
                        catch { }
                    }
                    else if (IcsHasRedirects || HostsHasRedirects)
                    {
                        // Do the settings match?
                        bool match = (RedirectMethod == RedirectMode.HostsFile && HostsHasRedirects)
                            || (RedirectMethod == RedirectMode.HostsIcsFile && IcsHasRedirects);

                        // Perform switch if the settings don't match
                        if (!match)
                            RedirectMethod = (RedirectMethod == RedirectMode.HostsFile) ? RedirectMode.HostsIcsFile : RedirectMode.HostsFile;

                        // === Fetch our redirect data

                        // Grab hosts file base
                        HostsFile hFile = (RedirectMethod == RedirectMode.HostsFile)
                            ? HostsFileSys as HostsFile
                            : HostsFileIcs as HostsFile;

                        // Parse Stats Address
                        if (hFile.HasEntry("bf2web.gamespy.com"))
                            StatsServerAddress = hFile.Get("bf2web.gamespy.com");

                        // Parse Gamespy Address
                        if (hFile.HasEntry("master.gamespy.com"))
                            GamespyServerAddress = hFile.Get("master.gamespy.com");

                        // Lock hosts file
                        if (RedirectMethod == RedirectMode.HostsFile && Program.Config.LockHostsFile)
                            HostsFileSys.Lock();

                    }
                    else if (RedirectMethod == RedirectMode.DnsServer)
                    {
                        IPAddress addy;

                        // Parse last used Stats Server Address
                        if (Networking.TryGetIpAddress(Program.Config.LastStatsServerAddress, out addy))
                            StatsServerAddress = addy;

                        // Parse gamespy saved address
                        if (Networking.TryGetIpAddress(Program.Config.LastLoginServerAddress, out addy))
                            GamespyServerAddress = addy;
                    }
                }

                // Verify cache
                return (RedirectsEnabled) ? VerifyDNSCache() : true;
            });
        }

        /// <summary>
        /// Sets a new Redirect method. Using this method removes any previous redirects
        /// </summary>
        /// <param name="Mode">The new redirect mode</param>
        /// <returns></returns>
        public static bool SetRedirectMode(RedirectMode Mode)
        {
            // If not change is made, return
            if (Mode == RedirectMethod) return false;

            // Remove old redirects first
            if (RedirectsEnabled) RemoveRedirects();

            // Set new method
            RedirectMethod = Mode;

            // Save config
            Program.Config.RedirectMode = Mode;
            Program.Config.Save();
            return true;
        }

        /// <summary>
        /// Applies the specified IP address redirects for the chosen redirect method
        /// </summary>
        public static Task<bool> ApplyRedirectsAsync(IProgress<TaskStep> Progress)
        {
            return Task.Run(() =>
            {
                // Remove old settings
                if (RedirectsEnabled) RemoveRedirects();

                // Invalid on no IP addresses
                if (StatsServerAddress == null && GamespyServerAddress == null)
                    return false;

                // Set new desired addresses
                if (StatsServerAddress != null)
                    Program.Config.LastStatsServerAddress = StatsServerAddress.ToString();
                if (GamespyServerAddress != null)
                    Program.Config.LastLoginServerAddress = GamespyServerAddress.ToString();
                Program.Config.Save();

                // Can't do anything with a dns server
                if (RedirectMethod == RedirectMode.DnsServer) return true;

                // === Apply new settings === //

                // Grab hosts file base
                HostsFile hFile = (RedirectMethod == RedirectMode.HostsFile)
                    ? HostsFileSys as HostsFile
                    : HostsFileIcs as HostsFile;

                // Unlock system hosts file
                if (RedirectMethod == RedirectMode.HostsFile)
                {
                    // Make sure file is writable
                    if (SysHostsFile.IsLocked && !HostsFileSys.UnLock())
                    {
                        Progress.Report(new TaskStep(0, "Cannot allow READ permissions on the Hosts File", true, hFile.LastException));
                        return false;
                    }
                    else
                        Progress.Report(new TaskStep(0, ""));
                }

                // Make sure file is writable
                if (!hFile.CanRead)
                {
                    Progress.Report(new TaskStep(1, "Cannot read the Hosts File", true, hFile.LastException));
                    return false;
                }
                else
                    Progress.Report(new TaskStep(1, ""));
                    
                // Make sure file is readable
                if (!hFile.CanWrite)
                {
                    Progress.Report(new TaskStep(2, "Cannot write to the Hosts File", true, hFile.LastException));
                    return false;
                }
                else
                    Progress.Report(new TaskStep(2, ""));

                // ===== Set Redirect Addresses ===== //

                // Stats Server
                if (StatsServerAddress != null)
                    hFile.Set(Bf2StatsHost, StatsServerAddress);

                // Gamespy Servers
                if (GamespyServerAddress != null)
                {
                    foreach (string hostname in GamespyHosts)
                        hFile.Set(hostname, GamespyServerAddress);
                }

                // Report Progress
                Progress.Report(new TaskStep(3, "Gamespy Redirects Set"));

                // ===== Save Redirects ===== //

                int Step = 4;
                string ErrDesc = "";
                try
                {
                    // Attempt to save the hosts file
                    ErrDesc = "Unable to  Save Hosts File!";
                    hFile.Save();

                    // Report Success
                    Progress.Report(new TaskStep(Step++, "Hosts File Saved Successfully"));

                    // Rebuild the DNS Cache
                    ErrDesc = "Failed to Rebuild the DNS Cache";
                    RebuildDNSCache(CancellationToken.None);

                    // Report Success
                    Progress.Report(new TaskStep(Step++, "DNS Cache Rebuilt Successfully"));
                }
                catch (Exception e)
                {
                    RemoveRedirects();
                    Progress.Report(new TaskStep(Step, ErrDesc, true, e));
                    return false;
                }

                // Lock system hosts File
                if (RedirectMethod == RedirectMode.HostsFile)
                {
                    if (!Program.Config.LockHostsFile)
                    {
                        // Report Success
                        Progress.Report(new TaskStep(Step++, ""));
                        return true;
                    }
                    else if (HostsFileSys.Lock())
                    {
                        // Report Success
                        Progress.Report(new TaskStep(Step++, "Hosts File Read Permissions Removed"));
                        return true;
                    }
                    else
                    {
                        // Report Error
                        Progress.Report(new TaskStep(Step++, "Cannot Remove Hosts File Read Permissions!",
                            true, HostsFileSys.LastException));
                        return true;
                    }
                }

                return true;
            });
        }

        /// <summary>
        /// Remove the redirects currently active
        /// </summary>
        public static void RemoveRedirects()
        {
            // Can't do anything with a dns server
            if (RedirectMethod == RedirectMode.DnsServer || !RedirectsEnabled) return;

            // UnLock system Hosts file
            if (RedirectMethod == RedirectMode.HostsFile)
            {
                // Must unlock first
                if (SysHostsFile.IsLocked)
                    HostsFileSys.UnLock();

                RemoveRedirects(HostsFileSys);
            }
            else
            {
                RemoveRedirects(HostsFileIcs);
            }
        }

        /// <summary>
        /// Removes all gamespy related redirects in the specified hosts file container
        /// </summary>
        /// <param name="HostFile"></param>
        private static void RemoveRedirects(HostsFile HostFile)
        {
            // Remove Gamespy Addresses. Use a Bitwise OR here to execute both methods
            if (HostFile.Remove(Bf2StatsHost) | HostFile.RemoveAll(GamespyHosts))
            {
                // Save Changes
                HostFile.Save();

                // Flush the Cache of the gamespy hosts
                foreach (string host in GamespyHosts)
                    DnsFlushResolverCacheEntry(host);

                // Flush stats server
                DnsFlushResolverCacheEntry(Bf2StatsHost);
            }
        }

        /// <summary>
        /// Queries the DNS Cache for the Gamespy hosts, and verifies that the
        /// IP addresses in the DNS Cache match that of the desired redirect IP
        /// </summary>
        public static bool VerifyDNSCache(IProgress<DnsCacheResult> Progress = null)
        {
            // Nothing to do here if redirects are disabled
            if (!RedirectsEnabled) return false;

            // Grab our saved hosts file IP addresses
            if (RedirectMethod != RedirectMode.DnsServer)
            {
                // Grab hosts file base
                HostsFile hFile = (RedirectMethod == RedirectMode.HostsFile)
                    ? HostsFileSys as HostsFile
                    : HostsFileIcs as HostsFile;

                // Fetch our saved IPAddresses
                GamespyServerAddress = (hFile.HasEntry("master.gamespy.com")) ? hFile.Get("master.gamespy.com") : null;
                StatsServerAddress = (hFile.HasEntry(Bf2StatsHost)) ? hFile.Get(Bf2StatsHost) : null;
            }

            // Flush our cache report
            DnsCacheReport.Entries.Clear();

            // Verify Gamespy Server IP addresses
            if (GamespyServerAddress != null)
            {
                foreach (string address in GamespyHosts)
                {
                    // Create new report
                    DnsCacheResult Result = new DnsCacheResult(address, GamespyServerAddress);

                    // Add the result to the report
                    DnsCacheReport.AddOrUpdate(Result);

                    // Report progress if we have a progress object
                    if (Progress != null)
                        Progress.Report(Result);
                }
            }

            // Verify Stats Server address
            if (StatsServerAddress != null)
            {
                // Create new report
                DnsCacheResult Result = new DnsCacheResult(Bf2StatsHost, StatsServerAddress);

                // Add the result to the report
                DnsCacheReport.AddOrUpdate(Result);

                // Report progress if we have a progress object
                if (Progress != null)
                    Progress.Report(Result);
            }

            // Set internal
            DnsCacheReport.LastRefresh = DateTime.Now;
            return DnsCacheReport.ErrorFree;
        }

        /// <summary>
        /// Preforms the pings required to fill the dns cache.
        /// The reason we ping, is because once the HOSTS file is locked, any request
        /// made to a url (when the DNS cache is empty), will skip the hosts file, because 
        /// it cant be read. If we ping first, then the DNS cache fills up with the IP 
        /// addresses in the hosts file.
        /// </summary>
        public static void RebuildDNSCache(CancellationToken CancelToken)
        {
            // Must be hosts file!
            if (RedirectMethod == RedirectMode.DnsServer || !RedirectsEnabled) return;

            // Grab hosts file base
            HostsFile hFile = (RedirectMethod == RedirectMode.HostsFile)
                ? HostsFileSys as HostsFile
                : HostsFileIcs as HostsFile;

            // Rebuild the DNS cache with the hosts file redirects
            foreach (string hostname in hFile.GetLines().Keys)
            {
                // Quit on cancel
                if (CancelToken.IsCancellationRequested) return;

                // Only ping gamespy urls with the hosts ics file
                if (RedirectMethod == RedirectMode.HostsIcsFile && !hostname.Contains("gamespy"))
                    continue;

                // Attempt to ping the server
                try
                {
                    // Clear the record from the DNS cache
                    DnsFlushResolverCacheEntry(hostname);

                    // Ping server to get the IP address in the dns cache
                    Dns.GetHostAddresses(hostname);
                }
                catch
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// Removes all DNS records from the DNS resolver cache.
        /// </summary>
        /// <returns></returns>
        [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCache")]
        private static extern UInt32 DnsFlushResolverCache();

        /// <summary>
        /// Removes all related DNS records for the given hostname from the DNS resolver cache.
        /// </summary>
        /// <param name="hostName">The host name to flush from the resolver cache.</param>
        /// <returns>Returns 1 if successful, zero if failed.  No other error information is returned.</returns>
        /// <seealso cref="http://stackoverflow.com/questions/3498337/is-there-a-way-to-flush-the-dns-cache-from-a-c-sharp-wpf-app-on-xp-vista-win/16821805#16821805"/>
        /// <remarks>
        /// DnsFlushResolverCacheEntry_W is an undocumented method.  From dissembler this method has two possible 
        /// return values 0 or 1.  If the argument is null or the _R_ResolverFlushCacheEntry returns something 
        /// other than zero than the return value is zero.  When _R_ResolverFlushCacheEntry returns zero the 
        /// return value is 1.  Based off this and testing of the method it is assumed that 1 is used to indicate success.  
        /// After calling this method querying the DNS resolver cache returns no results.
        /// 
        /// __stdcall DnsFlushResolverCacheEntry_W(x)
        /// ....
        /// 6DC12729 xor     esi, esi                       // Zero esi
        /// 6DC1272B cmp     [ebp+arg_0], esi               // check if the hostname is null
        /// 6DC1272E jz      loc_6DC1D8B8                   // Jump to end, return value is 0.
        /// 6DC12734 mov     [ebp+ms_exc.registration.TryLevel], esi
        /// 6DC12737 push    esi                            // Push 3 args for method, 2nd is hostname, others null
        /// 6DC12738 push    [ebp+arg_0]
        /// 6DC1273B push    esi
        /// 6DC1273C call    _R_ResolverFlushCacheEntry@12  // call this method 
        /// 6DC12741 mov     [ebp+var_1C], eax              // store return value in local
        /// 6DC12744 mov     [ebp+ms_exc.registration.TryLevel], 0FFFFFFFEh
        /// 6DC1274B
        /// 6DC1274B loc_6DC1274B:                           
        /// 6DC1274B cmp     [ebp+var_1C], esi           
        /// 6DC1274E jnz     loc_6DC1D8E7                   // Error?  jump to block that does etw then return 0
        /// 6DC12754 xor     eax, eax                       // Success?  Set eax to zero
        /// 6DC12756 inc     eax                            // result is 0, increment by 1.  success return value is 1
        /// 6DC12757 call    __SEH_epilog4
        /// 6DC1275C retn    4
        /// 
        /// 6DC1D8B8 xor     eax, eax                       // set return value to zero
        /// 6DC1D8BA jmp     loc_6DC12757                   // jump to end
        /// 
        /// 6DC1D8E7 mov     eax, _WPP_GLOBAL_Control
        /// 6DC1D8EC cmp     eax, offset _WPP_GLOBAL_Control
        /// 6DC1D8F1 jz      short loc_6DC1D8B8
        /// 6DC1D8F3 test    byte ptr [eax+1Ch], 40h
        /// 6DC1D8F7 jz      short loc_6DC1D8B8 // This is probably testing some flag that is used to indicate if ETW is enabled
        /// 6DC1D8F9 push    [ebp+var_1C]
        /// 6DC1D8FC push    offset dword_6DC22494
        /// 6DC1D901 push    0Dh
        /// 6DC1D903 push    dword ptr [eax+14h]
        /// 6DC1D906 push    dword ptr [eax+10h]
        /// 6DC1D909 call    _WPP_SF_q@20    ; WPP_SF_q(x,x,x,x,x)      // This method does some ETW tracing
        /// 6DC1D90E jmp     short loc_6DC1D8B8
        /// </remarks>
        [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCacheEntry_W", CharSet = CharSet.Unicode)]
        public static extern int DnsFlushResolverCacheEntry(string hostName);
    }
}