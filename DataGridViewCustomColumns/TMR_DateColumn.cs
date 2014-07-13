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
    public partial class TMR_DateColumn : DataGridViewColumn
    {
        public int minColumnSize = 0;

        public TMR_DateColumn()
            : base(new TMR_DateCell())
        {
            InitializeComponent();
        }

        public TMR_DateColumn(IContainer container)
            : base(new TMR_DateCell())
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
                    !value.GetType().IsAssignableFrom(typeof(TMR_DateCell)))
                {
                    throw new InvalidCastException("Must be a TMR_DateCell");
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

    #region TMR_DateCell

    public class TMR_DateCell : DataGridViewTextBoxCell
    {
        public TMR_DateCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);

            TMR_DateEditControl ctl =
                DataGridView.EditingControl as TMR_DateEditControl;

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
                TmWeek tmw = new TmWeek();
                
                if (value == System.DBNull.Value)
                    tmw.absweek = TmWeek.GetTmAbsWk(TmWeek.tmDay0);
                else
                    tmw = new TmWeek(Convert.ToInt32(value));

                string strYear = tmw.Season.ToString();
                string strMonth = tmw.Months.ToString();

                if (tmw.absweek == TmWeek.GetTmAbsWk(TmWeek.tmDay0))
                {
                    strYear = "-";
                    strMonth = "";
                }

                SizeF szf;

                base.Paint(graphics,
                           clipBounds,
                           cellBounds,
                           rowIndex,
                           cellState,
                           value,
                           strYear,
                           errorText,
                           cellStyle,
                           advancedBorderStyle,
                           paintParts);

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
                else
                {
                    fbr = new SolidBrush(cellStyle.ForeColor);
                    bbr = new SolidBrush(cellStyle.BackColor);
                }

                gbr = new Pen(this.DataGridView.GridColor);
                Brush hbr = new SolidBrush(Color.Blue);

                Rectangle cellRect = cellBounds;

                szf = graphics.MeasureString(strYear.ToString(), cellStyle.Font);

                Point pt2 = cellRect.Location;
                pt2.Offset((int)szf.Width , 2); // (int)cellStyle.Font.SizeInPoints);
                Rectangle rect = new Rectangle(pt2, new Size((int)cellStyle.Font.SizeInPoints * 2, cellRect.Height));

                Font small = new Font(cellStyle.Font.FontFamily, (float)(cellStyle.Font.SizeInPoints-0.5f));
                graphics.DrawString(strMonth.ToString(), small, hbr, rect, sf);

                if (tmw.absweek == TmWeek.GetTmAbsWk(TmWeek.tmDay0))
                {
                    this.ToolTipText = "No Date";
                }
                else
                {
                    this.ToolTipText = "Season " + tmw.Season.ToString() + ", Week " + tmw.Months.ToString();
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
                // Return the type of the editing contol that TMR_DateCell uses.
                return typeof(TMR_DateEditControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that TMR_DateCell contains.
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
            if (value == null) return "-";
            if (value == (object)System.DBNull.Value) return "-";

            TmWeek tmw = new TmWeek((int)value);
            string str = tmw.ToAge(DateTime.Now);

            string[] toks = str.Split("ym".ToCharArray());

            toks[0] += "   ";

            return toks[0];
        }
    }

    class TMR_DateEditControl : TextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public TMR_DateEditControl()
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
