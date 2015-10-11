namespace NTR_Controls
{
    partial class NTR_TxtAndImgColumn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NTR_TxtAndImgColumn));
            this.statusList = new System.Windows.Forms.ImageList(this.components);
            this.matchImgList = new System.Windows.Forms.ImageList(this.components);
        }

        #endregion

        public System.Windows.Forms.ImageList statusList;
        public System.Windows.Forms.ImageList matchImgList;
    }
}
