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

        public void AddColumn(string Title, string Property, int width, AG_Style styles)
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

            dgv.Name = Title;
            dgv.DataPropertyName = Property;
            dgv.Width = width;
            this.Columns.Add(dgv);
        }
    }

    [Flags]
    public enum AG_Style
    {
        Numeric = 0x01,
        Frozen = 0x02,
        Age = 0x04,
        String = 0x08,
    }
}
