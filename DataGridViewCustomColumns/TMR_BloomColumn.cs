using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Common;
using System.Data;

namespace DataGridViewCustomColumns
{
    public partial class TMR_BloomColumn : DataGridViewColumn
    {
        public int minColumnSize = 0;

        public TMR_BloomColumn()
            : base(new TMR_BloomCell())
        {
            InitializeComponent();
        }

        public TMR_BloomColumn(IContainer container)
            : base(new TMR_BloomCell())
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
                    !value.GetType().IsAssignableFrom(typeof(TMR_BloomCell)))
                {
                    throw new InvalidCastException("Must be a TMR_BloomCell");
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

    #region TMR_BloomCell

    public class TMR_BloomCell : DataGridViewTextBoxCell
    {
        public TMR_BloomCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);

            TMR_BloomEditControl ctl =
                DataGridView.EditingControl as TMR_BloomEditControl;

            if (this.RowIndex == -1) return;
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
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                Brush fbr = null, bbr = null;
                Pen gbr = new Pen(this.DataGridView.GridColor);

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

                if (OwningColumn.Name == "BloomingPhase")
                {
                    gbr = new Pen(this.DataGridView.GridColor);

                    Rectangle cellRect = cellBounds;
                    cellRect.Offset(-1, -1);

                    SizeF szf = graphics.MeasureString(formattedValue.ToString(), cellStyle.Font);

                    graphics.FillRectangle(bbr, cellRect);
                    graphics.DrawRectangle(gbr, cellRect);

                    szf = new SizeF(cellStyle.Font.SizeInPoints * 2f, cellStyle.Font.SizeInPoints * 1.5f);
                    Point pt = new Point((int)(cellRect.Width - szf.Width) / 2, (int)(cellRect.Height - szf.Height) / 2);
                    pt.X += cellRect.Left;
                    pt.Y += cellRect.Top;
                    Rectangle rect = new Rectangle(pt, szf.ToSize());

                    Brush cbr = null;
                    Brush hbr = null;

                    if (formattedValue.ToString() == "E")
                    {
                        cbr = new SolidBrush(Color.Gray);
                        hbr = new SolidBrush(Color.White);
                        this.ToolTipText = "Bloomed";
                    }
                    else if (formattedValue.ToString() == "U")
                    {
                        cbr = new SolidBrush(Color.Lime);
                        hbr = new SolidBrush(Color.Black);
                        this.ToolTipText = "Not Bloomed";
                    }
                    else if (formattedValue.ToString() == "-")
                    {
                        cbr = new SolidBrush(Color.White);
                        hbr = new SolidBrush(Color.DarkGray);
                        this.ToolTipText = "Bloom not determined";
                    }
                    else
                    {
                        cbr = new SolidBrush(Color.Yellow);
                        hbr = new SolidBrush(Color.DarkRed);
                        this.ToolTipText = "Season " + formattedValue.ToString() + " of blooming";
                    }

                    graphics.FillRectangle(cbr, rect);
                    graphics.DrawRectangle(gbr, rect);
                    graphics.DrawString(formattedValue.ToString(), cellStyle.Font, hbr, rect, sf);
                }
                else
                {
                    base.Paint(graphics,
                               clipBounds,
                               cellBounds,
                               rowIndex,
                               cellState,
                               formattedValue,
                               formattedValue.ToString(),
                               errorText,
                               cellStyle,
                               advancedBorderStyle,
                               paintParts);
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
                // Return the type of the editing contol that TMR_BloomCell uses.
                return typeof(TMR_BloomEditControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that TMR_BloomCell contains.
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
            if (value == System.DBNull.Value) return "-";


            if (OwningColumn.Name == "BloomingAge")
            {
                DataRowView drv = (DataRowView)(this.DataGridView.Rows[rowIndex].DataBoundItem);

                int wBorn = (int)drv["wBorn"];

                string[] strs = value.ToString().Split(';');

                int wBloomStart = int.Parse(strs[0]);

                int AgeStartOfBloom = (wBloomStart - wBorn) / 12;

                return AgeStartOfBloom.ToString();
            }
            else if (OwningColumn.Name == "Asi30")
            {
                string[] strs = value.ToString().Split(';');
                if (strs.Length < 5) return "-";
                int Asi30 = int.Parse(strs[4]);
                if (Asi30 <= 0) return "-";
                return Asi30.ToString();
            }
            else if (OwningColumn.Name == "Asi25")
            {
                string[] strs = value.ToString().Split(';');
                if (strs.Length < 6) return "-";
                int Asi25 = int.Parse(strs[5]);
                if (Asi25 <= 0) return "-";
                return Asi25.ToString();
            }
            else if (OwningColumn.Name == "BloomingPhase")
            {
                DataRowView drv = (DataRowView)(this.DataGridView.Rows[rowIndex].DataBoundItem);

                int wBorn = (int)drv["wBorn"];
                int wNow = TmWeek.GetTmAbsWk(DateTime.Now);

                string[] strs = value.ToString().Split(';');

                int wBloomStart = int.Parse(strs[0]);

                int YearsFromBloom;
                if (wNow > wBloomStart)
                    YearsFromBloom = (wNow - wBloomStart) / 12;
                else
                    YearsFromBloom = (wNow - wBloomStart) / 12 - 1;

                if (YearsFromBloom >= 3)
                {
                    return "E";
                }
                else if (YearsFromBloom < 0) 
                {
                    return "U";
                }
                else
                {
                    if (YearsFromBloom == 0)
                        return (YearsFromBloom+1).ToString();
                    else
                        return (YearsFromBloom + 1).ToString();
                }
            }

            return "-";
        }
    }

    class TMR_BloomEditControl : TextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public TMR_BloomEditControl()
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
