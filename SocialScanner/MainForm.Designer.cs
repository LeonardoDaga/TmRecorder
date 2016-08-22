namespace SocialScanner
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvCorporate = new System.Windows.Forms.DataGridView();
            this.corporateIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fbOfficialWebSiteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.twOfficialWebSiteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IgOfficialWebSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GgOfficialWebSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.corporateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.socialDataDB = new SocialScanner.SocialData();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ntrBrowser = new NTR_WebBrowser.NTR_Browser();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.corporateIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.likesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.talkingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last14DaysLikesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeenHere = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facebookBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.corporateIDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tweetsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.followersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.followingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.likesDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.twitterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.corporateIDDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.followersDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.followingDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instagramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCorporateListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoFacebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoInstagramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanSelectedCorporateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.facebookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scanStartingFromSelectedCorporateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorporate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corporateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.socialDataDB)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookBindingSource1)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twitterBindingSource)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instagramBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facebookBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(923, 492);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvCorporate);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(915, 466);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pages List";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvCorporate
            // 
            this.dgvCorporate.AutoGenerateColumns = false;
            this.dgvCorporate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCorporate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.corporateIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.Nation,
            this.fbOfficialWebSiteDataGridViewTextBoxColumn,
            this.twOfficialWebSiteDataGridViewTextBoxColumn,
            this.IgOfficialWebSite,
            this.GgOfficialWebSite});
            this.dgvCorporate.DataSource = this.corporateBindingSource;
            this.dgvCorporate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCorporate.Location = new System.Drawing.Point(3, 3);
            this.dgvCorporate.Name = "dgvCorporate";
            this.dgvCorporate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCorporate.Size = new System.Drawing.Size(909, 460);
            this.dgvCorporate.TabIndex = 0;
            // 
            // corporateIDDataGridViewTextBoxColumn
            // 
            this.corporateIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.corporateIDDataGridViewTextBoxColumn.DataPropertyName = "CorporateID";
            this.corporateIDDataGridViewTextBoxColumn.HeaderText = "CorporateID";
            this.corporateIDDataGridViewTextBoxColumn.Name = "corporateIDDataGridViewTextBoxColumn";
            this.corporateIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.corporateIDDataGridViewTextBoxColumn.Width = 89;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // Nation
            // 
            this.Nation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nation.DataPropertyName = "Nation";
            this.Nation.HeaderText = "Nation";
            this.Nation.Name = "Nation";
            this.Nation.Width = 63;
            // 
            // fbOfficialWebSiteDataGridViewTextBoxColumn
            // 
            this.fbOfficialWebSiteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fbOfficialWebSiteDataGridViewTextBoxColumn.DataPropertyName = "FbOfficialWebSite";
            this.fbOfficialWebSiteDataGridViewTextBoxColumn.HeaderText = "FbOfficialWebSite";
            this.fbOfficialWebSiteDataGridViewTextBoxColumn.Name = "fbOfficialWebSiteDataGridViewTextBoxColumn";
            this.fbOfficialWebSiteDataGridViewTextBoxColumn.Width = 117;
            // 
            // twOfficialWebSiteDataGridViewTextBoxColumn
            // 
            this.twOfficialWebSiteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.twOfficialWebSiteDataGridViewTextBoxColumn.DataPropertyName = "TwOfficialWebSite";
            this.twOfficialWebSiteDataGridViewTextBoxColumn.HeaderText = "TwOfficialWebSite";
            this.twOfficialWebSiteDataGridViewTextBoxColumn.Name = "twOfficialWebSiteDataGridViewTextBoxColumn";
            this.twOfficialWebSiteDataGridViewTextBoxColumn.Width = 120;
            // 
            // IgOfficialWebSite
            // 
            this.IgOfficialWebSite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IgOfficialWebSite.DataPropertyName = "IgOfficialWebSite";
            this.IgOfficialWebSite.HeaderText = "IgOfficialWebSite";
            this.IgOfficialWebSite.Name = "IgOfficialWebSite";
            this.IgOfficialWebSite.Width = 114;
            // 
            // GgOfficialWebSite
            // 
            this.GgOfficialWebSite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GgOfficialWebSite.DataPropertyName = "GgOfficialWebSite";
            this.GgOfficialWebSite.HeaderText = "GgOfficialWebSite";
            this.GgOfficialWebSite.Name = "GgOfficialWebSite";
            this.GgOfficialWebSite.Width = 119;
            // 
            // corporateBindingSource
            // 
            this.corporateBindingSource.DataMember = "Corporate";
            this.corporateBindingSource.DataSource = this.socialDataDB;
            // 
            // socialDataDB
            // 
            this.socialDataDB.DataSetName = "SocialData";
            this.socialDataDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ntrBrowser);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(915, 466);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Browser";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ntrBrowser
            // 
            this.ntrBrowser.DefaultDirectory = "";
            this.ntrBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntrBrowser.Location = new System.Drawing.Point(3, 3);
            this.ntrBrowser.Name = "ntrBrowser";
            this.ntrBrowser.NavigationAddress = "";
            this.ntrBrowser.NavigationMode = NTR_WebBrowser.NTR_Browser.eNavigationMode.Main;
            this.ntrBrowser.SelectedReportParser = null;
            this.ntrBrowser.ShowShortlist = false;
            this.ntrBrowser.ShowTransfer = false;
            this.ntrBrowser.Size = new System.Drawing.Size(909, 460);
            this.ntrBrowser.StartnavigationAddress = "";
            this.ntrBrowser.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(915, 466);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Facebook";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.corporateIDDataGridViewTextBoxColumn1,
            this.Week,
            this.likesDataGridViewTextBoxColumn,
            this.talkingDataGridViewTextBoxColumn,
            this.last14DaysLikesDataGridViewTextBoxColumn,
            this.BeenHere});
            this.dataGridView2.DataSource = this.facebookBindingSource1;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(909, 460);
            this.dataGridView2.TabIndex = 0;
            // 
            // corporateIDDataGridViewTextBoxColumn1
            // 
            this.corporateIDDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.corporateIDDataGridViewTextBoxColumn1.DataPropertyName = "CorporateID";
            this.corporateIDDataGridViewTextBoxColumn1.HeaderText = "CorporateID";
            this.corporateIDDataGridViewTextBoxColumn1.Name = "corporateIDDataGridViewTextBoxColumn1";
            this.corporateIDDataGridViewTextBoxColumn1.Width = 89;
            // 
            // Week
            // 
            this.Week.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Week.DataPropertyName = "Week";
            this.Week.HeaderText = "Week";
            this.Week.Name = "Week";
            this.Week.Width = 61;
            // 
            // likesDataGridViewTextBoxColumn
            // 
            this.likesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.likesDataGridViewTextBoxColumn.DataPropertyName = "Likes";
            this.likesDataGridViewTextBoxColumn.HeaderText = "Likes";
            this.likesDataGridViewTextBoxColumn.Name = "likesDataGridViewTextBoxColumn";
            this.likesDataGridViewTextBoxColumn.Width = 57;
            // 
            // talkingDataGridViewTextBoxColumn
            // 
            this.talkingDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.talkingDataGridViewTextBoxColumn.DataPropertyName = "Talking";
            this.talkingDataGridViewTextBoxColumn.HeaderText = "Talking";
            this.talkingDataGridViewTextBoxColumn.Name = "talkingDataGridViewTextBoxColumn";
            this.talkingDataGridViewTextBoxColumn.Width = 67;
            // 
            // last14DaysLikesDataGridViewTextBoxColumn
            // 
            this.last14DaysLikesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.last14DaysLikesDataGridViewTextBoxColumn.DataPropertyName = "Last14DaysLikes";
            this.last14DaysLikesDataGridViewTextBoxColumn.HeaderText = "Last14DaysLikes";
            this.last14DaysLikesDataGridViewTextBoxColumn.Name = "last14DaysLikesDataGridViewTextBoxColumn";
            this.last14DaysLikesDataGridViewTextBoxColumn.Width = 113;
            // 
            // BeenHere
            // 
            this.BeenHere.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BeenHere.DataPropertyName = "BeenHere";
            this.BeenHere.HeaderText = "BeenHere";
            this.BeenHere.Name = "BeenHere";
            this.BeenHere.Width = 80;
            // 
            // facebookBindingSource1
            // 
            this.facebookBindingSource1.DataMember = "Facebook";
            this.facebookBindingSource1.DataSource = this.socialDataDB;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridView3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(915, 466);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Twitter";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.corporateIDDataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.tweetsDataGridViewTextBoxColumn,
            this.followersDataGridViewTextBoxColumn,
            this.followingDataGridViewTextBoxColumn,
            this.likesDataGridViewTextBoxColumn1});
            this.dataGridView3.DataSource = this.twitterBindingSource;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(3, 3);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(909, 460);
            this.dataGridView3.TabIndex = 0;
            // 
            // corporateIDDataGridViewTextBoxColumn2
            // 
            this.corporateIDDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.corporateIDDataGridViewTextBoxColumn2.DataPropertyName = "CorporateID";
            this.corporateIDDataGridViewTextBoxColumn2.HeaderText = "CorporateID";
            this.corporateIDDataGridViewTextBoxColumn2.Name = "corporateIDDataGridViewTextBoxColumn2";
            this.corporateIDDataGridViewTextBoxColumn2.Width = 89;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Week";
            this.dataGridViewTextBoxColumn1.HeaderText = "Week";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 61;
            // 
            // tweetsDataGridViewTextBoxColumn
            // 
            this.tweetsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tweetsDataGridViewTextBoxColumn.DataPropertyName = "Tweets";
            this.tweetsDataGridViewTextBoxColumn.HeaderText = "Tweets";
            this.tweetsDataGridViewTextBoxColumn.Name = "tweetsDataGridViewTextBoxColumn";
            this.tweetsDataGridViewTextBoxColumn.Width = 67;
            // 
            // followersDataGridViewTextBoxColumn
            // 
            this.followersDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.followersDataGridViewTextBoxColumn.DataPropertyName = "Followers";
            this.followersDataGridViewTextBoxColumn.HeaderText = "Followers";
            this.followersDataGridViewTextBoxColumn.Name = "followersDataGridViewTextBoxColumn";
            this.followersDataGridViewTextBoxColumn.Width = 76;
            // 
            // followingDataGridViewTextBoxColumn
            // 
            this.followingDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.followingDataGridViewTextBoxColumn.DataPropertyName = "Following";
            this.followingDataGridViewTextBoxColumn.HeaderText = "Following";
            this.followingDataGridViewTextBoxColumn.Name = "followingDataGridViewTextBoxColumn";
            this.followingDataGridViewTextBoxColumn.Width = 76;
            // 
            // likesDataGridViewTextBoxColumn1
            // 
            this.likesDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.likesDataGridViewTextBoxColumn1.DataPropertyName = "Likes";
            this.likesDataGridViewTextBoxColumn1.HeaderText = "Likes";
            this.likesDataGridViewTextBoxColumn1.Name = "likesDataGridViewTextBoxColumn1";
            this.likesDataGridViewTextBoxColumn1.Width = 57;
            // 
            // twitterBindingSource
            // 
            this.twitterBindingSource.DataMember = "Twitter";
            this.twitterBindingSource.DataSource = this.socialDataDB;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dataGridView4);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(915, 466);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Instagram";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AutoGenerateColumns = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.corporateIDDataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2,
            this.postDataGridViewTextBoxColumn,
            this.followersDataGridViewTextBoxColumn1,
            this.followingDataGridViewTextBoxColumn1});
            this.dataGridView4.DataSource = this.instagramBindingSource;
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(3, 3);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.Size = new System.Drawing.Size(909, 460);
            this.dataGridView4.TabIndex = 0;
            // 
            // corporateIDDataGridViewTextBoxColumn3
            // 
            this.corporateIDDataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.corporateIDDataGridViewTextBoxColumn3.DataPropertyName = "CorporateID";
            this.corporateIDDataGridViewTextBoxColumn3.HeaderText = "CorporateID";
            this.corporateIDDataGridViewTextBoxColumn3.Name = "corporateIDDataGridViewTextBoxColumn3";
            this.corporateIDDataGridViewTextBoxColumn3.Width = 89;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Week";
            this.dataGridViewTextBoxColumn2.HeaderText = "Week";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 61;
            // 
            // postDataGridViewTextBoxColumn
            // 
            this.postDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.postDataGridViewTextBoxColumn.DataPropertyName = "Post";
            this.postDataGridViewTextBoxColumn.HeaderText = "Post";
            this.postDataGridViewTextBoxColumn.Name = "postDataGridViewTextBoxColumn";
            this.postDataGridViewTextBoxColumn.Width = 53;
            // 
            // followersDataGridViewTextBoxColumn1
            // 
            this.followersDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.followersDataGridViewTextBoxColumn1.DataPropertyName = "Followers";
            this.followersDataGridViewTextBoxColumn1.HeaderText = "Followers";
            this.followersDataGridViewTextBoxColumn1.Name = "followersDataGridViewTextBoxColumn1";
            this.followersDataGridViewTextBoxColumn1.Width = 76;
            // 
            // followingDataGridViewTextBoxColumn1
            // 
            this.followingDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.followingDataGridViewTextBoxColumn1.DataPropertyName = "Following";
            this.followingDataGridViewTextBoxColumn1.HeaderText = "Following";
            this.followingDataGridViewTextBoxColumn1.Name = "followingDataGridViewTextBoxColumn1";
            this.followingDataGridViewTextBoxColumn1.Width = 76;
            // 
            // instagramBindingSource
            // 
            this.instagramBindingSource.DataMember = "Instagram";
            this.instagramBindingSource.DataSource = this.socialDataDB;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.websitesToolStripMenuItem,
            this.scanToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(923, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCorporateListToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // saveCorporateListToolStripMenuItem
            // 
            this.saveCorporateListToolStripMenuItem.Name = "saveCorporateListToolStripMenuItem";
            this.saveCorporateListToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveCorporateListToolStripMenuItem.Text = "Save";
            this.saveCorporateListToolStripMenuItem.Click += new System.EventHandler(this.saveCorporateListToolStripMenuItem_Click);
            // 
            // websitesToolStripMenuItem
            // 
            this.websitesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoFacebookToolStripMenuItem,
            this.gotoTwitterToolStripMenuItem,
            this.gotoInstagramToolStripMenuItem});
            this.websitesToolStripMenuItem.Name = "websitesToolStripMenuItem";
            this.websitesToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.websitesToolStripMenuItem.Text = "Websites";
            // 
            // gotoFacebookToolStripMenuItem
            // 
            this.gotoFacebookToolStripMenuItem.Name = "gotoFacebookToolStripMenuItem";
            this.gotoFacebookToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.gotoFacebookToolStripMenuItem.Text = "Goto Facebook";
            this.gotoFacebookToolStripMenuItem.Click += new System.EventHandler(this.gotoFacebookToolStripMenuItem_Click);
            // 
            // gotoTwitterToolStripMenuItem
            // 
            this.gotoTwitterToolStripMenuItem.Name = "gotoTwitterToolStripMenuItem";
            this.gotoTwitterToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.gotoTwitterToolStripMenuItem.Text = "Goto Twitter";
            this.gotoTwitterToolStripMenuItem.Click += new System.EventHandler(this.gotoTwitterToolStripMenuItem_Click);
            // 
            // gotoInstagramToolStripMenuItem
            // 
            this.gotoInstagramToolStripMenuItem.Name = "gotoInstagramToolStripMenuItem";
            this.gotoInstagramToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.gotoInstagramToolStripMenuItem.Text = "Goto Instagram";
            this.gotoInstagramToolStripMenuItem.Click += new System.EventHandler(this.gotoInstagramToolStripMenuItem_Click);
            // 
            // scanToolStripMenuItem
            // 
            this.scanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startScanToolStripMenuItem,
            this.stopScanToolStripMenuItem,
            this.scanSelectedCorporateToolStripMenuItem,
            this.scanStartingFromSelectedCorporateToolStripMenuItem});
            this.scanToolStripMenuItem.Name = "scanToolStripMenuItem";
            this.scanToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.scanToolStripMenuItem.Text = "Scan";
            // 
            // startScanToolStripMenuItem
            // 
            this.startScanToolStripMenuItem.Name = "startScanToolStripMenuItem";
            this.startScanToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.startScanToolStripMenuItem.Text = "Start Scan";
            this.startScanToolStripMenuItem.Click += new System.EventHandler(this.startScanToolStripMenuItem_Click);
            // 
            // scanSelectedCorporateToolStripMenuItem
            // 
            this.scanSelectedCorporateToolStripMenuItem.Name = "scanSelectedCorporateToolStripMenuItem";
            this.scanSelectedCorporateToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.scanSelectedCorporateToolStripMenuItem.Text = "Scan Selected Corporate";
            this.scanSelectedCorporateToolStripMenuItem.Click += new System.EventHandler(this.scanSelectedCorporateToolStripMenuItem_Click);
            // 
            // stopScanToolStripMenuItem
            // 
            this.stopScanToolStripMenuItem.Name = "stopScanToolStripMenuItem";
            this.stopScanToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.stopScanToolStripMenuItem.Text = "Stop Scan";
            this.stopScanToolStripMenuItem.Click += new System.EventHandler(this.stopScanToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // facebookBindingSource
            // 
            this.facebookBindingSource.DataMember = "Facebook";
            this.facebookBindingSource.DataSource = this.socialDataDB;
            // 
            // scanStartingFromSelectedCorporateToolStripMenuItem
            // 
            this.scanStartingFromSelectedCorporateToolStripMenuItem.Name = "scanStartingFromSelectedCorporateToolStripMenuItem";
            this.scanStartingFromSelectedCorporateToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.scanStartingFromSelectedCorporateToolStripMenuItem.Text = "Scan Starting from selected Corporate";
            this.scanStartingFromSelectedCorporateToolStripMenuItem.Click += new System.EventHandler(this.scanStartingFromSelectedCorporateToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 516);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Social Scanner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorporate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.corporateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.socialDataDB)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookBindingSource1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twitterBindingSource)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instagramBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facebookBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvCorporate;
        private System.Windows.Forms.BindingSource corporateBindingSource;
        private SocialData socialDataDB;
        private System.Windows.Forms.TabPage tabPage2;
        private NTR_WebBrowser.NTR_Browser ntrBrowser;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.BindingSource facebookBindingSource;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource facebookBindingSource1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource twitterBindingSource;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource instagramBindingSource;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem saveCorporateListToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn instOfficialWebSiteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn corporateIDDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tweetsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn followersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn followingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn likesDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn corporateIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week;
        private System.Windows.Forms.DataGridViewTextBoxColumn likesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn talkingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn last14DaysLikesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeenHere;
        private System.Windows.Forms.DataGridViewTextBoxColumn corporateIDDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn postDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn followersDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn followingDataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripMenuItem websitesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoFacebookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoTwitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoInstagramToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn corporateIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn fbOfficialWebSiteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn twOfficialWebSiteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IgOfficialWebSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn GgOfficialWebSite;
        private System.Windows.Forms.ToolStripMenuItem scanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanSelectedCorporateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanStartingFromSelectedCorporateToolStripMenuItem;
    }
}

