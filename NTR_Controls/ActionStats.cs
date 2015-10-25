using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NTR_Common;

namespace NTR_Controls
{
    // Tentativo di definire un nuovo controllo piu' veloce
    // con molte proprieta' predefinite

    public partial class ActionsStats : UserControl
    {
        private float centerColSize = 120;

        #region Properties
        private string _title = "Title";
        public string Title
        {
            get { return _title; }
            set { _title = value; Invalidate(); }
        }

        private Font _titleFont = new Font(FontFamily.GenericSansSerif, 10);
        public Font TitleFont
        {
            get { return _titleFont; }
            set { _titleFont = value; Invalidate(); }
        }
        
        private Color _titleColor = Color.Black;
        public Color TitleColor
        {
            get { return _titleColor; }
            set { _titleColor = value; Invalidate(); }
        }

        private StringAlignment _titleAlignment;
        public StringAlignment TitleAlignment
        {
            get { return _titleAlignment; }
            set { _titleAlignment = value; Invalidate(); }
        }
        #endregion

        #region Columns
        private string[] colHeaderR =
        {
            "Tot", "Out", "In", "Goal"
        };

        private string[] colHeaderL =
        {
            "Goal", "In", "Out", "Tot"
        };

        private Columns columns = new Columns();

        private Font _headerFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
        public Font HeaderFont
        {
            get { return _headerFont; }
            set { _headerFont = value; Invalidate(); }
        }

        private Color _headerColor = Color.Black;
        public Color HeaderColor
        {
            get { return _headerColor; }
            set { _headerColor = value; Invalidate(); }
        }
        #endregion

        List< ActionRow> ActionRowsList
        {
            get;
            set;
        }

        public ActionsStats()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush titleBrush = new SolidBrush(_titleColor);

            StringFormat sf = new StringFormat();
            sf.Alignment = _titleAlignment;
            sf.LineAlignment = StringAlignment.Center;

            // Drawing the title
            SizeF szf = e.Graphics.MeasureString(Title, TitleFont);
            RectangleF titleRectangle = new RectangleF(0, 0, this.Width, szf.Height);
            e.Graphics.DrawString(Title, TitleFont, titleBrush, titleRectangle, sf);

            //---------------------------------------------------------
            // Creating the columns
            //---------------------------------------------------------
            Brush[] colBrushes = null;

            Brush headerBrush = new SolidBrush(_headerColor);

            // Draw the column titles

        }

        public class Column
        {
            private string Title;
        }

        public class Columns
        {
            public float[] size = null;

            private void Resize()
            {
                if (TitlePosition == eTitlePosition.Center)
                {
                    float detailColWidth = (_totalWidth - _titleWidth) / ((float)(_numberOfColumns - 1));

                    for (int i = 0; i < _numberOfColumns; i++)
                    {
                        size[i] = detailColWidth;
                    }

                    if (TitlePosition == eTitlePosition.Left)
                    {
                        size[0] = _titleWidth;
                    }
                    else if (TitlePosition == eTitlePosition.Center)
                        size[_numberOfColumns / 2] = _titleWidth;
                    else
                    {
                        size[_numberOfColumns - 1] = _titleWidth;
                    }
                }
            }

            public eTitlePosition TitlePosition
            {
                get;
                set;
            }

            private int _numberOfColumns;
            public int NumberOfColumns
            {
                get
                {
                    return _numberOfColumns;
                }
                set
                {
                    _numberOfColumns = value;
                    size = new float[_numberOfColumns];
                    Resize();
                }
            }

            private float _titleWidth;
            public float TitleWidth
            {
                get
                {
                    return _titleWidth;
                }
                set
                {
                    _titleWidth = value;
                    Resize();
                }
            }

            private float _totalWidth;
            public float TotalWidth
            {
                get
                {
                    return _totalWidth;
                }
                set
                {
                    _totalWidth = value;
                    Resize();
                }
            }

            public int TitleColumn
            {
                get
                {
                    return _numberOfColumns / 2;
                }
            }

            public enum eTitlePosition
            {
                Center,
                Left,
                Right
            }

        }

        public class Row
        {
            public string Title;
            public int[] YourActions;
            public int[] OppsActions;
        }
    }
}
