using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class ProgressForm : Form
    {
        public bool stopIncrement = false;
        public DateTime lastUpdate = DateTime.Now;
        public bool closedFromCode = false;

        public ProgressForm()
        {
            InitializeComponent();
        }

        public void CodeClose()
        {
            closedFromCode = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            stopIncrement = true;
        }

        private void IncrementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closedFromCode)
            {
                e.Cancel = true;
                stopIncrement = true;
            }
        }

        public int Value
        {
            set 
            {
                if (value < 0) 
                    progressBar.Value = progressBar.Minimum;
                else if (value < progressBar.Maximum)
                    progressBar.Value = value;
                else
                    progressBar.Value = progressBar.Maximum;

                TimeSpan ts = DateTime.Now - lastUpdate;
                if (ts.TotalSeconds > 1)
                {
                    this.Invalidate();
                    this.Update();
                    lastUpdate = DateTime.Now;
                }
            }
            get { return progressBar.Value; }
        }

        public void Redraw()
        {
            Invalidate();
            Update();
        }
    }
}