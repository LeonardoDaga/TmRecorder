using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Common
{
    public enum eFormationTypes
    {
        Type_4_4_2,
        Type_4_4_2_d,
        Type_4_4_2_D,
        Type_4_4_2_O,
        Type_4_2_4,
        Type_4_2_2_2,
        Type_4_3_3,
        Type_4_3_3_D,
        Type_4_5_1_D,
        Type_4_5_1_O,
        Type_4_1_4_1,
        Type_4_4_1_1,
        Type_4_2_3_1,
        Type_4_3_2_1,
        Type_3_3_2_2,
        Type_3_2_3_2,
        Type_3_5_2_O,
        Type_3_5_2_D,
        Type_3_4_3,
        Type_3_3_3_1,
        Type_5_4_1,
        Type_5_4_1_d,
        Type_5_3_2,
        Type_5_3_2_D,
        Type_Unknown,
        Type_Empty,
    }

    public class Pos
    {
        public const int GK = 0,
        DL = 1, DCL = 2, DC = 3, DCR = 4, DR = 5,
        DML = 6, DMCL = 7, DMC = 8, DMCR = 9, DMR = 10,
        ML = 11, MCL = 12, MC = 13, MCR = 14, MR = 15,
        OML = 16, OMCL = 17, OMC = 18, OMCR = 19, OMR = 20,
        FCL = 21, FC = 22, FCR = 23,
        TOT = 24;

        public enum eCode
        {
            GK = 0,
            DL = 1, DCL = 2, DC = 3, DCR = 4, DR = 5,
            DML = 6, DMCL = 7, DMC = 8, DMCR = 9, DMR = 10,
            ML = 11, MCL = 12, MC = 13, MCR = 14, MR = 15,
            OML = 16, OMCL = 17, OMC = 18, OMCR = 19, OMR = 20,
            FCL = 21, FC = 22, FCR = 23,
            SUBS1 = 24, SUBS2 = 25, SUBS3 = 26, SUBS4 = 27, SUBS5 = 28, 
            TOT = 29
        }

        public static int ToCode(string str)
        {
            string[] CodeStr = 
            {"GK", "DL", "DCL", "DC", "DCR", "DR", "DML", "DMCL", "DMC", "DMCR", "DMR", "ML", "MCL", "MC", "MCR", "MR", 
                "OML", "OMCL", "OMC", "OMCR", "OMR", "FCL", "FC", "FCR", "SUB1", "SUB2", "SUB3", "SUB4", "SUB5"};

            string ustr = str.ToUpper();
            for (int i = 0; i < Pos.TOT; i++)
            {
                if (CodeStr[i] == ustr)
                {
                    return i;
                }
            }
            return (int)eCode.TOT;
        }

        public static string ToString(int code)
        {
            switch (code)
            {
                case GK: return "GK";
                case DL: return "DL";
                case DR: return "DR";
                case DCL: return "DC";
                case DC: return "DC";
                case DCR: return "DC";
                case DML: return "DML";
                case DMR: return "DMR";
                case DMCL: return "DMC";
                case DMC: return "DMC";
                case DMCR: return "DMC";
                case ML: return "ML";
                case MR: return "MR";
                case MCL: return "MC";
                case MC: return "MC";
                case MCR: return "MC";
                case OML: return "OML";
                case OMR: return "OMR";
                case OMCL: return "OMC";
                case OMC: return "OMC";
                case OMCR: return "OMC";
                default: return "FC";
            }
        }
    }

    public static class Position
    {
        public static int String2BitP(string position)
        {
            switch (position)
            {
                case "D": return (int)(BitP.DEF);
                case "DW": return (int)(BitP.DEF | BitP.WIN);
                case "DM": return (int)(BitP.DEF | BitP.MID);
                case "DMW": return (int)(BitP.DEF | BitP.MID | BitP.WIN);
                case "M": return (int)(BitP.MID);
                case "MW": return (int)(BitP.MID | BitP.WIN);
                case "OM": return (int)(BitP.OFF | BitP.MID);
                case "OMW": return (int)(BitP.OFF | BitP.MID | BitP.WIN);
                case "O": return (int)(BitP.OFF);
                case "G": return (int)(BitP.GOK);
                case "A": return (int)(BitP.ALL);
                case "EXE": return (int)(BitP.EXE);
            }
            return (int)BitP.NON;
        }

        public static string BitP2String(int bitp)
        {
            switch (bitp)
            {
                case (int)(BitP.DEF): return "D";
                case (int)(BitP.DEF | BitP.WIN): return "DW";
                case (int)(BitP.DEF | BitP.MID): return "DM";
                case (int)(BitP.DEF | BitP.MID | BitP.WIN): return "DMW";
                case (int)(BitP.MID): return "M";
                case (int)(BitP.MID | BitP.WIN): return "MW";
                case (int)(BitP.OFF | BitP.MID): return "OM";
                case (int)(BitP.OFF | BitP.MID | BitP.WIN): return "OMW";
                case (int)(BitP.OFF): return "O";
                case (int)(BitP.GOK): return "G";
                case (int)(BitP.ALL): return "A";
                case (int)(BitP.EXE): return "EXE";
            }
            return "";
        }

        public static Point GetPosition(int pos, bool your, bool centered, Size windowSize)
        {
            PointF p = new PointF();

            float ox = 10.0f;
            float oy = 5.0f;
            float sx = (windowSize.Width - ox * 2.0f) / 12.0f;
            float sy = (windowSize.Height - oy * 2.0f) / 5.0f;

            switch (pos)
            {
                case Pos.GK: p.X = ox + 0 * sx; p.Y = oy + 2 * sy; break;

                case Pos.DL: p.X = ox + 1 * sx; p.Y = oy + 0 * sy; break;
                case Pos.DCL: p.X = ox + 1 * sx; p.Y = oy + 1 * sy; break;
                case Pos.DC: p.X = ox + 1 * sx; p.Y = oy + 2 * sy; break;
                case Pos.DCR: p.X = ox + 1 * sx; p.Y = oy + 3 * sy; break;
                case Pos.DR: p.X = ox + 1 * sx; p.Y = oy + 4 * sy; break;

                case Pos.DML: p.X = ox + 2 * sx; p.Y = oy + 0 * sy; break;
                case Pos.DMCL: p.X = ox + 2 * sx; p.Y = oy + 1* sy; break;
                case Pos.DMC: p.X = ox + 2 * sx; p.Y = oy + 2 * sy; break;
                case Pos.DMCR: p.X = ox + 2 * sx; p.Y = oy + 3 * sy; break;
                case Pos.DMR: p.X = ox + 2 * sx; p.Y = oy + 4 * sy; break;

                case Pos.ML: p.X = ox + 3 * sx; p.Y = oy + 0 * sy; break;
                case Pos.MCL: p.X = ox + 3 * sx; p.Y = oy + 1 * sy; break;
                case Pos.MC: p.X = ox + 3 * sx; p.Y = oy + 2 * sy; break;
                case Pos.MCR: p.X = ox + 3 * sx; p.Y = oy + 3 * sy; break;
                case Pos.MR: p.X = ox + 3 * sx; p.Y = oy + 4 * sy; break;

                case Pos.OML: p.X = ox + 4 * sx; p.Y = oy + 0 * sy; break;
                case Pos.OMCL: p.X = ox + 4 * sx; p.Y = oy + 1 * sy; break;
                case Pos.OMC: p.X = ox + 4 * sx; p.Y = oy + 2 * sy; break;
                case Pos.OMCR: p.X = ox + 4 * sx; p.Y = oy + 3 * sy; break;
                case Pos.OMR: p.X = ox + 4 * sx; p.Y = oy + 4 * sy; break;

                case Pos.FCL: p.X = ox + 5 * sx; p.Y = oy + 1 * sy; break;
                case Pos.FC: p.X = ox + 5 * sx; p.Y = oy + 2 * sy; break;
                case Pos.FCR: p.X = ox + 5 * sx; p.Y = oy + 3 * sy; break;
            }

            if (centered)
            {
                if (p.Y == oy + 1f * sy) p.Y = oy + 1.5f * sy;
                if (p.Y == oy + 3f * sy) p.Y = oy + 2.5f * sy;
            }
            else
            {
                if (p.Y == oy + 1.5f * sy) p.Y = oy + 1f * sy;
                if (p.Y == oy + 2.5f * sy) p.Y = oy + 3f * sy;
            }

            if (!your)
            {
                p.X = 2 * ox + 11 * sx - p.X;
                p.Y = 2 * oy + 4 * sy - p.Y;
            }

            return new Point((int)p.X, (int)p.Y);
        }
    }

    public enum BitP
    {
        NON = 0x0,
        GOK = 0x1,
        DEF = 0x2,
        MID = 0x4,
        OFF = 0x8,
        WIN = 0x10,
        ALL = 0x20,
        EXE = 0x40,
    }

    public class Player
    {
        public bool visible = false;
        public string name = "";
        public string pf = "";
        public int skills = 0;
        public int number = 0;
        public float vote = 0;
        public float value = 0;
        public bool showValue = false;
        public int card = 0;
        public string info = "";
        public string tip = "";
        public Color shirtColor = Color.DarkRed;
        public BitP bitPosition = BitP.NON;
        public int playerID = 0;
        public string sSkills = "";

        public Player(BitP ord)
        {
            bitPosition = ord;
        }

        internal void CopyTo(FormationDS.PlayerRow pr)
        {
            pr.visible = visible;
            pr.Name = name;
            pr.PF = pf;
            pr.Skills = skills;
            pr.No = number;
            pr.Vote = vote;
            pr.Value = value;
            pr.Card = card;
            pr.Tip = tip;
            pr.ShirtColor = shirtColor.ToArgb();
            pr.BitPosition = (int)bitPosition;
            pr.PlayerID = playerID;
            pr.sSkills = this.sSkills;
        }

        internal void CopyFrom(FormationDS.PlayerRow pr)
        {
            visible = pr.visible;
            name = pr.Name;
            pf = pr.PF;
            skills = pr.Skills;
            number = pr.No;
            vote = pr.Vote;
            value = pr.Value;
            card = pr.Card;
            tip = pr.Tip;
            shirtColor = Color.FromArgb(pr.ShirtColor);
            //bitPosition = (BitP)pr.BitPosition;
            playerID = pr.PlayerID;
            if (!pr.IssSkillsNull())
            {
                sSkills = pr.sSkills;
            }
        }

    }

    public class Formation
    {
        eFormationTypes _type;
        public Player[] players = new Player[24];
        private Color _teamColor = Color.DarkRed;
        public bool showMeanVote = false;

        public Color TeamColor
        {
            get { return _teamColor; }
            set
            {
                _teamColor = Color.FromArgb(255, value);

                for (int i = 0; i < Pos.TOT; i++)
                {
                    players[i].shirtColor = _teamColor;
                }
            }
        }

        private bool _showValue = false;
        public bool ShowValue
        {
            get { return _showValue; }
            set
            {
                _showValue = value;
                for (int i = 0; i < Pos.TOT; i++)
                {
                    players[i].showValue = _showValue;
                }
            }
        }

        public Formation()
        {
            Initialize();
        }

        public void Initialize()
        {
            players[Pos.GK] = new Player(BitP.GOK);

            players[Pos.DL] = new Player(BitP.DEF | BitP.WIN);
            players[Pos.DCL] = new Player(BitP.DEF);
            players[Pos.DC] = new Player(BitP.DEF);
            players[Pos.DCR] = new Player(BitP.DEF);
            players[Pos.DR] = new Player(BitP.DEF | BitP.WIN);

            players[Pos.DML] = new Player(BitP.DEF | BitP.MID | BitP.WIN);
            players[Pos.DMCL] = new Player(BitP.DEF | BitP.MID);
            players[Pos.DMC] = new Player(BitP.DEF | BitP.MID);
            players[Pos.DMCR] = new Player(BitP.DEF | BitP.MID);
            players[Pos.DMR] = new Player(BitP.DEF | BitP.MID | BitP.WIN);

            players[Pos.ML] = new Player(BitP.MID | BitP.WIN);
            players[Pos.MCL] = new Player(BitP.MID);
            players[Pos.MC] = new Player(BitP.MID);
            players[Pos.MCR] = new Player(BitP.MID);
            players[Pos.MR] = new Player(BitP.MID | BitP.WIN);

            players[Pos.OML] = new Player(BitP.MID | BitP.OFF | BitP.WIN);
            players[Pos.OMCL] = new Player(BitP.MID | BitP.OFF);
            players[Pos.OMC] = new Player(BitP.MID | BitP.OFF);
            players[Pos.OMCR] = new Player(BitP.MID | BitP.OFF);
            players[Pos.OMR] = new Player(BitP.MID | BitP.OFF | BitP.WIN);

            players[Pos.FCL] = new Player(BitP.OFF);
            players[Pos.FC] = new Player(BitP.OFF);
            players[Pos.FCR] = new Player(BitP.OFF);

        }

        public Formation(eFormationTypes type)
        {
            Initialize();
            Type = type;
        }

        static public eFormationTypes Recognize(MatchDS.YourTeamPerfDataTable dt)
        {
            foreach(eFormationTypes type in Enum.GetValues(typeof(eFormationTypes)))
            {
                Formation f = new Formation(type);
                foreach (MatchDS.YourTeamPerfRow row in dt)
                {
                    if (!f.Contains(row.Position.ToUpper())) break;
                }

                return type;
            }

            return eFormationTypes.Type_Unknown;
        }

        private bool Contains(string position)
        {
            if (position.Contains("GK")) return true;
            if (position.Contains("SUB")) return true;
            int res;
            if (int.TryParse(position, out res)) return true;
            if (position.Contains("BAN")) return true;

            if ((position.Contains("DL")) && (players[Pos.DL].visible)) return true;
            if ((position.Contains("DCL")) && (players[Pos.DCL].visible)) return true;
            if ((position.Contains("DCR")) && (players[Pos.DCR].visible)) return true;
            if ((position.Contains("DC")) && (players[Pos.DC].visible)) return true;
            if ((position.Contains("DR")) && (players[Pos.DR].visible)) return true;

            if ((position.Contains("DML")) && (players[Pos.DML].visible)) return true;
            if ((position.Contains("DMCL")) && (players[Pos.DMCL].visible)) return true;
            if ((position.Contains("DMCR")) && (players[Pos.DMCR].visible)) return true;
            if ((position.Contains("DMC")) && (players[Pos.DMC].visible)) return true;
            if ((position.Contains("DMR")) && (players[Pos.DMR].visible)) return true;

            if ((position.Contains("OML")) && (players[Pos.OML].visible)) return true;
            if ((position.Contains("OMCL")) && (players[Pos.OMCL].visible)) return true;
            if ((position.Contains("OMCR")) && (players[Pos.OMCR].visible)) return true;
            if ((position.Contains("OMC")) && (players[Pos.OMC].visible)) return true;
            if ((position.Contains("OMR")) && (players[Pos.OMR].visible)) return true;

            if ((position.Contains("ML")) && (players[Pos.ML].visible)) return true;
            if ((position.Contains("MCL")) && (players[Pos.MCL].visible)) return true;
            if ((position.Contains("MCR")) && (players[Pos.MCR].visible)) return true;
            if ((position.Contains("MC")) && (players[Pos.MC].visible)) return true;
            if ((position.Contains("MR")) && (players[Pos.MR].visible)) return true;

            if ((position.Contains("FCL")) && (players[Pos.OMCL].visible)) return true;
            if ((position.Contains("FCR")) && (players[Pos.OMCR].visible)) return true;
            if ((position.Contains("FC")) && (players[Pos.OMC].visible)) return true;

            return false;
        }

        public Player FindPlayer(int playerID)
        {
            for (int i = 0; i < Pos.TOT; i++)
            {
                if (players[i] == null) continue;
                if (players[i].playerID == playerID) return players[i];
            }

            return null;
        }

        public Player FindPlayer(string position)
        {
            if (position.Contains("GK")) return players[Pos.GK];

            if (position.Contains("SUB")) return null;
            int res;
            if (int.TryParse(position, out res)) return null;
            if (position.Contains("BAN")) return null;

            if (position.Contains("DL")) return players[Pos.DL];
            if (position.Contains("DCL")) return players[Pos.DCL];
            if (position.Contains("DCR")) return players[Pos.DCR];
            if (position.Contains("DC")) return players[Pos.DC];
            if (position.Contains("DR")) return players[Pos.DR];

            if (position.Contains("DML")) return players[Pos.DML];
            if (position.Contains("DMCL")) return players[Pos.DMCL];
            if (position.Contains("DMCR")) return players[Pos.DMCR];
            if (position.Contains("DMC")) return players[Pos.DMC];
            if (position.Contains("DMR")) return players[Pos.DMR];

            if (position.Contains("OML")) return players[Pos.OML];
            if (position.Contains("OMCL")) return players[Pos.OMCL];
            if (position.Contains("OMCR")) return players[Pos.OMCR];
            if (position.Contains("OMC")) return players[Pos.OMC];
            if (position.Contains("OMR")) return players[Pos.OMR];

            if (position.Contains("ML")) return players[Pos.ML];
            if (position.Contains("MCL")) return players[Pos.MCL];
            if (position.Contains("MCR")) return players[Pos.MCR];
            if (position.Contains("MC")) return players[Pos.MC];
            if (position.Contains("MR")) return players[Pos.MR];

            if (position.Contains("FCL")) return players[Pos.FCL];
            if (position.Contains("FCR")) return players[Pos.FCR];
            if (position.Contains("FC")) return players[Pos.FC];

            return null;
        }

        public override string ToString()
        {
            switch (_type)
            {
                case eFormationTypes.Type_4_4_2: return "4-4-2";
                case eFormationTypes.Type_4_4_2_d: return "4-4-2 (diamond)";
                case eFormationTypes.Type_4_4_2_D: return "4-4-2 (defensive)";
                case eFormationTypes.Type_4_4_2_O: return "4-4-2 (offensive)";
                case eFormationTypes.Type_4_2_4: return "4-2-4";
                case eFormationTypes.Type_4_2_2_2: return "4-2-2-2";
                case eFormationTypes.Type_4_3_3: return "4-3-3";
                case eFormationTypes.Type_4_3_3_D: return "4-3-3 (defensive)";
                case eFormationTypes.Type_4_5_1_D: return "4-5-1 (defensive)";
                case eFormationTypes.Type_4_5_1_O: return "4-5-1 (offensive)";
                case eFormationTypes.Type_4_1_4_1: return "4-1-4-1";
                case eFormationTypes.Type_4_4_1_1: return "4-4-1-1";
                case eFormationTypes.Type_4_2_3_1: return "4-2-3-1";
                case eFormationTypes.Type_4_3_2_1: return "4-3-2-1";
                case eFormationTypes.Type_3_3_2_2: return "3-3-2-2";
                case eFormationTypes.Type_3_2_3_2: return "3-2-3-2";
                case eFormationTypes.Type_3_5_2_O: return "3-5-2 (offensive)";
                case eFormationTypes.Type_3_5_2_D: return "3-5-2 (defensive)";
                case eFormationTypes.Type_3_4_3: return "3-4-3";
                case eFormationTypes.Type_3_3_3_1: return "3-3-3-1";
                case eFormationTypes.Type_5_4_1: return "5-4-1";
                case eFormationTypes.Type_5_4_1_d: return "5-4-1 (diamond)";
                case eFormationTypes.Type_5_3_2: return "5-3-2";
                case eFormationTypes.Type_5_3_2_D: return "5-3-2 (defensive)";
                default: return "unknown";
            }
        }

        public eFormationTypes Type
        {
            get { return _type; }

            set
            {
                _type = value;
                bool x = false;
                bool O = true;

                players[Pos.GK].visible = true;

                switch (_type)
                {
                    case eFormationTypes.Type_4_4_2:
                        SetDefense(O, O, x, O, O);
                        SetMidDefn(x, x, x, x, x);
                        SetMidfiel(O, O, x, O, O);
                        SetOffense(x, x, x, x, x);
                        SetFrwdAttack(O, x, O);
                        break;
                    case eFormationTypes.Type_4_4_2_d:
                        SetDefense(O, O, x, O, O);
                        SetMidDefn(x, x, O, x, x);
                        SetMidfiel(O, x, x, x, O);
                        SetOffense(x, x, O, x, x);
                        SetFrwdAttack(O, x, O);
                        break;
                    case eFormationTypes.Type_4_4_2_D:
                        SetDefense(O, O, x, O, O);
                        SetMidDefn(x, x, O, x, x);
                        SetMidfiel(O, x, O, x, O);
                        SetOffense(x, x, x, x, x);
                        SetFrwdAttack(O, x, O);
                        break;
                    case eFormationTypes.Type_4_4_2_O:
                        SetDefense(O, O, x, O, O);
                        SetMidDefn(x, x, x, x, x);
                        SetMidfiel(O, x, O, x, O);
                        SetOffense(x, x, O, x, x);
                        SetFrwdAttack(O, x, O);
                        break;
                    case eFormationTypes.Type_4_2_4:
                        SetDefense(O, O, x, O, O);
                        SetMidDefn(x, x, x, x, x);
                        SetMidfiel(x, O, x, O, x);
                        SetOffense(O, x, x, x, O);
                        SetFrwdAttack(O, x, O);
                        break;
                    case eFormationTypes.Type_4_2_2_2:
                        SetDefense(O, O, x, O, O);
                        SetMidDefn(x, O, x, O, x);
                        SetMidfiel(x, x, x, x, x);
                        SetOffense(x, O, x, O, x);
                        SetFrwdAttack(O, x, O);
                        break;
                    case eFormationTypes.Type_4_3_3:
                        SetDefense(O, O, x, O, O);
                        SetMidDefn(x, x, x, x, x);
                        SetMidfiel(O, x, O, x, O);
                        SetOffense(x, x, x, x, x);
                        SetFrwdAttack(O, O, O);
                        break;
                    case eFormationTypes.Type_4_3_3_D:
                        SetDefense(O, O, x, O, O);
                        SetMidDefn(x, x, O, x, x);
                        SetMidfiel(x, O, x, O, x);
                        SetOffense(O, x, x, x, O);
                        SetFrwdAttack(x, O, x);
                        break;
                    case eFormationTypes.Type_4_5_1_D:
                        SetDefense(O, O, x, O, O);
                        SetMidDefn(x, O, x, O, x);
                        SetMidfiel(O, x, x, x, O);
                        SetOffense(x, x, O, x, x);
                        SetFrwdAttack(x, O, x);
                        break;
                    case eFormationTypes.Type_4_5_1_O:
                        SetDefense(O, O, x, O, O);
                        SetMidDefn(x, x, O, x, x);
                        SetMidfiel(O, x, x, x, O);
                        SetOffense(x, O, x, O, x);
                        SetFrwdAttack(x, O, x);
                        break;
                    case eFormationTypes.Type_4_1_4_1:
                        SetDefense(O, O, x, O, O);
                        SetMidDefn(x, x, O, x, x);
                        SetMidfiel(O, O, x, O, O);
                        SetOffense(x, x, x, x, x);
                        SetFrwdAttack(x, O, x);
                        break;
                    case eFormationTypes.Type_4_4_1_1:
                        SetDefense(O, O, x, O, O);
                        SetMidDefn(x, x, x, x, x);
                        SetMidfiel(O, O, x, O, O);
                        SetOffense(x, x, O, x, x);
                        SetFrwdAttack(x, O, x);
                        break;
                    case eFormationTypes.Type_4_2_3_1:
                        SetDefense(O, O, x, O, O);
                        SetMidDefn(x, O, x, O, x);
                        SetMidfiel(x, x, x, x, x);
                        SetOffense(O, x, O, x, O);
                        SetFrwdAttack(x, O, x);
                        break;
                    case eFormationTypes.Type_4_3_2_1:
                        SetDefense(O, O, x, O, O);
                        SetMidDefn(O, x, O, x, O);
                        SetMidfiel(x, x, x, x, x);
                        SetOffense(x, O, x, O, x);
                        SetFrwdAttack(x, O, x);
                        break;
                    case eFormationTypes.Type_3_3_2_2:
                        SetDefense(x, O, O, O, x);
                        SetMidDefn(O, x, O, x, O);
                        SetMidfiel(x, x, x, x, x);
                        SetOffense(x, O, x, O, x);
                        SetFrwdAttack(O, x, O);
                        break;
                    case eFormationTypes.Type_3_2_3_2:
                        SetDefense(O, x, O, x, O);
                        SetMidDefn(x, O, x, O, x);
                        SetMidfiel(x, x, x, x, x);
                        SetOffense(O, x, O, x, O);
                        SetFrwdAttack(O, x, O);
                        break;
                    case eFormationTypes.Type_3_5_2_O:
                        SetDefense(x, O, O, O, x);
                        SetMidDefn(x, x, O, x, x);
                        SetMidfiel(O, x, x, x, O);
                        SetOffense(x, O, x, O, x);
                        SetFrwdAttack(O, x, O);
                        break;
                    case eFormationTypes.Type_3_5_2_D:
                        SetDefense(x, O, O, O, x);
                        SetMidDefn(x, O, x, O, x);
                        SetMidfiel(O, x, x, x, O);
                        SetOffense(x, x, O, x, x);
                        SetFrwdAttack(O, x, O);
                        break;
                    case eFormationTypes.Type_3_4_3:
                        SetDefense(x, O, O, O, x);
                        SetMidDefn(x, x, x, x, x);
                        SetMidfiel(O, O, x, O, O);
                        SetOffense(x, x, x, x, x);
                        SetFrwdAttack(O, O, O);
                        break;
                    case eFormationTypes.Type_3_3_3_1:
                        SetDefense(O, x, O, x, O);
                        SetMidDefn(O, x, O, x, O);
                        SetMidfiel(x, x, x, x, x);
                        SetOffense(O, x, O, x, O);
                        SetFrwdAttack(x, O, x);
                        break;
                    case eFormationTypes.Type_5_4_1:
                        SetDefense(O, O, O, O, O);
                        SetMidDefn(x, x, x, x, x);
                        SetMidfiel(O, O, x, O, O);
                        SetOffense(x, x, x, x, x);
                        SetFrwdAttack(x, O, x);
                        break;
                    case eFormationTypes.Type_5_4_1_d:
                        SetDefense(O, O, O, O, O);
                        SetMidDefn(x, x, O, x, x);
                        SetMidfiel(O, x, x, x, O);
                        SetOffense(x, x, O, x, x);
                        SetFrwdAttack(x, O, x);
                        break;
                    case eFormationTypes.Type_5_3_2:
                        SetDefense(O, O, O, O, O);
                        SetMidDefn(x, x, x, x, x);
                        SetMidfiel(x, O, O, O, x);
                        SetOffense(x, x, x, x, x);
                        SetFrwdAttack(O, x, O);
                        break;
                    case eFormationTypes.Type_5_3_2_D:
                        SetDefense(x, O, O, O, x);
                        SetMidDefn(O, x, x, x, O);
                        SetMidfiel(x, O, O, O, x);
                        SetOffense(x, x, x, x, x);
                        SetFrwdAttack(O, x, O);
                        break;
                    case eFormationTypes.Type_Empty:
                        SetDefense(x, x, x, x, x);
                        SetMidDefn(x, x, x, x, x);
                        SetMidfiel(x, x, x, x, x);
                        SetOffense(x, x, x, x, x);
                        SetFrwdAttack(x, x, x);
                        break;
                }
            }
        }

        private void SetFrwdAttack(bool CL, bool C, bool CR)
        {
            players[Pos.FCL].visible = CL;
            players[Pos.FC].visible = C;
            players[Pos.FCR].visible = CR;
        }

        private void SetOffense(bool L, bool CL, bool C, bool CR, bool R)
        {
            players[Pos.OML].visible = L;
            players[Pos.OMCL].visible = CL;
            players[Pos.OMC].visible = C;
            players[Pos.OMCR].visible = CR;
            players[Pos.OMR].visible = R;
        }

        private void SetMidfiel(bool L, bool CL, bool C, bool CR, bool R)
        {
            players[Pos.ML].visible = L;
            players[Pos.MCL].visible = CL;
            players[Pos.MC].visible = C;
            players[Pos.MCR].visible = CR;
            players[Pos.MR].visible = R;
        }

        private void SetMidDefn(bool L, bool CL, bool C, bool CR, bool R)
        {
            players[Pos.DML].visible = L;
            players[Pos.DMCL].visible = CL;
            players[Pos.DMC].visible = C;
            players[Pos.DMCR].visible = CR;
            players[Pos.DMR].visible = R;
        }

        private void SetDefense(bool L, bool CL, bool C, bool CR, bool R)
        {
            players[Pos.DL].visible = L;
            players[Pos.DCL].visible = CL;
            players[Pos.DC].visible = C;
            players[Pos.DCR].visible = CR;
            players[Pos.DR].visible = R;
        }

        public Player SetPlayer(int playerID, MatchList.PlayersListRow plr)
        {
            Player pl = FindPlayer(playerID);

            //pl.pf = row.Position;
            pl.vote = -1;
            pl.card = 0;

            return SetPlayer(pl, plr);
        }

        public Player SetPlayer(MatchList.TeamPerfRow row, MatchList.PlayersListRow plr)
        {
            Player pl = FindPlayer(row.Position.ToUpper());
            if (pl == null) return null;
            pl.pf = row.Position;
            pl.vote = (int)row.Vote;
            pl.card = row.Banned;

            return SetPlayer(pl, plr);
        }

        private Player SetPlayer(Player pl, MatchList.PlayersListRow plr)
        {
            pl.name = plr.Name;
            pl.playerID = plr.PlayerID;

            pl.skills = plr.GetSkillBits();

            pl.tip = plr.GetSkillString();

            if (pl.tip != "")
                pl.tip += "\r\n";

            if (!plr.IsMoMNull() && !plr.IsGolNull())
            {
                pl.tip += "PG: \t" + plr.PG.ToString() + "\r\n" +
                    "Gol: \t" + plr.Gol.ToString() + "\r\n" +
                    "MoM: \t" + plr.MoM + "\r\n" +
                    "Assist: \t" + plr.Assist.ToString() + "\r\n" +
                    "Val: \t" + plr.Val.ToString();
                
                pl.value = plr.Val;
            }

            pl.showValue = showMeanVote;

            if (!plr.IsASINull())
                pl.tip += "\r\n" + "ASI: \t" + plr.ASI.ToString();

            if (plr.IsNumberNull())
                pl.number = -1;
            else
                pl.number = plr.Number;

            pl.visible = true;

            return pl;
        }

        public Player SetPlayer(MatchDS.YourTeamPerfRow row)
        {
            Player pl = FindPlayer(row.Position.ToUpper());
            if (pl == null) return null;

            pl.name = row.Name;
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

        public Player SetPlayer(MatchDS.OppsTeamPerfRow row)
        {
            Player pl = FindPlayer(row.Position.ToUpper());
            if (pl == null) return null;
            pl.name = row.Name;
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

        /*
        public void Load(string filename)
        {
            formDS.ReadXml(filename);

            foreach (FormationDS.PlayerRow pr in formDS.Player)
            {
                players[pr.PosID].CopyFrom(pr);
            }
        }
        */

        public string GetPlayerPosition(Player player)
        {
            for (int i = 0; i < Pos.TOT; i++)
            {
                if (players[i] == null) continue;
                if (players[i].playerID == player.playerID)
                {
                    return Pos.ToString(i);
                }
            }

            return "";
        }

        /*
        public void Save(string filename)
        {
            for (int i = 0; i<players.Length; i++)
            {
                FormationDS.PlayerRow pr = formDS.Player.NewPlayerRow();

                players[i].CopyTo(pr);
                pr.PosID = i;

                formDS.Player.AddPlayerRow(pr);
            }

            formDS.WriteXml(filename);
        }
        */
        /*
        public void Save(string filename, int formID)
        {
            for (int i = 0; i<players.Length; i++)
            {
                FormationDS.PlayerRow pr = formDS.Player.NewPlayerRow();

                players[i].CopyTo(pr);
                pr.PosID = i;
                pr.formID = formID;

                formDS.Player.AddPlayerRow(pr);
            }

            formDS.WriteXml(filename);
        }
        */
    }
}
