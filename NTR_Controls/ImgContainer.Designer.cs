namespace NTR_Controls
{
    partial class ImgContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImgContainer));
            this.starImageList = new System.Windows.Forms.ImageList(this.components);
            this.starRowImgList = new System.Windows.Forms.ImageList(this.components);
            this.matchImageList = new System.Windows.Forms.ImageList(this.components);
            // 
            // starImageList
            // 
            this.starImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("starImageList.ImageStream")));
            this.starImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.starImageList.Images.SetKeyName(0, "1.png");
            this.starImageList.Images.SetKeyName(1, "2.png");
            this.starImageList.Images.SetKeyName(2, "3.png");
            this.starImageList.Images.SetKeyName(3, "4.png");
            this.starImageList.Images.SetKeyName(4, "5.png");
            this.starImageList.Images.SetKeyName(5, "6.png");
            this.starImageList.Images.SetKeyName(6, "7.png");
            this.starImageList.Images.SetKeyName(7, "8.png");
            this.starImageList.Images.SetKeyName(8, "9.png");
            this.starImageList.Images.SetKeyName(9, "10.png");
            // 
            // starRowImgList
            // 
            this.starRowImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("starRowImgList.ImageStream")));
            this.starRowImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.starRowImgList.Images.SetKeyName(0, "0.5.png");
            this.starRowImgList.Images.SetKeyName(1, "1.0.png");
            this.starRowImgList.Images.SetKeyName(2, "1.5.png");
            this.starRowImgList.Images.SetKeyName(3, "2.0.png");
            this.starRowImgList.Images.SetKeyName(4, "2.5.png");
            this.starRowImgList.Images.SetKeyName(5, "3.0.png");
            this.starRowImgList.Images.SetKeyName(6, "3.5.png");
            this.starRowImgList.Images.SetKeyName(7, "4.0.png");
            this.starRowImgList.Images.SetKeyName(8, "4.5.png");
            this.starRowImgList.Images.SetKeyName(9, "5.0.png");
            // 
            // matchImageList
            // 
            this.matchImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("matchImageList.ImageStream")));
            this.matchImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.matchImageList.Images.SetKeyName(0, "Assist.png");
            this.matchImageList.Images.SetKeyName(1, "GoalGreen.png");
            this.matchImageList.Images.SetKeyName(2, "Goal.png");
            this.matchImageList.Images.SetKeyName(3, "Injury.png");
            this.matchImageList.Images.SetKeyName(4, "Red.png");
            this.matchImageList.Images.SetKeyName(5, "Yellow.png");
            this.matchImageList.Images.SetKeyName(6, "YellowRed.png");
            this.matchImageList.Images.SetKeyName(7, "SubIn.png");
            this.matchImageList.Images.SetKeyName(8, "SubOut.png");

        }

        #endregion

        public System.Windows.Forms.ImageList starImageList;
        public System.Windows.Forms.ImageList starRowImgList;
        public System.Windows.Forms.ImageList matchImageList;
    }
}
