using Common;

namespace TmRecorder3
{
    partial class TR3_PlayerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TR3_PlayerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrefPos = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblASI = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSkills = new System.Windows.Forms.TabPage();
            this.graphSkills = new ZedGraph.ZedGraphControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.graphASI = new ZedGraph.ZedGraphControl();
            this.chkShowTGI = new System.Windows.Forms.CheckBox();
            this.graphTI = new ZedGraph.ZedGraphControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.graphInjuries = new ZedGraph.ZedGraphControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.graphSpecs = new ZedGraph.ZedGraphControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.lblSeason = new System.Windows.Forms.ToolStripLabel();
            this.cmbSeason = new System.Windows.Forms.ToolStripComboBox();
            this.chkNormalized = new System.Windows.Forms.ToolStripButton();
            this.chkShowPosition = new System.Windows.Forms.ToolStripButton();
            this.graphPerf = new ZedGraph.ZedGraphControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.whatToDoHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.getPotentialForThisPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.graphTrainingPsychology = new ZedGraph.ZedGraphControl();
            this.graphTrainingPhisics = new ZedGraph.ZedGraphControl();
            this.btnGetVotenSkillAuto = new System.Windows.Forms.Button();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.graphTrainingTactics = new ZedGraph.ZedGraphControl();
            this.graphTrainingTechnics = new ZedGraph.ZedGraphControl();
            this.tabPlayerScouting = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgScouts = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.developmentDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seniorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.youthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.physicalDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tacticalDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.technicalDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.psychologyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scoutsNReviews = new Common.ScoutsNReviews();
            this.dgReviews = new System.Windows.Forms.DataGridView();
            this.scoutIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vote = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.bloomingDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.BloomingStatus = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.Development = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.Speciality = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.Physics = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.Tactics = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.Technics = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.Charisma = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.Professionalism = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.aggressivityDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tagsBarPro = new Common.TagsBar();
            this.tagsBarAgg = new Common.TagsBar();
            this.tagsBarLea = new Common.TagsBar();
            this.tagsBarTec = new Common.TagsBar();
            this.tagsBarTac = new Common.TagsBar();
            this.tagsBarPhy = new Common.TagsBar();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.trainingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playerTraining = new TMRecorder.PlayerTraining();
            this.tabPlayerBrowser = new System.Windows.Forms.TabPage();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.tsBrowsePlayers = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.tsbLoadPlayerPage = new System.Windows.Forms.ToolStripButton();
            this.tsbNavigationType = new System.Windows.Forms.ToolStripDropDownButton();
            this.navigateProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigateReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tsbProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsbProgressText = new System.Windows.Forms.ToolStripLabel();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.scoutsDataTableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBloomAge = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblRoutine = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.seasonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratDevDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performancesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gameTableDS = new Common.GameTable();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbPlayers = new System.Windows.Forms.ToolStripDropDownButton();
            this.dDefendersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dMDefenderMidfieldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mMidfieldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oMOffenderMidfieldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fForwardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tsbComputeGrowth = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWage = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tmR_AgeColumn1 = new DataGridViewCustomColumns.TMR_AgeColumn(this.components);
            this.tmR_DateColumn1 = new DataGridViewCustomColumns.TMR_DateColumn(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scoutsDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reviewDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bestPlayersDS = new TMRecorder.BestPlayersDS();
            this.bestPlayersDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reviewDataTableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.scoutsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.extraDS = new Common.ExtraDS();
            this.ReportAnalysis = new Common.ReportAnalysis();
            this.playerData1 = new TMRecorder.PlayerData();
            this.PlayerAge = new DataGridViewCustomColumns.TMR_AgeColumn(this.components);
            this.absWeekDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_DateColumn(this.components);
            this.forDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.resDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.velDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.marDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.conDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.worDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.posDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.pasDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.croDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tecDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tesDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.finDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tirDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.calDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_TrainSkillColumn(this.components);
            this.tabControl1.SuspendLayout();
            this.tabSkills.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.tabPlayerScouting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgScouts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoutsNReviews)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgReviews)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerTraining)).BeginInit();
            this.tabPlayerBrowser.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tsBrowsePlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scoutsDataTableBindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performancesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameTableDS)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scoutsDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reviewDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bestPlayersDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bestPlayersDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reviewDataTableBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoutsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extraDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportAnalysis)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(6, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(245, 18);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Ignazio Mosconi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pref. Pos.";
            // 
            // lblPrefPos
            // 
            this.lblPrefPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPrefPos.Location = new System.Drawing.Point(71, 59);
            this.lblPrefPos.Name = "lblPrefPos";
            this.lblPrefPos.Size = new System.Drawing.Size(69, 17);
            this.lblPrefPos.TabIndex = 2;
            this.lblPrefPos.Text = "OC/OML";
            this.lblPrefPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "ASI";
            // 
            // lblASI
            // 
            this.lblASI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblASI.Location = new System.Drawing.Point(185, 58);
            this.lblASI.Name = "lblASI";
            this.lblASI.Size = new System.Drawing.Size(61, 18);
            this.lblASI.TabIndex = 2;
            this.lblASI.Text = "9891";
            this.lblASI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(153, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Age";
            // 
            // lblAge
            // 
            this.lblAge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAge.Location = new System.Drawing.Point(185, 80);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(61, 18);
            this.lblAge.TabIndex = 2;
            this.lblAge.Text = "27";
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabSkills);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPlayerScouting);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPlayerBrowser);
            this.tabControl1.Location = new System.Drawing.Point(257, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(696, 548);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabSkills
            // 
            this.tabSkills.Controls.Add(this.graphSkills);
            this.tabSkills.Location = new System.Drawing.Point(4, 22);
            this.tabSkills.Name = "tabSkills";
            this.tabSkills.Padding = new System.Windows.Forms.Padding(3);
            this.tabSkills.Size = new System.Drawing.Size(688, 522);
            this.tabSkills.TabIndex = 0;
            this.tabSkills.Text = "Skills";
            this.tabSkills.UseVisualStyleBackColor = true;
            // 
            // graphSkills
            // 
            this.graphSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphSkills.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSkills.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphSkills.IsAutoScrollRange = false;
            this.graphSkills.IsEnableHEdit = false;
            this.graphSkills.IsEnableHPan = true;
            this.graphSkills.IsEnableHZoom = true;
            this.graphSkills.IsEnableVEdit = false;
            this.graphSkills.IsEnableVPan = true;
            this.graphSkills.IsEnableVZoom = true;
            this.graphSkills.IsPrintFillPage = true;
            this.graphSkills.IsPrintKeepAspectRatio = true;
            this.graphSkills.IsScrollY2 = false;
            this.graphSkills.IsShowContextMenu = true;
            this.graphSkills.IsShowCopyMessage = true;
            this.graphSkills.IsShowCursorValues = false;
            this.graphSkills.IsShowHScrollBar = false;
            this.graphSkills.IsShowPointValues = false;
            this.graphSkills.IsShowVScrollBar = false;
            this.graphSkills.IsSynchronizeXAxes = false;
            this.graphSkills.IsSynchronizeYAxes = false;
            this.graphSkills.IsZoomOnMouseCenter = false;
            this.graphSkills.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSkills.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphSkills.Location = new System.Drawing.Point(3, 3);
            this.graphSkills.Name = "graphSkills";
            this.graphSkills.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSkills.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphSkills.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphSkills.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphSkills.PointDateFormat = "g";
            this.graphSkills.PointValueFormat = "G";
            this.graphSkills.ScrollMaxX = 0D;
            this.graphSkills.ScrollMaxY = 0D;
            this.graphSkills.ScrollMaxY2 = 0D;
            this.graphSkills.ScrollMinX = 0D;
            this.graphSkills.ScrollMinY = 0D;
            this.graphSkills.ScrollMinY2 = 0D;
            this.graphSkills.Size = new System.Drawing.Size(682, 516);
            this.graphSkills.TabIndex = 0;
            this.graphSkills.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSkills.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphSkills.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphSkills.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphSkills.ZoomStepFraction = 0.1D;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(688, 522);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "ASI";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.linkLabel1);
            this.splitContainer2.Panel1.Controls.Add(this.graphASI);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chkShowTGI);
            this.splitContainer2.Panel2.Controls.Add(this.graphTI);
            this.splitContainer2.Size = new System.Drawing.Size(682, 516);
            this.splitContainer2.SplitterDistance = 246;
            this.splitContainer2.TabIndex = 2;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(573, 1);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(108, 12);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Delta ASI - By FS Paystu";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // graphASI
            // 
            this.graphASI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphASI.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphASI.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphASI.IsAutoScrollRange = false;
            this.graphASI.IsEnableHEdit = false;
            this.graphASI.IsEnableHPan = true;
            this.graphASI.IsEnableHZoom = true;
            this.graphASI.IsEnableVEdit = false;
            this.graphASI.IsEnableVPan = true;
            this.graphASI.IsEnableVZoom = true;
            this.graphASI.IsPrintFillPage = true;
            this.graphASI.IsPrintKeepAspectRatio = true;
            this.graphASI.IsScrollY2 = false;
            this.graphASI.IsShowContextMenu = true;
            this.graphASI.IsShowCopyMessage = true;
            this.graphASI.IsShowCursorValues = false;
            this.graphASI.IsShowHScrollBar = false;
            this.graphASI.IsShowPointValues = false;
            this.graphASI.IsShowVScrollBar = false;
            this.graphASI.IsSynchronizeXAxes = false;
            this.graphASI.IsSynchronizeYAxes = false;
            this.graphASI.IsZoomOnMouseCenter = false;
            this.graphASI.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphASI.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphASI.Location = new System.Drawing.Point(0, 0);
            this.graphASI.Name = "graphASI";
            this.graphASI.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphASI.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphASI.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphASI.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphASI.PointDateFormat = "g";
            this.graphASI.PointValueFormat = "G";
            this.graphASI.ScrollMaxX = 0D;
            this.graphASI.ScrollMaxY = 0D;
            this.graphASI.ScrollMaxY2 = 0D;
            this.graphASI.ScrollMinX = 0D;
            this.graphASI.ScrollMinY = 0D;
            this.graphASI.ScrollMinY2 = 0D;
            this.graphASI.Size = new System.Drawing.Size(682, 246);
            this.graphASI.TabIndex = 1;
            this.graphASI.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphASI.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphASI.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphASI.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphASI.ZoomStepFraction = 0.1D;
            // 
            // chkShowTGI
            // 
            this.chkShowTGI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowTGI.AutoSize = true;
            this.chkShowTGI.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowTGI.Location = new System.Drawing.Point(610, 6);
            this.chkShowTGI.Name = "chkShowTGI";
            this.chkShowTGI.Size = new System.Drawing.Size(65, 16);
            this.chkShowTGI.TabIndex = 3;
            this.chkShowTGI.Text = "Show TGI";
            this.chkShowTGI.UseVisualStyleBackColor = true;
            this.chkShowTGI.CheckedChanged += new System.EventHandler(this.chkShowTGI_CheckedChanged);
            // 
            // graphTI
            // 
            this.graphTI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTI.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTI.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphTI.IsAutoScrollRange = false;
            this.graphTI.IsEnableHEdit = false;
            this.graphTI.IsEnableHPan = true;
            this.graphTI.IsEnableHZoom = true;
            this.graphTI.IsEnableVEdit = false;
            this.graphTI.IsEnableVPan = true;
            this.graphTI.IsEnableVZoom = true;
            this.graphTI.IsPrintFillPage = true;
            this.graphTI.IsPrintKeepAspectRatio = true;
            this.graphTI.IsScrollY2 = false;
            this.graphTI.IsShowContextMenu = true;
            this.graphTI.IsShowCopyMessage = true;
            this.graphTI.IsShowCursorValues = false;
            this.graphTI.IsShowHScrollBar = false;
            this.graphTI.IsShowPointValues = false;
            this.graphTI.IsShowVScrollBar = false;
            this.graphTI.IsSynchronizeXAxes = false;
            this.graphTI.IsSynchronizeYAxes = false;
            this.graphTI.IsZoomOnMouseCenter = false;
            this.graphTI.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTI.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphTI.Location = new System.Drawing.Point(0, 0);
            this.graphTI.Name = "graphTI";
            this.graphTI.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTI.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphTI.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphTI.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTI.PointDateFormat = "g";
            this.graphTI.PointValueFormat = "G";
            this.graphTI.ScrollMaxX = 0D;
            this.graphTI.ScrollMaxY = 0D;
            this.graphTI.ScrollMaxY2 = 0D;
            this.graphTI.ScrollMinX = 0D;
            this.graphTI.ScrollMinY = 0D;
            this.graphTI.ScrollMinY2 = 0D;
            this.graphTI.Size = new System.Drawing.Size(682, 266);
            this.graphTI.TabIndex = 2;
            this.graphTI.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTI.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphTI.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphTI.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTI.ZoomStepFraction = 0.1D;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.graphInjuries);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(688, 522);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Injuries";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // graphInjuries
            // 
            this.graphInjuries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphInjuries.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphInjuries.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphInjuries.IsAutoScrollRange = false;
            this.graphInjuries.IsEnableHEdit = false;
            this.graphInjuries.IsEnableHPan = true;
            this.graphInjuries.IsEnableHZoom = true;
            this.graphInjuries.IsEnableVEdit = false;
            this.graphInjuries.IsEnableVPan = true;
            this.graphInjuries.IsEnableVZoom = true;
            this.graphInjuries.IsPrintFillPage = true;
            this.graphInjuries.IsPrintKeepAspectRatio = true;
            this.graphInjuries.IsScrollY2 = false;
            this.graphInjuries.IsShowContextMenu = true;
            this.graphInjuries.IsShowCopyMessage = true;
            this.graphInjuries.IsShowCursorValues = false;
            this.graphInjuries.IsShowHScrollBar = false;
            this.graphInjuries.IsShowPointValues = false;
            this.graphInjuries.IsShowVScrollBar = false;
            this.graphInjuries.IsSynchronizeXAxes = false;
            this.graphInjuries.IsSynchronizeYAxes = false;
            this.graphInjuries.IsZoomOnMouseCenter = false;
            this.graphInjuries.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphInjuries.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphInjuries.Location = new System.Drawing.Point(3, 3);
            this.graphInjuries.Name = "graphInjuries";
            this.graphInjuries.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphInjuries.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphInjuries.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphInjuries.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphInjuries.PointDateFormat = "g";
            this.graphInjuries.PointValueFormat = "G";
            this.graphInjuries.ScrollMaxX = 0D;
            this.graphInjuries.ScrollMaxY = 0D;
            this.graphInjuries.ScrollMaxY2 = 0D;
            this.graphInjuries.ScrollMinX = 0D;
            this.graphInjuries.ScrollMinY = 0D;
            this.graphInjuries.ScrollMinY2 = 0D;
            this.graphInjuries.Size = new System.Drawing.Size(682, 516);
            this.graphInjuries.TabIndex = 2;
            this.graphInjuries.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphInjuries.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphInjuries.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphInjuries.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphInjuries.ZoomStepFraction = 0.1D;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.graphSpecs);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(688, 522);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Specs";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // graphSpecs
            // 
            this.graphSpecs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphSpecs.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSpecs.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphSpecs.IsAutoScrollRange = false;
            this.graphSpecs.IsEnableHEdit = false;
            this.graphSpecs.IsEnableHPan = true;
            this.graphSpecs.IsEnableHZoom = true;
            this.graphSpecs.IsEnableVEdit = false;
            this.graphSpecs.IsEnableVPan = true;
            this.graphSpecs.IsEnableVZoom = true;
            this.graphSpecs.IsPrintFillPage = true;
            this.graphSpecs.IsPrintKeepAspectRatio = true;
            this.graphSpecs.IsScrollY2 = false;
            this.graphSpecs.IsShowContextMenu = true;
            this.graphSpecs.IsShowCopyMessage = true;
            this.graphSpecs.IsShowCursorValues = false;
            this.graphSpecs.IsShowHScrollBar = false;
            this.graphSpecs.IsShowPointValues = false;
            this.graphSpecs.IsShowVScrollBar = false;
            this.graphSpecs.IsSynchronizeXAxes = false;
            this.graphSpecs.IsSynchronizeYAxes = false;
            this.graphSpecs.IsZoomOnMouseCenter = false;
            this.graphSpecs.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSpecs.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphSpecs.Location = new System.Drawing.Point(3, 3);
            this.graphSpecs.Name = "graphSpecs";
            this.graphSpecs.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSpecs.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphSpecs.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphSpecs.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphSpecs.PointDateFormat = "g";
            this.graphSpecs.PointValueFormat = "G";
            this.graphSpecs.ScrollMaxX = 0D;
            this.graphSpecs.ScrollMaxY = 0D;
            this.graphSpecs.ScrollMaxY2 = 0D;
            this.graphSpecs.ScrollMinX = 0D;
            this.graphSpecs.ScrollMinY = 0D;
            this.graphSpecs.ScrollMinY2 = 0D;
            this.graphSpecs.Size = new System.Drawing.Size(682, 516);
            this.graphSpecs.TabIndex = 1;
            this.graphSpecs.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSpecs.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphSpecs.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphSpecs.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphSpecs.ZoomStepFraction = 0.1D;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.toolStrip2);
            this.tabPage4.Controls.Add(this.graphPerf);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(688, 522);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Performances";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSeason,
            this.cmbSeason,
            this.chkNormalized,
            this.chkShowPosition});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(682, 25);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // lblSeason
            // 
            this.lblSeason.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeason.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblSeason.Name = "lblSeason";
            this.lblSeason.Size = new System.Drawing.Size(48, 22);
            this.lblSeason.Text = "Season";
            // 
            // cmbSeason
            // 
            this.cmbSeason.Name = "cmbSeason";
            this.cmbSeason.Size = new System.Drawing.Size(95, 25);
            this.cmbSeason.SelectedIndexChanged += new System.EventHandler(this.cmbSeason_SelectedIndexChanged);
            // 
            // chkNormalized
            // 
            this.chkNormalized.CheckOnClick = true;
            this.chkNormalized.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chkNormalized.Image = ((System.Drawing.Image)(resources.GetObject("chkNormalized.Image")));
            this.chkNormalized.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkNormalized.Name = "chkNormalized";
            this.chkNormalized.Size = new System.Drawing.Size(104, 22);
            this.chkNormalized.Text = "Normalized (OFF)";
            this.chkNormalized.CheckedChanged += new System.EventHandler(this.chkNormalized_CheckedChanged);
            // 
            // chkShowPosition
            // 
            this.chkShowPosition.CheckOnClick = true;
            this.chkShowPosition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chkShowPosition.Image = ((System.Drawing.Image)(resources.GetObject("chkShowPosition.Image")));
            this.chkShowPosition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkShowPosition.Name = "chkShowPosition";
            this.chkShowPosition.Size = new System.Drawing.Size(118, 22);
            this.chkShowPosition.Text = "Show Position (OFF)";
            this.chkShowPosition.CheckedChanged += new System.EventHandler(this.chkNormalized_CheckedChanged);
            // 
            // graphPerf
            // 
            this.graphPerf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphPerf.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphPerf.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphPerf.IsAutoScrollRange = false;
            this.graphPerf.IsEnableHEdit = false;
            this.graphPerf.IsEnableHPan = true;
            this.graphPerf.IsEnableHZoom = true;
            this.graphPerf.IsEnableVEdit = false;
            this.graphPerf.IsEnableVPan = true;
            this.graphPerf.IsEnableVZoom = true;
            this.graphPerf.IsPrintFillPage = true;
            this.graphPerf.IsPrintKeepAspectRatio = true;
            this.graphPerf.IsScrollY2 = false;
            this.graphPerf.IsShowContextMenu = true;
            this.graphPerf.IsShowCopyMessage = true;
            this.graphPerf.IsShowCursorValues = false;
            this.graphPerf.IsShowHScrollBar = false;
            this.graphPerf.IsShowPointValues = false;
            this.graphPerf.IsShowVScrollBar = false;
            this.graphPerf.IsSynchronizeXAxes = false;
            this.graphPerf.IsSynchronizeYAxes = false;
            this.graphPerf.IsZoomOnMouseCenter = false;
            this.graphPerf.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphPerf.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphPerf.Location = new System.Drawing.Point(3, 31);
            this.graphPerf.Name = "graphPerf";
            this.graphPerf.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphPerf.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphPerf.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphPerf.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphPerf.PointDateFormat = "g";
            this.graphPerf.PointValueFormat = "G";
            this.graphPerf.ScrollMaxX = 0D;
            this.graphPerf.ScrollMaxY = 0D;
            this.graphPerf.ScrollMaxY2 = 0D;
            this.graphPerf.ScrollMinX = 0D;
            this.graphPerf.ScrollMinY = 0D;
            this.graphPerf.ScrollMinY2 = 0D;
            this.graphPerf.Size = new System.Drawing.Size(610, 485);
            this.graphPerf.TabIndex = 2;
            this.graphPerf.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphPerf.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphPerf.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphPerf.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphPerf.ZoomStepFraction = 0.1D;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.toolStrip3);
            this.tabPage5.Controls.Add(this.splitContainer3);
            this.tabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(688, 522);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "Training & Potential";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(682, 25);
            this.toolStrip3.TabIndex = 8;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whatToDoHereToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(61, 22);
            this.toolStripDropDownButton2.Text = "Help";
            // 
            // whatToDoHereToolStripMenuItem
            // 
            this.whatToDoHereToolStripMenuItem.Name = "whatToDoHereToolStripMenuItem";
            this.whatToDoHereToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.whatToDoHereToolStripMenuItem.Text = "What To Do Here?";
            this.whatToDoHereToolStripMenuItem.Click += new System.EventHandler(this.whatToDoHereToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getPotentialForThisPlayerToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(150, 22);
            this.toolStripDropDownButton3.Text = "Analyse Scout Review";
            // 
            // getPotentialForThisPlayerToolStripMenuItem
            // 
            this.getPotentialForThisPlayerToolStripMenuItem.Name = "getPotentialForThisPlayerToolStripMenuItem";
            this.getPotentialForThisPlayerToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.getPotentialForThisPlayerToolStripMenuItem.Text = "Get Potentials for this Player";
            this.getPotentialForThisPlayerToolStripMenuItem.Click += new System.EventHandler(this.getPotentialForThisPlayerToolStripMenuItem_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(0, 30);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer3.Size = new System.Drawing.Size(616, 492);
            this.splitContainer3.SplitterDistance = 246;
            this.splitContainer3.SplitterWidth = 2;
            this.splitContainer3.TabIndex = 7;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.graphTrainingPsychology);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.graphTrainingPhisics);
            this.splitContainer4.Panel2.Controls.Add(this.btnGetVotenSkillAuto);
            this.splitContainer4.Size = new System.Drawing.Size(616, 246);
            this.splitContainer4.SplitterDistance = 306;
            this.splitContainer4.SplitterWidth = 2;
            this.splitContainer4.TabIndex = 7;
            // 
            // graphTrainingPsychology
            // 
            this.graphTrainingPsychology.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTrainingPsychology.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingPsychology.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphTrainingPsychology.IsAutoScrollRange = false;
            this.graphTrainingPsychology.IsEnableHEdit = false;
            this.graphTrainingPsychology.IsEnableHPan = true;
            this.graphTrainingPsychology.IsEnableHZoom = true;
            this.graphTrainingPsychology.IsEnableVEdit = false;
            this.graphTrainingPsychology.IsEnableVPan = true;
            this.graphTrainingPsychology.IsEnableVZoom = true;
            this.graphTrainingPsychology.IsPrintFillPage = true;
            this.graphTrainingPsychology.IsPrintKeepAspectRatio = true;
            this.graphTrainingPsychology.IsScrollY2 = false;
            this.graphTrainingPsychology.IsShowContextMenu = true;
            this.graphTrainingPsychology.IsShowCopyMessage = true;
            this.graphTrainingPsychology.IsShowCursorValues = false;
            this.graphTrainingPsychology.IsShowHScrollBar = false;
            this.graphTrainingPsychology.IsShowPointValues = false;
            this.graphTrainingPsychology.IsShowVScrollBar = false;
            this.graphTrainingPsychology.IsSynchronizeXAxes = false;
            this.graphTrainingPsychology.IsSynchronizeYAxes = false;
            this.graphTrainingPsychology.IsZoomOnMouseCenter = false;
            this.graphTrainingPsychology.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingPsychology.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphTrainingPsychology.Location = new System.Drawing.Point(0, 0);
            this.graphTrainingPsychology.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.graphTrainingPsychology.Name = "graphTrainingPsychology";
            this.graphTrainingPsychology.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingPsychology.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphTrainingPsychology.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphTrainingPsychology.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTrainingPsychology.PointDateFormat = "g";
            this.graphTrainingPsychology.PointValueFormat = "G";
            this.graphTrainingPsychology.ScrollMaxX = 0D;
            this.graphTrainingPsychology.ScrollMaxY = 0D;
            this.graphTrainingPsychology.ScrollMaxY2 = 0D;
            this.graphTrainingPsychology.ScrollMinX = 0D;
            this.graphTrainingPsychology.ScrollMinY = 0D;
            this.graphTrainingPsychology.ScrollMinY2 = 0D;
            this.graphTrainingPsychology.Size = new System.Drawing.Size(306, 246);
            this.graphTrainingPsychology.TabIndex = 6;
            this.graphTrainingPsychology.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingPsychology.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphTrainingPsychology.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphTrainingPsychology.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTrainingPsychology.ZoomStepFraction = 0.1D;
            // 
            // graphTrainingPhisics
            // 
            this.graphTrainingPhisics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTrainingPhisics.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingPhisics.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphTrainingPhisics.IsAutoScrollRange = false;
            this.graphTrainingPhisics.IsEnableHEdit = false;
            this.graphTrainingPhisics.IsEnableHPan = true;
            this.graphTrainingPhisics.IsEnableHZoom = true;
            this.graphTrainingPhisics.IsEnableVEdit = false;
            this.graphTrainingPhisics.IsEnableVPan = true;
            this.graphTrainingPhisics.IsEnableVZoom = true;
            this.graphTrainingPhisics.IsPrintFillPage = true;
            this.graphTrainingPhisics.IsPrintKeepAspectRatio = true;
            this.graphTrainingPhisics.IsScrollY2 = false;
            this.graphTrainingPhisics.IsShowContextMenu = true;
            this.graphTrainingPhisics.IsShowCopyMessage = true;
            this.graphTrainingPhisics.IsShowCursorValues = false;
            this.graphTrainingPhisics.IsShowHScrollBar = false;
            this.graphTrainingPhisics.IsShowPointValues = false;
            this.graphTrainingPhisics.IsShowVScrollBar = false;
            this.graphTrainingPhisics.IsSynchronizeXAxes = false;
            this.graphTrainingPhisics.IsSynchronizeYAxes = false;
            this.graphTrainingPhisics.IsZoomOnMouseCenter = false;
            this.graphTrainingPhisics.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingPhisics.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphTrainingPhisics.Location = new System.Drawing.Point(0, 0);
            this.graphTrainingPhisics.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.graphTrainingPhisics.Name = "graphTrainingPhisics";
            this.graphTrainingPhisics.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingPhisics.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphTrainingPhisics.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphTrainingPhisics.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTrainingPhisics.PointDateFormat = "g";
            this.graphTrainingPhisics.PointValueFormat = "G";
            this.graphTrainingPhisics.ScrollMaxX = 0D;
            this.graphTrainingPhisics.ScrollMaxY = 0D;
            this.graphTrainingPhisics.ScrollMaxY2 = 0D;
            this.graphTrainingPhisics.ScrollMinX = 0D;
            this.graphTrainingPhisics.ScrollMinY = 0D;
            this.graphTrainingPhisics.ScrollMinY2 = 0D;
            this.graphTrainingPhisics.Size = new System.Drawing.Size(308, 246);
            this.graphTrainingPhisics.TabIndex = 6;
            this.graphTrainingPhisics.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingPhisics.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphTrainingPhisics.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphTrainingPhisics.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTrainingPhisics.ZoomStepFraction = 0.1D;
            // 
            // btnGetVotenSkillAuto
            // 
            this.btnGetVotenSkillAuto.Location = new System.Drawing.Point(186, -31);
            this.btnGetVotenSkillAuto.Name = "btnGetVotenSkillAuto";
            this.btnGetVotenSkillAuto.Size = new System.Drawing.Size(85, 41);
            this.btnGetVotenSkillAuto.TabIndex = 4;
            this.btnGetVotenSkillAuto.Text = "Get Automatically";
            this.btnGetVotenSkillAuto.UseVisualStyleBackColor = true;
            this.btnGetVotenSkillAuto.Click += new System.EventHandler(this.btnGetVotenSkillAuto_Click);
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.graphTrainingTactics);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.graphTrainingTechnics);
            this.splitContainer5.Size = new System.Drawing.Size(616, 244);
            this.splitContainer5.SplitterDistance = 306;
            this.splitContainer5.SplitterWidth = 2;
            this.splitContainer5.TabIndex = 7;
            // 
            // graphTrainingTactics
            // 
            this.graphTrainingTactics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTrainingTactics.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingTactics.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphTrainingTactics.IsAutoScrollRange = false;
            this.graphTrainingTactics.IsEnableHEdit = false;
            this.graphTrainingTactics.IsEnableHPan = true;
            this.graphTrainingTactics.IsEnableHZoom = true;
            this.graphTrainingTactics.IsEnableVEdit = false;
            this.graphTrainingTactics.IsEnableVPan = true;
            this.graphTrainingTactics.IsEnableVZoom = true;
            this.graphTrainingTactics.IsPrintFillPage = true;
            this.graphTrainingTactics.IsPrintKeepAspectRatio = true;
            this.graphTrainingTactics.IsScrollY2 = false;
            this.graphTrainingTactics.IsShowContextMenu = true;
            this.graphTrainingTactics.IsShowCopyMessage = true;
            this.graphTrainingTactics.IsShowCursorValues = false;
            this.graphTrainingTactics.IsShowHScrollBar = false;
            this.graphTrainingTactics.IsShowPointValues = false;
            this.graphTrainingTactics.IsShowVScrollBar = false;
            this.graphTrainingTactics.IsSynchronizeXAxes = false;
            this.graphTrainingTactics.IsSynchronizeYAxes = false;
            this.graphTrainingTactics.IsZoomOnMouseCenter = false;
            this.graphTrainingTactics.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingTactics.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphTrainingTactics.Location = new System.Drawing.Point(0, 0);
            this.graphTrainingTactics.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.graphTrainingTactics.Name = "graphTrainingTactics";
            this.graphTrainingTactics.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingTactics.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphTrainingTactics.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphTrainingTactics.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTrainingTactics.PointDateFormat = "g";
            this.graphTrainingTactics.PointValueFormat = "G";
            this.graphTrainingTactics.ScrollMaxX = 0D;
            this.graphTrainingTactics.ScrollMaxY = 0D;
            this.graphTrainingTactics.ScrollMaxY2 = 0D;
            this.graphTrainingTactics.ScrollMinX = 0D;
            this.graphTrainingTactics.ScrollMinY = 0D;
            this.graphTrainingTactics.ScrollMinY2 = 0D;
            this.graphTrainingTactics.Size = new System.Drawing.Size(306, 244);
            this.graphTrainingTactics.TabIndex = 6;
            this.graphTrainingTactics.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingTactics.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphTrainingTactics.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphTrainingTactics.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTrainingTactics.ZoomStepFraction = 0.1D;
            // 
            // graphTrainingTechnics
            // 
            this.graphTrainingTechnics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTrainingTechnics.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingTechnics.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphTrainingTechnics.IsAutoScrollRange = false;
            this.graphTrainingTechnics.IsEnableHEdit = false;
            this.graphTrainingTechnics.IsEnableHPan = true;
            this.graphTrainingTechnics.IsEnableHZoom = true;
            this.graphTrainingTechnics.IsEnableVEdit = false;
            this.graphTrainingTechnics.IsEnableVPan = true;
            this.graphTrainingTechnics.IsEnableVZoom = true;
            this.graphTrainingTechnics.IsPrintFillPage = true;
            this.graphTrainingTechnics.IsPrintKeepAspectRatio = true;
            this.graphTrainingTechnics.IsScrollY2 = false;
            this.graphTrainingTechnics.IsShowContextMenu = true;
            this.graphTrainingTechnics.IsShowCopyMessage = true;
            this.graphTrainingTechnics.IsShowCursorValues = false;
            this.graphTrainingTechnics.IsShowHScrollBar = false;
            this.graphTrainingTechnics.IsShowPointValues = false;
            this.graphTrainingTechnics.IsShowVScrollBar = false;
            this.graphTrainingTechnics.IsSynchronizeXAxes = false;
            this.graphTrainingTechnics.IsSynchronizeYAxes = false;
            this.graphTrainingTechnics.IsZoomOnMouseCenter = false;
            this.graphTrainingTechnics.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingTechnics.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphTrainingTechnics.Location = new System.Drawing.Point(0, 0);
            this.graphTrainingTechnics.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.graphTrainingTechnics.Name = "graphTrainingTechnics";
            this.graphTrainingTechnics.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingTechnics.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphTrainingTechnics.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphTrainingTechnics.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTrainingTechnics.PointDateFormat = "g";
            this.graphTrainingTechnics.PointValueFormat = "G";
            this.graphTrainingTechnics.ScrollMaxX = 0D;
            this.graphTrainingTechnics.ScrollMaxY = 0D;
            this.graphTrainingTechnics.ScrollMaxY2 = 0D;
            this.graphTrainingTechnics.ScrollMinX = 0D;
            this.graphTrainingTechnics.ScrollMinY = 0D;
            this.graphTrainingTechnics.ScrollMinY2 = 0D;
            this.graphTrainingTechnics.Size = new System.Drawing.Size(308, 244);
            this.graphTrainingTechnics.TabIndex = 6;
            this.graphTrainingTechnics.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrainingTechnics.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphTrainingTechnics.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphTrainingTechnics.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTrainingTechnics.ZoomStepFraction = 0.1D;
            // 
            // tabPlayerScouting
            // 
            this.tabPlayerScouting.Controls.Add(this.label3);
            this.tabPlayerScouting.Controls.Add(this.label7);
            this.tabPlayerScouting.Controls.Add(this.label4);
            this.tabPlayerScouting.Controls.Add(this.dgScouts);
            this.tabPlayerScouting.Controls.Add(this.dgReviews);
            this.tabPlayerScouting.Controls.Add(this.tagsBarPro);
            this.tabPlayerScouting.Controls.Add(this.tagsBarAgg);
            this.tabPlayerScouting.Controls.Add(this.tagsBarLea);
            this.tabPlayerScouting.Controls.Add(this.tagsBarTec);
            this.tabPlayerScouting.Controls.Add(this.tagsBarTac);
            this.tabPlayerScouting.Controls.Add(this.tagsBarPhy);
            this.tabPlayerScouting.Location = new System.Drawing.Point(4, 22);
            this.tabPlayerScouting.Name = "tabPlayerScouting";
            this.tabPlayerScouting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlayerScouting.Size = new System.Drawing.Size(688, 522);
            this.tabPlayerScouting.TabIndex = 8;
            this.tabPlayerScouting.Text = "Scouts Report";
            this.tabPlayerScouting.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(6, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Weighted Summary";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(6, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Scouts";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(6, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Scouts Reviews";
            // 
            // dgScouts
            // 
            this.dgScouts.AllowUserToAddRows = false;
            this.dgScouts.AllowUserToDeleteRows = false;
            this.dgScouts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgScouts.AutoGenerateColumns = false;
            this.dgScouts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgScouts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgScouts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.developmentDataGridViewTextBoxColumn1,
            this.seniorDataGridViewTextBoxColumn,
            this.youthDataGridViewTextBoxColumn,
            this.physicalDataGridViewTextBoxColumn1,
            this.tacticalDataGridViewTextBoxColumn1,
            this.technicalDataGridViewTextBoxColumn1,
            this.psychologyDataGridViewTextBoxColumn});
            this.dgScouts.DataMember = "Scouts";
            this.dgScouts.DataSource = this.scoutsNReviews;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = "-";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgScouts.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgScouts.Location = new System.Drawing.Point(6, 29);
            this.dgScouts.Name = "dgScouts";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgScouts.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgScouts.RowHeadersWidth = 20;
            this.dgScouts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgScouts.Size = new System.Drawing.Size(676, 138);
            this.dgScouts.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // developmentDataGridViewTextBoxColumn1
            // 
            this.developmentDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.developmentDataGridViewTextBoxColumn1.DataPropertyName = "Development";
            this.developmentDataGridViewTextBoxColumn1.HeaderText = "Development";
            this.developmentDataGridViewTextBoxColumn1.Name = "developmentDataGridViewTextBoxColumn1";
            this.developmentDataGridViewTextBoxColumn1.Width = 95;
            // 
            // seniorDataGridViewTextBoxColumn
            // 
            this.seniorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.seniorDataGridViewTextBoxColumn.DataPropertyName = "Senior";
            this.seniorDataGridViewTextBoxColumn.HeaderText = "Senior";
            this.seniorDataGridViewTextBoxColumn.Name = "seniorDataGridViewTextBoxColumn";
            this.seniorDataGridViewTextBoxColumn.Width = 62;
            // 
            // youthDataGridViewTextBoxColumn
            // 
            this.youthDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.youthDataGridViewTextBoxColumn.DataPropertyName = "Youth";
            this.youthDataGridViewTextBoxColumn.HeaderText = "Youth";
            this.youthDataGridViewTextBoxColumn.Name = "youthDataGridViewTextBoxColumn";
            this.youthDataGridViewTextBoxColumn.Width = 60;
            // 
            // physicalDataGridViewTextBoxColumn1
            // 
            this.physicalDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.physicalDataGridViewTextBoxColumn1.DataPropertyName = "Physical";
            this.physicalDataGridViewTextBoxColumn1.HeaderText = "Physical";
            this.physicalDataGridViewTextBoxColumn1.Name = "physicalDataGridViewTextBoxColumn1";
            this.physicalDataGridViewTextBoxColumn1.Width = 71;
            // 
            // tacticalDataGridViewTextBoxColumn1
            // 
            this.tacticalDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tacticalDataGridViewTextBoxColumn1.DataPropertyName = "Tactical";
            this.tacticalDataGridViewTextBoxColumn1.HeaderText = "Tactical";
            this.tacticalDataGridViewTextBoxColumn1.Name = "tacticalDataGridViewTextBoxColumn1";
            this.tacticalDataGridViewTextBoxColumn1.Width = 70;
            // 
            // technicalDataGridViewTextBoxColumn1
            // 
            this.technicalDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.technicalDataGridViewTextBoxColumn1.DataPropertyName = "Technical";
            this.technicalDataGridViewTextBoxColumn1.HeaderText = "Technical";
            this.technicalDataGridViewTextBoxColumn1.Name = "technicalDataGridViewTextBoxColumn1";
            this.technicalDataGridViewTextBoxColumn1.Width = 79;
            // 
            // psychologyDataGridViewTextBoxColumn
            // 
            this.psychologyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.psychologyDataGridViewTextBoxColumn.DataPropertyName = "Psychology";
            this.psychologyDataGridViewTextBoxColumn.HeaderText = "Psychology";
            this.psychologyDataGridViewTextBoxColumn.Name = "psychologyDataGridViewTextBoxColumn";
            this.psychologyDataGridViewTextBoxColumn.Width = 86;
            // 
            // scoutsNReviews
            // 
            this.scoutsNReviews.DataSetName = "ScoutsNReviews";
            this.scoutsNReviews.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgReviews
            // 
            this.dgReviews.AllowUserToAddRows = false;
            this.dgReviews.AllowUserToDeleteRows = false;
            this.dgReviews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgReviews.AutoGenerateColumns = false;
            this.dgReviews.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReviews.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scoutIDDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn,
            this.Vote,
            this.bloomingDataGridViewTextBoxColumn,
            this.BloomingStatus,
            this.Development,
            this.Speciality,
            this.Physics,
            this.Tactics,
            this.Technics,
            this.Charisma,
            this.Professionalism,
            this.aggressivityDataGridViewTextBoxColumn});
            this.dgReviews.DataMember = "Review";
            this.dgReviews.DataSource = this.scoutsNReviews;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.NullValue = "-";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgReviews.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgReviews.Location = new System.Drawing.Point(6, 191);
            this.dgReviews.Name = "dgReviews";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgReviews.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgReviews.RowHeadersWidth = 20;
            this.dgReviews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgReviews.Size = new System.Drawing.Size(676, 175);
            this.dgReviews.TabIndex = 0;
            // 
            // scoutIDDataGridViewTextBoxColumn
            // 
            this.scoutIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.scoutIDDataGridViewTextBoxColumn.DataPropertyName = "ScoutName";
            this.scoutIDDataGridViewTextBoxColumn.HeaderText = "Scout";
            this.scoutIDDataGridViewTextBoxColumn.Name = "scoutIDDataGridViewTextBoxColumn";
            this.scoutIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 55;
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            this.ageDataGridViewTextBoxColumn.Width = 30;
            // 
            // Vote
            // 
            this.Vote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Vote.DataPropertyName = "Vote";
            this.Vote.FPn = 0;
            this.Vote.HeaderText = "Vote";
            this.Vote.MinimumWidth = 30;
            this.Vote.Name = "Vote";
            this.Vote.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Vote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Vote.Width = 30;
            // 
            // bloomingDataGridViewTextBoxColumn
            // 
            this.bloomingDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bloomingDataGridViewTextBoxColumn.DataPropertyName = "Blooming";
            this.bloomingDataGridViewTextBoxColumn.FPn = 0;
            this.bloomingDataGridViewTextBoxColumn.HeaderText = "Blo";
            this.bloomingDataGridViewTextBoxColumn.Name = "bloomingDataGridViewTextBoxColumn";
            this.bloomingDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.bloomingDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.bloomingDataGridViewTextBoxColumn.ToolTipText = "Blooming";
            this.bloomingDataGridViewTextBoxColumn.Width = 47;
            // 
            // BloomingStatus
            // 
            this.BloomingStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BloomingStatus.DataPropertyName = "Blooming_Status";
            this.BloomingStatus.FPn = 0;
            this.BloomingStatus.HeaderText = "Bl.Stat";
            this.BloomingStatus.Name = "BloomingStatus";
            this.BloomingStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BloomingStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BloomingStatus.ToolTipText = "Blooming Status";
            this.BloomingStatus.Width = 63;
            // 
            // Development
            // 
            this.Development.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Development.DataPropertyName = "Development";
            this.Development.FPn = 0;
            this.Development.HeaderText = "Dev";
            this.Development.Name = "Development";
            this.Development.Width = 33;
            // 
            // Speciality
            // 
            this.Speciality.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Speciality.DataPropertyName = "Speciality";
            this.Speciality.FPn = 0;
            this.Speciality.HeaderText = "Spe";
            this.Speciality.Name = "Speciality";
            this.Speciality.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Speciality.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Speciality.ToolTipText = "Speciality";
            this.Speciality.Width = 51;
            // 
            // Physics
            // 
            this.Physics.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Physics.DataPropertyName = "Physique";
            this.Physics.FPn = 0;
            this.Physics.HeaderText = "Phy";
            this.Physics.Name = "Physics";
            this.Physics.Width = 31;
            // 
            // Tactics
            // 
            this.Tactics.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tactics.DataPropertyName = "Tactics";
            this.Tactics.FPn = 0;
            this.Tactics.HeaderText = "Tac";
            this.Tactics.Name = "Tactics";
            this.Tactics.Width = 32;
            // 
            // Technics
            // 
            this.Technics.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Technics.DataPropertyName = "Technics";
            this.Technics.FPn = 0;
            this.Technics.HeaderText = "Tec";
            this.Technics.Name = "Technics";
            this.Technics.Width = 32;
            // 
            // Charisma
            // 
            this.Charisma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Charisma.DataPropertyName = "Charisma";
            this.Charisma.FPn = 0;
            this.Charisma.HeaderText = "Lea";
            this.Charisma.Name = "Charisma";
            this.Charisma.Width = 31;
            // 
            // Professionalism
            // 
            this.Professionalism.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Professionalism.DataPropertyName = "Professionalism";
            this.Professionalism.FPn = 0;
            this.Professionalism.HeaderText = "Pro";
            this.Professionalism.Name = "Professionalism";
            this.Professionalism.Width = 29;
            // 
            // aggressivityDataGridViewTextBoxColumn
            // 
            this.aggressivityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.aggressivityDataGridViewTextBoxColumn.DataPropertyName = "Aggressivity";
            this.aggressivityDataGridViewTextBoxColumn.FPn = 0;
            this.aggressivityDataGridViewTextBoxColumn.HeaderText = "Agg";
            this.aggressivityDataGridViewTextBoxColumn.Name = "aggressivityDataGridViewTextBoxColumn";
            this.aggressivityDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aggressivityDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.aggressivityDataGridViewTextBoxColumn.ToolTipText = "Aggressivity";
            this.aggressivityDataGridViewTextBoxColumn.Width = 51;
            // 
            // tagsBarPro
            // 
            this.tagsBarPro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tagsBarPro.BorderColor = System.Drawing.Color.Gray;
            this.tagsBarPro.FillerColor = System.Drawing.Color.Gold;
            this.tagsBarPro.Location = new System.Drawing.Point(576, 398);
            this.tagsBarPro.Max = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tagsBarPro.Min = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tagsBarPro.Name = "tagsBarPro";
            this.tagsBarPro.Size = new System.Drawing.Size(104, 121);
            this.tagsBarPro.TabIndex = 3;
            this.tagsBarPro.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("tagsBarPro.Tags")));
            this.tagsBarPro.TextColor = System.Drawing.Color.SaddleBrown;
            this.tagsBarPro.Title = "Professionalism";
            this.tagsBarPro.TitleColor = System.Drawing.Color.Olive;
            this.tagsBarPro.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // tagsBarAgg
            // 
            this.tagsBarAgg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tagsBarAgg.BorderColor = System.Drawing.Color.Gray;
            this.tagsBarAgg.FillerColor = System.Drawing.Color.Gold;
            this.tagsBarAgg.Location = new System.Drawing.Point(462, 398);
            this.tagsBarAgg.Max = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tagsBarAgg.Min = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tagsBarAgg.Name = "tagsBarAgg";
            this.tagsBarAgg.Size = new System.Drawing.Size(104, 121);
            this.tagsBarAgg.TabIndex = 3;
            this.tagsBarAgg.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("tagsBarAgg.Tags")));
            this.tagsBarAgg.TextColor = System.Drawing.Color.SaddleBrown;
            this.tagsBarAgg.Title = "Aggressivity";
            this.tagsBarAgg.TitleColor = System.Drawing.Color.Olive;
            this.tagsBarAgg.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // tagsBarLea
            // 
            this.tagsBarLea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tagsBarLea.BorderColor = System.Drawing.Color.Gray;
            this.tagsBarLea.FillerColor = System.Drawing.Color.Gold;
            this.tagsBarLea.Location = new System.Drawing.Point(348, 398);
            this.tagsBarLea.Max = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tagsBarLea.Min = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tagsBarLea.Name = "tagsBarLea";
            this.tagsBarLea.Size = new System.Drawing.Size(104, 121);
            this.tagsBarLea.TabIndex = 3;
            this.tagsBarLea.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("tagsBarLea.Tags")));
            this.tagsBarLea.TextColor = System.Drawing.Color.SaddleBrown;
            this.tagsBarLea.Title = "LeaderShip";
            this.tagsBarLea.TitleColor = System.Drawing.Color.Olive;
            this.tagsBarLea.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // tagsBarTec
            // 
            this.tagsBarTec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tagsBarTec.BorderColor = System.Drawing.Color.Gray;
            this.tagsBarTec.FillerColor = System.Drawing.Color.MediumTurquoise;
            this.tagsBarTec.Location = new System.Drawing.Point(234, 398);
            this.tagsBarTec.Max = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tagsBarTec.Min = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tagsBarTec.Name = "tagsBarTec";
            this.tagsBarTec.Size = new System.Drawing.Size(104, 121);
            this.tagsBarTec.TabIndex = 3;
            this.tagsBarTec.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("tagsBarTec.Tags")));
            this.tagsBarTec.TextColor = System.Drawing.Color.RoyalBlue;
            this.tagsBarTec.Title = "Technics";
            this.tagsBarTec.TitleColor = System.Drawing.Color.DarkBlue;
            this.tagsBarTec.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // tagsBarTac
            // 
            this.tagsBarTac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tagsBarTac.BorderColor = System.Drawing.Color.Gray;
            this.tagsBarTac.FillerColor = System.Drawing.Color.MediumTurquoise;
            this.tagsBarTac.Location = new System.Drawing.Point(120, 398);
            this.tagsBarTac.Max = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tagsBarTac.Min = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tagsBarTac.Name = "tagsBarTac";
            this.tagsBarTac.Size = new System.Drawing.Size(104, 121);
            this.tagsBarTac.TabIndex = 3;
            this.tagsBarTac.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("tagsBarTac.Tags")));
            this.tagsBarTac.TextColor = System.Drawing.Color.RoyalBlue;
            this.tagsBarTac.Title = "Tactics";
            this.tagsBarTac.TitleColor = System.Drawing.Color.DarkBlue;
            this.tagsBarTac.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // tagsBarPhy
            // 
            this.tagsBarPhy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tagsBarPhy.BorderColor = System.Drawing.Color.Gray;
            this.tagsBarPhy.FillerColor = System.Drawing.Color.MediumTurquoise;
            this.tagsBarPhy.Location = new System.Drawing.Point(6, 398);
            this.tagsBarPhy.Max = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tagsBarPhy.Min = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tagsBarPhy.Name = "tagsBarPhy";
            this.tagsBarPhy.Size = new System.Drawing.Size(104, 121);
            this.tagsBarPhy.TabIndex = 3;
            this.tagsBarPhy.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("tagsBarPhy.Tags")));
            this.tagsBarPhy.TextColor = System.Drawing.Color.RoyalBlue;
            this.tagsBarPhy.Title = "Physics";
            this.tagsBarPhy.TitleColor = System.Drawing.Color.DarkBlue;
            this.tagsBarPhy.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dataGridView1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(688, 522);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "Player Training";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerAge,
            this.absWeekDataGridViewTextBoxColumn,
            this.forDataGridViewTextBoxColumn,
            this.resDataGridViewTextBoxColumn,
            this.velDataGridViewTextBoxColumn,
            this.marDataGridViewTextBoxColumn,
            this.conDataGridViewTextBoxColumn,
            this.worDataGridViewTextBoxColumn,
            this.posDataGridViewTextBoxColumn,
            this.pasDataGridViewTextBoxColumn,
            this.croDataGridViewTextBoxColumn,
            this.tecDataGridViewTextBoxColumn,
            this.tesDataGridViewTextBoxColumn,
            this.finDataGridViewTextBoxColumn,
            this.tirDataGridViewTextBoxColumn,
            this.calDataGridViewTextBoxColumn,
            this.tIDataGridViewTextBoxColumn,
            this.trainerNameDataGridViewTextBoxColumn,
            this.programDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.trainingBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(682, 516);
            this.dataGridView1.TabIndex = 0;
            // 
            // trainingBindingSource
            // 
            this.trainingBindingSource.DataMember = "Training";
            this.trainingBindingSource.DataSource = this.playerTraining;
            // 
            // playerTraining
            // 
            this.playerTraining.DataSetName = "PlayerTraining";
            this.playerTraining.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPlayerBrowser
            // 
            this.tabPlayerBrowser.Controls.Add(this.toolStripContainer1);
            this.tabPlayerBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabPlayerBrowser.Name = "tabPlayerBrowser";
            this.tabPlayerBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlayerBrowser.Size = new System.Drawing.Size(688, 522);
            this.tabPlayerBrowser.TabIndex = 7;
            this.tabPlayerBrowser.Text = "Trophy Browser - Player";
            this.tabPlayerBrowser.UseVisualStyleBackColor = true;
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(688, 497);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(688, 522);
            this.toolStripContainer1.TabIndex = 1;
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
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(688, 497);
            this.webBrowser.TabIndex = 2;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
            this.webBrowser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser_ProgressChanged);
            // 
            // tsBrowsePlayers
            // 
            this.tsBrowsePlayers.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBrowsePlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel6,
            this.tsbLoadPlayerPage,
            this.tsbNavigationType,
            this.toolStripSeparator11,
            this.toolStripLabel4,
            this.tsbProgressBar,
            this.tsbProgressText,
            this.tsbImport});
            this.tsBrowsePlayers.Location = new System.Drawing.Point(3, 0);
            this.tsBrowsePlayers.Name = "tsBrowsePlayers";
            this.tsBrowsePlayers.Size = new System.Drawing.Size(620, 25);
            this.tsBrowsePlayers.TabIndex = 3;
            this.tsBrowsePlayers.Text = "toolStrip2";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(136, 22);
            this.toolStripLabel6.Text = "Browsing Players Tools";
            // 
            // tsbLoadPlayerPage
            // 
            this.tsbLoadPlayerPage.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadPlayerPage.Image")));
            this.tsbLoadPlayerPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadPlayerPage.Name = "tsbLoadPlayerPage";
            this.tsbLoadPlayerPage.Size = new System.Drawing.Size(117, 22);
            this.tsbLoadPlayerPage.Text = "Load Player Page";
            this.tsbLoadPlayerPage.Click += new System.EventHandler(this.tsbLoadPlayerPage_Click);
            // 
            // tsbNavigationType
            // 
            this.tsbNavigationType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigateProfilesToolStripMenuItem,
            this.navigateReportsToolStripMenuItem});
            this.tsbNavigationType.Image = ((System.Drawing.Image)(resources.GetObject("tsbNavigationType.Image")));
            this.tsbNavigationType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNavigationType.Name = "tsbNavigationType";
            this.tsbNavigationType.Size = new System.Drawing.Size(125, 22);
            this.tsbNavigationType.Text = "Navigate Profiles";
            // 
            // navigateProfilesToolStripMenuItem
            // 
            this.navigateProfilesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("navigateProfilesToolStripMenuItem.Image")));
            this.navigateProfilesToolStripMenuItem.Name = "navigateProfilesToolStripMenuItem";
            this.navigateProfilesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.navigateProfilesToolStripMenuItem.Text = "Navigate Profiles";
            this.navigateProfilesToolStripMenuItem.Click += new System.EventHandler(this.navigateProfilesToolStripMenuItem_Click);
            // 
            // navigateReportsToolStripMenuItem
            // 
            this.navigateReportsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("navigateReportsToolStripMenuItem.Image")));
            this.navigateReportsToolStripMenuItem.Name = "navigateReportsToolStripMenuItem";
            this.navigateReportsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.navigateReportsToolStripMenuItem.Text = "Navigate Reports";
            this.navigateReportsToolStripMenuItem.Click += new System.EventHandler(this.navigateReportsToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
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
            this.tsbImport.BackColor = System.Drawing.SystemColors.Control;
            this.tsbImport.Image = ((System.Drawing.Image)(resources.GetObject("tsbImport.Image")));
            this.tsbImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Size = new System.Drawing.Size(63, 22);
            this.tsbImport.Text = "Import";
            this.tsbImport.Click += new System.EventHandler(this.tsbImport_Click);
            // 
            // scoutsDataTableBindingSource1
            // 
            this.scoutsDataTableBindingSource1.DataSource = typeof(Common.ScoutsNReviews.ScoutsDataTable);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(0, 19);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ReadOnly = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(239, 88);
            this.txtNotes.TabIndex = 6;
            this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBloomAge);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblRoutine);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.playerData1);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(6, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 141);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Skills";
            // 
            // lblBloomAge
            // 
            this.lblBloomAge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblBloomAge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBloomAge.ForeColor = System.Drawing.Color.Black;
            this.lblBloomAge.Location = new System.Drawing.Point(190, 116);
            this.lblBloomAge.Name = "lblBloomAge";
            this.lblBloomAge.Size = new System.Drawing.Size(45, 17);
            this.lblBloomAge.TabIndex = 3;
            this.lblBloomAge.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(126, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Bloom Age";
            // 
            // lblRoutine
            // 
            this.lblRoutine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblRoutine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRoutine.ForeColor = System.Drawing.Color.Black;
            this.lblRoutine.Location = new System.Drawing.Point(59, 116);
            this.lblRoutine.Name = "lblRoutine";
            this.lblRoutine.Size = new System.Drawing.Size(36, 17);
            this.lblRoutine.TabIndex = 3;
            this.lblRoutine.Text = "-";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(14, 118);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 13);
            this.label24.TabIndex = 2;
            this.label24.Text = "Routine";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox2.Location = new System.Drawing.Point(6, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 331);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player Info";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.txtNotes);
            this.splitContainer1.Size = new System.Drawing.Size(239, 312);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.TabIndex = 10;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seasonDataGridViewTextBoxColumn,
            this.gPDataGridViewTextBoxColumn,
            this.gDataGridViewTextBoxColumn,
            this.aDataGridViewTextBoxColumn,
            this.cardsDataGridViewTextBoxColumn,
            this.ratDataGridViewTextBoxColumn,
            this.ratDevDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.performancesBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView2.RowHeadersWidth = 10;
            this.dataGridView2.RowTemplate.Height = 19;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(239, 201);
            this.dataGridView2.TabIndex = 0;
            // 
            // seasonDataGridViewTextBoxColumn
            // 
            this.seasonDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.seasonDataGridViewTextBoxColumn.DataPropertyName = "Season";
            this.seasonDataGridViewTextBoxColumn.HeaderText = "Sea";
            this.seasonDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.seasonDataGridViewTextBoxColumn.Name = "seasonDataGridViewTextBoxColumn";
            this.seasonDataGridViewTextBoxColumn.ReadOnly = true;
            this.seasonDataGridViewTextBoxColumn.ToolTipText = "Season";
            // 
            // gPDataGridViewTextBoxColumn
            // 
            this.gPDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.gPDataGridViewTextBoxColumn.DataPropertyName = "GP";
            this.gPDataGridViewTextBoxColumn.HeaderText = "GP";
            this.gPDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.gPDataGridViewTextBoxColumn.Name = "gPDataGridViewTextBoxColumn";
            this.gPDataGridViewTextBoxColumn.ReadOnly = true;
            this.gPDataGridViewTextBoxColumn.ToolTipText = "Game Played";
            this.gPDataGridViewTextBoxColumn.Width = 30;
            // 
            // gDataGridViewTextBoxColumn
            // 
            this.gDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.gDataGridViewTextBoxColumn.DataPropertyName = "G";
            this.gDataGridViewTextBoxColumn.HeaderText = "G";
            this.gDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.gDataGridViewTextBoxColumn.Name = "gDataGridViewTextBoxColumn";
            this.gDataGridViewTextBoxColumn.ReadOnly = true;
            this.gDataGridViewTextBoxColumn.ToolTipText = "Goals";
            this.gDataGridViewTextBoxColumn.Width = 30;
            // 
            // aDataGridViewTextBoxColumn
            // 
            this.aDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.aDataGridViewTextBoxColumn.DataPropertyName = "A";
            this.aDataGridViewTextBoxColumn.HeaderText = "A";
            this.aDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.aDataGridViewTextBoxColumn.Name = "aDataGridViewTextBoxColumn";
            this.aDataGridViewTextBoxColumn.ReadOnly = true;
            this.aDataGridViewTextBoxColumn.ToolTipText = "Assists";
            this.aDataGridViewTextBoxColumn.Width = 30;
            // 
            // cardsDataGridViewTextBoxColumn
            // 
            this.cardsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.cardsDataGridViewTextBoxColumn.DataPropertyName = "Cards";
            this.cardsDataGridViewTextBoxColumn.HeaderText = "Crd";
            this.cardsDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.cardsDataGridViewTextBoxColumn.Name = "cardsDataGridViewTextBoxColumn";
            this.cardsDataGridViewTextBoxColumn.ReadOnly = true;
            this.cardsDataGridViewTextBoxColumn.ToolTipText = "Cards";
            this.cardsDataGridViewTextBoxColumn.Width = 30;
            // 
            // ratDataGridViewTextBoxColumn
            // 
            this.ratDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ratDataGridViewTextBoxColumn.DataPropertyName = "Rat";
            dataGridViewCellStyle7.Format = "N1";
            this.ratDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.ratDataGridViewTextBoxColumn.HeaderText = "Rat";
            this.ratDataGridViewTextBoxColumn.MinimumWidth = 33;
            this.ratDataGridViewTextBoxColumn.Name = "ratDataGridViewTextBoxColumn";
            this.ratDataGridViewTextBoxColumn.ReadOnly = true;
            this.ratDataGridViewTextBoxColumn.ToolTipText = "Ratings";
            this.ratDataGridViewTextBoxColumn.Width = 33;
            // 
            // ratDevDataGridViewTextBoxColumn
            // 
            this.ratDevDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ratDevDataGridViewTextBoxColumn.DataPropertyName = "MoM";
            this.ratDevDataGridViewTextBoxColumn.HeaderText = "MoM";
            this.ratDevDataGridViewTextBoxColumn.MinimumWidth = 38;
            this.ratDevDataGridViewTextBoxColumn.Name = "ratDevDataGridViewTextBoxColumn";
            this.ratDevDataGridViewTextBoxColumn.ReadOnly = true;
            this.ratDevDataGridViewTextBoxColumn.ToolTipText = "Man of the Match";
            this.ratDevDataGridViewTextBoxColumn.Width = 38;
            // 
            // performancesBindingSource
            // 
            this.performancesBindingSource.DataMember = "Performances";
            this.performancesBindingSource.DataSource = this.gameTableDS;
            // 
            // gameTableDS
            // 
            this.gameTableDS.DataSetName = "GameTable";
            this.gameTableDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.tsbPlayers,
            this.toolStripButton4,
            this.toolStripButton3,
            this.tsbComputeGrowth});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(953, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStripMenu";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel2.Text = "Browse";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(88, 22);
            this.toolStripButton1.Text = "Prev. Player";
            this.toolStripButton1.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(86, 22);
            this.toolStripButton2.Text = "Next Player";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripButton2.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel1.Text = "Edit";
            // 
            // tsbPlayers
            // 
            this.tsbPlayers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton4.Text = "Explore Player";
            this.toolStripButton4.Click += new System.EventHandler(this.openPlayerPageToolStripMenuItem_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(146, 22);
            this.toolStripButton3.Text = "Export History To Excel";
            this.toolStripButton3.Click += new System.EventHandler(this.exportInExcelFormat_Click);
            // 
            // tsbComputeGrowth
            // 
            this.tsbComputeGrowth.Image = ((System.Drawing.Image)(resources.GetObject("tsbComputeGrowth.Image")));
            this.tsbComputeGrowth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbComputeGrowth.Name = "tsbComputeGrowth";
            this.tsbComputeGrowth.Size = new System.Drawing.Size(119, 22);
            this.tsbComputeGrowth.Text = "Compute Growth";
            this.tsbComputeGrowth.Click += new System.EventHandler(this.tsbComputeGrowth_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wage";
            // 
            // lblWage
            // 
            this.lblWage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWage.Location = new System.Drawing.Point(71, 80);
            this.lblWage.Name = "lblWage";
            this.lblWage.Size = new System.Drawing.Size(69, 18);
            this.lblWage.TabIndex = 2;
            this.lblWage.Text = "27";
            this.lblWage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmR_AgeColumn1
            // 
            this.tmR_AgeColumn1.DataPropertyName = "Age";
            this.tmR_AgeColumn1.HeaderText = "Age";
            this.tmR_AgeColumn1.Name = "tmR_AgeColumn1";
            this.tmR_AgeColumn1.When = new System.DateTime(2015, 4, 19, 16, 39, 22, 335);
            this.tmR_AgeColumn1.Width = 40;
            // 
            // tmR_DateColumn1
            // 
            this.tmR_DateColumn1.DataPropertyName = "absWeek";
            this.tmR_DateColumn1.HeaderText = "Week";
            this.tmR_DateColumn1.Name = "tmR_DateColumn1";
            this.tmR_DateColumn1.ReadOnly = true;
            this.tmR_DateColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_DateColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_DateColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "For";
            this.dataGridViewTextBoxColumn1.HeaderText = "Str";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 23;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Res";
            this.dataGridViewTextBoxColumn2.HeaderText = "Res";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 23;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Vel";
            this.dataGridViewTextBoxColumn3.HeaderText = "Pac";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 23;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Mar";
            this.dataGridViewTextBoxColumn4.HeaderText = "Mar";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 23;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Con";
            this.dataGridViewTextBoxColumn5.HeaderText = "Tak";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 23;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Wor";
            this.dataGridViewTextBoxColumn6.HeaderText = "Wor";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 23;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Pos";
            this.dataGridViewTextBoxColumn7.HeaderText = "Pos";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 23;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Pas";
            this.dataGridViewTextBoxColumn8.HeaderText = "Pas";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 23;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Cro";
            this.dataGridViewTextBoxColumn9.HeaderText = "Cro";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 23;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Tec";
            this.dataGridViewTextBoxColumn10.HeaderText = "Tec";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 23;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Tes";
            this.dataGridViewTextBoxColumn11.HeaderText = "Hea";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 23;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Fin";
            this.dataGridViewTextBoxColumn12.HeaderText = "Fin";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 23;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Tir";
            this.dataGridViewTextBoxColumn13.HeaderText = "Tir";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 23;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Cal";
            this.dataGridViewTextBoxColumn14.HeaderText = "CP";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 23;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "TI";
            this.dataGridViewTextBoxColumn15.HeaderText = "TI";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 35;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "TrainerName";
            this.dataGridViewTextBoxColumn16.HeaderText = "Trainer";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Program";
            this.dataGridViewTextBoxColumn17.HeaderText = "Program";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Percentage";
            this.dataGridViewTextBoxColumn18.HeaderText = "%";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 30;
            // 
            // scoutsDataTableBindingSource
            // 
            this.scoutsDataTableBindingSource.DataSource = typeof(Common.ScoutsNReviews.ScoutsDataTable);
            // 
            // reviewDataTableBindingSource
            // 
            this.reviewDataTableBindingSource.DataSource = typeof(Common.ScoutsNReviews.ReviewDataTable);
            this.reviewDataTableBindingSource.CurrentChanged += new System.EventHandler(this.reviewDataTableBindingSource_CurrentChanged);
            // 
            // bestPlayersDS
            // 
            this.bestPlayersDS.DataSetName = "BestPlayersDS";
            this.bestPlayersDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bestPlayersDSBindingSource
            // 
            this.bestPlayersDSBindingSource.DataSource = this.bestPlayersDS;
            this.bestPlayersDSBindingSource.Position = 0;
            // 
            // reviewDataTableBindingSource1
            // 
            this.reviewDataTableBindingSource1.DataMember = "Review";
            this.reviewDataTableBindingSource1.DataSource = this.scoutsNReviews;
            // 
            // scoutsBindingSource
            // 
            this.scoutsBindingSource.DataMember = "Scouts";
            this.scoutsBindingSource.DataSource = this.extraDS;
            // 
            // extraDS
            // 
            this.extraDS.DataSetName = "ExtraDS";
            this.extraDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportAnalysis
            // 
            this.ReportAnalysis.DataSetName = "ReportAnalysis";
            this.ReportAnalysis.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // playerData1
            // 
            this.playerData1.BackColor = System.Drawing.SystemColors.Control;
            this.playerData1.ForeColor = System.Drawing.Color.Black;
            this.playerData1.Location = new System.Drawing.Point(9, 16);
            this.playerData1.Name = "playerData1";
            this.playerData1.Size = new System.Drawing.Size(230, 92);
            this.playerData1.TabIndex = 1;
            // 
            // PlayerAge
            // 
            this.PlayerAge.DataPropertyName = "Age";
            this.PlayerAge.HeaderText = "Age";
            this.PlayerAge.Name = "PlayerAge";
            this.PlayerAge.ReadOnly = true;
            this.PlayerAge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PlayerAge.When = new System.DateTime(2015, 4, 19, 18, 31, 41, 824);
            this.PlayerAge.Width = 40;
            // 
            // absWeekDataGridViewTextBoxColumn
            // 
            this.absWeekDataGridViewTextBoxColumn.DataPropertyName = "absWeek";
            this.absWeekDataGridViewTextBoxColumn.HeaderText = "Week";
            this.absWeekDataGridViewTextBoxColumn.Name = "absWeekDataGridViewTextBoxColumn";
            this.absWeekDataGridViewTextBoxColumn.ReadOnly = true;
            this.absWeekDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.absWeekDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.absWeekDataGridViewTextBoxColumn.Width = 40;
            // 
            // forDataGridViewTextBoxColumn
            // 
            this.forDataGridViewTextBoxColumn.DataPropertyName = "For";
            this.forDataGridViewTextBoxColumn.HeaderText = "Str";
            this.forDataGridViewTextBoxColumn.Name = "forDataGridViewTextBoxColumn";
            this.forDataGridViewTextBoxColumn.ReadOnly = true;
            this.forDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.forDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.forDataGridViewTextBoxColumn.Width = 24;
            // 
            // resDataGridViewTextBoxColumn
            // 
            this.resDataGridViewTextBoxColumn.DataPropertyName = "Res";
            this.resDataGridViewTextBoxColumn.HeaderText = "Res";
            this.resDataGridViewTextBoxColumn.Name = "resDataGridViewTextBoxColumn";
            this.resDataGridViewTextBoxColumn.ReadOnly = true;
            this.resDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.resDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.resDataGridViewTextBoxColumn.Width = 24;
            // 
            // velDataGridViewTextBoxColumn
            // 
            this.velDataGridViewTextBoxColumn.DataPropertyName = "Vel";
            this.velDataGridViewTextBoxColumn.HeaderText = "Pac";
            this.velDataGridViewTextBoxColumn.Name = "velDataGridViewTextBoxColumn";
            this.velDataGridViewTextBoxColumn.ReadOnly = true;
            this.velDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.velDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.velDataGridViewTextBoxColumn.Width = 24;
            // 
            // marDataGridViewTextBoxColumn
            // 
            this.marDataGridViewTextBoxColumn.DataPropertyName = "Mar";
            this.marDataGridViewTextBoxColumn.HeaderText = "Mar";
            this.marDataGridViewTextBoxColumn.Name = "marDataGridViewTextBoxColumn";
            this.marDataGridViewTextBoxColumn.ReadOnly = true;
            this.marDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.marDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.marDataGridViewTextBoxColumn.Width = 24;
            // 
            // conDataGridViewTextBoxColumn
            // 
            this.conDataGridViewTextBoxColumn.DataPropertyName = "Con";
            this.conDataGridViewTextBoxColumn.HeaderText = "Tak";
            this.conDataGridViewTextBoxColumn.Name = "conDataGridViewTextBoxColumn";
            this.conDataGridViewTextBoxColumn.ReadOnly = true;
            this.conDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.conDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.conDataGridViewTextBoxColumn.Width = 24;
            // 
            // worDataGridViewTextBoxColumn
            // 
            this.worDataGridViewTextBoxColumn.DataPropertyName = "Wor";
            this.worDataGridViewTextBoxColumn.HeaderText = "Wor";
            this.worDataGridViewTextBoxColumn.Name = "worDataGridViewTextBoxColumn";
            this.worDataGridViewTextBoxColumn.ReadOnly = true;
            this.worDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.worDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.worDataGridViewTextBoxColumn.Width = 24;
            // 
            // posDataGridViewTextBoxColumn
            // 
            this.posDataGridViewTextBoxColumn.DataPropertyName = "Pos";
            this.posDataGridViewTextBoxColumn.HeaderText = "Pos";
            this.posDataGridViewTextBoxColumn.Name = "posDataGridViewTextBoxColumn";
            this.posDataGridViewTextBoxColumn.ReadOnly = true;
            this.posDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.posDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.posDataGridViewTextBoxColumn.Width = 24;
            // 
            // pasDataGridViewTextBoxColumn
            // 
            this.pasDataGridViewTextBoxColumn.DataPropertyName = "Pas";
            this.pasDataGridViewTextBoxColumn.HeaderText = "Pas";
            this.pasDataGridViewTextBoxColumn.Name = "pasDataGridViewTextBoxColumn";
            this.pasDataGridViewTextBoxColumn.ReadOnly = true;
            this.pasDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pasDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.pasDataGridViewTextBoxColumn.Width = 24;
            // 
            // croDataGridViewTextBoxColumn
            // 
            this.croDataGridViewTextBoxColumn.DataPropertyName = "Cro";
            this.croDataGridViewTextBoxColumn.HeaderText = "Cro";
            this.croDataGridViewTextBoxColumn.Name = "croDataGridViewTextBoxColumn";
            this.croDataGridViewTextBoxColumn.ReadOnly = true;
            this.croDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.croDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.croDataGridViewTextBoxColumn.Width = 24;
            // 
            // tecDataGridViewTextBoxColumn
            // 
            this.tecDataGridViewTextBoxColumn.DataPropertyName = "Tec";
            this.tecDataGridViewTextBoxColumn.HeaderText = "Tec";
            this.tecDataGridViewTextBoxColumn.Name = "tecDataGridViewTextBoxColumn";
            this.tecDataGridViewTextBoxColumn.ReadOnly = true;
            this.tecDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tecDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tecDataGridViewTextBoxColumn.Width = 24;
            // 
            // tesDataGridViewTextBoxColumn
            // 
            this.tesDataGridViewTextBoxColumn.DataPropertyName = "Tes";
            this.tesDataGridViewTextBoxColumn.HeaderText = "Hea";
            this.tesDataGridViewTextBoxColumn.Name = "tesDataGridViewTextBoxColumn";
            this.tesDataGridViewTextBoxColumn.ReadOnly = true;
            this.tesDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tesDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tesDataGridViewTextBoxColumn.Width = 24;
            // 
            // finDataGridViewTextBoxColumn
            // 
            this.finDataGridViewTextBoxColumn.DataPropertyName = "Fin";
            this.finDataGridViewTextBoxColumn.HeaderText = "Fin";
            this.finDataGridViewTextBoxColumn.Name = "finDataGridViewTextBoxColumn";
            this.finDataGridViewTextBoxColumn.ReadOnly = true;
            this.finDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.finDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.finDataGridViewTextBoxColumn.Width = 24;
            // 
            // tirDataGridViewTextBoxColumn
            // 
            this.tirDataGridViewTextBoxColumn.DataPropertyName = "Tir";
            this.tirDataGridViewTextBoxColumn.HeaderText = "Lon";
            this.tirDataGridViewTextBoxColumn.Name = "tirDataGridViewTextBoxColumn";
            this.tirDataGridViewTextBoxColumn.ReadOnly = true;
            this.tirDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tirDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tirDataGridViewTextBoxColumn.Width = 23;
            // 
            // calDataGridViewTextBoxColumn
            // 
            this.calDataGridViewTextBoxColumn.DataPropertyName = "Cal";
            this.calDataGridViewTextBoxColumn.HeaderText = "Set";
            this.calDataGridViewTextBoxColumn.Name = "calDataGridViewTextBoxColumn";
            this.calDataGridViewTextBoxColumn.ReadOnly = true;
            this.calDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.calDataGridViewTextBoxColumn.Width = 23;
            // 
            // tIDataGridViewTextBoxColumn
            // 
            this.tIDataGridViewTextBoxColumn.DataPropertyName = "TI";
            this.tIDataGridViewTextBoxColumn.HeaderText = "TI";
            this.tIDataGridViewTextBoxColumn.Name = "tIDataGridViewTextBoxColumn";
            this.tIDataGridViewTextBoxColumn.ReadOnly = true;
            this.tIDataGridViewTextBoxColumn.Width = 30;
            // 
            // trainerNameDataGridViewTextBoxColumn
            // 
            this.trainerNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.trainerNameDataGridViewTextBoxColumn.DataPropertyName = "TrainerName";
            this.trainerNameDataGridViewTextBoxColumn.HeaderText = "Training";
            this.trainerNameDataGridViewTextBoxColumn.Name = "trainerNameDataGridViewTextBoxColumn";
            this.trainerNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.trainerNameDataGridViewTextBoxColumn.Width = 62;
            // 
            // programDataGridViewTextBoxColumn
            // 
            this.programDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.programDataGridViewTextBoxColumn.DataPropertyName = "Program";
            this.programDataGridViewTextBoxColumn.HeaderText = "Training Program";
            this.programDataGridViewTextBoxColumn.Name = "programDataGridViewTextBoxColumn";
            this.programDataGridViewTextBoxColumn.ReadOnly = true;
            this.programDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.programDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.programDataGridViewTextBoxColumn.Width = 91;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(953, 577);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblWage);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblASI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPrefPos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PlayerForm";
            this.Text = "Player History";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerForm_FormClosing);
            this.Load += new System.EventHandler(this.PlayerForm_Load);
            this.SizeChanged += new System.EventHandler(this.PlayerForm_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.tabSkills.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.tabPlayerScouting.ResumeLayout(false);
            this.tabPlayerScouting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgScouts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoutsNReviews)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgReviews)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerTraining)).EndInit();
            this.tabPlayerBrowser.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tsBrowsePlayers.ResumeLayout(false);
            this.tsBrowsePlayers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scoutsDataTableBindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performancesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameTableDS)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scoutsDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reviewDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bestPlayersDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bestPlayersDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reviewDataTableBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoutsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extraDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportAnalysis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private PlayerData playerData1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrefPos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblASI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSkills;
        private ZedGraph.ZedGraphControl graphSkills;
        private System.Windows.Forms.TabPage tabPage2;
        private ZedGraph.ZedGraphControl graphInjuries;
        private System.Windows.Forms.TabPage tabPage3;
        private ZedGraph.ZedGraphControl graphSpecs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ZedGraph.ZedGraphControl graphASI;
        private ZedGraph.ZedGraphControl graphTI;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox chkShowTGI;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Label lblRoutine;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TabPage tabPage4;
        private ZedGraph.ZedGraphControl graphPerf;
        private System.Windows.Forms.ToolStripButton tsbComputeGrowth;
        private System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.BindingSource scoutsBindingSource;
        public ExtraDS extraDS;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnGetVotenSkillAuto;
        public ReportAnalysis ReportAnalysis;
        private PlayerTraining playerTraining;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource trainingBindingSource;
        private DataGridViewCustomColumns.TMR_AgeColumn tmR_AgeColumn1;
        private DataGridViewCustomColumns.TMR_DateColumn tmR_DateColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel lblSeason;
        private System.Windows.Forms.ToolStripComboBox cmbSeason;
        private System.Windows.Forms.ToolStripButton chkNormalized;
        private System.Windows.Forms.ToolStripButton chkShowPosition;
        private ZedGraph.ZedGraphControl graphTrainingPsychology;
        private ZedGraph.ZedGraphControl graphTrainingTechnics;
        private ZedGraph.ZedGraphControl graphTrainingTactics;
        private ZedGraph.ZedGraphControl graphTrainingPhisics;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem whatToDoHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem getPotentialForThisPlayerToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPlayerBrowser;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStrip tsBrowsePlayers;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripButton tsbLoadPlayerPage;
        private System.Windows.Forms.ToolStripDropDownButton tsbNavigationType;
        private System.Windows.Forms.ToolStripMenuItem navigateProfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navigateReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripProgressBar tsbProgressBar;
        private System.Windows.Forms.ToolStripLabel tsbProgressText;
        private System.Windows.Forms.ToolStripButton tsbImport;
        private System.Windows.Forms.ToolStripDropDownButton tsbPlayers;
        private System.Windows.Forms.ToolStripMenuItem dDefendersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dMDefenderMidfieldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mMidfieldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oMOffenderMidfieldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fForwardsToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPlayerScouting;
        private System.Windows.Forms.DataGridView dgReviews;
        private System.Windows.Forms.BindingSource reviewDataTableBindingSource1;
        private System.Windows.Forms.BindingSource scoutsDataTableBindingSource;
        private System.Windows.Forms.BindingSource reviewDataTableBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgScouts;
        private System.Windows.Forms.BindingSource scoutsDataTableBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn developmentDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn seniorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn youthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn physicalDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tacticalDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn technicalDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn psychologyDataGridViewTextBoxColumn;
        private ScoutsNReviews scoutsNReviews;
        private System.Windows.Forms.DataGridViewTextBoxColumn explosionDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ReportColumn physicalDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ReportColumn tacticalDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ReportColumn technicalDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ReportColumn leadershipDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ReportColumn professionalityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scoutIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ReportColumn Vote;
        private DataGridViewCustomColumns.TMR_ReportColumn bloomingDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ReportColumn BloomingStatus;
        private DataGridViewCustomColumns.TMR_ReportColumn Development;
        private DataGridViewCustomColumns.TMR_ReportColumn Speciality;
        private DataGridViewCustomColumns.TMR_ReportColumn Physics;
        private DataGridViewCustomColumns.TMR_ReportColumn Tactics;
        private DataGridViewCustomColumns.TMR_ReportColumn Technics;
        private DataGridViewCustomColumns.TMR_ReportColumn Charisma;
        private DataGridViewCustomColumns.TMR_ReportColumn Professionalism;
        private DataGridViewCustomColumns.TMR_ReportColumn aggressivityDataGridViewTextBoxColumn;
        private TagsBar tagsBarPro;
        private TagsBar tagsBarAgg;
        private TagsBar tagsBarLea;
        private TagsBar tagsBarTec;
        private TagsBar tagsBarTac;
        private TagsBar tagsBarPhy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private GameTable gameTableDS;
        private System.Windows.Forms.BindingSource performancesBindingSource;
        private BestPlayersDS bestPlayersDS;
        private System.Windows.Forms.BindingSource bestPlayersDSBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn seasonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratDevDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblBloomAge;
        private System.Windows.Forms.Label label9;
        private DataGridViewCustomColumns.TMR_AgeColumn PlayerAge;
        private DataGridViewCustomColumns.TMR_DateColumn absWeekDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn forDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn resDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn velDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn marDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn conDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn worDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn posDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn pasDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn croDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn tecDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn tesDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn finDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn tirDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn calDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainerNameDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_TrainSkillColumn programDataGridViewTextBoxColumn;
    }
}