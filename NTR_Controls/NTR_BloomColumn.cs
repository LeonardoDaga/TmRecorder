using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Common;
using System.Data;

namespace NTR_Controls
{
    public partial class NTR_BloomColumn : DataGridViewColumn
    {
        public int minColumnSize = 0;

        public NTR_BloomColumn()
            : base(new NTR_BloomCell())
        {
            InitializeComponent();
        }

        public NTR_BloomColumn(IContainer container)
            : base(new NTR_BloomCell())
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
                    !value.GetType().IsAssignableFrom(typeof(NTR_BloomCell)))
                {
                    throw new InvalidCastException("Must be a NTR_BloomCell");
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

    #region NTR_BloomCell

    public class NTR_BloomCell : DataGridViewTextBoxCell
    {
        public NTR_BloomCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);

            NTR_BloomEditControl ctl =
                DataGridView.EditingControl as NTR_BloomEditControl;

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

                //if (OwningColumn.Name == "BloomingPhase")
                //{
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
                //}
                //else
                //{
                //    base.Paint(graphics,
                //               clipBounds,
                //               cellBounds,
                //               rowIndex,
                //               cellState,
                //               formattedValue,
                //               formattedValue.ToString(),
                //               errorText,
                //               cellStyle,
                //               advancedBorderStyle,
                //               paintParts);
                //}
                
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
                // Return the type of the editing contol that NTR_BloomCell uses.
                return typeof(NTR_BloomEditControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that NTR_BloomCell contains.
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

            NTR_Db.PlayerData pd = (NTR_Db.PlayerData)(this.DataGridView.Rows[rowIndex].DataBoundItem);

            int wBorn = (int)pd.wBorn;
            int wNow = TmWeek.GetTmAbsWk(DateTime.Now);

            int wBloomStart = (int)value;

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
    }

    class NTR_BloomEditControl : TextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public NTR_BloomEditControl()
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
