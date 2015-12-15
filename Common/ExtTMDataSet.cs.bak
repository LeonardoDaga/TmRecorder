using System;
// using TMRecorder.Properties;
using Common;
using SendFileTo;
using System.IO;
using System.Windows.Forms;

namespace Common
{
    partial class ExtTMDataSet2
    {
        public FileInfo fiSource;

        partial class GiocatoriNSkillDataTable
        {
            bool foundA = false;
            bool foundB = false;

            public bool ContainsTeamA(ExtraDS extraDS)
            {
                if (foundA) return true;
                foreach (GiocatoriNSkillRow gnsr in this)
                {
                    if (extraDS.Giocatori.FindByPlayerID(gnsr.PlayerID).isYoungTeam == 0)
                    {
                        foundA = true;
                        return true;
                    }
                }
                return false;
            }

            public bool ContainsTeamB(ExtraDS extraDS)
            {
                if (foundB) return true;
                foreach (GiocatoriNSkillRow gnsr in this)
                {
                    if (extraDS.Giocatori.FindByPlayerID(gnsr.PlayerID).isYoungTeam == 1)
                    {
                        foundB = true;
                        return true;
                    }
                }
                return false;
            }

            public bool ContainsTeamA()
            {
                throw new NotImplementedException();
            }
        }

        partial class DataTable1DataTable
        {
        }

        partial class ATeamDataTable
        {
        }

        public DateTime Date
        {
            set
            {
                WeekNoDataRow row = null;

                // Create Row if needed
                if (WeekNoData.Rows.Count == 0)
                {
                    row = (WeekNoDataRow)WeekNoData.NewRow();
                    WeekNoData.Rows.Add(row);
                }
                else
                {
                    row = (WeekNoDataRow)WeekNoData.Rows[0];
                }

                row.Date = value;
            }

            get
            {
                // Create Row if needed
                if (WeekNoData.Rows.Count == 0)
                {
                    return DateTime.Now;
                }

                WeekNoDataRow row = (WeekNoDataRow)WeekNoData.Rows[0];
                return row.Date;
            }
        }

        public Db_TrophyDataSet Get_TDS()
        {
            Db_TrophyDataSet tds = new Db_TrophyDataSet();

            tds.Date = this.Date;

            foreach (ExtTMDataSet2.GiocatoriNSkillRow tdsRow in this.GiocatoriNSkill)
            {
                if (tdsRow.FPn == 0)
                {
                    Db_TrophyDataSet.GiocatoriRow edsRow = tds.Giocatori.NewGiocatoriRow();

                    edsRow.PlayerID = tdsRow.PlayerID;
                    edsRow.Numero = tdsRow.Numero;
                    edsRow.Nationality = tdsRow.Nationality;
                    edsRow.Nome = tdsRow.Nome;
                    edsRow.Età = tdsRow.Età;
                    edsRow.FP = tdsRow.FP;
                    edsRow.Ada = 0;
                    edsRow.ASI = tdsRow.ASI;
                    edsRow.Cal = tdsRow.Set;
                    edsRow.Con = tdsRow.Con_Uno;
                    edsRow.Cro = tdsRow.Cro_Com;
                    edsRow.Fin = tdsRow.Fin;
                    edsRow.For = tdsRow.For;
                    edsRow.Mar = tdsRow.Mar_Pre;
                    edsRow.Pas = tdsRow.Pas_Ele;
                    edsRow.Pos = tdsRow.Pos_Aer;
                    edsRow.Res = tdsRow.Res;
                    edsRow.Tec = tdsRow.Tec_Tir;
                    edsRow.Tes = tdsRow.Tes_Lan;
                    edsRow.Tir = tdsRow.Lon;
                    edsRow.Vel = tdsRow.Vel;
                    edsRow.Wor = tdsRow.Wor_Rif;
                    edsRow.InFormazione = tdsRow.InFormazione;
                    edsRow.Infortunato = tdsRow.Infortunato;
                    edsRow.Squalificato = tdsRow.Squalificato;
                    edsRow.Rec = tdsRow.Rec;

                    tds.Giocatori.AddGiocatoriRow(edsRow);
                }
                else
                {
                    Db_TrophyDataSet.PortieriRow edsRow = tds.Portieri.NewPortieriRow();

                    edsRow.PlayerID = tdsRow.PlayerID;
                    edsRow.Numero = tdsRow.Numero;
                    edsRow.Nationality = tdsRow.Nationality;
                    edsRow.Nome = tdsRow.Nome;
                    edsRow.Età = tdsRow.Età;
                    edsRow.ASI = tdsRow.ASI;

                    edsRow.For = tdsRow.For;
                    edsRow.Res = tdsRow.Res;
                    edsRow.Vel = tdsRow.Vel;
                    edsRow.Tir = tdsRow.Tec_Tir;
                    edsRow.Aer = tdsRow.Pos_Aer;
                    edsRow.Com = tdsRow.Cro_Com;
                    edsRow.Ele = tdsRow.Pas_Ele;
                    edsRow.Lan = tdsRow.Tes_Lan;
                    edsRow.Pre = tdsRow.Mar_Pre;
                    edsRow.Rif = tdsRow.Wor_Rif;
                    edsRow.Uno = tdsRow.Con_Uno;

                    edsRow.InFormazione = tdsRow.InFormazione;
                    edsRow.Infortunato = tdsRow.Infortunato;
                    edsRow.Squalificato = tdsRow.Squalificato;
                    edsRow.Rec = tdsRow.Rec;

                    tds.Portieri.AddPortieriRow(edsRow);
                }
            }

            return tds;
        }

        private decimal trInc(decimal skill, decimal training, decimal refskill)
        {
            if ((int)skill != (int)refskill) return skill;

            if (training == 1M)
            {
                // Incrementa la skill solo se non supera l'unità (non va oltre 0.9)
                if ((int)(skill + 0.1M) == (int)(skill))
                    return skill + 0.1M;
                else
                    return skill;
            }

            return skill;
        }

        public void IncSkill_TrainingDataSet(TrainingDataSet tds,
                                                ExtTMDataSet2 extTMDataSet)
        {
            foreach (TrainingDataSet.GiocatoriRow tdsRow in tds.Giocatori)
            {
                ExtTMDataSet2.GiocatoriNSkillRow edsRow = this.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);
                ExtTMDataSet2.GiocatoriNSkillRow refRow = extTMDataSet.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);

                if (edsRow == null) continue;
                if (refRow == null) continue;

                // Bisogna aggiungere ad ogni skill (byte alto) il contributo legato alla crescita
                // in modo che possa essere facilmente estratto e immesso senza che si creino sovrapposizioni
                edsRow.For = trInc(edsRow.For, tdsRow.For, refRow.For);
                edsRow.Vel = trInc(edsRow.Vel, tdsRow.Vel, refRow.Vel);
                edsRow.Res = trInc(edsRow.Res, tdsRow.Res, refRow.Res);
                edsRow.Con_Uno = trInc(edsRow.Con_Uno, tdsRow.Con, refRow.Con_Uno);
                edsRow.Cro_Com = trInc(edsRow.Cro_Com, tdsRow.Cro, refRow.Cro_Com);
                edsRow.Mar_Pre = trInc(edsRow.Mar_Pre, tdsRow.Mar, refRow.Mar_Pre);
                edsRow.Pas_Ele = trInc(edsRow.Pas_Ele, tdsRow.Pas, refRow.Pas_Ele);
                edsRow.Pos_Aer = trInc(edsRow.Pos_Aer, tdsRow.Pos, refRow.Pos_Aer);
                edsRow.Tec_Tir = trInc(edsRow.Tec_Tir, tdsRow.Tec, refRow.Tec_Tir);
                edsRow.Tes_Lan = trInc(edsRow.Tes_Lan, tdsRow.Tes, refRow.Tes_Lan);
                edsRow.Wor_Rif = trInc(edsRow.Wor_Rif, tdsRow.Wor, refRow.Wor_Rif);

                if (tdsRow.IsFinNull() || refRow.IsFinNull()) continue;
                edsRow.Fin = trInc(edsRow.Fin, tdsRow.Fin, refRow.Fin);
                edsRow.Lon = trInc(edsRow.Lon, tdsRow.Tir, refRow.Lon);
                edsRow.Set = trInc(edsRow.Set, tdsRow.Cal, refRow.Set);
            }
        }

        private decimal trDec(decimal skill, decimal training, decimal refskill)
        {
            if ((int)skill != (int)refskill) return skill;

            if (training == -1M)
            {
                if ((int)(skill + 0.1M) == (int)(skill))
                    return skill + 0.1M;
                else
                    return skill;
            }

            return skill;
        }

        public void DecSkill_TrainingDataSet(TrainingDataSet tds,
                                                ExtTMDataSet2 extTMDataSet)
        {
            foreach (TrainingDataSet.GiocatoriRow tdsRow in tds.Giocatori)
            {
                ExtTMDataSet2.GiocatoriNSkillRow edsRow = this.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);
                ExtTMDataSet2.GiocatoriNSkillRow refRow = extTMDataSet.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);

                if (edsRow == null) continue;
                if (refRow == null) continue;

                // Bisogna aggiungere ad ogni skill (byte alto) il contributo legato alla crescita
                // in modo che possa essere facilmente estratto e immesso senza che si creino sovrapposizioni
                edsRow.For = trDec(edsRow.For, tdsRow.For, refRow.For);
                edsRow.Res = trDec(edsRow.Res, tdsRow.Res, refRow.Res);
                edsRow.Vel = trDec(edsRow.Vel, tdsRow.Vel, refRow.Vel);
                edsRow.Con_Uno = trDec(edsRow.Con_Uno, tdsRow.Con, refRow.Con_Uno);
                edsRow.Cro_Com = trDec(edsRow.Cro_Com, tdsRow.Cro, refRow.Cro_Com);
                edsRow.Mar_Pre = trDec(edsRow.Mar_Pre, tdsRow.Mar, refRow.Mar_Pre);
                edsRow.Pas_Ele = trDec(edsRow.Pas_Ele, tdsRow.Pas, refRow.Pas_Ele);
                edsRow.Pos_Aer = trDec(edsRow.Pos_Aer, tdsRow.Pos, refRow.Pos_Aer);
                edsRow.Tec_Tir = trDec(edsRow.Tec_Tir, tdsRow.Tec, refRow.Tec_Tir);
                edsRow.Tes_Lan = trDec(edsRow.Tes_Lan, tdsRow.Tes, refRow.Tes_Lan);
                edsRow.Wor_Rif = trDec(edsRow.Wor_Rif, tdsRow.Wor, refRow.Wor_Rif);

                if (tdsRow.IsFinNull() || refRow.IsFinNull()) continue;
                edsRow.Fin = trDec(edsRow.Fin, tdsRow.Fin, refRow.Fin);
                edsRow.Lon = trDec(edsRow.Lon, tdsRow.Tir, refRow.Lon);
                edsRow.Set = trDec(edsRow.Set, tdsRow.Cal, refRow.Set);
            }
        }

        private decimal setDec(decimal newVal, decimal lastVal)
        {
            if ((int)newVal == (int)lastVal)
                return lastVal;
            else
                return newVal;
        }

        public void FillWithDb_TrophyDataSet(ExtraDS PlayersDS,
                                                Db_TrophyDataSet tds,
                                                Gain_Function fun,
                                                ExtTMDataSet2 prevDS,
                                                short isReserves,
                                                string ApplicationFolder)
        {
            try
            {
                this.Date = tds.Date;
                bool isNew = false;

                foreach (Db_TrophyDataSet.GiocatoriRow tdsRow in tds.Giocatori)
                {
                    isNew = false;

                    ExtTMDataSet2.GiocatoriNSkillRow edsRow = this.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);

                    if (edsRow == null)
                    {
                        edsRow = this.GiocatoriNSkill.NewGiocatoriNSkillRow();
                        edsRow.PlayerID = tdsRow.PlayerID;
                        isNew = true;
                    }

                    ExtTMDataSet2.GiocatoriNSkillRow pdsRow = null;
                    if (prevDS != null) pdsRow = prevDS.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);

                    ExtraDS.GiocatoriRow plyDB = null;
                    if (PlayersDS != null)
                    {
                        plyDB = PlayersDS.Giocatori.FindByPlayerID(edsRow.PlayerID);

                        if ((plyDB == null) || (plyDB.IsTeamNull()))
                            edsRow.Team = "A";
                        else
                            edsRow.Team = plyDB.Team;
                    }
                    else
                    {
                        edsRow.Team = "A";
                    }

                    edsRow.Numero = tdsRow.Numero;
                    edsRow.Nationality = tdsRow.Nationality;

                    if (!edsRow.IsNomeNull())
                    {
                        string eds_nome = edsRow.Nome.Split('|')[0];
                        if (eds_nome.Length > tdsRow.Nome.Length)
                            edsRow.Nome = eds_nome;
                        else
                            edsRow.Nome = tdsRow.Nome;
                        edsRow.Nome = HTML_Parser.ConvertHTML_Text(edsRow.Nome);
                    }
                    else
                    {
                        edsRow.Nome = tdsRow.Nome;
                    }

                    if (plyDB != null)
                    {
                        if (!tdsRow.IsRoutineNull())
                        {
                            edsRow.Rou = tdsRow.Routine;
                            plyDB.Routine = tdsRow.Routine;
                        }
                        else if (plyDB.IsRoutineNull())
                            edsRow.Rou = 0M;
                        else
                            edsRow.Rou = plyDB.Routine;
                        edsRow.TI = plyDB.LastTI;
                    }
                    else
                    {
                        if (!tdsRow.IsRoutineNull())
                        {
                            edsRow.Rou = tdsRow.Routine;
                        }
                        else
                        {
                            edsRow.Rou = 0.0M;
                        }

                        edsRow.TI = 0.0M;
                    }

                    if (isReserves == -1)
                    {
                        if (plyDB != null)
                            isReserves = plyDB.isYoungTeam;
                        else
                            isReserves = 0;
                    }

                    edsRow.Nome += "|" + tdsRow.Infortunato.ToString() + "|" + tdsRow.Squalificato.ToString()
                        + "|" + isReserves.ToString();

                    edsRow.Età = tdsRow.Età;

                    if (tdsRow.IsMesiNull())
                    {
                        tdsRow.Mesi = 0;
                    }

                    if (plyDB != null)
                    {
                        TmWeek age = TmWeek.GetAge(plyDB.wBorn, DateTime.Now);
                        if (age.Years < edsRow.Età)
                        {
                            plyDB.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, tdsRow.Mesi, edsRow.Età);
                        }

                        edsRow.wBorn = plyDB.wBorn;
                    }
                    else
                        edsRow.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, tdsRow.Mesi, edsRow.Età);

                    edsRow.FP = TM_Compatible.ConvertNewFP(tdsRow.FP);

                    edsRow.FPn = Tm_Utility.FPToNumber(tdsRow.FP);

                    // edsRow.Ada = tdsRow.Ada;
                    edsRow.ASI = tdsRow.ASI;

                    if (pdsRow != null)
                    {
                        edsRow.Set = setDec(tdsRow.Cal, pdsRow.Set);
                        edsRow.Con_Uno = setDec(tdsRow.Con, pdsRow.Con_Uno);
                        edsRow.Cro_Com = setDec(tdsRow.Cro, pdsRow.Cro_Com);
                        edsRow.Fin = setDec(tdsRow.Fin, pdsRow.Fin);
                        edsRow.For = setDec(tdsRow.For, pdsRow.For);
                        edsRow.Mar_Pre = setDec(tdsRow.Mar, pdsRow.Mar_Pre);
                        edsRow.Pas_Ele = setDec(tdsRow.Pas, pdsRow.Pas_Ele);
                        edsRow.Pos_Aer = setDec(tdsRow.Pos, pdsRow.Pos_Aer);
                        edsRow.Res = setDec(tdsRow.Res, pdsRow.Res);
                        edsRow.Tec_Tir = setDec(tdsRow.Tec, pdsRow.Tec_Tir);
                        edsRow.Tes_Lan = setDec(tdsRow.Tes, pdsRow.Tes_Lan);
                        edsRow.Lon = setDec(tdsRow.Tir, pdsRow.Lon);
                        edsRow.Vel = setDec(tdsRow.Vel, pdsRow.Vel);
                        edsRow.Wor_Rif = setDec(tdsRow.Wor, pdsRow.Wor_Rif);
                    }
                    else
                    {
                        edsRow.Set = tdsRow.Cal;
                        edsRow.Con_Uno = tdsRow.Con;
                        edsRow.Cro_Com = tdsRow.Cro;
                        edsRow.Fin = tdsRow.Fin;
                        edsRow.For = tdsRow.For;
                        edsRow.Mar_Pre = tdsRow.Mar;
                        edsRow.Pas_Ele = tdsRow.Pas;
                        edsRow.Pos_Aer = tdsRow.Pos;
                        edsRow.Res = tdsRow.Res;
                        edsRow.Tec_Tir = tdsRow.Tec;
                        edsRow.Tes_Lan = tdsRow.Tes;
                        edsRow.Lon = tdsRow.Tir;
                        edsRow.Vel = tdsRow.Vel;
                        edsRow.Wor_Rif = tdsRow.Wor;
                    }

                    edsRow.InFormazione = tdsRow.InFormazione;
                    edsRow.Infortunato = tdsRow.Infortunato;
                    edsRow.Squalificato = tdsRow.Squalificato;

                    edsRow.Rec = tdsRow.Rec;

                    edsRow.HidSk = plyDB.GetHidSkString();

                    edsRow.SetFP(fun);

                    if (isNew) this.GiocatoriNSkill.Rows.Add(edsRow);
                }

                foreach (Db_TrophyDataSet.PortieriRow tdsRow in tds.Portieri)
                {
                    isNew = false;

                    ExtTMDataSet2.GiocatoriNSkillRow edsRow = this.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);

                    if (edsRow == null)
                    {
                        edsRow = this.GiocatoriNSkill.NewGiocatoriNSkillRow();
                        edsRow.PlayerID = tdsRow.PlayerID;
                        isNew = true;
                    }

                    ExtraDS.GiocatoriRow plyDB = null;
                    if (PlayersDS != null)
                    {
                        plyDB = PlayersDS.Giocatori.FindByPlayerID(edsRow.PlayerID);
                    }

                    ExtTMDataSet2.GiocatoriNSkillRow pdsRow = null;
                    if (prevDS != null) pdsRow = prevDS.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);

                    edsRow.Numero = tdsRow.Numero;
                    edsRow.Nationality = tdsRow.Nationality;

                    if (!edsRow.IsNomeNull())
                    {
                        string eds_nome = edsRow.Nome.Split('|')[0];
                        if (eds_nome.Length > tdsRow.Nome.Length)
                            edsRow.Nome = eds_nome;
                        else
                        {
                            edsRow.Nome = tdsRow.Nome.Replace("\r\n", "").Replace(" ", "").Replace(".", ". ");
                        }

                        edsRow.Nome = HTML_Parser.ConvertHTML_Text(edsRow.Nome);
                    }
                    else
                    {
                        edsRow.Nome = tdsRow.Nome.Replace("\r\n", "").Replace(" ", "").Replace(".", ". ");
                    }

                    if (plyDB != null)
                    {
                        if (!tdsRow.IsRoutineNull())
                        {
                            edsRow.Rou = tdsRow.Routine;
                            plyDB.Routine = tdsRow.Routine;
                        }
                        else if (plyDB.IsRoutineNull())
                            edsRow.Rou = 0M;
                        else
                            edsRow.Rou = plyDB.Routine;
                        edsRow.TI = plyDB.LastTI;
                    }
                    else
                    {
                        if (!tdsRow.IsRoutineNull())
                        {
                            edsRow.Rou = tdsRow.Routine;
                        }
                        else
                        {
                            edsRow.Rou = 0.0M;
                        }
                        edsRow.TI = 0.0M;
                    }

                    if (isReserves == -1)
                    {
                        if (plyDB != null)
                            isReserves = plyDB.isYoungTeam;
                        else
                            isReserves = 0;
                    }

                    edsRow.Nome += "|" + tdsRow.Infortunato.ToString() + "|" + tdsRow.Squalificato.ToString()
                        + "|" + isReserves.ToString();

                    edsRow.Età = tdsRow.Età;

                    if (plyDB != null)
                    {
                        TmWeek age = TmWeek.GetAge(plyDB.wBorn, DateTime.Now);
                        if (age.Years < edsRow.Età)
                        {
                            plyDB.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, tdsRow.Mesi, edsRow.Età);
                        }

                        edsRow.wBorn = plyDB.wBorn;
                    }
                    else
                        edsRow.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, tdsRow.Mesi, edsRow.Età);

                    edsRow.ASI = tdsRow.ASI;

                    if (pdsRow != null)
                    {
                        edsRow.For = setDec(tdsRow.For, pdsRow.For);
                        edsRow.Res = setDec(tdsRow.Res, pdsRow.Res);
                        edsRow.Vel = setDec(tdsRow.Vel, pdsRow.Vel);
                        edsRow.Tec_Tir = setDec(tdsRow.Tir, pdsRow.Tec_Tir);
                        edsRow.Pos_Aer = setDec(tdsRow.Aer, pdsRow.Pos_Aer);
                        edsRow.Cro_Com = setDec(tdsRow.Com, pdsRow.Cro_Com);
                        edsRow.Pas_Ele = setDec(tdsRow.Ele, pdsRow.Pas_Ele);
                        edsRow.Tes_Lan = setDec(tdsRow.Lan, pdsRow.Tes_Lan);
                        edsRow.Mar_Pre = setDec(tdsRow.Pre, pdsRow.Mar_Pre);
                        edsRow.Wor_Rif = setDec(tdsRow.Rif, pdsRow.Wor_Rif);
                        edsRow.Con_Uno = setDec(tdsRow.Uno, pdsRow.Con_Uno);
                    }
                    else
                    {
                        edsRow.For = tdsRow.For;
                        edsRow.Res = tdsRow.Res;
                        edsRow.Vel = tdsRow.Vel;
                        edsRow.Tec_Tir = tdsRow.Tir;
                        edsRow.Pos_Aer = tdsRow.Aer;
                        edsRow.Cro_Com = tdsRow.Com;
                        edsRow.Pas_Ele = tdsRow.Ele;
                        edsRow.Tes_Lan = tdsRow.Lan;
                        edsRow.Mar_Pre = tdsRow.Pre;
                        edsRow.Wor_Rif = tdsRow.Rif;
                        edsRow.Con_Uno = tdsRow.Uno;
                    }

                    edsRow.InFormazione = false;
                    edsRow.Infortunato = 0;
                    edsRow.Squalificato = 0;

                    edsRow.Rec = tdsRow.Rec;

                    try
                    {
                        edsRow.InFormazione = tdsRow.InFormazione;
                        edsRow.Infortunato = tdsRow.Infortunato;
                        edsRow.Squalificato = tdsRow.Squalificato;
                    }
                    catch (Exception)
                    {
                    }

                    edsRow.SetFP(fun);

                    if (isNew) this.GiocatoriNSkill.Rows.Add(edsRow);
                }
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                string info = "";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(ApplicationFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                PlayersDS.WriteXml(fi.FullName);

                StreamReader file = new StreamReader(fi.FullName);
                info += "PlayersDS:\r\n" + file.ReadToEnd();
                file.Close();

                tds.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "\r\nTDS:\r\n" + file.ReadToEnd();
                file.Close();

                fun.gds.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "\r\nGDS:\r\n" + file.ReadToEnd();
                file.Close();

                if (prevDS != null)
                {
                    prevDS.WriteXml(fi.FullName);

                    file = new StreamReader(fi.FullName);
                    info += "prevDS:\r\n" + file.ReadToEnd();
                    file.Close();
                }
                else
                {
                    info += "prevDS: is null\r\n";
                }

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
            }
        }

        public void FillWithDb_TrophyDataSet_NewTM(ExtraDS PlayersDS,
                                                Db_TrophyDataSet tds,
                                                Gain_Function fun,
                                                ExtTMDataSet2 prevDS,
                                                string ApplicationFolder)
        {
            try
            {
                this.Date = tds.Date;
                bool isNew = false;

                foreach (Db_TrophyDataSet.GiocatoriRow tdsRow in tds.Giocatori)
                {
                    isNew = false;

                    ExtTMDataSet2.GiocatoriNSkillRow edsRow = this.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);

                    if (edsRow == null)
                    {
                        edsRow = this.GiocatoriNSkill.NewGiocatoriNSkillRow();
                        edsRow.PlayerID = tdsRow.PlayerID;
                        isNew = true;
                    }

                    ExtTMDataSet2.GiocatoriNSkillRow pdsRow = null;
                    if (prevDS != null) pdsRow = prevDS.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);

                    ExtraDS.GiocatoriRow plyDB = null;
                    if (PlayersDS != null)
                    {
                        plyDB = PlayersDS.Giocatori.FindByPlayerID(edsRow.PlayerID);

                        if ((plyDB == null) || (plyDB.IsTeamNull()))
                            edsRow.Team = "A";
                        else
                            edsRow.Team = plyDB.Team;
                    }
                    else
                    {
                        edsRow.Team = "A";
                    }

                    edsRow.Numero = tdsRow.Numero;
                    edsRow.Nationality = tdsRow.Nationality;

                    if (!edsRow.IsNomeNull())
                    {
                        string eds_nome = edsRow.Nome.Split('|')[0];
                        if (eds_nome.Length > tdsRow.Nome.Length)
                            edsRow.Nome = eds_nome;
                        else
                            edsRow.Nome = tdsRow.Nome;
                        edsRow.Nome = HTML_Parser.ConvertHTML_Text(edsRow.Nome);
                    }
                    else
                    {
                        edsRow.Nome = tdsRow.Nome;
                    }

                    if (plyDB != null)
                    {
                        if (!tdsRow.IsRoutineNull())
                        {
                            edsRow.Rou = tdsRow.Routine;
                            plyDB.Routine = tdsRow.Routine;
                        }
                        else if (plyDB.IsRoutineNull())
                            edsRow.Rou = 0M;
                        else
                            edsRow.Rou = plyDB.Routine;
                        edsRow.TI = plyDB.LastTI;
                    }
                    else
                    {
                        if (!tdsRow.IsRoutineNull())
                        {
                            edsRow.Rou = tdsRow.Routine;
                        }
                        else
                        {
                            edsRow.Rou = 0.0M;
                        }

                        edsRow.TI = 0.0M;
                    }

                    edsRow.Nome += "|" + tdsRow.Infortunato.ToString() + "|" + tdsRow.Squalificato.ToString()
                        + "|" + tdsRow.IsReserve.ToString() + "|" + tdsRow.Retire.ToString();

                    edsRow.Età = tdsRow.Età;

                    if (plyDB != null)
                    {
                        TmWeek age = TmWeek.GetAge(plyDB.wBorn, DateTime.Now);
                        if (age.Years < edsRow.Età)
                        {
                            plyDB.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, 0, edsRow.Età);
                        }

                        edsRow.wBorn = plyDB.wBorn;
                    }
                    else
                        edsRow.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, 0, edsRow.Età);

                    edsRow.FP = tdsRow.FP;
                    edsRow.FPn = Tm_Utility.FPToNumber(tdsRow.FP);

                    // edsRow.Ada = tdsRow.Ada;
                    edsRow.ASI = tdsRow.ASI;

                    if (pdsRow != null)
                    {
                        edsRow.Set = setDec(tdsRow.Cal, pdsRow.Set);
                        edsRow.Con_Uno = setDec(tdsRow.Con, pdsRow.Con_Uno);
                        edsRow.Cro_Com = setDec(tdsRow.Cro, pdsRow.Cro_Com);
                        edsRow.Fin = setDec(tdsRow.Fin, pdsRow.Fin);
                        edsRow.For = setDec(tdsRow.For, pdsRow.For);
                        edsRow.Mar_Pre = setDec(tdsRow.Mar, pdsRow.Mar_Pre);
                        edsRow.Pas_Ele = setDec(tdsRow.Pas, pdsRow.Pas_Ele);
                        edsRow.Pos_Aer = setDec(tdsRow.Pos, pdsRow.Pos_Aer);
                        edsRow.Res = setDec(tdsRow.Res, pdsRow.Res);
                        edsRow.Tec_Tir = setDec(tdsRow.Tec, pdsRow.Tec_Tir);
                        edsRow.Tes_Lan = setDec(tdsRow.Tes, pdsRow.Tes_Lan);
                        edsRow.Lon = setDec(tdsRow.Tir, pdsRow.Lon);
                        edsRow.Vel = setDec(tdsRow.Vel, pdsRow.Vel);
                        edsRow.Wor_Rif = setDec(tdsRow.Wor, pdsRow.Wor_Rif);
                    }
                    else
                    {
                        edsRow.Set = tdsRow.Cal;
                        edsRow.Con_Uno = tdsRow.Con;
                        edsRow.Cro_Com = tdsRow.Cro;
                        edsRow.Fin = tdsRow.Fin;
                        edsRow.For = tdsRow.For;
                        edsRow.Mar_Pre = tdsRow.Mar;
                        edsRow.Pas_Ele = tdsRow.Pas;
                        edsRow.Pos_Aer = tdsRow.Pos;
                        edsRow.Res = tdsRow.Res;
                        edsRow.Tec_Tir = tdsRow.Tec;
                        edsRow.Tes_Lan = tdsRow.Tes;
                        edsRow.Lon = tdsRow.Tir;
                        edsRow.Vel = tdsRow.Vel;
                        edsRow.Wor_Rif = tdsRow.Wor;
                    }

                    edsRow.InFormazione = tdsRow.InFormazione;
                    edsRow.Infortunato = tdsRow.Infortunato;
                    edsRow.Squalificato = tdsRow.Squalificato;

                    edsRow.Wage = tdsRow.Wage;
                    if (plyDB != null)
                    {
                        plyDB.Wage = tdsRow.Wage;
                        plyDB.AvRating = (float)tdsRow.Rating;
                        edsRow.HidSk = plyDB.GetHidSkString();
                    }

                    edsRow.SetFP(fun);
                    edsRow.Rec = tdsRow.Rec;


                    if (isNew) this.GiocatoriNSkill.Rows.Add(edsRow);
                }

                foreach (Db_TrophyDataSet.PortieriRow tdsRow in tds.Portieri)
                {
                    isNew = false;

                    ExtTMDataSet2.GiocatoriNSkillRow edsRow = this.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);

                    if (edsRow == null)
                    {
                        edsRow = this.GiocatoriNSkill.NewGiocatoriNSkillRow();
                        edsRow.PlayerID = tdsRow.PlayerID;
                        isNew = true;
                    }

                    ExtraDS.GiocatoriRow plyDB = null;
                    if (PlayersDS != null)
                    {
                        plyDB = PlayersDS.Giocatori.FindByPlayerID(edsRow.PlayerID);
                    }

                    ExtTMDataSet2.GiocatoriNSkillRow pdsRow = null;
                    if (prevDS != null) pdsRow = prevDS.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);

                    edsRow.Numero = tdsRow.Numero;
                    edsRow.Nationality = tdsRow.Nationality;

                    if (!edsRow.IsNomeNull())
                    {
                        string eds_nome = edsRow.Nome.Split('|')[0];
                        if (eds_nome.Length > tdsRow.Nome.Length)
                            edsRow.Nome = eds_nome;
                        else
                        {
                            edsRow.Nome = tdsRow.Nome;
                        }

                        edsRow.Nome = HTML_Parser.ConvertHTML_Text(edsRow.Nome);
                    }
                    else
                    {
                        edsRow.Nome = tdsRow.Nome;
                    }


                    if (plyDB != null)
                    {
                        if (!tdsRow.IsRoutineNull())
                        {
                            edsRow.Rou = tdsRow.Routine;
                            plyDB.Routine = tdsRow.Routine;
                        }
                        else if (plyDB.IsRoutineNull())
                            edsRow.Rou = 0M;
                        else
                            edsRow.Rou = plyDB.Routine;
                        edsRow.TI = plyDB.LastTI;
                    }
                    else
                    {
                        if (!tdsRow.IsRoutineNull())
                        {
                            edsRow.Rou = tdsRow.Routine;
                        }
                        else
                        {
                            edsRow.Rou = 0.0M;
                        }
                        edsRow.TI = 0.0M;
                    }

                    edsRow.Nome += "|" + tdsRow.Infortunato.ToString() + "|" + tdsRow.Squalificato.ToString()
                        + "|" + tdsRow.IsReserve.ToString() + "|" + tdsRow.Retire.ToString();

                    edsRow.Età = tdsRow.Età;

                    if (plyDB != null)
                    {
                        TmWeek age = TmWeek.GetAge(plyDB.wBorn, DateTime.Now);
                        if (age.Years < edsRow.Età)
                        {
                            plyDB.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, 0, edsRow.Età);
                        }

                        edsRow.wBorn = plyDB.wBorn;
                    }
                    else
                        edsRow.wBorn = TmWeek.GetBornWeekFromAge(DateTime.Now, 0, edsRow.Età);

                    edsRow.ASI = tdsRow.ASI;

                    if (pdsRow != null)
                    {
                        edsRow.For = setDec(tdsRow.For, pdsRow.For);
                        edsRow.Res = setDec(tdsRow.Res, pdsRow.Res);
                        edsRow.Vel = setDec(tdsRow.Vel, pdsRow.Vel);
                        edsRow.Tec_Tir = setDec(tdsRow.Tir, pdsRow.Tec_Tir);
                        edsRow.Pos_Aer = setDec(tdsRow.Aer, pdsRow.Pos_Aer);
                        edsRow.Cro_Com = setDec(tdsRow.Com, pdsRow.Cro_Com);
                        edsRow.Pas_Ele = setDec(tdsRow.Ele, pdsRow.Pas_Ele);
                        edsRow.Tes_Lan = setDec(tdsRow.Lan, pdsRow.Tes_Lan);
                        edsRow.Mar_Pre = setDec(tdsRow.Pre, pdsRow.Mar_Pre);
                        edsRow.Wor_Rif = setDec(tdsRow.Rif, pdsRow.Wor_Rif);
                        edsRow.Con_Uno = setDec(tdsRow.Uno, pdsRow.Con_Uno);
                    }
                    else
                    {
                        edsRow.For = tdsRow.For;
                        edsRow.Res = tdsRow.Res;
                        edsRow.Vel = tdsRow.Vel;
                        edsRow.Tec_Tir = tdsRow.Tir;
                        edsRow.Pos_Aer = tdsRow.Aer;
                        edsRow.Cro_Com = tdsRow.Com;
                        edsRow.Pas_Ele = tdsRow.Ele;
                        edsRow.Tes_Lan = tdsRow.Lan;
                        edsRow.Mar_Pre = tdsRow.Pre;
                        edsRow.Wor_Rif = tdsRow.Rif;
                        edsRow.Con_Uno = tdsRow.Uno;
                    }

                    edsRow.Wage = tdsRow.Wage;
                    if (plyDB != null)
                    {
                        plyDB.Wage = tdsRow.Wage;
                        plyDB.AvRating = (float)tdsRow.Rating;
                    }

                    edsRow.InFormazione = false;
                    edsRow.Infortunato = 0;
                    edsRow.Squalificato = 0;

                    try
                    {
                        edsRow.InFormazione = tdsRow.InFormazione;
                        edsRow.Infortunato = tdsRow.Infortunato;
                        edsRow.Squalificato = tdsRow.Squalificato;
                    }
                    catch (Exception)
                    {
                    }

                    edsRow.SetFP(fun);
                    edsRow.Rec = tdsRow.Rec;

                    if (isNew) this.GiocatoriNSkill.Rows.Add(edsRow);
                }
            }
            catch (Exception e)
            {
                string swRelease = "Sw Release:" + Application.ProductName + "("
                    + Application.ProductVersion + ")";
                string info = "";

                string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + ".tmreport.txt";
                string pathfilename = Path.Combine(ApplicationFolder, filename);
                FileInfo fi = new FileInfo(pathfilename);

                PlayersDS.WriteXml(fi.FullName);

                StreamReader file = new StreamReader(fi.FullName);
                info += "PlayersDS:\r\n" + file.ReadToEnd();
                file.Close();

                tds.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "\r\nTDS:\r\n" + file.ReadToEnd();
                file.Close();

                fun.gds.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "\r\nGDS:\r\n" + file.ReadToEnd();
                file.Close();

                prevDS.WriteXml(fi.FullName);

                file = new StreamReader(fi.FullName);
                info += "prevDS:\r\n" + file.ReadToEnd();
                file.Close();

                ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
            }
        }

        partial class PlayerHistoryRow : System.Data.DataRow
        {
            #region redefinition skills

            public decimal Pre
            {
                get { return Mar_Pre; }
                set { Mar_Pre = value; }
            }

            public decimal Mar
            {
                get { return Mar_Pre; }
                set { Mar_Pre = value; }
            }

            public decimal Con
            {
                get { return Con_Uno; }
                set { Con_Uno = value; }
            }

            public decimal Uno
            {
                get { return Con_Uno; }
                set { Con_Uno = value; }
            }

            public decimal Wor
            {
                get { return Wor_Rif; }
                set { Wor_Rif = value; }
            }

            public decimal Rif
            {
                get { return Wor_Rif; }
                set { Wor_Rif = value; }
            }

            public decimal Pas
            {
                get { return Pas_Ele; }
                set { Pas_Ele = value; }
            }

            public decimal Ele
            {
                get { return Pas_Ele; }
                set { Pas_Ele = value; }
            }

            public decimal Pos
            {
                get { return Pos_Aer; }
                set { Pos_Aer = value; }
            }

            public decimal Aer
            {
                get { return Pos_Aer; }
                set { Pos_Aer = value; }
            }

            public decimal Cro
            {
                get { return Cro_Com; }
                set { Cro_Com = value; }
            }

            public decimal Com
            {
                get { return Cro_Com; }
                set { Cro_Com = value; }
            }

            public decimal Tec
            {
                get { return Tec_Tir; }
                set { Tec_Tir = value; }
            }

            public decimal Tir
            {
                get { return Tec_Tir; }
                set { Tec_Tir = value; }
            }

            public decimal Tes
            {
                get { return Tes_Lan; }
                set { Tes_Lan = value; }
            }

            public decimal Lan
            {
                get { return Tes_Lan; }
                set { Tes_Lan = value; }
            }

            public float GK
            {
                get { return DC_GK; }
                set { DC_GK = value; }
            }

            public float DC
            {
                get { return DC_GK; }
                set { DC_GK = value; }
            }

            #endregion
        }

        partial class GiocatoriNSkillRow : System.Data.DataRow
        {
            bool isDirty = false;

            // Speciality FP amplification
            float[,] A = new float[,]{  {1.666f,1.331f,1.331f,1.496f,1.166f,1.166f,1.336f,1.000f,1.000f,1.167f,1.000f,1.000f,1.000f},
                                        {1.331f,1.666f,1.500f,1.164f,1.500f,1.331f,1.166f,1.337f,1.167f,1.000f,1.333f,1.167f,1.000f},
                                        {1.331f,1.500f,1.666f,1.164f,1.331f,1.500f,1.166f,1.167f,1.337f,1.000f,1.167f,1.333f,1.000f},
                                        {1.498f,1.166f,1.166f,1.664f,1.331f,1.331f,1.502f,1.167f,1.167f,1.335f,1.000f,1.000f,1.000f},
                                        {1.164f,1.500f,1.331f,1.332f,1.666f,1.500f,1.000f,1.504f,1.337f,1.000f,1.333f,1.167f,1.000f},
                                        {1.164f,1.331f,1.500f,1.332f,1.500f,1.666f,1.000f,1.337f,1.504f,1.000f,1.167f,1.333f,1.000f},
                                        {1.331f,1.000f,1.000f,1.496f,1.166f,1.166f,1.668f,1.337f,1.337f,1.498f,1.167f,1.167f,1.332f},
                                        {1.000f,1.331f,1.166f,1.164f,1.500f,1.331f,1.336f,1.670f,1.504f,1.167f,1.500f,1.333f,1.000f},
                                        {1.000f,1.166f,1.331f,1.164f,1.331f,1.500f,1.336f,1.504f,1.670f,1.167f,1.333f,1.500f,1.000f},
                                        {1.164f,1.000f,1.000f,1.332f,1.000f,1.000f,1.502f,1.167f,1.167f,1.665f,1.333f,1.333f,1.502f},
                                        {1.000f,1.166f,1.000f,1.000f,1.331f,1.166f,1.166f,1.504f,1.337f,1.335f,1.667f,1.500f,1.166f},
                                        {1.000f,1.000f,1.166f,1.000f,1.166f,1.331f,1.166f,1.337f,1.504f,1.335f,1.500f,1.667f,1.166f},
                                        {1.000f,1.000f,1.000f,1.164f,1.000f,1.000f,1.336f,1.000f,1.000f,1.498f,1.167f,1.167f,1.668f}};

            // Skill FP Gain
            float[,] K_Pl = new float[,] { {4.000f,3.000f,3.000f,2.880f,3.000f,3.000f,2.000f,1.560f,1.560f,1.910f,2.630f,2.630f,4.240f},
                                        {0.330f,0.430f,0.430f,1.680f,0.430f,0.430f,2.000f,1.560f,1.560f,0.270f,2.630f,2.630f,2.470f},
                                        {4.000f,5.140f,5.140f,1.680f,5.140f,5.140f,0.290f,2.670f,2.670f,0.270f,4.500f,4.500f,2.470f},
                                        {4.000f,5.140f,5.140f,2.880f,5.140f,5.140f,3.430f,2.670f,2.670f,1.910f,0.380f,0.380f,0.350f},
                                        {4.000f,5.140f,5.140f,2.880f,5.140f,5.140f,3.430f,2.670f,2.670f,1.910f,0.380f,0.380f,0.350f},
                                        {0.330f,0.430f,0.430f,2.880f,0.430f,0.430f,3.430f,2.670f,2.670f,3.270f,2.630f,2.630f,2.470f},
                                        {0.330f,0.430f,0.430f,2.880f,0.430f,0.430f,3.430f,2.670f,2.670f,3.270f,2.630f,2.630f,2.470f},
                                        {2.330f,3.000f,3.000f,2.880f,3.000f,3.000f,3.430f,2.670f,2.670f,3.270f,0.380f,0.380f,0.350f},
                                        {2.330f,3.000f,3.000f,1.680f,3.000f,3.000f,0.290f,2.670f,2.670f,0.270f,4.500f,4.500f,0.350f},
                                        {2.330f,3.000f,3.000f,1.680f,3.000f,3.000f,3.430f,2.670f,2.670f,3.270f,4.500f,4.500f,2.470f},
                                        {4.000f,3.000f,3.000f,2.880f,3.000f,3.000f,2.000f,1.560f,1.560f,1.910f,2.630f,2.630f,4.240f},
                                        {0.330f,0.430f,0.430f,0.240f,0.430f,0.430f,0.290f,0.220f,0.220f,3.270f,2.630f,2.630f,4.240f},
                                        {0.330f,0.430f,0.430f,0.240f,0.430f,0.430f,0.290f,0.220f,0.220f,3.270f,2.630f,2.630f,4.240f},
                                        {0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f}};

            float[,] K_Gk = new float[,] { { 6.3636f, 0f, 6.3636f, 11.8181f, 6.3636f, 10.9090f, 6.3636f, 6.3636f, 0f, 0f, 0f } };

            float[,] K
            {
                get
                {
                    if (FPn == 0)
                        return K_Gk;
                    else
                        return K_Pl;
                }
            }



            int[] skillCol_Pl = new int[] { 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            int[] skillCol_Gk = new int[] { 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 17, 17, 17 };

            int[] skillCol
            {
                get
                {
                    if (FPn == 0)
                        return skillCol_Gk;
                    else
                        return skillCol_Pl;
                }
            }

            float[] _skills = null;
            public float[] Skills
            {
                get
                {
                    float[] _skills = new float[14];

                    for (int i = 0; i < 14; i++)
                    {
                        _skills[i] = (float)((decimal)this[skillCol[i]]);
                    }

                    return _skills;
                }
            }
            public float[] Atts
            {
                get
                {
                    float[] f = new float[13];

                    f[0] = DC_GK;
                    f[1] = DR;
                    f[2] = DL;
                    f[3] = DMC;
                    f[4] = DMR;
                    f[5] = DML;
                    f[6] = MC;
                    f[7] = MR;
                    f[8] = ML;
                    f[9] = OMC;
                    f[10] = OMR;
                    f[11] = OML;
                    f[12] = FC;

                    return f;
                }
                set
                {
                    float[] f = value;

                    DC_GK = f[0];
                    DR = f[1];
                    DL = f[2];
                    DMC = f[3];
                    DMR = f[4];
                    DML = f[5];
                    MC = f[6];
                    MR = f[7];
                    ML = f[8];
                    OMC = f[9];
                    OMR = f[10];
                    OML = f[11];
                    FC = f[12];
                }
            }

            public float MaxAtts()
            {
                float max = 0;
                max = (DL > max) ? DL : max;
                max = (DR > max) ? DR : max;
                max = (DC_GK > max) ? DC_GK : max;
                max = (DML > max) ? DML : max;
                max = (DMR > max) ? DMR : max;
                max = (DMC > max) ? DMC : max;
                max = (ML > max) ? ML : max;
                max = (MR > max) ? MR : max;
                max = (MC > max) ? MC : max;
                max = (OML > max) ? OML : max;
                max = (OMR > max) ? OMR : max;
                max = (OMC > max) ? OMC : max;
                max = (FC > max) ? FC : max;
                return max / 5;
            }

            public float MaxAttsToStar(float a)
            {
                return (a - 2.0f) / 3.0f;
            }

            public void SetFP(Gain_Function PosF)
            {
                if (!IsFPNull())
                    FPn = Tm_Utility.FPToNumber(FP);
                else
                {
                    FPn = 0;
                    FP = "GK";
                }

                if (FPn == 0)
                {
                    SetFP_Gk(PosF);
                    return;
                }

                if (IsAdaNull())
                    Ada = 0;
                else if (Ada > 0)
                    Ada = Ada + 0;

                Atts = PosF.GetAttitude(Skills, this.FP, (float)this.Rou, (float)this.Ada);
                OSi = PosF.GetOSi_PL(Atts, Skills);

                float kRou = PosF.gds.funRou.Value((float)Rou);

                decimal SSD = Tm_Utility.ASItoSkSum((decimal)this.ASI, false) - this.SkillSum;
                CStr = (decimal)MaxAttsToStar(MaxAtts() / kRou * (float)((SkillSum + SSD) / SkillSum));
            }

            public void SetFP_Gk(Gain_Function PosF)
            {
                Atts = PosF.GetAttitude_GK(Skills, (float)this.Rou);
                OSi = PosF.GetOSi_GK(Atts, Skills);

                float kRou = PosF.gds.funRou.Value((float)Rou);

                decimal SSD = Tm_Utility.ASItoSkSum((decimal)this.ASI, true) - this.SkillSum;
                CStr = (decimal)MaxAttsToStar(MaxAtts() / kRou * (float)((SkillSum + SSD) / SkillSum));
            }

            public decimal SkillSum
            {
                get
                {
                    if (FPn == 0)
                        return For + Res + Vel + Mar_Pre + Con_Uno + Wor_Rif + Pas_Ele + Pos_Aer + Cro_Com +
                        Tec_Tir + Tes_Lan;
                    else
                        return For + Res + Vel + Mar_Pre + Con_Uno + Wor_Rif + Pas_Ele + Pos_Aer + Cro_Com +
                        Tec_Tir + Tes_Lan + Fin + Set + Lon;
                }
            }

            public decimal Mar
            {
                get { return Mar_Pre; }
                set { Mar_Pre = value; }
            }

            #region redefinition skills

            public decimal Pre
            {
                get { return Mar_Pre; }
                set { Mar_Pre = value; }
            }

            public decimal Con
            {
                get { return Con_Uno; }
                set { Con_Uno = value; }
            }

            public decimal Uno
            {
                get { return Con_Uno; }
                set { Con_Uno = value; }
            }

            public decimal Wor
            {
                get { return Wor_Rif; }
                set { Wor_Rif = value; }
            }

            public decimal Rif
            {
                get { return Wor_Rif; }
                set { Wor_Rif = value; }
            }

            public decimal Pas
            {
                get { return Pas_Ele; }
                set { Pas_Ele = value; }
            }

            public decimal Ele
            {
                get { return Pas_Ele; }
                set { Pas_Ele = value; }
            }

            public decimal Pos
            {
                get { return Pos_Aer; }
                set { Pos_Aer = value; }
            }

            public decimal Aer
            {
                get { return Pos_Aer; }
                set { Pos_Aer = value; }
            }

            public decimal Cro
            {
                get { return Cro_Com; }
                set { Cro_Com = value; }
            }

            public decimal Com
            {
                get { return Cro_Com; }
                set { Cro_Com = value; }
            }

            public decimal Tec
            {
                get { return Tec_Tir; }
                set { Tec_Tir = value; }
            }

            public decimal Tir
            {
                get { return Tec_Tir; }
                set { Tec_Tir = value; }
            }

            public decimal Tes
            {
                get { return Tes_Lan; }
                set { Tes_Lan = value; }
            }

            public decimal Lan
            {
                get { return Tes_Lan; }
                set { Tes_Lan = value; }
            }

            public float GK
            {
                get { return DC_GK; }
                set { DC_GK = value; }
            }

            public float DC
            {
                get { return DC_GK; }
                set { DC_GK = value; }
            }

            public float PO
            {
                get { return DC_GK; }
                set { DC_GK = value; }
            }

            #endregion

            public string ToExcelString()
            {
                string row = "";

                for (int i = 0; i < 22; i++)
                {
                    row += this[i].ToString() + "\t";
                }

                return row;
            }

            public float GetSkVal(string position)
            {
                if (position == "") return 0.0f;
                string p2 = position.Substring(0, 2);
                string p3 = (position.Length > 2) ? position.Substring(0, 3) : p2;

                return
                (p2 == "DC_GK") ? DC_GK :
                (p2 == "DL") ? DL :
                (p2 == "DR") ? DR :
                (p2 == "MC") ? MC :
                (p2 == "ML") ? ML :
                (p2 == "MR") ? MR :
                (p2 == "FC") ? FC :
                (p3 == "DMC") ? DMC :
                (p3 == "DMR") ? DMR :
                (p3 == "DML") ? DML :
                (p3 == "OMC") ? OMC :
                (p3 == "OMR") ? OMR :
                (p3 == "OML") ? OML : 0.0f;
            }
        }

        public void RecalculateSpecData(Gain_Function fun)
        {
            foreach (ExtTMDataSet2.GiocatoriNSkillRow gnsRow in this.GiocatoriNSkill)
            {
                gnsRow.SetFP(fun);
            }
        }

        public void RecalculateSpecData(Gain_Function fun, int plyID)
        {
            ExtTMDataSet2.GiocatoriNSkillRow gnsRow = GiocatoriNSkill.FindByPlayerID(plyID);
            if (gnsRow != null)
                gnsRow.SetFP(fun);
        }

        public DB_TrophyDataSet2 Get_TDS2()
        {
            DB_TrophyDataSet2 tds = new DB_TrophyDataSet2();

            tds.Date = this.Date;

            foreach (ExtTMDataSet2.GiocatoriNSkillRow tdsRow in this.GiocatoriNSkill)
            {
                DB_TrophyDataSet2.GiocatoriRow edsRow = tds.Giocatori.NewGiocatoriRow();

                edsRow.PlayerID = tdsRow.PlayerID;
                edsRow.Età = tdsRow.Età;
                edsRow.ASI = tdsRow.ASI;

                edsRow.Con = tdsRow.Con_Uno;
                edsRow.Cro = tdsRow.Cro_Com;
                edsRow.For = tdsRow.For;
                edsRow.Mar = tdsRow.Mar_Pre;
                edsRow.Pas = tdsRow.Pas_Ele;
                edsRow.Pos = tdsRow.Pos_Aer;
                edsRow.Res = tdsRow.Res;
                edsRow.Tec = tdsRow.Tec_Tir;
                edsRow.Tes = tdsRow.Tes_Lan;
                edsRow.Vel = tdsRow.Vel;
                edsRow.Wor = tdsRow.Wor_Rif;

                if (tdsRow.FPn != 0)
                {
                    edsRow.Tir = tdsRow.Lon;
                    edsRow.Fin = tdsRow.Fin;
                    edsRow.Cal = tdsRow.Set;
                }

                edsRow.InFormazione = tdsRow.InFormazione;
                edsRow.Infortunato = tdsRow.Infortunato;
                edsRow.Squalificato = tdsRow.Squalificato;

                tds.Giocatori.AddGiocatoriRow(edsRow);
            }

            return tds;
        }

        /// <summary>
        /// Update the players database with info from the DB_TDS read from file
        /// </summary>
        /// <param name="PlayersDS">Player's database</param>
        /// <param name="tds">DB_TDS read from file</param>
        /// <param name="gds">Gain Data set</param>
        public void FillWithDb_TrophyDataSet2(ExtraDS PlayersDS,
                                                DB_TrophyDataSet2 tds,
                                                Gain_Function fun,
                                                string ApplicationFolder)
        {
            this.Date = tds.Date;
            int errorCount = 0;

            foreach (DB_TrophyDataSet2.GiocatoriRow tdsRow in tds.Giocatori)
            {
                try
                {
                    ExtTMDataSet2.GiocatoriNSkillRow edsRow = this.GiocatoriNSkill.NewGiocatoriNSkillRow();
                    edsRow.PlayerID = tdsRow.PlayerID;

                    ExtraDS.GiocatoriRow plyDB = PlayersDS.Giocatori.FindByPlayerID(edsRow.PlayerID);

                    if (plyDB == null) continue;

                    edsRow.Numero = plyDB.Numero;
                    edsRow.Nationality = plyDB.Nationality;
                    edsRow.Nome = plyDB.Nome;

                    if (plyDB.IsisYoungTeamNull()) plyDB.isYoungTeam = 0;
                    edsRow.Nome += "|" + tdsRow.Infortunato.ToString() + "|" + tdsRow.Squalificato.ToString()
                                 + "|" + plyDB.isYoungTeam.ToString();

                    edsRow.FP = plyDB.FP;
                    edsRow.FPn = Tm_Utility.FPToNumber(edsRow.FP);
                    if (edsRow.FPn == -1) continue;

                    edsRow.Ada = plyDB.Ada;

                    if (plyDB.IsTeamNull())
                        plyDB.Team = "A";
                    edsRow.Team = plyDB.Team;

                    if (plyDB.IsWageNull())
                        plyDB.Wage = 0;

                    edsRow.ASI = tdsRow.ASI;

                    plyDB.Wage = Tm_Utility.ASItoWage(plyDB.ASI);
                    edsRow.Wage = Tm_Utility.ASItoWage(edsRow.ASI);

                    edsRow.Età = tdsRow.Età;
                    edsRow.Con = tdsRow.Con;
                    edsRow.Cro = tdsRow.Cro;
                    edsRow.For = tdsRow.For;
                    edsRow.Mar = tdsRow.Mar;
                    edsRow.Pas = tdsRow.Pas;
                    edsRow.Pos = tdsRow.Pos;
                    edsRow.Res = tdsRow.Res;
                    edsRow.Tec = tdsRow.Tec;
                    edsRow.Tes = tdsRow.Tes;
                    edsRow.Vel = tdsRow.Vel;
                    edsRow.Wor = tdsRow.Wor;

                    if (edsRow.FPn != 0)
                    {
                        edsRow.Set = tdsRow.Cal;
                        edsRow.Lon = tdsRow.Tir;
                        edsRow.Fin = tdsRow.Fin;
                    }

                    if (!tdsRow.IsRecNull())
                        edsRow.Rec = tdsRow.Rec;
                    else if (!plyDB.IsRecNull())
                        edsRow.Rec = plyDB.Rec;
                    else
                        edsRow.Rec = 0M;

                    if (!plyDB.IsRoutineNull())
                        edsRow.Rou = plyDB.Routine;
                    else
                        edsRow.Rou = 0;

                    edsRow.TI = plyDB.LastTI;

                    int wDiff = TmWeek.GetTmAbsWk(DateTime.Now) - TmWeek.GetTmAbsWk(this.Date);
                    if (!plyDB.IswBornNull())
                        edsRow.wBorn = plyDB.wBorn + wDiff;
                    else
                    {
                        edsRow.wBorn = TmWeek.GetBornWeekFromAge(this.Date, 0, edsRow.Età);
                    }

                    edsRow.InFormazione = tdsRow.InFormazione;
                    edsRow.Infortunato = tdsRow.Infortunato;
                    edsRow.Squalificato = tdsRow.Squalificato;

                    edsRow.SetFP(fun);

                    edsRow.HidSk = plyDB.GetHidSkString();

                    this.GiocatoriNSkill.Rows.Add(edsRow);
                }
                catch (Exception e)
                {
                    string info = "";
                    errorCount++;
                    if (errorCount > 1) continue;

                    string swRelease = "Sw Release:" + Application.ProductName + "("
                        + Application.ProductVersion + ")";

                    string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                        DateTime.Now.Minute.ToString() + ".tmreport.txt";
                    string pathfilename = Path.Combine(ApplicationFolder, filename);
                    FileInfo fi = new FileInfo(pathfilename);

                    PlayersDS.WriteXml(fi.FullName);

                    StreamReader file = new StreamReader(fi.FullName);
                    info += "PlayersDS:\r\n" + file.ReadToEnd();
                    file.Close();

                    tds.WriteXml(fi.FullName);

                    file = new StreamReader(fi.FullName);
                    info += "\r\nTDS:\r\n" + file.ReadToEnd();
                    file.Close();

                    ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                }
            }

            foreach (DB_TrophyDataSet2.PortieriRow tdsRow in tds.Portieri)
            {
                try
                {
                    ExtTMDataSet2.GiocatoriNSkillRow edsRow = this.GiocatoriNSkill.NewGiocatoriNSkillRow();
                    edsRow.PlayerID = tdsRow.PlayerID;

                    ExtraDS.GiocatoriRow plyDB = PlayersDS.Giocatori.FindByPlayerID(tdsRow.PlayerID);
                    if (plyDB == null) continue;

                    edsRow.Numero = plyDB.Numero;
                    edsRow.Nationality = plyDB.Nationality;
                    edsRow.Nome = plyDB.Nome;

                    if (plyDB.IsisYoungTeamNull()) plyDB.isYoungTeam = 0;
                    edsRow.Nome += "|" + tdsRow.Infortunato.ToString() + "|" + tdsRow.Squalificato.ToString()
                        + "|" + plyDB.isYoungTeam.ToString();

                    if (plyDB.IsWageNull())
                        plyDB.Wage = 0;
                    edsRow.ASI = tdsRow.ASI;

                    edsRow.Wage = Tm_Utility.ASItoWage(edsRow.ASI);

                    edsRow.Età = tdsRow.Età;
                    edsRow.For = tdsRow.For;
                    edsRow.Res = tdsRow.Res;
                    edsRow.Tir = tdsRow.Tir;
                    edsRow.Vel = tdsRow.Vel;
                    edsRow.Aer = tdsRow.Aer;
                    edsRow.Com = tdsRow.Com;
                    edsRow.Ele = tdsRow.Ele;
                    edsRow.Lan = tdsRow.Lan;
                    edsRow.Pre = tdsRow.Pre;
                    edsRow.Rif = tdsRow.Rif;
                    edsRow.Uno = tdsRow.Uno;

                    if (!tdsRow.IsRecNull())
                        edsRow.Rec = tdsRow.Rec;
                    else if (!plyDB.IsRecNull())
                        edsRow.Rec = plyDB.Rec;
                    else
                        edsRow.Rec = 0M;

                    if (!plyDB.IsRoutineNull())
                        edsRow.Rou = plyDB.Routine;
                    else
                        edsRow.Rou = 0;
                    edsRow.TI = plyDB.LastTI;

                    int wDiff = TmWeek.GetTmAbsWk(DateTime.Now) - TmWeek.GetTmAbsWk(this.Date);
                    if (!plyDB.IswBornNull())
                        edsRow.wBorn = plyDB.wBorn + wDiff;
                    else
                    {
                        edsRow.wBorn = TmWeek.GetBornWeekFromAge(this.Date, 0, edsRow.Età);
                    }

                    edsRow.InFormazione = tdsRow.InFormazione;
                    edsRow.Infortunato = tdsRow.Infortunato;
                    edsRow.Squalificato = tdsRow.Squalificato;

                    edsRow.SetFP(fun);

                    this.GiocatoriNSkill.Rows.Add(edsRow);
                }
                catch (Exception e)
                {
                    string info = "";
                    errorCount++;
                    if (errorCount > 1) continue;

                    string swRelease = "Sw Release:" + Application.ProductName + "("
                        + Application.ProductVersion + ")";

                    string filename = "dbinfo." + DateTime.Now.Hour.ToString() +
                        DateTime.Now.Minute.ToString() + ".tmreport.txt";
                    string pathfilename = Path.Combine(ApplicationFolder, filename);
                    FileInfo fi = new FileInfo(pathfilename);

                    PlayersDS.WriteXml(fi.FullName);

                    StreamReader file = new StreamReader(fi.FullName);
                    info += "PlayersDS:\r\n" + file.ReadToEnd();
                    file.Close();

                    tds.WriteXml(fi.FullName);

                    file = new StreamReader(fi.FullName);
                    info += "\r\nTDS:\r\n" + file.ReadToEnd();
                    file.Close();

                    ErrorReport.Send(e, info, Environment.StackTrace, swRelease);
                }
            }
        }

        public void MovePlayerToOtherTeam(int ID, string team)
        {
            GiocatoriNSkillRow gr = GiocatoriNSkill.FindByPlayerID(ID);
            gr.Team = team;
        }


        public void LoadBidAlarms()
        {
            throw new NotImplementedException();
        }

        public bool CheckPendingAlarms()
        {
            throw new NotImplementedException();
        }

        public void RecalculateSpecData(GainDS GD)
        {
            throw new NotImplementedException();
        }

        public void AddEndBidAlarm(DataGridViewRow row)
        {
            throw new NotImplementedException();
        }
    }

}

