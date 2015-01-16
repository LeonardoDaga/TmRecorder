using Common;
using Languages;
using NTR_Common;
using SendFileTo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTR_Db
{
    public enum ContentType
    {
        Squad,
        Training,
    }

    public class Content
    {
        public int TeamID;

        public string ClubName { get; set; }

        public string DocText { get; set; }

        public int MainSquadID { get; set; }

        public int ReserveSquadID { get; set; }

        public NTR_SquadDb squadDB { get; set; }

        public int Week { get; set; }

        public void ParsePage(string page, string address)
        {
            if (page.Contains("http://trophymanager.com/players/"))
            {
                string[] stringSeparators = new string[] { "\n\r\n" };
                string[] pages = page.Split(stringSeparators, StringSplitOptions.None);

                if (pages.Length < 2)
                {
                    string swRelease = "Sw Release:" + Application.ProductName + "(" + Application.ProductVersion + ")";
                    page = "Navigation Address: " + address + "\n" + page;

                    string message = "Error retrieving data from the players page";
                    SendFileTo.ErrorReport.SendPage(message, page, Environment.StackTrace, swRelease);
                }
                else
                {
                    // Get the actual week
                    this.Week = TmWeek.thisWeek().absweek;

                    LoadSquad(pages[0]);
                    LoadTraining(pages[1]);
                }
            }
        }

        private void LoadSquad(string squad)
        {
            string originalSquadString = squad;
            short isReserves = 0;
            int player = 0;

            try
            {
                {
                    int Id = 0;

                    int.TryParse(HTML_Parser.GetNumberAfter(originalSquadString, "A_team="), out Id);
                    MainSquadID = Id;

                    int.TryParse(HTML_Parser.GetNumberAfter(originalSquadString, "B_team="), out Id);
                    ReserveSquadID = Id;
                }

                // squad = HTML_Parser.ConvertHTML_Text(squad);
                squad = HTML_Parser.ConvertUnicodes_Text(squad);
                squad = HTML_Parser.ConvertUnicodes_MoreText(squad);

                string[] plRows = squad.Split('\n');

                // Row 0 is the table header
                for (player = 0; player < plRows.Length; player++)
                {
                    if (!plRows[player].Contains("id=")) continue;

                    string strPlayer = plRows[player].Trim(';');

                    ParsePlayer(strPlayer);
                }
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";

                string info = "";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(Application.LocalUserAppDataPath, filename);
                FileInfo fi = new FileInfo(pathfilename);

                squadDB.WriteXml(fi.FullName);

                StreamReader file = new StreamReader(fi.FullName);
                info += "SquadDB:\r\n" + file.ReadToEnd();
                file.Close();

                info += "isReserves:" + isReserves.ToString();
                info += "player:" + player.ToString();
                info += "Squad:" + originalSquadString;

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                MessageBox.Show(Current.Language.SorryTheImportingProcessHasFailedIfYouClickedOkTheInfoOfTheErrorHave +
                    Current.Language.BeenSentToLedLennonThatWillRemoveThisBugAsSoonAsPossible);
            }
        }

        private void LoadTraining(string page)
        {
            string[] playersTr = page.Split('\n');

            if (playersTr.Length == 0)
            {
                MessageBox.Show("Cannot import training", "Content/LoadTraining Function Error", MessageBoxButtons.OK);
                return;
            }

            foreach (string playerTr in playersTr)
            {
                Dictionary<string, string> data = TM_Parser.CreateDictionary_NewTm(playerTr);

                if (data.Count == 0) continue;

                // Row 0 is the table header
                int playerID = int.Parse(data["player"]);

                NTR_SquadDb.HistDataRow histRow = squadDB.HistData.FindByPlayerIDWeek(playerID, this.Week);
                if (histRow == null)
                {
                    // But the history row should already exist
                    histRow = squadDB.HistData.NewHistDataRow();
                    histRow.PlayerID = playerID;
                    histRow.Week = this.Week;
                    squadDB.HistData.AddHistDataRow(histRow);
                }

                int TI = int.Parse(data["ti"]);

                bool isGK = (histRow.PlayerRow.FPn == 0);
                UInt64 trCode = Tm_Training.TrainingDataToTrCode2(data, isGK);

                histRow.Training = trCode;
                histRow._TI = TI;
            }
        }

        public void ParsePlayer(string strPlayer)
        {
            // Creates the DB where to put the results, in case it's not already created
            if (squadDB == null)
                squadDB = new NTR_SquadDb();

            strPlayer = strPlayer.Replace("{", "");
            Dictionary<string, string> data = TM_Parser.CreateDictionary_NewTm(strPlayer);

            // Find the player in the DB
            int playerID = int.Parse(data["id"]);
            NTR_SquadDb.PlayerRow playerRow = squadDB.Player.FindByPlayerID(playerID);
            if (playerRow == null)
            {
                playerRow = squadDB.Player.NewPlayerRow();
                playerRow.PlayerID = playerID;
                squadDB.Player.AddPlayerRow(playerRow);
            }            

            NTR_SquadDb.HistDataRow histRow = squadDB.HistData.FindByPlayerIDWeek(playerID, this.Week);
            if (histRow == null)
            {
                histRow = squadDB.HistData.NewHistDataRow();
                histRow.PlayerID = playerID;
                histRow.Week = this.Week;
                squadDB.HistData.AddHistDataRow(histRow);
            }

            NTR_SquadDb.TempDataRow tempRow = squadDB.TempData.FindByPlayerID(playerID);
            if (tempRow == null)
            {
                tempRow = squadDB.TempData.NewTempDataRow();
                tempRow.PlayerID = playerID;
                squadDB.TempData.AddTempDataRow(tempRow);
            }

            histRow.Inj = 0;
            histRow.Ban = 0;

            // Row0: Numero
            playerRow.No = int.Parse(data["no"]);

            if (data["inj"] != "null")
                histRow.Inj = short.Parse(data["inj"]);
            histRow.Ban = short.Parse(data["ban_points"]);

            playerRow.Name = data["name"].Replace("  ", " ");
            playerRow.Nationality = data["country"];
            playerRow.wBorn = TmWeek.GetBornWeekFromAgeString(data["age"]);
            playerRow.FP = TM_Compatible.ConvertNewFP(data["fp"]);
            playerRow.FPn = Tm_Utility.FPToNumber(playerRow.FP);

            if (playerRow.FPn > 0)
            {
                histRow.For = int.Parse(data["str"]);
                histRow.Res = int.Parse(data["sta"]);
                histRow.Vel = int.Parse(data["pac"]);

                histRow.Mar = int.Parse(data["mar"]);
                histRow.Con = int.Parse(data["tac"]);
                histRow.Wor = int.Parse(data["wor"]);
                histRow.Pos = int.Parse(data["pos"]);
                histRow.Pas = int.Parse(data["pas"]);
                histRow.Cro = int.Parse(data["cro"]);
                histRow.Tec = int.Parse(data["tec"]);
                histRow.Tes = int.Parse(data["hea"]);
                histRow.Fin = int.Parse(data["fin"]);
                histRow.Dis = int.Parse(data["lon"]);
                histRow.Cal = int.Parse(data["set"]);
            }
            else
            {
                histRow.For = int.Parse(data["str"]);
                histRow.Res = int.Parse(data["sta"]);
                histRow.Vel = int.Parse(data["pac"]);

                histRow.Pre = int.Parse(data["han"]);
                histRow.Uno = int.Parse(data["one"]);
                histRow.Rif = int.Parse(data["ref"]);
                histRow.Aer = int.Parse(data["ari"]);
                histRow.Ele = int.Parse(data["jum"]);
                histRow.Com = int.Parse(data["com"]);
                histRow.Tir = int.Parse(data["kic"]);
                histRow.Lan = int.Parse(data["thr"]);
            }

            histRow.ASI = int.Parse(data["asi"]);

            tempRow.Rou = decimal.Parse(data["routine"], Common.CommGlobal.ciUs);

            
        }
    }
}
