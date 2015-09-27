using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DataGridViewCustomColumns
{
    public partial class TMR_NameInjurySqColumn : DataGridViewColumn
    {
        public int minColumnSize = 0;

        public TMR_NameInjurySqColumn()
            : base(new TMR_NameNStatCell())
        {
            InitializeComponent();
        }

        public TMR_NameInjurySqColumn(IContainer container)
            : base(new TMR_NameNStatCell())
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
                    !value.GetType().IsAssignableFrom(typeof(TMR_NameNStatCell)))
                {
                    throw new InvalidCastException("Must be a TMR_NameNStatCell");
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

    #region TMR_NameNStatCell

    public class TMR_NameNStatCell : DataGridViewTextBoxCell
    {
        public short injuried = 0; // Number of weeks
        public short banned = 0; // 0: none, 1: yellow card, 2: red card 1 week, 3: red card 2 week
        public short teamType = 0; // 0: main team, 1: young team
        public short retire = 0; // 0: no retire, 1: retire

        private Size preferredSize = new Size(-1, -1);

        public TMR_NameNStatCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);

            TMR_NISEditingControl ctl =
                DataGridView.EditingControl as TMR_NISEditingControl;

            if (this.Value != System.DBNull.Value)
            {
                ctl.Text = System.Convert.ToString(this.Value);
            }

        }

        public override object Clone()
        {
            TMR_NameNStatCell clone = (TMR_NameNStatCell)base.Clone();
            clone.injuried = this.injuried;
            clone.banned = this.banned;
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
            string val = Convert.ToString(value);
            //if (val.IndexOf("&#39;") != 0)
            //{
            //    val = val.Replace("&#39;", "'");
            //}
            string[] toks = val.Split('|');
            string str = toks[0];
            if (toks.Length > 1) injuried = short.Parse(toks[1]);
            if (toks.Length > 2) banned = short.Parse(toks[2]);
            if (toks.Length > 3) teamType = short.Parse(toks[3]);
            if (toks.Length > 4) retire = short.Parse(toks[4]);

            if (teamType == 1)
            {
                cellStyle.ForeColor = Color.Blue;
                cellStyle.SelectionForeColor = Color.LightCyan;
            }

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

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            TMR_NameInjurySqColumn dgc = (TMR_NameInjurySqColumn)(this.OwningColumn);
            SizeF szf = graphics.MeasureString(str.ToString(), cellStyle.Font);

            Point pt2 = cellBounds.Location;
            pt2.Offset((int)szf.Width, (cellBounds.Height - dgc.statusList.ImageSize.Height) / 2);

            Brush fbr = null;

            DataGridViewElementStates isSelected = cellState & DataGridViewElementStates.Selected;

            if (isSelected == DataGridViewElementStates.Selected)
            {
                fbr = new SolidBrush(cellStyle.SelectionForeColor);
            }
            else
            {
                fbr = new SolidBrush(cellStyle.ForeColor);
            }

            pt2.X += 5;
            if (this.banned != 0)
            {
                switch ((int)this.banned)
                {
                    case 1:
                        graphics.DrawImage(dgc.statusList.Images[0], pt2);
                        pt2.X += 9;
                        break;
                    case 2:
                        graphics.DrawImage(dgc.statusList.Images[1], pt2);
                        pt2.X += 9;
                        break;
                    case 3:
                        graphics.DrawImage(dgc.statusList.Images[2], pt2);
                        pt2.X += 9;
                        break;
                    default:
                        graphics.DrawImage(dgc.statusList.Images[3], pt2);

                        if (this.banned > 4)
                        {
                            pt2.X += 8;
                            graphics.DrawString((banned-4).ToString(), cellStyle.Font, fbr, pt2.X, pt2.Y + 4, sf);
                        }
                        pt2.X += 9;
                        break;
                }
            }

            if (this.injuried != 0)
            {
                graphics.DrawImage(dgc.statusList.Images[4], pt2);

                if (this.injuried > 1)
                {
                    pt2.X += 9;
                    graphics.DrawString((injuried).ToString(), cellStyle.Font, fbr, pt2.X, pt2.Y + 4, sf);
                }
                pt2.X += 9;
            }

            if (this.retire != 0)
            {
                graphics.DrawImage(dgc.statusList.Images[5], pt2);
                pt2.X += 9;
            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that TMR_NameNStatCell uses.
                return typeof(TMR_NISEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that TMR_NameNStatCell contains.
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

            string str = (string)value;

            //if (str.IndexOf("&#39;") != 0)
            //{
            //    str = str.Replace("&#39;", "'");
            //}
            string[] toks = str.Split('|');
            if (toks.Length > 1) injuried = short.Parse(toks[1]);
            if (toks.Length > 2) banned = short.Parse(toks[2]);
            if (toks.Length > 3) teamType = short.Parse(toks[3]);
            if (toks.Length > 4) retire = short.Parse(toks[4]);

            if (injuried == 1)
                toks[0] += "   ";
            if (injuried > 1)
                toks[0] += "      ";

            if ((banned >= 1) && (banned <= 4))
                toks[0] += "    ";
            if (banned > 4)
                toks[0] += "     ";

            if (retire == 1)
                toks[0] += "   ";

            return toks[0];
        }
    }

    class TMR_NISEditingControl : TextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public TMR_NISEditingControl()
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
