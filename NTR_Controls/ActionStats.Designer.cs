namespace NTR_Controls
{
    partial class ActionsStats
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
            // ActionsStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ActionsStats";
            this.Size = new System.Drawing.Size(300, 305);
            this.Enter += new System.EventHandler(this.ActionsStats_Enter);
            this.Leave += new System.EventHandler(this.ActionsStats_Leave);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ActionsStats_MouseClick);
            this.MouseLeave += new System.EventHandler(this.ActionsStats_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ActionsStats_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
