namespace TransferManager
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGainSet = new System.Windows.Forms.TextBox();
            this.btnGainSet = new System.Windows.Forms.Button();
            this.chkNormalizeGains = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlarmFile = new System.Windows.Forms.TextBox();
            this.btnAlarmFile = new System.Windows.Forms.Button();
            this.chkPlaySound = new System.Windows.Forms.CheckBox();
            this.cbDefaultNation = new System.Windows.Forms.ComboBox();
            this.nationNamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.Options = new Common.OptionsDS();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAutoLoadAndSave = new System.Windows.Forms.CheckBox();
            this.chkEvidenceGain = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nationNamesBindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.Options)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(247, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(328, 199);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "GainSet";
            // 
            // txtGainSet
            // 
            this.txtGainSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGainSet.Location = new System.Drawing.Point(63, 6);
            this.txtGainSet.Name = "txtGainSet";
            this.txtGainSet.Size = new System.Drawing.Size(320, 20);
            this.txtGainSet.TabIndex = 2;
            // 
            // btnGainSet
            // 
            this.btnGainSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGainSet.Location = new System.Drawing.Point(381, 4);
            this.btnGainSet.Name = "btnGainSet";
            this.btnGainSet.Size = new System.Drawing.Size(24, 23);
            this.btnGainSet.TabIndex = 3;
            this.btnGainSet.Text = "...";
            this.btnGainSet.UseVisualStyleBackColor = true;
            this.btnGainSet.Click += new System.EventHandler(this.btnGainSet_Click);
            // 
            // chkNormalizeGains
            // 
            this.chkNormalizeGains.AutoSize = true;
            this.chkNormalizeGains.Location = new System.Drawing.Point(63, 32);
            this.chkNormalizeGains.Name = "chkNormalizeGains";
            this.chkNormalizeGains.Size = new System.Drawing.Size(102, 17);
            this.chkNormalizeGains.TabIndex = 4;
            this.chkNormalizeGains.Text = "Normalize Gains";
            this.chkNormalizeGains.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Alarm Ring File";
            // 
            // txtAlarmFile
            // 
            this.txtAlarmFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlarmFile.Location = new System.Drawing.Point(95, 55);
            this.txtAlarmFile.Name = "txtAlarmFile";
            this.txtAlarmFile.Size = new System.Drawing.Size(288, 20);
            this.txtAlarmFile.TabIndex = 2;
            // 
            // btnAlarmFile
            // 
            this.btnAlarmFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlarmFile.Location = new System.Drawing.Point(381, 53);
            this.btnAlarmFile.Name = "btnAlarmFile";
            this.btnAlarmFile.Size = new System.Drawing.Size(24, 23);
            this.btnAlarmFile.TabIndex = 3;
            this.btnAlarmFile.Text = "...";
            this.btnAlarmFile.UseVisualStyleBackColor = true;
            this.btnAlarmFile.Click += new System.EventHandler(this.btnAlarmFile_Click);
            // 
            // chkPlaySound
            // 
            this.chkPlaySound.AutoSize = true;
            this.chkPlaySound.Location = new System.Drawing.Point(95, 81);
            this.chkPlaySound.Name = "chkPlaySound";
            this.chkPlaySound.Size = new System.Drawing.Size(80, 17);
            this.chkPlaySound.TabIndex = 4;
            this.chkPlaySound.Text = "Play Sound";
            this.chkPlaySound.UseVisualStyleBackColor = true;
            // 
            // cbDefaultNation
            // 
            this.cbDefaultNation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDefaultNation.DataSource = this.nationNamesBindingSource;
            this.cbDefaultNation.DisplayMember = "Name";
            this.cbDefaultNation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefaultNation.FormattingEnabled = true;
            this.cbDefaultNation.Location = new System.Drawing.Point(137, 104);
            this.cbDefaultNation.Name = "cbDefaultNation";
            this.cbDefaultNation.Size = new System.Drawing.Size(268, 21);
            this.cbDefaultNation.TabIndex = 6;
            this.cbDefaultNation.ValueMember = "Abbreviation";
            // 
            // nationNamesBindingSource
            // 
            this.nationNamesBindingSource.DataMember = "NationNames";
            this.nationNamesBindingSource.DataSource = null;
            //// 
            //// Options
            //// 
            //this.Options.DataSetName = "DataSet1";
            //this.Options.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Default Player Nation";
            // 
            // chkAutoLoadAndSave
            // 
            this.chkAutoLoadAndSave.AutoSize = true;
            this.chkAutoLoadAndSave.Location = new System.Drawing.Point(12, 138);
            this.chkAutoLoadAndSave.Name = "chkAutoLoadAndSave";
            this.chkAutoLoadAndSave.Size = new System.Drawing.Size(219, 17);
            this.chkAutoLoadAndSave.TabIndex = 4;
            this.chkAutoLoadAndSave.Text = "Save and Load automatically last Search";
            this.chkAutoLoadAndSave.UseVisualStyleBackColor = true;
            // 
            // chkEvidenceGain
            // 
            this.chkEvidenceGain.AutoSize = true;
            this.chkEvidenceGain.Location = new System.Drawing.Point(12, 161);
            this.chkEvidenceGain.Name = "chkEvidenceGain";
            this.chkEvidenceGain.Size = new System.Drawing.Size(191, 17);
            this.chkEvidenceGain.TabIndex = 7;
            this.chkEvidenceGain.Text = "Evidence Gain on the players table";
            this.chkEvidenceGain.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(415, 234);
            this.Controls.Add(this.chkEvidenceGain);
            this.Controls.Add(this.cbDefaultNation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkPlaySound);
            this.Controls.Add(this.chkAutoLoadAndSave);
            this.Controls.Add(this.chkNormalizeGains);
            this.Controls.Add(this.btnAlarmFile);
            this.Controls.Add(this.btnGainSet);
            this.Controls.Add(this.txtAlarmFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGainSet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsForm";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.nationNamesBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.Options)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGainSet;
        private System.Windows.Forms.Button btnGainSet;
        private System.Windows.Forms.CheckBox chkNormalizeGains;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAlarmFile;
        private System.Windows.Forms.Button btnAlarmFile;
        private System.Windows.Forms.CheckBox chkPlaySound;
        private System.Windows.Forms.ComboBox cbDefaultNation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource nationNamesBindingSource;
        private System.Windows.Forms.CheckBox chkAutoLoadAndSave;
        private System.Windows.Forms.CheckBox chkEvidenceGain;
    }
}