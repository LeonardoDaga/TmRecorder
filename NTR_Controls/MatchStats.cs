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
    public enum SizeType
    {
        Percentage,
        Pixels
    }

    public class Dictionary2D<K1, K2, V>
    {
        private Dictionary<K1, Dictionary<K2, V>> dict =
            new Dictionary<K1, Dictionary<K2, V>>();

        public V this[K1 key1, K2 key2]
        {
            get
            {
                try
                {
                    return dict[key1][key2];
                }
                catch
                {
                    return default(V);
                }
            }

            set
            {
                if (!dict.ContainsKey(key1))
                {
                    dict[key1] = new Dictionary<K2, V>();
                }
                dict[key1][key2] = value;
            }
        }
    }

    public class ItemDictionary:Dictionary2D<string, string, object>
    { }

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

    //public class Item 
    //{
    //    private object o;
    //    public Item(object o)
    //    {

    //    }

    //    //public class Value
    //    //{
    //    //    private object value = "";

    //    //    public Value(string str)
    //    //    {
    //    //        value = str;
    //    //    }

    //    //    public static implicit operator Value(string str)
    //    //    {
    //    //        return new Value(str);
    //    //    }

    //    //    public override string ToString()
    //    //    {
    //    //        return value.ToString();
    //    //    }
    //    //}

    //    public string Format { get; set; }
    //    public int IntValue 
    //    { 
    //        get {return (int)o;}
    //        set { o = value; }
    //    }
    //    public int FloatValue { get; set; }
    //    public int StrValue { get; set; }
    //}

    [Serializable]
    public class Item
    {
        public object o { get; set; }
        public string Name { get; set; }
    }

    public class Row
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Format { get; set; }

        [DefaultValue(false)]
        public bool IsHeader { get; set; }

        List<Item> _items = new List<Item>();
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        internal string GetText(string property)
        {
            if (property == "Title")
                return Text;
            else
            {
                object o = null;
                string text;

                if (Items == null)
                {
                    Random rg = new Random();
                    o = rg.Next(0, 30);
                }
                else
                {
                    IEnumerable<Item> items = (from c in Items
                                               where (c.Name == property)
                                               select c);
                    if (items.Count<Item>() > 0)
                        o = items.First<Item>().o;
                    else
                        o = null;
                }

                if ((o == null) || (Format == null))
                {
                    text = "n/a";
                }
                else if (o.GetType() == typeof(int))
                {
                    int i = (int)o;
                    text = string.Format(Format, i);
                }
                else
                {
                    text = o.ToString();
                }
                return text;
            }
        }
    }

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

        #region Row
        public Row[] Table
        {
            get;
            set;
        }
        #endregion

        #endregion

        public MatchStats()
        {
            InitializeComponent();
        }

        public void SetItemDictionary(ItemDictionary id)
        {
            foreach (Row row in this.Table)
            {
                if (row.Items != null)
                    row.Items.Clear();
                else
                    row.Items = new List<Item>();

                foreach (Column col in this.Columns)
                {
                    if (col.Property == "Title")
                        continue;

                    Item item = new Item();
                    item.Name = col.Property;
                    item.o = id[row.Name, item.Name];

                    row.Items.Add(item);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush titleBrush = new SolidBrush(TitleColor);

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
                if (this.Table == null) break;

                float rowTop = szf.Height;

                foreach (Row row in this.Table)
                {
                    float colLeft = 0;

                    for (int iCol = 0; iCol < _columns.Length; iCol++)
                    {
                        Column col = _columns[iCol];

                        string text = row.GetText(col.Property);

                        // Drawing the element string
                        szf = e.Graphics.MeasureString(text, _columns[iCol].Font);
                        RectangleF cellRectangle = new RectangleF(colLeft, rowTop, colSizes[iCol], szf.Height);

                        sf.Alignment = _columns[iCol].Alignment;

                        if (row.IsHeader)
                            e.Graphics.DrawString(text, _headerFont, headerBrush, cellRectangle, sf);
                        else
                            e.Graphics.DrawString(text, _columns[iCol].Font, colBrushes[iCol], cellRectangle, sf);

                        colLeft += colSizes[iCol];
                    }

                    rowTop += szf.Height;
                }

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

            this.Table = new Row[strTitles.Length];

            for(int i=0; i<strTitles.Length; i++)
            {
                if (strTitles[i] == "") 
                    continue;
                string[] strs = strTitles[i].Split(',');
                Row row = new Row();
                string title = strs[0];
                string format = strs[1];

                this.Table[i] = row;
                row.Name = title;
                row.Text = title;
                row.Format = format;

                row.Items = new List<Item>();
            }


            if (values != null)
            {
                for (int col = 0; col < colProperties.Count; col++)
                {
                    string[] items = values[col].Split(';');

                    for (int row = 0; row < strTitles.Length; row++)
                    {
                        if (strTitles[row] == "")
                            continue;

                        Item item = new Item();

                        item.o = items[row];
                        item.Name = colProperties[col];

                        this.Table[row].Items.Add(item);
                    }
                }
            }

            Invalidate();
        }
    }
}
