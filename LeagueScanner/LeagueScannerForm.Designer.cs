namespace LeagueScanner
{
    partial class LeagueScannerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeagueScannerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridGiocatori = new NTR_Controls.AeroDataGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new NTR_Controls.AeroDataGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new NTR_Controls.AeroDataGrid();
            this.tabBrowser = new System.Windows.Forms.TabPage();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.tsBrowsePlayers = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tsbProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsbProgressText = new System.Windows.Forms.ToolStripLabel();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTableInExcelFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindTeam = new System.Windows.Forms.BindingSource(this.components);
            this.injuriesDS = new LeagueScanner.InjuriesDS();
            this.matchIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.homeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.awayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindMatches = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noInjuriesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalInjuriesWeekDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noMatchesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meanVoteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindPlayers = new System.Windows.Forms.BindingSource(this.components);
            this.teamIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leagueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matchesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalInjuriesWeeksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalInjuries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeInjuries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeInjuriesWeeks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medCenterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.physioRoomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dreinageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pitchCoversDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sprinklersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heatingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGiocatori)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabBrowser.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tsBrowsePlayers.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.injuriesDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabBrowser);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(752, 349);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridGiocatori);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(744, 323);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Teams";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridGiocatori
            // 
            this.dataGridGiocatori.AllowUserToAddRows = false;
            this.dataGridGiocatori.AllowUserToDeleteRows = false;
            this.dataGridGiocatori.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridGiocatori.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridGiocatori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGiocatori.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.teamIDDataGridViewTextBoxColumn,
            this.leagueDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.matchesDataGridViewTextBoxColumn,
            this.totalInjuriesWeeksDataGridViewTextBoxColumn,
            this.TotalInjuries,
            this.HomeInjuries,
            this.HomeInjuriesWeeks,
            this.medCenterDataGridViewTextBoxColumn,
            this.physioRoomDataGridViewTextBoxColumn,
            this.dreinageDataGridViewTextBoxColumn,
            this.pitchCoversDataGridViewTextBoxColumn,
            this.sprinklersDataGridViewTextBoxColumn,
            this.heatingDataGridViewTextBoxColumn});
            this.dataGridGiocatori.DataSource = this.bindTeam;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridGiocatori.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridGiocatori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridGiocatori.Location = new System.Drawing.Point(3, 3);
            this.dataGridGiocatori.MultiSelect = false;
            this.dataGridGiocatori.Name = "dataGridGiocatori";
            this.dataGridGiocatori.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridGiocatori.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridGiocatori.RowHeadersWidth = 20;
            this.dataGridGiocatori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridGiocatori.Size = new System.Drawing.Size(738, 317);
            this.dataGridGiocatori.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(744, 323);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Matches";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.matchIDDataGridViewTextBoxColumn,
            this.homeDataGridViewTextBoxColumn,
            this.scoreDataGridViewTextBoxColumn,
            this.awayDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindMatches;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(738, 317);
            this.dataGridView1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(744, 323);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "Players";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.aSIDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn,
            this.noInjuriesDataGridViewTextBoxColumn,
            this.totalInjuriesWeekDataGridViewTextBoxColumn,
            this.noMatchesDataGridViewTextBoxColumn,
            this.meanVoteDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.bindPlayers;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView2.RowHeadersWidth = 20;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(738, 317);
            this.dataGridView2.TabIndex = 2;
            // 
            // tabBrowser
            // 
            this.tabBrowser.Controls.Add(this.toolStripContainer1);
            this.tabBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabBrowser.Name = "tabBrowser";
            this.tabBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.tabBrowser.Size = new System.Drawing.Size(744, 323);
            this.tabBrowser.TabIndex = 3;
            this.tabBrowser.Text = "Browser";
            this.tabBrowser.UseVisualStyleBackColor = true;
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.webBrowser);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(744, 322);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(744, 347);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsBrowsePlayers);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(744, 322);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser_ProgressChanged);
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // tsBrowsePlayers
            // 
            this.tsBrowsePlayers.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBrowsePlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel6,
            this.toolStripSeparator11,
            this.toolStripButton1,
            this.toolStripLabel4,
            this.tsbProgressBar,
            this.tsbProgressText,
            this.tsbImport});
            this.tsBrowsePlayers.Location = new System.Drawing.Point(3, 0);
            this.tsBrowsePlayers.Name = "tsBrowsePlayers";
            this.tsBrowsePlayers.Size = new System.Drawing.Size(423, 25);
            this.tsBrowsePlayers.TabIndex = 4;
            this.tsBrowsePlayers.Text = "toolStrip2";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(119, 22);
            this.toolStripLabel6.Text = "Youth Development";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(77, 22);
            this.toolStripButton1.Text = "Goto Page";
            this.toolStripButton1.Click += new System.EventHandler(this.tbGotoPage_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(87, 22);
            this.toolStripLabel4.Text = "Load progress";
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
            this.tsbImport.Image = ((System.Drawing.Image)(resources.GetObject("tsbImport.Image")));
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Size = new System.Drawing.Size(50, 22);
            this.tsbImport.Text = "Scan";
            this.tsbImport.Click += new System.EventHandler(this.tsbImport_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDatabaseToolStripMenuItem,
            this.loadDatabaseToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveDatabaseToolStripMenuItem
            // 
            this.saveDatabaseToolStripMenuItem.Name = "saveDatabaseToolStripMenuItem";
            this.saveDatabaseToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveDatabaseToolStripMenuItem.Text = "Save Database";
            this.saveDatabaseToolStripMenuItem.Click += new System.EventHandler(this.saveDatabaseToolStripMenuItem_Click);
            // 
            // loadDatabaseToolStripMenuItem
            // 
            this.loadDatabaseToolStripMenuItem.Name = "loadDatabaseToolStripMenuItem";
            this.loadDatabaseToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.loadDatabaseToolStripMenuItem.Text = "Load Database";
            this.loadDatabaseToolStripMenuItem.Click += new System.EventHandler(this.loadDatabaseToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearDatabaseToolStripMenuItem,
            this.copyTableInExcelFormatToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearDatabaseToolStripMenuItem
            // 
            this.clearDatabaseToolStripMenuItem.Name = "clearDatabaseToolStripMenuItem";
            this.clearDatabaseToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.clearDatabaseToolStripMenuItem.Text = "Clear Database";
            this.clearDatabaseToolStripMenuItem.Click += new System.EventHandler(this.clearDatabaseToolStripMenuItem_Click);
            // 
            // copyTableInExcelFormatToolStripMenuItem
            // 
            this.copyTableInExcelFormatToolStripMenuItem.Name = "copyTableInExcelFormatToolStripMenuItem";
            this.copyTableInExcelFormatToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.copyTableInExcelFormatToolStripMenuItem.Text = "Copy Team Table in Excel Format";
            this.copyTableInExcelFormatToolStripMenuItem.Click += new System.EventHandler(this.copyTeamTableInExcelFormatToolStripMenuItem_Click);
            // 
            // bindTeam
            // 
            this.bindTeam.DataMember = "Squad";
            this.bindTeam.DataSource = this.injuriesDS;
            // 
            // injuriesDS
            // 
            this.injuriesDS.DataSetName = "Injuries";
            this.injuriesDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // matchIDDataGridViewTextBoxColumn
            // 
            this.matchIDDataGridViewTextBoxColumn.DataPropertyName = "MatchID";
            this.matchIDDataGridViewTextBoxColumn.HeaderText = "MatchID";
            this.matchIDDataGridViewTextBoxColumn.Name = "matchIDDataGridViewTextBoxColumn";
            this.matchIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // homeDataGridViewTextBoxColumn
            // 
            this.homeDataGridViewTextBoxColumn.DataPropertyName = "Home";
            this.homeDataGridViewTextBoxColumn.HeaderText = "Home";
            this.homeDataGridViewTextBoxColumn.Name = "homeDataGridViewTextBoxColumn";
            this.homeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // scoreDataGridViewTextBoxColumn
            // 
            this.scoreDataGridViewTextBoxColumn.DataPropertyName = "Score";
            this.scoreDataGridViewTextBoxColumn.HeaderText = "Score";
            this.scoreDataGridViewTextBoxColumn.Name = "scoreDataGridViewTextBoxColumn";
            this.scoreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // awayDataGridViewTextBoxColumn
            // 
            this.awayDataGridViewTextBoxColumn.DataPropertyName = "Away";
            this.awayDataGridViewTextBoxColumn.HeaderText = "Away";
            this.awayDataGridViewTextBoxColumn.Name = "awayDataGridViewTextBoxColumn";
            this.awayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindMatches
            // 
            this.bindMatches.DataMember = "Matches";
            this.bindMatches.DataSource = this.injuriesDS;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // aSIDataGridViewTextBoxColumn
            // 
            this.aSIDataGridViewTextBoxColumn.DataPropertyName = "ASI";
            this.aSIDataGridViewTextBoxColumn.HeaderText = "ASI";
            this.aSIDataGridViewTextBoxColumn.Name = "aSIDataGridViewTextBoxColumn";
            this.aSIDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            this.ageDataGridViewTextBoxColumn.ReadOnly = true;
            this.ageDataGridViewTextBoxColumn.Width = 50;
            // 
            // noInjuriesDataGridViewTextBoxColumn
            // 
            this.noInjuriesDataGridViewTextBoxColumn.DataPropertyName = "NoInjuries";
            this.noInjuriesDataGridViewTextBoxColumn.HeaderText = "NoInjuries";
            this.noInjuriesDataGridViewTextBoxColumn.Name = "noInjuriesDataGridViewTextBoxColumn";
            this.noInjuriesDataGridViewTextBoxColumn.ReadOnly = true;
            this.noInjuriesDataGridViewTextBoxColumn.Width = 50;
            // 
            // totalInjuriesWeekDataGridViewTextBoxColumn
            // 
            this.totalInjuriesWeekDataGridViewTextBoxColumn.DataPropertyName = "TotalInjuriesWeek";
            this.totalInjuriesWeekDataGridViewTextBoxColumn.HeaderText = "TotalInjuriesWeek";
            this.totalInjuriesWeekDataGridViewTextBoxColumn.Name = "totalInjuriesWeekDataGridViewTextBoxColumn";
            this.totalInjuriesWeekDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalInjuriesWeekDataGridViewTextBoxColumn.Width = 70;
            // 
            // noMatchesDataGridViewTextBoxColumn
            // 
            this.noMatchesDataGridViewTextBoxColumn.DataPropertyName = "NoMatches";
            this.noMatchesDataGridViewTextBoxColumn.HeaderText = "NoMatches";
            this.noMatchesDataGridViewTextBoxColumn.Name = "noMatchesDataGridViewTextBoxColumn";
            this.noMatchesDataGridViewTextBoxColumn.ReadOnly = true;
            this.noMatchesDataGridViewTextBoxColumn.Width = 50;
            // 
            // meanVoteDataGridViewTextBoxColumn
            // 
            this.meanVoteDataGridViewTextBoxColumn.DataPropertyName = "MeanVote";
            dataGridViewCellStyle8.Format = "N2";
            this.meanVoteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.meanVoteDataGridViewTextBoxColumn.HeaderText = "MeanVote";
            this.meanVoteDataGridViewTextBoxColumn.Name = "meanVoteDataGridViewTextBoxColumn";
            this.meanVoteDataGridViewTextBoxColumn.ReadOnly = true;
            this.meanVoteDataGridViewTextBoxColumn.Width = 50;
            // 
            // bindPlayers
            // 
            this.bindPlayers.DataMember = "Player";
            this.bindPlayers.DataSource = this.injuriesDS;
            // 
            // teamIDDataGridViewTextBoxColumn
            // 
            this.teamIDDataGridViewTextBoxColumn.DataPropertyName = "TeamID";
            this.teamIDDataGridViewTextBoxColumn.HeaderText = "TeamID";
            this.teamIDDataGridViewTextBoxColumn.Name = "teamIDDataGridViewTextBoxColumn";
            this.teamIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.teamIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // leagueDataGridViewTextBoxColumn
            // 
            this.leagueDataGridViewTextBoxColumn.DataPropertyName = "League";
            this.leagueDataGridViewTextBoxColumn.HeaderText = "League";
            this.leagueDataGridViewTextBoxColumn.Name = "leagueDataGridViewTextBoxColumn";
            this.leagueDataGridViewTextBoxColumn.ReadOnly = true;
            this.leagueDataGridViewTextBoxColumn.Width = 40;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // matchesDataGridViewTextBoxColumn
            // 
            this.matchesDataGridViewTextBoxColumn.DataPropertyName = "Matches";
            this.matchesDataGridViewTextBoxColumn.HeaderText = "Match";
            this.matchesDataGridViewTextBoxColumn.Name = "matchesDataGridViewTextBoxColumn";
            this.matchesDataGridViewTextBoxColumn.ReadOnly = true;
            this.matchesDataGridViewTextBoxColumn.Width = 50;
            // 
            // totalInjuriesWeeksDataGridViewTextBoxColumn
            // 
            this.totalInjuriesWeeksDataGridViewTextBoxColumn.DataPropertyName = "TotalInjuriesWeeks";
            this.totalInjuriesWeeksDataGridViewTextBoxColumn.HeaderText = "TotInjWeeks";
            this.totalInjuriesWeeksDataGridViewTextBoxColumn.Name = "totalInjuriesWeeksDataGridViewTextBoxColumn";
            this.totalInjuriesWeeksDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalInjuriesWeeksDataGridViewTextBoxColumn.Width = 50;
            // 
            // TotalInjuries
            // 
            this.TotalInjuries.DataPropertyName = "TotalInjuries";
            this.TotalInjuries.HeaderText = "TotalInj";
            this.TotalInjuries.Name = "TotalInjuries";
            this.TotalInjuries.ReadOnly = true;
            this.TotalInjuries.Width = 50;
            // 
            // HomeInjuries
            // 
            this.HomeInjuries.DataPropertyName = "HomeInjuries";
            this.HomeInjuries.HeaderText = "HomeInj";
            this.HomeInjuries.Name = "HomeInjuries";
            this.HomeInjuries.ReadOnly = true;
            this.HomeInjuries.Width = 50;
            // 
            // HomeInjuriesWeeks
            // 
            this.HomeInjuriesWeeks.DataPropertyName = "HomeInjuriesWeeks";
            this.HomeInjuriesWeeks.HeaderText = "HomeInjWeeks";
            this.HomeInjuriesWeeks.Name = "HomeInjuriesWeeks";
            this.HomeInjuriesWeeks.ReadOnly = true;
            this.HomeInjuriesWeeks.Width = 60;
            // 
            // medCenterDataGridViewTextBoxColumn
            // 
            this.medCenterDataGridViewTextBoxColumn.DataPropertyName = "MedCenter";
            this.medCenterDataGridViewTextBoxColumn.HeaderText = "MedC";
            this.medCenterDataGridViewTextBoxColumn.Name = "medCenterDataGridViewTextBoxColumn";
            this.medCenterDataGridViewTextBoxColumn.ReadOnly = true;
            this.medCenterDataGridViewTextBoxColumn.Width = 50;
            // 
            // physioRoomDataGridViewTextBoxColumn
            // 
            this.physioRoomDataGridViewTextBoxColumn.DataPropertyName = "PhysioRoom";
            this.physioRoomDataGridViewTextBoxColumn.HeaderText = "Phys";
            this.physioRoomDataGridViewTextBoxColumn.Name = "physioRoomDataGridViewTextBoxColumn";
            this.physioRoomDataGridViewTextBoxColumn.ReadOnly = true;
            this.physioRoomDataGridViewTextBoxColumn.Width = 30;
            // 
            // dreinageDataGridViewTextBoxColumn
            // 
            this.dreinageDataGridViewTextBoxColumn.DataPropertyName = "Dreinage";
            this.dreinageDataGridViewTextBoxColumn.HeaderText = "Drei";
            this.dreinageDataGridViewTextBoxColumn.Name = "dreinageDataGridViewTextBoxColumn";
            this.dreinageDataGridViewTextBoxColumn.ReadOnly = true;
            this.dreinageDataGridViewTextBoxColumn.Width = 30;
            // 
            // pitchCoversDataGridViewTextBoxColumn
            // 
            this.pitchCoversDataGridViewTextBoxColumn.DataPropertyName = "PitchCovers";
            this.pitchCoversDataGridViewTextBoxColumn.HeaderText = "Pitc";
            this.pitchCoversDataGridViewTextBoxColumn.Name = "pitchCoversDataGridViewTextBoxColumn";
            this.pitchCoversDataGridViewTextBoxColumn.ReadOnly = true;
            this.pitchCoversDataGridViewTextBoxColumn.Width = 30;
            // 
            // sprinklersDataGridViewTextBoxColumn
            // 
            this.sprinklersDataGridViewTextBoxColumn.DataPropertyName = "Sprinklers";
            this.sprinklersDataGridViewTextBoxColumn.HeaderText = "Spri";
            this.sprinklersDataGridViewTextBoxColumn.Name = "sprinklersDataGridViewTextBoxColumn";
            this.sprinklersDataGridViewTextBoxColumn.ReadOnly = true;
            this.sprinklersDataGridViewTextBoxColumn.Width = 30;
            // 
            // heatingDataGridViewTextBoxColumn
            // 
            this.heatingDataGridViewTextBoxColumn.DataPropertyName = "Heating";
            this.heatingDataGridViewTextBoxColumn.HeaderText = "Heat";
            this.heatingDataGridViewTextBoxColumn.Name = "heatingDataGridViewTextBoxColumn";
            this.heatingDataGridViewTextBoxColumn.ReadOnly = true;
            this.heatingDataGridViewTextBoxColumn.Width = 30;
            // 
            // LeagueScannerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 373);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LeagueScannerForm";
            this.Text = "League Scanner";
            this.Load += new System.EventHandler(this.LeagueScannerForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LeagueScannerForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGiocatori)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabBrowser.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tsBrowsePlayers.ResumeLayout(false);
            this.tsBrowsePlayers.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.injuriesDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private NTR_Controls.AeroDataGrid dataGridGiocatori;
        private System.Windows.Forms.TabPage tabBrowser;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStrip tsBrowsePlayers;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripProgressBar tsbProgressBar;
        private System.Windows.Forms.ToolStripLabel tsbProgressText;
        private System.Windows.Forms.ToolStripButton tsbImport;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.BindingSource bindTeam;
        private LeagueScanner.InjuriesDS injuriesDS;
        private System.Windows.Forms.TabPage tabPage2;
        private NTR_Controls.AeroDataGrid dataGridView1;
        private System.Windows.Forms.BindingSource bindMatches;
        private System.Windows.Forms.DataGridViewTextBoxColumn matchIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn homeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn awayDataGridViewTextBoxColumn;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDatabaseToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private NTR_Controls.AeroDataGrid dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noInjuriesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalInjuriesWeekDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noMatchesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn meanVoteDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bindPlayers;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyTableInExcelFormatToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leagueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matchesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalInjuriesWeeksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalInjuries;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomeInjuries;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomeInjuriesWeeks;
        private System.Windows.Forms.DataGridViewTextBoxColumn medCenterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn physioRoomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dreinageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pitchCoversDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sprinklersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heatingDataGridViewTextBoxColumn;

    }
}

