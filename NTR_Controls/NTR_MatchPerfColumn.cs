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
    public partial class NTR_MatchPerfColumn : DataGridViewColumn
    {
        public NTR_MatchPerfColumn()
            : base(new NTR_MatchPerfColumnCell())
        {
            InitializeComponent();
        }

        public NTR_MatchPerfColumn(IContainer container)
            : base(new NTR_MatchPerfColumnCell())
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
                    !value.GetType().IsAssignableFrom(typeof(NTR_MatchPerfColumnCell)))
                {
                    throw new InvalidCastException("Must be a NTR_MatchPerfColumnCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    #region NTR_MatchPerfColumnCell

    public class NTR_MatchPerfColumnCell : DataGridViewTextBoxCell
    {
        public NTR_MatchPerfColumnCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);

            NTR_MatchPerfColumnControl ctl =
                DataGridView.EditingControl as NTR_MatchPerfColumnControl;

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
            Dictionary<string, string> values;

            string strValue = (string)value;

            if ((strValue == null) || (strValue == "") || (strValue == "0"))
                values = null;
            else
                values = HTML_Parser.String2Dictionary((string)value, ':');

            int AF = 0;
            int AO = 0;
            int AI = 0;
            int AG = 0;
            int AA = 0;
            int DF = 0;
            int DO = 0;
            int DI = 0;
            int DG = 0;

            if (values != null)
            {
                if (values.ContainsKey("AF")) AF = int.Parse(values["AF"]);
                if (values.ContainsKey("AO")) AO = int.Parse(values["AO"]);
                if (values.ContainsKey("AI")) AI = int.Parse(values["AI"]);
                if (values.ContainsKey("AG")) AG = int.Parse(values["AG"]);
                if (values.ContainsKey("AA")) AA = int.Parse(values["AA"]);
                if (values.ContainsKey("DF")) DF = int.Parse(values["DF"]);
                if (values.ContainsKey("DO")) DO = int.Parse(values["DO"]);
                if (values.ContainsKey("DI")) DI = int.Parse(values["DI"]);
                if (values.ContainsKey("DG")) DG = int.Parse(values["DG"]);
            }

            Brush fbr = null, bbr = null;
            Pen gbr = null;

            DataGridViewElementStates isSelected = cellState & DataGridViewElementStates.Selected;

            if (isSelected == DataGridViewElementStates.Selected)
            {
                bbr = new SolidBrush(Color.LightGray);
            }
            else
            {
                bbr = new SolidBrush(Color.White);
            }
                
            gbr = new Pen(this.DataGridView.GridColor);
            Rectangle cellRect = cellBounds;
            cellRect.Offset(-1, -1);
            graphics.FillRectangle(bbr, cellRect);
            graphics.DrawRectangle(gbr, cellRect);

            int margin = 1;
            Rectangle letterRect = new Rectangle(cellBounds.X - 1 + margin, cellBounds.Y - 1, cellBounds.Width - margin * 2, cellBounds.Height);

            // Draw attack results
            fbr = new SolidBrush(Color.DarkRed);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;


            string attack = "";
            //if (AF > 0) attack += AF.ToString() + "F ";
            //if (AO > 0) attack += AO.ToString() + "O ";
            //if (AI > 0) attack += AI.ToString() + "I ";
            //if (AG > 0) attack += AG.ToString() + "G ";
            for (int i = 0; i < AF; i++, attack += "F") ;
            for (int i = 0; i < AO; i++, attack += "O") ;
            for (int i = 0; i < AI; i++, attack += "I") ;
            for (int i = 0; i < AA; i++, attack += "A") ;
            for (int i = 0; i < AG; i++, attack += "G") ;

            graphics.DrawString(attack, cellStyle.Font, fbr, letterRect, sf);

            // Draw Defense results
            fbr = new SolidBrush(Color.Blue);

            sf.Alignment = StringAlignment.Far;
            sf.LineAlignment = StringAlignment.Center;


            string defense = "";
            //if (DF > 0) defense += DF.ToString() + "F ";
            //if (DO > 0) defense += DO.ToString() + "O ";
            //if (DI > 0) defense += DI.ToString() + "I ";
            //if (DG > 0) defense += DG.ToString() + "G ";
            for (int i = 0; i < DF; i++, defense += "F") ;
            for (int i = 0; i < DO; i++, defense += "O") ;
            for (int i = 0; i < DI; i++, defense += "I") ;
            for (int i = 0; i < DG; i++, defense += "G") ;

            graphics.DrawString(defense, cellStyle.Font, fbr, letterRect, sf);

            fbr.Dispose();
            bbr.Dispose();
            gbr.Dispose();
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that TMR_ReportCell uses.
                return typeof(NTR_MatchPerfColumnControl);
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

            NTR_MatchPerfColumn repCol = (NTR_MatchPerfColumn)OwningColumn;

            DataGridViewCellStyle cs = new DataGridViewCellStyle(cellStyle);

            if (value == null)
                return "";

            string formattedValue = ((string)value).Replace(":", "").Replace("A", "").Replace("D", "");

            return base.GetFormattedValue(formattedValue, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
    }

    class NTR_MatchPerfColumnControl : TextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public NTR_MatchPerfColumnControl()
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
