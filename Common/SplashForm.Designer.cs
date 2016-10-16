namespace Common
{
    partial class SplashForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 300);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Rempart De La Vierge.9.gif");
            this.imageList.Images.SetKeyName(1, "Croft Town.25.gif");
            this.imageList.Images.SetKeyName(2, "FC FOLKSTON.16.gif");
            this.imageList.Images.SetKeyName(3, "Quartu Sant\'Elena FC.16.gif");
            this.imageList.Images.SetKeyName(4, "Eclipse Grey.9.gif");
            this.imageList.Images.SetKeyName(5, "Donald Duck.8.gif");
            this.imageList.Images.SetKeyName(6, "Atlanta Chiefs.3..gif");
            this.imageList.Images.SetKeyName(7, "Cuana ELOI.25.gif");
            this.imageList.Images.SetKeyName(8, "Forum Sempronii.90.gif");
            this.imageList.Images.SetKeyName(9, "Juvelions.8.gif");
            this.imageList.Images.SetKeyName(10, "Rio FC.43.gif");
            this.imageList.Images.SetKeyName(11, "°°°Cremonese°°°.48.gif");
            this.imageList.Images.SetKeyName(12, "Centenario FC Milano.27.gif");
            this.imageList.Images.SetKeyName(13, "HK Friendship.8.gif");
            this.imageList.Images.SetKeyName(14, "Los Moros.136.gif");
            this.imageList.Images.SetKeyName(15, "MEGAS ALEXANDROS.61.gif");
            this.imageList.Images.SetKeyName(16, "CHAMPIONS™.17.bmp");
            this.imageList.Images.SetKeyName(17, "Ottawa City United.26.gif");
            this.imageList.Images.SetKeyName(18, "Hansa Rockstadt.200.gif");
            this.imageList.Images.SetKeyName(19, "Moloneys Cojones.17.gif");
            this.imageList.Images.SetKeyName(20, "CF Mascalzone.50.gif");
            this.imageList.Images.SetKeyName(21, "Borgo Cervaro Calcio Champagne.50.png");
            this.imageList.Images.SetKeyName(22, "Lost Bodies.5.png");
            this.imageList.Images.SetKeyName(23, "Rapid Dragasani.10.png");
            this.imageList.Images.SetKeyName(24, "Sansonese Calcio.8.png");
            this.imageList.Images.SetKeyName(25, "Sottomarina.10.png");
            this.imageList.Images.SetKeyName(26, "Circo ~ III ~ Ratti.200.png");
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(338, 122);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Desktop;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(338, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Supporters of TMR: Rempart del a Vierge";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashForm";
            this.Text = "SplashForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}