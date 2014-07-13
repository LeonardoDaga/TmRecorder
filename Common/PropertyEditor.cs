using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Common
{
    public partial class PropertyEditor : Form
    {
        public PropertyBag dialogBag = new PropertyBag();

        public PropertyEditor()
        {
            InitializeComponent();
        }

        public void InitializeGrid()
        {
            ArrayList objs = new ArrayList();
            objs.Add(dialogBag);

            propertyGrid.SelectedObjects = objs.ToArray();
            propertyGrid.PropertySort = PropertySort.Categorized;

            this.Height = 160 + 20 * dialogBag.Properties.Count;
            this.Width = 320;

            //Control cnt = this.propertyGrid.GetNextControl(null, true);
            //while (cnt != null)
            //{
            //    string str = cnt.GetType().ToString();
            //    if (str == "System.Windows.Forms.PropertyGridInternal.DocComment")
            //    {
            //        int lastHgt = cnt.Height;
            //        cnt.Height = 200;
            //        cnt.Refresh();
            //        //break;
            //    }
            //    else if (str == "System.Windows.Forms.PropertyGridInternal.PropertyGridView")
            //    {
            //        int lastHgt = cnt.Height;
            //        cnt.Height = 200;
            //        cnt.Refresh();
            //        //break;
            //    }
                
            //    cnt = this.propertyGrid.GetNextControl(cnt, true);
            //}
        }

        private void propertyGrid_Click(object sender, EventArgs e)
        {

        }
    }
}