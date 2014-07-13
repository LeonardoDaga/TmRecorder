namespace ULMatchGenerator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rotFormationControl1 = new FieldFormationControl.RotFormationControl();
            this.SuspendLayout();
            // 
            // rotFormationControl1
            // 
            this.rotFormationControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rotFormationControl1.BackgroundImage")));
            this.rotFormationControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rotFormationControl1.Location = new System.Drawing.Point(0, 42);
            this.rotFormationControl1.MatchFile = "";
            this.rotFormationControl1.Name = "rotFormationControl1";
            this.rotFormationControl1.OppFormationType = Common.eFormationTypes.Type_4_4_2;
            this.rotFormationControl1.Size = new System.Drawing.Size(951, 595);
            this.rotFormationControl1.TabIndex = 0;
            this.rotFormationControl1.YourFormationType = Common.eFormationTypes.Type_4_4_2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 637);
            this.Controls.Add(this.rotFormationControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private FieldFormationControl.RotFormationControl rotFormationControl1;
    }
}

