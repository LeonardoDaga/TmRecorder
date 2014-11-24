namespace DataGridViewCustomColumns
{
    partial class TMR_NumDecColumn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMR_NumDecColumn));
            this.iconList1 = new System.Windows.Forms.ImageList(this.components);
            this.iconList2 = new System.Windows.Forms.ImageList(this.components);
            // 
            // iconList1
            // 
            this.iconList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList1.ImageStream")));
            this.iconList1.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList1.Images.SetKeyName(0, "Star.ico");
            this.iconList1.Images.SetKeyName(1, "SilverStar.ico");
            // 
            // iconList2
            // 
            this.iconList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList2.ImageStream")));
            this.iconList2.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList2.Images.SetKeyName(0, "BigStepUp.ico");
            this.iconList2.Images.SetKeyName(1, "SmallStepUp.ico");
            this.iconList2.Images.SetKeyName(2, "SmallStepDown.ico");
            this.iconList2.Images.SetKeyName(3, "BigStepDown.ico");
            this.iconList2.Images.SetKeyName(4, "Unchanged.ico");
            this.iconList2.Images.SetKeyName(5, "New.ico");

        }

        #endregion

        public System.Windows.Forms.ImageList iconList1;
        public System.Windows.Forms.ImageList iconList2;

    }
}
