namespace NTR_Db
{
    partial class ActionDecoder
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
            this.lblActionDescription = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkOutcome = new System.Windows.Forms.CheckedListBox();
            this.chkActionType = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Action Description";
            // 
            // lblActionDescription
            // 
            this.lblActionDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActionDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblActionDescription.Location = new System.Drawing.Point(15, 62);
            this.lblActionDescription.Name = "lblActionDescription";
            this.lblActionDescription.Size = new System.Drawing.Size(536, 65);
            this.lblActionDescription.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(530, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "This is an action that is not recognized by TM Recorder. Please help the applicat" +
    "ion to understand the action type to improve your team\'s statistics.";
            // 
            // chkOutcome
            // 
            this.chkOutcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkOutcome.BackColor = System.Drawing.SystemColors.Control;
            this.chkOutcome.FormattingEnabled = true;
            this.chkOutcome.Items.AddRange(new object[] {
            "Failed attack",
            "Off Shot",
            "In Shot",
            "Goal",
            "Fault",
            "Ban for the opposite team",
            "Injury",
            "No Outcome"});
            this.chkOutcome.Location = new System.Drawing.Point(200, 154);
            this.chkOutcome.Name = "chkOutcome";
            this.chkOutcome.Size = new System.Drawing.Size(164, 124);
            this.chkOutcome.TabIndex = 4;
            // 
            // chkActionType
            // 
            this.chkActionType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkActionType.BackColor = System.Drawing.SystemColors.Control;
            this.chkActionType.FormattingEnabled = true;
            this.chkActionType.Items.AddRange(new object[] {
            "Short Pass",
            "Through Ball",
            "Wing",
            "Long Ball",
            "Counter Attack",
            "Corner",
            "Freekick",
            "GK counterattack",
            "GK long ball attack",
            "Penalty Shot",
            "Penalty Fault",
            "Yellow/Red Card",
            "Injury",
            "Substitution",
            "Not identified"});
            this.chkActionType.Location = new System.Drawing.Point(15, 154);
            this.chkActionType.Name = "chkActionType";
            this.chkActionType.Size = new System.Drawing.Size(164, 229);
            this.chkActionType.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(12, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Action Type";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(197, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Outcome";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(377, 363);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(467, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ActionDecoder
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(563, 394);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkActionType);
            this.Controls.Add(this.chkOutcome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblActionDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ActionDecoder";
            this.Text = "Action Decoder";
            this.Load += new System.EventHandler(this.ActionDecoder_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActionDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox chkOutcome;
        private System.Windows.Forms.CheckedListBox chkActionType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}