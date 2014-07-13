using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using TransferManager.Properties;

namespace TransferManager
{
    public partial class RingDialog : Form
    {
        public RingDialog()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Program.Setts.PlaySound) return;

            SoundPlayer simpleSound = new SoundPlayer(Program.Setts.RingWavefile);

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