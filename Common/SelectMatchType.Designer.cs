namespace Common
{
    partial class SelectMatchType
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbInternationalMatch = new System.Windows.Forms.RadioButton();
            this.rbFriendlyLeagueMatch = new System.Windows.Forms.RadioButton();
            this.rbFriendlyMatch = new System.Windows.Forms.RadioButton();
            this.rbCupMatch = new System.Windows.Forms.RadioButton();
            this.rbLeagueMatch = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Match Type Name";
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.SystemColors.Info;
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName.Location = new System.Drawing.Point(12, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(134, 21);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbInternationalMatch);
            this.groupBox1.Controls.Add(this.rbFriendlyLeagueMatch);
            this.groupBox1.Controls.Add(this.rbFriendlyMatch);
            this.groupBox1.Controls.Add(this.rbCupMatch);
            this.groupBox1.Controls.Add(this.rbLeagueMatch);
            this.groupBox1.Location = new System.Drawing.Point(200, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 142);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Match Types";
            // 
            // rbInternationalMatch
            // 
            this.rbInternationalMatch.AutoSize = true;
            this.rbInternationalMatch.Location = new System.Drawing.Point(11, 114);
            this.rbInternationalMatch.Name = "rbInternationalMatch";
            this.rbInternationalMatch.Size = new System.Drawing.Size(116, 17);
            this.rbInternationalMatch.TabIndex = 0;
            this.rbInternationalMatch.TabStop = true;
            this.rbInternationalMatch.Text = "International Match";
            this.rbInternationalMatch.UseVisualStyleBackColor = true;
            // 
            // rbFriendlyLeagueMatch
            // 
            this.rbFriendlyLeagueMatch.AutoSize = true;
            this.rbFriendlyLeagueMatch.Location = new System.Drawing.Point(11, 91);
            this.rbFriendlyLeagueMatch.Name = "rbFriendlyLeagueMatch";
            this.rbFriendlyLeagueMatch.Size = new System.Drawing.Size(133, 17);
            this.rbFriendlyLeagueMatch.TabIndex = 0;
            this.rbFriendlyLeagueMatch.TabStop = true;
            this.rbFriendlyLeagueMatch.Text = "Friendly League Match";
            this.rbFriendlyLeagueMatch.UseVisualStyleBackColor = true;
            // 
            // rbFriendlyMatch
            // 
            this.rbFriendlyMatch.AutoSize = true;
            this.rbFriendlyMatch.Location = new System.Drawing.Point(11, 68);
            this.rbFriendlyMatch.Name = "rbFriendlyMatch";
            this.rbFriendlyMatch.Size = new System.Drawing.Size(94, 17);
            this.rbFriendlyMatch.TabIndex = 0;
            this.rbFriendlyMatch.TabStop = true;
            this.rbFriendlyMatch.Text = "Friendly Match";
            this.rbFriendlyMatch.UseVisualStyleBackColor = true;
            // 
            // rbCupMatch
            // 
            this.rbCupMatch.AutoSize = true;
            this.rbCupMatch.Location = new System.Drawing.Point(11, 45);
            this.rbCupMatch.Name = "rbCupMatch";
            this.rbCupMatch.Size = new System.Drawing.Size(77, 17);
            this.rbCupMatch.TabIndex = 0;
            this.rbCupMatch.TabStop = true;
            this.rbCupMatch.Text = "Cup Match";
            this.rbCupMatch.UseVisualStyleBackColor = true;
            // 
            // rbLeagueMatch
            // 
            this.rbLeagueMatch.AutoSize = true;
            this.rbLeagueMatch.Checked = true;
            this.rbLeagueMatch.Location = new System.Drawing.Point(11, 22);
            this.rbLeagueMatch.Name = "rbLeagueMatch";
            this.rbLeagueMatch.Size = new System.Drawing.Size(94, 17);
            this.rbLeagueMatch.TabIndex = 0;
            this.rbLeagueMatch.TabStop = true;
            this.rbLeagueMatch.Text = "League Match";
            this.rbLeagueMatch.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(325, 160);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(12, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 95);
            this.label8.TabIndex = 17;
            this.label8.Text = "Select the appropriate type of match corresponding to the\r\nstring in the yellow b" +
                "ox. This selection is to help TmRecorder \r\nto recognize the type of match in the" +
                " match list.";
            // 
            // SelectMatchType
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 193);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Name = "SelectMatchType";
            this.Text = "SelectMatchType";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCupMatch;
        private System.Windows.Forms.RadioButton rbLeagueMatch;
        private System.Windows.Forms.RadioButton rbFriendlyMatch;
        private System.Windows.Forms.RadioButton rbInternationalMatch;
        private System.Windows.Forms.RadioButton rbFriendlyLeagueMatch;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label8;
    }
}