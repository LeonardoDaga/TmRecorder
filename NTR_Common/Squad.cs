using System;
using System.Collections.Generic;
using System.Text;
using Common;
using System.IO;

namespace NTR_Common
{
    public class AlarmInfo
    {
        public DateTime Ends;
        public DateTime AlarmTime;
        public bool Alarm;
        public int Bid;
    }

    public class TSquad : Dictionary<int, PlayersDS>
    {
        internal int ParsePlayer2(DateTime dt, string plRow, string HomeNation, ref AlarmInfo ai)
        {
            bool isNew = false;

            Dictionary<string, string> data = TM_Parser.CreateDictionary_NewTm(plRow);

            int ID = int.Parse(data["id"]);

            if (!this.ContainsKey(ID))
            {
                this.Add(ID, new PlayersDS());
                isNew = true;
                PlayersDS.FixDataRow fdr0 = this[ID].FixData.NewFixDataRow();
                fdr0.PlayerID = ID;
                this[ID].FixData.AddFixDataRow(fdr0);
            }

            PlayersDS plDS = this[ID];
            if (plDS.FixData.Count == 0)
            {
                isNew = true;
                PlayersDS.FixDataRow fdr0 = this[ID].FixData.NewFixDataRow();
                fdr0.PlayerID = ID;
                this[ID].FixData.AddFixDataRow(fdr0);
            }

            PlayersDS.FixDataRow fdr = plDS.FixData[0];

            // Verifica innanzitutto nei fix data
            if (isNew)
            {
                // Crea un nuovo giocatore
                string nome = data["name"].Replace("  ", " ");
                fdr.Nome = nome;

                if (data["country"] == "")
                    fdr.Nationality = HomeNation;
                else
                    fdr.Nationality = data["country"];

                // Row4: Posizione preferita
                fdr.FP = data["fp"];
                fdr.FP = TM_Compatible.ConvertNewFP(fdr.FP);
                fdr.FPn = Tm_Utility.FPToNumber(fdr.FP);
            }

            // Row0: Numero
            fdr.Numero = 0;

            if (data.ContainsKey("club"))
                fdr.TeamID = data["club"];
            else
                fdr.TeamID = data["club_id"];

            // Row3: Età
            int age = int.Parse(data["age"]);
            int wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, 0, age);
            if (fdr.IswBornNull() || (fdr.wBorn == -9999))
                fdr.wBorn = wBorn;
            else if (wBorn < fdr.wBorn)
                fdr.wBorn = wBorn;

            // Verifica innanzitutto nei fix data
            PlayersDS.VarDataRow vdr;
            int week = TmWeek.GetTmAbsWk(dt);

            if ((vdr = plDS.VarData.FindByWeek(week)) == null)
            {
                // Crea un nuovo set di dati
                vdr = plDS.VarData.NewVarDataRow();
                vdr.Week = week;
                plDS.VarData.AddVarDataRow(vdr);
            }

            // Row5: Forma
            vdr.For = int.Parse(data["str"]);

            // Row6: Resistenza
            vdr.Res = int.Parse(data["sta"]);

            // Row7: Velocità
            vdr.Vel = int.Parse(data["pac"]);

            // Row8: Marcatura
            if (fdr.FPn != 0) // it's not a gk
                vdr.Mar = int.Parse(data["mar"]);
            else
                vdr.Mar = int.Parse(data["han"]);

            // Row9: Contrasto
            if (fdr.FPn != 0) // it's not a gk
                vdr.Con = int.Parse(data["tac"]);
            else
                vdr.Con = int.Parse(data["one"]);

            // Row10: Impegno
            if (fdr.FPn != 0) // it's not a gk
                vdr.Wor = int.Parse(data["wor"]);
            else
                vdr.Wor = int.Parse(data["ref"]);

            // Row11: Posizioni
            if (fdr.FPn != 0) // it's not a gk
                vdr.Pos = int.Parse(data["pos"]);
            else
                vdr.Pos = int.Parse(data["ari"]);

            // Row12: Passaggi
            if (fdr.FPn != 0) // it's not a gk
                vdr.Pas = int.Parse(data["pas"]);
            else
                vdr.Pas = int.Parse(data["jum"]);

            // Row13: Cross
            if (fdr.FPn != 0) // it's not a gk
                vdr.Cro = int.Parse(data["cro"]);
            else
                vdr.Cro = int.Parse(data["com"]);

            // Row14: Tecnica
            if (fdr.FPn != 0) // it's not a gk
                vdr.Tec = int.Parse(data["tec"]);
            else
                vdr.Tec = int.Parse(data["kic"]);

            // Row15: Colpo di testa
            if (fdr.FPn != 0) // it's not a gk
                vdr.Tes = int.Parse(data["hea"]);
            else
                vdr.Tes = int.Parse(data["thr"]);

            // Row16: Finalizzazione
            if (fdr.FPn != 0) // it's not a gk
                vdr.Fin = int.Parse(data["fin"]);

            // Row17: Tiro dalla distanza
            if (fdr.FPn != 0) // it's not a gk
                vdr.Dis = int.Parse(data["lon"]);

            // Row18: Calci di punizioni
            if (fdr.FPn != 0) // it's not a gk
                vdr.Cal = int.Parse(data["set"]);

            // Row19: ASI
            vdr.ASI = int.Parse(data["asi"]);

            fdr.Rou = decimal.Parse(data["routine"], Common.CommGlobal.ciUs);

            fdr.Rec = decimal.Parse(data["rec"]) / 2.0M;

            int remainingTime = 0;
            if (data["timeleft"] != "")
                remainingTime = int.Parse(data["timeleft"]);

            if (remainingTime > 0)
            {
                DateTime dtNow = DateTime.Now;
                ai.Ends = dtNow.AddSeconds(remainingTime);
                ai.Bid = int.Parse(data["curbid"].Replace(",", ""));
            }

            return ID;
        }

        internal int ParsePlayer(DateTime dt, string plRow, string HomeNation, ref AlarmInfo ai)
        {
            bool isNew = false;

            if (!plRow.Contains("playerid="))
            {
                return -1;
            }

            plRow = plRow.Replace("&amp;", "&");
            List<string> plCells = HTML_Parser.GetTags(plRow, "TD");

            string playerIdStr = HTML_Parser.GetNumberAfter(plCells[0], "playerid=");

            int ID;
            if (!int.TryParse(playerIdStr, out ID))
                return -1;

            if (!this.ContainsKey(ID))
            {
                this.Add(ID, new PlayersDS());
                isNew = true;
                PlayersDS.FixDataRow fdr0 = this[ID].FixData.NewFixDataRow();
                fdr0.PlayerID = ID;
                this[ID].FixData.AddFixDataRow(fdr0);
            }

            PlayersDS plDS = this[ID];
            if (plDS.FixData.Count == 0)
            {
                isNew = true;
                PlayersDS.FixDataRow fdr0 = this[ID].FixData.NewFixDataRow();
                fdr0.PlayerID = ID;
                this[ID].FixData.AddFixDataRow(fdr0);
            }

            PlayersDS.FixDataRow fdr = plDS.FixData[0];

            // Verifica innanzitutto nei fix data
            if (isNew)
            {
                // Crea un nuovo giocatore
                string nome = HTML_Parser.CleanTags(plCells[0]);
                nome = nome.Replace("&nbsp;", "").Replace("\r\n", "").Replace("Â", "").Replace("&#39;", "'");
                nome = nome.Trim().TrimEnd('X').Trim().Replace("  ", " ");
                fdr.Nome = nome;

                fdr.Nationality = HTML_Parser.GetField(plCells[2], "flags/", ".png", HomeNation).Substring(0, 2);

                // Row4: Posizione preferita
                fdr.FP = HTML_Parser.Cut(plCells[4], "&nbsp;").Replace("Â", "").Trim();
                fdr.FP = TM_Compatible.ConvertNewFP(fdr.FP);
                fdr.FPn = Tm_Utility.FPToNumber(fdr.FP);
            }

            //-------------------------------------------------------------
            // Anche se sono dati fissi può essere utile aggiornarli
            //-------------------------------------------------------------

            // Row0: Numero
            //int numero;
            //if (!int.TryParse(HTML_Parser.Cut(plCells[0], "&nbsp;"), out numero))
            //{
            //    numero = int.Parse(HTML_Parser.GetTag(plCells[0], "SPAN"));
            //}
            fdr.Numero = 0;

            // Row3: Età
            string strAge = HTML_Parser.Cut(plCells[3], "</NOBR>");
            int age = int.Parse(strAge);
            int wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, 0, age);
            if (fdr.IswBornNull() || (fdr.wBorn == -9999))
                fdr.wBorn = wBorn;
            else if (wBorn < fdr.wBorn)
                fdr.wBorn = wBorn;

            //-------------------------------------------------------------
            // Aggiornamento dei dati variabili
            //-------------------------------------------------------------
            for (int n = 5; n <= 18; n++)
            {
                // Rimouve i tag relativi agli aumenti di skill
                if (plCells[n].IndexOf("star.gif") != -1)
                {
                    plCells[n] = "20";
                }
                else if (plCells[n].IndexOf("star_silver.gif") != -1)
                {
                    plCells[n] = "19";
                }
                else
                {
                    plCells[n] = HTML_Parser.CleanTags(plCells[n]);
                }
            }

            // Verifica innanzitutto nei fix data
            PlayersDS.VarDataRow vdr;
            int week = TmWeek.GetTmAbsWk(dt);

            if ((vdr = plDS.VarData.FindByWeek(week)) == null)
            {
                // Crea un nuovo set di dati
                vdr = plDS.VarData.NewVarDataRow();
                vdr.Week = week;
                plDS.VarData.AddVarDataRow(vdr);
            }

            // Row5: Forma
            vdr.For = int.Parse(plCells[5]);

            // Row6: Resistenza
            vdr.Res = int.Parse(plCells[6]);

            // Row7: Velocità
            vdr.Vel = int.Parse(plCells[7]);

            // Row8: Marcatura
            vdr.Mar = int.Parse(plCells[8]);

            // Row9: Contrasto
            vdr.Con = int.Parse(plCells[9]);

            // Row10: Impegno
            vdr.Wor = int.Parse(plCells[10]);

            // Row11: Posizioni
            vdr.Pos = int.Parse(plCells[11]);

            // Row12: Passaggi
            vdr.Pas = int.Parse(plCells[12]);

            // Row13: Cross
            vdr.Cro = int.Parse(plCells[13]);

            // Row14: Tecnica
            vdr.Tec = int.Parse(plCells[14]);

            // Row15: Colpo di testa
            vdr.Tes = int.Parse(plCells[15]);

            // Row16: Finalizzazione
            if (!plCells.Contains("-"))
                vdr.Fin = int.Parse(plCells[16]);

            // Row17: Tiro dalla distanza
            if (!plCells.Contains("-"))
                vdr.Dis = int.Parse(plCells[17]);

            // Row18: Calci di punizioni
            if (!plCells.Contains("-"))
                vdr.Cal = int.Parse(plCells[18]);

            // Row19: ASI
            string ASI = HTML_Parser.Cut(plCells[19], "&nbsp").Replace("Â", "").Trim();
            ASI = ASI.Replace(";", "");
            ASI = ASI.Replace(",", "");
            vdr.ASI = int.Parse(ASI);

            if (plCells[20].Contains(":"))
            {
                // The cells contains a bid
                string cell = HTML_Parser.CleanTags(plCells[20]);
                string[] toks = cell.Split(' ');
                for (int i = 0; i < toks.Length; i++)
                {
                    if (toks[i].Contains("/"))
                    {
                        ai.Ends = DateTime.Parse(toks[i]);
                        continue;
                    }

                    if (toks[i].Contains(":"))
                    {
                        ai.Ends = ai.Ends.AddHours(TimeSpan.Parse(toks[i]).TotalHours);
                        break;
                    }
                }
            }

            fdr.Notes = HTML_Parser.GetField(plCells[21], "--&#10;", "\" src=\"http");
            if (fdr.Notes == "")
                fdr.SetNotesNull();

            return ID;
        }

        internal int ParseTransferPlayer(DateTime dt, string plRow, ref AlarmInfo ai)
        {
            bool isNew = false;


            string[] plCells = plRow.Split(';');

            Dictionary<string, string> data = TM_Parser.CreateDictionary_NewTm(plRow);

            int ID;
            if (!data.ContainsKey("id")) return -1;

            if (!int.TryParse(data["id"], out ID)) return -1;

            if (!this.ContainsKey(ID))
            {
                this.Add(ID, new PlayersDS());
                isNew = true;
                PlayersDS.FixDataRow fdr0 = this[ID].FixData.NewFixDataRow();
                fdr0.PlayerID = ID;
                this[ID].FixData.AddFixDataRow(fdr0);
            }

            PlayersDS plDS = this[ID];

            if (plDS.FixData.Count == 0)
            {
                PlayersDS.FixDataRow fdr0 = this[ID].FixData.NewFixDataRow();
                fdr0.PlayerID = ID;
                this[ID].FixData.AddFixDataRow(fdr0);
                isNew = true;
            }

            PlayersDS.FixDataRow fdr = plDS.FixData[0];

            if (plCells.Length < 20) return -1;

            // Verifica innanzitutto nei fix data
            if (isNew)
            {
                // Crea un nuovo giocatore                
                fdr.Nome = data["name"];

                fdr.Nationality = data["nat"];

                // Row4: Posizione preferita
                fdr.FP = data["fp"].ToUpper();

                fdr.FPn = Tm_Utility.FPToNumber(fdr.FP);
            }

            //-------------------------------------------------------------
            // Anche se sono dati fissi può essere utile aggiornarli
            //-------------------------------------------------------------

            // Row0: Numero
            //int numero;
            //if (!int.TryParse(HTML_Parser.Cut(plCells[0], "&nbsp;"), out numero))
            //{
            //    numero = int.Parse(HTML_Parser.GetTag(plCells[0], "SPAN"));
            //}
            fdr.Numero = 0;

            // Row3: Età
            float f_age = float.Parse(data["age"], CommGlobal.ciUs);
            int age = (int)(f_age);
            int wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, 0, age);
            int weeks = (int)((f_age - (float)age + 0.00001) * 100);
            if (fdr.IswBornNull() || (fdr.wBorn == -9999))
                fdr.wBorn = wBorn - weeks;
            else if ((wBorn - weeks) < fdr.wBorn)
                fdr.wBorn = wBorn - weeks;

            fdr.Rec = decimal.Parse(data["rec"]) / 2M;

            //-------------------------------------------------------------
            // Aggiornamento dei dati variabili
            //-------------------------------------------------------------

            // Verifica innanzitutto nei fix data
            PlayersDS.VarDataRow vdr;
            int week = TmWeek.GetTmAbsWk(dt);

            DateTime endbid = dt.AddSeconds((double)int.Parse(data["time"]));

            int dataWeek = TmWeek.GetTmAbsWk(dt);
            if (dataWeek > week)
                dataWeek = week;

            if ((vdr = plDS.VarData.FindByWeek(dataWeek)) == null)
            {
                // Crea un nuovo set di dati
                vdr = plDS.VarData.NewVarDataRow();
                vdr.Week = dataWeek;
                plDS.VarData.AddVarDataRow(vdr);
            }

            fdr.TeamID = data["club_id"];

            // Row5: Forma
            vdr.For = int.Parse(data["str"]);

            // Row6: Resistenza
            vdr.Res = int.Parse(data["sta"]);

            // Row7: Velocità
            vdr.Vel = int.Parse(data["pac"]);

            if (fdr.FPn == 0) // GK
            {
                // Row8: Marcatura
                vdr.Pre = int.Parse(data["han"]);

                // Row9: Contrasto
                vdr.Con = int.Parse(data["one"]);

                // Row10: Impegno
                vdr.Wor = int.Parse(data["ref"]);

                // Row11: Posizioni
                vdr.Pos = int.Parse(data["ari"]);

                // Row12: Passaggi
                vdr.Pas = int.Parse(data["jum"]);

                // Row13: Cross
                vdr.Cro = int.Parse(data["com"]);

                // Row14: Tecnica
                vdr.Tec = int.Parse(data["kic"]);

                // Row15: Colpo di testa
                vdr.Tes = int.Parse(data["thr"]);
            }
            else
            {
                // Row8: Marcatura
                vdr.Mar = int.Parse(data["mar"]);

                // Row9: Contrasto
                vdr.Con = int.Parse(data["tac"]);

                // Row10: Impegno
                vdr.Wor = int.Parse(data["wor"]);

                // Row11: Posizioni
                vdr.Pos = int.Parse(data["pos"]);

                // Row12: Passaggi
                vdr.Pas = int.Parse(data["pas"]);

                // Row13: Cross
                vdr.Cro = int.Parse(data["cro"]);

                // Row14: Tecnica
                vdr.Tec = int.Parse(data["tec"]);

                // Row15: Colpo di testa
                vdr.Tes = int.Parse(data["hea"]);
            }

            // Row16: Finalizzazione
            if (fdr.FPn != 0)
            {
                vdr.Fin = int.Parse(data["fin"]);
                vdr.Dis = int.Parse(data["lon"]);
                vdr.Cal = int.Parse(data["set"]);
            }
            else
            {
                vdr.Fin = 0;
                vdr.Dis = 0;
                vdr.Cal = 0;
            }

            // Row19: ASI
            vdr.ASI = int.Parse(data["asi"]);

            string bid = data["bid"];

            fdr.Notes = "";
            if (fdr.Notes == "")
                fdr.SetNotesNull();

            fdr.TeamID = data["club_id"];

            ai.Bid = int.Parse(bid) / 1000000;
            ai.Ends = endbid;

            return ID;
        }

        internal int ParseGK(DateTime dt, string plRow, string HomeNation)
        {
            bool isNew = false;

            plRow = plRow.Replace("&amp;", "&");
            List<string> plCells = HTML_Parser.GetTags(plRow, "TD");

            string playerIdStr = HTML_Parser.GetNumberAfter(plCells[2], "playerid=");

            int ID;
            if (!int.TryParse(playerIdStr, out ID))
                return -1;

            if (!this.ContainsKey(ID))
            {
                this.Add(ID, new PlayersDS());
                isNew = true;
                PlayersDS.FixDataRow fdr0 = this[ID].FixData.NewFixDataRow();
                fdr0.PlayerID = ID;
                this[ID].FixData.AddFixDataRow(fdr0);
            }

            PlayersDS plDS = this[ID];
            PlayersDS.FixDataRow fdr = plDS.FixData[0];

            // Verifica innanzitutto nei fix data
            if (isNew)
            {
                // Crea un nuovo giocatore
                string nome = HTML_Parser.CleanTags(plCells[2]);
                nome = nome.Replace("&nbsp;", "").Replace("\r\n", "").Replace("Â", "").Replace("&#39;", "'");
                nome = nome.Trim().TrimEnd('X').Trim().Replace("  ", " ");
                fdr.Nome = nome;

                fdr.Nationality = HTML_Parser.GetField(plCells[2], "showcountry=", ">", HomeNation).Substring(0, 2);

                // Row4: Posizione preferita
                fdr.FP = "GK";
                fdr.FPn = 0;
            }

            //-------------------------------------------------------------
            // Anche se sono dati fissi può essere utile aggiornarli
            //-------------------------------------------------------------

            // Row0: Numero
            int numero;
            if (!int.TryParse(HTML_Parser.Cut(plCells[0], "&nbsp;"), out numero))
            {
                numero = int.Parse(HTML_Parser.GetTag(plCells[0], "SPAN"));
            }
            fdr.Numero = numero;

            // Row3: Età
            string strAge = HTML_Parser.Cut(plCells[3], "</NOBR>");
            int age = int.Parse(strAge);
            int wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, 0, age);
            if (fdr.IswBornNull() || (fdr.wBorn == -9999))
                fdr.wBorn = wBorn;
            else if (wBorn < fdr.wBorn)
                fdr.wBorn = wBorn;

            //-------------------------------------------------------------
            // Aggiornamento dei dati variabili
            //-------------------------------------------------------------
            for (int n = 5; n <= 15; n++)
            {
                // Rimouve i tag relativi agli aumenti di skill
                if (plCells[n].IndexOf("star.gif") != -1)
                {
                    plCells[n] = "20";
                }
                else if (plCells[n].IndexOf("star_silver.gif") != -1)
                {
                    plCells[n] = "19";
                }
                else
                {
                    plCells[n] = HTML_Parser.CleanTags(plCells[n]);
                }
            }

            // Verifica innanzitutto nei fix data
            PlayersDS.VarDataRow vdr;
            int week = TmWeek.GetTmAbsWk(dt);

            if ((vdr = plDS.VarData.FindByWeek(week)) == null)
            {
                // Crea un nuovo set di dati
                vdr = plDS.VarData.NewVarDataRow();
                vdr.Week = week;
                plDS.VarData.AddVarDataRow(vdr);
            }

            // Row5: Forma
            vdr.For = int.Parse(plCells[5]);

            // Row6: Resistenza
            vdr.Res = int.Parse(plCells[6]);

            // Row7: Velocità
            vdr.Vel = int.Parse(plCells[7]);

            // Row8: Marcatura
            vdr.Mar = int.Parse(plCells[8]);

            // Row9: Contrasto
            vdr.Con = int.Parse(plCells[9]);

            // Row10: Impegno
            vdr.Wor = int.Parse(plCells[10]);

            // Row11: Posizioni
            vdr.Pos = int.Parse(plCells[11]);

            // Row12: Passaggi
            vdr.Pas = int.Parse(plCells[12]);

            // Row13: Cross
            vdr.Cro = int.Parse(plCells[13]);

            // Row14: Tecnica
            vdr.Tec = int.Parse(plCells[14]);

            // Row15: Colpo di testa
            vdr.Tes = int.Parse(plCells[15]);

            // Row16: ASI
            string ASI = HTML_Parser.Cut(plCells[16], "&nbsp").Replace("Â", "").Trim();
            ASI = ASI.Replace(";", "");
            ASI = ASI.Replace(",", "");
            vdr.ASI = int.Parse(ASI);

            return ID;
        }

        internal void Save(string defaultDirPath)
        {
            foreach (int ID in this.Keys)
            {
                PlayersDS pDS = this[ID];
                string playerDataFile = Path.Combine(defaultDirPath, "Player-" + ID + ".4.xml");

                pDS.WriteXml(playerDataFile);
            }
        }

        internal void LoadPlayer(string defaultDirPath, int ID)
        {
            string playerDataFile = Path.Combine(defaultDirPath, "Player-" + ID + ".4.xml");

            if (!this.ContainsKey(ID))
                this.Add(ID, new PlayersDS());

            PlayersDS pDS = new PlayersDS();

            try
            {
                pDS.ReadXml(playerDataFile);
            }
            catch (Exception)
            {
                FileInfo fi = new FileInfo(playerDataFile);
                if (fi.Exists) fi.Delete();
            }

            foreach (PlayersDS.VarDataRow vdr in pDS.VarData)
            {
                if (this[ID].VarData.FindByWeek(vdr.Week) == null)
                {
                    PlayersDS.VarDataRow newVdr = this[ID].VarData.NewVarDataRow();
                    newVdr.ItemArray = vdr.ItemArray;
                    this[ID].VarData.AddVarDataRow(newVdr);
                }
            }

            // this[ID].ReadXml(playerDataFile, System.Data.XmlReadMode.Auto);
            // this[ID].ReadXml(playerDataFile);
        }

        internal int ParseClubhousePlayer(DateTime dt, string plRow, string HomeNation, ref AlarmInfo ai)
        {
            bool isNew = false;

            if (!plRow.Contains("playerid="))
            {
                return -1;
            }

            plRow = plRow.Replace("&amp;", "&");
            List<string> plCells = HTML_Parser.GetTags(plRow, "TD");

            string playerIdStr = HTML_Parser.GetNumberAfter(plCells[1], "playerid=");

            int ID;
            if (!int.TryParse(playerIdStr, out ID))
                return -1;

            if (!this.ContainsKey(ID))
            {
                this.Add(ID, new PlayersDS());
                isNew = true;
                PlayersDS.FixDataRow fdr0 = this[ID].FixData.NewFixDataRow();
                fdr0.PlayerID = ID;
                this[ID].FixData.AddFixDataRow(fdr0);
            }

            PlayersDS plDS = this[ID];
            PlayersDS.FixDataRow fdr = plDS.FixData[0];

            // Verifica innanzitutto nei fix data
            if (isNew)
            {
                // Crea un nuovo giocatore
                string nome = HTML_Parser.CleanTags(plCells[1]);
                nome = nome.Replace("&nbsp;", "").Replace("\r\n", "").Replace("Â", "").Replace("&#39;", "'");
                nome = nome.Trim().TrimEnd('X').Trim().Replace("  ", " ");
                fdr.Nome = nome;

                fdr.Nationality = HTML_Parser.GetField(plCells[3], "flags/", ".png", HomeNation).Substring(0, 2);

                // Row4: Posizione preferita
                fdr.FP = HTML_Parser.Cut(plCells[5], "&nbsp;").Replace("Â", "").Trim();
                fdr.FP = TM_Compatible.ConvertNewFP(fdr.FP);
                fdr.FPn = Tm_Utility.FPToNumber(fdr.FP);
            }

            //-------------------------------------------------------------
            // Anche se sono dati fissi può essere utile aggiornarli
            //-------------------------------------------------------------

            // Row0: Numero
            //int numero;
            //if (!int.TryParse(HTML_Parser.Cut(plCells[0], "&nbsp;"), out numero))
            //{
            //    numero = int.Parse(HTML_Parser.GetTag(plCells[0], "SPAN"));
            //}
            fdr.Numero = 0;

            // Row3: Età
            string strAge = HTML_Parser.Cut(plCells[4], "</NOBR>");
            strAge = HTML_Parser.CleanTags(strAge);
            int age = int.Parse(strAge);
            int wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, 0, age);
            if (fdr.IswBornNull() || (fdr.wBorn == -9999))
                fdr.wBorn = wBorn;
            else if (wBorn < fdr.wBorn)
                fdr.wBorn = wBorn;

            //-------------------------------------------------------------
            // Aggiornamento dei dati variabili
            //-------------------------------------------------------------


            // Verifica innanzitutto nei fix data
            PlayersDS.VarDataRow vdr;
            int week = TmWeek.GetTmAbsWk(dt);

            if ((vdr = plDS.VarData.FindByWeek(week)) == null)
            {
                // Crea un nuovo set di dati
                vdr = plDS.VarData.NewVarDataRow();
                vdr.Week = week;
                plDS.VarData.AddVarDataRow(vdr);
            }

            if (fdr.FPn == 0)
            {
                vdr.For = vdr.Res = vdr.Vel = vdr.Mar = vdr.Con = vdr.Wor = 0;
                vdr.Pos = vdr.Pas = vdr.Cro = vdr.Tec = vdr.Tes = 0;
            }
            else
            {
                vdr.For = vdr.Res = vdr.Vel = vdr.Mar = vdr.Con = vdr.Wor = 0;
                vdr.Pos = vdr.Pas = vdr.Cro = vdr.Tec = vdr.Tes = 0;
                vdr.Fin = vdr.Dis = vdr.Cal = 0;
            }

            // Row19: ASI
            string ASI = HTML_Parser.CleanTags(plCells[7]).Trim();
            ASI = ASI.Replace(";", "");
            ASI = ASI.Replace(",", "");
            vdr.ASI = int.Parse(ASI);


            return ID;
        }
    }
}
