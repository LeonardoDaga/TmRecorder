namespace TMR_CostumControls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tmR_ToolStripButton1 = new TMR_CostumControls.TMR_ToolStripButton();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(316, 217);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(375, 242);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmR_ToolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(59, 58);
            this.toolStrip1.TabIndex = 0;
            // 
            // tmR_ToolStripButton1
            // 
            this.tmR_ToolStripButton1.AutoSize = false;
            this.tmR_ToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("tmR_ToolStripButton1.Image")));
            this.tmR_ToolStripButton1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tmR_ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmR_ToolStripButton1.Name = "tmR_ToolStripButton1";
            this.tmR_ToolStripButton1.Size = new System.Drawing.Size(58, 25);
            this.tmR_ToolStripButton1.Text = "testo3";
            this.tmR_ToolStripButton1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tmR_ToolStripButton1.ToolTipText = "testo3";
            this.tmR_ToolStripButton1.UnderAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tmR_ToolStripButton1.UnderColor = System.Drawing.Color.Maroon;
            this.tmR_ToolStripButton1.UnderFont = new System.Drawing.Font("Segoe UI", 6F);
            this.tmR_ToolStripButton1.UnderText = "mezzo";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 242);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private TMR_ToolStripButton tmR_ToolStripButton1;
    }
}