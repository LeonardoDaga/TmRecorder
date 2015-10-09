using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace NTR_Controls
{
    public partial class NTR_ImgColumn : DataGridViewColumn
    {
        public ImgContainer imgContainer = new ImgContainer();

        public enum ImgType
        {
            Rec,
        }

        public ImgType ImageType { get; set; }
        
        public NTR_ImgColumn(ImgType imgType)
            : base(new NTR_ImgCell())
        {
            ImageType = imgType;
            InitializeComponent();
        }

        public NTR_ImgColumn(IContainer container)
            : base(new NTR_ImgCell())
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
                    !value.GetType().IsAssignableFrom(typeof(NTR_ImgCell)))
                {
                    throw new InvalidCastException("Must be a NTR_ImgCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    #region NTR_ImgColumn

    public class NTR_ImgCell : DataGridViewTextBoxCell
    {
        public short status = 2;

        public NTR_ImgCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            NTR_ImgEditingControl ctl =
                DataGridView.EditingControl as NTR_ImgEditingControl;

            if (this.Value != System.DBNull.Value)
            {
                ctl.Text = System.Convert.ToString(this.Value);
            }

        }

        protected override object GetValue(int rowIndex)
        {
            return base.GetValue(rowIndex);
        }

        public override object Clone()
        {
            NTR_ImgCell clone = (NTR_ImgCell)base.Clone();
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

            NTR_ImgColumn dnc = (NTR_ImgColumn)this.OwningColumn;            

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
            cellRect.Offset(-1, -1);
            graphics.FillRectangle(bbr, cellRect);
            graphics.DrawRectangle(gbr, cellRect);

            {
                Point pt = cellRect.Location;
                pt.Offset(2, (cellRect.Height - dnc.imgContainer.starRowImgList.ImageSize.Height) / 2);

                decimal ivalue = (decimal)value * 2M;

                if ((ivalue == 0) || (ivalue > 10))
                    ivalue = 1;

                string strValue = ivalue.ToString("N0");

                Image image = null;

                int ix = dnc.imgContainer.starRowImgList.Images.IndexOfKey(strValue + ".png");
                if (ix != -1) image = dnc.imgContainer.starRowImgList.Images[ix];

                if (image == null)
                {
                    image = dnc.imgContainer.starRowImgList.Images[0];
                }

                graphics.DrawImage(image, pt);
            }

            this.ToolTipText = formattedValue.ToString();

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
                // Return the type of the editing contol that NTR_ImgCell uses.
                return typeof(NTR_ImgEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that NTR_ImgCell contains.
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
            return value;
        }
    }

    class NTR_ImgEditingControl : TextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public NTR_ImgEditingControl()
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
