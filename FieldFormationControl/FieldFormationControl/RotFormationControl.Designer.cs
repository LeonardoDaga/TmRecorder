namespace FieldFormationControl
{
    partial class RotFormationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RotFormationControl));
            this.matchDS = new Common.MatchDS();
            ((System.ComponentModel.ISupportInitialize)(this.matchDS)).BeginInit();
            this.SuspendLayout();
            // 
            // matchDS
            // 
            this.matchDS.DataSetName = "MatchDS";
            this.matchDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RotFormationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Name = "RotFormationControl";
            this.Size = new System.Drawing.Size(951, 595);
            ((System.ComponentModel.ISupportInitialize)(this.matchDS)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Common.MatchDS matchDS;
    }
}
