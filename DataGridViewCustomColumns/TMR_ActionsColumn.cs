using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DataGridViewCustomColumns
{
    public partial class TMR_ActionsColumn : DataGridViewColumn
    {
        public TMR_ActionsColumn()
            : base(new TMR_ActionsCell())
        {
            InitializeComponent();
        }

        public TMR_ActionsColumn(IContainer container)
            : base(new TMR_ActionsCell())
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
                    !value.GetType().IsAssignableFrom(typeof(TMR_ActionsCell)))
                {
                    throw new InvalidCastException("Must be a TMR_ActionsCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    #region TMR_ActionsColumn

    public class TMR_ActionsCell : DataGridViewTextBoxCell
    {
        public short status = 2;

        public TMR_ActionsCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            TMR_ActionsEditingControl ctl =
                DataGridView.EditingControl as TMR_ActionsEditingControl;

            if (this.Value != System.DBNull.Value)
            {
                ctl.Text = System.Convert.ToString(this.Value);
            }

        }

        public override object Clone()
        {
            TMR_ActionsCell clone = (TMR_ActionsCell)base.Clone();
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

            TMR_ActionsColumn dnc = (TMR_ActionsColumn)this.OwningColumn;
            DataGridViewRow dr = this.OwningRow;

            DataGridViewElementStates isSelected = cellState & DataGridViewElementStates.Selected;

            if (isSelected == DataGridViewElementStates.Selected)
            {
                bbr = new SolidBrush(cellStyle.SelectionBackColor);
            }
            else
            {
                bbr = new SolidBrush(cellStyle.BackColor);
            }
            fbr = new SolidBrush(cellStyle.ForeColor);
            gbr = new Pen(this.DataGridView.GridColor);
            Brush hbr = new SolidBrush(Color.Blue);

            Rectangle cellRect = cellBounds;
            cellRect.Offset(-1, -1);
            graphics.FillRectangle(bbr, cellRect);
            graphics.DrawRectangle(gbr, cellRect);

            Point pt = cellRect.Location;
            pt.Offset((cellRect.Width - dnc.actionsImgList.ImageSize.Width) / 2,
                (cellRect.Height - dnc.actionsImgList.ImageSize.Height) / 2);

            Rectangle rcImage = new Rectangle(pt.X, pt.Y, dnc.actionsImgList.ImageSize.Width,
                dnc.actionsImgList.ImageSize.Height);
            graphics.FillRectangle(fbr, rcImage);

            int ix = 0;
            if (value.ToString() != "")
                ix = dnc.actionsImgList.Images.IndexOfKey(value.ToString() + ".gif");
            if (ix == -1) ix = 0;
            graphics.DrawImage(dnc.actionsImgList.Images[ix], pt);

            this.ToolTipText = value.ToString();

            hbr.Dispose();
            fbr.Dispose();
            bbr.Dispose();
            gbr.Dispose();
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that TMR_ActionsCell uses.
                return typeof(TMR_ActionsEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that TMR_ActionsCell contains.
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
    }

    class TMR_ActionsEditingControl : TextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public TMR_ActionsEditingControl()
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

        protected override void  OnTextChanged(EventArgs e)
        {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
 	         base.OnTextChanged(e);
        }
    }

    #endregion
}
