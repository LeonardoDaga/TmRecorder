namespace DataGridViewCustomColumns
{
    partial class TMR_ArrowColumn
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMR_ArrowColumn));
            this.arrowIcons = new System.Windows.Forms.ImageList(this.components);
            // 
            // arrowIcons
            // 
            this.arrowIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("arrowIcons.ImageStream")));
            this.arrowIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.arrowIcons.Images.SetKeyName(0, "BigStepUp.ico");
            this.arrowIcons.Images.SetKeyName(1, "SmallStepUp.ico");
            this.arrowIcons.Images.SetKeyName(2, "SmallStepDown.ico");
            this.arrowIcons.Images.SetKeyName(3, "BigStepDown.ico");
            this.arrowIcons.Images.SetKeyName(4, "NoStep.ico");

        }

        #endregion

        public System.Windows.Forms.ImageList arrowIcons;








    }
}
