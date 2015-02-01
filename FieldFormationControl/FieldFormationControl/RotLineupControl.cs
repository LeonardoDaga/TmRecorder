using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common;
using System.IO;

namespace FieldFormationControl
{
    public partial class RotLineupControl : UserControl
    {
        #region FieldPlayers Object Declaration
        SmallPlayer[] fp = new SmallPlayer[48];
        #endregion

        public Formation lastY_Formation = null;
        public Formation lastO_Formation = null;

        public RotLineupControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        eFormationTypes y_formType = eFormationTypes.Type_4_4_2;
        public eFormationTypes YourFormationType
        {
            get { return y_formType; }
            set 
            {
                y_formType = value;
                Y_ShowFormationPlayers(y_formType);
            }
        }

        eFormationTypes o_formType = eFormationTypes.Type_4_4_2;
        public eFormationTypes OppFormationType
        {
            get { return o_formType; }
            set 
            {
                o_formType = value;
                O_ShowFormationPlayers(o_formType);
            }
        }

        private string _matchFile = "";
        public string MatchFile
        {
            get { return _matchFile; }
            set
            {
                _matchFile = value;
                if (_matchFile == "") return;

                FileInfo fi = new FileInfo(_matchFile);
                if (!fi.Exists)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.FileName = _matchFile;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        _matchFile = ofd.FileName;
                        LoadMatchFile(_matchFile);
                    }
                }
            }
        }

        public void LoadMatchFile(string matchFile)
        {
            matchDS.Clear();
            matchDS.ReadXml(matchFile);

            // eFormationTypes type = Formation.Recognize(matchDS.YourTeamPerf);
            // Formation form = new Formation(type);

            Formation f = new Formation(eFormationTypes.Type_Empty);

            foreach (MatchDS.YourTeamPerfRow row in matchDS.YourTeamPerf)
            {
                Player pl = f.SetPlayer(row);
            }

            Y_ShowFormationPlayers(f);
        }

        #region Your Formation
        private void Y_ShowFormationPlayers(eFormationTypes formType)
        {
            if (lastY_Formation == null)
                lastY_Formation = new Formation(formType);
            else
                lastY_Formation.Type = formType;

            Y_ShowGoalKee(lastY_Formation);
            Y_ShowDefense(lastY_Formation);
            Y_ShowMidDefn(lastY_Formation);
            Y_ShowMidfiel(lastY_Formation);
            Y_ShowOffense(lastY_Formation);
            Y_ShowFrwdAttack(lastY_Formation);
        }

        public void Y_ShowFormationPlayers(Formation form)
        {
            Y_ShowGoalKee(form);
            Y_ShowDefense(form);
            Y_ShowMidDefn(form);
            Y_ShowMidfiel(form);
            Y_ShowOffense(form);
            Y_ShowFrwdAttack(form);

            lastY_Formation = form;
        }

        private void Y_ShowGoalKee(Formation form)
        {
            Player GK = form.players[Pos.GK];
            CreatePlayer(GK, Position.GetPosition(Pos.GK, true, false, this.ClientSize), ref fp[P.Y_GK]);
        }

        private void Y_ShowFrwdAttack(Formation form)
        {
            Player[] p = form.players;
            Player CL = p[Pos.FCL], C = p[Pos.FC], CR = p[Pos.FCR];

            CreatePlayer(CL, Position.GetPosition(Pos.FCL, true, !C.visible, this.ClientSize), ref fp[P.Y_FCL]);
            CreatePlayer(C, Position.GetPosition(Pos.FC, true, !C.visible, this.ClientSize), ref fp[P.Y_FC]);
            CreatePlayer(CR, Position.GetPosition(Pos.FCR, true, !C.visible, this.ClientSize), ref fp[P.Y_FCR]);
        }

        private void Y_ShowOffense(Formation form)
        {
            Player[] p = form.players;
            Player L = p[Pos.OML], CL = p[Pos.OMCL], C = p[Pos.OMC], CR = p[Pos.OMCR], R = p[Pos.OMR];

            CreatePlayer(L, Position.GetPosition(Pos.OML, true, !C.visible, this.ClientSize), ref fp[P.Y_OML]);
            CreatePlayer(CL, Position.GetPosition(Pos.OMCL, true, !C.visible, this.ClientSize), ref fp[P.Y_OMCL]);
            CreatePlayer(C, Position.GetPosition(Pos.OMC, true, !C.visible, this.ClientSize), ref fp[P.Y_OMC]);
            CreatePlayer(CR, Position.GetPosition(Pos.OMCR, true, !C.visible, this.ClientSize), ref fp[P.Y_OMCR]);
            CreatePlayer(R, Position.GetPosition(Pos.OMR, true, !C.visible, this.ClientSize), ref fp[P.Y_OMR]);
        }

        private void Y_ShowMidfiel(Formation form)
        {
            Player[] p = form.players;
            Player L = p[Pos.ML], CL = p[Pos.MCL], C = p[Pos.MC], CR = p[Pos.MCR], R = p[Pos.MR];

            CreatePlayer(L, Position.GetPosition(Pos.ML, true, !C.visible, this.ClientSize), ref fp[P.Y_ML]);
            CreatePlayer(CL, Position.GetPosition(Pos.MCL, true, !C.visible, this.ClientSize), ref fp[P.Y_MCL]);
            CreatePlayer(C, Position.GetPosition(Pos.MC, true, !C.visible, this.ClientSize), ref fp[P.Y_MC]);
            CreatePlayer(CR, Position.GetPosition(Pos.MCR, true, !C.visible, this.ClientSize), ref fp[P.Y_MCR]);
            CreatePlayer(R, Position.GetPosition(Pos.MR, true, !C.visible, this.ClientSize), ref fp[P.Y_MR]);
        }

        private void Y_ShowMidDefn(Formation form)
        {
            Player[] p = form.players;
            Player L = p[Pos.DML], CL = p[Pos.DMCL], C = p[Pos.DMC], CR = p[Pos.DMCR], R = p[Pos.DMR];

            CreatePlayer(L, Position.GetPosition(Pos.DML, true, !C.visible, this.ClientSize), ref fp[P.Y_DML]);
            CreatePlayer(CL, Position.GetPosition(Pos.DMCL, true, !C.visible, this.ClientSize), ref fp[P.Y_DMCL]);
            CreatePlayer(C, Position.GetPosition(Pos.DMC, true, !C.visible, this.ClientSize), ref fp[P.Y_DMC]);
            CreatePlayer(CR, Position.GetPosition(Pos.DMCR, true, !C.visible, this.ClientSize), ref fp[P.Y_DMCR]);
            CreatePlayer(R, Position.GetPosition(Pos.DMR, true, !C.visible, this.ClientSize), ref fp[P.Y_DMR]);
        }

        private void Y_ShowDefense(Formation form)
        {
            Player[] p = form.players;
            Player L = p[Pos.DL], CL = p[Pos.DCL], C = p[Pos.DC], CR = p[Pos.DCR], R = p[Pos.DR];

            CreatePlayer(L, Position.GetPosition(Pos.DL, true, !C.visible, this.ClientSize), ref fp[P.Y_DL]);
            CreatePlayer(CL, Position.GetPosition(Pos.DCL, true, !C.visible, this.ClientSize), ref fp[P.Y_DCL]);
            CreatePlayer(C, Position.GetPosition(Pos.DC, true, !C.visible, this.ClientSize), ref fp[P.Y_DC]);
            CreatePlayer(CR, Position.GetPosition(Pos.DCR, true, !C.visible, this.ClientSize), ref fp[P.Y_DCR]);
            CreatePlayer(R, Position.GetPosition(Pos.DR, true, !C.visible, this.ClientSize), ref fp[P.Y_DR]);
        }

        #endregion // Opposite formation

        #region Opposite Formation
        private void O_ShowFormationPlayers(eFormationTypes formType)
        {
            if (lastO_Formation == null)
                lastO_Formation = new Formation(formType);
            else
                lastO_Formation.Type = formType;

            O_ShowGoalKee(lastO_Formation);
            O_ShowDefense(lastO_Formation);
            O_ShowMidDefn(lastO_Formation);
            O_ShowMidfiel(lastO_Formation);
            O_ShowOffense(lastO_Formation);
            O_ShowFrwdAttack(lastO_Formation);
        }

        public void O_ShowFormationPlayers(Formation form)
        {
            O_ShowGoalKee(form);
            O_ShowDefense(form);
            O_ShowMidDefn(form);
            O_ShowMidfiel(form);
            O_ShowOffense(form);
            O_ShowFrwdAttack(form);

            lastO_Formation = form;
        }

        private void O_ShowGoalKee(Formation form)
        {
            Player GK = form.players[Pos.GK];
            CreatePlayer(GK, Position.GetPosition(Pos.GK, false, false, this.ClientSize), ref fp[P.O_GK]);
        }

        private void O_ShowFrwdAttack(Formation form)
        {
            Player[] p = form.players;
            Player CL = p[Pos.FCL], C = p[Pos.FC], CR = p[Pos.FCR];

            CreatePlayer(CL, Position.GetPosition(Pos.FCL, false, !C.visible, this.ClientSize), ref fp[P.O_FCL]);
            CreatePlayer(C, Position.GetPosition(Pos.FC, false, !C.visible, this.ClientSize), ref fp[P.O_FC]);
            CreatePlayer(CR, Position.GetPosition(Pos.FCR, false, !C.visible, this.ClientSize), ref fp[P.O_FCR]);
        }

        private void O_ShowOffense(Formation form)
        {
            Player[] p = form.players;
            Player L = p[Pos.OML], CL = p[Pos.OMCL], C = p[Pos.OMC], CR = p[Pos.OMCR], R = p[Pos.OMR];

            CreatePlayer(L, Position.GetPosition(Pos.OML, false, !C.visible, this.ClientSize), ref fp[P.O_OML]);
            CreatePlayer(CL, Position.GetPosition(Pos.OMCL, false, !C.visible, this.ClientSize), ref fp[P.O_OMCL]);
            CreatePlayer(C, Position.GetPosition(Pos.OMC, false, !C.visible, this.ClientSize), ref fp[P.O_OMC]);
            CreatePlayer(CR, Position.GetPosition(Pos.OMCR, false, !C.visible, this.ClientSize), ref fp[P.O_OMCR]);
            CreatePlayer(R, Position.GetPosition(Pos.OMR, false, !C.visible, this.ClientSize), ref fp[P.O_OMR]);
        }

        private void O_ShowMidfiel(Formation form)
        {
            Player[] p = form.players;
            Player L = p[Pos.ML], CL = p[Pos.MCL], C = p[Pos.MC], CR = p[Pos.MCR], R = p[Pos.MR];

            CreatePlayer(L, Position.GetPosition(Pos.ML, false, !C.visible, this.ClientSize), ref fp[P.O_ML]);
            CreatePlayer(CL, Position.GetPosition(Pos.MCL, false, !C.visible, this.ClientSize), ref fp[P.O_MCL]);
            CreatePlayer(C, Position.GetPosition(Pos.MC, false, !C.visible, this.ClientSize), ref fp[P.O_MC]);
            CreatePlayer(CR, Position.GetPosition(Pos.MCR, false, !C.visible, this.ClientSize), ref fp[P.O_MCR]);
            CreatePlayer(R, Position.GetPosition(Pos.MR, false, !C.visible, this.ClientSize), ref fp[P.O_MR]);
        }

        private void O_ShowMidDefn(Formation form)
        {
            Player[] p = form.players;
            Player L = p[Pos.DML], CL = p[Pos.DMCL], C = p[Pos.DMC], CR = p[Pos.DMCR], R = p[Pos.DMR];

            CreatePlayer(L, Position.GetPosition(Pos.DML, false, !C.visible, this.ClientSize), ref fp[P.O_DML]);
            CreatePlayer(CL, Position.GetPosition(Pos.DMCL, false, !C.visible, this.ClientSize), ref fp[P.O_DMCL]);
            CreatePlayer(C, Position.GetPosition(Pos.DMC, false, !C.visible, this.ClientSize), ref fp[P.O_DMC]);
            CreatePlayer(CR, Position.GetPosition(Pos.DMCR, false, !C.visible, this.ClientSize), ref fp[P.O_DMCR]);
            CreatePlayer(R, Position.GetPosition(Pos.DMR, false, !C.visible, this.ClientSize), ref fp[P.O_DMR]);
        }

        private void O_ShowDefense(Formation form)
        {
            Player[] p = form.players;
            Player L = p[Pos.DL], CL = p[Pos.DCL], C = p[Pos.DC], CR = p[Pos.DCR], R = p[Pos.DR];

            CreatePlayer(L, Position.GetPosition(Pos.DL, false, !C.visible, this.ClientSize), ref fp[P.O_DL]);
            CreatePlayer(CL, Position.GetPosition(Pos.DCL, false, !C.visible, this.ClientSize), ref fp[P.O_DCL]);
            CreatePlayer(C, Position.GetPosition(Pos.DC, false, !C.visible, this.ClientSize), ref fp[P.O_DC]);
            CreatePlayer(CR, Position.GetPosition(Pos.DCR, false, !C.visible, this.ClientSize), ref fp[P.O_DCR]);
            CreatePlayer(R, Position.GetPosition(Pos.DR, false, !C.visible, this.ClientSize), ref fp[P.O_DR]);
        }

        #endregion // Opposite formation

        private void CreatePlayer(Player pl, Point pnt, ref SmallPlayer fp)
        {
            Size windowSize = this.Size;
            float ox = 10.0f;
            float oy = 5.0f;
            int sx = (int)((windowSize.Width - ox * 2.0f) / 12.0f);
            int sy = (int)((windowSize.Height - oy * 2.0f) / 5.0f);

            if ((fp != null) && (!pl.visible))
            {
                this.Controls.Remove(fp);
                fp = null;
                return;
            }
            else if ((fp != null) && (pl.visible))
            {
                fp.Data = pl;
                return;
            }
            else if ((fp == null) && (pl.visible))
            {
                fp = new SmallPlayer();
                fp.Data = pl;
                fp.Location = pnt;
                fp.Visible = true;
                fp.Size = new Size(sx, sy);
                this.Controls.Add(fp);
            }
        }

        public void Y_SetPlayersMenu(ContextMenuStrip playerY_ContextMenu)
        {
            for (int i= 0; i<24; i++)
            {
                if (fp[i] == null) continue;
                fp[i].ContextMenuStrip = playerY_ContextMenu;
            }
        }

        public void O_SetPlayersMenu(ContextMenuStrip playerO_ContextMenu)
        {
            for (int i = 24; i < 48; i++)
            {
                if (fp[i] == null) continue;
                fp[i].ContextMenuStrip = playerO_ContextMenu;
            }
        }

        private void RotLineupControl_Paint(object sender, PaintEventArgs e)
        {
            Y_ShowFormationPlayers(YourFormationType);
            O_ShowFormationPlayers(OppFormationType);
        }
    }

    public class P
    {
        public const int Y_GK = 0,
                Y_DL = 1,
                Y_DCL = 2,
                Y_DC = 3,
                Y_DCR = 4,
                Y_DR = 5,
                Y_DML = 6,
                Y_DMCL = 7,
                Y_DMC = 8,
                Y_DMCR = 9,
                Y_DMR = 10,
                Y_ML = 11,
                Y_MCL = 12,
                Y_MC = 13,
                Y_MCR = 14,
                Y_MR = 15,
                Y_OML = 16,
                Y_OMCL = 17,
                Y_OMC = 18,
                Y_OMCR = 19,
                Y_OMR = 20,
                Y_FCL = 21,
                Y_FC = 22,
                Y_FCR = 23,
                O_GK = 24,
                O_DL = 25,
                O_DCL = 26,
                O_DC = 27,
                O_DCR = 28,
                O_DR = 29,
                O_DML = 30,
                O_DMCL = 31,
                O_DMC = 32,
                O_DMCR = 33,
                O_DMR = 34,
                O_ML = 35,
                O_MCL = 36,
                O_MC = 37,
                O_MCR = 38,
                O_MR = 39,
                O_OML = 40,
                O_OMCL = 41,
                O_OMC = 42,
                O_OMCR = 43,
                O_OMR = 44,
                O_FCL = 45,
                O_FC = 46,
                O_FCR = 47;
    }
}