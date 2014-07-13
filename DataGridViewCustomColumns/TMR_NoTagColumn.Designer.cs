namespace DataGridViewCustomColumns
{
    partial class TMR_NoTagColumn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMR_NoTagColumn));
            this.actionsImgList = new System.Windows.Forms.ImageList(this.components);
            // 
            // actionsImgList
            // 
            this.actionsImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("actionsImgList.ImageStream")));
            this.actionsImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.actionsImgList.Images.SetKeyName(0, "me_shot.gif");
            this.actionsImgList.Images.SetKeyName(1, "me_shotoff.gif");
            this.actionsImgList.Images.SetKeyName(2, "me_skade.gif");
            this.actionsImgList.Images.SetKeyName(3, "me_sub.gif");
            this.actionsImgList.Images.SetKeyName(4, "me_yellow2.gif");
            this.actionsImgList.Images.SetKeyName(5, "me_yellow.gif");
            this.actionsImgList.Images.SetKeyName(6, "me_chance2.gif");
            this.actionsImgList.Images.SetKeyName(7, "me_goal2.gif");

        }

        #endregion

        public System.Windows.Forms.ImageList actionsImgList;





    }
}
