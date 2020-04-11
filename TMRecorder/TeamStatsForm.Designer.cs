namespace TMRecorder
{
    partial class TeamStatsForm
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
            this.graphAgeHistory = new ZedGraph.ZedGraphControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.graphTotASIHistory = new ZedGraph.ZedGraphControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.graphSkillGrowth = new ZedGraph.ZedGraphControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.graphSkillCount = new ZedGraph.ZedGraphControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.graphSquadAge = new ZedGraph.ZedGraphControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.graphSquadASI = new ZedGraph.ZedGraphControl();
            this.tabFansPage = new System.Windows.Forms.TabPage();
            this.graphTeamFans = new ZedGraph.ZedGraphControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabFansPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabFansPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(768, 438);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.graphAgeHistory);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(760, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Age History";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // graphAgeHistory
            // 
            this.graphAgeHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphAgeHistory.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphAgeHistory.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphAgeHistory.ForeColor = System.Drawing.Color.White;
            this.graphAgeHistory.IsAutoScrollRange = false;
            this.graphAgeHistory.IsEnableHEdit = false;
            this.graphAgeHistory.IsEnableHPan = true;
            this.graphAgeHistory.IsEnableHZoom = true;
            this.graphAgeHistory.IsEnableVEdit = false;
            this.graphAgeHistory.IsEnableVPan = true;
            this.graphAgeHistory.IsEnableVZoom = true;
            this.graphAgeHistory.IsPrintFillPage = true;
            this.graphAgeHistory.IsPrintKeepAspectRatio = true;
            this.graphAgeHistory.IsScrollY2 = false;
            this.graphAgeHistory.IsShowContextMenu = true;
            this.graphAgeHistory.IsShowCopyMessage = true;
            this.graphAgeHistory.IsShowCursorValues = false;
            this.graphAgeHistory.IsShowHScrollBar = false;
            this.graphAgeHistory.IsShowPointValues = false;
            this.graphAgeHistory.IsShowVScrollBar = false;
            this.graphAgeHistory.IsSynchronizeXAxes = false;
            this.graphAgeHistory.IsSynchronizeYAxes = false;
            this.graphAgeHistory.IsZoomOnMouseCenter = false;
            this.graphAgeHistory.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphAgeHistory.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphAgeHistory.Location = new System.Drawing.Point(3, 3);
            this.graphAgeHistory.Name = "graphAgeHistory";
            this.graphAgeHistory.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphAgeHistory.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphAgeHistory.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphAgeHistory.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphAgeHistory.PointDateFormat = "g";
            this.graphAgeHistory.PointValueFormat = "G";
            this.graphAgeHistory.ScrollMaxX = 0D;
            this.graphAgeHistory.ScrollMaxY = 0D;
            this.graphAgeHistory.ScrollMaxY2 = 0D;
            this.graphAgeHistory.ScrollMinX = 0D;
            this.graphAgeHistory.ScrollMinY = 0D;
            this.graphAgeHistory.ScrollMinY2 = 0D;
            this.graphAgeHistory.Size = new System.Drawing.Size(754, 406);
            this.graphAgeHistory.TabIndex = 1;
            this.graphAgeHistory.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphAgeHistory.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphAgeHistory.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphAgeHistory.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphAgeHistory.ZoomStepFraction = 0.1D;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.graphTotASIHistory);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(760, 412);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Total ASI History";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // graphTotASIHistory
            // 
            this.graphTotASIHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTotASIHistory.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTotASIHistory.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphTotASIHistory.ForeColor = System.Drawing.Color.White;
            this.graphTotASIHistory.IsAutoScrollRange = false;
            this.graphTotASIHistory.IsEnableHEdit = false;
            this.graphTotASIHistory.IsEnableHPan = true;
            this.graphTotASIHistory.IsEnableHZoom = true;
            this.graphTotASIHistory.IsEnableVEdit = false;
            this.graphTotASIHistory.IsEnableVPan = true;
            this.graphTotASIHistory.IsEnableVZoom = true;
            this.graphTotASIHistory.IsPrintFillPage = true;
            this.graphTotASIHistory.IsPrintKeepAspectRatio = true;
            this.graphTotASIHistory.IsScrollY2 = false;
            this.graphTotASIHistory.IsShowContextMenu = true;
            this.graphTotASIHistory.IsShowCopyMessage = true;
            this.graphTotASIHistory.IsShowCursorValues = false;
            this.graphTotASIHistory.IsShowHScrollBar = false;
            this.graphTotASIHistory.IsShowPointValues = false;
            this.graphTotASIHistory.IsShowVScrollBar = false;
            this.graphTotASIHistory.IsSynchronizeXAxes = false;
            this.graphTotASIHistory.IsSynchronizeYAxes = false;
            this.graphTotASIHistory.IsZoomOnMouseCenter = false;
            this.graphTotASIHistory.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTotASIHistory.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphTotASIHistory.Location = new System.Drawing.Point(3, 3);
            this.graphTotASIHistory.Name = "graphTotASIHistory";
            this.graphTotASIHistory.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTotASIHistory.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphTotASIHistory.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphTotASIHistory.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTotASIHistory.PointDateFormat = "g";
            this.graphTotASIHistory.PointValueFormat = "G";
            this.graphTotASIHistory.ScrollMaxX = 0D;
            this.graphTotASIHistory.ScrollMaxY = 0D;
            this.graphTotASIHistory.ScrollMaxY2 = 0D;
            this.graphTotASIHistory.ScrollMinX = 0D;
            this.graphTotASIHistory.ScrollMinY = 0D;
            this.graphTotASIHistory.ScrollMinY2 = 0D;
            this.graphTotASIHistory.Size = new System.Drawing.Size(754, 406);
            this.graphTotASIHistory.TabIndex = 1;
            this.graphTotASIHistory.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTotASIHistory.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphTotASIHistory.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphTotASIHistory.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTotASIHistory.ZoomStepFraction = 0.1D;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.graphSkillGrowth);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(760, 412);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Skill Growth Graph";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // graphSkillGrowth
            // 
            this.graphSkillGrowth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphSkillGrowth.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSkillGrowth.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphSkillGrowth.ForeColor = System.Drawing.Color.White;
            this.graphSkillGrowth.IsAutoScrollRange = false;
            this.graphSkillGrowth.IsEnableHEdit = false;
            this.graphSkillGrowth.IsEnableHPan = true;
            this.graphSkillGrowth.IsEnableHZoom = true;
            this.graphSkillGrowth.IsEnableVEdit = false;
            this.graphSkillGrowth.IsEnableVPan = true;
            this.graphSkillGrowth.IsEnableVZoom = true;
            this.graphSkillGrowth.IsPrintFillPage = true;
            this.graphSkillGrowth.IsPrintKeepAspectRatio = true;
            this.graphSkillGrowth.IsScrollY2 = false;
            this.graphSkillGrowth.IsShowContextMenu = true;
            this.graphSkillGrowth.IsShowCopyMessage = true;
            this.graphSkillGrowth.IsShowCursorValues = false;
            this.graphSkillGrowth.IsShowHScrollBar = false;
            this.graphSkillGrowth.IsShowPointValues = false;
            this.graphSkillGrowth.IsShowVScrollBar = false;
            this.graphSkillGrowth.IsSynchronizeXAxes = false;
            this.graphSkillGrowth.IsSynchronizeYAxes = false;
            this.graphSkillGrowth.IsZoomOnMouseCenter = false;
            this.graphSkillGrowth.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSkillGrowth.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphSkillGrowth.Location = new System.Drawing.Point(3, 3);
            this.graphSkillGrowth.Name = "graphSkillGrowth";
            this.graphSkillGrowth.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSkillGrowth.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphSkillGrowth.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphSkillGrowth.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphSkillGrowth.PointDateFormat = "g";
            this.graphSkillGrowth.PointValueFormat = "G";
            this.graphSkillGrowth.ScrollMaxX = 0D;
            this.graphSkillGrowth.ScrollMaxY = 0D;
            this.graphSkillGrowth.ScrollMaxY2 = 0D;
            this.graphSkillGrowth.ScrollMinX = 0D;
            this.graphSkillGrowth.ScrollMinY = 0D;
            this.graphSkillGrowth.ScrollMinY2 = 0D;
            this.graphSkillGrowth.Size = new System.Drawing.Size(754, 406);
            this.graphSkillGrowth.TabIndex = 2;
            this.graphSkillGrowth.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSkillGrowth.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphSkillGrowth.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphSkillGrowth.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphSkillGrowth.ZoomStepFraction = 0.1D;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.graphSkillCount);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(760, 412);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Skill Count";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // graphSkillCount
            // 
            this.graphSkillCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphSkillCount.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSkillCount.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphSkillCount.ForeColor = System.Drawing.Color.White;
            this.graphSkillCount.IsAutoScrollRange = false;
            this.graphSkillCount.IsEnableHEdit = false;
            this.graphSkillCount.IsEnableHPan = true;
            this.graphSkillCount.IsEnableHZoom = true;
            this.graphSkillCount.IsEnableVEdit = false;
            this.graphSkillCount.IsEnableVPan = true;
            this.graphSkillCount.IsEnableVZoom = true;
            this.graphSkillCount.IsPrintFillPage = true;
            this.graphSkillCount.IsPrintKeepAspectRatio = true;
            this.graphSkillCount.IsScrollY2 = false;
            this.graphSkillCount.IsShowContextMenu = true;
            this.graphSkillCount.IsShowCopyMessage = true;
            this.graphSkillCount.IsShowCursorValues = false;
            this.graphSkillCount.IsShowHScrollBar = false;
            this.graphSkillCount.IsShowPointValues = false;
            this.graphSkillCount.IsShowVScrollBar = false;
            this.graphSkillCount.IsSynchronizeXAxes = false;
            this.graphSkillCount.IsSynchronizeYAxes = false;
            this.graphSkillCount.IsZoomOnMouseCenter = false;
            this.graphSkillCount.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSkillCount.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphSkillCount.Location = new System.Drawing.Point(3, 3);
            this.graphSkillCount.Name = "graphSkillCount";
            this.graphSkillCount.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSkillCount.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphSkillCount.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphSkillCount.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphSkillCount.PointDateFormat = "g";
            this.graphSkillCount.PointValueFormat = "G";
            this.graphSkillCount.ScrollMaxX = 0D;
            this.graphSkillCount.ScrollMaxY = 0D;
            this.graphSkillCount.ScrollMaxY2 = 0D;
            this.graphSkillCount.ScrollMinX = 0D;
            this.graphSkillCount.ScrollMinY = 0D;
            this.graphSkillCount.ScrollMinY2 = 0D;
            this.graphSkillCount.Size = new System.Drawing.Size(754, 406);
            this.graphSkillCount.TabIndex = 2;
            this.graphSkillCount.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSkillCount.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphSkillCount.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphSkillCount.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphSkillCount.ZoomStepFraction = 0.1D;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.graphSquadAge);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(760, 412);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Squad Age";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // graphSquadAge
            // 
            this.graphSquadAge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphSquadAge.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSquadAge.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphSquadAge.ForeColor = System.Drawing.Color.White;
            this.graphSquadAge.IsAutoScrollRange = false;
            this.graphSquadAge.IsEnableHEdit = false;
            this.graphSquadAge.IsEnableHPan = true;
            this.graphSquadAge.IsEnableHZoom = true;
            this.graphSquadAge.IsEnableVEdit = false;
            this.graphSquadAge.IsEnableVPan = true;
            this.graphSquadAge.IsEnableVZoom = true;
            this.graphSquadAge.IsPrintFillPage = true;
            this.graphSquadAge.IsPrintKeepAspectRatio = true;
            this.graphSquadAge.IsScrollY2 = false;
            this.graphSquadAge.IsShowContextMenu = true;
            this.graphSquadAge.IsShowCopyMessage = true;
            this.graphSquadAge.IsShowCursorValues = false;
            this.graphSquadAge.IsShowHScrollBar = false;
            this.graphSquadAge.IsShowPointValues = false;
            this.graphSquadAge.IsShowVScrollBar = false;
            this.graphSquadAge.IsSynchronizeXAxes = false;
            this.graphSquadAge.IsSynchronizeYAxes = false;
            this.graphSquadAge.IsZoomOnMouseCenter = false;
            this.graphSquadAge.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSquadAge.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphSquadAge.Location = new System.Drawing.Point(3, 3);
            this.graphSquadAge.Name = "graphSquadAge";
            this.graphSquadAge.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSquadAge.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphSquadAge.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphSquadAge.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphSquadAge.PointDateFormat = "g";
            this.graphSquadAge.PointValueFormat = "G";
            this.graphSquadAge.ScrollMaxX = 0D;
            this.graphSquadAge.ScrollMaxY = 0D;
            this.graphSquadAge.ScrollMaxY2 = 0D;
            this.graphSquadAge.ScrollMinX = 0D;
            this.graphSquadAge.ScrollMinY = 0D;
            this.graphSquadAge.ScrollMinY2 = 0D;
            this.graphSquadAge.Size = new System.Drawing.Size(754, 406);
            this.graphSquadAge.TabIndex = 1;
            this.graphSquadAge.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSquadAge.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphSquadAge.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphSquadAge.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphSquadAge.ZoomStepFraction = 0.1D;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.graphSquadASI);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(760, 412);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Squad ASI";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // graphSquadASI
            // 
            this.graphSquadASI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphSquadASI.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSquadASI.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphSquadASI.IsAutoScrollRange = false;
            this.graphSquadASI.IsEnableHEdit = false;
            this.graphSquadASI.IsEnableHPan = true;
            this.graphSquadASI.IsEnableHZoom = true;
            this.graphSquadASI.IsEnableVEdit = false;
            this.graphSquadASI.IsEnableVPan = true;
            this.graphSquadASI.IsEnableVZoom = true;
            this.graphSquadASI.IsPrintFillPage = true;
            this.graphSquadASI.IsPrintKeepAspectRatio = true;
            this.graphSquadASI.IsScrollY2 = false;
            this.graphSquadASI.IsShowContextMenu = true;
            this.graphSquadASI.IsShowCopyMessage = true;
            this.graphSquadASI.IsShowCursorValues = false;
            this.graphSquadASI.IsShowHScrollBar = false;
            this.graphSquadASI.IsShowPointValues = false;
            this.graphSquadASI.IsShowVScrollBar = false;
            this.graphSquadASI.IsSynchronizeXAxes = false;
            this.graphSquadASI.IsSynchronizeYAxes = false;
            this.graphSquadASI.IsZoomOnMouseCenter = false;
            this.graphSquadASI.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSquadASI.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphSquadASI.Location = new System.Drawing.Point(3, 3);
            this.graphSquadASI.Name = "graphSquadASI";
            this.graphSquadASI.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSquadASI.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphSquadASI.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphSquadASI.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphSquadASI.PointDateFormat = "g";
            this.graphSquadASI.PointValueFormat = "G";
            this.graphSquadASI.ScrollMaxX = 0D;
            this.graphSquadASI.ScrollMaxY = 0D;
            this.graphSquadASI.ScrollMaxY2 = 0D;
            this.graphSquadASI.ScrollMinX = 0D;
            this.graphSquadASI.ScrollMinY = 0D;
            this.graphSquadASI.ScrollMinY2 = 0D;
            this.graphSquadASI.Size = new System.Drawing.Size(754, 406);
            this.graphSquadASI.TabIndex = 2;
            this.graphSquadASI.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphSquadASI.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphSquadASI.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphSquadASI.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphSquadASI.ZoomStepFraction = 0.1D;
            // 
            // tabFansPage
            // 
            this.tabFansPage.Controls.Add(this.graphTeamFans);
            this.tabFansPage.Location = new System.Drawing.Point(4, 22);
            this.tabFansPage.Name = "tabFansPage";
            this.tabFansPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabFansPage.Size = new System.Drawing.Size(760, 412);
            this.tabFansPage.TabIndex = 6;
            this.tabFansPage.Text = "Fans History";
            this.tabFansPage.UseVisualStyleBackColor = true;
            // 
            // graphTeamFans
            // 
            this.graphTeamFans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTeamFans.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTeamFans.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphTeamFans.IsAutoScrollRange = false;
            this.graphTeamFans.IsEnableHEdit = false;
            this.graphTeamFans.IsEnableHPan = true;
            this.graphTeamFans.IsEnableHZoom = true;
            this.graphTeamFans.IsEnableVEdit = false;
            this.graphTeamFans.IsEnableVPan = true;
            this.graphTeamFans.IsEnableVZoom = true;
            this.graphTeamFans.IsPrintFillPage = true;
            this.graphTeamFans.IsPrintKeepAspectRatio = true;
            this.graphTeamFans.IsScrollY2 = false;
            this.graphTeamFans.IsShowContextMenu = true;
            this.graphTeamFans.IsShowCopyMessage = true;
            this.graphTeamFans.IsShowCursorValues = false;
            this.graphTeamFans.IsShowHScrollBar = false;
            this.graphTeamFans.IsShowPointValues = false;
            this.graphTeamFans.IsShowVScrollBar = false;
            this.graphTeamFans.IsSynchronizeXAxes = false;
            this.graphTeamFans.IsSynchronizeYAxes = false;
            this.graphTeamFans.IsZoomOnMouseCenter = false;
            this.graphTeamFans.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTeamFans.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphTeamFans.Location = new System.Drawing.Point(3, 3);
            this.graphTeamFans.Name = "graphTeamFans";
            this.graphTeamFans.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTeamFans.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphTeamFans.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphTeamFans.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTeamFans.PointDateFormat = "g";
            this.graphTeamFans.PointValueFormat = "G";
            this.graphTeamFans.ScrollMaxX = 0D;
            this.graphTeamFans.ScrollMaxY = 0D;
            this.graphTeamFans.ScrollMaxY2 = 0D;
            this.graphTeamFans.ScrollMinX = 0D;
            this.graphTeamFans.ScrollMinY = 0D;
            this.graphTeamFans.ScrollMinY2 = 0D;
            this.graphTeamFans.Size = new System.Drawing.Size(754, 406);
            this.graphTeamFans.TabIndex = 3;
            this.graphTeamFans.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTeamFans.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphTeamFans.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphTeamFans.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTeamFans.ZoomStepFraction = 0.1D;
            // 
            // TeamStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 438);
            this.Controls.Add(this.tabControl1);
            this.Name = "TeamStatsForm";
            this.Text = "Your Team Statistics";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabFansPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private ZedGraph.ZedGraphControl graphSquadAge;
        private ZedGraph.ZedGraphControl graphSquadASI;
        private ZedGraph.ZedGraphControl graphTotASIHistory;
        private ZedGraph.ZedGraphControl graphAgeHistory;
        private ZedGraph.ZedGraphControl graphSkillGrowth;
        private ZedGraph.ZedGraphControl graphSkillCount;
        private System.Windows.Forms.TabPage tabFansPage;
        private ZedGraph.ZedGraphControl graphTeamFans;
    }
}