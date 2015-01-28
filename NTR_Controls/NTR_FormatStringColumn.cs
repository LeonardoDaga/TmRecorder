using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Common;
using NTR_Db;

namespace NTR_Controls
{
    public partial class NTR_FormatStringColumn : DataGridViewColumn
    {
        public NTR_FormatStringColumn()
            : base(new NTR_FormatStringColumnCell())
        {
            InitializeComponent();
        }

        public NTR_FormatStringColumn(IContainer container)
            : base(new NTR_FormatStringColumnCell())
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
                    !value.GetType().IsAssignableFrom(typeof(NTR_FormatStringColumnCell)))
                {
                    throw new InvalidCastException("Must be a NTR_FormatStringColumnCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    #region NTR_FormatStringColumnCell

    public class NTR_FormatStringColumnCell : DataGridViewTextBoxCell
    {
        public NTR_FormatStringColumnCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);

            NTR_FormatStringColumnControl ctl =
                DataGridView.EditingControl as NTR_FormatStringColumnControl;

            if (this.Value != System.DBNull.Value)
            {
                ctl.Text = System.Convert.ToString(this.Value);
            }

        }

        public override object Clone()
        {
            return base.Clone();
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
            try
            {
                string colName = this.OwningColumn.DataPropertyName;
                
                NTR_FormatStringColumn repCol = (NTR_FormatStringColumn)OwningColumn;

                Brush fbr = null, bbr = null;
                Pen gbr = null;

                DataGridViewElementStates isSelected = cellState & DataGridViewElementStates.Selected;

                FormattedString fstring = (FormattedString)value;

                if (isSelected == DataGridViewElementStates.Selected)
                {
                    fbr = new SolidBrush(cellStyle.SelectionForeColor);
                    Color highlight = fstring.backColor;
                    highlight = Color.FromArgb(highlight.R * 9 / 10, highlight.G * 9 / 10, highlight.B * 9 / 10);
                    bbr = new SolidBrush(highlight);
                }
                else
                {
                    fbr = new SolidBrush(cellStyle.ForeColor);
                    bbr = new SolidBrush(fstring.backColor);
                }
                
                gbr = new Pen(this.DataGridView.GridColor);
                Rectangle cellRect = cellBounds;
                cellRect.Offset(-1, -1);
                graphics.FillRectangle(bbr, cellRect);
                graphics.DrawRectangle(gbr, cellRect);

                string str = value.ToString();

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;

                SizeF szf = new SizeF(0, 0);

                FontStyle fs = FontStyle.Regular;

                if (fstring.isBold)
                    fs = FontStyle.Bold;

                Font font = new Font(cellStyle.Font, fs);

                graphics.DrawString(str, font, fbr, cellRect, sf);
                szf = graphics.MeasureString(str, font);

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
                // Return the type of the editing contol that TMR_ReportCell uses.
                return typeof(NTR_FormatStringColumnControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that TMR_ReportCell contains.
                return typeof(int);
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
            string colName = this.OwningColumn.DataPropertyName;

            NTR_FormatStringColumn repCol = (NTR_FormatStringColumn)OwningColumn;

            DataGridViewCellStyle cs = new DataGridViewCellStyle(cellStyle);

            FormattedString fstring = (FormattedString)value;
            FontStyle fs = FontStyle.Regular;

            if (fstring.isBold)
                fs = FontStyle.Bold;

            Font font = new Font(cellStyle.Font, fs);

            cs.Font = font;

            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
    }

    class NTR_FormatStringColumnControl : TextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public NTR_FormatStringColumnControl()
        {
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        public object EditingControlFormattedValue
        {
            get
            {
                int val = 0; 
                int.TryParse(Text, out val);
                return val;
            }
            set
            {
                this.Text = System.Convert.ToString(value);
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

        protected override void OnTextChanged(EventArgs e)
        {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnTextChanged(e);
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                return base.DisplayRectangle;
            }
        }

        protected override Size SizeFromClientSize(Size clientSize)
        {
            return base.SizeFromClientSize(clientSize);
        }

        protected override Size DefaultMinimumSize
        {
            get
            {
                return base.DefaultMinimumSize;
            }
        }
    }

    #endregion

}
