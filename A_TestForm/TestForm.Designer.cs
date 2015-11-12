using A_TestForm.Properties;

namespace A_TestForm
{
    partial class TestForm
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
            this.ntR_Browser1 = new NTR_Controls.NTR_Browser();
            this.SuspendLayout();
            // 
            // ntR_Browser1
            // 
            this.ntR_Browser1.DefaultDirectory = "";
            this.ntR_Browser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntR_Browser1.Location = new System.Drawing.Point(0, 0);
            this.ntR_Browser1.Name = "ntR_Browser1";
            this.ntR_Browser1.Size = new System.Drawing.Size(761, 359);
            this.ntR_Browser1.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 359);
            this.Controls.Add(this.ntR_Browser1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private NTR_Controls.NTR_Browser ntR_Browser1;
    }
}