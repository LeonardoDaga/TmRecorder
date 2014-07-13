using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace NTR_Common
{
    public partial class RingDialog : Form
    {
        public bool PlaySound = false;
        public string RingWavefile = Environment.SpecialFolder.System + @"/../Media/chord.wav";

        public RingDialog()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!PlaySound) return;

            SoundPlayer simpleSound = new SoundPlayer(RingWavefile);

            try
            {
                simpleSound.Play();
            }
            catch (Exception)
            {
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}