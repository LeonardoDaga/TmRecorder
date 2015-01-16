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
            this.tsMainBar.Size = new System.Drawing.Size(951, 36);
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
            this.tabGK.Controls.Add(this.cbDataDayGK);
            this.tabGK.Controls.Add(this.label4);
            this.tabGK.Controls.Add(this.dgPlayersGK);
            this.tabGK.Controls.Add(this.qsMinRatingGK);
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
            // qsMinRatingGK
            // 
            this.qsMinRatingGK.Location = new System.Drawing.Point(279, 5);
            this.qsMinRatingGK.Name = "qsMinRatingGK";
            this.qsMinRatingGK.Size = new System.Drawing.Size(85, 17);
            this.qsMinRatingGK.TabIndex = 17;
            this.qsMinRatingGK.Value = 0F;
            this.qsMinRatingGK.ValueChanged += new NTR_Controls.QuantitySelector.ValueChangedHandler(this.qsMinRatingGK_ValueChanged);
            // 
            // tabBrowser
            // 
            this.tabBrowser.Controls.Add(this.ntrBrowser);
            this.tabBrowser.Controls.Add(this.tsBrowserImport);
            this.tabBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabBrowser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabBrowser.Name = "tabBrowser";
            this.tabBrowser.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabBrowser.Size = new System.Drawing.Size(943, 420);
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
            this.ntrBrowser.Size = new System.Drawing.Size(845, 418);
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
            // varDataBindingSource
            // 
            this.varDataBindingSource.DataSource = typeof(NTR_Db.PlayerData);
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
    }
}

