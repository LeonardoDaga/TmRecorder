namespace FieldFormationControl
{
    partial class LineupPlayer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineupPlayer));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipText = new System.Windows.Forms.ToolTip(this.components);
            this.assImageList0 = new System.Windows.Forms.ImageList(this.components);
            this.assImageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectItemToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 26);
            // 
            // selectItemToolStripMenuItem
            // 
            this.selectItemToolStripMenuItem.Name = "selectItemToolStripMenuItem";
            this.selectItemToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.selectItemToolStripMenuItem.Text = "Select Item";
            this.selectItemToolStripMenuItem.Click += new System.EventHandler(this.selectItemToolStripMenuItem_Click);
            // 
            // toolTipText
            // 
            this.toolTipText.AutoPopDelay = 100000;
            this.toolTipText.InitialDelay = 0;
            this.toolTipText.IsBalloon = true;
            this.toolTipText.ReshowDelay = 0;
            this.toolTipText.ToolTipTitle = "Tooltip Title";
            // 
            // assImageList0
            // 
            this.assImageList0.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("assImageList0.ImageStream")));
            this.assImageList0.TransparentColor = System.Drawing.Color.Transparent;
            this.assImageList0.Images.SetKeyName(0, "ass_str_0.gif");
            this.assImageList0.Images.SetKeyName(1, "ass_pace_0.gif");
            this.assImageList0.Images.SetKeyName(2, "ass_def_0.gif");
            this.assImageList0.Images.SetKeyName(3, "ass_bee_0.gif");
            this.assImageList0.Images.SetKeyName(4, "ass_shoe_0.gif");
            this.assImageList0.Images.SetKeyName(5, "ass_wing_0.gif");
            this.assImageList0.Images.SetKeyName(6, "ass_dart_0.gif");
            this.assImageList0.Images.SetKeyName(7, "ass_head_0.gif");
            this.assImageList0.Images.SetKeyName(8, "ass_gk_0.gif");
            // 
            // assImageList
            // 
            this.assImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("assImageList.ImageStream")));
            this.assImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.assImageList.Images.SetKeyName(0, "ass_str.gif");
            this.assImageList.Images.SetKeyName(1, "ass_pace.gif");
            this.assImageList.Images.SetKeyName(2, "ass_def.gif");
            this.assImageList.Images.SetKeyName(3, "ass_bee.gif");
            this.assImageList.Images.SetKeyName(4, "ass_shoe.gif");
            this.assImageList.Images.SetKeyName(5, "ass_wing.gif");
            this.assImageList.Images.SetKeyName(6, "ass_dart.gif");
            this.assImageList.Images.SetKeyName(7, "ass_head.gif");
            this.assImageList.Images.SetKeyName(8, "ass_gk.gif");
            this.assImageList.Images.SetKeyName(9, "Star.gif");
            this.assImageList.Images.SetKeyName(10, "Cross.gif");
            this.assImageList.Images.SetKeyName(11, "Yellow.gif");
            this.assImageList.Images.SetKeyName(12, "Red.gif");
            // 
            // LineupPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.DoubleBuffered = true;
            this.Name = "LineupPlayer";
            this.Size = new System.Drawing.Size(78, 77);
            this.toolTipText.SetToolTip(this, "Testo Tooltip");
            this.MouseLeave += new System.EventHandler(this.LineupPlayer_MouseLeave);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LineupPlayer_MouseClick);
            this.MouseHover += new System.EventHandler(this.LineupPlayer_MouseHover);
            this.MouseEnter += new System.EventHandler(this.LineupPlayer_MouseEnter);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectItemToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipText;
        private System.Windows.Forms.ImageList assImageList0;
        private System.Windows.Forms.ImageList assImageList;
    }
}
