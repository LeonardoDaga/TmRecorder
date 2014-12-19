using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DataGridViewCustomColumns
{
    public partial class TMR_FpColumn : DataGridViewColumn
    {
        public TMR_FpColumn()
            : base(new TMR_FpCell())
        {
            InitializeComponent();
        }

        public TMR_FpColumn(IContainer container)
            : base(new TMR_FpCell())
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
                    !value.GetType().IsAssignableFrom(typeof(TMR_FpCell)))
                {
                    throw new InvalidCastException("Must be a TMR_FpCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    #region TMR_FpColumn

    public class TMR_FpCell : DataGridViewTextBoxCell
    {
        public short status = 2;

        public TMR_FpCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            TMR_FpEditingControl ctl =
                DataGridView.EditingControl as TMR_FpEditingControl;

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
            TMR_FpCell clone = (TMR_FpCell)base.Clone();
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

            TMR_FpColumn dnc = (TMR_FpColumn)this.OwningColumn;            

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

            /*
            Brush DefBr = new SolidBrush(Color.FromArgb(0, 196, 255));
            Brush MidBr = new SolidBrush(Color.Yellow);
            Brush AttBr = new SolidBrush(Color.FromArgb(255, 32, 32));

            Rectangle cellRect = cellBounds;
            cellRect.Offset(-1, -1);
            graphics.FillRectangle(bbr, cellRect);

            Rectangle leftRect = cellRect;
            leftRect.Width = cellRect.Width / 2;

            Rectangle rightRect = cellRect;
            rightRect.Width = cellRect.Width / 2;
            rightRect.Offset(rightRect.Width, 0);

            string formattVal = formattedValue.ToString();
            if (formattVal.Contains("D") && formattVal.Contains("M"))
            {
                graphics.FillRectangle(DefBr, leftRect);
                graphics.FillRectangle(MidBr, rightRect);
            }
            else if (formattVal.Contains("O") && formattVal.Contains("M"))
            {
                graphics.FillRectangle(AttBr, leftRect);
                graphics.FillRectangle(MidBr, rightRect);
            }
            else if (formattVal.Contains("D"))
            {
                graphics.FillRectangle(DefBr, cellRect);
            }
            else if (formattVal.Contains("M"))
            {
                graphics.FillRectangle(MidBr, cellRect);
            }
            else if (formattVal.Contains("F"))
            {
                graphics.FillRectangle(AttBr, cellRect);
            }

            Point pt = cellRect.Location;
            //pt.Offset((cellRect.Width - dnc.actionsImgList.ImageSize.Width) / 2,
            //    (cellRect.Height - dnc.actionsImgList.ImageSize.Height) / 2);

            graphics.DrawString(formattedValue.ToString(), cellStyle.Font, fbr, cellRect, sf);
            */

            Rectangle cellRect = cellBounds;
            cellRect.Offset(-1, -1);
            graphics.FillRectangle(bbr, cellRect);
            graphics.DrawRectangle(gbr, cellRect);

            string[] FPs = formattedValue.ToString().Split('/');

            if (FPs.Length == 1)
            {
                Point pt = cellRect.Location;
                pt.Offset(2, (cellRect.Height - dnc.posImgList.ImageSize.Height) / 2);

                int ix = 0;
                if (formattedValue.ToString() != "")
                    ix = dnc.posImgList.Images.IndexOfKey(formattedValue.ToString() + ".gif");
                if (ix == -1) ix = 0;

                Image image = dnc.posImgList.Images[ix];

                Rectangle rcImage = new Rectangle(pt.X, pt.Y, image.Width,
                    image.Height);

                graphics.DrawImage(image, pt);
            }
            else
            {
                Point pt = cellRect.Location;
                pt.Offset(2, (cellRect.Height - dnc.posImgList.ImageSize.Height) / 2);

                int ix = 0;
                if (FPs[0].ToString() != "")
                    ix = dnc.posImgList.Images.IndexOfKey(FPs[0].ToString() + ".gif");
                if (ix == -1) ix = 0;

                Image image = dnc.posImgList.Images[ix];

                Rectangle rcImage = new Rectangle(pt.X, pt.Y, image.Width,
                    image.Height);

                graphics.DrawImage(image, pt);

                ix = dnc.posImgList.Images.IndexOfKey(FPs[1].ToString() + ".gif");
                if (ix == -1) ix = 0;

                image = dnc.posImgList.Images[ix];

                pt = cellRect.Location;
                pt.Offset(3 + image.Width, (cellRect.Height - image.Height) / 2);

                rcImage = new Rectangle(pt.X, pt.Y, image.Width,
                    image.Height);

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
                // Return the type of the editing contol that TMR_FpCell uses.
                return typeof(TMR_FpEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that TMR_FpCell contains.
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

            Type type = value.GetType();
            if (type.Name == "String")
                return (string)value;

            if (type.Name == "DBNull")
                return (string)"GK";

            int val = (int)value;

            //cellStyle.Font = new Font(cellStyle.Font.FontFamily, (float) cellStyle.Font.Size+1f);

            switch (val)
            {
                case 0: return "GK";
                case 10: return "DC";
                case 11: return "DC/DL";
                case 12: return "DC/DR";
                case 13: return "DL";
                case 14: return "DR/DL";
                case 15: return "DR";
                case 20: return "DC/DMC";
                case 21: return "DL/DML";
                case 22: return "DMR/DR";
                case 30: return "DMC";
                case 31: return "DMC/DML";
                case 32: return "DMC/DMR";
                case 33: return "DML";
                case 34: return "DML/DMR";
                case 35: return "DMR";
                case 40: return "DMC/MC";
                case 41: return "DML/ML";
                case 42: return "DMR/MR";
                case 50: return "MC";
                case 51: return "MC/ML";
                case 52: return "MC/MR";
                case 53: return "ML";
                case 54: return "ML/MR";
                case 55: return "MR";
                case 60: return "MC/OMC";
                case 61: return "ML/OML";
                case 62: return "MR/OMR";
                case 70: return "OMC";
                case 71: return "OMC/OML";
                case 72: return "OMC/OMR";
                case 73: return "OML";
                case 74: return "OML/OMR";
                case 75: return "OMR";
                case 80: return "FC/OMC";
                case 81: return "FC/OML";
                case 82: return "FC/OMR";
                case 90: return "FC";
                default: return "NOID";
            }
        }
    }

    class TMR_FpEditingControl : TextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public TMR_FpEditingControl()
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
