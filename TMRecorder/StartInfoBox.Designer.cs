namespace TMRecorder
{
    partial class StartInfoBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartInfoBox));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectDataDirectory = new System.Windows.Forms.Button();
            this.txtDataDirectory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.nationNamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbDefaultNation = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nationNamesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(249, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome in TmRecorder!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(760, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            "English;en",
            "Italiano;it",
            "Espanol;es",
            "Français;fr",
            "Portugues;pt"});
            this.cmbLanguage.Location = new System.Drawing.Point(579, 88);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(122, 21);
            this.cmbLanguage.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cmbLanguage, "Your natural language. The most of the program is not traslated, but in the futur" +
                    "e, maybe it will be.");
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(518, 91);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(55, 13);
            this.label35.TabIndex = 4;
            this.label35.Text = "Language";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Squad Nation";
            // 
            // btnSelectDataDirectory
            // 
            this.btnSelectDataDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectDataDirectory.Location = new System.Drawing.Point(675, 123);
            this.btnSelectDataDirectory.Name = "btnSelectDataDirectory";
            this.btnSelectDataDirectory.Size = new System.Drawing.Size(28, 20);
            this.btnSelectDataDirectory.TabIndex = 10;
            this.btnSelectDataDirectory.Text = "...";
            this.toolTip1.SetToolTip(this.btnSelectDataDirectory, "Click to change the folder");
            this.btnSelectDataDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDataDirectory.Click += new System.EventHandler(this.btnSelectDataDirectory_Click);
            // 
            // txtDataDirectory
            // 
            this.txtDataDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataDirectory.Location = new System.Drawing.Point(207, 123);
            this.txtDataDirectory.Name = "txtDataDirectory";
            this.txtDataDirectory.Size = new System.Drawing.Size(462, 20);
            this.txtDataDirectory.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txtDataDirectory, "Normally located in your document folder. It\'s size will grow from time to time, " +
                    "but it will never be so large.");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Squad Data Directory";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(371, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cbDefaultNation
            // 
            this.cbDefaultNation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDefaultNation.DataSource = this.nationNamesBindingSource;
            this.cbDefaultNation.DisplayMember = "Name";
            this.cbDefaultNation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefaultNation.FormattingEnabled = true;
            this.cbDefaultNation.Location = new System.Drawing.Point(170, 88);
            this.cbDefaultNation.Name = "cbDefaultNation";
            this.cbDefaultNation.Size = new System.Drawing.Size(198, 21);
            this.cbDefaultNation.TabIndex = 13;
            this.toolTip1.SetToolTip(this.cbDefaultNation, "This is the default nation of your players");
            this.cbDefaultNation.ValueMember = "Abbreviation";
            // 
            // StartInfoBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 192);
            this.Controls.Add(this.cbDefaultNation);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSelectDataDirectory);
            this.Controls.Add(this.txtDataDirectory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StartInfoBox";
            this.Text = "TmRecorder: Starting information collection";
            ((System.ComponentModel.ISupportInitialize)(this.nationNamesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectDataDirectory;
        private System.Windows.Forms.TextBox txtDataDirectory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.BindingSource nationNamesBindingSource;
        private System.Windows.Forms.ComboBox cbDefaultNation;
    }
}