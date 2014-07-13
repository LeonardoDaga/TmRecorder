using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common;

namespace TMRecorder
{
    public partial class GKData : UserControl
    {
        public GKData()
        {
            InitializeComponent();
        }

        public ExtTMDataSet.GKHistoryRow GKRow
        {
            set
            {
                ExtTMDataSet.GKHistoryRow gr = value;

                lblFor.Text = gr.For.ToString();
                lblRes.Text = gr.Res.ToString();
                lblVel.Text = gr.Vel.ToString();
                lblPre.Text = gr.Pre.ToString();
                lblUno.Text = gr.Uno.ToString();
                lblAer.Text = gr.Aer.ToString();
                lblEle.Text = gr.Ele.ToString();
                lblCom.Text = gr.Com.ToString();
                lblTir.Text = gr.Tir.ToString();
                lblLan.Text = gr.Lan.ToString();
                lblRef.Text = gr.Rif.ToString();
            }
        }
    }
}
