using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Common
{
    public partial class SplashForm : Form
    {
        string text1 = "Team Recorder";
        string text2 = "Release 1.15.1.4";
        string text3 = "Loading team history...";
        public int progressvalue = 0;
        int selPict = 0; 


        public SplashForm(string text, string release, string firstmessage)
        {
            text1 = text;
            text2 = release;
            text3 = firstmessage;

            InitializeComponent();

            int cnt = 0;
            int i = 0;

            for (; i<imageList.Images.Count; i++)
            {
                string key = imageList.Images.Keys[i];
                int add = int.Parse(key.Split('.')[1]);

                cnt += add;
            }

            Random rnd = new Random();
            int extracted = rnd.Next(cnt);

            cnt = 0;
            
            for (i = 0; i<imageList.Images.Count; i++)
            {
                string key = imageList.Images.Keys[i];
                int add = int.Parse(key.Split('.')[1]);

                cnt += add;
                if (extracted < cnt)
                    break;
            }

            selPict = i;
            if (selPict == cnt)
                selPict = selPict - 1;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf.Trimming = StringTrimming.None;

            Font f1 = new Font("Sans Serif", 26, FontStyle.Bold);
            Font f2 = new Font("Sans Serif", 16, FontStyle.Bold);
            Font f3 = new Font("Sans Serif", 10, FontStyle.Regular);
            Brush b_blue = new SolidBrush(Color.DarkBlue);
            Brush b_cyan = new SolidBrush(Color.Cyan);
            Brush backg = new SolidBrush(Color.LightGray);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            RectangleF rectE = new RectangleF(12, 269, 426, 20);
            RectangleF rectI = new RectangleF(13, 270, 424, 18);

            e.Graphics.DrawString(text1, f1, b_cyan, new PointF(10, 10));
            e.Graphics.DrawString(text1, f1, b_blue, new PointF(11, 11));
            e.Graphics.DrawString(text2, f2, b_cyan, new PointF(10, 46));
            e.Graphics.DrawString(text2, f2, b_blue, new PointF(11, 47));

            e.Graphics.FillRectangle(backg, rectE);

            rectI.Width = (rectI.Width*progressvalue)/100;
            e.Graphics.FillRectangle(b_cyan, rectI);

            e.Graphics.DrawString(text3, f3, b_blue, rectE, sf);

            this.pictureBox2.Image = imageList.Images[selPict];
            string key = imageList.Images.Keys[selPict];
            this.label1.Text = "Supporters of TMR: " + key.Split('.')[0] + " (" + key.Split('.')[1] + ")";
        }

        public void SetActualBackImage(FileInfo fi)
        {
            this.pictureBox1.Image = Image.FromFile(fi.FullName);
        }

        public void UpdateStatusMessage(int progressVal, string status)
        {
            progressvalue = progressVal;
            text3 = status;
            Rectangle rectE = new Rectangle(12, 269, 426, 20);

            this.Invalidate(rectE);
            this.Refresh();
        }
    }
}