namespace NTR_Controls
{
    partial class NTR_BloomColumn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NTR_BloomColumn));
            this.statusList = new System.Windows.Forms.ImageList(this.components);
            // 
            // statusList
            // 
            this.statusList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("statusList.ImageStream")));
            this.statusList.TransparentColor = System.Drawing.Color.Transparent;
            this.statusList.Images.SetKeyName(0, "YellowCard.ico");
            this.statusList.Images.SetKeyName(1, "RedCard.ico");
            this.statusList.Images.SetKeyName(2, "Injuried.ico");

        }

        #endregion

        public System.Windows.Forms.ImageList statusList;

    }
}
