namespace TmRecorder3
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.cbDefaultNation = new System.Windows.Forms.ComboBox();
            this.nationNamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbPro = new System.Windows.Forms.RadioButton();
            this.rbNonPro = new System.Windows.Forms.RadioButton();
            this.txtReserveSquadID = new System.Windows.Forms.TextBox();
            this.txtMainSquadID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtReserveSquadName = new System.Windows.Forms.TextBox();
            this.txtMainSquadName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabFolders = new System.Windows.Forms.TabPage();
            this.btnSelectDataDirectory = new System.Windows.Forms.Button();
            this.txtDataDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabGainSet = new System.Windows.Forms.TabPage();
            this.lbGainSet = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.cmbRoutineFunction = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtRoutineParameters = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkEvidenceGains = new System.Windows.Forms.CheckBox();
            this.chkNormalizeGains = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nationNamesBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabFolders.SuspendLayout();
            this.tabGainSet.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabFolders);
            this.tabControl.Controls.Add(this.tabGainSet);
            this.tabControl.Location = new System.Drawing.Point(0, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(657, 310);
            this.tabControl.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.cbDefaultNation);
            this.tabMain.Controls.Add(this.label2);
            this.tabMain.Controls.Add(this.groupBox3);
            this.tabMain.Controls.Add(this.txtReserveSquadID);
            this.tabMain.Controls.Add(this.txtMainSquadID);
            this.tabMain.Controls.Add(this.label11);
            this.tabMain.Controls.Add(this.txtReserveSquadName);
            this.tabMain.Controls.Add(this.txtMainSquadName);
            this.tabMain.Controls.Add(this.label10);
            this.tabMain.Controls.Add(this.label12);
            this.tabMain.Controls.Add(this.label9);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(649, 284);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // cbDefaultNation
            // 
            this.cbDefaultNation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDefaultNation.DataSource = this.nationNamesBindingSource;
            this.cbDefaultNation.DisplayMember = "Abbreviation";
            this.cbDefaultNation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefaultNation.FormattingEnabled = true;
            this.cbDefaultNation.Location = new System.Drawing.Point(443, 21);
            this.cbDefaultNation.Name = "cbDefaultNation";
            this.cbDefaultNation.Size = new System.Drawing.Size(198, 21);
            this.cbDefaultNation.TabIndex = 13;
            this.cbDefaultNation.ValueMember = "Abbreviation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Default Player Nation";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbPro);
            this.groupBox3.Controls.Add(this.rbNonPro);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(207, 48);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User Type";
            // 
            // rbPro
            // 
            this.rbPro.AutoSize = true;
            this.rbPro.Location = new System.Drawing.Point(131, 19);
            this.rbPro.Name = "rbPro";
            this.rbPro.Size = new System.Drawing.Size(48, 17);
            this.rbPro.TabIndex = 0;
            this.rbPro.TabStop = true;
            this.rbPro.Text = "PRO";
            this.rbPro.UseVisualStyleBackColor = true;
            // 
            // rbNonPro
            // 
            this.rbNonPro.AutoSize = true;
            this.rbNonPro.Location = new System.Drawing.Point(20, 19);
            this.rbNonPro.Name = "rbNonPro";
            this.rbNonPro.Size = new System.Drawing.Size(71, 17);
            this.rbNonPro.TabIndex = 0;
            this.rbNonPro.TabStop = true;
            this.rbNonPro.Text = "Non PRO";
            this.rbNonPro.UseVisualStyleBackColor = true;
            // 
            // txtReserveSquadID
            // 
            this.txtReserveSquadID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReserveSquadID.Location = new System.Drawing.Point(527, 102);
            this.txtReserveSquadID.Name = "txtReserveSquadID";
            this.txtReserveSquadID.Size = new System.Drawing.Size(114, 20);
            this.txtReserveSquadID.TabIndex = 7;
            // 
            // txtMainSquadID
            // 
            this.txtMainSquadID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMainSquadID.Location = new System.Drawing.Point(527, 76);
            this.txtMainSquadID.Name = "txtMainSquadID";
            this.txtMainSquadID.Size = new System.Drawing.Size(114, 20);
            this.txtMainSquadID.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(524, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "ID";
            // 
            // txtReserveSquadName
            // 
            this.txtReserveSquadName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReserveSquadName.Location = new System.Drawing.Point(96, 102);
            this.txtReserveSquadName.Name = "txtReserveSquadName";
            this.txtReserveSquadName.Size = new System.Drawing.Size(425, 20);
            this.txtReserveSquadName.TabIndex = 9;
            // 
            // txtMainSquadName
            // 
            this.txtMainSquadName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMainSquadName.Location = new System.Drawing.Point(96, 76);
            this.txtMainSquadName.Name = "txtMainSquadName";
            this.txtMainSquadName.Size = new System.Drawing.Size(425, 20);
            this.txtMainSquadName.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(93, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Reserve Squad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Main Squad";
            // 
            // tabFolders
            // 
            this.tabFolders.Controls.Add(this.btnSelectDataDirectory);
            this.tabFolders.Controls.Add(this.txtDataDirectory);
            this.tabFolders.Controls.Add(this.label1);
            this.tabFolders.Location = new System.Drawing.Point(4, 22);
            this.tabFolders.Name = "tabFolders";
            this.tabFolders.Padding = new System.Windows.Forms.Padding(3);
            this.tabFolders.Size = new System.Drawing.Size(649, 284);
            this.tabFolders.TabIndex = 1;
            this.tabFolders.Text = "Folders";
            this.tabFolders.UseVisualStyleBackColor = true;
            // 
            // btnSelectDataDirectory
            // 
            this.btnSelectDataDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectDataDirectory.Location = new System.Drawing.Point(613, 10);
            this.btnSelectDataDirectory.Name = "btnSelectDataDirectory";
            this.btnSelectDataDirectory.Size = new System.Drawing.Size(28, 21);
            this.btnSelectDataDirectory.TabIndex = 5;
            this.btnSelectDataDirectory.Text = "...";
            this.btnSelectDataDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDataDirectory.Click += new System.EventHandler(this.btnSelectDataDirectory_Click);
            // 
            // txtDataDirectory
            // 
            this.txtDataDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataDirectory.Location = new System.Drawing.Point(123, 11);
            this.txtDataDirectory.Name = "txtDataDirectory";
            this.txtDataDirectory.Size = new System.Drawing.Size(484, 20);
            this.txtDataDirectory.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Data Directory";
            // 
            // tabGainSet
            // 
            this.tabGainSet.Controls.Add(this.lbGainSet);
            this.tabGainSet.Controls.Add(this.groupBox4);
            this.tabGainSet.Controls.Add(this.label3);
            this.tabGainSet.Controls.Add(this.chkEvidenceGains);
            this.tabGainSet.Controls.Add(this.chkNormalizeGains);
            this.tabGainSet.Location = new System.Drawing.Point(4, 22);
            this.tabGainSet.Name = "tabGainSet";
            this.tabGainSet.Padding = new System.Windows.Forms.Padding(3);
            this.tabGainSet.Size = new System.Drawing.Size(649, 284);
            this.tabGainSet.TabIndex = 2;
            this.tabGainSet.Text = "Gain Set";
            this.tabGainSet.UseVisualStyleBackColor = true;
            // 
            // lbGainSet
            // 
            this.lbGainSet.FormattingEnabled = true;
            this.lbGainSet.Items.AddRange(new object[] {
            "Default",
            "RusCheratte",
            "Led_2"});
            this.lbGainSet.Location = new System.Drawing.Point(61, 8);
            this.lbGainSet.Name = "lbGainSet";
            this.lbGainSet.Size = new System.Drawing.Size(310, 95);
            this.lbGainSet.TabIndex = 12;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.cmbRoutineFunction);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.txtRoutineParameters);
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox4.Location = new System.Drawing.Point(10, 155);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(605, 100);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Routine";
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.SystemColors.Control;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label33.Location = new System.Drawing.Point(7, 41);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(592, 56);
            this.label33.TabIndex = 11;
            this.label33.Text = resources.GetString("label33.Text");
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(350, 20);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(48, 13);
            this.label32.TabIndex = 7;
            this.label32.Text = "Function";
            // 
            // cmbRoutineFunction
            // 
            this.cmbRoutineFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoutineFunction.ForeColor = System.Drawing.Color.Black;
            this.cmbRoutineFunction.FormattingEnabled = true;
            this.cmbRoutineFunction.Items.AddRange(new object[] {
            "Linear (P0 + X*P1)",
            "Exponential (P0 + P1*exp(P2*X + P3))",
            "Logarithm (P0 + P1*log10(P2*X + P3))",
            "Quadratic (P0 + P1*X + P2*X^2)"});
            this.cmbRoutineFunction.Location = new System.Drawing.Point(404, 17);
            this.cmbRoutineFunction.Name = "cmbRoutineFunction";
            this.cmbRoutineFunction.Size = new System.Drawing.Size(195, 21);
            this.cmbRoutineFunction.TabIndex = 10;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(7, 20);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(60, 13);
            this.label31.TabIndex = 7;
            this.label31.Text = "Parameters";
            // 
            // txtRoutineParameters
            // 
            this.txtRoutineParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoutineParameters.ForeColor = System.Drawing.Color.Black;
            this.txtRoutineParameters.Location = new System.Drawing.Point(73, 17);
            this.txtRoutineParameters.Name = "txtRoutineParameters";
            this.txtRoutineParameters.Size = new System.Drawing.Size(179, 20);
            this.txtRoutineParameters.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Gain Set";
            // 
            // chkEvidenceGains
            // 
            this.chkEvidenceGains.AutoSize = true;
            this.chkEvidenceGains.Location = new System.Drawing.Point(390, 35);
            this.chkEvidenceGains.Name = "chkEvidenceGains";
            this.chkEvidenceGains.Size = new System.Drawing.Size(191, 17);
            this.chkEvidenceGains.TabIndex = 6;
            this.chkEvidenceGains.Text = "Evidence Gain on the players table";
            this.chkEvidenceGains.UseVisualStyleBackColor = true;
            // 
            // chkNormalizeGains
            // 
            this.chkNormalizeGains.AutoSize = true;
            this.chkNormalizeGains.Location = new System.Drawing.Point(390, 12);
            this.chkNormalizeGains.Name = "chkNormalizeGains";
            this.chkNormalizeGains.Size = new System.Drawing.Size(102, 17);
            this.chkNormalizeGains.TabIndex = 6;
            this.chkNormalizeGains.Text = "Normalize Gains";
            this.chkNormalizeGains.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(486, 317);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(578, 317);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(657, 347);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl);
            this.Name = "OptionsForm";
            this.Text = "OptionsForm";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nationNamesBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabFolders.ResumeLayout(false);
            this.tabFolders.PerformLayout();
            this.tabGainSet.ResumeLayout(false);
            this.tabGainSet.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabFolders;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbPro;
        private System.Windows.Forms.RadioButton rbNonPro;
        private System.Windows.Forms.TextBox txtReserveSquadID;
        private System.Windows.Forms.TextBox txtMainSquadID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtReserveSquadName;
        private System.Windows.Forms.TextBox txtMainSquadName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbDefaultNation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabGainSet;
        private System.Windows.Forms.ListBox lbGainSet;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox cmbRoutineFunction;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtRoutineParameters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkEvidenceGains;
        private System.Windows.Forms.CheckBox chkNormalizeGains;
        private System.Windows.Forms.Button btnSelectDataDirectory;
        private System.Windows.Forms.TextBox txtDataDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.BindingSource nationNamesBindingSource;
    }
}