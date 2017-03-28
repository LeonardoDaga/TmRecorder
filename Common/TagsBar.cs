using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class TagsBar : UserControl
    {
        private string _title = "Title";
        public string Title
        {
            get { return _title; }
            set { _title = value; this.Invalidate(); }
        }

        private decimal _min = 1;
        public decimal Min
        {
            get { return _min; }
            set { _min = value; this.Invalidate(); }
        }

        private decimal _max = 5;
        public decimal Max
        {
            get { return _max; }
            set { _max = value; this.Invalidate(); }
        }

        private decimal _value = 2;
        public decimal Value
        {
            get
            {
                if (_value > 20)
                    _value = 20;
                return _value;
            }
            set
            {
                if (_value > 20)
                    _value = 20;
                else
                    _value = value;
                this.Invalidate();
            }
        }

        private Color _titleColor = Color.DarkMagenta;
        public Color TitleColor
        {
            get { return _titleColor; }
            set
            {
                _titleColor = value;
                this.Invalidate();
            }
        }

        private Color _borderColor = Color.Gray;
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        private Color _fillerColor = Color.Aqua;
        public Color FillerColor
        {
            get { return _fillerColor; }
            set { _fillerColor = value; this.Invalidate(); }
        }

        private Color _textColor = Color.DarkBlue;
        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; this.Invalidate(); }
        }

        private List<string> _tags = new List<string>();
        public List<string> Tags
        {
            get { return _tags; }
            set { _tags = value; this.Invalidate(); }
        }
        
        public TagsBar()
        {
            InitializeComponent();

            for (int i = (int)Min; i <= Max + 1.01M; i++)
            {
                _tags.Add("No. " + i.ToString());
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush brText = new SolidBrush(_textColor);
            Brush brTitle = new SolidBrush(_titleColor);

            // Draw the number
            SizeF szf = e.Graphics.MeasureString("Test", this.Font);

            int start = (int)(szf.Height + szf.Height/2 + 2);
            int recHeigth = this.ClientSize.Height - start - (int)(szf.Height / 2) - 2;

            // Fill the rectangle
            Brush brFiller = new SolidBrush(FillerColor);
            int len = (int)(((recHeigth) * (Value - Min)) / (Max - Min));
            e.Graphics.FillRectangle(brFiller, new Rectangle(1, start + recHeigth - len, 12, len));

            // Draw the border
            Pen penBorder = new Pen(BorderColor);
            e.Graphics.DrawRectangle(penBorder, new Rectangle(1, start, 12, recHeigth));

            // Draw the cursor
            e.Graphics.DrawRectangle(penBorder, new Rectangle(0, start + recHeigth - len - 2, 14, 4));
            e.Graphics.DrawRectangle(penBorder, new Rectangle(1, start + recHeigth - len - 1, 12, 2));

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Near;

            // Draw the Title
            RectangleF titleText = new RectangleF(0, 0, (float)this.ClientSize.Width, szf.Height);
            e.Graphics.DrawString(_title, this.Font, brTitle, titleText, sf);

            // Drawing the items
            float count = 0;
            float tot = (float)Tags.Count;
            foreach (string tag in Tags)
            {
                // Draw the corresponding line
                int pos = start + recHeigth - (int)((float)recHeigth / (tot-1) * count);
                Point p1 = new Point(11, pos);
                Point p2 = new Point(14, pos);
                e.Graphics.DrawLine(penBorder, p1, p2);

                RectangleF rectText = new RectangleF(15, pos - szf.Height / 2, (float)this.ClientSize.Width - 15, szf.Height);

                e.Graphics.DrawString(tag, this.Font, brText, rectText, sf);

                count = count + 1;
            }

            brFiller.Dispose();
            brText.Dispose();
            penBorder.Dispose();
        }
    }
}
