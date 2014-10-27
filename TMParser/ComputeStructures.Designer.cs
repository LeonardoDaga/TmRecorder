namespace TMRecorder
{
    partial class ComputeStructures
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.graphEconomy = new ZedGraph.ZedGraphControl();
            this.numAverageAttendance = new System.Windows.Forms.NumericUpDown();
            this.numOfSupporters = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numStadiumSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numAverageAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOfSupporters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStadiumSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 49);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Average Attendance";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Number of Supporters";
            // 
            // graphEconomy
            // 
            this.graphEconomy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphEconomy.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphEconomy.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphEconomy.IsAutoScrollRange = false;
            this.graphEconomy.IsEnableHEdit = false;
            this.graphEconomy.IsEnableHPan = true;
            this.graphEconomy.IsEnableHZoom = true;
            this.graphEconomy.IsEnableVEdit = false;
            this.graphEconomy.IsEnableVPan = true;
            this.graphEconomy.IsEnableVZoom = true;
            this.graphEconomy.IsPrintFillPage = true;
            this.graphEconomy.IsPrintKeepAspectRatio = true;
            this.graphEconomy.IsScrollY2 = false;
            this.graphEconomy.IsShowContextMenu = true;
            this.graphEconomy.IsShowCopyMessage = true;
            this.graphEconomy.IsShowCursorValues = false;
            this.graphEconomy.IsShowHScrollBar = false;
            this.graphEconomy.IsShowPointValues = false;
            this.graphEconomy.IsShowVScrollBar = false;
            this.graphEconomy.IsSynchronizeXAxes = false;
            this.graphEconomy.IsSynchronizeYAxes = false;
            this.graphEconomy.IsZoomOnMouseCenter = false;
            this.graphEconomy.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphEconomy.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.graphEconomy.Location = new System.Drawing.Point(313, 6);
            this.graphEconomy.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.graphEconomy.Name = "graphEconomy";
            this.graphEconomy.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphEconomy.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphEconomy.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphEconomy.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphEconomy.PointDateFormat = "TY";
            this.graphEconomy.PointValueFormat = "N2";
            this.graphEconomy.ScrollMaxX = 0D;
            this.graphEconomy.ScrollMaxY = 0D;
            this.graphEconomy.ScrollMaxY2 = 0D;
            this.graphEconomy.ScrollMinX = 0D;
            this.graphEconomy.ScrollMinY = 0D;
            this.graphEconomy.ScrollMinY2 = 0D;
            this.graphEconomy.Size = new System.Drawing.Size(734, 466);
            this.graphEconomy.TabIndex = 5;
            this.graphEconomy.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphEconomy.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphEconomy.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphEconomy.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphEconomy.ZoomStepFraction = 0.1D;
            // 
            // numAverageAttendance
            // 
            this.numAverageAttendance.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numAverageAttendance.Location = new System.Drawing.Point(197, 47);
            this.numAverageAttendance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numAverageAttendance.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
            this.numAverageAttendance.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numAverageAttendance.Name = "numAverageAttendance";
            this.numAverageAttendance.Size = new System.Drawing.Size(107, 22);
            this.numAverageAttendance.TabIndex = 6;
            this.numAverageAttendance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAverageAttendance.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numAverageAttendance.ValueChanged += new System.EventHandler(this.txtData_TextChanged);
            // 
            // numOfSupporters
            // 
            this.numOfSupporters.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numOfSupporters.Location = new System.Drawing.Point(197, 15);
            this.numOfSupporters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numOfSupporters.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
            this.numOfSupporters.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numOfSupporters.Name = "numOfSupporters";
            this.numOfSupporters.Size = new System.Drawing.Size(107, 22);
            this.numOfSupporters.TabIndex = 6;
            this.numOfSupporters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numOfSupporters.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numOfSupporters.ValueChanged += new System.EventHandler(this.txtData_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stadium Size";
            // 
            // numStadiumSize
            // 
            this.numStadiumSize.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numStadiumSize.Location = new System.Drawing.Point(197, 79);
            this.numStadiumSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numStadiumSize.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
            this.numStadiumSize.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numStadiumSize.Name = "numStadiumSize";
            this.numStadiumSize.Size = new System.Drawing.Size(107, 22);
            this.numStadiumSize.TabIndex = 6;
            this.numStadiumSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStadiumSize.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numStadiumSize.ValueChanged += new System.EventHandler(this.txtData_TextChanged);
            // 
            // ComputeStructures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 473);
            this.Controls.Add(this.numOfSupporters);
            this.Controls.Add(this.numStadiumSize);
            this.Controls.Add(this.numAverageAttendance);
            this.Controls.Add(this.graphEconomy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ComputeStructures";
            this.Text = "Structures Calculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComputeStructures_FormClosing);
            this.Load += new System.EventHandler(this.ComputeStructures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAverageAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOfSupporters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStadiumSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private ZedGraph.ZedGraphControl graphEconomy;
        private System.Windows.Forms.NumericUpDown numAverageAttendance;
        private System.Windows.Forms.NumericUpDown numOfSupporters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numStadiumSize;
    }
}