using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common;
using System.IO;
using NTR_Db;

namespace FieldFormationControl
{
    public partial class RotLineupControl : UserControl
    {
        #region FieldPlayers Object Declaration
        SmallPlayer[] fp = new SmallPlayer[48];
        #endregion

        public Formation lastY_Formation = null;
        public Formation lastO_Formation = null;
        private bool isInitialized = false;

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
                if (!isInitialized)
                    return;
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
                if (!isInitialized)
                    return;
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

            Position.OffsetSize os = new Position.OffsetSize(this.ClientSize);
            Y_ShowGoalKee(lastY_Formation, os);
            Y_ShowDefense(lastY_Formation, os);
            Y_ShowMidDefn(lastY_Formation, os);
            Y_ShowMidfiel(lastY_Formation, os);
            Y_ShowOffense(lastY_Formation, os);
            Y_ShowFrwdAttack(lastY_Formation, os);
        }

        public void Y_ShowFormationPlayers(Formation form)
        {
            Position.OffsetSize os = new Position.OffsetSize(this.ClientSize);
            Y_ShowGoalKee(form, os);
            Y_ShowDefense(form, os);
            Y_ShowMidDefn(form, os);
            Y_ShowMidfiel(form, os);
            Y_ShowOffense(form, os);
            Y_ShowFrwdAttack(form, os);

            lastY_Formation = form;
        }

        private void Y_ShowGoalKee(Formation form, Position.OffsetSize os)
        {
            Player GK = form.players[Pos.GK];
            CreatePlayer(GK, Position.GetPosition(Pos.GK, true, false, os), ref fp[P.Y_GK]);
        }

        private void Y_ShowFrwdAttack(Formation form, Position.OffsetSize os)
        {
            Player[] p = form.players;
            Player CL = p[Pos.FCL], C = p[Pos.FC], CR = p[Pos.FCR];

            CreatePlayer(CL, Position.GetPosition(Pos.FCL, true, !C.visible, os), ref fp[P.Y_FCL]);
            CreatePlayer(C, Position.GetPosition(Pos.FC, true, !C.visible, os), ref fp[P.Y_FC]);
            CreatePlayer(CR, Position.GetPosition(Pos.FCR, true, !C.visible, os), ref fp[P.Y_FCR]);
        }

        private void Y_ShowOffense(Formation form, Position.OffsetSize os)
        {
            Player[] p = form.players;
            Player L = p[Pos.OML], CL = p[Pos.OMCL], C = p[Pos.OMC], CR = p[Pos.OMCR], R = p[Pos.OMR];

            CreatePlayer(L, Position.GetPosition(Pos.OML, true, !C.visible, os), ref fp[P.Y_OML]);
            CreatePlayer(CL, Position.GetPosition(Pos.OMCL, true, !C.visible, os), ref fp[P.Y_OMCL]);
            CreatePlayer(C, Position.GetPosition(Pos.OMC, true, !C.visible, os), ref fp[P.Y_OMC]);
            CreatePlayer(CR, Position.GetPosition(Pos.OMCR, true, !C.visible, os), ref fp[P.Y_OMCR]);
            CreatePlayer(R, Position.GetPosition(Pos.OMR, true, !C.visible, os), ref fp[P.Y_OMR]);
        }

        private void Y_ShowMidfiel(Formation form, Position.OffsetSize os)
        {
            Player[] p = form.players;
            Player L = p[Pos.ML], CL = p[Pos.MCL], C = p[Pos.MC], CR = p[Pos.MCR], R = p[Pos.MR];

            CreatePlayer(L, Position.GetPosition(Pos.ML, true, !C.visible, os), ref fp[P.Y_ML]);
            CreatePlayer(CL, Position.GetPosition(Pos.MCL, true, !C.visible, os), ref fp[P.Y_MCL]);
            CreatePlayer(C, Position.GetPosition(Pos.MC, true, !C.visible, os), ref fp[P.Y_MC]);
            CreatePlayer(CR, Position.GetPosition(Pos.MCR, true, !C.visible, os), ref fp[P.Y_MCR]);
            CreatePlayer(R, Position.GetPosition(Pos.MR, true, !C.visible, os), ref fp[P.Y_MR]);
        }

        private void Y_ShowMidDefn(Formation form, Position.OffsetSize os)
        {
            Player[] p = form.players;
            Player L = p[Pos.DML], CL = p[Pos.DMCL], C = p[Pos.DMC], CR = p[Pos.DMCR], R = p[Pos.DMR];

            CreatePlayer(L, Position.GetPosition(Pos.DML, true, !C.visible, os), ref fp[P.Y_DML]);
            CreatePlayer(CL, Position.GetPosition(Pos.DMCL, true, !C.visible, os), ref fp[P.Y_DMCL]);
            CreatePlayer(C, Position.GetPosition(Pos.DMC, true, !C.visible, os), ref fp[P.Y_DMC]);
            CreatePlayer(CR, Position.GetPosition(Pos.DMCR, true, !C.visible, os), ref fp[P.Y_DMCR]);
            CreatePlayer(R, Position.GetPosition(Pos.DMR, true, !C.visible, os), ref fp[P.Y_DMR]);
        }

        private void Y_ShowDefense(Formation form, Position.OffsetSize os)
        {
            Player[] p = form.players;
            Player L = p[Pos.DL], CL = p[Pos.DCL], C = p[Pos.DC], CR = p[Pos.DCR], R = p[Pos.DR];

            CreatePlayer(L, Position.GetPosition(Pos.DL, true, !C.visible, os), ref fp[P.Y_DL]);
            CreatePlayer(CL, Position.GetPosition(Pos.DCL, true, !C.visible, os), ref fp[P.Y_DCL]);
            CreatePlayer(C, Position.GetPosition(Pos.DC, true, !C.visible, os), ref fp[P.Y_DC]);
            CreatePlayer(CR, Position.GetPosition(Pos.DCR, true, !C.visible, os), ref fp[P.Y_DCR]);
            CreatePlayer(R, Position.GetPosition(Pos.DR, true, !C.visible, os), ref fp[P.Y_DR]);
        }

        #endregion // Opposite formation

        #region Opposite Formation
        private void O_ShowFormationPlayers(eFormationTypes formType)
        {
            if (lastO_Formation == null)
                lastO_Formation = new Formation(formType);
            else
                lastO_Formation.Type = formType;

            Position.OffsetSize os = new Position.OffsetSize(this.ClientSize);
            O_ShowGoalKee(lastO_Formation, os);
            O_ShowDefense(lastO_Formation, os);
            O_ShowMidDefn(lastO_Formation, os);
            O_ShowMidfiel(lastO_Formation, os);
            O_ShowOffense(lastO_Formation, os);
            O_ShowFrwdAttack(lastO_Formation, os);
        }

        public void O_ShowFormationPlayers(Formation form)
        {
            Position.OffsetSize os = new Position.OffsetSize(this.ClientSize);
            O_ShowGoalKee(form, os);
            O_ShowDefense(form, os);
            O_ShowMidDefn(form, os);
            O_ShowMidfiel(form, os);
            O_ShowOffense(form, os);
            O_ShowFrwdAttack(form, os);

            lastO_Formation = form;
        }

        private void O_ShowGoalKee(Formation form, Position.OffsetSize os)
        {
            Player GK = form.players[Pos.GK];
            
            CreatePlayer(GK, Position.GetPosition(Pos.GK, false, false, os), ref fp[P.O_GK]);
        }

        private void O_ShowFrwdAttack(Formation form, Position.OffsetSize os)
        {
            Player[] p = form.players;
            Player CL = p[Pos.FCL], C = p[Pos.FC], CR = p[Pos.FCR];

            CreatePlayer(CL, Position.GetPosition(Pos.FCL, false, !C.visible, os), ref fp[P.O_FCL]);
            CreatePlayer(C, Position.GetPosition(Pos.FC, false, !C.visible, os), ref fp[P.O_FC]);
            CreatePlayer(CR, Position.GetPosition(Pos.FCR, false, !C.visible, os), ref fp[P.O_FCR]);
        }

        private void O_ShowOffense(Formation form, Position.OffsetSize os)
        {
            Player[] p = form.players;
            Player L = p[Pos.OML], CL = p[Pos.OMCL], C = p[Pos.OMC], CR = p[Pos.OMCR], R = p[Pos.OMR];

            CreatePlayer(L, Position.GetPosition(Pos.OML, false, !C.visible, os), ref fp[P.O_OML]);
            CreatePlayer(CL, Position.GetPosition(Pos.OMCL, false, !C.visible, os), ref fp[P.O_OMCL]);
            CreatePlayer(C, Position.GetPosition(Pos.OMC, false, !C.visible, os), ref fp[P.O_OMC]);
            CreatePlayer(CR, Position.GetPosition(Pos.OMCR, false, !C.visible, os), ref fp[P.O_OMCR]);
            CreatePlayer(R, Position.GetPosition(Pos.OMR, false, !C.visible, os), ref fp[P.O_OMR]);
        }

        private void O_ShowMidfiel(Formation form, Position.OffsetSize os)
        {
            Player[] p = form.players;
            Player L = p[Pos.ML], CL = p[Pos.MCL], C = p[Pos.MC], CR = p[Pos.MCR], R = p[Pos.MR];

            CreatePlayer(L, Position.GetPosition(Pos.ML, false, !C.visible, os), ref fp[P.O_ML]);
            CreatePlayer(CL, Position.GetPosition(Pos.MCL, false, !C.visible, os), ref fp[P.O_MCL]);
            CreatePlayer(C, Position.GetPosition(Pos.MC, false, !C.visible, os), ref fp[P.O_MC]);
            CreatePlayer(CR, Position.GetPosition(Pos.MCR, false, !C.visible, os), ref fp[P.O_MCR]);
            CreatePlayer(R, Position.GetPosition(Pos.MR, false, !C.visible, os), ref fp[P.O_MR]);
        }

        private void O_ShowMidDefn(Formation form, Position.OffsetSize os)
        {
            Player[] p = form.players;
            Player L = p[Pos.DML], CL = p[Pos.DMCL], C = p[Pos.DMC], CR = p[Pos.DMCR], R = p[Pos.DMR];

            CreatePlayer(L, Position.GetPosition(Pos.DML, false, !C.visible, os), ref fp[P.O_DML]);
            CreatePlayer(CL, Position.GetPosition(Pos.DMCL, false, !C.visible, os), ref fp[P.O_DMCL]);
            CreatePlayer(C, Position.GetPosition(Pos.DMC, false, !C.visible, os), ref fp[P.O_DMC]);
            CreatePlayer(CR, Position.GetPosition(Pos.DMCR, false, !C.visible, os), ref fp[P.O_DMCR]);
            CreatePlayer(R, Position.GetPosition(Pos.DMR, false, !C.visible, os), ref fp[P.O_DMR]);
        }

        private void O_ShowDefense(Formation form, Position.OffsetSize os)
        {
            Player[] p = form.players;
            Player L = p[Pos.DL], CL = p[Pos.DCL], C = p[Pos.DC], CR = p[Pos.DCR], R = p[Pos.DR];

            CreatePlayer(L, Position.GetPosition(Pos.DL, false, !C.visible, os), ref fp[P.O_DL]);
            CreatePlayer(CL, Position.GetPosition(Pos.DCL, false, !C.visible, os), ref fp[P.O_DCL]);
            CreatePlayer(C, Position.GetPosition(Pos.DC, false, !C.visible, os), ref fp[P.O_DC]);
            CreatePlayer(CR, Position.GetPosition(Pos.DCR, false, !C.visible, os), ref fp[P.O_DCR]);
            CreatePlayer(R, Position.GetPosition(Pos.DR, false, !C.visible, os), ref fp[P.O_DR]);
        }

        #endregion // Opposite formation

        private void CreatePlayer(Player pl, Point pnt, ref SmallPlayer fp)
        {
            Position.OffsetSize os = new Position.OffsetSize(this.ClientSize);

            float ox = os.ox;
            float oy = os.oy;
            int sx = (int)os.sx;
            int sy = (int)os.sy;

            if ((fp != null) && (!pl.visible))
            {
                this.Controls.Remove(fp);
                fp.Dispose();
                fp = null;
                return;
            }
            else if ((fp != null) && (pl.visible))
            {
                fp.Data = pl;
                fp.Location = pnt;
                fp.Size = new Size(sx, sy);
                return;
            }
            else if ((fp == null) && (pl.visible))
            {
                fp = new SmallPlayer();
                fp.Data = pl;
                fp.Location = pnt;
                fp.Visible = true;
                fp.Size = new Size(sx, sy);
                fp.NameFont = new Font("Arial", 8f);
                fp.RuleFont = new Font("Arial", 8f);
                fp.VoteFont = new Font("Arial", 8f);
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
        }

        private void RotLineupControl_Load(object sender, EventArgs e)
        {
            if (lastY_Formation == null)
                Y_ShowFormationPlayers(YourFormationType);
            else
                Y_ShowFormationPlayers(lastY_Formation);

            if (lastO_Formation == null)
                O_ShowFormationPlayers(OppFormationType);
            else
                O_ShowFormationPlayers(lastO_Formation);
        }

        private void RotLineupControl_Resize(object sender, EventArgs e)
        {
            if (lastY_Formation == null)
                Y_ShowFormationPlayers(YourFormationType);
            else
                Y_ShowFormationPlayers(lastY_Formation);

            if (lastO_Formation == null)
                O_ShowFormationPlayers(OppFormationType);
            else
                O_ShowFormationPlayers(lastO_Formation);
        }

        public void SetMatchData(MatchData md, bool yourTeamLeft)
        {
            EnumerableRowCollection<NTR_SquadDb.PlayerPerfRow> pprLeftCollection = null;
            EnumerableRowCollection<NTR_SquadDb.PlayerPerfRow> pprRightCollection = null;

            Color leftColor = Color.Black;
            Color rightColor = Color.Black;

            if (!md.IsHome && yourTeamLeft)
            {
                pprLeftCollection = md.AwayPlayerPerf;
                pprRightCollection = md.HomePlayerPerf;
                leftColor = md.Away.tagColor;
                rightColor = md.Home.tagColor;
            }
            else
            {
                pprLeftCollection = md.HomePlayerPerf;
                pprRightCollection = md.AwayPlayerPerf;
                leftColor = md.Home.tagColor;
                rightColor = md.Away.tagColor;
            }

            lastY_Formation = new Formation(eFormationTypes.Type_Empty);

            if (md.Report)
            foreach (NTR_SquadDb.PlayerPerfRow player in pprLeftCollection)
            {
                lastY_Formation.TeamColor = leftColor;
                Player pl = SetPlayer(lastY_Formation, player);
            }

            Y_ShowFormationPlayers(lastY_Formation);

            lastO_Formation = new Formation(eFormationTypes.Type_Empty);

            if (md.Report)
            foreach (NTR_SquadDb.PlayerPerfRow player in pprRightCollection)
            {
                lastO_Formation.TeamColor = rightColor;
                Player pl = SetPlayer(lastO_Formation, player);
            }

            O_ShowFormationPlayers(lastO_Formation);
        }

        public Player SetPlayer(Formation f, NTR_SquadDb.PlayerPerfRow row)
        {
            Player pl = f.FindPlayer(row.Position.ToUpper());
            if (pl == null) return null;

            pl.name = row.PlayerRow.Name;
            pl.pf = row.Position;
            pl.vote = (int)row.Vote;
            pl.playerID = row.PlayerID;

            if (row.IsNumberNull())
                pl.number = -1;
            else
                pl.number = row.Number;

            pl.visible = true;

            return pl;
        }

        public void SetFontSize(float fontSize)
        {
            if (fontSize < 5)
                return;
            Font font = new Font("Arial", fontSize);
            for (int i = 0; i < 48; i++)
            {
                if (fp[i] == null) continue;
                fp[i].NameFont = font;
                fp[i].VoteFont = font;
                fp[i].RuleFont = font;
            }
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