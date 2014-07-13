using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class SelectDataDate : Form
    {
        public DateTime SelectedDate
        {
            get { return monthCalendar1.SelectionRange.Start; }
            set 
            { 
                monthCalendar1.SelectionStart = value;
            }
        }

        public SelectDataDate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SelectDataDate_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}