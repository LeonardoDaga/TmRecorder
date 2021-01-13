using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Languages;
using Common;
using NTR_Db;

namespace FieldFormationControl
{
    public partial class FlyingPlayerDataPanel : Form
    {
        public FlyingPlayerDataPanel()
        {
            InitializeComponent();
        }

        public FlyingPlayerDataPanel(string Language)
        {
            InitializeComponent();

            LoadLanguage(Language);

            SetLanguage(0);
        }

        private void LoadLanguage(string Language)
        {
            if (Language == "en")
                Current.Language = new English();
            else if (Language == "it")
                Current.Language = new Italian();
            else if (Language == "fr")
                Current.Language = new French();
            else if (Language == "es")
                Current.Language = new Spanish();
            else if (Language == "pt")
                Current.Language = new Portuguese();
        }

        internal void SetData(object PlayerDataRow)
        {
            if (PlayerDataRow == null) return;
            ExtTMDataSet.GiocatoriNSkillRow gnsr = (ExtTMDataSet.GiocatoriNSkillRow)PlayerDataRow;

            if (gnsr.FPn > 0)
            {
                Width = 260;
                Height = 166;

                SetLanguage(0);

                lbl1.Text = gnsr.For.ToString("N0");
                lbl2.Text = gnsr.Res.ToString("N0");
                lbl3.Text = gnsr.Vel.ToString("N0");
                lbl4.Text = gnsr.Mar.ToString("N0");
                lbl5.Text = gnsr.Con.ToString("N0");
                lbl6.Text = gnsr.Wor.ToString("N0");
                lbl7.Text = gnsr.Pos.ToString("N0");
                lbl8.Text = gnsr.Pas.ToString("N0");
                lbl9.Text = gnsr.Cro.ToString("N0");
                lbl10.Text = gnsr.Tec.ToString("N0");
                lbl11.Text = gnsr.Tes.ToString("N0");
                if (gnsr.FPn > 0)
                {
                    lbl12.Text = gnsr.Fin.ToString("N0");
                    lbl13.Text = gnsr.Lon.ToString("N0");
                    lbl14.Text = gnsr.Set.ToString("N0");
                }
                lbl15.Text = gnsr.Rou.ToString("N0");

                string nameNdata = gnsr.Nome;
                string[] toks = nameNdata.Split('|');
                lblName.Text = toks[0];

                TmWeek tmw = TmWeek.GetAge(gnsr.wBorn, DateTime.Now);
                lblAge.Text = tmw.ToAge();
                lblASI.Text = gnsr.ASI.ToString();
                lblFP.Text = gnsr.FP;
                lblFP.ForeColor = Color.Blue;

                gbGK.Visible = false;

                FillGrade(lblDL, gnsr.DL);
                FillGrade(lblDL, gnsr.DL);
                FillGrade(lblDC, gnsr.DC);
                FillGrade(lblDR, gnsr.DR);

                FillGrade(lblDML, gnsr.DML);
                FillGrade(lblDMC, gnsr.DMC);
                FillGrade(lblDMR, gnsr.DMR);

                FillGrade(lblML, gnsr.ML);
                FillGrade(lblMC, gnsr.MC);
                FillGrade(lblMR, gnsr.MR);

                FillGrade(lblOML, gnsr.OML);
                FillGrade(lblOMC, gnsr.OMC);
                FillGrade(lblOMR, gnsr.OMR);

                FillGrade(lblFC, gnsr.FC);

                //lbl15.Text = Tactics.Factor(Tactics.FactorType.Standard, gnsr, Tactics.Type.Direct, 1).ToString("N1");
                //lbl16.Text = Tactics.Factor(Tactics.FactorType.Standard, gnsr, Tactics.Type.LongBalls, 1).ToString("N1");
                //lbl17.Text = Tactics.Factor(Tactics.FactorType.Standard, gnsr, Tactics.Type.ShortPass, 1).ToString("N1");
                //lbl18.Text = Tactics.Factor(Tactics.FactorType.Standard, gnsr, Tactics.Type.Through, 1).ToString("N1");
                //lbl19.Text = Tactics.Factor(Tactics.FactorType.Standard, gnsr, Tactics.Type.Wings, 1).ToString("N1");
            }
            else
            {
                Width = 169;
                Height = 165;
                SetLanguage(1);

                lbl1.Text = gnsr.For.ToString("N0");
                lbl2.Text = gnsr.Res.ToString("N0");
                lbl3.Text = gnsr.Vel.ToString("N0");
                lbl4.Text = gnsr.Pre.ToString("N0");
                lbl5.Text = gnsr.Uno.ToString("N0");
                lbl6.Text = gnsr.Rif.ToString("N0");
                lbl7.Text = gnsr.Aer.ToString("N0");
                lbl8.Text = gnsr.Ele.ToString("N0");
                lbl9.Text = gnsr.Com.ToString("N0");
                lbl10.Text = gnsr.Tir.ToString("N0");
                lbl11.Text = gnsr.Lan.ToString("N0");
                lbl12.Text = gnsr.Rou.ToString("N0");
                lbl13.Visible = false;
                lbl14.Visible = false;
                lbl15.Visible = false;

                gbD.Visible = false;
                gbDM.Visible = false;
                gbM.Visible = false;
                gbOM.Visible = false;
                gbF.Visible = false;
                gbGK.Visible = true;
                gbTactics.Visible = false;

                FillGrade(lblGK, gnsr.PO);

                string nameNdata = gnsr.Nome;
                string[] toks = nameNdata.Split('|');
                lblName.Text = toks[0];
                TmWeek tmw = TmWeek.GetAge(gnsr.wBorn, DateTime.Now);
                lblAge.Text = tmw.ToAge();
                lblASI.Text = gnsr.ASI.ToString();
                lblFP.Text = "GK";
                lblFP.ForeColor = Color.Blue;
            }
        }

        internal void SetData(Rating rat, PlayerDataSkills pds)
        {
            if (pds.FPn > 0)
            {
                Width = 260;
                Height = 166;

                SetLanguage(0);

                lbl1.Text = pds.Str.ToString("N0");
                lbl2.Text = pds.Sta.ToString("N0");
                lbl3.Text = pds.Pac.ToString("N0");
                lbl4.Text = pds.Mar.ToString("N0");
                lbl5.Text = pds.Tac.ToString("N0");
                lbl6.Text = pds.Wor.ToString("N0");
                lbl7.Text = pds.Pos.ToString("N0");
                lbl8.Text = pds.Pas.ToString("N0");
                lbl9.Text = pds.Cro.ToString("N0");
                lbl10.Text = pds.Tec.ToString("N0");
                lbl11.Text = pds.Hea.ToString("N0");
                if (pds.FPn > 0)
                {
                    lbl12.Text = pds.Fin.ToString("N0");
                    lbl13.Text = pds.Lon.ToString("N0");
                    lbl14.Text = pds.Set.ToString("N0");
                }
                lbl15.Text = pds.Rou.ToString("N0");

                string nameNdata = pds.Name;
                string[] toks = nameNdata.Split('|');
                lblName.Text = toks[0];

                TmWeek tmw = TmWeek.GetAge(pds.wBorn, DateTime.Now);
                lblAge.Text = tmw.ToAge();
                lblASI.Text = pds.ASI.ToString();
                lblFP.Text = Tm_Utility.FPnToFP(pds.FPn);
                lblFP.ForeColor = Color.Blue;

                gbGK.Visible = false;

                FillGrade(lblDL, rat.DL);
                FillGrade(lblDL, rat.DL);
                FillGrade(lblDC, rat.DC);
                FillGrade(lblDR, rat.DR);

                FillGrade(lblDML, rat.DML);
                FillGrade(lblDMC, rat.DMC);
                FillGrade(lblDMR, rat.DMR);

                FillGrade(lblML, rat.ML);
                FillGrade(lblMC, rat.MC);
                FillGrade(lblMR, rat.MR);

                FillGrade(lblOML, rat.OML);
                FillGrade(lblOMC, rat.OMC);
                FillGrade(lblOMR, rat.OMR);

                FillGrade(lblFC, rat.FC);
            }
            else
            {
                Width = 169;
                Height = 165;
                SetLanguage(1);

                lbl1.Text = pds.Str.ToString("N0");
                lbl2.Text = pds.Sta.ToString("N0");
                lbl3.Text = pds.Pac.ToString("N0");
                lbl4.Text = pds.Han.ToString("N0");
                lbl5.Text = pds.One.ToString("N0");
                lbl6.Text = pds.Ref.ToString("N0");
                lbl7.Text = pds.Aer.ToString("N0");
                lbl8.Text = pds.Jum.ToString("N0");
                lbl9.Text = pds.Com.ToString("N0");
                lbl10.Text = pds.Kic.ToString("N0");
                lbl11.Text = pds.Thr.ToString("N0");
                lbl12.Text = pds.Rou.ToString("N0");
                lbl13.Visible = false;
                lbl14.Visible = false;
                lbl15.Visible = false;

                gbD.Visible = false;
                gbDM.Visible = false;
                gbM.Visible = false;
                gbOM.Visible = false;
                gbF.Visible = false;
                gbGK.Visible = true;
                gbTactics.Visible = false;

                FillGrade(lblGK, rat.GK);

                string nameNdata = pds.Name;
                string[] toks = nameNdata.Split('|');
                lblName.Text = toks[0];
                TmWeek tmw = TmWeek.GetAge(pds.wBorn, DateTime.Now);
                lblAge.Text = tmw.ToAge();
                lblASI.Text = pds.ASI.ToString();
                lblFP.Text = "GK";
                lblFP.ForeColor = Color.Blue;
            }
        }

        private void FillGrade(Label lbl, float f)
        {
            lbl.Text = f.ToString("N1");
            lbl.ForeColor = Utility.GradeColor(f);
        }

        private void FillGrade(Label lbl, double f)
        {
            FillGrade(lbl, (float)f);
        }
    }
}
