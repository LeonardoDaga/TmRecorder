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
            this.ntR_Browser1 = new NTR_Browser.NTR_Browser();
            this.btnOpenDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ntR_Browser1
            // 
            this.ntR_Browser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ntR_Browser1.DefaultDirectory = "";
            this.ntR_Browser1.Location = new System.Drawing.Point(0, 34);
            this.ntR_Browser1.MainTeamId = 0;
            this.ntR_Browser1.Name = "ntR_Browser1";
            this.ntR_Browser1.NavigationAddress = "";
            this.ntR_Browser1.NavigationMode = NTR_Browser.NTR_Browser.eNavigationMode.Main;
            this.ntR_Browser1.RatingVersion = Common.eRatingVersion.None;
            this.ntR_Browser1.SelectedReportParser = null;
            this.ntR_Browser1.ShowShortlist = true;
            this.ntR_Browser1.ShowTransfer = true;
            this.ntR_Browser1.Size = new System.Drawing.Size(761, 325);
            this.ntR_Browser1.StartnavigationAddress = "";
            this.ntR_Browser1.TabIndex = 0;
            // 
            // btnOpenDialog
            // 
            this.btnOpenDialog.Location = new System.Drawing.Point(6, 5);
            this.btnOpenDialog.Name = "btnOpenDialog";
            this.btnOpenDialog.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDialog.TabIndex = 1;
            this.btnOpenDialog.Text = "Open Dialog";
            this.btnOpenDialog.UseVisualStyleBackColor = true;
            this.btnOpenDialog.Click += new System.EventHandler(this.btnOpenDialog_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 359);
            this.Controls.Add(this.btnOpenDialog);
            this.Controls.Add(this.ntR_Browser1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private NTR_Browser.NTR_Browser ntR_Browser1;
        private System.Windows.Forms.Button btnOpenDialog;
    }
}