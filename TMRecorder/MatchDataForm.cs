using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TMRecorder.Properties;

namespace TMRecorder
{
    public partial class MatchDataForm : Form
    {
        public MatchDataForm()
        {
            InitializeComponent();
            FillMatchListType();
        }

        private void FillMatchListType()
        {
            string str = Program.Setts.MatchTypes;
            string[] mtypes = str.Split(',');

            lbMatchTypes.Items.AddRange(mtypes);
            lbMatchTypes.SelectedIndex = 0;
        }

        public int MatchType
        {
            get {return lbMatchTypes.SelectedIndex;}
        }

        public DateTime SelectedDate
        {
            get { return monthCalendar1.SelectionRange.Start; }
            set
            {
                monthCalendar1.SelectionStart = value;
            }
        }

    }
}