namespace DataGridViewCustomColumns
{
    partial class TMR_MatchTypeColumn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMR_MatchTypeColumn));
            this.matchTypeImageList = new System.Windows.Forms.ImageList(this.components);
            // 
            // matchTypeImageList
            // 
            this.matchTypeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("matchTypeImageList.ImageStream")));
            this.matchTypeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.matchTypeImageList.Images.SetKeyName(0, "L.png");
            this.matchTypeImageList.Images.SetKeyName(1, "C.png");
            this.matchTypeImageList.Images.SetKeyName(2, "F.png");
            this.matchTypeImageList.Images.SetKeyName(3, "FL.png");
            this.matchTypeImageList.Images.SetKeyName(4, "LL.png");

        }

        #endregion

        public System.Windows.Forms.ImageList matchTypeImageList;



    }
}
