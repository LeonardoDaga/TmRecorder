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
    public partial class TMR_ReportColumn : DataGridViewColumn
    {
        public int minColumnSize = 0;
        public ReportParser reportParser = null;

        public TMR_ReportColumn()
            : base(new TMR_ReportCell())
        {
            InitializeComponent();
        }

        public TMR_ReportColumn(IContainer container)
            : base(new TMR_ReportCell())
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
                    !value.GetType().IsAssignableFrom(typeof(TMR_ReportCell)))
                {
                    throw new InvalidCastException("Must be a TMR_ReportCell");
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

        public int FPn { get; set; }
    }

    #region TMR_ReportCell

    public class TMR_ReportCell : DataGridViewTextBoxCell
    {
        public TMR_ReportCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);

            TMR_ReportControl ctl =
                DataGridView.EditingControl as TMR_ReportControl;

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

                TMR_ReportColumn repCol = (TMR_ReportColumn)OwningColumn;

                string dictStr = "";

                if (repCol.reportParser != null)
                {
                    if (value.ToString() != "")
                    {
                        if (repCol.reportParser.Dict.ContainsKey(colName))
                        {
                            Dictionary<int, string> dict = repCol.reportParser.Dict[colName];
                            Int16 val = (Int16)value;
                            dictStr = dict[val];
                        }
                        else
                        {
                            if (value.GetType() == typeof(decimal))
                            {
                                decimal val = (decimal)value;
                                dictStr = (val / 2M).ToString("N1");
                            }
                            else if (value.GetType() == typeof(float))
                            {
                                float val = (float)value;
                                dictStr = val.ToString("N1");
                            }
                            else if (colName == "Speciality")
                            {
                                Int16 val = (Int16)value;
                                if (repCol.FPn != 0)
                                    dictStr = repCol.reportParser.Dict["Player_Skill"][val];
                                else
                                    dictStr = repCol.reportParser.Dict["GK_Skill"][val];
                            }
                            else
                            {
                                dictStr = value.ToString();
                            }
                        }
                    }
                    else
                    {
                        base.Paint(graphics,
                           clipBounds,
                           cellBounds,
                           rowIndex,
                           cellState,
                           value,
                           formattedValue,
                           errorText,
                           cellStyle,
                           advancedBorderStyle,
                           paintParts);
                        return;
                    }
                }

                base.Paint(graphics,
                           clipBounds,
                           cellBounds,
                           rowIndex,
                           cellState,
                           value,
                           dictStr,
                           errorText,
                           cellStyle,
                           advancedBorderStyle,
                           paintParts);
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
                return typeof(TMR_ReportControl);
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

            TMR_ReportColumn repCol = (TMR_ReportColumn)OwningColumn;

            string dictStr = "";

            if (value == null) return null;

            if (repCol.reportParser != null)
            {
                if (value.ToString() != "")
                {
                    if (repCol.reportParser.Dict.ContainsKey(colName))
                    {
                        Dictionary<int, string> dict = repCol.reportParser.Dict[colName];
                        Type type = value.GetType();
                        Int16 val = (Int16)value;
                        dictStr = dict[val];
                    }
                    else
                    {
                        if (value.GetType() == typeof(decimal))
                        {
                            decimal val = (decimal)value;
                            dictStr = (val / 2M).ToString("N1");
                        }
                        else if (value.GetType() == typeof(float))
                        {
                            float val = (float)value;
                            dictStr = (val / 2).ToString("N1");
                        }
                        else
                        {
                            dictStr.ToString();
                        }
                    }
                }
                else
                {
                    return null;
                }
            }

            return dictStr;
        }
    }

    class TMR_ReportControl : TextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public TMR_ReportControl()
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
