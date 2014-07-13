using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DataGridViewCustomColumns
{
    public partial class TMR_ArrowColumn : DataGridViewColumn
    {
        public TMR_ArrowColumn()
            : base(new TMR_ArrowCell())
        {
            InitializeComponent();
        }

        public TMR_ArrowColumn(IContainer container)
            : base(new TMR_ArrowCell())
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
                    !value.GetType().IsAssignableFrom(typeof(TMR_ArrowCell)))
                {
                    throw new InvalidCastException("Must be a TMR_ArrowCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    #region TMR_ArrowColumn

    public class TMR_ArrowCell : DataGridViewTextBoxCell
    {
        public short status = 2;

        public TMR_ArrowCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            TMR_ArrowEditingControl ctl =
                DataGridView.EditingControl as TMR_ArrowEditingControl;

            if (this.Value != System.DBNull.Value)
            {
                ctl.Text = System.Convert.ToString(this.Value);
            }

        }

        public override object Clone()
        {
            TMR_ArrowCell clone = (TMR_ArrowCell)base.Clone();
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
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            Brush fbr = null, bbr = null;
            Pen gbr = null;

            TMR_ArrowColumn dnc = (TMR_ArrowColumn)this.OwningColumn;            

            DataGridViewElementStates isSelected = cellState & DataGridViewElementStates.Selected;

            if (isSelected == DataGridViewElementStates.Selected)
            {
                fbr = new SolidBrush(cellStyle.SelectionForeColor);
            }
            else
            {
                fbr = new SolidBrush(cellStyle.ForeColor);
            }
            gbr = new Pen(this.DataGridView.GridColor);
            Brush hbr = new SolidBrush(Color.Blue);

            Rectangle cellRect = cellBounds;
            cellRect.Offset(-1, -1);

            Point pt = cellRect.Location;
            pt.Offset(1, (cellRect.Height - dnc.arrowIcons.ImageSize.Height) / 2);

            Image image = null;
            decimal val = (decimal)value;

            int skVal = ((int)val) / 100;

            int colorCode = ((int)val) % 100 / 10;

            switch (colorCode)
            {
                case 1: bbr = new SolidBrush(Color.Yellow); break;
                case 2: bbr = new SolidBrush(Color.Cyan); break;
                case 3: bbr = new SolidBrush(Color.Orange); break;
                case 4: bbr = new SolidBrush(Color.LightGray); break;
                case 5: bbr = new SolidBrush(Color.LightCoral); break;
                case 6: bbr = new SolidBrush(Color.LightBlue); break;
                default:
                    if (isSelected == DataGridViewElementStates.Selected)
                    {
                        bbr = new SolidBrush(cellStyle.SelectionBackColor);
                    }
                    else
                    {
                        bbr = new SolidBrush(cellStyle.BackColor);
                    }
                    break;
            }
            graphics.FillRectangle(bbr, cellRect);
            graphics.DrawRectangle(gbr, cellRect);

            val = val%10;

            if (val == 4M)
            {
                image = dnc.arrowIcons.Images[0];
                this.ToolTipText = "decimal increment";
            }
            else if (val == 3M)
            {
                image = dnc.arrowIcons.Images[1];
                this.ToolTipText = "unitary increment";
            }
            else if (val == 2M)
            {
                // image = dnc.arrowIcons.Images[4]; 
                image = null;
                this.ToolTipText = "no increment";
            }
            else if (val == 1M)
            {
                image = dnc.arrowIcons.Images[2]; 
                this.ToolTipText = "decimal decrement";
            }
            else if (val == 0M)
            {
                image = dnc.arrowIcons.Images[3]; 
                this.ToolTipText = "unitary decrement";
            }

            if (image != null)
            {
                Rectangle rcImage = new Rectangle(cellRect.Left + cellRect.Width - image.Width, pt.Y, image.Width,
                    image.Height);
                graphics.DrawImage(image, rcImage);
            }

            Rectangle rcNumber = new Rectangle(cellRect.Left, pt.Y, cellRect.Width - dnc.arrowIcons.ImageSize.Width + 3,
                dnc.arrowIcons.ImageSize.Height);
            
            graphics.DrawString(skVal.ToString(), cellStyle.Font, fbr, rcNumber);

            graphics.DrawRectangle(gbr, cellRect);

            hbr.Dispose();
            fbr.Dispose();
            bbr.Dispose();
            gbr.Dispose();
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that TMR_ArrowCell uses.
                return typeof(TMR_ArrowEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that TMR_ArrowCell contains.
                return typeof(decimal);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return (decimal)0;
            }
        }

        protected override object GetFormattedValue(object value, int rowIndex, 
                                            ref DataGridViewCellStyle cellStyle, 
                                            TypeConverter valueTypeConverter, 
                                            TypeConverter formattedValueTypeConverter, 
                                            DataGridViewDataErrorContexts context)
        {
            return value.ToString();
        }
    }

    class TMR_ArrowEditingControl : TextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public TMR_ArrowEditingControl()
        {
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value.ToString();
            }
        }

        // Implements the 
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return "Cicc";
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

        protected override void  OnTextChanged(EventArgs e)
        {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
 	         base.OnTextChanged(e);
        }
    }

    #endregion
}
