using Common;
using NTR_Controls;

namespace TMRecorder
{
    partial class PlayerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlPlayerHistory = new System.Windows.Forms.TabControl();
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
            this.tabPageTrainingAndPotential = new System.Windows.Forms.TabPage();
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
            this.dgTraining = new NTR_Controls.AeroDataGrid();
            this.trainingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playerTraining = new TMRecorder.PlayerTraining();
            this.tabPlayerBrowser = new System.Windows.Forms.TabPage();
            this.webBrowser = new NTR_WebBrowser.NTR_Browser();
            this.scoutsDataTableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.scoutsDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reviewDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bestPlayersDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reviewDataTableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.scoutsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.extraDS = new Common.ExtraDS();
            this.ReportAnalysis = new Common.ReportAnalysis();
            this.tmR_ReportColumn2 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn3 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn4 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn5 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn6 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn7 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn8 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn9 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn10 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn11 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_AgeColumn1 = new DataGridViewCustomColumns.TMR_AgeColumn(this.components);
            this.tmR_DateColumn1 = new DataGridViewCustomColumns.TMR_DateColumn(this.components);
            this.tmR_ArrowColumn1 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn2 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn3 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn4 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn5 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn6 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn7 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn8 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn9 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn10 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn11 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn12 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn13 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn14 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_TrainSkillColumn1 = new DataGridViewCustomColumns.TMR_TrainSkillColumn(this.components);
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
            this.tmR_ReportColumn12 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn13 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn14 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn15 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn16 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn17 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn18 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn19 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn20 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn21 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_ReportColumn22 = new DataGridViewCustomColumns.TMR_ReportColumn(this.components);
            this.tmR_AgeColumn2 = new DataGridViewCustomColumns.TMR_AgeColumn(this.components);
            this.tmR_DateColumn2 = new DataGridViewCustomColumns.TMR_DateColumn(this.components);
            this.tmR_ArrowColumn15 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn16 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn17 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn18 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn19 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn20 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn21 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn22 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn23 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn24 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn25 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn26 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn27 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tmR_ArrowColumn28 = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmR_TrainSkillColumn2 = new DataGridViewCustomColumns.TMR_TrainSkillColumn(this.components);
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerData = new NTR_Common.NTR_PlayerData();
            this.teamDS = new NTR_Common.TeamDS();
            this.gkGoalkeepersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.lonDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.setDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_ArrowColumn(this.components);
            this.tIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainingTypesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programDataGridViewTextBoxColumn = new DataGridViewCustomColumns.TMR_TrainSkillColumn(this.components);
            this.tabControlPlayerHistory.SuspendLayout();
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
            this.tabPageTrainingAndPotential.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgTraining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerTraining)).BeginInit();
            this.tabPlayerBrowser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scoutsDataTableBindingSource1)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.bestPlayersDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reviewDataTableBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoutsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extraDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamDS)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlPlayerHistory
            // 
            this.tabControlPlayerHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlPlayerHistory.Controls.Add(this.tabSkills);
            this.tabControlPlayerHistory.Controls.Add(this.tabPage1);
            this.tabControlPlayerHistory.Controls.Add(this.tabPage2);
            this.tabControlPlayerHistory.Controls.Add(this.tabPage3);
            this.tabControlPlayerHistory.Controls.Add(this.tabPage4);
            this.tabControlPlayerHistory.Controls.Add(this.tabPageTrainingAndPotential);
            this.tabControlPlayerHistory.Controls.Add(this.tabPlayerScouting);
            this.tabControlPlayerHistory.Controls.Add(this.tabPage6);
            this.tabControlPlayerHistory.Controls.Add(this.tabPlayerBrowser);
            this.tabControlPlayerHistory.Location = new System.Drawing.Point(257, 28);
            this.tabControlPlayerHistory.Name = "tabControlPlayerHistory";
            this.tabControlPlayerHistory.SelectedIndex = 0;
            this.tabControlPlayerHistory.Size = new System.Drawing.Size(711, 548);
            this.tabControlPlayerHistory.TabIndex = 3;
            this.tabControlPlayerHistory.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabSkills
            // 
            this.tabSkills.Controls.Add(this.graphSkills);
            this.tabSkills.Location = new System.Drawing.Point(4, 22);
            this.tabSkills.Name = "tabSkills";
            this.tabSkills.Padding = new System.Windows.Forms.Padding(3);
            this.tabSkills.Size = new System.Drawing.Size(703, 522);
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
            this.graphSkills.Size = new System.Drawing.Size(697, 516);
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
            this.tabPage1.Size = new System.Drawing.Size(703, 522);
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
            this.splitContainer2.Size = new System.Drawing.Size(697, 516);
            this.splitContainer2.SplitterDistance = 246;
            this.splitContainer2.TabIndex = 2;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(588, 1);
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
            this.graphASI.Size = new System.Drawing.Size(697, 246);
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
            this.chkShowTGI.Location = new System.Drawing.Point(625, 6);
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
            this.graphTI.Size = new System.Drawing.Size(697, 266);
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
            this.tabPage2.Size = new System.Drawing.Size(703, 522);
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
            this.graphInjuries.Size = new System.Drawing.Size(697, 516);
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
            this.tabPage3.Size = new System.Drawing.Size(703, 522);
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
            this.graphSpecs.Size = new System.Drawing.Size(697, 516);
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
            this.tabPage4.Size = new System.Drawing.Size(703, 522);
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
            this.toolStrip2.Size = new System.Drawing.Size(697, 25);
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
            this.cmbSeason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.graphPerf.Size = new System.Drawing.Size(697, 485);
            this.graphPerf.TabIndex = 2;
            this.graphPerf.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphPerf.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphPerf.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphPerf.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphPerf.ZoomStepFraction = 0.1D;
            // 
            // tabPageTrainingAndPotential
            // 
            this.tabPageTrainingAndPotential.Controls.Add(this.toolStrip3);
            this.tabPageTrainingAndPotential.Controls.Add(this.splitContainer3);
            this.tabPageTrainingAndPotential.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageTrainingAndPotential.Location = new System.Drawing.Point(4, 22);
            this.tabPageTrainingAndPotential.Name = "tabPageTrainingAndPotential";
            this.tabPageTrainingAndPotential.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTrainingAndPotential.Size = new System.Drawing.Size(703, 522);
            this.tabPageTrainingAndPotential.TabIndex = 5;
            this.tabPageTrainingAndPotential.Text = "Training & Potential";
            this.tabPageTrainingAndPotential.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(697, 25);
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
            this.splitContainer3.Size = new System.Drawing.Size(700, 492);
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
            this.splitContainer4.Size = new System.Drawing.Size(700, 246);
            this.splitContainer4.SplitterDistance = 347;
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
            this.graphTrainingPsychology.Size = new System.Drawing.Size(347, 246);
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
            this.graphTrainingPhisics.Size = new System.Drawing.Size(351, 246);
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
            this.splitContainer5.Size = new System.Drawing.Size(700, 244);
            this.splitContainer5.SplitterDistance = 347;
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
            this.graphTrainingTactics.Size = new System.Drawing.Size(347, 244);
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
            this.graphTrainingTechnics.Size = new System.Drawing.Size(351, 244);
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
            this.tabPlayerScouting.Size = new System.Drawing.Size(703, 522);
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.NullValue = "-";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgScouts.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgScouts.Location = new System.Drawing.Point(6, 29);
            this.dgScouts.Name = "dgScouts";
            this.dgScouts.RowHeadersWidth = 20;
            this.dgScouts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgScouts.Size = new System.Drawing.Size(694, 138);
            this.dgScouts.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 59;
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
            this.physicalDataGridViewTextBoxColumn1.Width = 70;
            // 
            // tacticalDataGridViewTextBoxColumn1
            // 
            this.tacticalDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tacticalDataGridViewTextBoxColumn1.DataPropertyName = "Tactical";
            this.tacticalDataGridViewTextBoxColumn1.HeaderText = "Tactical";
            this.tacticalDataGridViewTextBoxColumn1.Name = "tacticalDataGridViewTextBoxColumn1";
            this.tacticalDataGridViewTextBoxColumn1.Width = 68;
            // 
            // technicalDataGridViewTextBoxColumn1
            // 
            this.technicalDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.technicalDataGridViewTextBoxColumn1.DataPropertyName = "Technical";
            this.technicalDataGridViewTextBoxColumn1.HeaderText = "Technical";
            this.technicalDataGridViewTextBoxColumn1.Name = "technicalDataGridViewTextBoxColumn1";
            this.technicalDataGridViewTextBoxColumn1.Width = 76;
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
            this.scoutsNReviews.isDirty = false;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.NullValue = "-";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgReviews.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgReviews.Location = new System.Drawing.Point(6, 191);
            this.dgReviews.Name = "dgReviews";
            this.dgReviews.RowHeadersWidth = 20;
            this.dgReviews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgReviews.Size = new System.Drawing.Size(694, 175);
            this.dgReviews.TabIndex = 0;
            // 
            // scoutIDDataGridViewTextBoxColumn
            // 
            this.scoutIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.scoutIDDataGridViewTextBoxColumn.DataPropertyName = "ScoutName";
            this.scoutIDDataGridViewTextBoxColumn.HeaderText = "Scout";
            this.scoutIDDataGridViewTextBoxColumn.Name = "scoutIDDataGridViewTextBoxColumn";
            this.scoutIDDataGridViewTextBoxColumn.Width = 59;
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
            this.bloomingDataGridViewTextBoxColumn.Width = 46;
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
            this.BloomingStatus.Width = 64;
            // 
            // Development
            // 
            this.Development.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Development.DataPropertyName = "Development";
            this.Development.FPn = 0;
            this.Development.HeaderText = "Dev";
            this.Development.Name = "Development";
            this.Development.Width = 32;
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
            this.Speciality.Width = 50;
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
            this.Tactics.Width = 30;
            // 
            // Technics
            // 
            this.Technics.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Technics.DataPropertyName = "Technics";
            this.Technics.FPn = 0;
            this.Technics.HeaderText = "Tec";
            this.Technics.Name = "Technics";
            this.Technics.Width = 30;
            // 
            // Charisma
            // 
            this.Charisma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Charisma.DataPropertyName = "Charisma";
            this.Charisma.FPn = 0;
            this.Charisma.HeaderText = "Lea";
            this.Charisma.Name = "Charisma";
            this.Charisma.Width = 30;
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
            this.tabPage6.Controls.Add(this.dgTraining);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(703, 522);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "Player Training";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dgTraining
            // 
            this.dgTraining.AllowUserToAddRows = false;
            this.dgTraining.AllowUserToDeleteRows = false;
            this.dgTraining.AllowUserToResizeColumns = false;
            this.dgTraining.AutoGenerateColumns = false;
            this.dgTraining.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTraining.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.lonDataGridViewTextBoxColumn,
            this.setDataGridViewTextBoxColumn,
            this.tIDataGridViewTextBoxColumn,
            this.trainingTypesColumn,
            this.programDataGridViewTextBoxColumn});
            this.dgTraining.DataCollection = null;
            this.dgTraining.DataSource = this.trainingBindingSource;
            this.dgTraining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTraining.Location = new System.Drawing.Point(3, 3);
            this.dgTraining.Margin = new System.Windows.Forms.Padding(2);
            this.dgTraining.MultiSelect = false;
            this.dgTraining.Name = "dgTraining";
            this.dgTraining.ReadOnly = true;
            this.dgTraining.RowHeadersWidth = 20;
            this.dgTraining.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTraining.Size = new System.Drawing.Size(697, 516);
            this.dgTraining.TabIndex = 0;
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
            this.tabPlayerBrowser.Controls.Add(this.webBrowser);
            this.tabPlayerBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabPlayerBrowser.Name = "tabPlayerBrowser";
            this.tabPlayerBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlayerBrowser.Size = new System.Drawing.Size(703, 522);
            this.tabPlayerBrowser.TabIndex = 7;
            this.tabPlayerBrowser.Text = "Trophy Browser - Player";
            this.tabPlayerBrowser.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.DefaultDirectory = "";
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(3, 3);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.NavigationAddress = "";
            this.webBrowser.NavigationMode = NTR_WebBrowser.NTR_Browser.eNavigationMode.Main;
            this.webBrowser.SelectedReportParser = null;
            this.webBrowser.Size = new System.Drawing.Size(697, 516);
            this.webBrowser.StartnavigationAddress = "";
            this.webBrowser.TabIndex = 1;
            this.webBrowser.ImportedContent += new NTR_WebBrowser.ImportedContentHandler(this.webBrowser_ImportedContent);
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
            this.txtNotes.Size = new System.Drawing.Size(239, 51);
            this.txtNotes.TabIndex = 6;
            this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox2.Location = new System.Drawing.Point(6, 342);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 225);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player Info";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
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
            this.splitContainer1.Size = new System.Drawing.Size(239, 205);
            this.splitContainer1.SplitterDistance = 131;
            this.splitContainer1.TabIndex = 10;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
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
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 10;
            this.dataGridView2.RowTemplate.Height = 19;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(239, 131);
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
            this.toolStrip1.Size = new System.Drawing.Size(968, 25);
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
            this.toolStripButton1.AutoToolTip = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(88, 22);
            this.toolStripButton1.Text = "Prev. Player";
            this.toolStripButton1.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoToolTip = false;
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
            this.gkGoalkeepersToolStripMenuItem,
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
            // scoutsDataTableBindingSource
            // 
            this.scoutsDataTableBindingSource.DataSource = typeof(Common.ScoutsNReviews.ScoutsDataTable);
            // 
            // reviewDataTableBindingSource
            // 
            this.reviewDataTableBindingSource.DataSource = typeof(Common.ScoutsNReviews.ReviewDataTable);
            this.reviewDataTableBindingSource.CurrentChanged += new System.EventHandler(this.reviewDataTableBindingSource_CurrentChanged);
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
            // tmR_ReportColumn2
            // 
            this.tmR_ReportColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn2.DataPropertyName = "Blooming";
            this.tmR_ReportColumn2.FPn = 0;
            this.tmR_ReportColumn2.HeaderText = "Blo";
            this.tmR_ReportColumn2.Name = "tmR_ReportColumn2";
            this.tmR_ReportColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ReportColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ReportColumn2.ToolTipText = "Blooming";
            // 
            // tmR_ReportColumn3
            // 
            this.tmR_ReportColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn3.DataPropertyName = "Blooming_Status";
            this.tmR_ReportColumn3.FPn = 0;
            this.tmR_ReportColumn3.HeaderText = "Bl.Stat";
            this.tmR_ReportColumn3.Name = "tmR_ReportColumn3";
            this.tmR_ReportColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ReportColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ReportColumn3.ToolTipText = "Blooming Status";
            // 
            // tmR_ReportColumn4
            // 
            this.tmR_ReportColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn4.DataPropertyName = "Development";
            this.tmR_ReportColumn4.FPn = 0;
            this.tmR_ReportColumn4.HeaderText = "Dev";
            this.tmR_ReportColumn4.Name = "tmR_ReportColumn4";
            // 
            // tmR_ReportColumn5
            // 
            this.tmR_ReportColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn5.DataPropertyName = "Speciality";
            this.tmR_ReportColumn5.FPn = 0;
            this.tmR_ReportColumn5.HeaderText = "Spe";
            this.tmR_ReportColumn5.Name = "tmR_ReportColumn5";
            this.tmR_ReportColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ReportColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ReportColumn5.ToolTipText = "Speciality";
            // 
            // tmR_ReportColumn6
            // 
            this.tmR_ReportColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn6.DataPropertyName = "Physique";
            this.tmR_ReportColumn6.FPn = 0;
            this.tmR_ReportColumn6.HeaderText = "Phy";
            this.tmR_ReportColumn6.Name = "tmR_ReportColumn6";
            // 
            // tmR_ReportColumn7
            // 
            this.tmR_ReportColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn7.DataPropertyName = "Tactics";
            this.tmR_ReportColumn7.FPn = 0;
            this.tmR_ReportColumn7.HeaderText = "Tac";
            this.tmR_ReportColumn7.Name = "tmR_ReportColumn7";
            // 
            // tmR_ReportColumn8
            // 
            this.tmR_ReportColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn8.DataPropertyName = "Technics";
            this.tmR_ReportColumn8.FPn = 0;
            this.tmR_ReportColumn8.HeaderText = "Tec";
            this.tmR_ReportColumn8.Name = "tmR_ReportColumn8";
            // 
            // tmR_ReportColumn9
            // 
            this.tmR_ReportColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn9.DataPropertyName = "Charisma";
            this.tmR_ReportColumn9.FPn = 0;
            this.tmR_ReportColumn9.HeaderText = "Lea";
            this.tmR_ReportColumn9.Name = "tmR_ReportColumn9";
            // 
            // tmR_ReportColumn10
            // 
            this.tmR_ReportColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn10.DataPropertyName = "Professionalism";
            this.tmR_ReportColumn10.FPn = 0;
            this.tmR_ReportColumn10.HeaderText = "Pro";
            this.tmR_ReportColumn10.Name = "tmR_ReportColumn10";
            // 
            // tmR_ReportColumn11
            // 
            this.tmR_ReportColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn11.DataPropertyName = "Aggressivity";
            this.tmR_ReportColumn11.FPn = 0;
            this.tmR_ReportColumn11.HeaderText = "Agg";
            this.tmR_ReportColumn11.Name = "tmR_ReportColumn11";
            this.tmR_ReportColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ReportColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ReportColumn11.ToolTipText = "Aggressivity";
            // 
            // tmR_AgeColumn1
            // 
            this.tmR_AgeColumn1.DataPropertyName = "Age";
            this.tmR_AgeColumn1.HeaderText = "Age";
            this.tmR_AgeColumn1.Name = "tmR_AgeColumn1";
            this.tmR_AgeColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_AgeColumn1.When = new System.DateTime(2015, 4, 19, 18, 31, 41, 824);
            this.tmR_AgeColumn1.Width = 40;
            // 
            // tmR_DateColumn1
            // 
            this.tmR_DateColumn1.DataPropertyName = "absWeek";
            this.tmR_DateColumn1.HeaderText = "Week";
            this.tmR_DateColumn1.Name = "tmR_DateColumn1";
            this.tmR_DateColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_DateColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_DateColumn1.Width = 40;
            // 
            // tmR_ArrowColumn1
            // 
            this.tmR_ArrowColumn1.DataPropertyName = "For";
            this.tmR_ArrowColumn1.HeaderText = "Str";
            this.tmR_ArrowColumn1.Name = "tmR_ArrowColumn1";
            this.tmR_ArrowColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn1.Width = 24;
            // 
            // tmR_ArrowColumn2
            // 
            this.tmR_ArrowColumn2.DataPropertyName = "Res";
            this.tmR_ArrowColumn2.HeaderText = "Res";
            this.tmR_ArrowColumn2.Name = "tmR_ArrowColumn2";
            this.tmR_ArrowColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn2.Width = 24;
            // 
            // tmR_ArrowColumn3
            // 
            this.tmR_ArrowColumn3.DataPropertyName = "Vel";
            this.tmR_ArrowColumn3.HeaderText = "Pac";
            this.tmR_ArrowColumn3.Name = "tmR_ArrowColumn3";
            this.tmR_ArrowColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn3.Width = 24;
            // 
            // tmR_ArrowColumn4
            // 
            this.tmR_ArrowColumn4.DataPropertyName = "Mar";
            this.tmR_ArrowColumn4.HeaderText = "Mar";
            this.tmR_ArrowColumn4.Name = "tmR_ArrowColumn4";
            this.tmR_ArrowColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn4.Width = 24;
            // 
            // tmR_ArrowColumn5
            // 
            this.tmR_ArrowColumn5.DataPropertyName = "Con";
            this.tmR_ArrowColumn5.HeaderText = "Tak";
            this.tmR_ArrowColumn5.Name = "tmR_ArrowColumn5";
            this.tmR_ArrowColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn5.Width = 24;
            // 
            // tmR_ArrowColumn6
            // 
            this.tmR_ArrowColumn6.DataPropertyName = "Wor";
            this.tmR_ArrowColumn6.HeaderText = "Wor";
            this.tmR_ArrowColumn6.Name = "tmR_ArrowColumn6";
            this.tmR_ArrowColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn6.Width = 24;
            // 
            // tmR_ArrowColumn7
            // 
            this.tmR_ArrowColumn7.DataPropertyName = "Pos";
            this.tmR_ArrowColumn7.HeaderText = "Pos";
            this.tmR_ArrowColumn7.Name = "tmR_ArrowColumn7";
            this.tmR_ArrowColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn7.Width = 24;
            // 
            // tmR_ArrowColumn8
            // 
            this.tmR_ArrowColumn8.DataPropertyName = "Pas";
            this.tmR_ArrowColumn8.HeaderText = "Pas";
            this.tmR_ArrowColumn8.Name = "tmR_ArrowColumn8";
            this.tmR_ArrowColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn8.Width = 24;
            // 
            // tmR_ArrowColumn9
            // 
            this.tmR_ArrowColumn9.DataPropertyName = "Cro";
            this.tmR_ArrowColumn9.HeaderText = "Cro";
            this.tmR_ArrowColumn9.Name = "tmR_ArrowColumn9";
            this.tmR_ArrowColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn9.Width = 24;
            // 
            // tmR_ArrowColumn10
            // 
            this.tmR_ArrowColumn10.DataPropertyName = "Tec";
            this.tmR_ArrowColumn10.HeaderText = "Tec";
            this.tmR_ArrowColumn10.Name = "tmR_ArrowColumn10";
            this.tmR_ArrowColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn10.Width = 24;
            // 
            // tmR_ArrowColumn11
            // 
            this.tmR_ArrowColumn11.DataPropertyName = "Tes";
            this.tmR_ArrowColumn11.HeaderText = "Hea";
            this.tmR_ArrowColumn11.Name = "tmR_ArrowColumn11";
            this.tmR_ArrowColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn11.Width = 24;
            // 
            // tmR_ArrowColumn12
            // 
            this.tmR_ArrowColumn12.DataPropertyName = "Fin";
            this.tmR_ArrowColumn12.HeaderText = "Fin";
            this.tmR_ArrowColumn12.Name = "tmR_ArrowColumn12";
            this.tmR_ArrowColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn12.Width = 24;
            // 
            // tmR_ArrowColumn13
            // 
            this.tmR_ArrowColumn13.DataPropertyName = "Tir";
            this.tmR_ArrowColumn13.HeaderText = "Lon";
            this.tmR_ArrowColumn13.Name = "tmR_ArrowColumn13";
            this.tmR_ArrowColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn13.Width = 23;
            // 
            // tmR_ArrowColumn14
            // 
            this.tmR_ArrowColumn14.DataPropertyName = "Cal";
            this.tmR_ArrowColumn14.HeaderText = "Set";
            this.tmR_ArrowColumn14.Name = "tmR_ArrowColumn14";
            this.tmR_ArrowColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn14.Width = 23;
            // 
            // tmR_TrainSkillColumn1
            // 
            this.tmR_TrainSkillColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_TrainSkillColumn1.DataPropertyName = "Program";
            this.tmR_TrainSkillColumn1.HeaderText = "Training Program";
            this.tmR_TrainSkillColumn1.Name = "tmR_TrainSkillColumn1";
            this.tmR_TrainSkillColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_TrainSkillColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "For";
            this.dataGridViewTextBoxColumn1.HeaderText = "Str";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Res";
            this.dataGridViewTextBoxColumn2.HeaderText = "Res";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Vel";
            this.dataGridViewTextBoxColumn3.HeaderText = "Pac";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Mar";
            this.dataGridViewTextBoxColumn4.HeaderText = "Mar";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Con";
            this.dataGridViewTextBoxColumn5.HeaderText = "Tak";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Wor";
            this.dataGridViewTextBoxColumn6.HeaderText = "Wor";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Pos";
            this.dataGridViewTextBoxColumn7.HeaderText = "Pos";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Pas";
            this.dataGridViewTextBoxColumn8.HeaderText = "Pas";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Cro";
            this.dataGridViewTextBoxColumn9.HeaderText = "Cro";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Tec";
            this.dataGridViewTextBoxColumn10.HeaderText = "Tec";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Tes";
            this.dataGridViewTextBoxColumn11.HeaderText = "Hea";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // tmR_ReportColumn12
            // 
            this.tmR_ReportColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.tmR_ReportColumn12.DataPropertyName = "Vote";
            this.tmR_ReportColumn12.FPn = 0;
            this.tmR_ReportColumn12.HeaderText = "Vote";
            this.tmR_ReportColumn12.MinimumWidth = 30;
            this.tmR_ReportColumn12.Name = "tmR_ReportColumn12";
            this.tmR_ReportColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ReportColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tmR_ReportColumn13
            // 
            this.tmR_ReportColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn13.DataPropertyName = "Blooming";
            this.tmR_ReportColumn13.FPn = 0;
            this.tmR_ReportColumn13.HeaderText = "Blo";
            this.tmR_ReportColumn13.Name = "tmR_ReportColumn13";
            this.tmR_ReportColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ReportColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ReportColumn13.ToolTipText = "Blooming";
            // 
            // tmR_ReportColumn14
            // 
            this.tmR_ReportColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn14.DataPropertyName = "Blooming_Status";
            this.tmR_ReportColumn14.FPn = 0;
            this.tmR_ReportColumn14.HeaderText = "Bl.Stat";
            this.tmR_ReportColumn14.Name = "tmR_ReportColumn14";
            this.tmR_ReportColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ReportColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ReportColumn14.ToolTipText = "Blooming Status";
            // 
            // tmR_ReportColumn15
            // 
            this.tmR_ReportColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn15.DataPropertyName = "Development";
            this.tmR_ReportColumn15.FPn = 0;
            this.tmR_ReportColumn15.HeaderText = "Dev";
            this.tmR_ReportColumn15.Name = "tmR_ReportColumn15";
            // 
            // tmR_ReportColumn16
            // 
            this.tmR_ReportColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn16.DataPropertyName = "Speciality";
            this.tmR_ReportColumn16.FPn = 0;
            this.tmR_ReportColumn16.HeaderText = "Spe";
            this.tmR_ReportColumn16.Name = "tmR_ReportColumn16";
            this.tmR_ReportColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ReportColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ReportColumn16.ToolTipText = "Speciality";
            // 
            // tmR_ReportColumn17
            // 
            this.tmR_ReportColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn17.DataPropertyName = "Physique";
            this.tmR_ReportColumn17.FPn = 0;
            this.tmR_ReportColumn17.HeaderText = "Phy";
            this.tmR_ReportColumn17.Name = "tmR_ReportColumn17";
            // 
            // tmR_ReportColumn18
            // 
            this.tmR_ReportColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn18.DataPropertyName = "Tactics";
            this.tmR_ReportColumn18.FPn = 0;
            this.tmR_ReportColumn18.HeaderText = "Tac";
            this.tmR_ReportColumn18.Name = "tmR_ReportColumn18";
            // 
            // tmR_ReportColumn19
            // 
            this.tmR_ReportColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn19.DataPropertyName = "Technics";
            this.tmR_ReportColumn19.FPn = 0;
            this.tmR_ReportColumn19.HeaderText = "Tec";
            this.tmR_ReportColumn19.Name = "tmR_ReportColumn19";
            // 
            // tmR_ReportColumn20
            // 
            this.tmR_ReportColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn20.DataPropertyName = "Charisma";
            this.tmR_ReportColumn20.FPn = 0;
            this.tmR_ReportColumn20.HeaderText = "Lea";
            this.tmR_ReportColumn20.Name = "tmR_ReportColumn20";
            // 
            // tmR_ReportColumn21
            // 
            this.tmR_ReportColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn21.DataPropertyName = "Professionalism";
            this.tmR_ReportColumn21.FPn = 0;
            this.tmR_ReportColumn21.HeaderText = "Pro";
            this.tmR_ReportColumn21.Name = "tmR_ReportColumn21";
            // 
            // tmR_ReportColumn22
            // 
            this.tmR_ReportColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_ReportColumn22.DataPropertyName = "Aggressivity";
            this.tmR_ReportColumn22.FPn = 0;
            this.tmR_ReportColumn22.HeaderText = "Agg";
            this.tmR_ReportColumn22.Name = "tmR_ReportColumn22";
            this.tmR_ReportColumn22.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ReportColumn22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ReportColumn22.ToolTipText = "Aggressivity";
            // 
            // tmR_AgeColumn2
            // 
            this.tmR_AgeColumn2.DataPropertyName = "Age";
            this.tmR_AgeColumn2.HeaderText = "Age";
            this.tmR_AgeColumn2.Name = "tmR_AgeColumn2";
            this.tmR_AgeColumn2.ReadOnly = true;
            this.tmR_AgeColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_AgeColumn2.When = new System.DateTime(2015, 4, 19, 18, 31, 41, 824);
            this.tmR_AgeColumn2.Width = 40;
            // 
            // tmR_DateColumn2
            // 
            this.tmR_DateColumn2.DataPropertyName = "absWeek";
            this.tmR_DateColumn2.HeaderText = "Week";
            this.tmR_DateColumn2.Name = "tmR_DateColumn2";
            this.tmR_DateColumn2.ReadOnly = true;
            this.tmR_DateColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_DateColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_DateColumn2.Width = 40;
            // 
            // tmR_ArrowColumn15
            // 
            this.tmR_ArrowColumn15.DataPropertyName = "For";
            this.tmR_ArrowColumn15.HeaderText = "Str";
            this.tmR_ArrowColumn15.Name = "tmR_ArrowColumn15";
            this.tmR_ArrowColumn15.ReadOnly = true;
            this.tmR_ArrowColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn15.Width = 24;
            // 
            // tmR_ArrowColumn16
            // 
            this.tmR_ArrowColumn16.DataPropertyName = "Res";
            this.tmR_ArrowColumn16.HeaderText = "Res";
            this.tmR_ArrowColumn16.Name = "tmR_ArrowColumn16";
            this.tmR_ArrowColumn16.ReadOnly = true;
            this.tmR_ArrowColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn16.Width = 24;
            // 
            // tmR_ArrowColumn17
            // 
            this.tmR_ArrowColumn17.DataPropertyName = "Vel";
            this.tmR_ArrowColumn17.HeaderText = "Pac";
            this.tmR_ArrowColumn17.Name = "tmR_ArrowColumn17";
            this.tmR_ArrowColumn17.ReadOnly = true;
            this.tmR_ArrowColumn17.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn17.Width = 24;
            // 
            // tmR_ArrowColumn18
            // 
            this.tmR_ArrowColumn18.DataPropertyName = "Mar";
            this.tmR_ArrowColumn18.HeaderText = "Mar";
            this.tmR_ArrowColumn18.Name = "tmR_ArrowColumn18";
            this.tmR_ArrowColumn18.ReadOnly = true;
            this.tmR_ArrowColumn18.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn18.Width = 24;
            // 
            // tmR_ArrowColumn19
            // 
            this.tmR_ArrowColumn19.DataPropertyName = "Con";
            this.tmR_ArrowColumn19.HeaderText = "Tak";
            this.tmR_ArrowColumn19.Name = "tmR_ArrowColumn19";
            this.tmR_ArrowColumn19.ReadOnly = true;
            this.tmR_ArrowColumn19.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn19.Width = 24;
            // 
            // tmR_ArrowColumn20
            // 
            this.tmR_ArrowColumn20.DataPropertyName = "Wor";
            this.tmR_ArrowColumn20.HeaderText = "Wor";
            this.tmR_ArrowColumn20.Name = "tmR_ArrowColumn20";
            this.tmR_ArrowColumn20.ReadOnly = true;
            this.tmR_ArrowColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn20.Width = 24;
            // 
            // tmR_ArrowColumn21
            // 
            this.tmR_ArrowColumn21.DataPropertyName = "Pos";
            this.tmR_ArrowColumn21.HeaderText = "Pos";
            this.tmR_ArrowColumn21.Name = "tmR_ArrowColumn21";
            this.tmR_ArrowColumn21.ReadOnly = true;
            this.tmR_ArrowColumn21.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn21.Width = 24;
            // 
            // tmR_ArrowColumn22
            // 
            this.tmR_ArrowColumn22.DataPropertyName = "Pas";
            this.tmR_ArrowColumn22.HeaderText = "Pas";
            this.tmR_ArrowColumn22.Name = "tmR_ArrowColumn22";
            this.tmR_ArrowColumn22.ReadOnly = true;
            this.tmR_ArrowColumn22.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn22.Width = 24;
            // 
            // tmR_ArrowColumn23
            // 
            this.tmR_ArrowColumn23.DataPropertyName = "Cro";
            this.tmR_ArrowColumn23.HeaderText = "Cro";
            this.tmR_ArrowColumn23.Name = "tmR_ArrowColumn23";
            this.tmR_ArrowColumn23.ReadOnly = true;
            this.tmR_ArrowColumn23.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn23.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn23.Width = 24;
            // 
            // tmR_ArrowColumn24
            // 
            this.tmR_ArrowColumn24.DataPropertyName = "Tec";
            this.tmR_ArrowColumn24.HeaderText = "Tec";
            this.tmR_ArrowColumn24.Name = "tmR_ArrowColumn24";
            this.tmR_ArrowColumn24.ReadOnly = true;
            this.tmR_ArrowColumn24.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn24.Width = 24;
            // 
            // tmR_ArrowColumn25
            // 
            this.tmR_ArrowColumn25.DataPropertyName = "Tes";
            this.tmR_ArrowColumn25.HeaderText = "Hea";
            this.tmR_ArrowColumn25.Name = "tmR_ArrowColumn25";
            this.tmR_ArrowColumn25.ReadOnly = true;
            this.tmR_ArrowColumn25.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn25.Width = 24;
            // 
            // tmR_ArrowColumn26
            // 
            this.tmR_ArrowColumn26.DataPropertyName = "Fin";
            this.tmR_ArrowColumn26.HeaderText = "Fin";
            this.tmR_ArrowColumn26.Name = "tmR_ArrowColumn26";
            this.tmR_ArrowColumn26.ReadOnly = true;
            this.tmR_ArrowColumn26.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn26.Width = 24;
            // 
            // tmR_ArrowColumn27
            // 
            this.tmR_ArrowColumn27.DataPropertyName = "Tir";
            this.tmR_ArrowColumn27.HeaderText = "Lon";
            this.tmR_ArrowColumn27.Name = "tmR_ArrowColumn27";
            this.tmR_ArrowColumn27.ReadOnly = true;
            this.tmR_ArrowColumn27.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn27.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn27.Width = 23;
            // 
            // tmR_ArrowColumn28
            // 
            this.tmR_ArrowColumn28.DataPropertyName = "Cal";
            this.tmR_ArrowColumn28.HeaderText = "Set";
            this.tmR_ArrowColumn28.Name = "tmR_ArrowColumn28";
            this.tmR_ArrowColumn28.ReadOnly = true;
            this.tmR_ArrowColumn28.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_ArrowColumn28.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tmR_ArrowColumn28.Width = 23;
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
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Tir";
            this.dataGridViewTextBoxColumn13.HeaderText = "Tir";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // tmR_TrainSkillColumn2
            // 
            this.tmR_TrainSkillColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tmR_TrainSkillColumn2.DataPropertyName = "Program";
            this.tmR_TrainSkillColumn2.HeaderText = "Training Program";
            this.tmR_TrainSkillColumn2.Name = "tmR_TrainSkillColumn2";
            this.tmR_TrainSkillColumn2.ReadOnly = true;
            this.tmR_TrainSkillColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tmR_TrainSkillColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Cal";
            this.dataGridViewTextBoxColumn14.HeaderText = "CP";
            this.dataGridViewTextBoxColumn14.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.ToolTipText = "Season";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "TI";
            this.dataGridViewTextBoxColumn15.HeaderText = "TI";
            this.dataGridViewTextBoxColumn15.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.ToolTipText = "Game Played";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "TrainerName";
            this.dataGridViewTextBoxColumn16.HeaderText = "Trainer";
            this.dataGridViewTextBoxColumn16.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.ToolTipText = "Goals";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Program";
            this.dataGridViewTextBoxColumn17.HeaderText = "Program";
            this.dataGridViewTextBoxColumn17.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.ToolTipText = "Assists";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Percentage";
            this.dataGridViewTextBoxColumn18.HeaderText = "%";
            this.dataGridViewTextBoxColumn18.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.ToolTipText = "Cards";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Rat";
            dataGridViewCellStyle8.Format = "N1";
            this.dataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn19.HeaderText = "Rat";
            this.dataGridViewTextBoxColumn19.MinimumWidth = 33;
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.ToolTipText = "Ratings";
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn20.DataPropertyName = "MoM";
            this.dataGridViewTextBoxColumn20.HeaderText = "MoM";
            this.dataGridViewTextBoxColumn20.MinimumWidth = 38;
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.ToolTipText = "Man of the Match";
            // 
            // playerData
            // 
            this.playerData.BackColor = System.Drawing.SystemColors.Control;
            this.playerData.Location = new System.Drawing.Point(3, 28);
            this.playerData.Name = "playerData";
            this.playerData.Size = new System.Drawing.Size(252, 313);
            this.playerData.TabIndex = 11;
            // 
            // teamDS
            // 
            this.teamDS.DataSetName = "TeamDS";
            this.teamDS.last_week_loaded = -1;
            this.teamDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gkGoalkeepersToolStripMenuItem
            // 
            this.gkGoalkeepersToolStripMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.gkGoalkeepersToolStripMenuItem.Name = "gkGoalkeepersToolStripMenuItem";
            this.gkGoalkeepersToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.gkGoalkeepersToolStripMenuItem.Text = "GK - Goalkeepers";
            // 
            // PlayerAge
            // 
            this.PlayerAge.DataPropertyName = "Age";
            this.PlayerAge.HeaderText = "Age";
            this.PlayerAge.Name = "PlayerAge";
            this.PlayerAge.ReadOnly = true;
            this.PlayerAge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PlayerAge.When = new System.DateTime(2015, 12, 22, 0, 4, 44, 937);
            this.PlayerAge.Width = 40;
            // 
            // absWeekDataGridViewTextBoxColumn
            // 
            this.absWeekDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
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
            this.forDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.forDataGridViewTextBoxColumn.DataPropertyName = "For";
            this.forDataGridViewTextBoxColumn.HeaderText = "Str";
            this.forDataGridViewTextBoxColumn.Name = "forDataGridViewTextBoxColumn";
            this.forDataGridViewTextBoxColumn.ReadOnly = true;
            this.forDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.forDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.forDataGridViewTextBoxColumn.Width = 28;
            // 
            // resDataGridViewTextBoxColumn
            // 
            this.resDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.resDataGridViewTextBoxColumn.DataPropertyName = "Res";
            this.resDataGridViewTextBoxColumn.HeaderText = "Sta";
            this.resDataGridViewTextBoxColumn.Name = "resDataGridViewTextBoxColumn";
            this.resDataGridViewTextBoxColumn.ReadOnly = true;
            this.resDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.resDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.resDataGridViewTextBoxColumn.Width = 28;
            // 
            // velDataGridViewTextBoxColumn
            // 
            this.velDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.velDataGridViewTextBoxColumn.DataPropertyName = "Vel";
            this.velDataGridViewTextBoxColumn.HeaderText = "Pac";
            this.velDataGridViewTextBoxColumn.Name = "velDataGridViewTextBoxColumn";
            this.velDataGridViewTextBoxColumn.ReadOnly = true;
            this.velDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.velDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.velDataGridViewTextBoxColumn.Width = 20;
            // 
            // marDataGridViewTextBoxColumn
            // 
            this.marDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.marDataGridViewTextBoxColumn.DataPropertyName = "Mar";
            this.marDataGridViewTextBoxColumn.HeaderText = "Mar";
            this.marDataGridViewTextBoxColumn.Name = "marDataGridViewTextBoxColumn";
            this.marDataGridViewTextBoxColumn.ReadOnly = true;
            this.marDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.marDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.marDataGridViewTextBoxColumn.Width = 28;
            // 
            // conDataGridViewTextBoxColumn
            // 
            this.conDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.conDataGridViewTextBoxColumn.DataPropertyName = "Con";
            this.conDataGridViewTextBoxColumn.HeaderText = "Tak";
            this.conDataGridViewTextBoxColumn.Name = "conDataGridViewTextBoxColumn";
            this.conDataGridViewTextBoxColumn.ReadOnly = true;
            this.conDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.conDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.conDataGridViewTextBoxColumn.Width = 28;
            // 
            // worDataGridViewTextBoxColumn
            // 
            this.worDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.worDataGridViewTextBoxColumn.DataPropertyName = "Wor";
            this.worDataGridViewTextBoxColumn.HeaderText = "Wor";
            this.worDataGridViewTextBoxColumn.Name = "worDataGridViewTextBoxColumn";
            this.worDataGridViewTextBoxColumn.ReadOnly = true;
            this.worDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.worDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.worDataGridViewTextBoxColumn.Width = 28;
            // 
            // posDataGridViewTextBoxColumn
            // 
            this.posDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.posDataGridViewTextBoxColumn.DataPropertyName = "Pos";
            this.posDataGridViewTextBoxColumn.HeaderText = "Pos";
            this.posDataGridViewTextBoxColumn.Name = "posDataGridViewTextBoxColumn";
            this.posDataGridViewTextBoxColumn.ReadOnly = true;
            this.posDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.posDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.posDataGridViewTextBoxColumn.Width = 28;
            // 
            // pasDataGridViewTextBoxColumn
            // 
            this.pasDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.pasDataGridViewTextBoxColumn.DataPropertyName = "Pas";
            this.pasDataGridViewTextBoxColumn.HeaderText = "Pas";
            this.pasDataGridViewTextBoxColumn.Name = "pasDataGridViewTextBoxColumn";
            this.pasDataGridViewTextBoxColumn.ReadOnly = true;
            this.pasDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pasDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.pasDataGridViewTextBoxColumn.Width = 28;
            // 
            // croDataGridViewTextBoxColumn
            // 
            this.croDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.croDataGridViewTextBoxColumn.DataPropertyName = "Cro";
            this.croDataGridViewTextBoxColumn.HeaderText = "Cro";
            this.croDataGridViewTextBoxColumn.Name = "croDataGridViewTextBoxColumn";
            this.croDataGridViewTextBoxColumn.ReadOnly = true;
            this.croDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.croDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.croDataGridViewTextBoxColumn.Width = 28;
            // 
            // tecDataGridViewTextBoxColumn
            // 
            this.tecDataGridViewTextBoxColumn.DataPropertyName = "Tec";
            this.tecDataGridViewTextBoxColumn.HeaderText = "Tec";
            this.tecDataGridViewTextBoxColumn.Name = "tecDataGridViewTextBoxColumn";
            this.tecDataGridViewTextBoxColumn.ReadOnly = true;
            this.tecDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tecDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tecDataGridViewTextBoxColumn.Width = 28;
            // 
            // tesDataGridViewTextBoxColumn
            // 
            this.tesDataGridViewTextBoxColumn.DataPropertyName = "Tes";
            this.tesDataGridViewTextBoxColumn.HeaderText = "Hea";
            this.tesDataGridViewTextBoxColumn.Name = "tesDataGridViewTextBoxColumn";
            this.tesDataGridViewTextBoxColumn.ReadOnly = true;
            this.tesDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tesDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tesDataGridViewTextBoxColumn.Width = 28;
            // 
            // finDataGridViewTextBoxColumn
            // 
            this.finDataGridViewTextBoxColumn.DataPropertyName = "Fin";
            this.finDataGridViewTextBoxColumn.HeaderText = "Fin";
            this.finDataGridViewTextBoxColumn.Name = "finDataGridViewTextBoxColumn";
            this.finDataGridViewTextBoxColumn.ReadOnly = true;
            this.finDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.finDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.finDataGridViewTextBoxColumn.Width = 28;
            // 
            // lonDataGridViewTextBoxColumn
            // 
            this.lonDataGridViewTextBoxColumn.DataPropertyName = "Tir";
            this.lonDataGridViewTextBoxColumn.HeaderText = "Lon";
            this.lonDataGridViewTextBoxColumn.Name = "lonDataGridViewTextBoxColumn";
            this.lonDataGridViewTextBoxColumn.ReadOnly = true;
            this.lonDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lonDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lonDataGridViewTextBoxColumn.Width = 28;
            // 
            // setDataGridViewTextBoxColumn
            // 
            this.setDataGridViewTextBoxColumn.DataPropertyName = "Cal";
            this.setDataGridViewTextBoxColumn.HeaderText = "Set";
            this.setDataGridViewTextBoxColumn.Name = "setDataGridViewTextBoxColumn";
            this.setDataGridViewTextBoxColumn.ReadOnly = true;
            this.setDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.setDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.setDataGridViewTextBoxColumn.Width = 28;
            // 
            // tIDataGridViewTextBoxColumn
            // 
            this.tIDataGridViewTextBoxColumn.DataPropertyName = "TI";
            this.tIDataGridViewTextBoxColumn.HeaderText = "TI";
            this.tIDataGridViewTextBoxColumn.Name = "tIDataGridViewTextBoxColumn";
            this.tIDataGridViewTextBoxColumn.ReadOnly = true;
            this.tIDataGridViewTextBoxColumn.Width = 28;
            // 
            // trainingTypesColumn
            // 
            this.trainingTypesColumn.DataPropertyName = "TrainerName";
            this.trainingTypesColumn.HeaderText = "Training Type";
            this.trainingTypesColumn.Name = "trainingTypesColumn";
            this.trainingTypesColumn.ReadOnly = true;
            // 
            // programDataGridViewTextBoxColumn
            // 
            this.programDataGridViewTextBoxColumn.DataPropertyName = "Program";
            this.programDataGridViewTextBoxColumn.HeaderText = "Program";
            this.programDataGridViewTextBoxColumn.Name = "programDataGridViewTextBoxColumn";
            this.programDataGridViewTextBoxColumn.ReadOnly = true;
            this.programDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.programDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(968, 577);
            this.Controls.Add(this.playerData);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControlPlayerHistory);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PlayerForm";
            this.Text = "Player History";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerForm_FormClosing);
            this.Load += new System.EventHandler(this.PlayerForm_Load);
            this.SizeChanged += new System.EventHandler(this.PlayerForm_SizeChanged);
            this.tabControlPlayerHistory.ResumeLayout(false);
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
            this.tabPageTrainingAndPotential.ResumeLayout(false);
            this.tabPageTrainingAndPotential.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgTraining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerTraining)).EndInit();
            this.tabPlayerBrowser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scoutsDataTableBindingSource1)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.bestPlayersDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reviewDataTableBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoutsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extraDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPlayerHistory;
        private System.Windows.Forms.TabPage tabSkills;
        private ZedGraph.ZedGraphControl graphSkills;
        private System.Windows.Forms.TabPage tabPage2;
        private ZedGraph.ZedGraphControl graphInjuries;
        private System.Windows.Forms.TabPage tabPage3;
        private ZedGraph.ZedGraphControl graphSpecs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ZedGraph.ZedGraphControl graphASI;
        private ZedGraph.ZedGraphControl graphTI;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox chkShowTGI;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.TabPage tabPage4;
        private ZedGraph.ZedGraphControl graphPerf;
        private System.Windows.Forms.ToolStripButton tsbComputeGrowth;
        private System.Windows.Forms.TabPage tabPageTrainingAndPotential;
        public System.Windows.Forms.BindingSource scoutsBindingSource;
        public ExtraDS extraDS;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnGetVotenSkillAuto;
        public ReportAnalysis ReportAnalysis;
        private System.Windows.Forms.TabPage tabPage6;
        private AeroDataGrid dgTraining;
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
        private NTR_Common.NTR_PlayerData playerData;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn2;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn3;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn4;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn5;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn6;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn7;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn8;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn9;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn10;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn11;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn1;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn2;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn3;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn4;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn5;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn6;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn7;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn8;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn9;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn10;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn11;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn12;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn13;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn14;
        private DataGridViewCustomColumns.TMR_TrainSkillColumn tmR_TrainSkillColumn1;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn12;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn13;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn14;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn15;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn16;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn17;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn18;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn19;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn20;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn21;
        private DataGridViewCustomColumns.TMR_ReportColumn tmR_ReportColumn22;
        private DataGridViewCustomColumns.TMR_AgeColumn tmR_AgeColumn2;
        private DataGridViewCustomColumns.TMR_DateColumn tmR_DateColumn2;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn15;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn16;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn17;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn18;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn19;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn20;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn21;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn22;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn23;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn24;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn25;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn26;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn27;
        private DataGridViewCustomColumns.TMR_ArrowColumn tmR_ArrowColumn28;
        private DataGridViewCustomColumns.TMR_TrainSkillColumn tmR_TrainSkillColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private NTR_Common.TeamDS teamDS;
        private NTR_WebBrowser.NTR_Browser webBrowser;
        private PlayerTraining playerTraining;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainingTypeColumn;
        private System.Windows.Forms.ToolStripMenuItem gkGoalkeepersToolStripMenuItem;
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
        private DataGridViewCustomColumns.TMR_ArrowColumn lonDataGridViewTextBoxColumn;
        private DataGridViewCustomColumns.TMR_ArrowColumn setDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainingTypesColumn;
        private DataGridViewCustomColumns.TMR_TrainSkillColumn programDataGridViewTextBoxColumn;
    }
}