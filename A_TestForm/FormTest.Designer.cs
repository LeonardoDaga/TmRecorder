namespace A_TestForm
{
    partial class FormTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            this.rotLineupControl1 = new FieldFormationControl.RotLineupControl();
            this.SuspendLayout();
            // 
            // rotLineupControl1
            // 
            this.rotLineupControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rotLineupControl1.BackgroundImage")));
            this.rotLineupControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rotLineupControl1.Location = new System.Drawing.Point(12, 12);
            this.rotLineupControl1.MatchFile = "";
            this.rotLineupControl1.Name = "rotLineupControl1";
            this.rotLineupControl1.OppFormationType = Common.eFormationTypes.Type_4_4_2;
            this.rotLineupControl1.Size = new System.Drawing.Size(637, 346);
            this.rotLineupControl1.TabIndex = 0;
            this.rotLineupControl1.YourFormationType = Common.eFormationTypes.Type_4_4_2;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 370);
            this.Controls.Add(this.rotLineupControl1);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private FieldFormationControl.RotLineupControl rotLineupControl1;
    }
}