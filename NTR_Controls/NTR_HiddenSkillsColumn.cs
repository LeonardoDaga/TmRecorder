using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Common;
using NTR_Db;

namespace NTR_Controls
{
    public partial class NTR_HiddenSkillColumn : DataGridViewColumn
    {
        public NTR_HiddenSkillColumn()
            : base(new NTR_HiddenSkillColumnCell())
        {
            InitializeComponent();
        }

        public NTR_HiddenSkillColumn(IContainer container)
            : base(new NTR_HiddenSkillColumnCell())
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
                    !value.GetType().IsAssignableFrom(typeof(NTR_HiddenSkillColumnCell)))
                {
                    throw new InvalidCastException("Must be a NTR_HiddenSkillColumnCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    #region NTR_HiddenSkillColumnCell

    public class NTR_HiddenSkillColumnCell : DataGridViewTextBoxCell
    {
        public NTR_HiddenSkillColumnCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);

            NTR_HiddenSkillColumnControl ctl =
                DataGridView.EditingControl as NTR_HiddenSkillColumnControl;

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
                decimal Pro = 2M;
                decimal Lea = 13M;

                decimal Agg = 5M;
                decimal Inj = 18M;

                Brush fbr = null, bbr = null;
                Pen gbr = null;

                DataGridViewElementStates isSelected = cellState & DataGridViewElementStates.Selected;

                if (isSelected == DataGridViewElementStates.Selected)
                {
                    bbr = new SolidBrush(Color.FromArgb(0, 0, 196));
                }
                else
                {
                    bbr = new SolidBrush(Color.FromArgb(0, 0, 64));
                }
                
                gbr = new Pen(this.DataGridView.GridColor);
                Rectangle cellRect = cellBounds;
                cellRect.Offset(-1, -1);
                graphics.FillRectangle(bbr, cellRect);
                graphics.DrawRectangle(gbr, cellRect);

                int margin = 1;
                Rectangle letterRect = new Rectangle(cellBounds.X - 1 + margin, cellBounds.Y - 1, cellBounds.Width - margin * 2, cellBounds.Height);

                string str = value.ToString();

                // Draw professionalism
                fbr = new SolidBrush(Utility.GradeColor((float)Pro, 20));

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;

                Font font = new Font(cellStyle.Font.FontFamily, 7.5f, FontStyle.Regular);

                graphics.DrawString("P", font, fbr, letterRect, sf);

                // Draw Leadership
                fbr = new SolidBrush(Utility.GradeColor((float)Lea, 20));

                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Near;

                font = new Font(cellStyle.Font.FontFamily, 7.5f, FontStyle.Regular);

                graphics.DrawString("L", font, fbr, letterRect, sf);

                // Draw Injury Proneness
                fbr = new SolidBrush(Utility.GradeColor((float)Inj, 20));

                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Far;

                font = new Font(cellStyle.Font.FontFamily, 7.5f, FontStyle.Regular);

                graphics.DrawString("I", font, fbr, letterRect, sf);

                // Draw Aggressive
                fbr = new SolidBrush(Utility.GradeColor((float)Agg, 20));

                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;

                font = new Font(cellStyle.Font.FontFamily, 7.5f, FontStyle.Regular);

                graphics.DrawString("A", font, fbr, letterRect, sf);

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
                // Return the type of the editing contol that TMR_ReportCell uses.
                return typeof(NTR_HiddenSkillColumnControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that TMR_ReportCell contains.
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
            string colName = this.OwningColumn.DataPropertyName;

            NTR_HiddenSkillColumn repCol = (NTR_HiddenSkillColumn)OwningColumn;

            DataGridViewCellStyle cs = new DataGridViewCellStyle(cellStyle);

            if (value == null)
                return "";

            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
    }

    class NTR_HiddenSkillColumnControl : TextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public NTR_HiddenSkillColumnControl()
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
