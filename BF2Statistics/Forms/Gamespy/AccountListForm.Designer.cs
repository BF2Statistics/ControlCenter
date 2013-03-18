﻿namespace BF2Statistics
{
    partial class AccountListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.PageNumber = new System.Windows.Forms.NumericUpDown();
            this.NextBtn = new System.Windows.Forms.Button();
            this.PreviousBtn = new System.Windows.Forms.Button();
            this.LastBtn = new System.Windows.Forms.Button();
            this.FirstBtn = new System.Windows.Forms.Button();
            this.RowCountDesc = new System.Windows.Forms.Label();
            this.LimitSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DataTable = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.session = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PageNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Account Name:";
            // 
            // SearchBox
            // 
            this.SearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchBox.Location = new System.Drawing.Point(568, 55);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(200, 20);
            this.SearchBox.TabIndex = 1;
            this.SearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(29, 17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(739, 24);
            this.richTextBox1.TabIndex = 21;
            this.richTextBox1.Text = "Below is a list of all the gamespy accounts in your database. Select an account t" +
                "o edit or view by double clicking on a player below";
            // 
            // PageNumber
            // 
            this.PageNumber.Location = new System.Drawing.Point(538, 534);
            this.PageNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PageNumber.Name = "PageNumber";
            this.PageNumber.ReadOnly = true;
            this.PageNumber.Size = new System.Drawing.Size(70, 20);
            this.PageNumber.TabIndex = 20;
            this.PageNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PageNumber.ValueChanged += new System.EventHandler(this.PageNumber_ValueChanged);
            // 
            // NextBtn
            // 
            this.NextBtn.Location = new System.Drawing.Point(614, 530);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(70, 25);
            this.NextBtn.TabIndex = 19;
            this.NextBtn.Text = "Next";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // PreviousBtn
            // 
            this.PreviousBtn.Location = new System.Drawing.Point(461, 531);
            this.PreviousBtn.Name = "PreviousBtn";
            this.PreviousBtn.Size = new System.Drawing.Size(70, 25);
            this.PreviousBtn.TabIndex = 18;
            this.PreviousBtn.Text = "Previous";
            this.PreviousBtn.UseVisualStyleBackColor = true;
            this.PreviousBtn.Click += new System.EventHandler(this.PreviousBtn_Click);
            // 
            // LastBtn
            // 
            this.LastBtn.Location = new System.Drawing.Point(690, 530);
            this.LastBtn.Name = "LastBtn";
            this.LastBtn.Size = new System.Drawing.Size(70, 25);
            this.LastBtn.TabIndex = 17;
            this.LastBtn.Text = "Last";
            this.LastBtn.UseVisualStyleBackColor = true;
            this.LastBtn.Click += new System.EventHandler(this.LastBtn_Click);
            // 
            // FirstBtn
            // 
            this.FirstBtn.Location = new System.Drawing.Point(385, 531);
            this.FirstBtn.Name = "FirstBtn";
            this.FirstBtn.Size = new System.Drawing.Size(70, 25);
            this.FirstBtn.TabIndex = 16;
            this.FirstBtn.Text = "First";
            this.FirstBtn.UseVisualStyleBackColor = true;
            this.FirstBtn.Click += new System.EventHandler(this.FirstBtn_Click);
            // 
            // RowCountDesc
            // 
            this.RowCountDesc.AutoSize = true;
            this.RowCountDesc.Location = new System.Drawing.Point(26, 536);
            this.RowCountDesc.Name = "RowCountDesc";
            this.RowCountDesc.Size = new System.Drawing.Size(65, 13);
            this.RowCountDesc.TabIndex = 15;
            this.RowCountDesc.Text = "PlaceHolder";
            // 
            // LimitSelect
            // 
            this.LimitSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LimitSelect.FormattingEnabled = true;
            this.LimitSelect.Items.AddRange(new object[] {
            "10",
            "25",
            "50",
            "100",
            "150",
            "250"});
            this.LimitSelect.Location = new System.Drawing.Point(132, 55);
            this.LimitSelect.Name = "LimitSelect";
            this.LimitSelect.Size = new System.Drawing.Size(150, 21);
            this.LimitSelect.TabIndex = 14;
            this.LimitSelect.SelectedIndexChanged += new System.EventHandler(this.LimitSelect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Records Per Page: ";
            // 
            // DataTable
            // 
            this.DataTable.AllowUserToAddRows = false;
            this.DataTable.AllowUserToDeleteRows = false;
            this.DataTable.AllowUserToOrderColumns = true;
            this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.email,
            this.country,
            this.session,
            this.lastip});
            this.DataTable.Location = new System.Drawing.Point(24, 84);
            this.DataTable.MultiSelect = false;
            this.DataTable.Name = "DataTable";
            this.DataTable.ReadOnly = true;
            this.DataTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataTable.Size = new System.Drawing.Size(744, 432);
            this.DataTable.TabIndex = 12;
            this.DataTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataTable_CellDoubleClick);
            this.DataTable.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataTable_ColumnHeaderMouseClick);
            // 
            // id
            // 
            this.id.HeaderText = "Account ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.id.Width = 85;
            // 
            // name
            // 
            this.name.HeaderText = "Account Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.name.Width = 150;
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.email.Width = 175;
            // 
            // country
            // 
            this.country.HeaderText = "Country";
            this.country.Name = "country";
            this.country.ReadOnly = true;
            this.country.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.country.Width = 75;
            // 
            // session
            // 
            this.session.HeaderText = "Online";
            this.session.Name = "session";
            this.session.ReadOnly = true;
            this.session.Width = 50;
            // 
            // lastip
            // 
            this.lastip.HeaderText = "Last IP Address";
            this.lastip.Name = "lastip";
            this.lastip.ReadOnly = true;
            this.lastip.Width = 170;
            // 
            // AccountListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.PageNumber);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.PreviousBtn);
            this.Controls.Add(this.LastBtn);
            this.Controls.Add(this.FirstBtn);
            this.Controls.Add(this.RowCountDesc);
            this.Controls.Add(this.LimitSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DataTable);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gamespy Accounts";
            ((System.ComponentModel.ISupportInitialize)(this.PageNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NumericUpDown PageNumber;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Button PreviousBtn;
        private System.Windows.Forms.Button LastBtn;
        private System.Windows.Forms.Button FirstBtn;
        private System.Windows.Forms.Label RowCountDesc;
        private System.Windows.Forms.ComboBox LimitSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DataTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn country;
        private System.Windows.Forms.DataGridViewTextBoxColumn session;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastip;
    }
}