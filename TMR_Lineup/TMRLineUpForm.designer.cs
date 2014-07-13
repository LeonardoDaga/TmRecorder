namespace FieldFormationControl
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.playerY_ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.replaceWithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoPlayerPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerO_ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbTeam1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cmbMatch1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.cmbTeam2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.cmbMatch2 = new System.Windows.Forms.ToolStripComboBox();
            this.formationControl = new FieldFormationControl.RotFormationControl();
            this.matchListDS = new Common.MatchList();
            this.bindLeftMatch = new System.Windows.Forms.BindingSource(this.components);
            this.bindTeam1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindRightMatch = new System.Windows.Forms.BindingSource(this.components);
            this.bindTeam2 = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tsBrowsePlayers = new System.Windows.Forms.ToolStrip();
            this.tsblTitle = new System.Windows.Forms.ToolStripLabel();
            this.tsbLoadPlayerPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.tsbProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsbProgressText = new System.Windows.Forms.ToolStripLabel();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAnalyzerRight = new System.Windows.Forms.ToolStripButton();
            this.btnAnalyzerLeft = new System.Windows.Forms.ToolStripButton();
            this.tsbPrev = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.playerY_ContextMenu.SuspendLayout();
            this.playerO_ContextMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchListDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindLeftMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindTeam1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindRightMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindTeam2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tsBrowsePlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerY_ContextMenu
            // 
            this.playerY_ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceWithToolStripMenuItem,
            this.gotoPlayerPageToolStripMenuItem});
            this.playerY_ContextMenu.Name = "playerY_ContextMenu";
            this.playerY_ContextMenu.Size = new System.Drawing.Size(165, 48);
            // 
            // replaceWithToolStripMenuItem
            // 
            this.replaceWithToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testPlayerToolStripMenuItem});
            this.replaceWithToolStripMenuItem.Name = "replaceWithToolStripMenuItem";
            this.replaceWithToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.replaceWithToolStripMenuItem.Text = "Replace With";
            // 
            // testPlayerToolStripMenuItem
            // 
            this.testPlayerToolStripMenuItem.Name = "testPlayerToolStripMenuItem";
            this.testPlayerToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.testPlayerToolStripMenuItem.Text = "Test Player";
            this.testPlayerToolStripMenuItem.Click += new System.EventHandler(this.changeY_PlayerToolStripMenuItem_Click);
            // 
            // gotoPlayerPageToolStripMenuItem
            // 
            this.gotoPlayerPageToolStripMenuItem.Name = "gotoPlayerPageToolStripMenuItem";
            this.gotoPlayerPageToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.gotoPlayerPageToolStripMenuItem.Text = "Goto Player Page";
            this.gotoPlayerPageToolStripMenuItem.Click += new System.EventHandler(this.gotoPlayerPageToolStripMenuItem_Click);
            // 
            // playerO_ContextMenu
            // 
            this.playerO_ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4});
            this.playerO_ContextMenu.Name = "playerY_ContextMenu";
            this.playerO_ContextMenu.Size = new System.Drawing.Size(144, 26);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItem4.Text = "Replace With";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem13,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cmbTeam1,
            this.toolStripLabel2,
            this.cmbMatch1,
            this.btnAnalyzerLeft,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.cmbTeam2,
            this.toolStripLabel4,
            this.cmbMatch2,
            this.btnAnalyzerRight});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(957, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem12,
            this.clearDataToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(37, 25);
            this.toolStripMenuItem2.Text = "File";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "Load Data";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.loadDataToolStripMenuItem_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem12.Text = "Save Data";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.saveDataToolStripMenuItem_Click);
            // 
            // clearDataToolStripMenuItem
            // 
            this.clearDataToolStripMenuItem.Name = "clearDataToolStripMenuItem";
            this.clearDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearDataToolStripMenuItem.Text = "Clear Data";
            this.clearDataToolStripMenuItem.Click += new System.EventHandler(this.clearDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem14,
            this.toolStripMenuItem15,
            this.toolStripMenuItem16,
            this.toolStripMenuItem17,
            this.toolStripSeparator3,
            this.toolStripMenuItem1});
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(39, 25);
            this.toolStripMenuItem13.Text = "Edit";
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItem16.Text = "Select Left Team Tactics";
            this.toolStripMenuItem16.Click += new System.EventHandler(this.selectYourFormationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItem17.Text = "Select Right Team Tactics";
            this.toolStripMenuItem17.Click += new System.EventHandler(this.selectOppositeFormationToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(235, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.CheckOnClick = true;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItem1.Text = "Show players mean votes";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.showPlayersMeanVoteToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(64, 22);
            this.toolStripLabel1.Text = "Left Team";
            // 
            // cmbTeam1
            // 
            this.cmbTeam1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cmbTeam1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeam1.DropDownWidth = 130;
            this.cmbTeam1.Name = "cmbTeam1";
            this.cmbTeam1.Size = new System.Drawing.Size(100, 25);
            this.cmbTeam1.SelectedIndexChanged += new System.EventHandler(this.cmbTeam1_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel2.Image = global::TMR_Lineup.Properties.Resources.Squad;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(16, 22);
            this.toolStripLabel2.Text = "toolStripLabel2";
            // 
            // cmbMatch1
            // 
            this.cmbMatch1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cmbMatch1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMatch1.DropDownWidth = 200;
            this.cmbMatch1.Name = "cmbMatch1";
            this.cmbMatch1.Size = new System.Drawing.Size(160, 25);
            this.cmbMatch1.SelectedIndexChanged += new System.EventHandler(this.cmbMatch1_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(72, 22);
            this.toolStripLabel3.Text = "Right Team";
            // 
            // cmbTeam2
            // 
            this.cmbTeam2.BackColor = System.Drawing.Color.LightSalmon;
            this.cmbTeam2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeam2.DropDownWidth = 130;
            this.cmbTeam2.Name = "cmbTeam2";
            this.cmbTeam2.Size = new System.Drawing.Size(100, 25);
            this.cmbTeam2.SelectedIndexChanged += new System.EventHandler(this.cmbTeam2_SelectedIndexChanged);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.BackColor = System.Drawing.Color.LightSalmon;
            this.toolStripLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel4.Image = global::TMR_Lineup.Properties.Resources.Squad;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(16, 22);
            this.toolStripLabel4.Text = "toolStripLabel2";
            // 
            // cmbMatch2
            // 
            this.cmbMatch2.BackColor = System.Drawing.Color.LightSalmon;
            this.cmbMatch2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMatch2.DropDownWidth = 200;
            this.cmbMatch2.Name = "cmbMatch2";
            this.cmbMatch2.Size = new System.Drawing.Size(160, 25);
            this.cmbMatch2.SelectedIndexChanged += new System.EventHandler(this.cmbMatch2_SelectedIndexChanged);
            // 
            // formationControl
            // 
            this.formationControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("formationControl.BackgroundImage")));
            this.formationControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.formationControl.Location = new System.Drawing.Point(0, 1);
            this.formationControl.MatchFile = "";
            this.formationControl.Name = "formationControl";
            this.formationControl.OppFormationType = Common.eFormationTypes.Type_4_4_2;
            this.formationControl.Size = new System.Drawing.Size(951, 566);
            this.formationControl.TabIndex = 0;
            this.formationControl.YourFormationType = Common.eFormationTypes.Type_4_5_1_D;
            // 
            // matchListDS
            // 
            this.matchListDS.DataSetName = "MatchList";
            this.matchListDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindLeftMatch
            // 
            this.bindLeftMatch.DataMember = "MatchesList";
            this.bindLeftMatch.DataSource = this.matchListDS;
            // 
            // bindTeam1
            // 
            this.bindTeam1.DataMember = "TeamList";
            this.bindTeam1.DataSource = this.matchListDS;
            // 
            // bindRightMatch
            // 
            this.bindRightMatch.DataMember = "MatchesList";
            this.bindRightMatch.DataSource = this.matchListDS;
            // 
            // bindTeam2
            // 
            this.bindTeam2.DataMember = "TeamList";
            this.bindTeam2.DataSource = this.matchListDS;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(957, 591);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.formationControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(949, 565);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lineup";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tsBrowsePlayers);
            this.tabPage2.Controls.Add(this.webBrowser);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(949, 565);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Browser";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tsBrowsePlayers
            // 
            this.tsBrowsePlayers.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBrowsePlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsblTitle,
            this.tsbPrev,
            this.tsbNext,
            this.toolStripSeparator5,
            this.tsbLoadPlayerPage,
            this.toolStripSeparator11,
            this.toolStripLabel5,
            this.tsbProgressBar,
            this.tsbProgressText,
            this.tsbImport});
            this.tsBrowsePlayers.Location = new System.Drawing.Point(3, 1);
            this.tsBrowsePlayers.Name = "tsBrowsePlayers";
            this.tsBrowsePlayers.Size = new System.Drawing.Size(535, 25);
            this.tsBrowsePlayers.TabIndex = 6;
            this.tsBrowsePlayers.Text = "toolStrip2";
            // 
            // tsblTitle
            // 
            this.tsblTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsblTitle.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tsblTitle.Name = "tsblTitle";
            this.tsblTitle.Size = new System.Drawing.Size(53, 22);
            this.tsblTitle.Text = "Browser";
            // 
            // tsbLoadPlayerPage
            // 
            this.tsbLoadPlayerPage.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadPlayerPage.Image")));
            this.tsbLoadPlayerPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadPlayerPage.Name = "tsbLoadPlayerPage";
            this.tsbLoadPlayerPage.Size = new System.Drawing.Size(133, 22);
            this.tsbLoadPlayerPage.Text = "Goto TM Main Page";
            this.tsbLoadPlayerPage.Click += new System.EventHandler(this.tsbLoadPlayerPage_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(87, 22);
            this.toolStripLabel5.Text = "Load progress";
            // 
            // tsbProgressBar
            // 
            this.tsbProgressBar.Name = "tsbProgressBar";
            this.tsbProgressBar.Size = new System.Drawing.Size(62, 22);
            this.tsbProgressBar.Step = 5;
            // 
            // tsbProgressText
            // 
            this.tsbProgressText.Name = "tsbProgressText";
            this.tsbProgressText.Size = new System.Drawing.Size(10, 22);
            this.tsbProgressText.Text = " ";
            // 
            // tsbImport
            // 
            this.tsbImport.BackColor = System.Drawing.SystemColors.Control;
            this.tsbImport.Image = ((System.Drawing.Image)(resources.GetObject("tsbImport.Image")));
            this.tsbImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Size = new System.Drawing.Size(63, 22);
            this.tsbImport.Text = "Import";
            this.tsbImport.Click += new System.EventHandler(this.tsbImport_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(0, 29);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(949, 540);
            this.webBrowser.TabIndex = 5;
            this.webBrowser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser_ProgressChanged);
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.toolStripMenuItem14.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItem14.Text = "Paste Match Evaluation";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.pasteHTMLData_Click);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.toolStripMenuItem15.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItem15.Text = "Paste Team Analysis";
            this.toolStripMenuItem15.Click += new System.EventHandler(this.pasteHTMLData_Click);
            // 
            // btnAnalyzerRight
            // 
            this.btnAnalyzerRight.Image = global::TMR_Lineup.Properties.Resources.Analyzer;
            this.btnAnalyzerRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnalyzerRight.Name = "btnAnalyzerRight";
            this.btnAnalyzerRight.Size = new System.Drawing.Size(73, 22);
            this.btnAnalyzerRight.Text = "Get Plyrs";
            this.btnAnalyzerRight.Click += new System.EventHandler(this.btnAnalyzerRight_Click);
            // 
            // btnAnalyzerLeft
            // 
            this.btnAnalyzerLeft.Image = global::TMR_Lineup.Properties.Resources.Analyzer;
            this.btnAnalyzerLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnalyzerLeft.Name = "btnAnalyzerLeft";
            this.btnAnalyzerLeft.Size = new System.Drawing.Size(73, 22);
            this.btnAnalyzerLeft.Text = "Get Plyrs";
            this.btnAnalyzerLeft.Click += new System.EventHandler(this.btnAnalyzerLeft_Click);
            // 
            // tsbPrev
            // 
            this.tsbPrev.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrev.Image")));
            this.tsbPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrev.Name = "tsbPrev";
            this.tsbPrev.Size = new System.Drawing.Size(50, 22);
            this.tsbPrev.Text = "Prev";
            this.tsbPrev.Click += new System.EventHandler(this.tsbPrev_Click);
            // 
            // tsbNext
            // 
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(51, 22);
            this.tsbNext.Text = "Next";
            this.tsbNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 616);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestForm";
            this.Text = "TMR Lineup - ver 1.0.9";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestForm_FormClosing);
            this.playerY_ContextMenu.ResumeLayout(false);
            this.playerO_ContextMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchListDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindLeftMatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindTeam1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindRightMatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindTeam2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tsBrowsePlayers.ResumeLayout(false);
            this.tsBrowsePlayers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RotFormationControl formationControl;
        private Common.MatchList matchListDS;
        private System.Windows.Forms.BindingSource bindLeftMatch;
        private System.Windows.Forms.BindingSource bindRightMatch;
        private System.Windows.Forms.BindingSource bindTeam1;
        private System.Windows.Forms.BindingSource bindTeam2;
        private System.Windows.Forms.ContextMenuStrip playerY_ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem replaceWithToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip playerO_ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem testPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbTeam1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cmbMatch1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox cmbTeam2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox cmbMatch2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem gotoPlayerPageToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip tsBrowsePlayers;
        private System.Windows.Forms.ToolStripLabel tsblTitle;
        private System.Windows.Forms.ToolStripButton tsbLoadPlayerPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripProgressBar tsbProgressBar;
        private System.Windows.Forms.ToolStripLabel tsbProgressText;
        private System.Windows.Forms.ToolStripButton tsbImport;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripButton btnAnalyzerLeft;
        private System.Windows.Forms.ToolStripButton btnAnalyzerRight;
        private System.Windows.Forms.ToolStripButton tsbPrev;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;

    }
}