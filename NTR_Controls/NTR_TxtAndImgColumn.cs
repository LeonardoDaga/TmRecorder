using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace NTR_Controls
{
    public partial class NTR_TxtAndImgColumn : DataGridViewColumn
    {
        int minColumnSize = 30;
        public ImageList ImgList { get; set; }

        public NTR_TxtAndImgColumn(ImageList imgList)
            : base(new NTR_TxtAndImgCell())
        {
            ImgList = imgList;
            InitializeComponent();
        }

        public NTR_TxtAndImgColumn(IContainer container)
            : base(new NTR_TxtAndImgCell())
        {
            container.Add(this);

            InitializeComponent();
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(NTR_TxtAndImgCell)))
                {
                    throw new InvalidCastException("Must be a NTR_TxtAndImgCell");
                }
                base.CellTemplate = value;
            }
        }

        public override int GetPreferredWidth(DataGridViewAutoSizeColumnMode autoSizeColumnMode, bool fixedHeight)
        {
            int width = base.GetPreferredWidth(autoSizeColumnMode, fixedHeight);
            if (width > minColumnSize)
                return width;
            else
                return minColumnSize;
        }
    }

    #region NTR_TxtAndImgCell

    public class NTR_TxtAndImgCell : DataGridViewTextBoxCell
    {
        private Size preferredSize = new Size(-1, -1);

        public NTR_TxtAndImgCell()
            : base()
        {
        }

        public override object Clone()
        {
            NTR_TxtAndImgCell clone = (NTR_TxtAndImgCell)base.Clone();
            return clone;
        }

        protected override void Paint(System.Drawing.Graphics graphics,
            System.Drawing.Rectangle clipBounds,
            System.Drawing.Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates cellState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            string val = Convert.ToString(value);

            var dict = Common.Utility.StringToDictionary(val);

            string strText = dict["Text"];

            base.Paint(graphics,
                       clipBounds,
                       cellBounds,
                       rowIndex,
                       cellState,
                       strText,
                       strText,
                       errorText,
                       cellStyle,
                       advancedBorderStyle,
                       paintParts);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            NTR_TxtAndImgColumn dgc = (NTR_TxtAndImgColumn)(this.OwningColumn);
            SizeF szf = graphics.MeasureString(strText, cellStyle.Font);

            Point pt2 = cellBounds.Location;
            pt2.Offset((int)szf.Width, (cellBounds.Height - dgc.ImgList.ImageSize.Height) / 2);

            Brush fbr = null;

            DataGridViewElementStates isSelected = cellState & DataGridViewElementStates.Selected;

            if (isSelected == DataGridViewElementStates.Selected)
            {
                fbr = new SolidBrush(cellStyle.SelectionForeColor);
            }
            else
            {
                fbr = new SolidBrush(cellStyle.ForeColor);
            }

            pt2.X += 3;

            Image image = null;
            foreach (var item in dict)
            {
                if (item.Key == "Text") continue;

                int ix = dgc.ImgList.Images.IndexOfKey(item.Key + ".png");
                if (ix != -1) image = dgc.ImgList.Images[ix];

                if (image == null)
                {
                    image = dgc.ImgList.Images[0];
                }

                for (int i = 0; i < int.Parse(item.Value); i++)
                {
                    graphics.DrawImage(image, pt2);
                    pt2.X += image.Width;
                }
            }

        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that NTR_TxtAndImgCell contains.
                return typeof(string);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return "";
            }
        }

        protected override object GetFormattedValue(object value, int rowIndex, 
                                            ref DataGridViewCellStyle cellStyle, 
                                            TypeConverter valueTypeConverter, 
                                            TypeConverter formattedValueTypeConverter, 
                                            DataGridViewDataErrorContexts context)
        {
            if (value == null)
                return "";

            string strValue = (string)value;
            var dict = Common.Utility.StringToDictionary(strValue);

            string formattedString = dict["Text"] + "     ";

            foreach (var item in dict)
            {
                if (item.Key == "Text") continue;
                for (int j = 0; j < int.Parse(item.Value); j++)
                    formattedString += "   ";
            }

            return formattedString;
        }
    }

    #endregion

}
