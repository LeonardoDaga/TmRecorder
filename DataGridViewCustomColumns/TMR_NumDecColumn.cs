using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Common;

namespace DataGridViewCustomColumns
{
    public partial class TMR_NumDecColumn : DataGridViewColumn
    {
        public CellColorStyleList CellColorStyles = null;

        public TMR_NumDecColumn()
            : base(new TMR_NumDecCell())
        {
            InitializeComponent();
        }

        public TMR_NumDecColumn(IContainer container)
            : base(new TMR_NumDecCell())
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
                    !value.GetType().IsAssignableFrom(typeof(TMR_NumDecCell)))
                {
                    throw new InvalidCastException("Must be a TMR_NumDecCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    #region TMR_NumDecCell

    public class TMR_NumDecCell : DataGridViewTextBoxCell
    {
        public short status = 2;
        public bool filterASIvalue = false;
        public string txtTooltip = "";

        public TMR_NumDecCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            TMR_NumDecEditingControl ctl =
                DataGridView.EditingControl as TMR_NumDecEditingControl;

            if (this.Value != System.DBNull.Value)
            {
                ctl.Value = System.Convert.ToDecimal(this.Value);
            }

        }

        public override object Clone()
        {
            TMR_NumDecCell clone = (TMR_NumDecCell)base.Clone();
            clone.status = this.status;
            clone.filterASIvalue = this.filterASIvalue;
            return clone;
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value is intvar)
                return ((intvar)value).description;
            else if (value is decvar)
            {
                decvar decval = (decvar)value;
                string description = "";

                if (decval != null)
                {
                    if (decimal.Floor(decval.prev) == decimal.MinValue)
                        description = decval.actual.ToString() + " (New Value)";
                    else if (decimal.Floor(decval.actual) > decimal.Floor(decval.prev))
                        description = "Prev. Value = " + decval.prev.ToString() + "; Increment = +" + (decval.actual - decval.prev).ToString();
                    else if (decval.actual > decval.prev)
                        description = decval.actual.ToString() + ", Increment: +" + (decval.actual - decval.prev).ToString();
                    else if (decimal.Floor(decval.actual) < decimal.Floor(decval.prev))
                        description = "Prev. Value = " + decval.prev.ToString() + ", Decrement = " + (decval.actual - decval.prev).ToString();
                    else if (decval.actual < decval.prev)
                        description = decval.actual.ToString() + ", Decrement = " + (decval.actual - decval.prev).ToString();
                    else
                        description = decval.actual.ToString();
                }
                
                return description;
            }
            else
                return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }

        protected override void Paint(System.Drawing.Graphics graphics, 
            System.Drawing.Rectangle clipBounds, 
            System.Drawing.Rectangle cellBounds, 
            int rowIndex, 
            DataGridViewElementStates cellState, 
            object value, 
            object formattedValue, 
            string errorText, 
            DataGridViewCellStyle gridViewCellStyle, 
            DataGridViewAdvancedBorderStyle advancedBorderStyle, 
            DataGridViewPaintParts paintParts)
        {
            try
            {
                decimal dec;
                intvar intval = null;
                decvar decval = null;
                decimal quality = -1;
                CellColorStyle cellStyle;

                TMR_NumDecColumn dgc = (TMR_NumDecColumn)(this.OwningColumn);
                
                if (value.GetType() == typeof(int))
                {
                    dec = Convert.ToDecimal(value);
                    quality = -1;
                    cellStyle = CellColorStyle.FromDataGridViewCellStyle(gridViewCellStyle);
                }
                else if (value.GetType() == typeof(decimal))
                {
                    dec = Convert.ToDecimal(value);
                    quality = -1;

                    if (dgc.CellColorStyles == null)
                        cellStyle = CellColorStyle.FromDataGridViewCellStyle(gridViewCellStyle);
                    else
                        cellStyle = dgc.CellColorStyles.GetColorStyle(dec);
                }
                else if (value.GetType() == typeof(intvar))
                {
                    intval = (intvar)value;
                    dec = Convert.ToDecimal(intval.actual);
                    quality = -1;
                    cellStyle = dgc.CellColorStyles.GetColorStyle(-1);
                }
                else if (value.GetType() == typeof(decvar))
                {
                    decval = (decvar)value;
                    dec = decval.actual;
                    quality = decval.quality;
                    cellStyle = dgc.CellColorStyles.GetColorStyle(quality);
                }
                else
                {
                    dec = 0;
                    cellStyle = dgc.CellColorStyles.GetColorStyle(-1);
                }

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;

                Brush fbr = null, bbr = null;
                Pen gbr = null;

                DataGridViewElementStates isSelected = cellState & DataGridViewElementStates.Selected;

                if (isSelected == DataGridViewElementStates.Selected)
                {
                    fbr = new SolidBrush(cellStyle.SelectionForeColor);
                    bbr = new SolidBrush(cellStyle.SelectionBackColor);
                }
                else if (intval != null)
                {
                    if (intval.prev == int.MinValue)
                        fbr = new SolidBrush(cellStyle.ForeColor);
                    else if (intval.actual > intval.prev)
                        fbr = new SolidBrush(Color.Green);
                    else if (intval.actual < intval.prev)
                        fbr = new SolidBrush(Color.Red);
                    else 
                        fbr = new SolidBrush(cellStyle.ForeColor);
                    bbr = new SolidBrush(cellStyle.BackColor);
                }
                else
                {
                    fbr = new SolidBrush(cellStyle.ForeColor);
                    bbr = new SolidBrush(cellStyle.BackColor);
                }
                
                gbr = new Pen(this.DataGridView.GridColor);

                Rectangle cellRect = cellBounds;
                cellRect.Offset(-1, -1);
                graphics.FillRectangle(bbr, cellRect);
                graphics.DrawRectangle(gbr, cellRect);

                string str;

                if ((dgc.CellColorStyles != null) && (dgc.CellColorStyles.Type == CellColorStyleList.ListType.DefaultFp))
                    str = dec.ToString("N1");
                else
                    str = ((int)dec).ToString();

                SizeF szf = new SizeF(0, 0);

                if (this.OwningColumn.DataPropertyName == "ASI")
                    filterASIvalue = true;

                if ((dgc.CellColorStyles != null) && (dgc.CellColorStyles.Type == CellColorStyleList.ListType.DefaultFp))
                {
                    graphics.DrawString(str.ToString(), gridViewCellStyle.Font, fbr, cellRect, sf);
                    szf = graphics.MeasureString(str.ToString(), gridViewCellStyle.Font);
                }
                else if ((dec < 19) || (filterASIvalue)) // || 
                {
                    graphics.DrawString(str.ToString(), gridViewCellStyle.Font, fbr, cellRect, sf);
                    szf = graphics.MeasureString(str.ToString(), gridViewCellStyle.Font);
                }
                else if ((dec >= 19)&& (dec < 20))
                {
                    Point pt = cellRect.Location;
                    pt.Offset(2, (cellRect.Height - dgc.iconList1.ImageSize.Height) / 2);
                    graphics.DrawImage(dgc.iconList1.Images[1], pt);
                    szf = dgc.iconList1.ImageSize;
                }
                else if (dec == 20)
                {
                    Point pt = cellRect.Location;
                    pt.Offset(2, (cellRect.Height - dgc.iconList1.ImageSize.Height) / 2);
                    graphics.DrawImage(dgc.iconList1.Images[0], pt);
                    szf = dgc.iconList1.ImageSize;
                }

                Point pt2 = cellRect.Location;
                pt2.Offset((int)szf.Width, (cellRect.Height - dgc.iconList2.ImageSize.Height) / 2);
                Rectangle rect = new Rectangle(pt2, new Size(9, 12));

                if (this.Tag != null)
                {
                    switch ((int)this.Tag)
                    {
                        case 2: graphics.DrawImage(dgc.iconList2.Images[0], pt2); break;
                        case 1: graphics.DrawImage(dgc.iconList2.Images[1], pt2); break;
                        case -1: graphics.DrawImage(dgc.iconList2.Images[2], pt2); break;
                        case -2: graphics.DrawImage(dgc.iconList2.Images[3], pt2); break;
                    }
                }

                if (intval != null)
                {
                    if (intval.prev == int.MinValue)
                    {
                        graphics.DrawImage(dgc.iconList2.Images[5], pt2);
                        intval.description = "New value";
                    }
                    else if (intval.actual > intval.prev)
                    {
                        graphics.DrawImage(dgc.iconList2.Images[0], pt2);
                        intval.description = "Prev. Value = " + intval.prev.ToString() + "; Increment = +" + (intval.actual - intval.prev).ToString();
                    }
                    else if (intval.actual < intval.prev)
                    {
                        graphics.DrawImage(dgc.iconList2.Images[3], pt2);
                        intval.description = "Prev. Value = " + intval.prev.ToString() + "; Decrement = " + (intval.actual - intval.prev).ToString();
                    }
                    else if (intval.actual == intval.prev)
                    {
                        graphics.DrawImage(dgc.iconList2.Images[4], pt2);
                        intval.description = "No value change";
                    }
                }

                if (decval != null)
                {
                    if (decval.prev == decimal.MinValue)
                        decval.description = "New value";
                    else if (decimal.Floor(decval.actual) > decimal.Floor(decval.prev))
                        graphics.DrawImage(dgc.iconList2.Images[0], pt2);
                    else if (decval.actual > decval.prev)
                        graphics.DrawImage(dgc.iconList2.Images[1], pt2);
                    else if (decimal.Floor(decval.actual) < decimal.Floor(decval.prev))
                        graphics.DrawImage(dgc.iconList2.Images[3], pt2);
                    else if (decval.actual < decval.prev)
                        graphics.DrawImage(dgc.iconList2.Images[2], pt2);
                }

                if (value.GetType() == typeof(decvar))
                {
                    decimal decpart = (dec - decimal.Floor(dec));

                    int height = (int)((decpart * 100M * (cellRect.Height - 2)) / 100M);

                    Rectangle bar = new Rectangle(cellRect.Left + 1,
                        cellRect.Bottom - 5, height, 3);

                    Brush hbr = null;
                    if (decpart <= 0.5M)
                        hbr = new SolidBrush(Color.Blue);
                    else if (decpart <= 0.8M)
                        hbr = new SolidBrush(Color.Yellow);
                    else
                        hbr = new SolidBrush(Color.Red);

                    graphics.FillRectangle(hbr, bar);
                    graphics.DrawRectangle(gbr, bar);
                }
                else if (dgc.CellColorStyles == null)
                {
                    decimal decpart = (dec - decimal.Floor(dec));

                    int height = (int)((decpart * 100M * (cellRect.Height - 2)) / 100M);

                    Rectangle bar = new Rectangle(cellRect.Left + 1,
                        cellRect.Bottom - 5, height, 3);

                    Brush hbr = null;
                    if (decpart <= 0.5M)
                        hbr = new SolidBrush(Color.Blue);
                    else if (decpart <= 0.8M)
                        hbr = new SolidBrush(Color.Yellow);
                    else
                        hbr = new SolidBrush(Color.Red);

                    graphics.FillRectangle(hbr, bar);
                    graphics.DrawRectangle(gbr, bar);
                }

                fbr.Dispose();
                bbr.Dispose();
                gbr.Dispose();
            }
            catch (Exception)
            {
            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that TMR_NumDecCell uses.
                return typeof(TMR_NumDecEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that TMR_NumDecCell contains.
                return typeof(decimal);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return (decimal)0f;
            }
        }
    }

    class TMR_NumDecEditingControl : NumericUpDown, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public TMR_NumDecEditingControl()
        {
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Value.ToString();
            }
            set
            {
                if (value is decimal)
                {
                    this.Value = (decimal)value;
                }
                else
                {
                    this.Value = decimal.Parse((string)value);
                }
            }
        }

        // Implements the 
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the 
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;

            this.DecimalPlaces = int.Parse(dataGridViewCellStyle.Format.Trim('N'));
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
        // property.
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
        // method.
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return false;
            }
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        // Implements the IDataGridViewEditingControl
        // .RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlValueChanged property.
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingPanelCursor property.
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnValueChanged(EventArgs e)
        {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(e);
        }
    }

    #endregion
}
