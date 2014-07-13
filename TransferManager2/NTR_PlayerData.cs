using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NTR_Common;
using Common;

namespace TransferManager
{
    public partial class NTR_PlayerData : UserControl
    {
        public NTR_PlayerData()
        {
            InitializeComponent();
        }

        public TeamDS.GiocatoriNSkillRow PlayerRow
        {
            set
            {
                TeamDS.GiocatoriNSkillRow pr = value;

                if (pr.FPn != 0)
                {
                    lblAdaCapt.Visible = true;
                    lblFinCapt.Visible = true;
                    lblSetCapt.Visible = true;
                    lblLonCapt.Visible = true;
                    lblAda.Visible = true;
                    lblFin.Visible = true;
                    lblCP.Visible = true;
                    lblDis.Visible = true;

                    lblTakCapt.Text = "Tak";
                    lblCroCapt.Text = "Cro";
                    lblFinCapt.Text = "Fin";
                    lblStrCapt.Text = "Str";
                    lblMarCapt.Text = "Mar";
                    lblPasCapt.Text = "Pas";
                    lblPosCapt.Text = "Pos";
                    lblStaCapt.Text = "Sta";
                    lblTecCapt.Text = "Tec";
                    lblHeaCapt.Text = "Hea";
                    lblLonCapt.Text = "Lon";
                    lblPacCapt.Text = "Pac";
                    lblWorCapt.Text = "Wor";
                    lblSetCapt.Text = "Set";

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
                    lblDis.Text = pr.Dis.ToString();
                    lblVel.Text = pr.Vel.ToString();
                    lblImp.Text = pr.Wor.ToString();
                    lblCP.Text = pr.Cal.ToString();

                    if (!pr.IsRouNull())
                        lblRou.Text = pr.Rou.ToString();
                    else
                        lblRou.Text = "-";

                    lblASI.Text = pr.ASI.ToString();
                    lblAda.Text = pr.Ada.ToString();
                    TmWeek born = new TmWeek(pr.wBorn);
                    lblAge.Text = born.ToAge(DateTime.Today);
                }
                else
                {
                    lblAdaCapt.Visible = false;
                    lblFinCapt.Visible = false;
                    lblSetCapt.Visible = false;
                    lblLonCapt.Visible = false;
                    lblAda.Visible = false;
                    lblFin.Visible = false;
                    lblCP.Visible = false;
                    lblDis.Visible = false;

                    lblTakCapt.Text = "One";
                    lblCroCapt.Text = "Com";
                    lblStrCapt.Text = "Str";
                    lblMarCapt.Text = "Han";
                    lblPasCapt.Text = "Jum";
                    lblPosCapt.Text = "Ari";
                    lblStaCapt.Text = "Sta";
                    lblTecCapt.Text = "Kic";
                    lblHeaCapt.Text = "Thr";
                    lblPacCapt.Text = "Pac";
                    lblWorCapt.Text = "Ref";

                    lblCon.Text = pr.Con.ToString();
                    lblCro.Text = pr.Cro.ToString();
                    lblFor.Text = pr.For.ToString();
                    lblMar.Text = pr.Mar.ToString();
                    lblPas.Text = pr.Pas.ToString();
                    lblPos.Text = pr.Pos.ToString();
                    lblRes.Text = pr.Res.ToString();
                    lblTec.Text = pr.Tec.ToString();
                    lblTes.Text = pr.Tes.ToString();
                    lblVel.Text = pr.Vel.ToString();
                    lblImp.Text = pr.Wor.ToString();

                    if (!pr.IsRouNull())
                        lblRou.Text = pr.Rou.ToString();
                    else
                        lblRou.Text = "-";

                    lblASI.Text = pr.ASI.ToString();
                    TmWeek born = new TmWeek(pr.wBorn);
                    lblAge.Text = born.ToAge(DateTime.Today);
                }
            }
        }
    }
}
