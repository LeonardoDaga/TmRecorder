namespace TMRecorder
{
    partial class PlayerReview
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.numShowRev = new System.Windows.Forms.NumericUpDown();
            this.txtScout = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPasteScoutData = new System.Windows.Forms.Button();
            this.txtScoutVote = new System.Windows.Forms.TextBox();
            this.txtScoutReview = new System.Windows.Forms.TextBox();
            this.chkChangeInfos = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addScoutReviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteScoutReviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numShowRev)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(57, 7);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(26, 13);
            this.lblTotal.TabIndex = 19;
            this.lblTotal.Text = "of X";
            // 
            // numShowRev
            // 
            this.numShowRev.Location = new System.Drawing.Point(9, 5);
            this.numShowRev.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numShowRev.Name = "numShowRev";
            this.numShowRev.Size = new System.Drawing.Size(45, 20);
            this.numShowRev.TabIndex = 18;
            this.numShowRev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numShowRev.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numShowRev.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numShowRev.ValueChanged += new System.EventHandler(this.numShowRev_ValueChanged);
            // 
            // txtScout
            // 
            this.txtScout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScout.Location = new System.Drawing.Point(44, 50);
            this.txtScout.Name = "txtScout";
            this.txtScout.ReadOnly = true;
            this.txtScout.Size = new System.Drawing.Size(120, 20);
            this.txtScout.TabIndex = 15;
            this.txtScout.TextChanged += new System.EventHandler(this.txtDataChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Vote";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Scout";
            // 
            // btnPasteScoutData
            // 
            this.btnPasteScoutData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPasteScoutData.Location = new System.Drawing.Point(140, 24);
            this.btnPasteScoutData.Name = "btnPasteScoutData";
            this.btnPasteScoutData.Size = new System.Drawing.Size(99, 21);
            this.btnPasteScoutData.TabIndex = 17;
            this.btnPasteScoutData.Text = "Paste Scout Data";
            this.btnPasteScoutData.UseVisualStyleBackColor = true;
            this.btnPasteScoutData.Click += new System.EventHandler(this.btnPasteScoutData_Click);
            // 
            // txtScoutVote
            // 
            this.txtScoutVote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScoutVote.Location = new System.Drawing.Point(201, 50);
            this.txtScoutVote.Name = "txtScoutVote";
            this.txtScoutVote.ReadOnly = true;
            this.txtScoutVote.Size = new System.Drawing.Size(35, 20);
            this.txtScoutVote.TabIndex = 13;
            this.txtScoutVote.TextChanged += new System.EventHandler(this.txtDataChanged);
            // 
            // txtScoutReview
            // 
            this.txtScoutReview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScoutReview.Location = new System.Drawing.Point(3, 72);
            this.txtScoutReview.Multiline = true;
            this.txtScoutReview.Name = "txtScoutReview";
            this.txtScoutReview.ReadOnly = true;
            this.txtScoutReview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScoutReview.Size = new System.Drawing.Size(237, 213);
            this.txtScoutReview.TabIndex = 14;
            this.txtScoutReview.TextChanged += new System.EventHandler(this.txtDataChanged);
            // 
            // chkChangeInfos
            // 
            this.chkChangeInfos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkChangeInfos.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkChangeInfos.Location = new System.Drawing.Point(140, 2);
            this.chkChangeInfos.Name = "chkChangeInfos";
            this.chkChangeInfos.Size = new System.Drawing.Size(99, 22);
            this.chkChangeInfos.TabIndex = 16;
            this.chkChangeInfos.Text = "Change";
            this.chkChangeInfos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkChangeInfos.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Date";
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.Location = new System.Drawing.Point(44, 29);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(82, 20);
            this.txtDate.TabIndex = 13;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDataChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addScoutReviewToolStripMenuItem,
            this.deleteScoutReviewToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 70);
            // 
            // addScoutReviewToolStripMenuItem
            // 
            this.addScoutReviewToolStripMenuItem.Name = "addScoutReviewToolStripMenuItem";
            this.addScoutReviewToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.addScoutReviewToolStripMenuItem.Text = "Add Scout Review";
            this.addScoutReviewToolStripMenuItem.Click += new System.EventHandler(this.addScoutReviewToolStripMenuItem_Click);
            // 
            // deleteScoutReviewToolStripMenuItem
            // 
            this.deleteScoutReviewToolStripMenuItem.Name = "deleteScoutReviewToolStripMenuItem";
            this.deleteScoutReviewToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.deleteScoutReviewToolStripMenuItem.Text = "Delete Scout Review";
            this.deleteScoutReviewToolStripMenuItem.Click += new System.EventHandler(this.deleteScoutReviewToolStripMenuItem_Click);
            // 
            // PlayerReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.numShowRev);
            this.Controls.Add(this.txtScout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPasteScoutData);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtScoutVote);
            this.Controls.Add(this.txtScoutReview);
            this.Controls.Add(this.chkChangeInfos);
            this.Name = "PlayerReview";
            this.Size = new System.Drawing.Size(240, 288);
            ((System.ComponentModel.ISupportInitialize)(this.numShowRev)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.NumericUpDown numShowRev;
        private System.Windows.Forms.TextBox txtScout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPasteScoutData;
        private System.Windows.Forms.TextBox txtScoutVote;
        private System.Windows.Forms.TextBox txtScoutReview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDate;
        public System.Windows.Forms.CheckBox chkChangeInfos;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addScoutReviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteScoutReviewToolStripMenuItem;
    }
}
