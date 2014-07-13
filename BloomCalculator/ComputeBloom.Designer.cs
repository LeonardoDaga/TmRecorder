namespace BloomCalculator
{
    partial class ComputeBloom
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtActualASI = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrentSkillSum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAfterBloomingTI = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAgeStartOfBloom = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEndOfBloomSkillSum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEndOfBloomASI = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtActualTI = new System.Windows.Forms.TextBox();
            this.txtBeforeExplTI = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtExplosionTI = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTopASI = new System.Windows.Forms.TextBox();
            this.chkGK = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMonths = new System.Windows.Forms.TextBox();
            this.graphASI = new ZedGraph.ZedGraphControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actual ASI";
            // 
            // txtActualASI
            // 
            this.txtActualASI.BackColor = System.Drawing.Color.White;
            this.txtActualASI.Location = new System.Drawing.Point(145, 35);
            this.txtActualASI.Name = "txtActualASI";
            this.txtActualASI.Size = new System.Drawing.Size(81, 20);
            this.txtActualASI.TabIndex = 3;
            this.txtActualASI.TextChanged += new System.EventHandler(this.txtActualASI_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Current Skill Sum";
            // 
            // txtCurrentSkillSum
            // 
            this.txtCurrentSkillSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCurrentSkillSum.Location = new System.Drawing.Point(145, 61);
            this.txtCurrentSkillSum.Name = "txtCurrentSkillSum";
            this.txtCurrentSkillSum.ReadOnly = true;
            this.txtCurrentSkillSum.Size = new System.Drawing.Size(81, 20);
            this.txtCurrentSkillSum.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "After Blooming TI";
            this.toolTip1.SetToolTip(this.label4, "This value is the TI of the player after the end of the blooming. \r\n");
            // 
            // txtAfterBloomingTI
            // 
            this.txtAfterBloomingTI.Location = new System.Drawing.Point(145, 166);
            this.txtAfterBloomingTI.Name = "txtAfterBloomingTI";
            this.txtAfterBloomingTI.Size = new System.Drawing.Size(81, 20);
            this.txtAfterBloomingTI.TabIndex = 7;
            this.txtAfterBloomingTI.TextChanged += new System.EventHandler(this.txtData_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Start of Bloom Age (Years)";
            // 
            // txtAgeStartOfBloom
            // 
            this.txtAgeStartOfBloom.Location = new System.Drawing.Point(145, 192);
            this.txtAgeStartOfBloom.Name = "txtAgeStartOfBloom";
            this.txtAgeStartOfBloom.Size = new System.Drawing.Size(81, 20);
            this.txtAgeStartOfBloom.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtAgeStartOfBloom, "Age of the Start of the Bllom");
            this.txtAgeStartOfBloom.TextChanged += new System.EventHandler(this.txtData_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlText;
            this.pictureBox1.Location = new System.Drawing.Point(11, 221);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 2);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "End Of Bloom Skill Sum";
            // 
            // txtEndOfBloomSkillSum
            // 
            this.txtEndOfBloomSkillSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEndOfBloomSkillSum.Location = new System.Drawing.Point(145, 229);
            this.txtEndOfBloomSkillSum.Name = "txtEndOfBloomSkillSum";
            this.txtEndOfBloomSkillSum.ReadOnly = true;
            this.txtEndOfBloomSkillSum.Size = new System.Drawing.Size(81, 20);
            this.txtEndOfBloomSkillSum.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "End Of Bloom ASI";
            // 
            // txtEndOfBloomASI
            // 
            this.txtEndOfBloomASI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEndOfBloomASI.Location = new System.Drawing.Point(145, 255);
            this.txtEndOfBloomASI.Name = "txtEndOfBloomASI";
            this.txtEndOfBloomASI.ReadOnly = true;
            this.txtEndOfBloomASI.Size = new System.Drawing.Size(81, 20);
            this.txtEndOfBloomASI.TabIndex = 1;
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.Color.White;
            this.txtAge.Location = new System.Drawing.Point(83, 9);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(38, 20);
            this.txtAge.TabIndex = 1;
            this.txtAge.TextChanged += new System.EventHandler(this.txtAge_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Actual Age";
            // 
            // txtActualTI
            // 
            this.txtActualTI.Location = new System.Drawing.Point(144, 114);
            this.txtActualTI.Name = "txtActualTI";
            this.txtActualTI.Size = new System.Drawing.Size(81, 20);
            this.txtActualTI.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtActualTI, "The TI increase after the explosion. If before the explosion the\r\nTI is 7 and aft" +
                    "er is 21, the additive TI is 21-7 = 14");
            this.txtActualTI.TextChanged += new System.EventHandler(this.txtData_TextChanged);
            // 
            // txtBeforeExplTI
            // 
            this.txtBeforeExplTI.Location = new System.Drawing.Point(144, 87);
            this.txtBeforeExplTI.Name = "txtBeforeExplTI";
            this.txtBeforeExplTI.Size = new System.Drawing.Size(81, 20);
            this.txtBeforeExplTI.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtBeforeExplTI, "TI of the player before the explosion");
            this.txtBeforeExplTI.TextChanged += new System.EventHandler(this.txtData_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Actual TI";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Before Explosion TI";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 363);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "Base formulae by Palmyra";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(82, 363);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(39, 12);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Palmyra";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Explosion TI";
            // 
            // txtExplosionTI
            // 
            this.txtExplosionTI.Location = new System.Drawing.Point(144, 140);
            this.txtExplosionTI.Name = "txtExplosionTI";
            this.txtExplosionTI.Size = new System.Drawing.Size(81, 20);
            this.txtExplosionTI.TabIndex = 6;
            this.txtExplosionTI.TextChanged += new System.EventHandler(this.txtData_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 284);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Top (30\'s) ASI";
            // 
            // txtTopASI
            // 
            this.txtTopASI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTopASI.Location = new System.Drawing.Point(145, 281);
            this.txtTopASI.Name = "txtTopASI";
            this.txtTopASI.ReadOnly = true;
            this.txtTopASI.Size = new System.Drawing.Size(81, 20);
            this.txtTopASI.TabIndex = 1;
            // 
            // chkGK
            // 
            this.chkGK.AutoSize = true;
            this.chkGK.Location = new System.Drawing.Point(11, 319);
            this.chkGK.Name = "chkGK";
            this.chkGK.Size = new System.Drawing.Size(82, 17);
            this.chkGK.TabIndex = 8;
            this.chkGK.Text = "GoalKeeper";
            this.chkGK.UseVisualStyleBackColor = true;
            this.chkGK.CheckedChanged += new System.EventHandler(this.chkGK_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(127, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Yrs";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(193, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Months";
            // 
            // txtMonths
            // 
            this.txtMonths.BackColor = System.Drawing.Color.White;
            this.txtMonths.Location = new System.Drawing.Point(155, 9);
            this.txtMonths.Name = "txtMonths";
            this.txtMonths.Size = new System.Drawing.Size(32, 20);
            this.txtMonths.TabIndex = 2;
            this.txtMonths.TextChanged += new System.EventHandler(this.txtAge_TextChanged);
            // 
            // graphASI
            // 
            this.graphASI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.graphASI.Location = new System.Drawing.Point(244, 5);
            this.graphASI.Name = "graphASI";
            this.graphASI.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphASI.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphASI.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.graphASI.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphASI.PointDateFormat = "TY";
            this.graphASI.PointValueFormat = "N2";
            this.graphASI.ScrollMaxX = 0;
            this.graphASI.ScrollMaxY = 0;
            this.graphASI.ScrollMaxY2 = 0;
            this.graphASI.ScrollMinX = 0;
            this.graphASI.ScrollMinY = 0;
            this.graphASI.ScrollMinY2 = 0;
            this.graphASI.Size = new System.Drawing.Size(542, 379);
            this.graphASI.TabIndex = 5;
            this.graphASI.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphASI.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphASI.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphASI.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphASI.ZoomStepFraction = 0.1;
            // 
            // ComputeBloom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 384);
            this.Controls.Add(this.chkGK);
            this.Controls.Add(this.graphASI);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtEndOfBloomASI);
            this.Controls.Add(this.txtTopASI);
            this.Controls.Add(this.txtEndOfBloomSkillSum);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAgeStartOfBloom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBeforeExplTI);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtExplosionTI);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtActualTI);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAfterBloomingTI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCurrentSkillSum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMonths);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtActualASI);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Name = "ComputeBloom";
            this.Text = "Bloom Calculator";
            this.Load += new System.EventHandler(this.ComputeBloom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtActualASI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrentSkillSum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAfterBloomingTI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAgeStartOfBloom;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEndOfBloomSkillSum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEndOfBloomASI;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtActualTI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBeforeExplTI;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtExplosionTI;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTopASI;
        private ZedGraph.ZedGraphControl graphASI;
        private System.Windows.Forms.CheckBox chkGK;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMonths;
    }
}