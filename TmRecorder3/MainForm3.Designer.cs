namespace TmRecorder3
{
    partial class MainForm3
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm3));
            this.tsMainBar = new System.Windows.Forms.ToolStrip();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabSquad = new System.Windows.Forms.TabPage();
            this.chkBTeam = new System.Windows.Forms.CheckBox();
            this.chkO21 = new System.Windows.Forms.CheckBox();
            this.chkU21 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.qsMinRating = new NTR_Controls.QuantitySelector();
            this.cbDataDay = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgPlayers = new NTR_Controls.AeroDataGrid();
            this.contextMenuPlayersPage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.movePlayerToATeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movePlayerToBTeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabGK = new System.Windows.Forms.TabPage();
            this.chkBTeamGK = new System.Windows.Forms.CheckBox();
            this.chkO21GK = new System.Windows.Forms.CheckBox();
            this.chkU21GK = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.qsMinRatingGK = new NTR_Controls.QuantitySelector();
            this.cbDataDayGK = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgPlayersGK = new NTR_Controls.AeroDataGrid();
            this.tabBrowser = new System.Windows.Forms.TabPage();
            this.toolStripContainer3 = new System.Windows.Forms.ToolStripContainer();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.tsBrowserMain = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel11 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel12 = new System.Windows.Forms.ToolStripLabel();
            this.tsbProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsbProgressText = new System.Windows.Forms.ToolStripLabel();
            this.tsBrowseMatches = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBrowsePlayers = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.nTR_SquadDb = new NTR_Db.NTR_SquadDb();
            this.DB = new NTR_Db.Data(this.components);
            this.chkShowF = new System.Windows.Forms.CheckBox();
            this.chkShowOM = new System.Windows.Forms.CheckBox();
            this.chkShowM = new System.Windows.Forms.CheckBox();
            this.chkShowDM = new System.Windows.Forms.CheckBox();
            this.chkShowD = new System.Windows.Forms.CheckBox();
            this.tsbPrev = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbExtraTeam = new System.Windows.Forms.ToolStripDropDownButton();
            this.addExtraTeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbChangeToConfiguredExtraTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton16 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbGotoMainTrophyPage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbGotoAdobePage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbLoadHTMLPage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSendThisPageForDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrevMatch = new System.Windows.Forms.ToolStripButton();
            this.btnNextMatch = new System.Windows.Forms.ToolStripButton();
            this.tsbMatches = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbMatches0 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbMatches1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbMatches2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbMatches3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbMatches4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbMatches5 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMatchStored = new System.Windows.Forms.ToolStripLabel();
            this.tsbMatchNavigationType = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbNavigateMainTeamMatches = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNavigateReservesMatches = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbPrevPlayer = new System.Windows.Forms.ToolStripButton();
            this.tsbNextPlayer = new System.Windows.Forms.ToolStripButton();
            this.tsbPlayers = new System.Windows.Forms.ToolStripDropDownButton();
            this.gKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDefendersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dMDefenderMidfieldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mMidfieldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oMOffenderMidfieldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fForwardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNumberOfReviews = new System.Windows.Forms.ToolStripLabel();
            this.tsbNavigationType = new System.Windows.Forms.ToolStripDropDownButton();
            this.navigateProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigateReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.importDataFromTmR1xFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDataFromFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.varDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsBrowserImport = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel13 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.tsbImportSquad = new TMR_CostumControls.TMR_ToolStripButton();
            this.toolStripLabel14 = new System.Windows.Forms.ToolStripLabel();
            this.tsbScouts = new TMR_CostumControls.TMR_ToolStripButton();
            this.tsbTrainingTraining = new TMR_CostumControls.TMR_ToolStripButton();
            this.toolStripLabel15 = new System.Windows.Forms.ToolStripLabel();
            this.tsbMatchListA = new TMR_CostumControls.TMR_ToolStripButton();
            this.tsbMatchListB = new TMR_CostumControls.TMR_ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tsbMatchSquadA = new TMR_CostumControls.TMR_ToolStripButton();
            this.tsbMatchSquadB = new TMR_CostumControls.TMR_ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbImport = new TMR_CostumControls.TMR_ToolStripButton();
            this.tsMainBar.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabSquad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).BeginInit();
            this.contextMenuPlayersPage.SuspendLayout();
            this.tabGK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayersGK)).BeginInit();
            this.tabBrowser.SuspendLayout();
            this.toolStripContainer3.ContentPanel.SuspendLayout();
            this.toolStripContainer3.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer3.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer3.SuspendLayout();
            this.tsBrowserMain.SuspendLayout();
            this.tsBrowseMatches.SuspendLayout();
            this.tsBrowsePlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTR_SquadDb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varDataBindingSource)).BeginInit();
            this.tsBrowserImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMainBar
            // 
            this.tsMainBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton3});
            this.tsMainBar.Location = new System.Drawing.Point(0, 0);
            this.tsMainBar.Name = "tsMainBar";
            this.tsMainBar.Size = new System.Drawing.Size(951, 36);
            this.tsMainBar.TabIndex = 2;
            this.tsMainBar.Text = "toolStrip1";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabSquad);
            this.tabMain.Controls.Add(this.tabGK);
            this.tabMain.Controls.Add(this.tabBrowser);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 36);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(951, 446);
            this.tabMain.TabIndex = 3;
            // 
            // tabSquad
            // 
            this.tabSquad.Controls.Add(this.chkBTeam);
            this.tabSquad.Controls.Add(this.chkO21);
            this.tabSquad.Controls.Add(this.chkU21);
            this.tabSquad.Controls.Add(this.label2);
            this.tabSquad.Controls.Add(this.qsMinRating);
            this.tabSquad.Controls.Add(this.chkShowF);
            this.tabSquad.Controls.Add(this.chkShowOM);
            this.tabSquad.Controls.Add(this.chkShowM);
            this.tabSquad.Controls.Add(this.chkShowDM);
            this.tabSquad.Controls.Add(this.chkShowD);
            this.tabSquad.Controls.Add(this.cbDataDay);
            this.tabSquad.Controls.Add(this.label1);
            this.tabSquad.Controls.Add(this.dgPlayers);
            this.tabSquad.Location = new System.Drawing.Point(4, 22);
            this.tabSquad.Name = "tabSquad";
            this.tabSquad.Padding = new System.Windows.Forms.Padding(3);
            this.tabSquad.Size = new System.Drawing.Size(943, 420);
            this.tabSquad.TabIndex = 0;
            this.tabSquad.Text = "Field Players";
            this.tabSquad.UseVisualStyleBackColor = true;
            // 
            // chkBTeam
            // 
            this.chkBTeam.AutoSize = true;
            this.chkBTeam.Location = new System.Drawing.Point(715, 6);
            this.chkBTeam.Name = "chkBTeam";
            this.chkBTeam.Size = new System.Drawing.Size(63, 17);
            this.chkBTeam.TabIndex = 8;
            this.chkBTeam.Text = "B-Team";
            this.chkBTeam.UseVisualStyleBackColor = true;
            this.chkBTeam.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkO21
            // 
            this.chkO21.AutoSize = true;
            this.chkO21.Location = new System.Drawing.Point(663, 6);
            this.chkO21.Name = "chkO21";
            this.chkO21.Size = new System.Drawing.Size(47, 17);
            this.chkO21.TabIndex = 8;
            this.chkO21.Text = "O21";
            this.chkO21.UseVisualStyleBackColor = true;
            this.chkO21.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkU21
            // 
            this.chkU21.AutoSize = true;
            this.chkU21.Location = new System.Drawing.Point(611, 6);
            this.chkU21.Name = "chkU21";
            this.chkU21.Size = new System.Drawing.Size(46, 17);
            this.chkU21.TabIndex = 8;
            this.chkU21.Text = "U21";
            this.chkU21.UseVisualStyleBackColor = true;
            this.chkU21.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Min. Rating";
            // 
            // qsMinRating
            // 
            this.qsMinRating.Location = new System.Drawing.Point(507, 5);
            this.qsMinRating.Name = "qsMinRating";
            this.qsMinRating.Size = new System.Drawing.Size(85, 17);
            this.qsMinRating.TabIndex = 6;
            this.qsMinRating.Value = 0F;
            this.qsMinRating.ValueChanged += new NTR_Controls.QuantitySelector.ValueChangedHandler(this.qsMinRating_ValueChanged);
            // 
            // cbDataDay
            // 
            this.cbDataDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataDay.FormattingEnabled = true;
            this.cbDataDay.Location = new System.Drawing.Point(82, 4);
            this.cbDataDay.Name = "cbDataDay";
            this.cbDataDay.Size = new System.Drawing.Size(106, 21);
            this.cbDataDay.TabIndex = 4;
            this.cbDataDay.SelectedIndexChanged += new System.EventHandler(this.cbDataDay_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Weeks Data";
            // 
            // dgPlayers
            // 
            this.dgPlayers.AllowUserToAddRows = false;
            this.dgPlayers.AllowUserToDeleteRows = false;
            this.dgPlayers.AllowUserToOrderColumns = true;
            this.dgPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPlayers.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPlayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlayers.ContextMenuStrip = this.contextMenuPlayersPage;
            this.dgPlayers.DataCollection = null;
            this.dgPlayers.Location = new System.Drawing.Point(3, 27);
            this.dgPlayers.Name = "dgPlayers";
            this.dgPlayers.ReadOnly = true;
            this.dgPlayers.RowHeadersWidth = 20;
            this.dgPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPlayers.Size = new System.Drawing.Size(937, 391);
            this.dgPlayers.TabIndex = 1;
            this.dgPlayers.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPlayers_ColumnHeaderMouseClick);
            // 
            // contextMenuPlayersPage
            // 
            this.contextMenuPlayersPage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movePlayerToATeamToolStripMenuItem,
            this.movePlayerToBTeamToolStripMenuItem});
            this.contextMenuPlayersPage.Name = "contextMenuPlayersPage";
            this.contextMenuPlayersPage.Size = new System.Drawing.Size(209, 48);
            this.contextMenuPlayersPage.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuPlayersPage_Opening);
            // 
            // movePlayerToATeamToolStripMenuItem
            // 
            this.movePlayerToATeamToolStripMenuItem.Name = "movePlayerToATeamToolStripMenuItem";
            this.movePlayerToATeamToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.movePlayerToATeamToolStripMenuItem.Text = "Move Player To Main Team";
            this.movePlayerToATeamToolStripMenuItem.Click += new System.EventHandler(this.movePlayerToATeamToolStripMenuItem_Click);
            // 
            // movePlayerToBTeamToolStripMenuItem
            // 
            this.movePlayerToBTeamToolStripMenuItem.Name = "movePlayerToBTeamToolStripMenuItem";
            this.movePlayerToBTeamToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.movePlayerToBTeamToolStripMenuItem.Text = "Move Player To B Team";
            this.movePlayerToBTeamToolStripMenuItem.Click += new System.EventHandler(this.movePlayerToBTeamToolStripMenuItem_Click);
            // 
            // tabGK
            // 
            this.tabGK.Controls.Add(this.chkBTeamGK);
            this.tabGK.Controls.Add(this.chkO21GK);
            this.tabGK.Controls.Add(this.chkU21GK);
            this.tabGK.Controls.Add(this.label3);
            this.tabGK.Controls.Add(this.qsMinRatingGK);
            this.tabGK.Controls.Add(this.cbDataDayGK);
            this.tabGK.Controls.Add(this.label4);
            this.tabGK.Controls.Add(this.dgPlayersGK);
            this.tabGK.Location = new System.Drawing.Point(4, 22);
            this.tabGK.Name = "tabGK";
            this.tabGK.Padding = new System.Windows.Forms.Padding(3);
            this.tabGK.Size = new System.Drawing.Size(943, 420);
            this.tabGK.TabIndex = 1;
            this.tabGK.Text = "Goalkeepers";
            this.tabGK.UseVisualStyleBackColor = true;
            // 
            // chkBTeamGK
            // 
            this.chkBTeamGK.AutoSize = true;
            this.chkBTeamGK.Location = new System.Drawing.Point(487, 6);
            this.chkBTeamGK.Name = "chkBTeamGK";
            this.chkBTeamGK.Size = new System.Drawing.Size(63, 17);
            this.chkBTeamGK.TabIndex = 19;
            this.chkBTeamGK.Text = "B-Team";
            this.chkBTeamGK.UseVisualStyleBackColor = true;
            this.chkBTeamGK.CheckedChanged += new System.EventHandler(this.chkShowGK_CheckedChanged);
            // 
            // chkO21GK
            // 
            this.chkO21GK.AutoSize = true;
            this.chkO21GK.Location = new System.Drawing.Point(435, 6);
            this.chkO21GK.Name = "chkO21GK";
            this.chkO21GK.Size = new System.Drawing.Size(47, 17);
            this.chkO21GK.TabIndex = 20;
            this.chkO21GK.Text = "O21";
            this.chkO21GK.UseVisualStyleBackColor = true;
            this.chkO21GK.CheckedChanged += new System.EventHandler(this.chkShowGK_CheckedChanged);
            // 
            // chkU21GK
            // 
            this.chkU21GK.AutoSize = true;
            this.chkU21GK.Location = new System.Drawing.Point(383, 6);
            this.chkU21GK.Name = "chkU21GK";
            this.chkU21GK.Size = new System.Drawing.Size(46, 17);
            this.chkU21GK.TabIndex = 21;
            this.chkU21GK.Text = "U21";
            this.chkU21GK.UseVisualStyleBackColor = true;
            this.chkU21GK.CheckedChanged += new System.EventHandler(this.chkShowGK_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Min. Rating";
            // 
            // qsMinRatingGK
            // 
            this.qsMinRatingGK.Location = new System.Drawing.Point(279, 5);
            this.qsMinRatingGK.Name = "qsMinRatingGK";
            this.qsMinRatingGK.Size = new System.Drawing.Size(85, 17);
            this.qsMinRatingGK.TabIndex = 17;
            this.qsMinRatingGK.Value = 0F;
            this.qsMinRatingGK.ValueChanged += new NTR_Controls.QuantitySelector.ValueChangedHandler(this.qsMinRatingGK_ValueChanged);
            // 
            // cbDataDayGK
            // 
            this.cbDataDayGK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataDayGK.FormattingEnabled = true;
            this.cbDataDayGK.Location = new System.Drawing.Point(82, 4);
            this.cbDataDayGK.Name = "cbDataDayGK";
            this.cbDataDayGK.Size = new System.Drawing.Size(106, 21);
            this.cbDataDayGK.TabIndex = 11;
            this.cbDataDayGK.SelectedIndexChanged += new System.EventHandler(this.cbDataDayGK_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Weeks Data";
            // 
            // dgPlayersGK
            // 
            this.dgPlayersGK.AllowUserToAddRows = false;
            this.dgPlayersGK.AllowUserToDeleteRows = false;
            this.dgPlayersGK.AllowUserToOrderColumns = true;
            this.dgPlayersGK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPlayersGK.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPlayersGK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgPlayersGK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlayersGK.ContextMenuStrip = this.contextMenuPlayersPage;
            this.dgPlayersGK.DataCollection = null;
            this.dgPlayersGK.Location = new System.Drawing.Point(3, 27);
            this.dgPlayersGK.Name = "dgPlayersGK";
            this.dgPlayersGK.ReadOnly = true;
            this.dgPlayersGK.RowHeadersWidth = 20;
            this.dgPlayersGK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPlayersGK.Size = new System.Drawing.Size(937, 391);
            this.dgPlayersGK.TabIndex = 9;
            this.dgPlayersGK.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPlayersGK_ColumnHeaderMouseClick);
            // 
            // tabBrowser
            // 
            this.tabBrowser.Controls.Add(this.toolStripContainer3);
            this.tabBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabBrowser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabBrowser.Name = "tabBrowser";
            this.tabBrowser.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabBrowser.Size = new System.Drawing.Size(943, 420);
            this.tabBrowser.TabIndex = 9;
            this.tabBrowser.Text = "Trophy Browser";
            this.tabBrowser.UseVisualStyleBackColor = true;
            // 
            // toolStripContainer3
            // 
            // 
            // toolStripContainer3.ContentPanel
            // 
            this.toolStripContainer3.ContentPanel.Controls.Add(this.webBrowser);
            this.toolStripContainer3.ContentPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolStripContainer3.ContentPanel.Size = new System.Drawing.Size(844, 387);
            this.toolStripContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer3.LeftToolStripPanel
            // 
            this.toolStripContainer3.LeftToolStripPanel.Controls.Add(this.tsBrowserImport);
            this.toolStripContainer3.Location = new System.Drawing.Point(3, 4);
            this.toolStripContainer3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolStripContainer3.Name = "toolStripContainer3";
            this.toolStripContainer3.Size = new System.Drawing.Size(937, 412);
            this.toolStripContainer3.TabIndex = 0;
            this.toolStripContainer3.Text = "toolStripContainer3";
            // 
            // toolStripContainer3.TopToolStripPanel
            // 
            this.toolStripContainer3.TopToolStripPanel.Controls.Add(this.tsBrowseMatches);
            this.toolStripContainer3.TopToolStripPanel.Controls.Add(this.tsBrowserMain);
            this.toolStripContainer3.TopToolStripPanel.Controls.Add(this.tsBrowsePlayers);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.webBrowser.MinimumSize = new System.Drawing.Size(23, 23);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(844, 387);
            this.webBrowser.TabIndex = 1;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
            this.webBrowser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser_ProgressChanged);
            // 
            // tsBrowserMain
            // 
            this.tsBrowserMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBrowserMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel10,
            this.tsbPrev,
            this.tsbNext,
            this.toolStripSeparator16,
            this.toolStripLabel11,
            this.tsbExtraTeam,
            this.toolStripDropDownButton16,
            this.toolStripSeparator18,
            this.toolStripLabel12,
            this.tsbProgressBar,
            this.tsbProgressText});
            this.tsBrowserMain.Location = new System.Drawing.Point(3, 0);
            this.tsBrowserMain.Name = "tsBrowserMain";
            this.tsBrowserMain.Size = new System.Drawing.Size(585, 25);
            this.tsBrowserMain.TabIndex = 3;
            this.tsBrowserMain.Text = "toolStrip4";
            // 
            // toolStripLabel10
            // 
            this.toolStripLabel10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolStripLabel10.Name = "toolStripLabel10";
            this.toolStripLabel10.Size = new System.Drawing.Size(67, 22);
            this.toolStripLabel10.Text = "Navigation";
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel11
            // 
            this.toolStripLabel11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolStripLabel11.Name = "toolStripLabel11";
            this.toolStripLabel11.Size = new System.Drawing.Size(61, 22);
            this.toolStripLabel11.Text = "TM Pages";
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel12
            // 
            this.toolStripLabel12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel12.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolStripLabel12.Name = "toolStripLabel12";
            this.toolStripLabel12.Size = new System.Drawing.Size(87, 22);
            this.toolStripLabel12.Text = "Load progress";
            // 
            // tsbProgressBar
            // 
            this.tsbProgressBar.Name = "tsbProgressBar";
            this.tsbProgressBar.Size = new System.Drawing.Size(92, 22);
            this.tsbProgressBar.Step = 5;
            // 
            // tsbProgressText
            // 
            this.tsbProgressText.Name = "tsbProgressText";
            this.tsbProgressText.Size = new System.Drawing.Size(10, 22);
            this.tsbProgressText.Text = " ";
            // 
            // tsBrowseMatches
            // 
            this.tsBrowseMatches.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBrowseMatches.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel7,
            this.btnPrevMatch,
            this.btnNextMatch,
            this.toolStripSeparator13,
            this.toolStripLabel8,
            this.tsbMatches,
            this.toolStripSeparator14,
            this.lblMatchStored,
            this.tsbMatchNavigationType});
            this.tsBrowseMatches.Location = new System.Drawing.Point(3, 0);
            this.tsBrowseMatches.Name = "tsBrowseMatches";
            this.tsBrowseMatches.Size = new System.Drawing.Size(777, 25);
            this.tsBrowseMatches.TabIndex = 2;
            this.tsBrowseMatches.Text = "toolStrip2";
            this.tsBrowseMatches.Visible = false;
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(99, 22);
            this.toolStripLabel7.Text = "Browse Matches";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel8.Text = "Match";
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBrowsePlayers
            // 
            this.tsBrowsePlayers.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBrowsePlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel6,
            this.tsbPrevPlayer,
            this.tsbNextPlayer,
            this.toolStripSeparator10,
            this.toolStripLabel9,
            this.tsbPlayers,
            this.toolStripSeparator12,
            this.tsbNumberOfReviews,
            this.tsbNavigationType});
            this.tsBrowsePlayers.Location = new System.Drawing.Point(3, 25);
            this.tsBrowsePlayers.Name = "tsBrowsePlayers";
            this.tsBrowsePlayers.Size = new System.Drawing.Size(780, 25);
            this.tsBrowsePlayers.TabIndex = 2;
            this.tsBrowsePlayers.Text = "toolStrip2";
            this.tsBrowsePlayers.Visible = false;
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(93, 22);
            this.toolStripLabel6.Text = "Browse Players";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel9
            // 
            this.toolStripLabel9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolStripLabel9.Name = "toolStripLabel9";
            this.toolStripLabel9.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel9.Text = "Player";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // nTR_SquadDb
            // 
            this.nTR_SquadDb.DataSetName = "NTR_SquadDb";
            this.nTR_SquadDb.GDS = null;
            this.nTR_SquadDb.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DB
            // 
            this.DB.latestDataDay = new System.DateTime(((long)(0)));
            // 
            // chkShowF
            // 
            this.chkShowF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowF.Image = ((System.Drawing.Image)(resources.GetObject("chkShowF.Image")));
            this.chkShowF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowF.Location = new System.Drawing.Point(387, 3);
            this.chkShowF.Name = "chkShowF";
            this.chkShowF.Size = new System.Drawing.Size(40, 22);
            this.chkShowF.TabIndex = 5;
            this.chkShowF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowF.UseVisualStyleBackColor = true;
            this.chkShowF.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkShowOM
            // 
            this.chkShowOM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowOM.Image = ((System.Drawing.Image)(resources.GetObject("chkShowOM.Image")));
            this.chkShowOM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowOM.Location = new System.Drawing.Point(341, 3);
            this.chkShowOM.Name = "chkShowOM";
            this.chkShowOM.Size = new System.Drawing.Size(40, 22);
            this.chkShowOM.TabIndex = 5;
            this.chkShowOM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowOM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowOM.UseVisualStyleBackColor = true;
            this.chkShowOM.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkShowM
            // 
            this.chkShowM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowM.Image = ((System.Drawing.Image)(resources.GetObject("chkShowM.Image")));
            this.chkShowM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowM.Location = new System.Drawing.Point(295, 3);
            this.chkShowM.Name = "chkShowM";
            this.chkShowM.Size = new System.Drawing.Size(40, 22);
            this.chkShowM.TabIndex = 5;
            this.chkShowM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowM.UseVisualStyleBackColor = true;
            this.chkShowM.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkShowDM
            // 
            this.chkShowDM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowDM.Image = ((System.Drawing.Image)(resources.GetObject("chkShowDM.Image")));
            this.chkShowDM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowDM.Location = new System.Drawing.Point(249, 3);
            this.chkShowDM.Name = "chkShowDM";
            this.chkShowDM.Size = new System.Drawing.Size(40, 22);
            this.chkShowDM.TabIndex = 5;
            this.chkShowDM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowDM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowDM.UseVisualStyleBackColor = true;
            this.chkShowDM.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkShowD
            // 
            this.chkShowD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowD.Image = ((System.Drawing.Image)(resources.GetObject("chkShowD.Image")));
            this.chkShowD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowD.Location = new System.Drawing.Point(203, 3);
            this.chkShowD.Name = "chkShowD";
            this.chkShowD.Size = new System.Drawing.Size(40, 22);
            this.chkShowD.TabIndex = 5;
            this.chkShowD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowD.UseVisualStyleBackColor = true;
            this.chkShowD.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // tsbPrev
            // 
            this.tsbPrev.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrev.Image")));
            this.tsbPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrev.Name = "tsbPrev";
            this.tsbPrev.Size = new System.Drawing.Size(48, 22);
            this.tsbPrev.Text = "Prev";
            this.tsbPrev.Click += new System.EventHandler(this.tsbPrev_Click);
            // 
            // tsbNext
            // 
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(50, 22);
            this.tsbNext.Text = "Next";
            this.tsbNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // tsbExtraTeam
            // 
            this.tsbExtraTeam.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addExtraTeamToolStripMenuItem,
            this.tsbChangeToConfiguredExtraTeam});
            this.tsbExtraTeam.Image = ((System.Drawing.Image)(resources.GetObject("tsbExtraTeam.Image")));
            this.tsbExtraTeam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExtraTeam.Name = "tsbExtraTeam";
            this.tsbExtraTeam.Size = new System.Drawing.Size(90, 22);
            this.tsbExtraTeam.Text = "Extra Team";
            // 
            // addExtraTeamToolStripMenuItem
            // 
            this.addExtraTeamToolStripMenuItem.Name = "addExtraTeamToolStripMenuItem";
            this.addExtraTeamToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.addExtraTeamToolStripMenuItem.Text = "Add Extra Team";
            this.addExtraTeamToolStripMenuItem.Click += new System.EventHandler(this.addExtraTeamToolStripMenuItem_Click_1);
            // 
            // tsbChangeToConfiguredExtraTeam
            // 
            this.tsbChangeToConfiguredExtraTeam.Name = "tsbChangeToConfiguredExtraTeam";
            this.tsbChangeToConfiguredExtraTeam.Size = new System.Drawing.Size(256, 22);
            this.tsbChangeToConfiguredExtraTeam.Text = "Change Browser to the actual Team";
            this.tsbChangeToConfiguredExtraTeam.Click += new System.EventHandler(this.tsbChangeToConfiguredExtraTeam_Click);
            // 
            // toolStripDropDownButton16
            // 
            this.toolStripDropDownButton16.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGotoMainTrophyPage,
            this.tsbGotoAdobePage,
            this.tsbLoadHTMLPage,
            this.toolStripSeparator17,
            this.tsbSendThisPageForDebug});
            this.toolStripDropDownButton16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton16.Image")));
            this.toolStripDropDownButton16.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton16.Name = "toolStripDropDownButton16";
            this.toolStripDropDownButton16.Size = new System.Drawing.Size(54, 22);
            this.toolStripDropDownButton16.Text = "File";
            // 
            // tsbGotoMainTrophyPage
            // 
            this.tsbGotoMainTrophyPage.Name = "tsbGotoMainTrophyPage";
            this.tsbGotoMainTrophyPage.Size = new System.Drawing.Size(323, 22);
            this.tsbGotoMainTrophyPage.Text = "Goto Main TrophyManager page";
            this.tsbGotoMainTrophyPage.Click += new System.EventHandler(this.gotoMToolStripMenuItem_Click);
            // 
            // tsbGotoAdobePage
            // 
            this.tsbGotoAdobePage.Name = "tsbGotoAdobePage";
            this.tsbGotoAdobePage.Size = new System.Drawing.Size(323, 22);
            this.tsbGotoAdobePage.Text = "Goto Adobe Flashplayer page";
            this.tsbGotoAdobePage.Click += new System.EventHandler(this.gotoAdobeFlashplayerPageToolStripMenuItem_Click);
            // 
            // tsbLoadHTMLPage
            // 
            this.tsbLoadHTMLPage.Name = "tsbLoadHTMLPage";
            this.tsbLoadHTMLPage.Size = new System.Drawing.Size(323, 22);
            this.tsbLoadHTMLPage.Text = "Load HTML file (Squad,Training,Calendar,Players)";
            this.tsbLoadHTMLPage.Click += new System.EventHandler(this.loadFromBackupFilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(320, 6);
            // 
            // tsbSendThisPageForDebug
            // 
            this.tsbSendThisPageForDebug.Name = "tsbSendThisPageForDebug";
            this.tsbSendThisPageForDebug.Size = new System.Drawing.Size(323, 22);
            this.tsbSendThisPageForDebug.Text = "Send this page to LedLennon for Debug";
            this.tsbSendThisPageForDebug.Click += new System.EventHandler(this.sendThisPageToLedLennonForDebugToolStripMenuItem_Click);
            // 
            // btnPrevMatch
            // 
            this.btnPrevMatch.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevMatch.Image")));
            this.btnPrevMatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevMatch.Name = "btnPrevMatch";
            this.btnPrevMatch.Size = new System.Drawing.Size(48, 22);
            this.btnPrevMatch.Text = "Prev";
            // 
            // btnNextMatch
            // 
            this.btnNextMatch.Image = ((System.Drawing.Image)(resources.GetObject("btnNextMatch.Image")));
            this.btnNextMatch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNextMatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNextMatch.Name = "btnNextMatch";
            this.btnNextMatch.Size = new System.Drawing.Size(50, 22);
            this.btnNextMatch.Text = "Next";
            this.btnNextMatch.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // tsbMatches
            // 
            this.tsbMatches.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMatches0,
            this.tsbMatches1,
            this.tsbMatches2,
            this.tsbMatches3,
            this.tsbMatches4,
            this.tsbMatches5});
            this.tsbMatches.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbMatches.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tsbMatches.Image = ((System.Drawing.Image)(resources.GetObject("tsbMatches.Image")));
            this.tsbMatches.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMatches.Name = "tsbMatches";
            this.tsbMatches.Size = new System.Drawing.Size(237, 22);
            this.tsbMatches.Text = "[Ca] Atletico Granata - JampalOOza";
            // 
            // tsbMatches0
            // 
            this.tsbMatches0.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tsbMatches0.Name = "tsbMatches0";
            this.tsbMatches0.Size = new System.Drawing.Size(149, 22);
            this.tsbMatches0.Text = "[Ca] Matches";
            // 
            // tsbMatches1
            // 
            this.tsbMatches1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tsbMatches1.Name = "tsbMatches1";
            this.tsbMatches1.Size = new System.Drawing.Size(149, 22);
            this.tsbMatches1.Text = "[FL] Matches";
            // 
            // tsbMatches2
            // 
            this.tsbMatches2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tsbMatches2.Name = "tsbMatches2";
            this.tsbMatches2.Size = new System.Drawing.Size(149, 22);
            this.tsbMatches2.Text = "[F] Matches";
            // 
            // tsbMatches3
            // 
            this.tsbMatches3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tsbMatches3.Name = "tsbMatches3";
            this.tsbMatches3.Size = new System.Drawing.Size(149, 22);
            this.tsbMatches3.Text = "[Co] Matches";
            // 
            // tsbMatches4
            // 
            this.tsbMatches4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tsbMatches4.Name = "tsbMatches4";
            this.tsbMatches4.Size = new System.Drawing.Size(149, 22);
            this.tsbMatches4.Text = "[Co] Matches";
            // 
            // tsbMatches5
            // 
            this.tsbMatches5.ForeColor = System.Drawing.Color.Blue;
            this.tsbMatches5.Name = "tsbMatches5";
            this.tsbMatches5.Size = new System.Drawing.Size(149, 22);
            this.tsbMatches5.Text = "[Co] Matches";
            // 
            // lblMatchStored
            // 
            this.lblMatchStored.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMatchStored.Image = ((System.Drawing.Image)(resources.GetObject("lblMatchStored.Image")));
            this.lblMatchStored.Name = "lblMatchStored";
            this.lblMatchStored.Size = new System.Drawing.Size(92, 22);
            this.lblMatchStored.Text = "Match Stored";
            // 
            // tsbMatchNavigationType
            // 
            this.tsbMatchNavigationType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNavigateMainTeamMatches,
            this.tsbNavigateReservesMatches});
            this.tsbMatchNavigationType.Image = ((System.Drawing.Image)(resources.GetObject("tsbMatchNavigationType.Image")));
            this.tsbMatchNavigationType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMatchNavigationType.Name = "tsbMatchNavigationType";
            this.tsbMatchNavigationType.Size = new System.Drawing.Size(185, 22);
            this.tsbMatchNavigationType.Text = "Navigate Main Team Matches";
            // 
            // tsbNavigateMainTeamMatches
            // 
            this.tsbNavigateMainTeamMatches.Image = ((System.Drawing.Image)(resources.GetObject("tsbNavigateMainTeamMatches.Image")));
            this.tsbNavigateMainTeamMatches.Name = "tsbNavigateMainTeamMatches";
            this.tsbNavigateMainTeamMatches.Size = new System.Drawing.Size(223, 22);
            this.tsbNavigateMainTeamMatches.Text = "Navigate Main Team Matches";
            // 
            // tsbNavigateReservesMatches
            // 
            this.tsbNavigateReservesMatches.Image = ((System.Drawing.Image)(resources.GetObject("tsbNavigateReservesMatches.Image")));
            this.tsbNavigateReservesMatches.Name = "tsbNavigateReservesMatches";
            this.tsbNavigateReservesMatches.Size = new System.Drawing.Size(223, 22);
            this.tsbNavigateReservesMatches.Text = "Navigate Reserves Matches";
            // 
            // tsbPrevPlayer
            // 
            this.tsbPrevPlayer.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrevPlayer.Image")));
            this.tsbPrevPlayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrevPlayer.Name = "tsbPrevPlayer";
            this.tsbPrevPlayer.Size = new System.Drawing.Size(48, 22);
            this.tsbPrevPlayer.Text = "Prev";
            // 
            // tsbNextPlayer
            // 
            this.tsbNextPlayer.Image = ((System.Drawing.Image)(resources.GetObject("tsbNextPlayer.Image")));
            this.tsbNextPlayer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNextPlayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNextPlayer.Name = "tsbNextPlayer";
            this.tsbNextPlayer.Size = new System.Drawing.Size(50, 22);
            this.tsbNextPlayer.Text = "Next";
            this.tsbNextPlayer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // tsbPlayers
            // 
            this.tsbPlayers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gKToolStripMenuItem,
            this.dDefendersToolStripMenuItem,
            this.dMDefenderMidfieldersToolStripMenuItem,
            this.mMidfieldersToolStripMenuItem,
            this.oMOffenderMidfieldersToolStripMenuItem,
            this.fForwardsToolStripMenuItem});
            this.tsbPlayers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbPlayers.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tsbPlayers.Image = ((System.Drawing.Image)(resources.GetObject("tsbPlayers.Image")));
            this.tsbPlayers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPlayers.Name = "tsbPlayers";
            this.tsbPlayers.Size = new System.Drawing.Size(254, 22);
            this.tsbPlayers.Text = "[FC] Robert \"O Baixinho\" Scherpenzeel";
            // 
            // gKToolStripMenuItem
            // 
            this.gKToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gKToolStripMenuItem.Name = "gKToolStripMenuItem";
            this.gKToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.gKToolStripMenuItem.Text = "GK - Goalkeepers";
            // 
            // dDefendersToolStripMenuItem
            // 
            this.dDefendersToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dDefendersToolStripMenuItem.Name = "dDefendersToolStripMenuItem";
            this.dDefendersToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.dDefendersToolStripMenuItem.Text = "D - Defenders";
            // 
            // dMDefenderMidfieldersToolStripMenuItem
            // 
            this.dMDefenderMidfieldersToolStripMenuItem.ForeColor = System.Drawing.Color.Lime;
            this.dMDefenderMidfieldersToolStripMenuItem.Name = "dMDefenderMidfieldersToolStripMenuItem";
            this.dMDefenderMidfieldersToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.dMDefenderMidfieldersToolStripMenuItem.Text = "DM - Defender/Midfielders";
            // 
            // mMidfieldersToolStripMenuItem
            // 
            this.mMidfieldersToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.mMidfieldersToolStripMenuItem.Name = "mMidfieldersToolStripMenuItem";
            this.mMidfieldersToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.mMidfieldersToolStripMenuItem.Text = "M - Midfielders";
            // 
            // oMOffenderMidfieldersToolStripMenuItem
            // 
            this.oMOffenderMidfieldersToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.oMOffenderMidfieldersToolStripMenuItem.Name = "oMOffenderMidfieldersToolStripMenuItem";
            this.oMOffenderMidfieldersToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.oMOffenderMidfieldersToolStripMenuItem.Text = "OM - Offender/Midfielders";
            // 
            // fForwardsToolStripMenuItem
            // 
            this.fForwardsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fForwardsToolStripMenuItem.Name = "fForwardsToolStripMenuItem";
            this.fForwardsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.fForwardsToolStripMenuItem.Text = "F - Forwards";
            // 
            // tsbNumberOfReviews
            // 
            this.tsbNumberOfReviews.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tsbNumberOfReviews.Image = ((System.Drawing.Image)(resources.GetObject("tsbNumberOfReviews.Image")));
            this.tsbNumberOfReviews.Name = "tsbNumberOfReviews";
            this.tsbNumberOfReviews.Size = new System.Drawing.Size(146, 22);
            this.tsbNumberOfReviews.Text = "2 Scouts Reviews stored";
            // 
            // tsbNavigationType
            // 
            this.tsbNavigationType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigateProfilesToolStripMenuItem,
            this.navigateReportsToolStripMenuItem});
            this.tsbNavigationType.Image = ((System.Drawing.Image)(resources.GetObject("tsbNavigationType.Image")));
            this.tsbNavigationType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNavigationType.Name = "tsbNavigationType";
            this.tsbNavigationType.Size = new System.Drawing.Size(122, 22);
            this.tsbNavigationType.Text = "Navigate Profiles";
            // 
            // navigateProfilesToolStripMenuItem
            // 
            this.navigateProfilesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("navigateProfilesToolStripMenuItem.Image")));
            this.navigateProfilesToolStripMenuItem.Name = "navigateProfilesToolStripMenuItem";
            this.navigateProfilesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.navigateProfilesToolStripMenuItem.Text = "Navigate Profiles";
            // 
            // navigateReportsToolStripMenuItem
            // 
            this.navigateReportsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("navigateReportsToolStripMenuItem.Image")));
            this.navigateReportsToolStripMenuItem.Name = "navigateReportsToolStripMenuItem";
            this.navigateReportsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.navigateReportsToolStripMenuItem.Text = "Navigate Reports";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDataFromTmR1xFormatToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 33);
            this.toolStripDropDownButton1.Text = "File";
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // importDataFromTmR1xFormatToolStripMenuItem
            // 
            this.importDataFromTmR1xFormatToolStripMenuItem.Name = "importDataFromTmR1xFormatToolStripMenuItem";
            this.importDataFromTmR1xFormatToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.importDataFromTmR1xFormatToolStripMenuItem.Text = "Import Data from TmR 1.x format";
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOptions,
            this.reloadDataFromFilesToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(47, 33);
            this.toolStripDropDownButton3.Text = "Tools";
            this.toolStripDropDownButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsOptions
            // 
            this.tsOptions.Name = "tsOptions";
            this.tsOptions.Size = new System.Drawing.Size(188, 22);
            this.tsOptions.Text = "Options";
            this.tsOptions.Click += new System.EventHandler(this.tsOptions_Click);
            // 
            // reloadDataFromFilesToolStripMenuItem
            // 
            this.reloadDataFromFilesToolStripMenuItem.Name = "reloadDataFromFilesToolStripMenuItem";
            this.reloadDataFromFilesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.reloadDataFromFilesToolStripMenuItem.Text = "Reload Data from files";
            this.reloadDataFromFilesToolStripMenuItem.Click += new System.EventHandler(this.reloadDataFromFilesToolStripMenuItem_Click);
            // 
            // varDataBindingSource
            // 
            this.varDataBindingSource.DataSource = typeof(NTR_Db.PlayerData);
            // 
            // tsBrowserImport
            // 
            this.tsBrowserImport.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBrowserImport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel13,
            this.toolStripLabel2,
            this.toolStripSeparator8,
            this.toolStripLabel5,
            this.tsbImportSquad,
            this.toolStripLabel14,
            this.tsbScouts,
            this.tsbTrainingTraining,
            this.toolStripLabel15,
            this.tsbMatchListA,
            this.tsbMatchListB,
            this.toolStripLabel4,
            this.tsbMatchSquadA,
            this.tsbMatchSquadB,
            this.toolStripSeparator11,
            this.tsbImport});
            this.tsBrowserImport.Location = new System.Drawing.Point(0, 3);
            this.tsBrowserImport.Name = "tsBrowserImport";
            this.tsBrowserImport.Size = new System.Drawing.Size(93, 348);
            this.tsBrowserImport.TabIndex = 2;
            this.tsBrowserImport.Text = "toolStrip4";
            // 
            // toolStripLabel13
            // 
            this.toolStripLabel13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel13.ForeColor = System.Drawing.Color.Navy;
            this.toolStripLabel13.Name = "toolStripLabel13";
            this.toolStripLabel13.Size = new System.Drawing.Size(91, 13);
            this.toolStripLabel13.Text = "Automatic";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Navy;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(91, 13);
            this.toolStripLabel2.Text = "Import Panel";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(91, 6);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(91, 13);
            this.toolStripLabel5.Text = "Squad Data";
            // 
            // tsbImportSquad
            // 
            this.tsbImportSquad.AutoSize = false;
            this.tsbImportSquad.BackColor = System.Drawing.SystemColors.Control;
            this.tsbImportSquad.Image = ((System.Drawing.Image)(resources.GetObject("tsbImportSquad.Image")));
            this.tsbImportSquad.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbImportSquad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImportSquad.Name = "tsbImportSquad";
            this.tsbImportSquad.Size = new System.Drawing.Size(92, 25);
            this.tsbImportSquad.Text = "Squad";
            this.tsbImportSquad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tsbImportSquad.UnderAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbImportSquad.UnderColor = System.Drawing.Color.CadetBlue;
            this.tsbImportSquad.UnderFont = new System.Drawing.Font("Arial", 7.25F);
            this.tsbImportSquad.UnderText = "";
            this.tsbImportSquad.Click += new System.EventHandler(this.tsbImportSquad_Click);
            // 
            // toolStripLabel14
            // 
            this.toolStripLabel14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel14.Name = "toolStripLabel14";
            this.toolStripLabel14.Size = new System.Drawing.Size(91, 13);
            this.toolStripLabel14.Text = "Training";
            // 
            // tsbScouts
            // 
            this.tsbScouts.AutoSize = false;
            this.tsbScouts.BackColor = System.Drawing.SystemColors.Control;
            this.tsbScouts.Image = ((System.Drawing.Image)(resources.GetObject("tsbScouts.Image")));
            this.tsbScouts.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbScouts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbScouts.Name = "tsbScouts";
            this.tsbScouts.Size = new System.Drawing.Size(92, 25);
            this.tsbScouts.Text = "Scouts";
            this.tsbScouts.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tsbScouts.UnderAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbScouts.UnderColor = System.Drawing.Color.CadetBlue;
            this.tsbScouts.UnderFont = new System.Drawing.Font("Arial", 7.25F);
            this.tsbScouts.UnderText = "";
            this.tsbScouts.Click += new System.EventHandler(this.tsbScouts_Click);
            // 
            // tsbTrainingTraining
            // 
            this.tsbTrainingTraining.AutoSize = false;
            this.tsbTrainingTraining.BackColor = System.Drawing.SystemColors.Control;
            this.tsbTrainingTraining.Image = ((System.Drawing.Image)(resources.GetObject("tsbTrainingTraining.Image")));
            this.tsbTrainingTraining.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbTrainingTraining.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTrainingTraining.Name = "tsbTrainingTraining";
            this.tsbTrainingTraining.Size = new System.Drawing.Size(92, 25);
            this.tsbTrainingTraining.Text = "Training";
            this.tsbTrainingTraining.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tsbTrainingTraining.UnderAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbTrainingTraining.UnderColor = System.Drawing.Color.CadetBlue;
            this.tsbTrainingTraining.UnderFont = new System.Drawing.Font("Arial", 7.25F);
            this.tsbTrainingTraining.UnderText = "";
            this.tsbTrainingTraining.Click += new System.EventHandler(this.tsbTrainingTraining_Click);
            // 
            // toolStripLabel15
            // 
            this.toolStripLabel15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel15.Name = "toolStripLabel15";
            this.toolStripLabel15.Size = new System.Drawing.Size(91, 13);
            this.toolStripLabel15.Text = "Matches List";
            // 
            // tsbMatchListA
            // 
            this.tsbMatchListA.AutoSize = false;
            this.tsbMatchListA.BackColor = System.Drawing.SystemColors.Control;
            this.tsbMatchListA.Image = ((System.Drawing.Image)(resources.GetObject("tsbMatchListA.Image")));
            this.tsbMatchListA.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbMatchListA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMatchListA.Name = "tsbMatchListA";
            this.tsbMatchListA.Size = new System.Drawing.Size(92, 25);
            this.tsbMatchListA.Text = "List A";
            this.tsbMatchListA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tsbMatchListA.UnderAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbMatchListA.UnderColor = System.Drawing.Color.CadetBlue;
            this.tsbMatchListA.UnderFont = new System.Drawing.Font("Arial", 7.25F);
            this.tsbMatchListA.UnderText = "";
            this.tsbMatchListA.Click += new System.EventHandler(this.tsbMatchListA_Click);
            // 
            // tsbMatchListB
            // 
            this.tsbMatchListB.AutoSize = false;
            this.tsbMatchListB.BackColor = System.Drawing.SystemColors.Control;
            this.tsbMatchListB.Image = ((System.Drawing.Image)(resources.GetObject("tsbMatchListB.Image")));
            this.tsbMatchListB.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbMatchListB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMatchListB.Name = "tsbMatchListB";
            this.tsbMatchListB.Size = new System.Drawing.Size(92, 25);
            this.tsbMatchListB.Text = "List B";
            this.tsbMatchListB.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tsbMatchListB.UnderAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbMatchListB.UnderColor = System.Drawing.Color.CadetBlue;
            this.tsbMatchListB.UnderFont = new System.Drawing.Font("Arial", 7.25F);
            this.tsbMatchListB.UnderText = "";
            this.tsbMatchListB.Click += new System.EventHandler(this.tsbMatchListB_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(91, 13);
            this.toolStripLabel4.Text = "Matches";
            // 
            // tsbMatchSquadA
            // 
            this.tsbMatchSquadA.AutoSize = false;
            this.tsbMatchSquadA.BackColor = System.Drawing.SystemColors.Control;
            this.tsbMatchSquadA.Image = ((System.Drawing.Image)(resources.GetObject("tsbMatchSquadA.Image")));
            this.tsbMatchSquadA.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbMatchSquadA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMatchSquadA.Name = "tsbMatchSquadA";
            this.tsbMatchSquadA.Size = new System.Drawing.Size(92, 25);
            this.tsbMatchSquadA.Text = "Squad A";
            this.tsbMatchSquadA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tsbMatchSquadA.ToolTipText = "Squad A";
            this.tsbMatchSquadA.UnderAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbMatchSquadA.UnderColor = System.Drawing.Color.CadetBlue;
            this.tsbMatchSquadA.UnderFont = new System.Drawing.Font("Arial", 7.25F);
            this.tsbMatchSquadA.UnderText = "";
            this.tsbMatchSquadA.Click += new System.EventHandler(this.tsbMatchSquadA_Click);
            // 
            // tsbMatchSquadB
            // 
            this.tsbMatchSquadB.AutoSize = false;
            this.tsbMatchSquadB.BackColor = System.Drawing.SystemColors.Control;
            this.tsbMatchSquadB.Image = ((System.Drawing.Image)(resources.GetObject("tsbMatchSquadB.Image")));
            this.tsbMatchSquadB.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbMatchSquadB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMatchSquadB.Name = "tsbMatchSquadB";
            this.tsbMatchSquadB.Size = new System.Drawing.Size(92, 25);
            this.tsbMatchSquadB.Text = "Squad B";
            this.tsbMatchSquadB.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tsbMatchSquadB.ToolTipText = "Squad B";
            this.tsbMatchSquadB.UnderAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbMatchSquadB.UnderColor = System.Drawing.Color.CadetBlue;
            this.tsbMatchSquadB.UnderFont = new System.Drawing.Font("Arial", 7.25F);
            this.tsbMatchSquadB.UnderText = "";
            this.tsbMatchSquadB.Click += new System.EventHandler(this.tsbMatchSquadB_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(91, 6);
            // 
            // tsbImport
            // 
            this.tsbImport.AutoSize = false;
            this.tsbImport.BackColor = System.Drawing.SystemColors.Control;
            this.tsbImport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbImport.Image = ((System.Drawing.Image)(resources.GetObject("tsbImport.Image")));
            this.tsbImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Size = new System.Drawing.Size(91, 30);
            this.tsbImport.Text = "Import";
            this.tsbImport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbImport.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsbImport.UnderAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbImport.UnderColor = System.Drawing.Color.Black;
            this.tsbImport.UnderFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbImport.UnderText = "Page";
            this.tsbImport.Click += new System.EventHandler(this.tsbImport_Click);
            // 
            // MainForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 482);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.tsMainBar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm3";
            this.Text = "TmRecorder 3.x.x.x";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tsMainBar.ResumeLayout(false);
            this.tsMainBar.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabSquad.ResumeLayout(false);
            this.tabSquad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).EndInit();
            this.contextMenuPlayersPage.ResumeLayout(false);
            this.tabGK.ResumeLayout(false);
            this.tabGK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayersGK)).EndInit();
            this.tabBrowser.ResumeLayout(false);
            this.toolStripContainer3.ContentPanel.ResumeLayout(false);
            this.toolStripContainer3.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer3.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer3.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer3.TopToolStripPanel.PerformLayout();
            this.toolStripContainer3.ResumeLayout(false);
            this.toolStripContainer3.PerformLayout();
            this.tsBrowserMain.ResumeLayout(false);
            this.tsBrowserMain.PerformLayout();
            this.tsBrowseMatches.ResumeLayout(false);
            this.tsBrowseMatches.PerformLayout();
            this.tsBrowsePlayers.ResumeLayout(false);
            this.tsBrowsePlayers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTR_SquadDb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varDataBindingSource)).EndInit();
            this.tsBrowserImport.ResumeLayout(false);
            this.tsBrowserImport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NTR_Db.NTR_SquadDb nTR_SquadDb;
        private System.Windows.Forms.BindingSource varDataBindingSource;
        private NTR_Db.Data DB;
        private System.Windows.Forms.ToolStrip tsMainBar;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem importDataFromTmR1xFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem tsOptions;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabSquad;
        private NTR_Controls.AeroDataGrid dgPlayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem reloadDataFromFilesToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbDataDay;
        private System.Windows.Forms.CheckBox chkShowD;
        private System.Windows.Forms.Label label2;
        private NTR_Controls.QuantitySelector qsMinRating;
        private System.Windows.Forms.CheckBox chkShowF;
        private System.Windows.Forms.CheckBox chkShowOM;
        private System.Windows.Forms.CheckBox chkShowM;
        private System.Windows.Forms.CheckBox chkShowDM;
        private System.Windows.Forms.CheckBox chkBTeam;
        private System.Windows.Forms.CheckBox chkU21;
        private System.Windows.Forms.CheckBox chkO21;
        private System.Windows.Forms.TabPage tabGK;
        private System.Windows.Forms.CheckBox chkBTeamGK;
        private System.Windows.Forms.CheckBox chkO21GK;
        private System.Windows.Forms.CheckBox chkU21GK;
        private System.Windows.Forms.Label label3;
        private NTR_Controls.QuantitySelector qsMinRatingGK;
        private System.Windows.Forms.ComboBox cbDataDayGK;
        private System.Windows.Forms.Label label4;
        private NTR_Controls.AeroDataGrid dgPlayersGK;
        private System.Windows.Forms.ContextMenuStrip contextMenuPlayersPage;
        private System.Windows.Forms.ToolStripMenuItem movePlayerToATeamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movePlayerToBTeamToolStripMenuItem;
        private System.Windows.Forms.TabPage tabBrowser;
        private System.Windows.Forms.ToolStripContainer toolStripContainer3;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStrip tsBrowserMain;
        private System.Windows.Forms.ToolStripLabel toolStripLabel10;
        private System.Windows.Forms.ToolStripButton tsbPrev;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripLabel toolStripLabel11;
        private System.Windows.Forms.ToolStripDropDownButton tsbExtraTeam;
        private System.Windows.Forms.ToolStripMenuItem addExtraTeamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsbChangeToConfiguredExtraTeam;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton16;
        private System.Windows.Forms.ToolStripMenuItem tsbGotoMainTrophyPage;
        private System.Windows.Forms.ToolStripMenuItem tsbGotoAdobePage;
        private System.Windows.Forms.ToolStripMenuItem tsbLoadHTMLPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem tsbSendThisPageForDebug;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripLabel toolStripLabel12;
        private System.Windows.Forms.ToolStripProgressBar tsbProgressBar;
        private System.Windows.Forms.ToolStripLabel tsbProgressText;
        private System.Windows.Forms.ToolStrip tsBrowseMatches;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripButton btnPrevMatch;
        private System.Windows.Forms.ToolStripButton btnNextMatch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private System.Windows.Forms.ToolStripDropDownButton tsbMatches;
        private System.Windows.Forms.ToolStripMenuItem tsbMatches0;
        private System.Windows.Forms.ToolStripMenuItem tsbMatches1;
        private System.Windows.Forms.ToolStripMenuItem tsbMatches2;
        private System.Windows.Forms.ToolStripMenuItem tsbMatches3;
        private System.Windows.Forms.ToolStripMenuItem tsbMatches4;
        private System.Windows.Forms.ToolStripMenuItem tsbMatches5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripLabel lblMatchStored;
        private System.Windows.Forms.ToolStripDropDownButton tsbMatchNavigationType;
        private System.Windows.Forms.ToolStripMenuItem tsbNavigateMainTeamMatches;
        private System.Windows.Forms.ToolStripMenuItem tsbNavigateReservesMatches;
        private System.Windows.Forms.ToolStrip tsBrowsePlayers;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripButton tsbPrevPlayer;
        private System.Windows.Forms.ToolStripButton tsbNextPlayer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripLabel toolStripLabel9;
        private System.Windows.Forms.ToolStripDropDownButton tsbPlayers;
        private System.Windows.Forms.ToolStripMenuItem gKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDefendersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dMDefenderMidfieldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mMidfieldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oMOffenderMidfieldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fForwardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripLabel tsbNumberOfReviews;
        private System.Windows.Forms.ToolStripDropDownButton tsbNavigationType;
        private System.Windows.Forms.ToolStripMenuItem navigateProfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navigateReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tsBrowserImport;
        private System.Windows.Forms.ToolStripLabel toolStripLabel13;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private TMR_CostumControls.TMR_ToolStripButton tsbImportSquad;
        private System.Windows.Forms.ToolStripLabel toolStripLabel14;
        private TMR_CostumControls.TMR_ToolStripButton tsbScouts;
        private TMR_CostumControls.TMR_ToolStripButton tsbTrainingTraining;
        private System.Windows.Forms.ToolStripLabel toolStripLabel15;
        private TMR_CostumControls.TMR_ToolStripButton tsbMatchListA;
        private TMR_CostumControls.TMR_ToolStripButton tsbMatchListB;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private TMR_CostumControls.TMR_ToolStripButton tsbMatchSquadA;
        private TMR_CostumControls.TMR_ToolStripButton tsbMatchSquadB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private TMR_CostumControls.TMR_ToolStripButton tsbImport;
    }
}

