using System; 
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace Common
{
    public enum eMatchType
    {
        CHAMP = 0,
        CUP = 1,
        FLEAGUE = 2,
        FRIENDLY = 3,
        INTERNATIONAL = 4
    }

    partial class ChampDS
    {
        public string[] mTDefs = null;
        public bool isDirty = false;

        public int TeamID = -1;
        public int ReservesID = -1;

        public List<int> iSeason = new List<int>();

        public int LoadSeasonFile_NewTM(string html, ref string matchTypes,
            int debugFunction, string ApplicationFolder)
        {
            isDirty = true;

            int cnt = 0;

            // Get the items
            string[] rows = html.Split('\n');

            foreach (string row in rows)
            {
                if (!row.Contains(";")) continue;

                Dictionary<string, string> items = HTML_Parser.CreateDictionary(row, ';');

                MatchRow mr = Match.NewMatchRow();

                // First, get the day number
                mr.Date = DateTime.Parse(items["date"]);
                mr.Score = items["result"];
                mr.Home = items["home_name"];
                mr.Away = items["away_name"];
                mr.MatchID = int.Parse(items["id"]);

                int homeID;
                int.TryParse(items["home"], out homeID);
                mr.isHome = (homeID == TeamID);

                string[] mDefs = matchTypes.Split(',');

                if (items["type"] == "l")
                    mr.MatchType = (byte)0;
                else if (items["type"] == "f")
                    mr.MatchType = (byte)2;
                else if (items["type"] == "fl")
                    mr.MatchType = (byte)3;
                else if (items["type"].StartsWith("p"))
                {
                    byte i = byte.Parse(items["type"].Substring(1));
                    mr.MatchType = (byte)(10 + i);
                }
                else if (items["type"].StartsWith("ue"))
                {
                    byte i = byte.Parse(items["type"].Substring(2));
                    mr.MatchType = (byte)(20 + i);
                }
                else if (items["type"].StartsWith("lq"))
                {
                    mr.MatchType = (byte)5; // Qualificazioni campionato
                }
                else
                {
                    mr.MatchType = (byte)4; // Altra internazionale
                }


                int home = int.Parse(items["home"]);
                int away = int.Parse(items["away"]);

                if (home == this.TeamID)
                {
                    mr.Analyzed = 0;
                    mr.isReserves = 0;
                    mr.OppsClubID = away;
                    mr.OppsClubName = mr.Away;
                }
                else if (away == this.TeamID)
                {
                    mr.Analyzed = 0;
                    mr.isReserves = 0;
                    mr.OppsClubID = home;
                    mr.OppsClubName = mr.Home;
                }
                else if (home == this.ReservesID)
                {
                    mr.Analyzed = 0;
                    mr.isReserves = 1;
                    mr.OppsClubID = away;
                    mr.OppsClubName = mr.Away;
                }
                else
                {
                    mr.Analyzed = 0;
                    mr.isReserves = 1;
                    mr.OppsClubID = home;
                    mr.OppsClubName = mr.Home;
                }

                {
                    MatchRow mrold = null;
                    if ((mrold = Match.FindByMatchID(mr.MatchID)) == null)
                        Match.AddMatchRow(mr);
                    else
                    {
                        mrold.Score = mr.Score;
                        mrold.Date = mr.Date;
                        mrold.MatchType = mr.MatchType;
                        mrold.Home = mr.Home;
                        mrold.Away = mr.Away;
                        mrold.OppsClubID = mr.OppsClubID;
                        mrold.isReserves = mr.isReserves;
                    }

                    cnt++;
                }
            }

            return cnt;
        }

        public void LoadSeasonFileNonFlash(string html, ref string matchTypes)
        {
            // Get the tables
            List<string> tables = HTML_Parser.GetTags(html, "TABLE");

            List<string> rows = HTML_Parser.GetTags(tables[0], "TR");

            foreach (string row in rows)
            {
                if (matchTypes == "") return;

                MatchRow mr = Match.NewMatchRow();

                if (mr.ParseRowHtml(row, ref matchTypes))
                {
                    mr.Away = mr.Away.Replace("Â ", "").Replace("\r\n", "");
                    mr.Home = mr.Home.Replace("Â ", "").Replace("\r\n", "");

                    MatchRow mrold = null;
                    if ((mrold = Match.FindByMatchID(mr.MatchID)) == null)
                        Match.AddMatchRow(mr);
                    else
                    {
                        mrold.Score = mr.Score;
                        mrold.Date = mr.Date;
                        mrold.MatchType = mr.MatchType;
                        mrold.Home = mr.Home;
                        mrold.Away = mr.Away;
                        mrold.OppsClubID = mr.OppsClubID;
                        mrold.isReserves = mr.isReserves;
                    }
                }
            }
        }

        public int LoadSeasonFileFlash(string seasonfile, ref string matchTypes,
            int debugFunction, string ApplicationFolder)
        {
            isDirty = true;

            int cnt = 0;

            // Match.Clear();

            string squad = seasonfile;
            squad = squad.Replace("&#34;", "'");

            // Get the script section
            string linedefs = HTML_Parser.GetField(squad, "var sorting = new Array(", ");");
            linedefs = linedefs.Replace("\"", "");
            string[] defs = linedefs.Split(',');
            matchTypes = "";

            for (int i = 0; i < defs.Length; i++)
            {
                defs[i] = defs[i].Trim("'".ToCharArray()).Trim("[]".ToCharArray());
                matchTypes += defs[i];
                if (i != defs.Length - 1)
                    matchTypes += ",";
            }
            mTDefs = defs;

            string script = HTML_Parser.GetField(squad, "var week = [[", "]];");

            if (script == "")
                script = HTML_Parser.GetField(squad, "var week = [[", "<!--EndFragment-->");

            if (script == "")
            {
                MessageBox.Show("The Season File is not complete. Please, update the browser page and repeat the Copy operation");

                if (debugFunction == 101)
                {
                    DialogResult res = MessageBox.Show("Send a report about this function?",
                        "Debug function", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No) return cnt;

                    Exception ex = new Exception("Problem Report");
                    string swRelease = "Sw Release:" + Application.ProductName + "("
                        + Application.ProductVersion + ")";

                    string page = "Season file: " + seasonfile + "\n";
                    page += "MatchTypes: " + matchTypes + "\n";

                    SendFileTo.ErrorReport.Send(ex, page, Environment.StackTrace, swRelease);
                }
                return cnt;
            }

            script = HTML_Parser.ConvertHTML(script);
            script = script.Replace("§", "£");
            script = script.Replace("],[", "§");


            // Get all rows of the players table
            string[] plRows = script.Split('§');

            // Row 0 is the table header
            for (int match = 0; match < plRows.Length; match++)
            {
                List<string> clubs = HTML_Parser.GetFieldsCut(plRows[match], "showclub=", ">");

                if (clubs.Count == 1)
                {
                    if (clubs[0] == "") continue;

                    MatchRow mr = Match.NewMatchRow();
                    if (mr.ParseRow(plRows[match], mTDefs))
                    {
                        mr.isReserves = 0;

                        MatchRow mrold = null;
                        if ((mrold = Match.FindByMatchID(mr.MatchID)) == null)
                        {
                            Match.AddMatchRow(mr);
                            cnt = cnt + 1;
                        }
                        else
                        {
                            mrold.Score = mr.Score;
                            mrold.Date = mr.Date;
                            mrold.MatchType = mr.MatchType;
                            mrold.Home = mr.Home;
                            mrold.Away = mr.Away;
                            mrold.OppsClubID = mr.OppsClubID;
                            mrold.isReserves = 0;
                        }
                    }
                }
                else if (clubs.Count == 2)
                {
                    if ((clubs[0] == "") && (clubs[1] == "")) continue;

                    if (ReservesID == 0)
                    {
                        MessageBox.Show("You must first set the reserves club ID in the 'Your Teams Data' page of the\n" +
                            "Options form, that can be open using the Tools->Options menu\n" +
                            "The club ID could be found in the clubhouse page of the main squad and reserves squad menu");
                        break;
                    }

                    MatchRow mr = Match.NewMatchRow();
                    if (mr.ParseReserveRow(plRows[match], mTDefs))
                    {
                        mr.isReserves = 1;

                        MatchRow mrold = null;
                        if ((mrold = Match.FindByMatchID(mr.MatchID)) == null)
                        {
                            Match.AddMatchRow(mr);
                            cnt = cnt + 1;
                        }
                        else
                        {
                            mrold.Score = mr.Score;
                            mrold.Date = mr.Date;
                            mrold.MatchType = mr.MatchType;
                            mrold.Home = mr.Home;
                            mrold.Away = mr.Away;
                            mrold.OppsClubID = mr.OppsClubID;
                            mrold.isReserves = 1;
                        }
                    }
                }
            }

            if (debugFunction == 101)
            {
                DialogResult res = MessageBox.Show("Send a report about this function?",
                    "Debug Function", MessageBoxButtons.YesNo);
                if (res == DialogResult.No) return cnt;

                Exception ex = new Exception("Problem Report");
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string page = "Season file: " + seasonfile + "\n";
                page += "MatchTypes: " + matchTypes + "\n";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(ApplicationFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                Match.WriteXml(fi.FullName);

                StreamReader file = new StreamReader(fi.FullName);
                page += "Match:\r\n" + file.ReadToEnd();
                file.Close();

                SendFileTo.ErrorReport.Send(ex, page, Environment.StackTrace, swRelease);
            }

            return cnt;
        }

        partial class MatchRow
        {
            internal bool ParseReserveRow(string tablerow, string[] mDefs)
            {
                string[] plCells = tablerow.Split(',');

                if (plCells.Length < 5)
                    return false;

                plCells[4] = plCells[4].Trim('\'');
                if (plCells[4] == "")
                    return false;

                // This is a match row docode it
                int resClubID = ((ChampDS)this.Table.DataSet).ReservesID;

                List<string> clubs = HTML_Parser.GetFieldsCut(tablerow, "showclub=", ">");

                if ((clubs[0] == "-") || (clubs[1] == "-"))
                    return false;

                int club1 = int.Parse(clubs[0]);
                int club2 = int.Parse(clubs[1]);

                if (club1 == resClubID)
                    this.OppsClubID = club2;
                else
                    this.OppsClubID = club1;


                if (plCells[2].Contains("?matchid="))
                {
                    // This is a match row docode it
                    int matchID;
                    if (!int.TryParse(HTML_Parser.GetField(plCells[2], "matchid=", ">"), out matchID))
                        return false;

                    this.MatchID = matchID;

                    plCells[4] = plCells[4].Trim("'[]".ToCharArray());

                    for (int i = 0; i < mDefs.Length; i++)
                    {
                        if (plCells[4] == mDefs[i])
                        {
                            this.MatchType = (byte)i;
                            break;
                        }
                    }

                    this.Score = HTML_Parser.GetField(plCells[2], "<span>", "</span>");

                    if (this.OppsClubID == club2)
                    {
                        this.isHome = true;
                        this.OppsClubName = HTML_Parser.GetTag(plCells[3], "a");
                        Away = this.OppsClubName;
                        Home = HTML_Parser.GetTag(plCells[1], "a");
                    }
                    else
                    {
                        this.isHome = false;
                        this.OppsClubName = HTML_Parser.GetTag(plCells[1], "a");
                        Home = this.OppsClubName;
                        Away = HTML_Parser.GetTag(plCells[3], "a");
                    }

                    string date = plCells[0].Trim("'[]".ToCharArray());

                    DateTime dt;

                    try
                    {
                        dt = DateTime.Parse(date, Common.CommGlobal.ciIt);
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                    this.Date = dt;

                    if (Score.Contains(":"))
                    {
                        if (Date < DateTime.Today)
                            Date = Date.AddYears(1);
                    }
                    else
                    {
                        if (Date > DateTime.Today)
                            Date = Date.AddYears(-1);
                    }

                    return true;
                }

                return false;
            }

            internal bool ParseRow(string tablerow, string[] mDefs)
            {
                // This is a match row docode it
                int oppClubID;

                List<string> clubs = HTML_Parser.GetFieldsCut(tablerow, "showclub=", ">");

                if (!int.TryParse(HTML_Parser.GetField(tablerow, "showclub=", ">"), out oppClubID))
                    return false;

                this.OppsClubID = oppClubID;

                string[] plCells = tablerow.Split(',');

                if (plCells.Length < 5) return false;

                if (plCells[2].Contains("?matchid="))
                {
                    // This is a match row docode it
                    int matchID;
                    if (!int.TryParse(HTML_Parser.GetField(plCells[2], "matchid=", ">"), out matchID))
                        return false;

                    this.MatchID = matchID;

                    plCells[4] = plCells[4].Trim("'[]".ToCharArray());

                    for (int i = 0; i < mDefs.Length; i++)
                    {
                        if (plCells[4] == mDefs[i])
                        {
                            this.MatchType = (byte)i;
                            break;
                        }
                    }

                    this.Score = HTML_Parser.GetField(plCells[2], "<span>", "</span>");

                    if (plCells[3].Contains("?showclub="))
                    {
                        this.isHome = true;
                        this.OppsClubName = HTML_Parser.GetTag(plCells[3], "a");
                        Away = this.OppsClubName;
                        Home = plCells[1].Trim('\'');
                    }
                    else
                    {
                        this.isHome = false;
                        this.OppsClubName = HTML_Parser.GetTag(plCells[1], "a");
                        Home = this.OppsClubName;
                        Away = plCells[3].Trim('\'');
                    }

                    string date = plCells[0].Trim("'[]".ToCharArray());

                    DateTime dt;

                    try
                    {
                        dt = DateTime.Parse(date, Common.CommGlobal.ciIt);
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                    this.Date = dt;

                    if (Score.Contains(":"))
                    {
                        if (Date < DateTime.Today)
                            Date = Date.AddYears(1);
                    }
                    else
                    {
                        if (Date > DateTime.Today)
                            Date = Date.AddYears(-1);
                    }

                    return true;
                }

                return false;
            }

            internal bool ParseRowHtml_NewTM(string tablerow, ref string matchTypes)
            {
                List<string> plCells = HTML_Parser.GetTags(tablerow.Replace("<SPAN class=hometeam_flag></SPAN>", ""), "SPAN");
                if (plCells[1] == "") plCells.RemoveAt(1);

                if (plCells.Count < 6) return false;

                // This is a match row docode it
                int clubID1 = int.Parse(HTML_Parser.GetNumberAfter(plCells[2], "href=\"/club/"));
                int clubID2 = int.Parse(HTML_Parser.GetNumberAfter(plCells[4], "href=\"/club/"));

                if ((clubID1 != ((ChampDS)this.Table.DataSet).TeamID) &&
                    (clubID1 != ((ChampDS)this.Table.DataSet).ReservesID))
                {
                    OppsClubID = clubID1;
                }
                else
                {
                    OppsClubID = clubID2;
                }

                if (plCells[3].Contains("/matches/"))
                {
                    // This is a match row docode it
                    int matchID;
                    if (!int.TryParse(HTML_Parser.GetNumberAfter(plCells[3], "/matches/"), out matchID))
                        return false;

                    this.MatchID = matchID;

                    string[] mDefs = matchTypes.Split(',');

                    int i = 0;
                    for (; i < mDefs.Length; i++)
                    {
                        string[] mDefsTypes = mDefs[i].Split(';');
                        foreach (string mDefsType in mDefsTypes)
                        {
                            if (mDefsType == plCells[1])
                            {
                                this.MatchType = (byte)i;
                                break;
                            }
                        }
                        if (!this.IsMatchTypeNull())
                            break;
                    }
                    if (i == mDefs.Length)
                    {
                        MessageBox.Show("A match type has not been recognized. Select which Match type is \"" + plCells[1] + "\" in the next form.", "Unrecognized Match Type");

                        SelectMatchType smtForm = new SelectMatchType();
                        smtForm.MatchTypeName = plCells[1];
                        if (smtForm.ShowDialog() == DialogResult.Cancel)
                            return false;

                        string newMatchType = "";
                        for (i = 0; i < mDefs.Length; i++)
                        {
                            string mDef = mDefs[i];
                            if (i == (int)smtForm.MatchType)
                                mDef += ";" + smtForm.MatchTypeName;
                            newMatchType += "," + mDef;
                        }
                        matchTypes = newMatchType.Trim(",".ToCharArray());
                        i = (int)smtForm.MatchType;

                        this.MatchType = (byte)i;
                    }

                    this.Score = HTML_Parser.CleanTags(plCells[3]);

                    if ((clubID1 == ((ChampDS)this.Table.DataSet).ReservesID) ||
                        (clubID2 == ((ChampDS)this.Table.DataSet).ReservesID))
                    {
                        int resClubID = ((ChampDS)this.Table.DataSet).ReservesID;
                        this.isHome = (clubID1 == resClubID);
                        this.isReserves = 1;

                        if (isHome)
                        {
                            this.OppsClubName = HTML_Parser.CleanTags(plCells[4]);
                            Away = this.OppsClubName;
                            Home = HTML_Parser.CleanTags(plCells[2]);
                        }
                        else
                        {
                            this.OppsClubName = HTML_Parser.CleanTags(plCells[2]);
                            Home = this.OppsClubName;
                            Away = HTML_Parser.CleanTags(plCells[4]);
                        }
                    }
                    else // Is main team
                    {
                        int mainClubID = ((ChampDS)this.Table.DataSet).TeamID;
                        this.isHome = (clubID1 == mainClubID);
                        this.isReserves = 0;

                        if (isHome)
                        {
                            this.OppsClubName = HTML_Parser.CleanTags(plCells[4]);
                            Away = this.OppsClubName;
                            Home = HTML_Parser.CleanTags(plCells[2]);
                        }
                        else
                        {
                            this.OppsClubName = HTML_Parser.CleanTags(plCells[2]);
                            Home = this.OppsClubName;
                            Away = HTML_Parser.CleanTags(plCells[4]);
                        }
                    }

                    return true;
                }

                return false;
            }

            internal bool ParseRowHtml(string tablerow, ref string matchTypes)
            {
                List<string> plCells = HTML_Parser.GetTags(tablerow.Replace("&nbsp;", " "), "TD");

                if (plCells.Count != 5) return false;
                if (plCells[4] == "") return false;

                // This is a match row docode it
                int oppClubID;
                if (!int.TryParse(HTML_Parser.GetField(tablerow, "showclub=", ">"), out oppClubID))
                    return false;

                this.OppsClubID = oppClubID;

                if (plCells[2].Contains("?matchid="))
                {
                    // This is a match row docode it
                    int matchID;
                    if (!int.TryParse(HTML_Parser.GetField(plCells[2], "matchid=", ">"), out matchID))
                        return false;

                    this.MatchID = matchID;

                    plCells[4] = plCells[4].Trim("'[]".ToCharArray());

                    string[] mDefs = matchTypes.Split(',');

                    int i = 0;
                    for (; i < mDefs.Length; i++)
                    {
                        if (plCells[4] == mDefs[i])
                        {
                            this.MatchType = (byte)i;
                            break;
                        }
                    }
                    if (i == mDefs.Length)
                    {
                        MessageBox.Show("The match types are not recognized. Change the settings in the options dialog" +
                            "Goto to the menu item Tools->Options, General, Match Types", "Wrong Match Type");
                        matchTypes = "";
                        return false;
                    }

                    this.Score = HTML_Parser.GetField(plCells[2], "<span>", "</span>");

                    if (plCells[1].Contains("?showclub=") && plCells[3].Contains("?showclub="))
                    {
                        int homeid = int.Parse(HTML_Parser.GetNumberAfter(plCells[1], "showclub="));

                        int resClubID = ((ChampDS)this.Table.DataSet).ReservesID;
                        this.isHome = (homeid == resClubID);
                        this.isReserves = 1;

                        if (this.isHome)
                        {
                            this.OppsClubName = HTML_Parser.GetTag(plCells[3], "span");
                            Away = this.OppsClubName;
                            Home = HTML_Parser.GetTag(plCells[1], "span");
                        }
                        else
                        {
                            this.OppsClubName = HTML_Parser.GetTag(plCells[1], "span");
                            Home = this.OppsClubName;
                            Away = HTML_Parser.GetTag(plCells[3], "span");
                        }
                    }
                    else
                    {
                        if (plCells[3].Contains("?showclub="))
                        {
                            this.isHome = true;
                            this.OppsClubName = HTML_Parser.GetTag(plCells[3], "span");
                            Away = this.OppsClubName;
                            Home = plCells[1].Trim("\' ".ToCharArray());
                        }
                        else
                        {
                            this.isHome = false;
                            this.OppsClubName = HTML_Parser.GetTag(plCells[1], "span");
                            Home = this.OppsClubName;
                            Away = plCells[3].Trim("\' ".ToCharArray());
                        }
                    }

                    string date = HTML_Parser.GetTag(plCells[0], "strong");

                    DateTime dt;

                    try
                    {
                        dt = DateTime.Parse(date, Common.CommGlobal.ciIt);
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                    this.Date = dt;

                    if (Score.Contains(":"))
                    {
                        if (Date < DateTime.Today)
                            Date = Date.AddYears(1);
                    }
                    else
                    {
                        if (Date > DateTime.Today)
                            Date = Date.AddYears(-1);
                    }

                    return true;
                }

                return false;
            }
        }

        partial class PlyStatsDataTable
        {
            public void RefreshPlayerStats(int playerID, byte matchType, int season)
            {
                PlyStatsRow psr = FindByPlayerIDSeasonIDTypeStats(playerID,
                            season,
                            matchType);

                if (!psr.IsVotesNull())
                {
                    string[] votes = psr.Votes.Split(';');
                    float meanV = 0.0f;
                    float meanW = 0.0f;

                    foreach (string vote in votes)
                    {
                        string[] pts = vote.Split('|');
                        meanV += float.Parse(pts[2]);
                        meanW += float.Parse(pts[3]);
                    }

                    psr.Value = meanV / (float)votes.Length;
                    psr.NormVal = meanW / (float)votes.Length;

                    psr.PG = votes.Length;
                }

                if (psr.IsAnalysisNull())
                {
                    return;
                }

                string analysis = psr.Analysis;

                string[] matches = analysis.Split(';');
                psr.Goals = Action.Count(analysis, "gg");
                psr.Assist = Action.Count(analysis, "aa");
                psr.InShots = Action.Count(analysis, "ss");
                psr.RedCards = Action.Count(analysis, "rr");

                // yy=yellow, yh=giallo con duro contrasto
                string[] yellow = { "yy", "yh" };
                psr.YellowCards = Action.Count(analysis, yellow);

                // th=Colpo di Testa, tn=Tiro da vicino, tl=Tiro da lontano, tp=Calcio di punizione, tr=Rigore
                string[] tiri = { "th", "tn", "tl", "tp", "tr" };
                psr.Shots = Action.Count(analysis, tiri);

                // dh=Colpo di Testa, dt=Tackle, dc=Contrasto, da=Anticipo, dp=Posizione, di=Palla Intercettata
                string[] difesa = { "dh", "dt", "dc", "da", "dp", "di" };
                psr.DefActs = Action.Count(analysis, difesa);

                // of=Palla Filtrante, op=passaggio, ol=Pass.Lungo, oc=Contropiede, ow=Ali, ok=Calcio di Punizione, or:Cross, od=Dribbling, ov=Velocità, ot=Tecnica, oy=Fermato con ammonizione, on=corner, os=pass.corti, og=rigore procurato
                string[] offacts = { "of", "op", "ol", "oc", "ow", "ok", "or", "od", "ov", "ot", "oy", "on", "os", "og" };
                psr.OffActs = Action.Count(analysis, offacts);

                // ed=Difensivo, ea=Attacco, ep=Passaggio, el=Lancio lungo, ew=Fascia, ec=Corner, ef:Pass.Filtrante, er:Riflessi Portiere, ek:Punizione sbagliata, eg:Errore Portiere, em=Marcatura, eh=Errore di testa, ev=Velocità, et=takle, eo=Posizione
                string[] errors = { "ed", "ea", "ep", "el", "ew", "ec", "ef", "er", "ek", "eg", "em", "eh", "ev", "et", "eo" };
                psr.Errors = Action.Count(analysis, errors);

                // pp=Parata, pb=Bloccata, pd=deviata, pr=riflessi, po=Uno vs Uno, pj=Tuffo, pa=aerial
                string[] gkd = { "pp", "pb", "pd", "pr", "po", "pj", "pa" };
                psr.GKd = Action.Count(analysis, gkd);
            }

            public void AddPlayerStats(MatchRow mr, MatchDS matchDS, string clubNick)
            {
                if (matchDS.MatchData.Rows.Count == 0)
                    return;

                MatchDS.MatchDataRow mdr = (MatchDS.MatchDataRow)matchDS.MatchData.Rows[0];

                int firstColor = 0;
                bool isFirstColorYourTeam = false;

                if (matchDS.Actions.Count == 0)
                {
                    MessageBox.Show("The following match contains some errors, please paste this match once again\n",
                        mr.Date + " : " + mr.Home + " - " + mr.Away);
                    return;
                }

                MatchDS.ActionsRow ar0 = matchDS.Actions[0];
                if (ar0.Description.Contains(clubNick))
                {
                    isFirstColorYourTeam = true;
                    firstColor = ar0.Color;
                }
                else
                {
                    firstColor = ar0.Color;
                }

                if (mr == null) return;

                mr.Cards = "";
                foreach (MatchDS.ActionsRow atr in matchDS.Actions)
                {
                    if ((atr.ActionType == "me_yellow") ||
                        (atr.ActionType == "me_yellow2") ||
                        (atr.ActionType == "me_red"))
                    {
                        int card_id = 0;
                        int card_type = (atr.ActionType == "me_yellow") ? 1 :
                            (atr.ActionType == "me_yellow2") ? 2 : 3;

                        if (((atr.Color == firstColor) && isFirstColorYourTeam) ||
                            ((atr.Color != firstColor) && !isFirstColorYourTeam))
                        {
                            List<string> tok = HTML_Parser.GetFieldsCut(atr.Description, "<a href=showprofile.php?playerid=", ">");

                            foreach (string str in tok)
                            {
                                int id = int.Parse(str);

                                if (matchDS.YourTeamPerf.FindByPlayerID(id) != null)
                                {
                                    // Quello che ha ricevuto il cartellino è un tuo giocatore
                                    card_id = id;
                                }
                            }
                        }

                        if (card_id != 0)
                        {
                            string str = card_id.ToString() + "|" + card_type.ToString();

                            if (mr.Cards == "")
                            {
                                mr.Cards = str;
                            }
                            else
                            {
                                mr.Cards += "," + str;
                            }
                        }
                    }
                }

                foreach (MatchDS.YourTeamPerfRow pr in matchDS.YourTeamPerf)
                {
                    int seasonID = TmWeek.GetSeason(mr.Date);

                    PlyStatsRow psr = this.FindByPlayerIDSeasonIDTypeStats(pr.PlayerID,
                        seasonID, mr.MatchType);

                    if (psr == null)
                    {
                        psr = NewPlyStatsRow();
                        psr.PlayerID = pr.PlayerID;
                        psr.TypeStats = (int)mr.MatchType;
                        psr.SeasonID = seasonID;

                        if (!pr.IsScoredNull())
                        {
                            psr.Goals = pr.Scored;
                        }

                        if (!pr.IsVoteNull())
                        {
                            if (pr.Vote != 0)
                                psr.PG = 1;
                            else
                                psr.PG = 0;
                        }

                        psr.AddInfo(mr, pr, matchDS.MeanVote);

                        if (psr.PlayerID == mdr.BestPlayer)
                            psr.MoM = 1;
                        else
                            psr.MoM = 0;

                        if (!mr.IsCardsNull())
                        {
                            string id = psr.PlayerID.ToString();
                            if (mr.Cards.Contains(id))
                            {
                                string[] cards = mr.Cards.Split(',');
                                foreach (string card in cards)
                                {
                                    if (!card.Contains(id)) continue;

                                    int cardType = int.Parse(card.Split('|')[1]);

                                    if (cardType == 1)
                                        psr.YellowCards = 1;
                                    else
                                        psr.RedCards = 1;
                                }
                            }
                        }

                        AddPlyStatsRow(psr);

                        psr.UpdateMean();
                    }
                    else
                    {
                        psr.AddInfo(mr, pr, matchDS.MeanVote);

                        if (!pr.IsScoredNull())
                        {
                            psr.Goals += pr.Scored;
                        }

                        if (!pr.IsVoteNull())
                        {
                            if (pr.Vote != 0)
                                if (psr.IsPGNull())
                                    psr.PG = 1;
                                else
                                    psr.PG++;
                        }

                        if (psr.PlayerID == mdr.BestPlayer)
                            psr.MoM++;

                        if (!mr.IsCardsNull())
                        {
                            string id = psr.PlayerID.ToString();
                            if (mr.Cards.Contains(id))
                            {
                                string[] cards = mr.Cards.Split(',');
                                foreach (string card in cards)
                                {
                                    if (!card.Contains(id)) continue;

                                    int cardType = int.Parse(card.Split('|')[1]);

                                    if (cardType == 1)
                                        if (psr.IsYellowCardsNull())
                                            psr.YellowCards = 1;
                                        else
                                            psr.YellowCards++;
                                    else
                                        if (psr.IsRedCardsNull())
                                        psr.RedCards = 1;
                                    else
                                        psr.RedCards++;
                                }
                            }
                        }

                        psr.UpdateMean();
                    }
                }
            }

            internal void AddPlayerAnalysis(int plID, byte matchType, int season)
            {
                PlyStatsRow psr = FindByPlayerIDSeasonIDTypeStats(plID, season, matchType);

                if (psr == null) return;


            }
        }

        partial class PlyStatsRow
        {
            internal void AddInfo(MatchRow mr, MatchDS.YourTeamPerfRow pr, float SquadMean)
            {
                string perf = "";

                if (!IsVotesNull())
                    perf = this.Votes;

                if (perf != "") perf += ";";
                if (pr.IsVoteNull()) return;
                perf += TmWeek.ToSWDString(mr.Date) + "|" + pr.Position + "|" + pr.Vote + "|" + WeightVote(pr.Vote, SquadMean);

                this.Votes = perf;
            }

            private string WeightVote(float vote, float SquadMean)
            {
                float fvote = (float)vote;

                if (fvote < SquadMean)
                    return (fvote / SquadMean * 5).ToString("N1");
                else
                    return (5f + (fvote - SquadMean) / (10 - SquadMean) * 5f).ToString("N1");
            }

            internal void UpdateMean()
            {
                if (!IsVotesNull())
                {
                    string[] votes = this.Votes.Split(';');
                    float sum = 0.0f;
                    float sumw = 0.0f;
                    foreach (string res in votes)
                    {
                        string[] str = res.Split('|');
                        sum += float.Parse(str[2]);
                        sumw += float.Parse(str[3]);
                    }

                    this.Value = sum / (float)votes.Length; ;
                    this.NormVal = sumw / (float)votes.Length;
                }
            }

            public void SetAnalysis(DateTime dateTime, string plActions)
            {
                string timestr = dateTime.ToShortDateString();

                if (this.IsAnalysisNull()) Analysis = "";

                string analysis = this.Analysis;

                if (analysis.Length == 0) // no record
                {
                    Analysis = timestr + "|" + plActions;
                    return;
                }

                int ix = analysis.IndexOf(timestr);

                if (ix == -1) // not found
                {
                    Analysis += ";" + timestr + "|" + plActions;
                }
                else // found
                {
                    int ixe = analysis.IndexOf(';', ix);
                    if (ixe == -1) ixe = analysis.Length;

                    string newString = timestr + "|" + plActions;

                    if (ixe != analysis.Length)
                        Analysis = analysis.Substring(0, ix) + newString + analysis.Substring(ixe);
                    else
                        Analysis = analysis.Substring(0, ix) + newString;
                }
            }

            private string ToQuantity(string plActions)
            {
                string[] singleActions = plActions.Split(',');
                string res = "";

                foreach (string act in singleActions)
                {
                    if (res != "") res += ",";

                    res += "1" + act;
                }

                return res;
            }

            private string ActionsSum(string oldActions, string plActions)
            {
                // actions are the actions to add
                string[] actions = plActions.Split(',');

                foreach (string action in actions)
                {
                    int ix = oldActions.IndexOf(action);
                    if (ix == -1)
                    {
                        oldActions += ",1" + action;
                        continue;
                    }

                    int ixi = oldActions.LastIndexOf(',', ix);

                    string q = oldActions.Substring(ixi + 1, ix - ixi - 1);

                    int quantity = int.Parse(q);

                    if (oldActions.Length > ix + 2)
                    {
                        if (ixi == -1)
                        {
                            oldActions = (quantity + 1).ToString() + action +
                                                        oldActions.Substring(ix + 2);
                        }
                        else
                        {
                            oldActions = oldActions.Substring(0, ixi) + "," +
                                                        (quantity + 1).ToString() + action +
                                                        oldActions.Substring(ix + 2);
                        }
                    }
                    else
                    {
                        if (ixi == -1)
                        {
                            oldActions = (quantity + 1).ToString() + action;
                        }
                        else
                        {
                            oldActions = oldActions.Substring(0, ixi) + "," +
                                            (quantity + 1).ToString() + action;
                        }
                    }
                }

                return oldActions;
            }

            public void SetVote(DateTime date, float fvote, string position, float meanVote)
            {
                string vdate = TmWeek.ToSWDString(date);
                string newVotes = "";
                string newvote = vdate + "|" + position + "|" + fvote.ToString() + "|" + WeightVote(fvote, meanVote); ;

                if (IsVotesNull())
                {
                    Votes = newvote;
                    return;
                }

                if (Votes.Contains(vdate))
                {
                    bool set = false;
                    string[] votes = Votes.Split(';');

                    foreach (string vote in votes)
                    {
                        if ((vote.Contains(vdate)) && (!set))
                        {
                            set = true;

                            newVotes += newvote + ";";
                        }
                        else if (!vote.Contains(vdate))
                        {
                            newVotes += vote + ";";
                        }
                    }

                    Votes = newVotes.TrimEnd(';');
                }
                else
                {
                    Votes += ";" + newvote;
                }
            }
        }

        //partial class PlyMatchStatsRow
        //{
        //    internal void AddInfo(MatchRow mr, MatchDS.YourTeamPerfRow pr, float SquadMean)
        //    {
        //        string perf = "";

        //        switch ((eMatchType)mr.MatchType)
        //        {
        //            case eMatchType.MT_CHAMP: if (!IsLeagueStatsNull()) perf = this.LeagueStats; break;
        //            case eMatchType.MT_CUP: if (!IsCupStatsNull()) perf = this.CupStats; break;
        //            case eMatchType.MT_FLEAGUE: if (!IsFLStatsNull()) perf = this.FLStats; break;
        //            case eMatchType.MT_FRIENDLY: if (!IsFriendlyStatsNull()) perf = this.FriendlyStats; break;
        //        }

        //        if (perf != "") perf += ";";
        //        if (pr.IsVoteNull()) return;
        //        perf += mr.Date.ToShortDateString() + "|" + pr.Position + "|" + pr.Vote + "|" + WeightVote(pr.Vote, SquadMean);

        //        switch ((eMatchType)mr.MatchType)
        //        {
        //            case eMatchType.MT_CHAMP: this.LeagueStats = perf; break;
        //            case eMatchType.MT_CUP: this.CupStats = perf; break;
        //            case eMatchType.MT_FLEAGUE: this.FLStats = perf; break;
        //            case eMatchType.MT_FRIENDLY: this.FriendlyStats = perf; break;
        //        }
        //    }

        //}


        public void UpdateSeason(ComboBox cmbSeason)
        {
            int selected = -1;

            if (cmbSeason.SelectedItem != null)
                selected = (int)cmbSeason.SelectedItem;
            else
                selected = TmWeek.thisWeek().Season;

            cmbSeason.Items.Clear();

            foreach (MatchRow row in Match)
            {
                TmWeek tmw = new TmWeek(row.Date);
                if (!cmbSeason.Items.Contains(tmw.Season))
                    cmbSeason.Items.Add(tmw.Season);
            }

            cmbSeason.Sorted = true;

            if (cmbSeason.Items.Contains(selected))
                cmbSeason.SelectedItem = selected;
            else
            {
                if (cmbSeason.Items.Count > 0)
                    cmbSeason.SelectedItem = cmbSeason.Items[cmbSeason.Items.Count - 1];
            }
        }

        partial class MatchDataTable
        {
            public bool UpdatedCalendarReserves()
            {
                DateTime dtYesterday = DateTime.Now.AddDays(-1);
                DateTime dtSeasonStart = TmWeek.GetDateTimeOfSeasonStart(TmWeek.GetSeason(DateTime.Now));

                ChampDS.MatchRow[] mrows = null;

                try
                {
                    string str = "(isReserves = 1) AND (Date > #" + dtSeasonStart.ToString(CommGlobal.ciUs) + "#)";
                    mrows = (ChampDS.MatchRow[])this.Select(str);
                }
                catch (Exception ex)
                {
                }

                if (mrows.Length > 33)
                    return true;
                else
                    return false;
            }

            public bool UpdatedCalendar()
            {
                DateTime dtYesterday = DateTime.Now.AddDays(-1);
                DateTime dtSeasonStart = TmWeek.GetDateTimeOfSeasonStart(TmWeek.GetSeason(DateTime.Now));

                ChampDS.MatchRow[] mrows = null;

                try
                {
                    string str = "(isReserves = 0) AND (Date > #" + dtSeasonStart.ToString(CommGlobal.ciUs) + "#)";
                    mrows = (ChampDS.MatchRow[])this.Select(str);
                }
                catch (Exception ex)
                {
                }

                if (mrows.Length > 33)
                    return true;
                else
                    return false;
            }

            public int Updated()
            {
                DateTime dtYesterday = DateTime.Now.AddDays(-1);
                DateTime dtSeasonStart = TmWeek.GetDateTimeOfSeasonStart(TmWeek.GetSeason(DateTime.Now));

                ChampDS.MatchRow[] mrows = null;

                try
                {
                    string str = "(isReserves = 0) AND (Date < #" + dtYesterday.ToString(CommGlobal.ciUs) + "#) AND (Date > #" + dtSeasonStart.ToString(CommGlobal.ciUs) + "#)";
                    mrows = (ChampDS.MatchRow[])this.Select(str);
                }
                catch (Exception ex)
                {
                }

                int count = 0;
                foreach (ChampDS.MatchRow mrow in mrows)
                {
                    if (!mrow.Report)
                    {
                        count++;
                    }
                }

                return count;
            }

            public int UpdatedReserves()
            {
                DateTime dtYesterday = DateTime.Now.AddDays(-1);
                DateTime dtSeasonStart = TmWeek.GetDateTimeOfSeasonStart(TmWeek.GetSeason(DateTime.Now));

                ChampDS.MatchRow[] mrows = null;

                try
                {
                    string str = "(isReserves = 1) AND (Date < #" + dtYesterday.ToString(CommGlobal.ciUs) + "#) AND (Date > #" + dtSeasonStart.ToString(CommGlobal.ciUs) + "#)";
                    mrows = (ChampDS.MatchRow[])this.Select(str);
                }
                catch (Exception ex)
                {
                }

                int count = 0;
                foreach (ChampDS.MatchRow mrow in mrows)
                {
                    if (!mrow.Report)
                    {
                        count++;
                    }
                }

                return count;
            }

            public int GetFirstMatchToUpdate()
            {
                DateTime dtNow = DateTime.Now;
                DateTime dtSeasonStart = TmWeek.GetDateTimeOfSeasonStart(TmWeek.GetSeason(DateTime.Now));

                ChampDS.MatchRow[] mrows = null;

                try
                {
                    string str = "(isReserves = 0) AND (Date < #" + dtNow.ToString(CommGlobal.ciUs) + "#) AND (Date >= #" + dtSeasonStart.ToString(CommGlobal.ciUs) + "#)";
                    mrows = (ChampDS.MatchRow[])this.Select(str);
                }
                catch (Exception ex)
                {
                }

                foreach (ChampDS.MatchRow mrow in mrows)
                {
                    if (!mrow.Report)
                    {
                        return mrow.MatchID;
                    }
                }

                if (mrows.Length > 0)
                {
                    return mrows[mrows.Length - 1].MatchID;
                }

                return -1;
            }

            public int GetFirstMatchToUpdateReserves()
            {
                DateTime dtNow = DateTime.Now;
                DateTime dtSeasonStart = TmWeek.GetDateTimeOfSeasonStart(TmWeek.GetSeason(DateTime.Now));

                ChampDS.MatchRow[] mrows = null;

                try
                {
                    string str = "(isReserves = 1) AND (Date < #" + dtNow.ToString(CommGlobal.ciUs) + "#) AND (Date >= #" + dtSeasonStart.ToString(CommGlobal.ciUs) + "#)";
                    mrows = (ChampDS.MatchRow[])this.Select(str);
                }
                catch (Exception ex)
                {
                }

                foreach (ChampDS.MatchRow mrow in mrows)
                {
                    if (!mrow.Report)
                    {
                        return mrow.MatchID;
                    }
                }

                if (mrows.Length > 0)
                {
                    return mrows[mrows.Length - 1].MatchID;
                }

                return -1;
            }
        }
    }
}
