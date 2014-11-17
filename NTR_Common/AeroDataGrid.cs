using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices; 

namespace NTR_Common
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
            // this.HandleCreated += AeroDataGrid_HandleCreated;
        }

        void AeroDataGrid_HandleCreated(object sender, EventArgs e)
        {
            //SetWindowTheme(Handle, "explorer", null);
        }
    }
}
