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
    public partial class PlayerData : UserControl
    {
        public PlayerData()
        {
            InitializeComponent();
        }

        public ExtTMDataSet.PlayerHistoryRow PlayerRow
        {
            set
            {
                ExtTMDataSet.PlayerHistoryRow pr = value;

                lblCon.Text = pr.Con.ToString();
                lblCro.Text = pr.Cro.ToString();
                lblFin.Text = pr.Fin.ToString();
                lblFor.Text = pr.For.ToString();
                lblMar.Text = pr.Mar.ToString();
                lblPas.Text = pr.Pas.ToString();
                lblPos.Text = pr.Pos.ToString();
                lblRes.Text = pr.Res.ToString();
                lblTec.Text = pr.Tec.ToString();
                lblTes.Text = pr.Tes.ToString();
                lblDis.Text = pr.Tir.ToString();
                lblVel.Text = pr.Vel.ToString();
                lblImp.Text = pr.Wor.ToString();
                lblCP.Text = pr.Cal.ToString();
            }
        }
    }
}
