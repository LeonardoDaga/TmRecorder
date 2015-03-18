using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NTR_Common;

namespace NTR_Controls
{
    // Nuova implementazione
    // Il controllo contiene l'elenco delle colonne con in nome (solo per visualizzazione) e la proprietà che serve per 
    // identificare il valore nell'ItemDictionary
    // Il controllo internamente indicizza la posizione di tutte le celle (opzionale)
    // Il controllo contiene, sull'interfaccia, l'elenco dei titoli delle righe, corrispondente alla colonna title.
    // Il controllo contiene, internamente, l'ItemDictionary con gli elementi da visualizzare. Non mostrata ad interfaccia
    // per non farla incasinare

    public partial class MatchStats : UserControl
    {
        #region Properties

        #region Title
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


        private Column[] _columns;
        public Column[] Columns
        {
            get { return _columns; }
            set { _columns = value; Invalidate(); }
        }

        #endregion

        #region Rows
        private Dictionary<string, Row> _rowsDict = new Dictionary<string, Row>();
        private Row[] _rows = null;
        public Row[] Rows
        {
            get
            {
                return _rows;
            }
            set
            {
                _rows = value;
            }
        }
        private Row GetRow(string name)
        {
            if (_rowsDict.Count == 0)
            {
                foreach (Row row in _rows)
                {
                    _rowsDict.Add(row.Name, row);
                }
            }
            Row rowOut = _rowsDict[name];
            if (rowOut.Name != name)
            {
                _rowsDict.Clear();
                foreach (Row row in _rows)
                {
                    _rowsDict.Add(row.Name, row);
                }
                rowOut = _rowsDict[name];
            }
            return rowOut;
        }

        float[] rowTops = null;
        #endregion

        private ItemDictionary Table = null;

        public int selectedRow { get; set; }

        public bool IsSelectable { get; set; }

        #endregion

        public MatchStats()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.MouseWheel += MatchStats_MouseWheel;
            selectedRow = -1;
        }

        public void SetItemDictionary(ItemDictionary idTable)
        {
            Table = idTable;

            Invalidate();
        }

        internal string GetText(string propertyCol, string row)
        {
            if (propertyCol == "Title")
                return row;
            else
            {
                object o = null;
                string text;

                if (Table == null)
                {
                    Random rg = new Random();
                    o = rg.Next(0, 30);
                }
                else
                {
                    o = Table[row, propertyCol];
                }

                Row thisRow = GetRow(row);
                if ((o == null) || (thisRow.Format == null) || (o.ToString() == ""))
                {
                    text = "n/a";
                }
                else if (o.GetType() == typeof(int))
                {
                    int i = (int)o;
                    text = string.Format(thisRow.Format, i);
                }
                else
                {
                    text = o.ToString();
                }
                return text;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush titleBrush = new SolidBrush(TitleColor);

            StringFormat sf = new StringFormat();
            sf.Alignment = _titleAlignment;
            sf.LineAlignment = StringAlignment.Center;

            // Selected Row pen
            Pen penRect = new Pen(Color.Gray);

            // Drawing the title
            SizeF szf = e.Graphics.MeasureString(Title, TitleFont);
            RectangleF titleRectangle = new RectangleF(0, 0, this.Width, szf.Height);
            e.Graphics.DrawString(Title, TitleFont, titleBrush, titleRectangle, sf);

            //---------------------------------------------------------
            // Creating the columns
            //---------------------------------------------------------
            Brush[] colBrushes = null;

            Brush headerBrush = new SolidBrush(HeaderColor);

            for (; ; )
            {
                // Creating the fixed part
                float fixedSize = 0;
                if (_columns == null) break;

                foreach (Column col in this._columns)
                {
                    if (col.ColumnSizeType == SizeType.Pixels)
                        fixedSize += col.ColumnSize;
                }

                float movingSize = this.Width - fixedSize;

                float[] colSizes = new float[_columns.Length];
                colBrushes = new SolidBrush[_columns.Length];

                for (int iCol = 0; iCol < _columns.Length; iCol++)
                {
                    if (_columns[iCol].ColumnSizeType == SizeType.Pixels)
                        colSizes[iCol] = _columns[iCol].ColumnSize;
                    else
                        colSizes[iCol] = movingSize * (_columns[iCol].ColumnSize / 100f);

                    colBrushes[iCol] = new SolidBrush(_columns[iCol].Color);
                }

                // Drawing each column
                if (this.Rows == null) break;

                float rowTop = szf.Height;

                rowTops = new float[this.Rows.Length + 1];
                int iRow = 0;

                foreach (Row row in this.Rows)
                {
                    rowTops[iRow] = rowTop;

                    float colLeft = 0;
                    float maxRowHeight = 0;

                    for (int iCol = 0; iCol < _columns.Length; iCol++)
                    {
                        Column col = _columns[iCol];

                        string text;

                        if (row.Name == "Type")
                            text = col.Name;
                        else if (col.Property == "Title")
                            text = row.Text;
                        else
                            text = GetText(col.Property, row.Name);

                        if (text == "n/a")
                            text = "-";

                        // Drawing the element string
                        szf = e.Graphics.MeasureString(text, _columns[iCol].Font);
                        RectangleF cellRectangle = new RectangleF(colLeft, rowTop, colSizes[iCol], szf.Height);
                        maxRowHeight = Math.Max(maxRowHeight, szf.Height);

                        sf.Alignment = _columns[iCol].Alignment;

                        if (row.IsHeader)
                            e.Graphics.DrawString(text, _headerFont, headerBrush, cellRectangle, sf);
                        else
                            e.Graphics.DrawString(text, _columns[iCol].Font, colBrushes[iCol], cellRectangle, sf);

                        colLeft += colSizes[iCol];
                    }

                    if ((iRow == selectedRow) && (IsSelectable) && !row.IsHeader)
                    {
                        Rectangle cellRectangle = new Rectangle(0, (int)rowTop, this.Width, (int)szf.Height);
                        e.Graphics.DrawRectangle(penRect, cellRectangle);
                    }

                    rowTop += maxRowHeight;
                    iRow++;
                }

                if (this.Rows.Length > 0)
                    rowTops[this.Rows.Length] = rowTop;

                break;
            }

            // Dispose the allocated objects
            if (_columns != null)
            {
                for (int iCol = 0; iCol < _columns.Length; iCol++)
                {
                    if (colBrushes != null)
                        colBrushes[iCol].Dispose();
                }
            }

            headerBrush.Dispose();
            titleBrush.Dispose();
        }

        public void SetData(string titles, string[] values)
        {
            ItemDictionary id = new ItemDictionary();

            string[] strTitles = titles.Split(';');

            List<string> colProperties = new List<string>();
            foreach (Column col in this.Columns)
            {
                if (col.Property != "Title")
                    colProperties.Add(col.Property);
            }

            this.Rows = new Row[strTitles.Length];

            for(int i=0; i<strTitles.Length; i++)
            {
                if (strTitles[i] == "") 
                    continue;
                string[] strs = strTitles[i].Split(',');
                Row row = new Row();
                string title = strs[0];
                string format = strs[1];

                this.Rows[i] = row;
                row.Name = title;
                row.Text = title;
                row.Format = format;
            }

            Table = new ItemDictionary();

            if (values != null)
            {
                for (int col = 0; col < colProperties.Count; col++)
                {
                    string[] items = values[col].Split(';');

                    for (int row = 0; row < this.Rows.Length; row++)
                    {
                        Table[Rows[row].Name, colProperties[col]] = items[row];
                    }
                }
            }

            Invalidate();
        }

        private void MatchStats_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void MatchStats_MouseWheel(object sender, MouseEventArgs e)
        {
        }

        private void MatchStats_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsSelectable)
                return;

            int i;
            for (i=-1; i<rowTops.Length-1; i++)
            {
                if (e.Y < rowTops[i + 1])
                    break;
            }

            if (i == -1)
            {
                return;
            }

            if (i >= rowTops.Length - 1)
                i = rowTops.Length - 2;

            if (i != selectedRow)
            {
                Rectangle oldRectangle;
                if (selectedRow != -1)
                {
                    oldRectangle = new Rectangle(0, (int)rowTops[selectedRow], (int)this.Width, (int)rowTops[selectedRow + 1]);
                    Invalidate(oldRectangle);
                }

                selectedRow = i;

                Rectangle newRectangle = new Rectangle(0, (int)rowTops[selectedRow], this.Width, (int)rowTops[selectedRow + 1]);
                Invalidate(newRectangle);
            }
        }
    }

    public enum SizeType
    {
        Percentage,
        Pixels
    }

    public class Column
    {
        private string _property;
        public string Property
        {
            get { return _property; }
            set { _property = value; }
        }

        private string _name = "Name";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Font _font = new Font(FontFamily.GenericSansSerif, 8);
        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        private Color _color = Color.Black;
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        private StringAlignment _alignment;
        public StringAlignment Alignment
        {
            get { return _alignment; }
            set { _alignment = value; }
        }

        private int _columnSize;
        public int ColumnSize
        {
            get { return _columnSize; }
            set { _columnSize = value; }
        }

        private SizeType _columnSizeType;
        public SizeType ColumnSizeType
        {
            get { return _columnSizeType; }
            set { _columnSizeType = value; }
        }

    }

    [Serializable]
    public class Row
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Format { get; set; }

        [DefaultValue(false)]
        public bool IsHeader { get; set; }
    }
}
