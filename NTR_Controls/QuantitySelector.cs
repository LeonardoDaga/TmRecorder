using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTR_Controls
{
    public partial class QuantitySelector : UserControl
    {
        public QuantitySelector()
        {
            InitializeComponent();
        }

        public delegate void ValueChangedHandler(float NewValue);
        public event ValueChangedHandler ValueChanged;

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush brBackground = new SolidBrush(this.BackColor);
            e.Graphics.FillRectangle(brBackground, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

            RectangleF starRect = new RectangleF(0, 0, this.ClientSize.Width/5.0f, this.ClientSize.Height);

            int i = 0;
            for (; i <= Value - 1.0f; i++)
            {
                e.Graphics.DrawImage(imageList.Images[0], starRect);
                starRect.Offset((float)(this.ClientSize.Width / 5.0f), 0f);
            }

            if (Value - i >= 0.5)
            {
                e.Graphics.DrawImage(imageList.Images[1], starRect);
                starRect.Offset((float)(this.ClientSize.Width / 5.0f), 0f);
                i++;
            }

            for (; i <= 5; i++)
            {
                e.Graphics.DrawImage(imageList.Images[2], starRect);
                starRect.Offset((float)(this.ClientSize.Width / 5.0f), 0f);
            }


            brBackground.Dispose();
        }

        float _value = 0;
        public float Value 
        {
            get { return _value; }

            set
            {
                _value = value;
                this.Invalidate();
                if (ValueChanged != null)
                    ValueChanged(_value);
            } 
        }

        private void QuantitySelector_MouseClick(object sender, MouseEventArgs e)
        {
            float pos = (float)e.X / (float)this.ClientSize.Width;
            pos = (float)((int)(pos * 10.0f)) / 2.0f + 0.5f;
            Value = pos;
        }
    }
}
