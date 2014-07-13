using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TMR_CostumControls
{
    public partial class TMR_ToolStripButton : ToolStripButton
    {
        private string _underText = "(0)";
        public string UnderText
        {
            get { return _underText; }
            set 
            { 
                _underText = value;
                this.Invalidate();
            }
        }

        private bool fontInitialized = false;
        private Font _underFont = new Font(FontFamily.GenericSerif, 8);
        public Font UnderFont
        {
            get 
            {
                if (!fontInitialized)
                {
                    _underFont = this.Font;
                    fontInitialized = true;
                }
                return _underFont; 
            }
            set { _underFont = value; this.Invalidate(); }
        }

        private Color _underColor = Color.CadetBlue;
        public Color UnderColor
        {
            get { return _underColor; }
            set { _underColor = value; this.Invalidate(); }
        }

        private ContentAlignment _underAlign = ContentAlignment.BottomCenter;
        public ContentAlignment UnderAlign
        {
            get { return _underAlign; }
            set { _underAlign = value; this.Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            SolidBrush sbFore = new SolidBrush(_underColor);
            Size size = base.GetPreferredSize(new Size(0,0));

            StringFormat sf = StringFormatFromContentAlignment();
            SizeF sizef = e.Graphics.MeasureString(_underText, _underFont);
            
            e.Graphics.DrawString(_underText, _underFont, sbFore,
                new RectangleF(0, 0, Size.Width, Size.Height), sf);

            sbFore.Dispose();
        }

        private StringFormat StringFormatFromContentAlignment()
        {
            StringFormat sf = new StringFormat();

            if (UnderAlign == ContentAlignment.BottomCenter)
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Far;
            }
            else if  (UnderAlign == ContentAlignment.BottomLeft)
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Far;
            }
            else if  (UnderAlign == ContentAlignment.BottomRight)
            {
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
            }
            else if  (UnderAlign == ContentAlignment.MiddleCenter)
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
            }
            else if  (UnderAlign == ContentAlignment.MiddleLeft)
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;
            }
            else if  (UnderAlign == ContentAlignment.MiddleRight)
            {
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Center;
            }
            else if (UnderAlign == ContentAlignment.TopCenter)
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Near;
            }
            else if (UnderAlign == ContentAlignment.TopLeft)
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
            }
            else // if (UnderAlign == ContentAlignment.TopRight)
            {
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Near;
            }
            return sf;
        }

        public TMR_ToolStripButton()
        {
            InitializeComponent();
        }
    }
}
