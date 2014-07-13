namespace NTR_Forms
{
    partial class SelectNationalityForm
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
            this.cbDefaultNation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bindNationsNames = new System.Windows.Forms.BindingSource(this.components);
            this.nationsDS1 = new Common.NationsDS();
            ((System.ComponentModel.ISupportInitialize)(this.bindNationsNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nationsDS1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDefaultNation
            // 
            this.cbDefaultNation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDefaultNation.DataSource = this.bindNationsNames;
            this.cbDefaultNation.DisplayMember = "Name";
            this.cbDefaultNation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefaultNation.FormattingEnabled = true;
            this.cbDefaultNation.Location = new System.Drawing.Point(12, 34);
            this.cbDefaultNation.Name = "cbDefaultNation";
            this.cbDefaultNation.Size = new System.Drawing.Size(270, 21);
            this.cbDefaultNation.TabIndex = 4;
            this.cbDefaultNation.ValueMember = "Abbreviation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select the nation of your Team";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(126, 61);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(207, 61);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // bindNationsNames
            // 
            this.bindNationsNames.DataMember = "Names";
            this.bindNationsNames.DataSource = this.nationsDS1;
            // 
            // nationsDS1
            // 
            this.nationsDS1.DataSetName = "NationsDS";
            this.nationsDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SelectNationalityForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(294, 93);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDefaultNation);
            this.Name = "SelectNationalityForm";
            this.Text = "Select Nationality";
            ((System.ComponentModel.ISupportInitialize)(this.bindNationsNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nationsDS1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.ComboBox cbDefaultNation;
        private System.Windows.Forms.BindingSource bindNationNames;
        public Common.NationsDS nationsDS;
        private System.Windows.Forms.BindingSource bindNationsNames;
        private Common.NationsDS nationsDS1;
    }
}