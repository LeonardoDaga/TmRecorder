namespace NTR_Controls
{
    partial class MatchStats
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MatchStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MatchStats";
            this.Size = new System.Drawing.Size(257, 184);
            this.Enter += new System.EventHandler(this.MatchStats_Enter);
            this.Leave += new System.EventHandler(this.MatchStats_Leave);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MatchStats_MouseClick);
            this.MouseLeave += new System.EventHandler(this.MatchStats_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MatchStats_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
