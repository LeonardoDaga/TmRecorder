using System;
using System.Collections.Generic;
using System.Text;
using TMRecorder.Properties;
using Common;

namespace TMRecorder
{
    public class TM_Parser
    {
        public static void ParsePlayer(ref Db_TrophyDataSet.GiocatoriRow row, string tablerow)
        {
            tablerow = tablerow.Replace("&amp;", "&");
            List<string> plCells = HTML_Parser.GetTags(tablerow, "TD");

            row.Infortunato = 0;
            row.Squalificato = 0;
            row.InFormazione = false;

            // Row0: Numero
            int numero;
            if (!int.TryParse(HTML_Parser.Cut(plCells[0], "&nbsp;"), out numero))
            {
                numero = int.Parse(HTML_Parser.GetTag(plCells[0], "SPAN"));
            }
            row.Numero = numero;

            // Row1: Posizione schieramento
            string posizione = plCells[1].Replace("Â", "");
            if (posizione.IndexOf("[IMPOSTA]") != -1)
            {
                // Non è attualmente in formazione
            }
            else if (posizione.IndexOf("squad_inj.gif") != -1)
            {
                // Il giocatore è infortunato
                posizione = HTML_Parser.CutField(posizione, "");
                posizione = HTML_Parser.Cut(posizione, "&nbsp;");
                posizione = posizione.Replace("Â", "").Trim();

                // Il numero contenuto in posizione è il numero di settimane di infortunio
                int inj = int.Parse(posizione);
                row.Infortunato = inj;
            }
            else if (posizione.IndexOf("squad_ban") != -1)
            {
                // Il giocatore è squalificato
                row.Squalificato = 1;
            }
            else
            {
                posizione = HTML_Parser.GetTag(posizione, "A");
                posizione = HTML_Parser.Cut(posizione, "&nbsp;");
                posizione = posizione.Trim();
                // La stringa residua rappresenta l'attuale posizione scelta in campo
            }


            // Row2: Nome, player ID e nazionalità
            //nome = HTML_Parser.GetTag(plCells[2], "SPAN");
            //nome = HTML_Parser.Cut(nome, "&nbsp;").Replace("\r\n", "").Replace("Â", "").Replace("&#39;", "'");
            string nome = HTML_Parser.CleanTags(plCells[2]);
            nome = nome.Replace("&nbsp;", "").Replace("\r\n", "").Replace("?", "");
            nome = nome.Replace("Â", "").Replace("&#39;", "'");
            nome = nome.Trim().TrimEnd('X').Trim().Replace("  ", " ");
            row.Nome = nome;

            plCells[2] = plCells[2].Replace("&amp;", "&");
            string playerIdStr = HTML_Parser.GetNumberAfter(plCells[2], "playerid=");
            if (playerIdStr == "")
                playerIdStr = HTML_Parser.GetNumberAfter(plCells[2], "fire=");
            row.PlayerID = int.Parse(playerIdStr);
            row.Nationality = HTML_Parser.GetField(plCells[2], "showcountry=", ">", Program.Setts.HomeNation).Substring(0, 2);

            // Row3: Età
            string eta = HTML_Parser.Cut(plCells[3], "</NOBR>");
            row.Età = int.Parse(eta);

            // Row4: Posizione preferita
            row.FP = HTML_Parser.Cut(plCells[4], "&nbsp;").Replace("Â", "").Replace("?", "").Trim();
            row.FP = TM_Compatible.ConvertNewFP(row.FP);

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

            // Row5: Forma
            row.For = int.Parse(plCells[5]);

            // Row6: Resistenza
            row.Res = int.Parse(plCells[6]);

            // Row7: Velocità
            row.Vel = int.Parse(plCells[7]);

            // Row8: Marcatura
            row.Mar = int.Parse(plCells[8]);

            // Row9: Contrasto
            row.Con = int.Parse(plCells[9]);

            // Row10: Impegno
            row.Wor = int.Parse(plCells[10]);

            // Row11: Posizioni
            row.Pos = int.Parse(plCells[11]);

            // Row12: Passaggi
            row.Pas = int.Parse(plCells[12]);

            // Row13: Cross
            row.Cro = int.Parse(plCells[13]);

            // Row14: Tecnica
            row.Tec = int.Parse(plCells[14]);

            // Row15: Colpo di testa
            row.Tes = int.Parse(plCells[15]);

            // Row16: Finalizzazione
            row.Fin = int.Parse(plCells[16]);

            // Row17: Tiro dalla distanza
            row.Tir = int.Parse(plCells[17]);

            // Row18: Calci di punizioni
            row.Cal = int.Parse(plCells[18]);

            // Row19: ASI
            string ASI = HTML_Parser.Cut(plCells[19], "&nbsp").Replace("Â", "").Replace("?", "").Trim();
            ASI = ASI.Replace(";", "");
            ASI = ASI.Replace(",", "");
            row.ASI = int.Parse(ASI);
        }

        public static void ParseGK(ref Db_TrophyDataSet.PortieriRow row, string tablerow)
        {
            List<string> plCells = HTML_Parser.GetTags(tablerow, "TD");

            row.Infortunato = 0;
            row.Squalificato = 0;
            row.InFormazione = false;

            if (plCells.Count < 16)
            {
                row = null;
                return;
            }

            // Row0: Numero
            string num = HTML_Parser.GetNumberAfter(plCells[1], "no=");
            if (num == "")
                num = HTML_Parser.GetTag(plCells[0], "SPAN");

            row.Numero = int.Parse(num);

            // Row1: Posizione schieramento
            string posizione = plCells[1];
            if (posizione.IndexOf("[IMPOSTA]") != -1)
            {
                // Non è attualmente in formazione
            }
            else if (posizione.IndexOf("squad_inj.gif") != -1)
            {
                // Il giocatore è infortunato
                posizione = HTML_Parser.CutField(posizione, "");
                posizione = HTML_Parser.Cut(posizione, "&nbsp;");
                posizione = posizione.Replace("Â", "").Trim();

                // Il numero contenuto in posizione è il numero di settimane di infortunio
                int inj = int.Parse(posizione);
                row.Infortunato = inj;
            }
            else if (posizione.IndexOf("squad_ban") != -1)
            {
                // Il giocatore è squalificato
                row.Squalificato = 1;
            }
            else
            {
                posizione = HTML_Parser.GetTag(posizione, "A");
                posizione = HTML_Parser.Cut(posizione, "&nbsp;");
                posizione = posizione.Replace("Â", "").Trim();

                // La stringa residua rappresenta l'attuale posizione scelta in campo
            }

            // Row2: Nome, playerID e Nazionalità
            string nome = HTML_Parser.CleanTags(plCells[2]);
            nome = nome.Trim().TrimEnd('X').Trim().Replace("  ", " ").Replace("?", "").Replace("&#39;", "'");
            nome = nome.Replace("Â", "").Trim();
            row.Nome = nome;
            //string nome = HTML_Parser.GetTag(plCells[2], "SPAN").Replace("Â", "").Replace("\r\n", "");
            //nome = HTML_Parser.Cut(nome, "&nbsp;").Trim();
            //if (nome.IndexOf("&#39;") != -1)
            //{
            //    nome = nome.Replace("&#39;", "'");
            //}
            //row.Nome = nome;

            string playerIdStr = HTML_Parser.GetNumberAfter(plCells[2], "playerid=");
            if (playerIdStr == "")
                playerIdStr = HTML_Parser.GetNumberAfter(plCells[2], "fire=");
            row.PlayerID = int.Parse(playerIdStr);

            row.Nationality = HTML_Parser.GetField(plCells[2], "showcountry=", ">", Program.Setts.HomeNation).Substring(0, 2);

            // Row3: Età
            string eta = HTML_Parser.Cut(plCells[3], "</NOBR>");
            row.Età = int.Parse(eta);

            // Row4: Posizione preferita: Sempre PO

            // Rimouve i tag relativi agli aumenti di skill
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

            // Row5: Forma
            row.For = int.Parse(plCells[5]);

            // Row6: Resistenza
            row.Res = int.Parse(plCells[6]);

            // Row7: Velocità
            row.Vel = int.Parse(plCells[7]);

            // Row8: Presa
            row.Pre = int.Parse(plCells[8]);

            // Row9: Uno contro Uno
            row.Uno = int.Parse(plCells[9]);

            // Row10: Riflessi
            row.Rif = int.Parse(plCells[10]);

            // Row11: Autorità aerea
            row.Aer = int.Parse(plCells[11]);

            // Row12: Elevazione
            row.Ele = int.Parse(plCells[12]);

            // Row13: Comunicazione
            row.Com = int.Parse(plCells[13]);

            // Row14: Tiro
            row.Tir = int.Parse(plCells[14]);

            // Row15: Lanci
            row.Lan = int.Parse(plCells[15]);

            // Row16: ASI
            string ASI = HTML_Parser.Cut(plCells[16], "&nbsp").Replace("?", "").Replace("Â", "").Trim();
            ASI = ASI.Replace(";", "");
            ASI = ASI.Replace(",", "");
            row.ASI = int.Parse(ASI);
        }

        internal static bool ParsePlayerTraining_NewTM2(ref TrainingDataSet.GiocatoriRow row,
                                                        Dictionary<string, string> data)
        {
            row.PlayerID = int.Parse(data["player"]);
            row.TI = int.Parse(data["ti"]);
            row.For = int.Parse(data["0"]);
            row.Res = int.Parse(data["1"]);
            row.Vel = int.Parse(data["2"]);
            row.Mar = int.Parse(data["3"]);
            row.Con = int.Parse(data["4"]);
            row.Wor = int.Parse(data["5"]);
            row.Pos = int.Parse(data["6"]);
            row.Pas = int.Parse(data["7"]);
            row.Cro = int.Parse(data["8"]);
            row.Tec = int.Parse(data["9"]);
            row.Tes = int.Parse(data["10"]);
            row.Fin = int.Parse(data["11"]);
            row.Tir = int.Parse(data["12"]);
            row.Cal = int.Parse(data["13"]);
            return true;
        }

        internal static bool ParseGKTraining_NewTM2(ref TrainingDataSet.PortieriRow row,
                                                        Dictionary<string, string> data)
        {
            row.PlayerID = int.Parse(data["player"]);
            row.TI = int.Parse(data["ti"]);
            row.For = int.Parse(data["0"]);
            row.Res = int.Parse(data["1"]);
            row.Vel = int.Parse(data["2"]);
            row.Pre = int.Parse(data["3"]);
            row.Uno = int.Parse(data["4"]);
            row.Rif = int.Parse(data["5"]);
            row.Aer = int.Parse(data["6"]);
            row.Ele = int.Parse(data["7"]);
            row.Com = int.Parse(data["8"]);
            row.Tir = int.Parse(data["9"]);
            row.Lan = int.Parse(data["10"]);
            
            return true;
        }

        internal static bool ParsePlayerTraining_NewTM(ref TrainingDataSet.GiocatoriRow row, string tablerow)
        {
            List<string> plCells = HTML_Parser.GetTags(tablerow, "TD");
            int[] ilInc = new int[18];

            if (plCells.Count < 18) return false;

            int plyID = 0;
            if (!int.TryParse(HTML_Parser.GetNumberAfter(plCells[0], "player_link=\""), out plyID))
                return false;

            row.PlayerID = plyID;

            int n0 = 3;
            for (int n = n0; n <= n0 + 13; n++)
            {
                plCells[n] = plCells[n].ToLower();
                // Rimouve i tag relativi agli aumenti di skill
                if (plCells[n].Contains("subtle"))
                    ilInc[n] = 0;
                else if (plCells[n].Contains("training training_small"))
                    ilInc[n] = 1;
                else if (plCells[n].Contains("training training_big"))
                    ilInc[n] = 2;
                else if (plCells[n].Contains("training training_part_down"))
                    ilInc[n] = -1;
                else if (plCells[n].Contains("training training_down"))
                    ilInc[n] = -2;
                else
                    ilInc[n] = 0;
            }

            // Row4: Forma
            row.For = ilInc[n0 + 0];

            // Row5: Resistenza
            row.Res = ilInc[n0 + 1];

            // Row6: Velocità
            row.Vel = ilInc[n0 + 2];

            // Row7: Marcatura
            row.Mar = ilInc[n0 + 3];

            // Row8: Contrasto
            row.Con = ilInc[n0 + 4];

            // Row9: Impegno
            row.Wor = ilInc[n0 + 5];

            // Row10: Posizioni
            row.Pos = ilInc[n0 + 6];

            // Row11: Passaggi
            row.Pas = ilInc[n0 + 7];

            // Row12: Cross
            row.Cro = ilInc[n0 + 8];

            // Row13: Tecnica
            row.Tec = ilInc[n0 + 9];

            // Row14: Colpo di testa
            row.Tes = ilInc[n0 + 10];

            // Row15: Finalizzazione
            row.Fin = ilInc[n0 + 11];

            // Row16: Tiro dalla distanza
            row.Tir = ilInc[n0 + 12];

            // Row17: Calci di punizioni
            row.Cal = ilInc[n0 + 13];

            // Row18: TI
            plCells[n0 + 14] = plCells[n0 + 14].Replace(',', '.');

            if (plCells[n0 + 14] == "-")
                row.TI = 0f;
            else if (plCells[n0 + 14] != "")
                row.TI = float.Parse(HTML_Parser.CleanTags(plCells[n0 + 14]), CommGlobal.ci);
            else
                row.TI = 0f;

            // Importing training
            row.Age = plCells[1];

            return true;
        }

        internal static bool ParsePlayerTraining(ref TrainingDataSet.GiocatoriRow row, string tablerow)
        {
            tablerow = tablerow.Replace("rgb(141, 182, 82)", "#8db652");
            tablerow = tablerow.Replace("rgb(66, 85, 39)", "#425527");
            tablerow = tablerow.Replace("rgb(96, 47, 47)", "#602f2f");
            tablerow = tablerow.Replace("rgb(255, 0, 0)", "#ff0000");
            tablerow = tablerow.Replace("' ", " ");

            List<string> plCells = HTML_Parser.GetTags(tablerow, "TD");

            if (plCells.Count < 17) return false;

            int plyID = 0;
            if (!int.TryParse(HTML_Parser.GetNumberAfter(plCells[1], "playerid="), out plyID))
                return false;

            row.PlayerID = plyID;

            int n0 = 5;
            for (int n = n0; n <= n0 + 13; n++)
            {
                plCells[n] = plCells[n].ToUpper();
                // Rimouve i tag relativi agli aumenti di skill
                if (plCells[n].IndexOf("BACKGROUND") != -1)
                {
                    if (plCells[n].IndexOf("#425527") != -1)
                        plCells[n] = "1";
                    else if (plCells[n].ToUpper().IndexOf("#8DB652") != -1)
                        plCells[n] = "2";
                    else if (plCells[n].ToUpper().IndexOf("#602F2F") != -1)
                        plCells[n] = "-1";
                    else if (plCells[n].ToUpper().IndexOf("#FF0000") != -1)
                        plCells[n] = "-2";
                    else
                        plCells[n] = "0";
                }
                else
                {
                    plCells[n] = "0";
                }
            }

            // Row4: Forma
            row.For = int.Parse(plCells[n0 + 0]);

            // Row5: Resistenza
            row.Res = int.Parse(plCells[n0 + 1]);

            // Row6: Velocità
            row.Vel = int.Parse(plCells[n0 + 2]);

            // Row7: Marcatura
            row.Mar = int.Parse(plCells[n0 + 3]);

            // Row8: Contrasto
            row.Con = int.Parse(plCells[n0 + 4]);

            // Row9: Impegno
            row.Wor = int.Parse(plCells[n0 + 5]);

            // Row10: Posizioni
            row.Pos = int.Parse(plCells[n0 + 6]);

            // Row11: Passaggi
            row.Pas = int.Parse(plCells[n0 + 7]);

            // Row12: Cross
            row.Cro = int.Parse(plCells[n0 + 8]);

            // Row13: Tecnica
            row.Tec = int.Parse(plCells[n0 + 9]);

            // Row14: Colpo di testa
            row.Tes = int.Parse(plCells[n0 + 10]);

            // Row15: Finalizzazione
            row.Fin = int.Parse(plCells[n0 + 11]);

            // Row16: Tiro dalla distanza
            row.Tir = int.Parse(plCells[n0 + 12]);

            // Row17: Calci di punizioni
            row.Cal = int.Parse(plCells[n0 + 13]);

            // Row18: TI
            plCells[n0 + 15] = plCells[n0 + 15].Replace(',', '.');

            if (plCells[n0 + 15] == "-")
                row.TI = 0f;
            else if (plCells[n0 + 15] != "")
                row.TI = float.Parse(HTML_Parser.CleanTags(plCells[n0 + 15]), CommGlobal.ci);
            else
                row.TI = 0f;

            return true;
        }

        internal static bool ParsePlayerTrainingNew(ref TrainingDataSet.GiocatoriRow row, string tablerow)
        {
            string[] plCells = tablerow.Split(',');

            if (plCells.Length < 17) return false;

            int plyID = 0;
            if (!int.TryParse(plCells[0], out plyID))
                return false;

            row.PlayerID = plyID;

            int n0 = 5;
            for (int n = n0; n <= n0 + 13; n++)
            {
                // Non ci sono scatti decimali
                plCells[n] = "0";
            }

            // Row4: Forma
            row.For = int.Parse(plCells[n0 + 0]);

            // Row5: Resistenza
            row.Res = int.Parse(plCells[n0 + 1]);

            // Row6: Velocità
            row.Vel = int.Parse(plCells[n0 + 2]);

            // Row7: Marcatura
            row.Mar = int.Parse(plCells[n0 + 3]);

            // Row8: Contrasto
            row.Con = int.Parse(plCells[n0 + 4]);

            // Row9: Impegno
            row.Wor = int.Parse(plCells[n0 + 5]);

            // Row10: Posizioni
            row.Pos = int.Parse(plCells[n0 + 6]);

            // Row11: Passaggi
            row.Pas = int.Parse(plCells[n0 + 7]);

            // Row12: Cross
            row.Cro = int.Parse(plCells[n0 + 8]);

            // Row13: Tecnica
            row.Tec = int.Parse(plCells[n0 + 9]);

            // Row14: Colpo di testa
            row.Tes = int.Parse(plCells[n0 + 10]);

            // Row15: Finalizzazione
            row.Fin = int.Parse(plCells[n0 + 11]);

            // Row16: Tiro dalla distanza
            row.Tir = int.Parse(plCells[n0 + 12]);

            // Row17: Calci di punizioni
            row.Cal = int.Parse(plCells[n0 + 13]);

            // Row18: TI
            if (plCells.Length < n0 + 15 + 1)
            {
                row.TI = 0f;
                return true;
            }

            int nTI = plCells.Length - 1;
            plCells[nTI] = plCells[nTI].Replace(',', '.');

            float TI = 0.0f;
            float.TryParse(HTML_Parser.CleanTags(plCells[nTI]), System.Globalization.NumberStyles.Any, CommGlobal.ci, out TI);
            row.TI = TI;

            return true;
        }

        public static bool ParseTrainingGK(ref TrainingDataSet.PortieriRow row, string tablerow)
        {
            tablerow = tablerow.Replace("background", "BACKGROUND");
            tablerow = tablerow.Replace("-color", "-COLOR");
            tablerow = tablerow.Replace("rgb(141, 182, 82)", "#8db652");
            tablerow = tablerow.Replace("rgb(66, 85, 39)", "#425527");
            tablerow = tablerow.Replace("rgb(96, 47, 47)", "#602f2f");
            tablerow = tablerow.Replace("rgb(255, 0, 0)", "#ff0000");
            tablerow = tablerow.Replace("BACKGROUND-COLOR: red", "BACKGROUND-COLOR: #ff0000");
            tablerow = tablerow.Replace("BACKGROUND-COLOR:red", "BACKGROUND-COLOR: #ff0000");

            List<string> plCells = HTML_Parser.GetTags(tablerow, "TD");

            if (plCells.Count < 16)
            {
                row = null;
                return false;
            }

            int ix = 5;
            int plyID = 0;

            if (!int.TryParse(HTML_Parser.GetNumberAfter(plCells[1], "playerid="), out plyID))
                return false;

            row.PlayerID = plyID;

            // Rimouve i tag relativi agli aumenti di skill
            for (int n = ix; n <= ix + 10; n++)
            {
                // Rimouve i tag relativi agli aumenti di skill
                if (plCells[n].IndexOf("BACKGROUND") != -1)
                {
                    if (plCells[n].IndexOf("#425527") != -1)
                        plCells[n] = "1";
                    else if (plCells[n].ToUpper().IndexOf("#8DB652") != -1)
                        plCells[n] = "2";
                    else if (plCells[n].ToUpper().IndexOf("#602F2F") != -1)
                        plCells[n] = "-1";
                    else if (plCells[n].ToUpper().IndexOf("#FF0000") != -1)
                        plCells[n] = "-2";
                }
                else
                {
                    plCells[n] = "0";
                }
            }

            // Row5: Forma
            row.For = int.Parse(plCells[ix + 0]);

            // Row6: Resistenza
            row.Res = int.Parse(plCells[ix + 1]);

            // Row7: Velocità
            row.Vel = int.Parse(plCells[ix + 2]);

            // Row8: Presa
            row.Pre = int.Parse(plCells[ix + 3]);

            // Row9: Uno contro Uno
            row.Uno = int.Parse(plCells[ix + 4]);

            // Row10: Riflessi
            row.Rif = int.Parse(plCells[ix + 5]);

            // Row11: Autorità aerea
            row.Aer = int.Parse(plCells[ix + 6]);

            // Row12: Elevazione
            row.Ele = int.Parse(plCells[ix + 7]);

            // Row13: Comunicazione
            row.Com = int.Parse(plCells[ix + 8]);

            // Row14: Tiro
            row.Tir = int.Parse(plCells[ix + 9]);

            // Row15: Lanci
            row.Lan = int.Parse(plCells[ix + 10]);

            // Row15: Lanci
            plCells[ix + 15] = plCells[ix + 15].Replace(',', '.');
            plCells[ix + 15] = HTML_Parser.CleanTags(plCells[ix + 15]);
            if (plCells[ix + 15] == "-")
                row.TI = 0f;
            else
                row.TI = float.Parse(plCells[ix + 15], CommGlobal.ci);

            return true;
        }

        public static bool ParseTrainingGK_NewTM(ref TrainingDataSet.PortieriRow row, string tablerow)
        {
            List<string> plCells = HTML_Parser.GetTags(tablerow, "TD");
            int[] ilInc = new int[18];

            if (plCells.Count < 15)
            {
                row = null;
                return false;
            }

            int ix = 3;
            int plyID = 0;

            if (!int.TryParse(HTML_Parser.GetNumberAfter(plCells[0], "player_link=\""), out plyID))
                return false;

            row.PlayerID = plyID;

            // Rimouve i tag relativi agli aumenti di skill
            for (int n = ix; n <= ix + 10; n++)
            {
                plCells[n] = plCells[n].ToLower();
                // Rimouve i tag relativi agli aumenti di skill
                if (plCells[n].Contains("subtle"))
                    ilInc[n] = 0;
                else if (plCells[n].Contains("training training_small"))
                    ilInc[n] = 1;
                else if (plCells[n].Contains("training training_big"))
                    ilInc[n] = 2;
                else if (plCells[n].Contains("training training_part_down"))
                    ilInc[n] = -1;
                else if (plCells[n].Contains("training training_down"))
                    ilInc[n] = -2;
                else
                    ilInc[n] = 0;
            }

            // Row5: Forma
            row.For = ilInc[ix + 0];

            // Row6: Resistenza
            row.Res = ilInc[ix + 1];

            // Row7: Velocità
            row.Vel = ilInc[ix + 2];

            // Row8: Presa
            row.Pre = ilInc[ix + 3];

            // Row9: Uno contro Uno
            row.Uno = ilInc[ix + 4];

            // Row10: Riflessi
            row.Rif = ilInc[ix + 5];

            // Row11: Autorità aerea
            row.Aer = ilInc[ix + 6];

            // Row12: Elevazione
            row.Ele = ilInc[ix + 7];

            // Row13: Comunicazione
            row.Com = ilInc[ix + 8];

            // Row14: Tiro
            row.Tir = ilInc[ix + 9];

            // Row15: Lanci
            row.Lan = ilInc[ix + 10];

            // Row18: TI
            plCells[ix + 11] = plCells[ix + 11].Replace(',', '.');

            if (plCells[ix + 11] == "-")
                row.TI = 0f;
            else if (plCells[ix + 11] != "")
                row.TI = float.Parse(HTML_Parser.CleanTags(plCells[ix + 11]), CommGlobal.ci);
            else
                row.TI = 0f;

            // Importing training
            row.Age = plCells[1];

            return true;
        }

        public static bool ParseTrainingGKNew(ref TrainingDataSet.PortieriRow row, string tablerow)
        {
            string[] plCells = tablerow.Split(',');

            if (plCells.Length < 15) return false;

            int plyID = 0;
            if (!int.TryParse(plCells[0], out plyID))
                return false;

            row.PlayerID = plyID;

            // Rimouve i tag relativi agli aumenti di skill
            int ix = 5;
            for (int n = ix; n <= ix + 10; n++)
            {
                // Rimouve i tag relativi agli aumenti di skill
                if (plCells[n].IndexOf("BACKGROUND") != -1)
                {
                    if (plCells[n].IndexOf("#425527") != -1)
                        plCells[n] = "1";
                    else if (plCells[n].IndexOf("#8db652") != -1)
                        plCells[n] = "2";
                    else if (plCells[n].IndexOf("#602f2f") != -1)
                        plCells[n] = "-1";
                    else if (plCells[n].IndexOf("background-color:red") != -1)
                        plCells[n] = "-2";
                }
                else
                {
                    plCells[n] = "0";
                }
            }

            // Row5: Forma
            row.For = int.Parse(plCells[ix + 0]);

            // Row6: Resistenza
            row.Res = int.Parse(plCells[ix + 1]);

            // Row7: Velocità
            row.Vel = int.Parse(plCells[ix + 2]);

            // Row8: Presa
            row.Pre = int.Parse(plCells[ix + 3]);

            // Row9: Uno contro Uno
            row.Uno = int.Parse(plCells[ix + 4]);

            // Row10: Riflessi
            row.Rif = int.Parse(plCells[ix + 5]);

            // Row11: Autorità aerea
            row.Aer = int.Parse(plCells[ix + 6]);

            // Row12: Elevazione
            row.Ele = int.Parse(plCells[ix + 7]);

            // Row13: Comunicazione
            row.Com = int.Parse(plCells[ix + 8]);

            // Row14: Tiro
            row.Tir = int.Parse(plCells[ix + 9]);

            // Row15: Lanci
            row.Lan = int.Parse(plCells[ix + 10]);

            // Row18: TI
            if (plCells.Length < ix + 12 + 1)
            {
                row.TI = 0f;
                return true;
            }

            int ixTI = plCells.Length - 1;

            // Row15: TI
            plCells[ixTI] = plCells[ixTI].Replace(',', '.');
            plCells[ixTI] = HTML_Parser.CleanTags(plCells[ixTI]);

            float TI = 0.0f;
            float.TryParse(plCells[ixTI], System.Globalization.NumberStyles.Any, CommGlobal.ci, out TI);
            row.TI = TI;

            return true;
        }

        internal static int ParseTrainerTraining_NewTM(ref TrainingDataSet trainingDataSet, string plRow, TrainersSkills trainers)
        {
            TrainingDataSet.TrainersRow row = (TrainingDataSet.TrainersRow)trainingDataSet.Trainers.NewRow();
            row.ID = 0;

            if (!plRow.Contains("%"))
                row.Name = "No Trainer";
            else
                row.Name = HTML_Parser.GetField(plRow, " - ", " (").Trim();

            // Find the trainer id
            foreach (TrainersSkills.TrainersRow tr in trainers.Trainers)
            {
                if (!tr.Name.Contains("."))
                {
                    if ((tr.Name == row.Name) &&
                        (trainingDataSet.Trainers.FindByID(tr.ID) == null))
                    {
                        row.ID = tr.ID;
                        break;
                    }
                }
                else
                {
                    string[] pcs = row.Name.Split(' ');
                    string shortname = pcs[0][0] + ". " + pcs[1];
                    //for (int i = 1; i < 2 /*pcs.Length*/; i++)
                    //{
                    //    if (pcs[i].Contains(".")) continue;
                    //    shortname += " " + pcs[i];
                    //}

                    if ((tr.Name == shortname) &&
                        (trainingDataSet.Trainers.FindByID(tr.ID) == null))
                    {
                        row.ID = tr.ID;
                        tr.Name = row.Name;
                        trainers.isDirty = true;
                        break;
                    }
                }
            }

            if (row.Name == "No Trainer")
            {
                // Check if there is already a "No Trainer"
                foreach (TrainersSkills.TrainersRow tr in trainers.Trainers)
                {
                    if (tr.Name == "No Trainer")
                    {
                        row.ID = tr.ID;
                        break;
                    }
                }
                return row.ID;
            }

            if ((row.ID == 0) && (row.Name == "No Trainer"))
            {
                row.ID = row.Name.GetHashCode();

                TrainersSkills.TrainersRow tr = trainers.Trainers.FindByID(row.ID);

                if (tr == null)
                {
                    tr = (TrainersSkills.TrainersRow)trainers.Trainers.NewTrainersRow();
                    tr.Name = row.Name;
                    tr.ID = row.ID;
                    tr.Att = 0;
                    tr.Dif = 0;
                    tr.Fis = 0;
                    tr.Hea = 0;
                    tr.Mot = 0;
                    tr.Por = 0;
                    tr.Tec = 0;
                    tr.Win = 0;
                    tr.inTeam = true;
                    trainers.Trainers.AddTrainersRow(tr);
                }
            }

            if (row.ID == 0)
            {
                row.ID = row.Name.GetHashCode();

                TrainersSkills.TrainersRow tr = trainers.Trainers.FindByID(row.ID);

                if (tr == null)
                {
                    tr = (TrainersSkills.TrainersRow)trainers.Trainers.NewTrainersRow();
                    tr.Name = row.Name;
                    tr.ID = row.ID;
                    tr.Att = 0;
                    tr.Dif = 0;
                    tr.Fis = 0;
                    tr.Hea = 0;
                    tr.Mot = 0;
                    tr.Por = 0;
                    tr.Tec = 0;
                    tr.Win = 0;
                    tr.inTeam = true;
                    trainers.Trainers.AddTrainersRow(tr);
                }
            }

            // Compose the Program field
            int program = 0;
            if (plRow.Contains("training_prog11.png")) program += 1;
            if (plRow.Contains("training_prog21.png")) program += 2;
            if (plRow.Contains("training_prog31.png")) program += 4;
            if (plRow.Contains("training_prog41.png")) program += 8;
            if (plRow.Contains("training_prog51.png")) program += 16;
            if (plRow.Contains("training_prog61.png")) program += 32;
            if (plRow.Contains("training_prog3.png")) program += 4;
            if (plRow.Contains("training_prog4.png")) program += 8;
            if (plRow.Contains("training_prog5.png")) program += 16;
            if (plRow.Contains("training_prog6.png")) program += 32;

            row.Program = program;

            if (row.Program > 0)
            {
                int percentage = 0;
                int.TryParse(HTML_Parser.GetField(plRow, " (", "%)<").Trim(), out percentage);
                row.Percentage = percentage;
            }
            else
            {
                row.Percentage = 0;
            }

            if (trainers.Trainers.FindByID(row.ID) == null)
            {
                return -1;
            }

            trainingDataSet.Trainers.AddTrainersRow(row);
            return row.ID;
        }


        internal static int ParseTrainerTraining(ref TrainingDataSet trainingDataSet, string plRow, TrainersSkills trainers)
        {
            TrainingDataSet.TrainersRow row = (TrainingDataSet.TrainersRow)trainingDataSet.Trainers.NewRow();
            row.ID = 0;

            string tok = HTML_Parser.GetField(plRow, "<strong>", "</strong>").Trim();
            row.Name = HTML_Parser.GetField(tok, ":", "<span>").Trim();
            if (row.Name == "")
            {
                if (tok.Contains("0%"))
                    row.Name = "No Trainer";
                else
                    row.Name = HTML_Parser.GetField(plRow, "Coach:", "(").Trim();
            }

            // Find the trainer id
            foreach (TrainersSkills.TrainersRow tr in trainers.Trainers)
            {
                if (!tr.Name.Contains("."))
                {
                    if ((tr.Name == row.Name) &&
                        (trainingDataSet.Trainers.FindByID(tr.ID) == null))
                    {
                        row.ID = tr.ID;
                        break;
                    }
                }
                else
                {
                    string[] pcs = row.Name.Split(' ');
                    string shortname = pcs[0][0] + ". " + pcs[1];
                    //for (int i = 1; i < 2 /*pcs.Length*/; i++)
                    //{
                    //    if (pcs[i].Contains(".")) continue;
                    //    shortname += " " + pcs[i];
                    //}

                    if ((tr.Name == shortname) &&
                        (trainingDataSet.Trainers.FindByID(tr.ID) == null))
                    {
                        row.ID = tr.ID;
                        tr.Name = row.Name;
                        trainers.isDirty = true;
                        break;
                    }
                }
            }

            if ((row.ID == 0) && (row.Name == "No Trainer"))
            {
                row.ID = row.Name.GetHashCode();

                TrainersSkills.TrainersRow tr = trainers.Trainers.FindByID(row.ID);

                if (tr == null)
                {
                    tr = (TrainersSkills.TrainersRow)trainers.Trainers.NewTrainersRow();
                    tr.Name = row.Name;
                    tr.ID = row.ID;
                    tr.Att = 0;
                    tr.Dif = 0;
                    tr.Fis = 0;
                    tr.Hea = 0;
                    tr.Mot = 0;
                    tr.Por = 0;
                    tr.Tec = 0;
                    tr.Win = 0;
                    tr.inTeam = true;
                    trainers.Trainers.AddTrainersRow(tr);
                }
            }

            if (row.ID == 0)
            {
                row.ID = row.Name.GetHashCode();

                TrainersSkills.TrainersRow tr = trainers.Trainers.FindByID(row.ID);

                if (tr == null)
                {
                    tr = (TrainersSkills.TrainersRow)trainers.Trainers.NewTrainersRow();
                    tr.Name = row.Name;
                    tr.ID = row.ID;
                    tr.Att = 0;
                    tr.Dif = 0;
                    tr.Fis = 0;
                    tr.Hea = 0;
                    tr.Mot = 0;
                    tr.Por = 0;
                    tr.Tec = 0;
                    tr.Win = 0;
                    tr.inTeam = true;
                    trainers.Trainers.AddTrainersRow(tr);
                }
            }

            // Compose the Program field
            int program = 0;
            if (plRow.Contains("training_prog11.png")) program += 1;
            if (plRow.Contains("training_prog21.png")) program += 2;
            if (plRow.Contains("training_prog31.png")) program += 4;
            if (plRow.Contains("training_prog41.png")) program += 8;
            if (plRow.Contains("training_prog51.png")) program += 16;
            if (plRow.Contains("training_prog61.png")) program += 32;
            if (plRow.Contains("training_prog3.png")) program += 4;
            if (plRow.Contains("training_prog4.png")) program += 8;
            if (plRow.Contains("training_prog5.png")) program += 16;
            if (plRow.Contains("training_prog6.png")) program += 32;

            row.Program = program;

            if (row.Program > 0)
            {
                int percentage = 0;
                int.TryParse(HTML_Parser.GetField(plRow, "<span>(", "%)").Trim(), out percentage);
                row.Percentage = percentage;
            }
            else
            {
                row.Percentage = 0;
            }

            if (trainers.Trainers.FindByID(row.ID) == null)
            {
                return -1;
            }

            trainingDataSet.Trainers.AddTrainersRow(row);
            return row.ID;
        }

        internal static bool ParseTrainerTrainingNew(ref TrainersSkills.TrainersRow trow, string trainer)
        {
            // Typical string: 65682,Dario Rizzati,48,20,15,19,5,17,11,11,1
            string[] str = trainer.Trim("'".ToCharArray()).Split(',');

            int id = int.Parse(str[0]);
            trow.ID = id;
            trow.Name = str[1];
            trow.Mot = decimal.Parse(str[3]);
            trow.Fis = decimal.Parse(str[4]);
            trow.Por = decimal.Parse(str[5]);
            trow.Dif = decimal.Parse(str[6]);
            trow.Tec = decimal.Parse(str[7]);
            trow.Win = decimal.Parse(str[8]);
            trow.Hea = decimal.Parse(str[9]);
            trow.Att = decimal.Parse(str[10]);

            return true;
        }

        public static void ParsePlayer_New(ref Db_TrophyDataSet.GiocatoriRow row, string tablerow)
        {
            tablerow = tablerow.Replace("{", "");
            Dictionary<string, string> data = CreateDictionary(tablerow);

            ParsePlayer_Dict(ref row, data);
        }

        public static void ParsePlayer_NewTM(ref Db_TrophyDataSet.GiocatoriRow row, string tablerow)
        {            
            Dictionary<string, string> data = CreateDictionaryNewTm(tablerow);

            ParsePlayer_Dict(ref row, data);
        }

        public static void ParsePlayer_Dict(ref Db_TrophyDataSet.GiocatoriRow row, Dictionary<string, string> data)
        {
            row.Infortunato = 0;
            row.Squalificato = 0;
            row.InFormazione = false;

            // Row0: Numero
            row.Numero = int.Parse(data["no"]);

            row.Nome = data["name"].Replace("  ", " ");
            row.PlayerID = int.Parse(data["id"]);
            row.Nationality = data["country"];
            if (row.Nationality == "")
                row.Nationality = Program.Setts.HomeNation;
            string[] etaStr = data["age"].Split('.');
            row.Età = int.Parse(etaStr[0]);
            row.Mesi = int.Parse(etaStr[1]);
            
            row.FP = TM_Compatible.ConvertNewFP(data["fp"]);

            row.For = int.Parse(data["str"]);
            row.Res = int.Parse(data["sta"]);
            row.Vel = int.Parse(data["pac"]);
            row.Mar = int.Parse(data["mar"]);
            row.Con = int.Parse(data["tac"]);
            row.Wor = int.Parse(data["wor"]);
            row.Pos = int.Parse(data["pos"]);
            row.Pas = int.Parse(data["pas"]);
            row.Cro = int.Parse(data["cro"]);
            row.Tec = int.Parse(data["tec"]);
            row.Tes = int.Parse(data["hea"]);
            row.Fin = int.Parse(data["fin"]);
            row.Tir = int.Parse(data["lon"]);
            row.Cal = int.Parse(data["set"]);
            row.ASI = int.Parse(data["asi"]);
            row.Routine = decimal.Parse(data["routine"], Common.CommGlobal.ciUs);

            row.Goals = int.Parse(data["goals"]);
            row.Assist = int.Parse(data["assists"]);
            row.Wage = int.Parse(data["wage"]);
            row.Rating = decimal.Parse(data["rat"], Common.CommGlobal.ciUs);
            row.GP = int.Parse(data["gp"]);

            row.MoM = int.Parse(data["mom"]);
            row.Cards = int.Parse(data["cards"]);

            row.Rec = int.Parse(data["rec"]);
            row.Squalificato = int.Parse(data["ban_points"]);

            int retire = 0;
            int.TryParse(data["retire"], out retire);
            row.Retire = retire;

            row.Note = data["txt"];

            row.TIs = data["TIs"].Replace(",",";");

            if (data["inj"] != "null")
                row.Infortunato = int.Parse(data["inj"]);
            else
                row.Infortunato = 0;

            int TeamID = int.Parse(data["club"]);
            row.IsReserve = (short)((TeamID == Program.Setts.MainSquadID) ? 0 : 1);
        }

        public static Dictionary<string, string> CreateDictionaryNewTm(string tablerow)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            string[] plCells = tablerow.Split(';');

            foreach (string cell in plCells)
            {
                string[] item = cell.Split('=');
                if (item.Length < 2) continue;
                string key = item[0].Trim();
                string value = item[1].Trim();
                if (dict.ContainsKey(key)) continue;
                dict.Add(key, value);
            }

            return dict;
        }

        public static Dictionary<string, string> CreateDictionary(string tablerow)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            tablerow = tablerow.Replace("{", "");
            tablerow = tablerow.Replace(", \"", "*").Replace(",\"", "*");
            tablerow = tablerow.Replace("\"", "");

            string[] plCells = tablerow.Split('*');

            foreach (string cell in plCells)
            {
                string[] item = cell.Split(':');
                if (item.Length < 2) continue;
                string key = item[0].Trim();
                string value = item[1].Trim();
                dict.Add(key, value);
            }

            return dict;
        }

        public static void ParseGK_New(ref Db_TrophyDataSet.PortieriRow row, string tablerow)
        {
            tablerow = tablerow.Replace("{", "");
            Dictionary<string, string> data = CreateDictionary(tablerow);

            ParseGK_Dict(ref row, data);
        }

        public static void ParseGK_NewTM(ref Db_TrophyDataSet.PortieriRow row, string tablerow)
        {
            Dictionary<string, string> data = CreateDictionaryNewTm(tablerow);

            ParseGK_Dict(ref row, data);
        }

        public static void ParseGK_Dict(ref Db_TrophyDataSet.PortieriRow row, Dictionary<string, string> data)
        {
            row.Infortunato = 0;
            row.Squalificato = 0;
            row.InFormazione = false;

            // Row0: Numero
            row.Numero = int.Parse(data["no"]);

            //row.Squalificato = int.Parse(data["ban"]);
            row.Nome = data["name"].Replace("  ", " ");
            row.PlayerID = int.Parse(data["id"]);
            row.Nationality = data["country"];
            if (row.Nationality == "")
                row.Nationality = Program.Setts.HomeNation;

            string[] etaStr = data["age"].Split('.');
            row.Età = int.Parse(etaStr[0]);
            row.Mesi = int.Parse(etaStr[1]);

            row.For = int.Parse(data["str"]);
            row.Res = int.Parse(data["sta"]);
            row.Vel = int.Parse(data["pac"]);

            row.Pre = int.Parse(data["han"]);
            row.Uno = int.Parse(data["one"]);
            row.Rif = int.Parse(data["ref"]);
            row.Aer = int.Parse(data["ari"]);
            row.Ele = int.Parse(data["jum"]);
            row.Com = int.Parse(data["com"]);
            row.Tir = int.Parse(data["kic"]);
            row.Lan = int.Parse(data["thr"]);
            row.ASI = int.Parse(data["asi"]);
            row.Routine = decimal.Parse(data["routine"], Common.CommGlobal.ciUs);

            row.Goals = int.Parse(data["goals"]);
            row.Assist = int.Parse(data["assists"]);
            row.Wage = int.Parse(data["wage"]);
            row.Rating = decimal.Parse(data["rat"], Common.CommGlobal.ciUs);
            row.GP = int.Parse(data["gp"]);

            row.Cards = int.Parse(data["cards"]);
            row.MoM = int.Parse(data["mom"]);

            row.Note = data["txt"];
            row.TIs = data["TIs"].Replace(",", ";");

            row.Rec = int.Parse(data["rec"]);
            row.Squalificato = int.Parse(data["ban_points"]);
            row.Retire = int.Parse(data["retire"]);

            if (data["inj"] != "null")
                row.Infortunato = int.Parse(data["inj"]);
            else
                row.Infortunato = 0;

            int TeamID = int.Parse(data["club"]);
            row.IsReserve = (short)((TeamID == Program.Setts.MainSquadID) ? 0 : 1);
        }


        public static void ParsePlayerTraining_Dict(ref Db_TrophyDataSet.PortieriRow row, Dictionary<string, string> data)
        {
            row.Infortunato = 0;
            row.Squalificato = 0;
            row.InFormazione = false;

            // Row0: Numero
            row.Numero = int.Parse(data["no"]);

            if (data["inj"] != "null")
                row.Infortunato = int.Parse(data["inj"]);
            else
                row.Infortunato = 0;

            //row.Squalificato = int.Parse(data["ban"]);
            row.Nome = data["name"].Replace("  ", " ");
            row.PlayerID = int.Parse(data["id"]);
            row.Nationality = data["country"];
            if (row.Nationality == "")
                row.Nationality = Program.Setts.HomeNation;

            string[] etaStr = data["age"].Split('.');
            row.Età = int.Parse(etaStr[0]);
            row.Mesi = int.Parse(etaStr[1]);

            row.For = int.Parse(data["str"]);
            row.Res = int.Parse(data["sta"]);
            row.Vel = int.Parse(data["pac"]);

            row.Pre = int.Parse(data["han"]);
            row.Uno = int.Parse(data["one"]);
            row.Rif = int.Parse(data["ref"]);
            row.Aer = int.Parse(data["ari"]);
            row.Ele = int.Parse(data["jum"]);
            row.Com = int.Parse(data["com"]);
            row.Tir = int.Parse(data["kic"]);
            row.Lan = int.Parse(data["thr"]);
            row.ASI = int.Parse(data["asi"]);
            row.Routine = decimal.Parse(data["routine"], Common.CommGlobal.ciUs);

            row.Goals = int.Parse(data["goals"]);
            row.Assist = int.Parse(data["assists"]);
            row.Wage = int.Parse(data["wage"]);
            row.Rating = decimal.Parse(data["rat"], Common.CommGlobal.ciUs);
            row.GP = int.Parse(data["gp"]);

            if (data["inj"] != "null")
                row.Infortunato = int.Parse(data["inj"]);
            else
                row.Infortunato = 0;

            int TeamID = int.Parse(data["club"]);
            row.IsReserve = (short)((TeamID == Program.Setts.MainSquadID) ? 0 : 1);
        }
    }
}
