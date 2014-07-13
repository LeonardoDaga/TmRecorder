using System;
namespace Common
{
    partial class YouthDev
    {
        partial class ScoutReportDataTable
        {
        }

        partial class ScoutReportRow
        {
            public decimal GetEstimASI()
            {
                if (FP == "GK")
                    return (decimal)Math.Pow(10.0, (double)6.7284 * Math.Log10((double)(GetSkillSum()*14M/11M)) - 10.769);
                else
                    return (decimal)Math.Pow(10.0, (double)6.7284 * Math.Log10((double)(GetSkillSum())) - 10.769);
            }

            public decimal GetSkillSum()
            {
                decimal skSum = For + Res + Vel;
                skSum += Mar_Pre + Con_Uno + Wor_Rif;
                skSum += Pos_Aer + Pas_Ele + Cro_Com;
                skSum += Tec_Tir + Tes_Lan;
                if (FP != "GK")
                    skSum += Fin + Tir + Cal;

                return skSum;
            }
        }

        public void ParsePlayerPage_NewTM(string page, int actualYouthLevel, string homeNation)
        {
            int ix = 0;
            int ixend = 0;

            System.Collections.Generic.List<string> rows = new System.Collections.Generic.List<string>();

            while ((ix = page.IndexOf("id=youth_player_", ixend)) != -1)
            {
                ixend = page.IndexOf("small_red_x.png", ix);
                string substr = page.Substring(ix, ixend - ix);

                rows = HTML_Parser.GetTags(substr, "TD");

                ScoutReportRow srr = this.ScoutReport.NewScoutReportRow();

                System.Collections.Generic.List<string> tds = HTML_Parser.GetTags(substr, "TD");

                // Find position
                // Vertical position:
                string vpos = HTML_Parser.GetField(substr, "<SPAN class=\"favposition long\"><SPAN class=", ">");
                int ixs = substr.IndexOf("<SPAN class=side>") + 17;
                bool hposl = (substr.IndexOf("Left", ixs, 20) != -1);
                bool hposc = (substr.IndexOf("Center", ixs, 20) != -1);
                bool hposr = (substr.IndexOf("Right", ixs, 20) != -1);

                string FP = "";
                if (vpos == "gk")
                {
                    srr.FP = "GK";
                }
                else if (vpos == "f")
                {
                    srr.FP = "FC";
                }
                else 
                {
                    // Horizontal position:
                    FP = vpos.ToUpper();
                }

                if (hposl && hposr)
                    srr.FP = FP + "L/" + FP + "R";
                else if (hposl && hposc)
                    srr.FP = FP + "L/" + FP + "C";
                else if (hposc && hposr)
                    srr.FP = FP + "C/" + FP + "R";
                else if (hposl)
                    srr.FP = FP + "L";
                else if (hposc)
                    srr.FP = FP + "C";
                else if (hposr)
                    srr.FP = FP + "R";

                srr.FPn = Tm_Utility.FPToNumber(srr.FP);

                if (srr.FP == "GK")
                {
                    srr.For = int.Parse(tds[0]);
                    srr.Res = int.Parse(tds[2]);
                    srr.Vel = int.Parse(tds[4]);
                    srr.Mar_Pre = int.Parse(tds[1]);
                    srr.Con_Uno = int.Parse(tds[3]);
                    srr.Wor_Rif = int.Parse(tds[5]);
                    srr.Pos_Aer = int.Parse(tds[7]);
                    srr.Pas_Ele = int.Parse(tds[9]);
                    srr.Cro_Com = int.Parse(tds[11]);
                    srr.Tec_Tir = int.Parse(tds[15]);
                    srr.Tes_Lan = int.Parse(tds[13]);
                }
                else
                {
                    srr.For = int.Parse(tds[0]);
                    srr.Res = int.Parse(tds[2]);
                    srr.Vel = int.Parse(tds[4]);
                    srr.Mar_Pre = int.Parse(tds[6]);
                    srr.Con_Uno = int.Parse(tds[8]);
                    srr.Wor_Rif = int.Parse(tds[10]);
                    srr.Pos_Aer = int.Parse(tds[12]);
                    srr.Pas_Ele = int.Parse(tds[1]);
                    srr.Cro_Com = int.Parse(tds[3]);
                    srr.Tec_Tir = int.Parse(tds[5]);
                    srr.Tes_Lan = int.Parse(tds[7]);
                    srr.Fin = int.Parse(tds[9]);
                    srr.Tir = int.Parse(tds[11]);
                    srr.Cal = int.Parse(tds[13]);
                }

                srr.Name = HTML_Parser.GetField(substr, "<DIV class=\"player_name mega_headline\">", "</DIV>");

                srr.Age = int.Parse(HTML_Parser.GetField(substr, "<DIV>Età: ", "<BR>"));
                srr.Week = TmWeek.GetTmAbsWk(System.DateTime.Now);
                srr.Promoted = false;

                srr.SkillSum = srr.GetSkillSum();
                srr.EstimASI = srr.GetEstimASI();
                srr.ID = int.Parse(HTML_Parser.GetNumberAfter(substr, "id=youth_player_"));

                srr.PromotYouthLev = actualYouthLevel;

                // looking for the stars
                ixs = substr.IndexOf("class=rec_stars");

                int pot = 0;
                for (int i = 0; i < 5; i++)
                {
                    int ixRec_4 = substr.IndexOf("megastar recomendation\"", ixs);
                    int ixRec_2 = substr.IndexOf("megastar recomendation_potential\"", ixs);
                    int ixPot_4 = substr.IndexOf("megastar potential\"", ixs);
                    int ixPot_2 = substr.IndexOf("megastar potential_half\"", ixs);
                    int ixPot_0 = substr.IndexOf("megastar empty\"", ixs);

                    if (ixRec_4 == -1) ixRec_4 = substr.Length;
                    if (ixRec_2 == -1) ixRec_2 = substr.Length;
                    if (ixPot_4 == -1) ixPot_4 = substr.Length;
                    if (ixPot_2 == -1) ixPot_2 = substr.Length;

                    if ((ixRec_4 < ixRec_2) && (ixRec_4 < ixPot_4) & (ixRec_4 < ixPot_2))
                    {
                        pot += 4;
                        ixs = ixRec_4 + 1;
                        continue;
                    }
                    if ((ixRec_2 < ixRec_4) && (ixRec_2 < ixPot_4) & (ixRec_2 < ixPot_2))
                    {
                        pot += 4;
                        ixs = ixRec_2 + 1;
                        continue;
                    }
                    if ((ixPot_4 < ixRec_4) && (ixPot_4 < ixRec_2) & (ixPot_4 < ixPot_2))
                    {
                        pot += 4;
                        ixs = ixPot_4 + 1;
                        continue;
                    }
                    if ((ixPot_2 < ixRec_4) && (ixPot_2 < ixRec_2) & (ixPot_2 < ixPot_4))
                    {
                        pot += 2;
                        ixs = ixPot_2 + 1;
                        continue;
                    }
                }

                srr.YouthScoutVote = pot;
                //for (int i = 0; i < pc.Length; i++)
                //{
                //    if (pc[i].Contains(srr.Name))
                //    {
                //        for (; i < pc.Length; i++)
                //        {
                //            if (pc[i].Contains("*"))
                //            {
                //                srr.YouthScoutVote = int.Parse(HTML_Parser.GetFieldRev(pc[i], ":", "*"));
                //                break;
                //            }
                //        }
                //        break;
                //    }
                //}

                srr.Nationality = homeNation;

                ScoutReportRow srrOld = ScoutReport.FindByID(srr.ID);

                if (srrOld == null)
                    this.ScoutReport.AddScoutReportRow(srr);
                else
                {
                    System.Windows.Forms.DialogResult res;
                    res = System.Windows.Forms.MessageBox.Show("The player " + srr.Name + "(its ID) already exists (Name on the list: " + srrOld.Name + "): Substitute?",
                        "Youth Development: Scout report paste", System.Windows.Forms.MessageBoxButtons.YesNo);

                    if (res == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.ScoutReport.RemoveScoutReportRow(srrOld);
                        this.ScoutReport.AddScoutReportRow(srr);
                    }
                }
            }
        }

        public void ParsePlayerPage(string page, int actualYouthLevel, string homeNation)
        {
            page = page.Replace("'", "");
            page = page.Replace("  ", " ");
            page = page.Replace('"', '\'');
            page = page.Replace("'>", ">");
            page = page.Replace("&#39;", "'");
            page = page.Replace(" \r\n", " ");
            page = page.Replace("&nbsp;", "");

            string rest = HTML_Parser.GetField(page, "playerid=ALL", "!-- Footer --");
            rest = rest.Replace("<strong>", "|");
            rest = rest.Replace("</strong>", "|");
            rest = rest.Replace("<STRONG>", "|");
            rest = rest.Replace("</STRONG>", "|");

            string[] pc = rest.Split('|');

            System.Collections.Generic.List<string> rows = HTML_Parser.GetTags(rest, "TR");

            int nPlayers = rows.Count - 3;

            foreach(string row in rows)
            {
                ScoutReportRow srr = this.ScoutReport.NewScoutReportRow();

                System.Collections.Generic.List<string> tds = HTML_Parser.GetTags(row, "TD");

                if (tds.Count < 4) continue;

                srr.FP = tds[1];
                srr.FP = TM_Compatible.ConvertNewFP(srr.FP);
                srr.FPn = Tm_Utility.FPToNumber(srr.FP);

                srr.Name = HTML_Parser.GetField("|"+tds[0].Replace("Â ", ""), "|", " (");
                srr.For = int.Parse(tds[2]);
                srr.Res = int.Parse(tds[3]);
                srr.Vel = int.Parse(tds[4]);
                srr.Mar_Pre = int.Parse(tds[5]);
                srr.Con_Uno = int.Parse(tds[6]);
                srr.Wor_Rif = int.Parse(tds[7]);
                srr.Pos_Aer = int.Parse(tds[8]);
                srr.Pas_Ele = int.Parse(tds[9]);
                srr.Cro_Com = int.Parse(tds[10]);
                srr.Tec_Tir = int.Parse(tds[11]);
                srr.Tes_Lan = int.Parse(tds[12]);

                if (srr.FP != "GK")
                {
                    srr.Fin = int.Parse(tds[13]);
                    srr.Tir = int.Parse(tds[14]);
                    srr.Cal = int.Parse(tds[15]);
                }

                srr.Age = int.Parse(HTML_Parser.GetField(tds[0], "(", " "));
                srr.Week = TmWeek.GetTmAbsWk(System.DateTime.Now);
                srr.Promoted = false;

                srr.SkillSum = srr.GetSkillSum();
                srr.EstimASI = srr.GetEstimASI();
                srr.ID = int.Parse(HTML_Parser.GetField(tds[16], "playerid=", ">"));

                srr.PromotYouthLev = actualYouthLevel;

                for (int i = 0; i < pc.Length; i++)
                {
                    if (pc[i].Contains(srr.Name))
                    {
                        for (; i < pc.Length; i++)
                        {
                            if (pc[i].Contains("*"))
                            {
                                srr.YouthScoutVote = int.Parse(HTML_Parser.GetFieldRev(pc[i], ":", "*"));
                                break;
                            }
                        }
                        break;
                    }
                }

                srr.Nationality = homeNation;

                ScoutReportRow srrOld = ScoutReport.FindByID(srr.ID);

                if (srrOld == null)
                    this.ScoutReport.AddScoutReportRow(srr);
                else
                {
                    System.Windows.Forms.DialogResult res;
                    res = System.Windows.Forms.MessageBox.Show("The player " + srr.Name + "(its ID) already exists (Name on the list: " + srrOld.Name + "): Substitute?",
                        "Youth Development: Scout report paste", System.Windows.Forms.MessageBoxButtons.YesNo);

                    if (res == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.ScoutReport.RemoveScoutReportRow(srrOld);
                        this.ScoutReport.AddScoutReportRow(srr);
                    }
                }
            }
        }
    }
}
