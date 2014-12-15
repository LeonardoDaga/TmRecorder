using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using NTR_Common;

namespace DataGridViewCustomColumns
{
    public partial class TMR_NumericStyledColumn : DataGridViewColumn
    {
        public TMR_NumericStyledColumn()
            : base(new TMR_NumericStyledCell())
        {
            InitializeComponent();
        }

        public TMR_NumericStyledColumn(IContainer container)
            : base(new TMR_NumericStyledCell())
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
                    !value.GetType().IsAssignableFrom(typeof(TMR_NumericStyledCell)))
                {
                    throw new InvalidCastException("Must be a TMR_NumericStyledCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    #region TMR_NumericStyledCell

    public class TMR_NumericStyledCell : DataGridViewTextBoxCell
    {
        public short status = 2;
        public bool filterASIvalue = false;

        public TMR_NumericStyledCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            TMR_NumericStyledEditingControl ctl =
                DataGridView.EditingControl as TMR_NumericStyledEditingControl;

            if (this.Value != System.DBNull.Value)
            {
                ctl.Value = System.Convert.ToDecimal(this.Value);
            }

        }

        public override object Clone()
        {
            TMR_NumericStyledCell clone = (TMR_NumericStyledCell)base.Clone();
            clone.status = this.status;
            clone.filterASIvalue = this.filterASIvalue;
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
            try
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;

                TMR_NumericStyledColumn dgc = (TMR_NumericStyledColumn)(this.OwningColumn);

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

                Rectangle cellRect = cellBounds;
                cellRect.Offset(-1, -1);
                graphics.FillRectangle(bbr, cellRect);
                graphics.DrawRectangle(gbr, cellRect);

                decimal dec;
                dec = Convert.ToDecimal(value);

                string str;

                str = ((int)dec).ToString();

                SizeF szf = new SizeF(0, 0);

                if (this.OwningColumn.DataPropertyName == "ASI")
                    filterASIvalue = true;

                //if ((dec < 19) || (filterASIvalue))
                //{
                //    graphics.DrawString(str.ToString(), cellStyle.Font, fbr, cellRect, sf);
                //    szf = graphics.MeasureString(str.ToString(), cellStyle.Font);
                //}
                //else if ((dec >= 19) && (dec < 20))
                //{
                //    Point pt = cellRect.Location;
                //    pt.Offset(2, (cellRect.Height - dgc.iconList1.ImageSize.Height) / 2);
                //    graphics.DrawImage(dgc.iconList1.Images[1], pt);
                //    szf = dgc.iconList1.ImageSize;
                //}
                //else if (dec == 20)
                //{
                //    Point pt = cellRect.Location;
                //    pt.Offset(2, (cellRect.Height - dgc.iconList1.ImageSize.Height) / 2);
                //    graphics.DrawImage(dgc.iconList1.Images[0], pt);
                //    szf = dgc.iconList1.ImageSize;
                //}

                //Point pt2 = cellRect.Location;
                //pt2.Offset((int)szf.Width, (cellRect.Height - dgc.iconList2.ImageSize.Height) / 2);
                //Rectangle rect = new Rectangle(pt2, new Size(9, 12));

                //System.Data.DataRowView dr = (System.Data.DataRowView)this.OwningRow.DataBoundItem;
                //TeamDS.GiocatoriNSkillRow gnsRow = (TeamDS.GiocatoriNSkillRow)dr.Row;

                //if (this.OwningColumn.DataPropertyName != "ASI")
                //{
                //    decimal val_change = (decimal)gnsRow.Player_VDR_Change[OwningColumn.DataPropertyName];
                //    if (val_change > 0)
                //    {
                //        // Dark green arrow
                //        graphics.DrawImage(dgc.iconList2.Images[0], pt2);
                //        this.ToolTipText = "+1";
                //    }
                //    else if (val_change < 0)
                //    {
                //        // Dark red arrow
                //        graphics.DrawImage(dgc.iconList2.Images[3], pt2);
                //        this.ToolTipText = "-1";
                //    }
                //    else
                //    {
                //        this.ToolTipText = "Unchanged skill";
                //    }
                //}
                //else
                //{
                //    int val_change = (int)gnsRow.Player_VDR_Change[OwningColumn.DataPropertyName];
                //    if (val_change > 0)
                //    {
                //        // Dark green arrow
                //        graphics.DrawImage(dgc.iconList2.Images[0], pt2);
                //        this.ToolTipText = "+" + val_change.ToString("N0");
                //    }
                //    else if (val_change < 0)
                //    {
                //        // Dark red arrow
                //        graphics.DrawImage(dgc.iconList2.Images[3], pt2);
                //        this.ToolTipText = val_change.ToString("N0");
                //    }
                //}

                decimal decpart = (dec - (decimal)((int)dec));

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
                // Return the type of the editing contol that TMR_NumericStyledCell uses.
                return typeof(TMR_NumericStyledEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that TMR_NumericStyledCell contains.
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

    class TMR_NumericStyledEditingControl : NumericUpDown, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public TMR_NumericStyledEditingControl()
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
