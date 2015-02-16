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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm3));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMainBar = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.importDataFromTmR1xFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDataFromFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadOldReleaseDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAndImportAllSavedPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recalculateDecimalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabSquad = new System.Windows.Forms.TabPage();
            this.chkBTeam = new System.Windows.Forms.CheckBox();
            this.chkO21 = new System.Windows.Forms.CheckBox();
            this.chkU21 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.qsMinRating = new NTR_Controls.QuantitySelector();
            this.chkShowF = new System.Windows.Forms.CheckBox();
            this.chkShowOM = new System.Windows.Forms.CheckBox();
            this.chkShowM = new System.Windows.Forms.CheckBox();
            this.chkShowDM = new System.Windows.Forms.CheckBox();
            this.chkShowD = new System.Windows.Forms.CheckBox();
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
            this.cbDataDayGK = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgPlayersGK = new NTR_Controls.AeroDataGrid();
            this.qsMinRatingGK = new NTR_Controls.QuantitySelector();
            this.tabMatches = new System.Windows.Forms.TabPage();
            this.lineupControl = new FieldFormationControl.RotLineupControl();
            this.lblNameTeamAway = new System.Windows.Forms.Label();
            this.btnEnlargeMatchWindow = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblNameTeamHome = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkHome = new System.Windows.Forms.CheckBox();
            this.chkAway = new System.Windows.Forms.CheckBox();
            this.dgMatches = new NTR_Controls.AeroDataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkMT1 = new System.Windows.Forms.CheckBox();
            this.chkMT2 = new System.Windows.Forms.CheckBox();
            this.chkMT3 = new System.Windows.Forms.CheckBox();
            this.chkMT4 = new System.Windows.Forms.CheckBox();
            this.chkMT5 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbSeason = new System.Windows.Forms.ComboBox();
            this.tabBrowser = new System.Windows.Forms.TabPage();
            this.ntrBrowser = new NTR_Controls.NTR_Browser();
            this.tsBrowserImport = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel13 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
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
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.nTR_SquadDb = new NTR_Db.NTR_SquadDb();
            this.DB = new NTR_Db.Data(this.components);
            this.varDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsMainBar.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabSquad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).BeginInit();
            this.contextMenuPlayersPage.SuspendLayout();
            this.tabGK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayersGK)).BeginInit();
            this.tabMatches.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMatches)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabBrowser.SuspendLayout();
            this.tsBrowserImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTR_SquadDb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMainBar
            // 
            this.tsMainBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton3});
            this.tsMainBar.Location = new System.Drawing.Point(0, 0);
            this.tsMainBar.Name = "tsMainBar";
            this.tsMainBar.Size = new System.Drawing.Size(1212, 36);
            this.tsMainBar.TabIndex = 2;
            this.tsMainBar.Text = "toolStrip1";
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
            this.reloadDataFromFilesToolStripMenuItem,
            this.reloadOldReleaseDBToolStripMenuItem,
            this.searchAndImportAllSavedPagesToolStripMenuItem,
            this.recalculateDecimalsToolStripMenuItem});
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
            this.tsOptions.Size = new System.Drawing.Size(249, 22);
            this.tsOptions.Text = "Options";
            this.tsOptions.Click += new System.EventHandler(this.tsOptions_Click);
            // 
            // reloadDataFromFilesToolStripMenuItem
            // 
            this.reloadDataFromFilesToolStripMenuItem.Name = "reloadDataFromFilesToolStripMenuItem";
            this.reloadDataFromFilesToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.reloadDataFromFilesToolStripMenuItem.Text = "Reload DB";
            this.reloadDataFromFilesToolStripMenuItem.Click += new System.EventHandler(this.reloadDataFromFilesToolStripMenuItem_Click);
            // 
            // reloadOldReleaseDBToolStripMenuItem
            // 
            this.reloadOldReleaseDBToolStripMenuItem.Name = "reloadOldReleaseDBToolStripMenuItem";
            this.reloadOldReleaseDBToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.reloadOldReleaseDBToolStripMenuItem.Text = "Reload Old Version DB";
            this.reloadOldReleaseDBToolStripMenuItem.Click += new System.EventHandler(this.reloadOldReleaseDBToolStripMenuItem_Click);
            // 
            // searchAndImportAllSavedPagesToolStripMenuItem
            // 
            this.searchAndImportAllSavedPagesToolStripMenuItem.Name = "searchAndImportAllSavedPagesToolStripMenuItem";
            this.searchAndImportAllSavedPagesToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.searchAndImportAllSavedPagesToolStripMenuItem.Text = "Search and import all saved pages";
            this.searchAndImportAllSavedPagesToolStripMenuItem.Click += new System.EventHandler(this.searchAndImportAllSavedPagesToolStripMenuItem_Click);
            // 
            // recalculateDecimalsToolStripMenuItem
            // 
            this.recalculateDecimalsToolStripMenuItem.Name = "recalculateDecimalsToolStripMenuItem";
            this.recalculateDecimalsToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.recalculateDecimalsToolStripMenuItem.Text = "Recalculate decimals";
            this.recalculateDecimalsToolStripMenuItem.Click += new System.EventHandler(this.recalculateDecimalsToolStripMenuItem_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabSquad);
            this.tabMain.Controls.Add(this.tabGK);
            this.tabMain.Controls.Add(this.tabMatches);
            this.tabMain.Controls.Add(this.tabBrowser);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 36);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1212, 559);
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
            this.tabSquad.Size = new System.Drawing.Size(1204, 533);
            this.tabSquad.TabIndex = 0;
            this.tabSquad.Text = "Field Players";
            this.tabSquad.UseVisualStyleBackColor = true;
            // 
            // chkBTeam
            // 
            this.chkBTeam.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBTeam.Location = new System.Drawing.Point(669, 3);
            this.chkBTeam.Name = "chkBTeam";
            this.chkBTeam.Size = new System.Drawing.Size(63, 21);
            this.chkBTeam.TabIndex = 8;
            this.chkBTeam.Text = "B-Team";
            this.chkBTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBTeam.UseVisualStyleBackColor = true;
            this.chkBTeam.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkO21
            // 
            this.chkO21.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkO21.Location = new System.Drawing.Point(624, 3);
            this.chkO21.Name = "chkO21";
            this.chkO21.Size = new System.Drawing.Size(39, 21);
            this.chkO21.TabIndex = 8;
            this.chkO21.Text = "O21";
            this.chkO21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkO21.UseVisualStyleBackColor = true;
            this.chkO21.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkU21
            // 
            this.chkU21.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkU21.Location = new System.Drawing.Point(578, 3);
            this.chkU21.Name = "chkU21";
            this.chkU21.Size = new System.Drawing.Size(39, 21);
            this.chkU21.TabIndex = 8;
            this.chkU21.Text = "U21";
            this.chkU21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkU21.UseVisualStyleBackColor = true;
            this.chkU21.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Min. Rating";
            // 
            // qsMinRating
            // 
            this.qsMinRating.Location = new System.Drawing.Point(475, 5);
            this.qsMinRating.Name = "qsMinRating";
            this.qsMinRating.Size = new System.Drawing.Size(85, 17);
            this.qsMinRating.TabIndex = 6;
            this.qsMinRating.Value = 0F;
            this.qsMinRating.ValueChanged += new NTR_Controls.QuantitySelector.ValueChangedHandler(this.qsMinRating_ValueChanged);
            // 
            // chkShowF
            // 
            this.chkShowF.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowF.BackgroundImage = global::TmRecorder3.Properties.Resources.F;
            this.chkShowF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chkShowF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowF.Location = new System.Drawing.Point(363, 3);
            this.chkShowF.Name = "chkShowF";
            this.chkShowF.Size = new System.Drawing.Size(32, 20);
            this.chkShowF.TabIndex = 5;
            this.chkShowF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowF.UseVisualStyleBackColor = true;
            this.chkShowF.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkShowOM
            // 
            this.chkShowOM.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowOM.BackgroundImage = global::TmRecorder3.Properties.Resources.OM;
            this.chkShowOM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chkShowOM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowOM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowOM.Location = new System.Drawing.Point(323, 3);
            this.chkShowOM.Name = "chkShowOM";
            this.chkShowOM.Size = new System.Drawing.Size(32, 20);
            this.chkShowOM.TabIndex = 5;
            this.chkShowOM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowOM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowOM.UseVisualStyleBackColor = true;
            this.chkShowOM.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkShowM
            // 
            this.chkShowM.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowM.BackgroundImage = global::TmRecorder3.Properties.Resources.M;
            this.chkShowM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chkShowM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowM.Location = new System.Drawing.Point(283, 3);
            this.chkShowM.Name = "chkShowM";
            this.chkShowM.Size = new System.Drawing.Size(32, 20);
            this.chkShowM.TabIndex = 5;
            this.chkShowM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowM.UseVisualStyleBackColor = true;
            this.chkShowM.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkShowDM
            // 
            this.chkShowDM.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowDM.BackgroundImage = global::TmRecorder3.Properties.Resources.DM;
            this.chkShowDM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chkShowDM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowDM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowDM.Location = new System.Drawing.Point(243, 3);
            this.chkShowDM.Name = "chkShowDM";
            this.chkShowDM.Size = new System.Drawing.Size(32, 20);
            this.chkShowDM.TabIndex = 5;
            this.chkShowDM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowDM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowDM.UseVisualStyleBackColor = true;
            this.chkShowDM.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // chkShowD
            // 
            this.chkShowD.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowD.BackColor = System.Drawing.Color.Transparent;
            this.chkShowD.BackgroundImage = global::TmRecorder3.Properties.Resources.D;
            this.chkShowD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chkShowD.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.chkShowD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkShowD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkShowD.Location = new System.Drawing.Point(203, 3);
            this.chkShowD.Name = "chkShowD";
            this.chkShowD.Size = new System.Drawing.Size(32, 20);
            this.chkShowD.TabIndex = 5;
            this.chkShowD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkShowD.UseVisualStyleBackColor = false;
            this.chkShowD.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
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
            this.dgPlayers.Size = new System.Drawing.Size(1198, 503);
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
            this.tabGK.Controls.Add(this.cbDataDayGK);
            this.tabGK.Controls.Add(this.label4);
            this.tabGK.Controls.Add(this.dgPlayersGK);
            this.tabGK.Controls.Add(this.qsMinRatingGK);
            this.tabGK.Location = new System.Drawing.Point(4, 22);
            this.tabGK.Name = "tabGK";
            this.tabGK.Padding = new System.Windows.Forms.Padding(3);
            this.tabGK.Size = new System.Drawing.Size(1204, 533);
            this.tabGK.TabIndex = 1;
            this.tabGK.Text = "Goalkeepers";
            this.tabGK.UseVisualStyleBackColor = true;
            // 
            // chkBTeamGK
            // 
            this.chkBTeamGK.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBTeamGK.Location = new System.Drawing.Point(487, 3);
            this.chkBTeamGK.Name = "chkBTeamGK";
            this.chkBTeamGK.Size = new System.Drawing.Size(63, 21);
            this.chkBTeamGK.TabIndex = 19;
            this.chkBTeamGK.Text = "B-Team";
            this.chkBTeamGK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBTeamGK.UseVisualStyleBackColor = true;
            this.chkBTeamGK.CheckedChanged += new System.EventHandler(this.chkShowGK_CheckedChanged);
            // 
            // chkO21GK
            // 
            this.chkO21GK.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkO21GK.Location = new System.Drawing.Point(435, 3);
            this.chkO21GK.Name = "chkO21GK";
            this.chkO21GK.Size = new System.Drawing.Size(47, 21);
            this.chkO21GK.TabIndex = 20;
            this.chkO21GK.Text = "O21";
            this.chkO21GK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkO21GK.UseVisualStyleBackColor = true;
            this.chkO21GK.CheckedChanged += new System.EventHandler(this.chkShowGK_CheckedChanged);
            // 
            // chkU21GK
            // 
            this.chkU21GK.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkU21GK.Location = new System.Drawing.Point(383, 3);
            this.chkU21GK.Name = "chkU21GK";
            this.chkU21GK.Size = new System.Drawing.Size(46, 21);
            this.chkU21GK.TabIndex = 21;
            this.chkU21GK.Text = "U21";
            this.chkU21GK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.dgPlayersGK.Size = new System.Drawing.Size(1198, 501);
            this.dgPlayersGK.TabIndex = 9;
            this.dgPlayersGK.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPlayersGK_ColumnHeaderMouseClick);
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
            // tabMatches
            // 
            this.tabMatches.Controls.Add(this.lineupControl);
            this.tabMatches.Controls.Add(this.lblNameTeamAway);
            this.tabMatches.Controls.Add(this.btnEnlargeMatchWindow);
            this.tabMatches.Controls.Add(this.lblScore);
            this.tabMatches.Controls.Add(this.lblNameTeamHome);
            this.tabMatches.Controls.Add(this.btnHelp);
            this.tabMatches.Controls.Add(this.groupBox4);
            this.tabMatches.Controls.Add(this.dgMatches);
            this.tabMatches.Controls.Add(this.groupBox1);
            this.tabMatches.Controls.Add(this.groupBox3);
            this.tabMatches.Controls.Add(this.groupBox2);
            this.tabMatches.Location = new System.Drawing.Point(4, 22);
            this.tabMatches.Name = "tabMatches";
            this.tabMatches.Padding = new System.Windows.Forms.Padding(3);
            this.tabMatches.Size = new System.Drawing.Size(1204, 533);
            this.tabMatches.TabIndex = 10;
            this.tabMatches.Text = "Matches";
            this.tabMatches.UseVisualStyleBackColor = true;
            this.tabMatches.Resize += new System.EventHandler(this.tabMatches_Resize);
            // 
            // lineupControl
            // 
            this.lineupControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineupControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lineupControl.BackgroundImage")));
            this.lineupControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lineupControl.Location = new System.Drawing.Point(560, 30);
            this.lineupControl.MatchFile = "";
            this.lineupControl.Name = "lineupControl";
            this.lineupControl.OppFormationType = Common.eFormationTypes.Type_4_4_2;
            this.lineupControl.Size = new System.Drawing.Size(636, 374);
            this.lineupControl.TabIndex = 1;
            this.lineupControl.YourFormationType = Common.eFormationTypes.Type_4_4_2;
            // 
            // lblNameTeamAway
            // 
            this.lblNameTeamAway.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameTeamAway.Location = new System.Drawing.Point(905, 3);
            this.lblNameTeamAway.Name = "lblNameTeamAway";
            this.lblNameTeamAway.Size = new System.Drawing.Size(261, 24);
            this.lblNameTeamAway.TabIndex = 2;
            this.lblNameTeamAway.Text = "Team2";
            this.lblNameTeamAway.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEnlargeMatchWindow
            // 
            this.btnEnlargeMatchWindow.Location = new System.Drawing.Point(505, 40);
            this.btnEnlargeMatchWindow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEnlargeMatchWindow.Name = "btnEnlargeMatchWindow";
            this.btnEnlargeMatchWindow.Size = new System.Drawing.Size(39, 20);
            this.btnEnlargeMatchWindow.TabIndex = 10;
            this.btnEnlargeMatchWindow.Text = ">>";
            this.btnEnlargeMatchWindow.UseVisualStyleBackColor = true;
            this.btnEnlargeMatchWindow.Click += new System.EventHandler(this.btnEnlargeMatchWindow_Click);
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(836, 3);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(63, 24);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "0 - 0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNameTeamHome
            // 
            this.lblNameTeamHome.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameTeamHome.Location = new System.Drawing.Point(555, 3);
            this.lblNameTeamHome.Name = "lblNameTeamHome";
            this.lblNameTeamHome.Size = new System.Drawing.Size(275, 24);
            this.lblNameTeamHome.TabIndex = 2;
            this.lblNameTeamHome.Text = "Team1";
            this.lblNameTeamHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(505, 17);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(39, 21);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkHome);
            this.groupBox4.Controls.Add(this.chkAway);
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox4.Location = new System.Drawing.Point(430, 2);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(69, 67);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Location";
            // 
            // chkHome
            // 
            this.chkHome.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkHome.ForeColor = System.Drawing.Color.Black;
            this.chkHome.Location = new System.Drawing.Point(7, 15);
            this.chkHome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkHome.Name = "chkHome";
            this.chkHome.Size = new System.Drawing.Size(56, 21);
            this.chkHome.TabIndex = 2;
            this.chkHome.Text = "Home";
            this.chkHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkHome.UseVisualStyleBackColor = true;
            // 
            // chkAway
            // 
            this.chkAway.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAway.ForeColor = System.Drawing.Color.Black;
            this.chkAway.Location = new System.Drawing.Point(7, 38);
            this.chkAway.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAway.Name = "chkAway";
            this.chkAway.Size = new System.Drawing.Size(56, 21);
            this.chkAway.TabIndex = 2;
            this.chkAway.Text = "Away";
            this.chkAway.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAway.UseVisualStyleBackColor = true;
            // 
            // dgMatches
            // 
            this.dgMatches.AllowUserToAddRows = false;
            this.dgMatches.AllowUserToDeleteRows = false;
            this.dgMatches.AllowUserToResizeRows = false;
            this.dgMatches.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgMatches.AutoGenerateColumns = false;
            this.dgMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgMatches.DataCollection = null;
            this.dgMatches.Location = new System.Drawing.Point(3, 75);
            this.dgMatches.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgMatches.MultiSelect = false;
            this.dgMatches.Name = "dgMatches";
            this.dgMatches.ReadOnly = true;
            this.dgMatches.RowHeadersWidth = 20;
            this.dgMatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMatches.Size = new System.Drawing.Size(542, 452);
            this.dgMatches.TabIndex = 1;
            this.dgMatches.SelectionChanged += new System.EventHandler(this.dgMatches_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkMT1);
            this.groupBox1.Controls.Add(this.chkMT2);
            this.groupBox1.Controls.Add(this.chkMT3);
            this.groupBox1.Controls.Add(this.chkMT4);
            this.groupBox1.Controls.Add(this.chkMT5);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(187, 67);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Match Type";
            // 
            // chkMT1
            // 
            this.chkMT1.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMT1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMT1.Location = new System.Drawing.Point(6, 15);
            this.chkMT1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkMT1.Name = "chkMT1";
            this.chkMT1.Size = new System.Drawing.Size(57, 21);
            this.chkMT1.TabIndex = 2;
            this.chkMT1.Text = "League";
            this.chkMT1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMT1.UseVisualStyleBackColor = true;
            // 
            // chkMT2
            // 
            this.chkMT2.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMT2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMT2.Location = new System.Drawing.Point(65, 15);
            this.chkMT2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkMT2.Name = "chkMT2";
            this.chkMT2.Size = new System.Drawing.Size(57, 21);
            this.chkMT2.TabIndex = 2;
            this.chkMT2.Text = "Cup";
            this.chkMT2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMT2.UseVisualStyleBackColor = true;
            // 
            // chkMT3
            // 
            this.chkMT3.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMT3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMT3.Location = new System.Drawing.Point(124, 15);
            this.chkMT3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkMT3.Name = "chkMT3";
            this.chkMT3.Size = new System.Drawing.Size(57, 21);
            this.chkMT3.TabIndex = 2;
            this.chkMT3.Text = "Friendly";
            this.chkMT3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMT3.UseVisualStyleBackColor = true;
            // 
            // chkMT4
            // 
            this.chkMT4.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMT4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMT4.Location = new System.Drawing.Point(6, 39);
            this.chkMT4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkMT4.Name = "chkMT4";
            this.chkMT4.Size = new System.Drawing.Size(57, 21);
            this.chkMT4.TabIndex = 2;
            this.chkMT4.Text = "Fr.Lea.";
            this.chkMT4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMT4.UseVisualStyleBackColor = true;
            // 
            // chkMT5
            // 
            this.chkMT5.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMT5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMT5.Location = new System.Drawing.Point(65, 39);
            this.chkMT5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkMT5.Name = "chkMT5";
            this.chkMT5.Size = new System.Drawing.Size(75, 21);
            this.chkMT5.TabIndex = 2;
            this.chkMT5.Text = "Int.Match";
            this.chkMT5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMT5.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox3.Location = new System.Drawing.Point(270, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(154, 67);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Squad";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbSeason);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox2.Location = new System.Drawing.Point(196, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(68, 67);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Season";
            // 
            // cmbSeason
            // 
            this.cmbSeason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeason.FormattingEnabled = true;
            this.cmbSeason.Location = new System.Drawing.Point(6, 28);
            this.cmbSeason.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbSeason.Name = "cmbSeason";
            this.cmbSeason.Size = new System.Drawing.Size(57, 21);
            this.cmbSeason.TabIndex = 5;
            this.cmbSeason.SelectedIndexChanged += new System.EventHandler(this.cmbSeason_SelectedIndexChanged);
            // 
            // tabBrowser
            // 
            this.tabBrowser.Controls.Add(this.ntrBrowser);
            this.tabBrowser.Controls.Add(this.tsBrowserImport);
            this.tabBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabBrowser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabBrowser.Name = "tabBrowser";
            this.tabBrowser.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabBrowser.Size = new System.Drawing.Size(1204, 533);
            this.tabBrowser.TabIndex = 9;
            this.tabBrowser.Text = "Trophy Browser";
            this.tabBrowser.UseVisualStyleBackColor = true;
            // 
            // ntrBrowser
            // 
            this.ntrBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ntrBrowser.DefaultDirectory = "";
            this.ntrBrowser.Location = new System.Drawing.Point(98, 2);
            this.ntrBrowser.Name = "ntrBrowser";
            this.ntrBrowser.Size = new System.Drawing.Size(1103, 524);
            this.ntrBrowser.SourceDB = null;
            this.ntrBrowser.TabIndex = 3;
            this.ntrBrowser.ImportedContent += new NTR_Controls.ImportedContentHandler(this.ntrBrowser_ImportedContent);
            // 
            // tsBrowserImport
            // 
            this.tsBrowserImport.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBrowserImport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripDropDownButton2,
            this.toolStripSeparator1,
            this.toolStripLabel13,
            this.toolStripLabel1,
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
            this.tsbMatchSquadB});
            this.tsBrowserImport.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsBrowserImport.Location = new System.Drawing.Point(0, 2);
            this.tsBrowserImport.Name = "tsBrowserImport";
            this.tsBrowserImport.Size = new System.Drawing.Size(93, 354);
            this.tsBrowserImport.TabIndex = 2;
            this.tsBrowserImport.Text = "toolStrip4";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Navy;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(91, 13);
            this.toolStripLabel2.Text = "TM Access";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(91, 20);
            this.toolStripDropDownButton2.Text = "Extra Team";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(323, 22);
            this.toolStripMenuItem1.Text = "Add Extra Team";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(323, 22);
            this.toolStripMenuItem2.Text = "Change Browser to the actual Team";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(323, 22);
            this.toolStripMenuItem3.Text = "Load HTML file (Squad,Training,Calendar,Players)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(91, 6);
            // 
            // toolStripLabel13
            // 
            this.toolStripLabel13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel13.ForeColor = System.Drawing.Color.Navy;
            this.toolStripLabel13.Name = "toolStripLabel13";
            this.toolStripLabel13.Size = new System.Drawing.Size(91, 13);
            this.toolStripLabel13.Text = "Automatic";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Navy;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(91, 13);
            this.toolStripLabel1.Text = "Import Panel";
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
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ContentPanel.Size = new System.Drawing.Size(842, 385);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
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
            this.DB.Teams = null;
            // 
            // varDataBindingSource
            // 
            this.varDataBindingSource.DataSource = typeof(NTR_Db.PlayerData);
            // 
            // MainForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 595);
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
            this.tabMatches.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMatches)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabBrowser.ResumeLayout(false);
            this.tabBrowser.PerformLayout();
            this.tsBrowserImport.ResumeLayout(false);
            this.tsBrowserImport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTR_SquadDb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varDataBindingSource)).EndInit();
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
        private System.Windows.Forms.ToolStrip tsBrowserImport;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel13;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
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
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private NTR_Controls.NTR_Browser ntrBrowser;
        private System.Windows.Forms.TabPage tabMatches;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkHome;
        private System.Windows.Forms.CheckBox chkAway;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbSeason;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkMT1;
        private System.Windows.Forms.CheckBox chkMT2;
        private System.Windows.Forms.CheckBox chkMT3;
        private System.Windows.Forms.CheckBox chkMT4;
        private System.Windows.Forms.CheckBox chkMT5;
        private System.Windows.Forms.Button btnHelp;
        private NTR_Controls.AeroDataGrid dgMatches;
        private System.Windows.Forms.ToolStripMenuItem reloadOldReleaseDBToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnEnlargeMatchWindow;
        private System.Windows.Forms.Label lblNameTeamAway;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblNameTeamHome;
        private FieldFormationControl.RotLineupControl lineupControl;
        private System.Windows.Forms.ToolStripMenuItem searchAndImportAllSavedPagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recalculateDecimalsToolStripMenuItem;
    }
}

