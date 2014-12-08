﻿CREATE TABLE "main"."army"(
  "id" INT NOT NULL DEFAULT 0,
  "time0" INT NOT NULL DEFAULT 0,
  "win0" INT NOT NULL DEFAULT 0,
  "loss0" INT NOT NULL DEFAULT 0,
  "score0" INT NOT NULL DEFAULT 0,
  "best0" INT NOT NULL DEFAULT 0,
  "worst0" INT NOT NULL DEFAULT 0,
  "brnd0" INT NOT NULL DEFAULT 0,
  "time1" INT NOT NULL DEFAULT 0,
  "win1" INT NOT NULL DEFAULT 0,
  "loss1" INT NOT NULL DEFAULT 0,
  "score1" INT NOT NULL DEFAULT 0,
  "best1" INT NOT NULL DEFAULT 0,
  "worst1" INT NOT NULL DEFAULT 0,
  "brnd1" INT NOT NULL DEFAULT 0,
  "time2" INT NOT NULL DEFAULT 0,
  "win2" INT NOT NULL DEFAULT 0,
  "loss2" INT NOT NULL DEFAULT 0,
  "score2" INT NOT NULL DEFAULT 0,
  "best2" INT NOT NULL DEFAULT 0,
  "worst2" INT NOT NULL DEFAULT 0,
  "brnd2" INT NOT NULL DEFAULT 0,
  "time3" INT NOT NULL DEFAULT 0,
  "win3" INT NOT NULL DEFAULT 0,
  "loss3" INT NOT NULL DEFAULT 0,
  "score3" INT NOT NULL DEFAULT 0,
  "best3" INT NOT NULL DEFAULT 0,
  "worst3" INT NOT NULL DEFAULT 0,
  "brnd3" INT NOT NULL DEFAULT 0,
  "time4" INT NOT NULL DEFAULT 0,
  "win4" INT NOT NULL DEFAULT 0,
  "loss4" INT NOT NULL DEFAULT 0,
  "score4" INT NOT NULL DEFAULT 0,
  "best4" INT NOT NULL DEFAULT 0,
  "worst4" INT NOT NULL DEFAULT 0,
  "brnd4" INT NOT NULL DEFAULT 0,
  "time5" INT NOT NULL DEFAULT 0,
  "win5" INT NOT NULL DEFAULT 0,
  "loss5" INT NOT NULL DEFAULT 0,
  "score5" INT NOT NULL DEFAULT 0,
  "best5" INT NOT NULL DEFAULT 0,
  "worst5" INT NOT NULL DEFAULT 0,
  "brnd5" INT NOT NULL DEFAULT 0,
  "time6" INT NOT NULL DEFAULT 0,
  "win6" INT NOT NULL DEFAULT 0,
  "loss6" INT NOT NULL DEFAULT 0,
  "score6" INT NOT NULL DEFAULT 0,
  "best6" INT NOT NULL DEFAULT 0,
  "worst6" INT NOT NULL DEFAULT 0,
  "brnd6" INT NOT NULL DEFAULT 0,
  "time7" INT NOT NULL DEFAULT 0,
  "win7" INT NOT NULL DEFAULT 0,
  "loss7" INT NOT NULL DEFAULT 0,
  "score7" INT NOT NULL DEFAULT 0,
  "best7" INT NOT NULL DEFAULT 0,
  "worst7" INT NOT NULL DEFAULT 0,
  "brnd7" INT NOT NULL DEFAULT 0,
  "time8" INT NOT NULL DEFAULT 0,
  "win8" INT NOT NULL DEFAULT 0,
  "loss8" INT NOT NULL DEFAULT 0,
  "score8" INT NOT NULL DEFAULT 0,
  "best8" INT NOT NULL DEFAULT 0,
  "worst8" INT NOT NULL DEFAULT 0,
  "brnd8" INT NOT NULL DEFAULT 0,
  "time9" INT NOT NULL DEFAULT 0,
  "win9" INT NOT NULL DEFAULT 0,
  "loss9" INT NOT NULL DEFAULT 0,
  "score9" INT NOT NULL DEFAULT 0,
  "best9" INT NOT NULL DEFAULT 0,
  "worst9" INT NOT NULL DEFAULT 0,
  "brnd9" INT NOT NULL DEFAULT 0,
  "time10" INT NOT NULL DEFAULT 0,
  "win10" INT NOT NULL DEFAULT 0,
  "loss10" INT NOT NULL DEFAULT 0,
  "score10" INT NOT NULL DEFAULT 0,
  "best10" INT NOT NULL DEFAULT 0,
  "worst10" INT NOT NULL DEFAULT 0,
  "brnd10" INT NOT NULL DEFAULT 0,
  "time11" INT NOT NULL DEFAULT 0,
  "win11" INT NOT NULL DEFAULT 0,
  "loss11" INT NOT NULL DEFAULT 0,
  "score11" INT NOT NULL DEFAULT 0,
  "best11" INT NOT NULL DEFAULT 0,
  "worst11" INT NOT NULL DEFAULT 0,
  "brnd11" INT NOT NULL DEFAULT 0,
  "time12" INT NOT NULL DEFAULT 0,
  "win12" INT NOT NULL DEFAULT 0,
  "loss12" INT NOT NULL DEFAULT 0,
  "score12" INT NOT NULL DEFAULT 0,
  "best12" INT NOT NULL DEFAULT 0,
  "worst12" INT NOT NULL DEFAULT 0,
  "brnd12" INT NOT NULL DEFAULT 0,
  "time13" INT NOT NULL DEFAULT 0,
  "win13" INT NOT NULL DEFAULT 0,
  "loss13" INT NOT NULL DEFAULT 0,
  "score13" INT NOT NULL DEFAULT 0,
  "best13" INT NOT NULL DEFAULT 0,
  "worst13" INT NOT NULL DEFAULT 0,
  "brnd13" INT NOT NULL DEFAULT 0,
  PRIMARY KEY ("id")
);

CREATE TABLE "main"."awards"(
  "id" INT NOT NULL DEFAULT 0,
  "awd" MEDIUMINT NOT NULL DEFAULT 0,
  "level" INT NOT NULL DEFAULT 0,
  "earned" INT NOT NULL DEFAULT 0,
  "first" INT NOT NULL DEFAULT 0,
  PRIMARY KEY ("id","awd","level")
);

CREATE TABLE "main"."kills"(
  "attacker" INT  NOT NULL DEFAULT 0,
  "victim" INT  NOT NULL DEFAULT 0,
  "count" INT NOT NULL DEFAULT 0,
  PRIMARY KEY ("attacker","victim")
);

CREATE TABLE "main"."kits"(
  "id" INT NOT NULL DEFAULT 0,
  "time0" INT NOT NULL DEFAULT 0,
  "kills0" INT NOT NULL DEFAULT 0,
  "deaths0" INT NOT NULL DEFAULT 0,
  "time1" INT NOT NULL DEFAULT 0,
  "kills1" INT NOT NULL DEFAULT 0,
  "deaths1" INT NOT NULL DEFAULT 0,
  "time2" INT NOT NULL DEFAULT 0,
  "kills2" INT NOT NULL DEFAULT 0,
  "deaths2" INT NOT NULL DEFAULT 0,
  "time3" INT NOT NULL DEFAULT 0,
  "kills3" INT NOT NULL DEFAULT 0,
  "deaths3" INT NOT NULL DEFAULT 0,
  "time4" INT NOT NULL DEFAULT 0,
  "kills4" INT NOT NULL DEFAULT 0,
  "deaths4" INT NOT NULL DEFAULT 0,
  "time5" INT NOT NULL DEFAULT 0,
  "kills5" INT NOT NULL DEFAULT 0,
  "deaths5" INT NOT NULL DEFAULT 0,
  "time6" INT NOT NULL DEFAULT 0,
  "kills6" INT NOT NULL DEFAULT 0,
  "deaths6" INT NOT NULL DEFAULT 0,
  PRIMARY KEY ("id")
);

CREATE TABLE "main"."mapinfo"(
  "id" INT NOT NULL DEFAULT 0,
  "name" TEXT NOT NULL DEFAULT '',
  "score" INT NOT NULL DEFAULT 0,
  "time" INT NOT NULL DEFAULT 0,
  "times" INT NOT NULL DEFAULT 0,
  "kills" INT NOT NULL DEFAULT 0,
  "deaths" INT NOT NULL DEFAULT 0,
  "custom" tinyint(2) NOT NULL DEFAULT 0,
  PRIMARY KEY ("id","name")
);

CREATE TABLE "main"."maps"(
  "id" INT NOT NULL DEFAULT 0,
  "mapid" INT NOT NULL DEFAULT 0,
  "time" INT NOT NULL DEFAULT 0,
  "win" INT NOT NULL DEFAULT 0,
  "loss" INT NOT NULL DEFAULT 0,
  "best" INT NOT NULL DEFAULT 0,
  "worst" INT NOT NULL DEFAULT 0,
  PRIMARY KEY ("id","mapid")
);

CREATE TABLE "main"."player"(
  "id" INT NOT NULL DEFAULT 0,
  "name" TEXT NOT NULL DEFAULT '',
  "country" TEXT NOT NULL DEFAULT '',
  "time" INT NOT NULL DEFAULT 0,
  "rounds" INT NOT NULL DEFAULT 0,
  "ip" TEXT NOT NULL DEFAULT '',
  "score" INT NOT NULL DEFAULT 0,
  "cmdscore" INT NOT NULL DEFAULT 0,
  "skillscore" INT NOT NULL DEFAULT 0,
  "teamscore" INT NOT NULL DEFAULT 0,
  "kills" INT NOT NULL DEFAULT 0,
  "deaths" INT NOT NULL DEFAULT 0,
  "captures" INT NOT NULL DEFAULT 0,
  "neutralizes" INT NOT NULL DEFAULT 0,
  "captureassists" INT NOT NULL DEFAULT 0,
  "neutralizeassists" INT NOT NULL DEFAULT 0,
  "defends" INT NOT NULL DEFAULT 0,
  "damageassists" INT NOT NULL DEFAULT 0,
  "heals" INT NOT NULL DEFAULT 0,
  "revives" INT NOT NULL DEFAULT 0,
  "ammos" INT NOT NULL DEFAULT 0,
  "repairs" INT NOT NULL DEFAULT 0,
  "targetassists" INT NOT NULL DEFAULT 0,
  "driverspecials" INT NOT NULL DEFAULT 0,
  "driverassists" INT NOT NULL DEFAULT 0,
  "passengerassists" INT NOT NULL DEFAULT 0,
  "teamkills" INT NOT NULL DEFAULT 0,
  "teamdamage" INT NOT NULL DEFAULT 0,
  "teamvehicledamage" INT NOT NULL DEFAULT 0,
  "suicides" INT NOT NULL DEFAULT 0,
  "killstreak" INT NOT NULL DEFAULT 0,
  "deathstreak" INT NOT NULL DEFAULT 0,
  "rank" INT NOT NULL DEFAULT 0,
  "banned" INT NOT NULL DEFAULT 0,
  "kicked" INT NOT NULL DEFAULT 0,
  "cmdtime" INT NOT NULL DEFAULT 0,
  "sqltime" INT NOT NULL DEFAULT 0,
  "sqmtime" INT NOT NULL DEFAULT 0,
  "lwtime" INT NOT NULL DEFAULT 0,
  "wins" INT NOT NULL DEFAULT 0,
  "losses" INT NOT NULL DEFAULT 0,
  "availunlocks" INT NOT NULL DEFAULT 0,
  "usedunlocks" INT NOT NULL DEFAULT 0,
  "joined" INT NOT NULL DEFAULT 0,
  "rndscore" INT NOT NULL DEFAULT 0,
  "lastonline" INT NOT NULL DEFAULT 0,
  "chng" INT NOT NULL DEFAULT 0,
  "decr" INT NOT NULL DEFAULT 0,
  "mode0" INT NOT NULL DEFAULT 0,
  "mode1" INT NOT NULL DEFAULT 0,
  "mode2" INT NOT NULL DEFAULT 0,
  "permban" INT NOT NULL DEFAULT 0,
  "clantag" TEXT NOT NULL DEFAULT '',
  "isbot" INT NOT NULL DEFAULT 0,
  PRIMARY KEY ("id","name")
);

CREATE TABLE "main"."player_history"(
  "id" INT NOT NULL DEFAULT 0,
  "timestamp" INT NOT NULL DEFAULT 0,
  "time" INT NOT NULL DEFAULT 0,
  "score" INT NOT NULL DEFAULT 0,
  "cmdscore" INT NOT NULL DEFAULT 0,
  "skillscore" INT NOT NULL DEFAULT 0,
  "teamscore" INT NOT NULL DEFAULT 0,
  "kills" INT NOT NULL DEFAULT 0,
  "deaths" INT NOT NULL DEFAULT 0,
  "rank" INT NOT NULL DEFAULT 0,
  PRIMARY KEY ("id","timestamp")
);

CREATE TABLE "main"."round_history"(
  "id" INTEGER PRIMARY KEY,
  "timestamp" INT NOT NULL DEFAULT 0,
  "mapid" INT NOT NULL DEFAULT 0,
  "time" INT NOT NULL DEFAULT 0,
  "team1" INT NOT NULL DEFAULT 0,
  "team2" INT NOT NULL DEFAULT 0,
  "tickets1" INT NOT NULL DEFAULT 0,
  "tickets2" INT NOT NULL DEFAULT 0,
  "pids1" INT NOT NULL DEFAULT 0,
  "pids1_end" INT NOT NULL DEFAULT 0,
  "pids2" INT NOT NULL DEFAULT 0,
  "pids2_end" INT NOT NULL DEFAULT 0
);

CREATE TABLE "main"."servers"(
  "id" INTEGER PRIMARY KEY,
  "ip" TEXT NOT NULL DEFAULT '',
  "prefix" TEXT NOT NULL DEFAULT '',
  "name" TEXT DEFAULT NULL,
  "port" INT DEFAULT 0,
  "queryport" INT NOT NULL DEFAULT 0,
  "rcon_port" INT NOT NULL DEFAULT 4711,
  "rcon_password" TEXT DEFAULT NULL,
  "lastupdate" TEXT NOT NULL DEFAULT '0000-00-00 00:00:00'
);

CREATE TABLE "main"."unlocks"(
  "id" INT NOT NULL DEFAULT 0,
  "kit" SMALLINT NOT NULL DEFAULT 0,
  "state" TEXT NOT NULL DEFAULT 'n',
  PRIMARY KEY ("id","kit")
);

CREATE TABLE "main"."vehicles"(
  "id" INT NOT NULL DEFAULT 0,
  "time0" INT NOT NULL DEFAULT 0,
  "time1" INT NOT NULL DEFAULT 0,
  "time2" INT NOT NULL DEFAULT 0,
  "time3" INT NOT NULL DEFAULT 0,
  "time4" INT NOT NULL DEFAULT 0,
  "time5" INT NOT NULL DEFAULT 0,
  "time6" INT NOT NULL DEFAULT 0,
  "timepara" INT NOT NULL DEFAULT 0,
  "kills0" INT NOT NULL DEFAULT 0,
  "kills1" INT NOT NULL DEFAULT 0,
  "kills2" INT NOT NULL DEFAULT 0,
  "kills3" INT NOT NULL DEFAULT 0,
  "kills4" INT NOT NULL DEFAULT 0,
  "kills5" INT NOT NULL DEFAULT 0,
  "kills6" INT NOT NULL DEFAULT 0,
  "deaths0" INT NOT NULL DEFAULT 0,
  "deaths1" INT NOT NULL DEFAULT 0,
  "deaths2" INT NOT NULL DEFAULT 0,
  "deaths3" INT NOT NULL DEFAULT 0,
  "deaths4" INT NOT NULL DEFAULT 0,
  "deaths5" INT NOT NULL DEFAULT 0,
  "deaths6" INT NOT NULL DEFAULT 0,
  "rk0" INT NOT NULL DEFAULT 0,
  "rk1" INT NOT NULL DEFAULT 0,
  "rk2" INT NOT NULL DEFAULT 0,
  "rk3" INT NOT NULL DEFAULT 0,
  "rk4" INT NOT NULL DEFAULT 0,
  "rk5" INT NOT NULL DEFAULT 0,
  "rk6" INT NOT NULL DEFAULT 0,
  PRIMARY KEY ("id")
);

CREATE TABLE "main"."weapons"(
  "id" INT NOT NULL DEFAULT 0,
  "time0" INT NOT NULL DEFAULT 0,
  "time1" INT NOT NULL DEFAULT 0,
  "time2" INT NOT NULL DEFAULT 0,
  "time3" INT NOT NULL DEFAULT 0,
  "time4" INT NOT NULL DEFAULT 0,
  "time5" INT NOT NULL DEFAULT 0,
  "time6" INT NOT NULL DEFAULT 0,
  "time7" INT NOT NULL DEFAULT 0,
  "time8" INT NOT NULL DEFAULT 0,
  "knifetime" INT NOT NULL DEFAULT 0,
  "c4time" INT NOT NULL DEFAULT 0,
  "handgrenadetime" INT NOT NULL DEFAULT 0,
  "claymoretime" INT NOT NULL DEFAULT 0,
  "shockpadtime" INT NOT NULL DEFAULT 0,
  "atminetime" INT NOT NULL DEFAULT 0,
  "tacticaltime" INT NOT NULL DEFAULT 0,
  "grapplinghooktime" INT NOT NULL DEFAULT 0,
  "ziplinetime" INT NOT NULL DEFAULT 0,
  "kills0" INT NOT NULL DEFAULT 0,
  "kills1" INT NOT NULL DEFAULT 0,
  "kills2" INT NOT NULL DEFAULT 0,
  "kills3" INT NOT NULL DEFAULT 0,
  "kills4" INT NOT NULL DEFAULT 0,
  "kills5" INT NOT NULL DEFAULT 0,
  "kills6" INT NOT NULL DEFAULT 0,
  "kills7" INT NOT NULL DEFAULT 0,
  "kills8" INT NOT NULL DEFAULT 0,
  "knifekills" INT NOT NULL DEFAULT 0,
  "c4kills" INT NOT NULL DEFAULT 0,
  "handgrenadekills" INT NOT NULL DEFAULT 0,
  "claymorekills" INT NOT NULL DEFAULT 0,
  "shockpadkills" INT NOT NULL DEFAULT 0,
  "atminekills" INT NOT NULL DEFAULT 0,
  "deaths0" INT NOT NULL DEFAULT 0,
  "deaths1" INT NOT NULL DEFAULT 0,
  "deaths2" INT NOT NULL DEFAULT 0,
  "deaths3" INT NOT NULL DEFAULT 0,
  "deaths4" INT NOT NULL DEFAULT 0,
  "deaths5" INT NOT NULL DEFAULT 0,
  "deaths6" INT NOT NULL DEFAULT 0,
  "deaths7" INT NOT NULL DEFAULT 0,
  "deaths8" INT NOT NULL DEFAULT 0,
  "knifedeaths" INT NOT NULL DEFAULT 0,
  "c4deaths" INT NOT NULL DEFAULT 0,
  "handgrenadedeaths" INT NOT NULL DEFAULT 0,
  "claymoredeaths" INT NOT NULL DEFAULT 0,
  "shockpaddeaths" INT NOT NULL DEFAULT 0,
  "atminedeaths" INT NOT NULL DEFAULT 0,
  "ziplinedeaths" INT NOT NULL DEFAULT 0,
  "grapplinghookdeaths" INT NOT NULL DEFAULT 0,
  "tacticaldeployed" INT NOT NULL DEFAULT 0,
  "grapplinghookdeployed" INT NOT NULL DEFAULT 0,
  "ziplinedeployed" INT NOT NULL DEFAULT 0,
  "fired0" INT NOT NULL DEFAULT 0,
  "fired1" INT NOT NULL DEFAULT 0,
  "fired2" INT NOT NULL DEFAULT 0,
  "fired3" INT NOT NULL DEFAULT 0,
  "fired4" INT NOT NULL DEFAULT 0,
  "fired5" INT NOT NULL DEFAULT 0,
  "fired6" INT NOT NULL DEFAULT 0,
  "fired7" INT NOT NULL DEFAULT 0,
  "fired8" INT NOT NULL DEFAULT 0,
  "knifefired" INT NOT NULL DEFAULT 0,
  "c4fired" INT NOT NULL DEFAULT 0,
  "claymorefired" INT NOT NULL DEFAULT 0,
  "handgrenadefired" INT NOT NULL DEFAULT 0,
  "shockpadfired" INT NOT NULL DEFAULT 0,
  "atminefired" INT NOT NULL DEFAULT 0,
  "hit0" INT NOT NULL DEFAULT 0,
  "hit1" INT NOT NULL DEFAULT 0,
  "hit2" INT NOT NULL DEFAULT 0,
  "hit3" INT NOT NULL DEFAULT 0,
  "hit4" INT NOT NULL DEFAULT 0,
  "hit5" INT NOT NULL DEFAULT 0,
  "hit6" INT NOT NULL DEFAULT 0,
  "hit7" INT NOT NULL DEFAULT 0,
  "hit8" INT NOT NULL DEFAULT 0,
  "knifehit" INT NOT NULL DEFAULT 0,
  "c4hit" INT NOT NULL DEFAULT 0,
  "claymorehit" INT NOT NULL DEFAULT 0,
  "handgrenadehit" INT NOT NULL DEFAULT 0,
  "shockpadhit" INT NOT NULL DEFAULT 0,
  "atminehit" INT NOT NULL DEFAULT 0,
  PRIMARY KEY ("id")
);

CREATE TABLE "main"."_version"(
  "dbver" TEXT NOT NULL DEFAULT '',
  "dbdate" INT NOT NULL DEFAULT 0,
  PRIMARY KEY ("dbver")
);

--
-- Dumping data for table `_version`
--
INSERT INTO _version VALUES ('2.2.0', 1363280938);
