namespace LicenseCodeComputer
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdTeam = new System.Windows.Forms.TextBox();
            this.btnComputeCode = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodes = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Team";
            // 
            // txtIdTeam
            // 
            this.txtIdTeam.Location = new System.Drawing.Point(85, 16);
            this.txtIdTeam.Name = "txtIdTeam";
            this.txtIdTeam.Size = new System.Drawing.Size(187, 20);
            this.txtIdTeam.TabIndex = 1;
            // 
            // btnComputeCode
            // 
            this.btnComputeCode.Location = new System.Drawing.Point(278, 13);
            this.btnComputeCode.Name = "btnComputeCode";
            this.btnComputeCode.Size = new System.Drawing.Size(75, 23);
            this.btnComputeCode.TabIndex = 2;
            this.btnComputeCode.Text = "Compute";
            this.btnComputeCode.UseVisualStyleBackColor = true;
            this.btnComputeCode.Click += new System.EventHandler(this.btnComputeCode_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(130, 19);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(75, 23);
            this.btnPaste.TabIndex = 3;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodes);
            this.groupBox1.Controls.Add(this.btnPaste);
            this.groupBox1.Location = new System.Drawing.Point(15, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 232);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paste & Data";
            // 
            // txtCodes
            // 
            this.txtCodes.Location = new System.Drawing.Point(6, 50);
            this.txtCodes.Multiline = true;
            this.txtCodes.Name = "txtCodes";
            this.txtCodes.Size = new System.Drawing.Size(332, 176);
            this.txtCodes.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 286);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnComputeCode);
            this.Controls.Add(this.txtIdTeam);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Code Computer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdTeam;
        private System.Windows.Forms.Button btnComputeCode;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCodes;
    }
}

