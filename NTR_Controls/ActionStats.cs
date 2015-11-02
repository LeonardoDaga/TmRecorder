using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NTR_Common;
using NTR_Db;

namespace NTR_Controls
{
    // Tentativo di definire un nuovo controllo piu' veloce
    // con molte proprieta' predefinite

    public partial class ActionsStats : UserControl
    {
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
        public float RowsTitleWidth
        {
            get { return _columns.TitleWidth; }
            set { _columns.TitleWidth = value; Invalidate(); }
        }

        private int _rowsTitlePosition = 0;
        public int RowsTitlePosition
        {
            get { return _rowsTitlePosition; }
            set
            {
                _rowsTitlePosition = value;
                _columns = new ColumnsArray(_columnHeaders, _rowsTitlePosition);
                this.Invalidate();
            }
        }

        private string[] _columnHeaders = { "Goal", "In", "Out", "Tot", "", "Tot", "Out", "In", "Goal" };
        public string[] ColumnsHeaders
        {
            get { return _columnHeaders; }
            set
            {
                _columnHeaders = value;
                _columns = new ColumnsArray(_columnHeaders, _rowsTitlePosition);
                this.Invalidate();
            }
        }

        private ColumnsArray _columns = new ColumnsArray(new string[] { "" }, 0);

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

        private Font _rowsTitleFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
        public Font RowsTitleFont
        {
            get { return _rowsTitleFont; }
            set { _rowsTitleFont = value; Invalidate(); }
        }

        private Color _rowsTitleColor = Color.Black;
        public Color RowsTitleColor
        {
            get { return _rowsTitleColor; }
            set { _rowsTitleColor = value; Invalidate(); }
        }

        private StringAlignment _columnsAlignment;
        public StringAlignment ColumnsAlignment
        {
            get { return _columnsAlignment; }
            set { _columnsAlignment = value; Invalidate(); }
        }
        #endregion

        private Row[] _actionRows;
        public Row[] ActionRows
        {
            get { return _actionRows; }
            set { _actionRows = value; Invalidate(); }
        }

        public ActionsStats()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _columns = new ColumnsArray(_columnHeaders, _rowsTitlePosition);
        }

        public void ActionsToRows(string yActions, string oActions)
        {
            string[] Titles = new string[]
                {"Total","ShortPass","ThroughBall","Wing","LongBall","CounterAttack",
                "Corner","Freekick","GkLongBall","GkCounterAttack","Penalty"};

            _actionRows = new Row[Titles.Length];

            if (yActions == null)
            {
                // Clean the control
                for (int i = 0; i < Titles.Length; i++)
                {
                    string title = Titles[i];

                    _actionRows[i] = new Row();
                    _actionRows[i].Title = title;

                    string[] yv = { "", "", "", "" };
                    string[] ov = { "", "", "", "" };

                    _actionRows[i].values = new string[]
                    { yv[3], yv[2], yv[1], yv[0], "", ov[0], ov[1], ov[2], ov[3] };
                }
            }
            else
            {
                Dictionary<string, string[]> yourItems = ActionsList.ParseAsSimpleDictionary(yActions);
                Dictionary<string, string[]> oppsItems = ActionsList.ParseAsSimpleDictionary(oActions);

                int[] ys = { 0, 0, 0, 0 };
                int[] os = { 0, 0, 0, 0 };

                for (int i = 1; i < Titles.Length; i++)
                {
                    string title = Titles[i];

                    _actionRows[i] = new Row();
                    _actionRows[i].Title = title;

                    string[] yv = { "", "", "", "" };
                    string[] ov = { "", "", "", "" };
                    if (yourItems.ContainsKey(title))
                    {
                        int p;
                        yv = yourItems[Titles[i]];
                        for (int j = 0; j < yv.Length; j++)
                        {
                            int.TryParse(yv[j], out p);
                            ys[j] = ys[j] + p;
                        }
                    }
                    if (oppsItems.ContainsKey(title))
                    {
                        int p;
                        ov = oppsItems[Titles[i]];
                        for (int j = 0; j < yv.Length; j++)
                        {
                            int.TryParse(ov[j], out p);
                            os[j] = os[j] + p;
                        }
                    }                    

                    _actionRows[i].values = new string[]
                    { yv[3], yv[2], yv[1], yv[0], "", ov[0], ov[1], ov[2], ov[3] };
                }

                _actionRows[0] = new Row();
                _actionRows[0].Title = Titles[0];

                _actionRows[0].values = new string[]
                { ys[3].ToString(), ys[2].ToString(), ys[1].ToString(), ys[0].ToString(), "", os[0].ToString(), os[1].ToString(), os[2].ToString(), os[3].ToString() };
            }

            Invalidate();
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
            Brush headerBrush = new SolidBrush(_headerColor);
            Brush rowsTitleBrush = new SolidBrush(_rowsTitleColor);
            Brush valuesBrush = new SolidBrush(this.ForeColor);
            Pen delimiterPen = new Pen(Color.Gainsboro);

            _columns.TotalWidth = this.Width;
            _columns.Resize();

            float colLeft = 0;
            float rowTop = szf.Height;
            float maxRowHeight = 0;

            // Draw the column titles
            foreach (Column column in _columns.columnArray)
            {
                // Drawing the element string
                szf = e.Graphics.MeasureString(column.Title, _headerFont);
                RectangleF cellRectangle = new RectangleF(colLeft - 3, rowTop, column.size + 6, szf.Height);
                maxRowHeight = Math.Max(maxRowHeight, szf.Height);

                sf.Alignment = _columnsAlignment;

                e.Graphics.DrawString(column.Title, _headerFont, headerBrush, cellRectangle, sf);

                colLeft += column.size;
            }

            // Draw the first delimiter line
            rowTop += maxRowHeight + 2;

            // Draw the column titles
            if (this.ActionRows != null)
            foreach (Row row in this.ActionRows)
            {
                colLeft = 0;

                for (int nCol = 0; nCol < _columns.NumberOfColumns; nCol++)
                {
                    if (nCol == RowsTitlePosition)
                    {
                        // Drawing the element string
                        szf = e.Graphics.MeasureString(row.Title, _rowsTitleFont);
                        RectangleF cellRectangle = new RectangleF(colLeft - 3, rowTop, RowsTitleWidth + 6, szf.Height);
                        sf.Alignment = _columnsAlignment;

                        e.Graphics.DrawString(row.Title, _rowsTitleFont, rowsTitleBrush, cellRectangle, sf);

                        colLeft += RowsTitleWidth;
                    }
                    else
                    {
                        // Drawing the element string
                        string value = "-";
                        if (nCol < row.values.Length)
                            value = row.values[nCol];
                        szf = e.Graphics.MeasureString(value, this.Font);
                        RectangleF cellRectangle = new RectangleF(colLeft - 3, rowTop, _columns.columnArray[nCol].size + 6, szf.Height);
                        sf.Alignment = _columnsAlignment;

                        e.Graphics.DrawString(value, this.Font, valuesBrush, cellRectangle, sf);

                        colLeft += _columns.columnArray[nCol].size;
                    }

                    maxRowHeight = Math.Max(maxRowHeight, szf.Height);
                }

                e.Graphics.DrawLine(delimiterPen, 0, rowTop - 1, this.Width, rowTop - 1);
                rowTop += maxRowHeight + 1;
            }

            e.Graphics.DrawLine(delimiterPen, 0, rowTop - 1, this.Width, rowTop - 1);

            delimiterPen.Dispose();
            headerBrush.Dispose();
            titleBrush.Dispose();
            rowsTitleBrush.Dispose();
            valuesBrush.Dispose();
        }

        public class Column
        {
            public string Title;
            public float size;

            private Color _color = Color.Black;
            public Color Color
            {
                get { return _color; }
                set { _color = value; }
            }
        }

        public class ColumnsArray
        {
            public Column[] columnArray = new Column[0];

            public ColumnsArray(string[] columns, int titlePosition)
            {
                columnArray = new Column[columns.Length];

                for (int i = 0; i < columnArray.Length; i++)
                {
                    Column col = new Column();
                    col.Title = columns[i];
                    columnArray[i] = col;
                }

                TitlePosition = titlePosition;

                Resize();
            }


            public void Resize()
            {
                float detailColWidth = (_totalWidth - _titleWidth) / ((float)(NumberOfColumns - 1));

                for (int i = 0; i < NumberOfColumns; i++)
                {
                    columnArray[i].size = detailColWidth;
                }

                columnArray[TitlePosition].size = _titleWidth;
            }

            public int NumberOfColumns
            {
                get
                {
                    return columnArray.Length;
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

            public int TitlePosition { get; private set; }

            public enum eTitlePosition
            {
                Center,
                Left,
                Right
            }

        }

        public class Row
        {
            public string Title
            {
                get; set;
            }

            public string[] values
            {
                get; set;
            }
        }
    }
}
