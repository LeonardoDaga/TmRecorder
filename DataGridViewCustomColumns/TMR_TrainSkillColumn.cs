using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DataGridViewCustomColumns
{
    public partial class TMR_TrainSkillColumn : DataGridViewColumn
    {
        public TMR_TrainSkillColumn()
            : base(new TMR_TrainSkillCell())
        {
            InitializeComponent();
        }

        public TMR_TrainSkillColumn(IContainer container)
            : base(new TMR_TrainSkillCell())
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
                    !value.GetType().IsAssignableFrom(typeof(TMR_TrainSkillCell)))
                {
                    throw new InvalidCastException("Must be a TMR_TrainSkillCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    #region TMR_TrainSkillColumn

    public class TMR_TrainSkillCell : DataGridViewTextBoxCell
    {
        public short status = 2;

        public TMR_TrainSkillCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            TMR_TrainSkillEditingControl ctl =
                DataGridView.EditingControl as TMR_TrainSkillEditingControl;

            if (this.Value != System.DBNull.Value)
            {
                ctl.Text = System.Convert.ToString(this.Value);
            }

        }

        public override object Clone()
        {
            TMR_TrainSkillCell clone = (TMR_TrainSkillCell)base.Clone();
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
            sf.FormatFlags = StringFormatFlags.NoWrap;

            Brush fbr = null, bbr = null;
            Pen gbr = null;

            TMR_TrainSkillColumn dnc = (TMR_TrainSkillColumn)this.OwningColumn;            

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

            Point pt = cellRect.Location;

            string allsk = (string)value;
            string[] sks = allsk.Split(';');
            int numsk = sks.Length-1;

            object obj = this.OwningColumn.DataPropertyName;

            for (int i = 0; i < numsk; i++)
            {
                Brush hbr = null;
                Brush nbr = null;

                pt.Offset((cellRect.Width*(i-1))/numsk, 
                    0);
                Rectangle rect = new Rectangle(cellRect.Left + (cellRect.Width*i) / numsk, 
                    cellRect.Top, 
                    cellRect.Width / numsk,
                    cellRect.Height);

                string sk = sks[i].Split(':')[0];

                if ((sk == "Phy") || (allsk == "Str;Sta;Pac;Wor;"))
                {
                    hbr = new SolidBrush(Color.Black);
                    nbr = new SolidBrush(Color.Yellow);
                }
                else if ((sk == "Def") || (allsk == "Mar;Tak;Pos;Hea;"))
                {
                    hbr = new SolidBrush(Color.Black);
                    nbr = new SolidBrush(Color.Cyan);
                }
                else if ((sk == "Win") || (allsk == "Cro;Pac;Tec;"))
                {
                    hbr = new SolidBrush(Color.Black);
                    nbr = new SolidBrush(Color.LightGray);
                }
                else if ((sk == "Tec") || (allsk == "Tec;Pas;Set;"))
                {
                    hbr = new SolidBrush(Color.Black);
                    nbr = new SolidBrush(Color.Orange);
                }
                else if ((sk == "Att") || (allsk == "Fin;Lon;Hea;"))
                {
                    hbr = new SolidBrush(Color.Black);
                    nbr = new SolidBrush(Color.LightBlue);
                }
                else if ((sk == "Hea") || (allsk == "Wor;Pos;Pas;"))
                {
                    hbr = new SolidBrush(Color.Black);
                    nbr = new SolidBrush(Color.LightCoral);
                }
                else
                {
                    hbr = new SolidBrush(Color.Black);
                    nbr = new SolidBrush(Color.White);
                }

                SizeF szf = graphics.MeasureString(sk.ToString(), cellStyle.Font);

                graphics.FillRectangle(nbr, rect);
                graphics.DrawRectangle(gbr, rect);

                Font small = new Font(cellStyle.Font.FontFamily, (float)(cellStyle.Font.SizeInPoints - 0.75f));
                graphics.DrawString(sks[i], small, hbr, rect, sf);

                hbr.Dispose();
                nbr.Dispose();
            }

            this.ToolTipText = (string)value;

            graphics.DrawRectangle(gbr, cellRect);

            fbr.Dispose();
            bbr.Dispose();
            gbr.Dispose();
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that TMR_TrainSkillCell uses.
                return typeof(TMR_TrainSkillEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that TMR_TrainSkillCell contains.
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
            return value.ToString();
        }
    }

    class TMR_TrainSkillEditingControl : TextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public TMR_TrainSkillEditingControl()
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
            return this.Text;
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
