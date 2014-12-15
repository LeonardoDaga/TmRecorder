using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DataGridViewCustomColumns;
//using Common;

namespace NTR_Controls
{
    public partial class AeroDataGrid : DataGridView
    {
        //[DllImport("uxtheme", ExactSpelling = true, CharSet = CharSet.Unicode)]
        //public extern static Int32 SetWindowTheme(IntPtr hWnd,
        //              String textSubAppName, String textSubIdList);

        public AeroDataGrid()
        {
            InitializeComponent();
            this.DoubleBuffered = true;            
        }

        void AeroDataGrid_HandleCreated(object sender, EventArgs e)
        {
        }

        public DataGridViewColumn AddColumn(string Title, string Property, int width, AG_Style styles,
            DataGridViewCellStyle dgvCellStyle)
        {
            DefaultCellStyle = dgvCellStyle;
            return AddColumn(Title, Property, width, styles);
        }

        public DataGridViewColumn AddColumn(string Title, string Property, int width, AG_Style styles)
        {
            DataGridViewColumn dgv = null;

            if ((int)(styles & AG_Style.Numeric) > 0)
            {
                dgv = new DataGridViewTextBoxColumn();
            }
            else if ((int)(styles & AG_Style.Age) > 0)
            {
                dgv = new TMR_AgeColumn();
            }
            else if ((int)(styles & AG_Style.String) > 0)
            {
                dgv = new DataGridViewTextBoxColumn();
            }
            else if ((int)(styles & AG_Style.FavPosition) > 0)
            {
                dgv = new TMR_FpColumn();
            }
            else if ((int)(styles & AG_Style.NameInj) > 0)
            {
                dgv = new TMR_NameInjurySqColumn();
            }
            else if ((int)(styles & AG_Style.Nationality) > 0)
            {
                dgv = new TMR_NationColumn();
            }
            else if ((int)(styles & AG_Style.NumDec) > 0)
            {
                dgv = new TMR_NumDecColumn();
            }

            dgv.Name = Title;
            dgv.DataPropertyName = Property;
            dgv.Width = width;

            this.Columns.Add(dgv);

            dgv.Frozen = ((int)(styles & AG_Style.Frozen) > 0);

            if ((int)(styles & AG_Style.ResizeAllCells) > 0)
                dgv.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if ((int)(styles & AG_Style.RightJustified) > 0)
                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if ((int)(styles & AG_Style.N1) > 0)
                dgv.DefaultCellStyle.Format = "N1";

            return dgv;
        }

        public void SetWhen(DateTime when)
        {
            foreach (DataGridViewColumn dgv in this.Columns)
            {
                if (dgv.GetType() == typeof(TMR_AgeColumn))
                {
                    TMR_AgeColumn ageCol = (TMR_AgeColumn)dgv;
                    ageCol.When = when;
                }
            }
        }
    }

    [Flags]
    public enum AG_Style
    {
        Numeric = 0x01,
        Frozen = 0x02,
        Age = 0x04,
        String = 0x08,
        FavPosition = 0x10,
        NameInj = 0x20,
        ResizeAllCells = 0x40,
        Nationality = 0x80,
        NumDec = 0x100,
        RightJustified = 0x200,
        N1 = 0x400,
    }
}
