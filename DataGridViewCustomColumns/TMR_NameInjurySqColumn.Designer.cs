namespace DataGridViewCustomColumns
{
    partial class TMR_NameInjurySqColumn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMR_NameInjurySqColumn));
            this.statusList = new System.Windows.Forms.ImageList(this.components);
            this.matchImgList = new System.Windows.Forms.ImageList(this.components);
            // 
            // statusList
            // 
            this.statusList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("statusList.ImageStream")));
            this.statusList.TransparentColor = System.Drawing.Color.Transparent;
            this.statusList.Images.SetKeyName(0, "YellowCard1.ico");
            this.statusList.Images.SetKeyName(1, "YellowCard2.ico");
            this.statusList.Images.SetKeyName(2, "YellowCard.ico");
            this.statusList.Images.SetKeyName(3, "RedCard.ico");
            this.statusList.Images.SetKeyName(4, "Injuried.ico");
            this.statusList.Images.SetKeyName(5, "Retire.ico");
            // 
            // matchImgList
            // 
            this.matchImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("matchImgList.ImageStream")));
            this.matchImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.matchImgList.Images.SetKeyName(0, "RedCard.png");
            this.matchImgList.Images.SetKeyName(1, "YellowCard.png");
            this.matchImgList.Images.SetKeyName(2, "YellowRed.png");
            this.matchImgList.Images.SetKeyName(3, "Goal.png");

        }

        #endregion

        public System.Windows.Forms.ImageList statusList;
        public System.Windows.Forms.ImageList matchImgList;
    }
}
