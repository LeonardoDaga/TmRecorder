using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.IO;

namespace TMRecorder
{
    class DebugClass
    {

        public static void TestLoadClearPlayerData()
        {
            List<Dictionary<string, string>> listPlayers = new List<Dictionary<string, string>>();

            DirectoryInfo di = new DirectoryInfo(@"H:\Dev2008\TmRecorder\TMRecorder\Documentazione\MatlabDataLoad");

            StreamReader file = new StreamReader(Path.Combine(di.FullName, "clear_data.txt"));
            string playerpage = file.ReadToEnd();

            string[] lines = playerpage.Split('\n');

            Dictionary<string, string> player = null;
            for (int i = 0; i<lines.Length; i++)
            {
                string line = lines[i];

                string[] items = line.Split(':');
                if (items.Length < 2) continue;
                string item = items[0];
                string value = items[1].Trim().Trim('"');


                int id = 0;                

                if (item == "age")
                {
                    // Create new player
                    player = new Dictionary<string, string>();
                    listPlayers.Add(player);

                    player[item] = value;
                }
                else
                {
                    if (player == null) continue;
                    // add a value to the player
                    if (!player.ContainsKey(item))
                    {
                        player[item] = value;
                    }
                }
            }

            StreamWriter wrfile = new StreamWriter(Path.Combine(di.FullName, "player_out_data.txt"));
            foreach (Dictionary<string, string> pl in listPlayers)
            {
                if (pl["fp"] == "GK") continue;

                string strPlayer = pl["id"] + "\t";
                strPlayer += pl["strength"] + "\t";
                strPlayer += pl["stamina"] + "\t";
                strPlayer += pl["pace"] + "\t";
                strPlayer += pl["marking"] + "\t";
                strPlayer += pl["tackling"] + "\t";
                strPlayer += pl["workrate"] + "\t";
                strPlayer += pl["positioning"] + "\t";
                strPlayer += pl["passing"] + "\t";
                strPlayer += pl["crossing"] + "\t";
                strPlayer += pl["technique"] + "\t";
                strPlayer += pl["heading"] + "\t";
                strPlayer += pl["finishing"] + "\t";
                strPlayer += pl["longshots"] + "\t";
                strPlayer += pl["setpieces"] + "\t";
                strPlayer += pl["rutine"] + "\t";
                strPlayer += pl["asi"] + "\t";
                strPlayer += pl["rec"] + "\t";
                strPlayer += pl["rec_count"] + "\t";
                strPlayer += pl["training"] + "\t";

                wrfile.WriteLine(strPlayer);
            }
            wrfile.Close();

            wrfile = new StreamWriter(Path.Combine(di.FullName, "player_dc_data.txt"));
            foreach (Dictionary<string, string> pl in listPlayers)
            {
                if (pl["fp"] != "D C") continue;

                string strPlayer = pl["id"] + "\t";
                strPlayer += pl["strength"] + "\t";
                strPlayer += pl["stamina"] + "\t";
                strPlayer += pl["pace"] + "\t";
                strPlayer += pl["marking"] + "\t";
                strPlayer += pl["tackling"] + "\t";
                strPlayer += pl["workrate"] + "\t";
                strPlayer += pl["positioning"] + "\t";
                strPlayer += pl["passing"] + "\t";
                strPlayer += pl["crossing"] + "\t";
                strPlayer += pl["technique"] + "\t";
                strPlayer += pl["heading"] + "\t";
                strPlayer += pl["finishing"] + "\t";
                strPlayer += pl["longshots"] + "\t";
                strPlayer += pl["setpieces"] + "\t";
                strPlayer += pl["rutine"] + "\t";
                strPlayer += pl["asi"] + "\t";
                strPlayer += pl["rec"] + "\t";
                strPlayer += pl["rec_count"] + "\t";
                strPlayer += pl["training"] + "\t";

                wrfile.WriteLine(strPlayer);
            }
            wrfile.Close();

            wrfile = new StreamWriter(Path.Combine(di.FullName, "player_de_data.txt"));
            foreach (Dictionary<string, string> pl in listPlayers)
            {
                if ((pl["fp"] != "D L") && (pl["fp"] != "D R")) continue;

                string strPlayer = pl["id"] + "\t";
                strPlayer += pl["strength"] + "\t";
                strPlayer += pl["stamina"] + "\t";
                strPlayer += pl["pace"] + "\t";
                strPlayer += pl["marking"] + "\t";
                strPlayer += pl["tackling"] + "\t";
                strPlayer += pl["workrate"] + "\t";
                strPlayer += pl["positioning"] + "\t";
                strPlayer += pl["passing"] + "\t";
                strPlayer += pl["crossing"] + "\t";
                strPlayer += pl["technique"] + "\t";
                strPlayer += pl["heading"] + "\t";
                strPlayer += pl["finishing"] + "\t";
                strPlayer += pl["longshots"] + "\t";
                strPlayer += pl["setpieces"] + "\t";
                strPlayer += pl["rutine"] + "\t";
                strPlayer += pl["asi"] + "\t";
                strPlayer += pl["rec"] + "\t";
                strPlayer += pl["rec_count"] + "\t";
                strPlayer += pl["training"] + "\t";

                wrfile.WriteLine(strPlayer);
            }
            wrfile.Close();

            //---------------------------------------------------------------

            wrfile = new StreamWriter(Path.Combine(di.FullName, "player_dmc_data.txt"));
            foreach (Dictionary<string, string> pl in listPlayers)
            {
                if (pl["fp"] != "DM C") continue;

                string strPlayer = pl["id"] + "\t";
                strPlayer += pl["strength"] + "\t";
                strPlayer += pl["stamina"] + "\t";
                strPlayer += pl["pace"] + "\t";
                strPlayer += pl["marking"] + "\t";
                strPlayer += pl["tackling"] + "\t";
                strPlayer += pl["workrate"] + "\t";
                strPlayer += pl["positioning"] + "\t";
                strPlayer += pl["passing"] + "\t";
                strPlayer += pl["crossing"] + "\t";
                strPlayer += pl["technique"] + "\t";
                strPlayer += pl["heading"] + "\t";
                strPlayer += pl["finishing"] + "\t";
                strPlayer += pl["longshots"] + "\t";
                strPlayer += pl["setpieces"] + "\t";
                strPlayer += pl["rutine"] + "\t";
                strPlayer += pl["asi"] + "\t";
                strPlayer += pl["rec"] + "\t";
                strPlayer += pl["rec_count"] + "\t";
                strPlayer += pl["training"] + "\t";

                wrfile.WriteLine(strPlayer);
            }
            wrfile.Close();

            //---------------------------------------------------------------

            wrfile = new StreamWriter(Path.Combine(di.FullName, "player_dml_data.txt"));
            foreach (Dictionary<string, string> pl in listPlayers)
            {
                if ((pl["fp"] != "DM L") && (pl["fp"] != "DM R")) continue;

                string strPlayer = pl["id"] + "\t";
                strPlayer += pl["strength"] + "\t";
                strPlayer += pl["stamina"] + "\t";
                strPlayer += pl["pace"] + "\t";
                strPlayer += pl["marking"] + "\t";
                strPlayer += pl["tackling"] + "\t";
                strPlayer += pl["workrate"] + "\t";
                strPlayer += pl["positioning"] + "\t";
                strPlayer += pl["passing"] + "\t";
                strPlayer += pl["crossing"] + "\t";
                strPlayer += pl["technique"] + "\t";
                strPlayer += pl["heading"] + "\t";
                strPlayer += pl["finishing"] + "\t";
                strPlayer += pl["longshots"] + "\t";
                strPlayer += pl["setpieces"] + "\t";
                strPlayer += pl["rutine"] + "\t";
                strPlayer += pl["asi"] + "\t";
                strPlayer += pl["rec"] + "\t";
                strPlayer += pl["rec_count"] + "\t";
                strPlayer += pl["training"] + "\t";

                wrfile.WriteLine(strPlayer);
            }
            wrfile.Close();

            //---------------------------------------------------------------

            wrfile = new StreamWriter(Path.Combine(di.FullName, "player_mc_data.txt"));
            foreach (Dictionary<string, string> pl in listPlayers)
            {
                if (pl["fp"] != "M C") continue;

                string strPlayer = pl["id"] + "\t";
                strPlayer += pl["strength"] + "\t";
                strPlayer += pl["stamina"] + "\t";
                strPlayer += pl["pace"] + "\t";
                strPlayer += pl["marking"] + "\t";
                strPlayer += pl["tackling"] + "\t";
                strPlayer += pl["workrate"] + "\t";
                strPlayer += pl["positioning"] + "\t";
                strPlayer += pl["passing"] + "\t";
                strPlayer += pl["crossing"] + "\t";
                strPlayer += pl["technique"] + "\t";
                strPlayer += pl["heading"] + "\t";
                strPlayer += pl["finishing"] + "\t";
                strPlayer += pl["longshots"] + "\t";
                strPlayer += pl["setpieces"] + "\t";
                strPlayer += pl["rutine"] + "\t";
                strPlayer += pl["asi"] + "\t";
                strPlayer += pl["rec"] + "\t";
                strPlayer += pl["rec_count"] + "\t";
                strPlayer += pl["training"] + "\t";

                wrfile.WriteLine(strPlayer);
            }
            wrfile.Close();

            //---------------------------------------------------------------

            wrfile = new StreamWriter(Path.Combine(di.FullName, "player_ml_data.txt"));
            foreach (Dictionary<string, string> pl in listPlayers)
            {
                if ((pl["fp"] != "M L") && (pl["fp"] != "M R")) continue;

                string strPlayer = pl["id"] + "\t";
                strPlayer += pl["strength"] + "\t";
                strPlayer += pl["stamina"] + "\t";
                strPlayer += pl["pace"] + "\t";
                strPlayer += pl["marking"] + "\t";
                strPlayer += pl["tackling"] + "\t";
                strPlayer += pl["workrate"] + "\t";
                strPlayer += pl["positioning"] + "\t";
                strPlayer += pl["passing"] + "\t";
                strPlayer += pl["crossing"] + "\t";
                strPlayer += pl["technique"] + "\t";
                strPlayer += pl["heading"] + "\t";
                strPlayer += pl["finishing"] + "\t";
                strPlayer += pl["longshots"] + "\t";
                strPlayer += pl["setpieces"] + "\t";
                strPlayer += pl["rutine"] + "\t";
                strPlayer += pl["asi"] + "\t";
                strPlayer += pl["rec"] + "\t";
                strPlayer += pl["rec_count"] + "\t";
                strPlayer += pl["training"] + "\t";

                wrfile.WriteLine(strPlayer);
            }
            wrfile.Close();

            //---------------------------------------------------------------

            wrfile = new StreamWriter(Path.Combine(di.FullName, "player_omc_data.txt"));
            foreach (Dictionary<string, string> pl in listPlayers)
            {
                if (pl["fp"] != "OM C") continue;

                string strPlayer = pl["id"] + "\t";
                strPlayer += pl["strength"] + "\t";
                strPlayer += pl["stamina"] + "\t";
                strPlayer += pl["pace"] + "\t";
                strPlayer += pl["marking"] + "\t";
                strPlayer += pl["tackling"] + "\t";
                strPlayer += pl["workrate"] + "\t";
                strPlayer += pl["positioning"] + "\t";
                strPlayer += pl["passing"] + "\t";
                strPlayer += pl["crossing"] + "\t";
                strPlayer += pl["technique"] + "\t";
                strPlayer += pl["heading"] + "\t";
                strPlayer += pl["finishing"] + "\t";
                strPlayer += pl["longshots"] + "\t";
                strPlayer += pl["setpieces"] + "\t";
                strPlayer += pl["rutine"] + "\t";
                strPlayer += pl["asi"] + "\t";
                strPlayer += pl["rec"] + "\t";
                strPlayer += pl["rec_count"] + "\t";
                strPlayer += pl["training"] + "\t";

                wrfile.WriteLine(strPlayer);
            }
            wrfile.Close();

            //---------------------------------------------------------------

            wrfile = new StreamWriter(Path.Combine(di.FullName, "player_oml_data.txt"));
            foreach (Dictionary<string, string> pl in listPlayers)
            {
                if ((pl["fp"] != "OM L") && (pl["fp"] != "OM R")) continue;

                string strPlayer = pl["id"] + "\t";
                strPlayer += pl["strength"] + "\t";
                strPlayer += pl["stamina"] + "\t";
                strPlayer += pl["pace"] + "\t";
                strPlayer += pl["marking"] + "\t";
                strPlayer += pl["tackling"] + "\t";
                strPlayer += pl["workrate"] + "\t";
                strPlayer += pl["positioning"] + "\t";
                strPlayer += pl["passing"] + "\t";
                strPlayer += pl["crossing"] + "\t";
                strPlayer += pl["technique"] + "\t";
                strPlayer += pl["heading"] + "\t";
                strPlayer += pl["finishing"] + "\t";
                strPlayer += pl["longshots"] + "\t";
                strPlayer += pl["setpieces"] + "\t";
                strPlayer += pl["rutine"] + "\t";
                strPlayer += pl["asi"] + "\t";
                strPlayer += pl["rec"] + "\t";
                strPlayer += pl["rec_count"] + "\t";
                strPlayer += pl["training"] + "\t";

                wrfile.WriteLine(strPlayer);
            }
            wrfile.Close();

            //---------------------------------------------------------------

            wrfile = new StreamWriter(Path.Combine(di.FullName, "player_fc_data.txt"));
            foreach (Dictionary<string, string> pl in listPlayers)
            {
                if (pl["fp"] != "F") continue;

                string strPlayer = pl["id"] + "\t";
                strPlayer += pl["strength"] + "\t";
                strPlayer += pl["stamina"] + "\t";
                strPlayer += pl["pace"] + "\t";
                strPlayer += pl["marking"] + "\t";
                strPlayer += pl["tackling"] + "\t";
                strPlayer += pl["workrate"] + "\t";
                strPlayer += pl["positioning"] + "\t";
                strPlayer += pl["passing"] + "\t";
                strPlayer += pl["crossing"] + "\t";
                strPlayer += pl["technique"] + "\t";
                strPlayer += pl["heading"] + "\t";
                strPlayer += pl["finishing"] + "\t";
                strPlayer += pl["longshots"] + "\t";
                strPlayer += pl["setpieces"] + "\t";
                strPlayer += pl["rutine"] + "\t";
                strPlayer += pl["asi"] + "\t";
                strPlayer += pl["rec"] + "\t";
                strPlayer += pl["rec_count"] + "\t";
                strPlayer += pl["training"] + "\t";

                wrfile.WriteLine(strPlayer);
            }
            wrfile.Close();

            //---------------------------------------------------------------

            wrfile = new StreamWriter(Path.Combine(di.FullName, "gk_out_data.txt"));
            foreach (Dictionary<string, string> gk in listPlayers)
            {
                if (gk["fp"] != "GK") continue;

                string strPlayer = gk["id"] + "\t";
                strPlayer += gk["strength"] + "\t";
                strPlayer += gk["stamina"] + "\t";
                strPlayer += gk["pace"] + "\t";

                strPlayer += gk["handling"] + "\t";
                strPlayer += gk["oneonones"] + "\t";
                strPlayer += gk["reflexes"] + "\t";
                strPlayer += gk["arialability"] + "\t";
                strPlayer += gk["jumping"] + "\t";
                strPlayer += gk["communication"] + "\t";
                strPlayer += gk["kicking"] + "\t";
                strPlayer += gk["throwing"] + "\t";
                
                strPlayer += gk["rutine"] + "\t";
                strPlayer += gk["asi"] + "\t";
                strPlayer += gk["rec"] + "\t";
                strPlayer += gk["rec_count"] + "\t";
                strPlayer += gk["training"] + "\t";

                wrfile.WriteLine(strPlayer);
            }
            wrfile.Close();
        }

        public static void TestLoadMatch()
        {
            MatchDS matchDS = new MatchDS();

            ChampDS champDS = new ChampDS();
            champDS.Match.ReadXml("C:\\Temp\\ChampsDS.xml");

            StreamReader file = new StreamReader("C:\\Temp\\Match.xml");
            string playerpage = file.ReadToEnd();
            file.Close();

            ChampDS.MatchRow mr = champDS.Match.FindByMatchID(25895003);
            matchDS.Analyze_NewTM(playerpage, ref mr);
        }

        public static void Test2()
        {
            ExtTMDataSet eds = new ExtTMDataSet();

            ExtraDS PlayersDS = new ExtraDS();
            PlayersDS.ReadXml(@"C:\Temp\PlayersDS.xml");

            DB_TrophyDataSet2 tds = new DB_TrophyDataSet2();
            tds.ReadXml(@"C:\Temp\TDS.xml");

            Gain_Function PFun = new RusCheratte_Function();
            PFun.gds = new GainDS();
            PFun.gds.SetDefaultValues();

            Program.Setts.Initialize();
            Program.Setts.Load();

            eds.FillWithDb_TrophyDataSet2(PlayersDS, tds, PFun, Program.Setts.ApplicationFolder);
        }

        public static void Test3()
        {
            StreamReader file = new StreamReader("C:\\Documents and Settings\\Leo\\Documenti\\Download\\pastefile1941.tmreport.txt");
            string page = file.ReadToEnd();
            file.Close();

            Program.Setts.Initialize();

            Db_TrophyDataSet db_TrophyDataSet = new Db_TrophyDataSet();

            List<string> plRows = HTML_Parser.GetFields(page, "{", "}");

            // Row 0 is the table header
            for (int player = 0; player < plRows.Count; player++)
            {
                if (plRows[player].Contains("GK"))
                {
                    Db_TrophyDataSet.PortieriRow row = (Db_TrophyDataSet.PortieriRow)db_TrophyDataSet.Portieri.NewRow();

                    TM_Parser.ParseGK_New(ref row, plRows[player]);

                    if (row != null)
                        db_TrophyDataSet.Portieri.AddPortieriRow(row);
                }
                else
                {
                    Db_TrophyDataSet.GiocatoriRow row = (Db_TrophyDataSet.GiocatoriRow)db_TrophyDataSet.Giocatori.NewRow();

                    TM_Parser.ParsePlayer_New(ref row, plRows[player]);

                    db_TrophyDataSet.Giocatori.AddGiocatoriRow(row);
                }
            }
        }

        public static void LoadTrainingNew()
        {
            DateTime dt = DateTime.Now;
            TrainersSkills ts = new TrainersSkills();
            ts.ReadXml(@"C:\Temp\TrainersSkills.xml");

            Program.Setts.Initialize();
            TeamHistory History = new TeamHistory();
            History.PlayersDS = new ExtraDS();
            History.PlayersDS.ReadXml(@"C:\Temp\PlayersDS.xml");

            StreamReader file = new StreamReader(@"C:\Temp\TM - Training_new.html");
            string page = file.ReadToEnd();
            file.Close();

            History.LoadTrainingNew(dt, page, ts);
        }

        public static void Test5()
        {
            DateTime dt = DateTime.Now;
            Program.Setts.Initialize();
            TeamHistory History = new TeamHistory();

            StreamReader file = new StreamReader(@"C:\Temp\LoadTIfromTrainingNew.txt");
            string page = file.ReadToEnd();
            file.Close();

            History.PlayersDS = new ExtraDS();

            History.LoadTIfromTrainingNew(dt, page);
        }

        public static void TestLoadSquad()
        {
            Program.Setts.Initialize();
            TeamHistory History = new TeamHistory();

            History.PlayersDS = new ExtraDS();
            History.PlayersDS.ReadXml(@"C:\Temp\PlayersDS.xml");

            DB_TrophyDataSet2 tds = new DB_TrophyDataSet2();
            tds.ReadXml(@"C:\Temp\TDS.xml");

            StreamReader file = new StreamReader(@"C:\Temp\Squad.txt");
            string page = file.ReadToEnd();
            file.Close();

            string[] args = new string[0];
            MainForm form = new MainForm(args);

            History.LoadSquad_NewTm(DateTime.Now, page);        
        }

        public static void TestFillPLTrainingTable()
        {
            Program.Setts.Initialize();
            TeamHistory History = new TeamHistory();
            History.PlayersDS = new ExtraDS();
            History.PlayersDS.ReadXml(@"C:\Temp\PlayersDS.xml");

            ExtTMDataSet eds = new ExtTMDataSet();
            eds.ReadXml(@"C:\temp\this_ix.txt");
            History.Add(eds);

            TrainingDataSet tdsin = new TrainingDataSet();
            tdsin.ReadXml(@"C:\temp\trainingDataSet.xml");

            History.dbTrainers = new TrainersSkills();
            History.dbTrainers.ReadXml(@"C:\temp\dbTrainers.xml");

            History.TrainingHist.Add(tdsin);

            History.FillPLTrainingTable(new PlayerTraining(), 55762883);
        }

        public static void TestLoadSquadShort()
        {
            Program.Setts.Initialize();
            TeamHistory History = new TeamHistory();

            History.PlayersDS = new ExtraDS();
            History.PlayersDS.ReadXml(@"H:\Documents\TmRecorder.debug\PlayersDS.xml");

            DB_TrophyDataSet2 tds = new DB_TrophyDataSet2();
            tds.ReadXml(@"H:\Documents\TmRecorder.debug\TDS.xml");

            //StreamReader file = new StreamReader(@"C:\Temp\Squad.txt");
            //string page = file.ReadToEnd();
            //file.Close();

            //string[] args = new string[0];
            //MainForm form = new MainForm(args);

            //History.LoadSquad_NewTm(DateTime.Now, page);
        }
    }
}
