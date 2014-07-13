using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NTR_Forms
{
    public partial class RadioButtonSelectOption : Form
    {
        RadioButton[] rbList = null;
        int maxWidth = 0;

        public RadioButtonSelectOption()
        {
            InitializeComponent();
        }

        public int Choice
        {
            get
            {
                if (rbList == null) return -1;
                for (int i = 0; i < rbList.Length; i++)
                {
                    if (rbList[i].Checked) return i;
                }
                return -1;
            }
            set
            {
                if (rbList == null) return;
                if (value >= rbList.Length) return;
                rbList[value].Checked = true;
            }
        }

        public void ConfigureOptionsSelection(string[] options,
            string txtQuestion, string txtTitle)
        {
            maxWidth = 200;

            Text = txtTitle;
            lblQuestion.Text = txtQuestion;
            maxWidth = Math.Max(lblQuestion.Right + 20, maxWidth);
            int topRadio = lblQuestion.Bottom + 8;
            rbList = new RadioButton[options.Length];

            for(int i=0; i<options.Length; i++)
            {
                rbList[i] = new RadioButton();
                rbList[i].Top = topRadio + 23 * i;
                rbList[i].Left = 15;
                rbList[i].Text = options[i];
                rbList[i].AutoSize = true;
                rbList[i].TabStop = true;
                rbList[i].TabIndex = 11+i;
                rbList[i].UseVisualStyleBackColor = true;
                this.Controls.Add(rbList[i]);
                maxWidth = Math.Max(rbList[i].Right + 20, maxWidth);
            }
        }

        private void RadioButtonSelectOption_Load(object sender, EventArgs e)
        {
            int topRadio = lblQuestion.Bottom + 8;
            this.Width = maxWidth;
            this.Height = topRadio + 23 * rbList.Length + 80;
        }
    }
}
