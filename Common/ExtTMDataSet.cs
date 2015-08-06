using System;
// using TMRecorder.Properties;
using Common;
using SendFileTo;
using System.IO;
using System.Windows.Forms;

namespace Common {
    partial class ExtTMDataSet
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

            foreach (ExtTMDataSet.GiocatoriNSkillRow tdsRow in this.GiocatoriNSkill)
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
                edsRow.Cal = tdsRow.Cal;
                edsRow.Con = tdsRow.Con;
                edsRow.Cro = tdsRow.Cro;
                edsRow.Fin = tdsRow.Fin;
                edsRow.For = tdsRow.For;
                edsRow.Mar = tdsRow.Mar;
                edsRow.Pas = tdsRow.Pas;
                edsRow.Pos = tdsRow.Pos;
                edsRow.Res = tdsRow.Res;
                edsRow.Tec = tdsRow.Tec;
                edsRow.Tes = tdsRow.Tes;
                edsRow.Tir = tdsRow.Tir;
                edsRow.Vel = tdsRow.Vel;
                edsRow.Wor = tdsRow.Wor;
                edsRow.InFormazione = tdsRow.InFormazione;
                edsRow.Infortunato = tdsRow.Infortunato;
                edsRow.Squalificato = tdsRow.Squalificato;
                edsRow.Rec = tdsRow.Rec;

                tds.Giocatori.AddGiocatoriRow(edsRow);
            }

            foreach (ExtTMDataSet.PortieriNSkillRow pnsRow in this.PortieriNSkill)
            {
                Db_TrophyDataSet.PortieriRow edsRow = tds.Portieri.NewPortieriRow();

                edsRow.PlayerID = pnsRow.PlayerID;
                edsRow.Numero = pnsRow.Numero;
                edsRow.Nationality = pnsRow.Nationality;
                edsRow.Nome = pnsRow.Nome;
                edsRow.Età = pnsRow.Età;
                edsRow.ASI = pnsRow.ASI;

                edsRow.For = pnsRow.For;
                edsRow.Res = pnsRow.Res;
                edsRow.Tir = pnsRow.Tir;
                edsRow.Vel = pnsRow.Vel;
                edsRow.Aer = pnsRow.Aer;
                edsRow.Com = pnsRow.Com;
                edsRow.Ele = pnsRow.Ele;
                edsRow.Lan = pnsRow.Lan;
                edsRow.Pre = pnsRow.Pre;
                edsRow.Rif = pnsRow.Rif;
                edsRow.Uno = pnsRow.Uno;

                edsRow.InFormazione = pnsRow.InFormazione;
                edsRow.Infortunato = pnsRow.Infortunato;
                edsRow.Squalificato = pnsRow.Squalificato;
                edsRow.Rec = pnsRow.Rec;

                tds.Portieri.AddPortieriRow(edsRow);
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
                                                ExtTMDataSet extTMDataSet)
        {
            foreach (TrainingDataSet.GiocatoriRow tdsRow in tds.Giocatori)
            {
                ExtTMDataSet.GiocatoriNSkillRow edsRow = this.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);
                ExtTMDataSet.GiocatoriNSkillRow refRow = extTMDataSet.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);

                if (edsRow == null) continue;
                if (refRow == null) continue;

                // Bisogna aggiungere ad ogni skill (byte alto) il contributo legato alla crescita
                // in modo che possa essere facilmente estratto e immesso senza che si creino sovrapposizioni
                edsRow.Cal = trInc(edsRow.Cal, tdsRow.Cal, refRow.Cal);
                edsRow.Con = trInc(edsRow.Con, tdsRow.Con, refRow.Con);
                edsRow.Cro = trInc(edsRow.Cro, tdsRow.Cro, refRow.Cro);
                edsRow.Fin = trInc(edsRow.Fin, tdsRow.Fin, refRow.Fin);
                edsRow.For = trInc(edsRow.For, tdsRow.For, refRow.For);
                edsRow.Mar = trInc(edsRow.Mar, tdsRow.Mar, refRow.Mar);
                edsRow.Pas = trInc(edsRow.Pas, tdsRow.Pas, refRow.Pas);
                edsRow.Pos = trInc(edsRow.Pos, tdsRow.Pos, refRow.Pos);
                edsRow.Res = trInc(edsRow.Res, tdsRow.Res, refRow.Res);
                edsRow.Tec = trInc(edsRow.Tec, tdsRow.Tec, refRow.Tec);
                edsRow.Tes = trInc(edsRow.Tes, tdsRow.Tes, refRow.Tes);
                edsRow.Tir = trInc(edsRow.Tir, tdsRow.Tir, refRow.Tir);
                edsRow.Vel = trInc(edsRow.Vel, tdsRow.Vel, refRow.Vel);
                edsRow.Wor = trInc(edsRow.Wor, tdsRow.Wor, refRow.Wor);
            }

            foreach (TrainingDataSet.PortieriRow tdsRow in tds.Portieri)
            {
                ExtTMDataSet.PortieriNSkillRow edsRow = this.PortieriNSkill.FindByPlayerID(tdsRow.PlayerID);
                ExtTMDataSet.PortieriNSkillRow refRow = extTMDataSet.PortieriNSkill.FindByPlayerID(tdsRow.PlayerID);

                if (edsRow == null) continue;
                if (refRow == null) continue;

                edsRow.For = trInc(edsRow.For, tdsRow.For, refRow.For);
                edsRow.Res = trInc(edsRow.Res, tdsRow.Res, refRow.Res);
                edsRow.Tir = trInc(edsRow.Tir, tdsRow.Tir, refRow.Tir);
                edsRow.Vel = trInc(edsRow.Vel, tdsRow.Vel, refRow.Vel);
                edsRow.Aer = trInc(edsRow.Aer, tdsRow.Aer, refRow.Aer);
                edsRow.Com = trInc(edsRow.Com, tdsRow.Com, refRow.Com);
                edsRow.Ele = trInc(edsRow.Ele, tdsRow.Ele, refRow.Ele);
                edsRow.Lan = trInc(edsRow.Lan, tdsRow.Lan, refRow.Lan);
                edsRow.Pre = trInc(edsRow.Pre, tdsRow.Pre, refRow.Pre);
                edsRow.Rif = trInc(edsRow.Rif, tdsRow.Rif, refRow.Rif);
                edsRow.Uno = trInc(edsRow.Uno, tdsRow.Uno, refRow.Uno);
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
                                                ExtTMDataSet extTMDataSet)
        {
            foreach (TrainingDataSet.GiocatoriRow tdsRow in tds.Giocatori)
            {
                ExtTMDataSet.GiocatoriNSkillRow edsRow = this.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);
                ExtTMDataSet.GiocatoriNSkillRow refRow = extTMDataSet.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);

                if (edsRow == null) continue;
                if (refRow == null) continue;

                // Bisogna aggiungere ad ogni skill (byte alto) il contributo legato alla crescita
                // in modo che possa essere facilmente estratto e immesso senza che si creino sovrapposizioni
                edsRow.Cal = trDec(edsRow.Cal, tdsRow.Cal, refRow.Cal);
                edsRow.Con = trDec(edsRow.Con, tdsRow.Con, refRow.Con);
                edsRow.Cro = trDec(edsRow.Cro, tdsRow.Cro, refRow.Cro);
                edsRow.Fin = trDec(edsRow.Fin, tdsRow.Fin, refRow.Fin);
                edsRow.For = trDec(edsRow.For, tdsRow.For, refRow.For);
                edsRow.Mar = trDec(edsRow.Mar, tdsRow.Mar, refRow.Mar);
                edsRow.Pas = trDec(edsRow.Pas, tdsRow.Pas, refRow.Pas);
                edsRow.Pos = trDec(edsRow.Pos, tdsRow.Pos, refRow.Pos);
                edsRow.Res = trDec(edsRow.Res, tdsRow.Res, refRow.Res);
                edsRow.Tec = trDec(edsRow.Tec, tdsRow.Tec, refRow.Tec);
                edsRow.Tes = trDec(edsRow.Tes, tdsRow.Tes, refRow.Tes);
                edsRow.Tir = trDec(edsRow.Tir, tdsRow.Tir, refRow.Tir);
                edsRow.Vel = trDec(edsRow.Vel, tdsRow.Vel, refRow.Vel);
                edsRow.Wor = trDec(edsRow.Wor, tdsRow.Wor, refRow.Wor);
            }

            foreach (TrainingDataSet.PortieriRow tdsRow in tds.Portieri)
            {
                ExtTMDataSet.PortieriNSkillRow edsRow = this.PortieriNSkill.FindByPlayerID(tdsRow.PlayerID);
                ExtTMDataSet.PortieriNSkillRow refRow = extTMDataSet.PortieriNSkill.FindByPlayerID(tdsRow.PlayerID);

                if (edsRow == null) continue;
                if (refRow == null) continue;

                edsRow.For = trDec(edsRow.For, tdsRow.For, refRow.For);
                edsRow.Res = trDec(edsRow.Res, tdsRow.Res, refRow.Res);
                edsRow.Tir = trDec(edsRow.Tir, tdsRow.Tir, refRow.Tir);
                edsRow.Vel = trDec(edsRow.Vel, tdsRow.Vel, refRow.Vel);
                edsRow.Aer = trDec(edsRow.Aer, tdsRow.Aer, refRow.Aer);
                edsRow.Com = trDec(edsRow.Com, tdsRow.Com, refRow.Com);
                edsRow.Ele = trDec(edsRow.Ele, tdsRow.Ele, refRow.Ele);
                edsRow.Lan = trDec(edsRow.Lan, tdsRow.Lan, refRow.Lan);
                edsRow.Pre = trDec(edsRow.Pre, tdsRow.Pre, refRow.Pre);
                edsRow.Rif = trDec(edsRow.Rif, tdsRow.Rif, refRow.Rif);
                edsRow.Uno = trDec(edsRow.Uno, tdsRow.Uno, refRow.Uno);
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
                                                ExtTMDataSet prevDS,
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

                    ExtTMDataSet.GiocatoriNSkillRow edsRow = this.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);

                    if (edsRow == null)
                    {
                        edsRow = this.GiocatoriNSkill.NewGiocatoriNSkillRow();
                        edsRow.PlayerID = tdsRow.PlayerID;
                        isNew = true;
                    }

                    ExtTMDataSet.GiocatoriNSkillRow pdsRow = null;
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
                        edsRow.Cal = setDec(tdsRow.Cal, pdsRow.Cal);
                        edsRow.Con = setDec(tdsRow.Con, pdsRow.Con);
                        edsRow.Cro = setDec(tdsRow.Cro, pdsRow.Cro);
                        edsRow.Fin = setDec(tdsRow.Fin, pdsRow.Fin);
                        edsRow.For = setDec(tdsRow.For, pdsRow.For);
                        edsRow.Mar = setDec(tdsRow.Mar, pdsRow.Mar);
                        edsRow.Pas = setDec(tdsRow.Pas, pdsRow.Pas);
                        edsRow.Pos = setDec(tdsRow.Pos, pdsRow.Pos);
                        edsRow.Res = setDec(tdsRow.Res, pdsRow.Res);
                        edsRow.Tec = setDec(tdsRow.Tec, pdsRow.Tec);
                        edsRow.Tes = setDec(tdsRow.Tes, pdsRow.Tes);
                        edsRow.Tir = setDec(tdsRow.Tir, pdsRow.Tir);
                        edsRow.Vel = setDec(tdsRow.Vel, pdsRow.Vel);
                        edsRow.Wor = setDec(tdsRow.Wor, pdsRow.Wor);
                    }
                    else
                    {
                        edsRow.Cal = tdsRow.Cal;
                        edsRow.Con = tdsRow.Con;
                        edsRow.Cro = tdsRow.Cro;
                        edsRow.Fin = tdsRow.Fin;
                        edsRow.For = tdsRow.For;
                        edsRow.Mar = tdsRow.Mar;
                        edsRow.Pas = tdsRow.Pas;
                        edsRow.Pos = tdsRow.Pos;
                        edsRow.Res = tdsRow.Res;
                        edsRow.Tec = tdsRow.Tec;
                        edsRow.Tes = tdsRow.Tes;
                        edsRow.Tir = tdsRow.Tir;
                        edsRow.Vel = tdsRow.Vel;
                        edsRow.Wor = tdsRow.Wor;
                    }

                    edsRow.InFormazione = tdsRow.InFormazione;
                    edsRow.Infortunato = tdsRow.Infortunato;
                    edsRow.Squalificato = tdsRow.Squalificato;

                    edsRow.Rec = tdsRow.Rec;

                    edsRow.SetFP(fun);

                    if (isNew) this.GiocatoriNSkill.Rows.Add(edsRow);
                }

                foreach (Db_TrophyDataSet.PortieriRow tdsRow in tds.Portieri)
                {
                    isNew = false;

                    ExtTMDataSet.PortieriNSkillRow edsRow = this.PortieriNSkill.FindByPlayerID(tdsRow.PlayerID);

                    if (edsRow == null)
                    {
                        edsRow = this.PortieriNSkill.NewPortieriNSkillRow();
                        edsRow.PlayerID = tdsRow.PlayerID;
                        isNew = true;
                    }

                    ExtraDS.GiocatoriRow plyDB = null;
                    if (PlayersDS != null)
                    {
                        plyDB = PlayersDS.Giocatori.FindByPlayerID(edsRow.PlayerID);
                    }

                    ExtTMDataSet.PortieriNSkillRow pdsRow = null;
                    if (prevDS != null) pdsRow = prevDS.PortieriNSkill.FindByPlayerID(tdsRow.PlayerID);

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
                        edsRow.Tir = setDec(tdsRow.Tir, pdsRow.Tir);
                        edsRow.Vel = setDec(tdsRow.Vel, pdsRow.Vel);
                        edsRow.Aer = setDec(tdsRow.Aer, pdsRow.Aer);
                        edsRow.Com = setDec(tdsRow.Com, pdsRow.Com);
                        edsRow.Ele = setDec(tdsRow.Ele, pdsRow.Ele);
                        edsRow.Lan = setDec(tdsRow.Lan, pdsRow.Lan);
                        edsRow.Pre = setDec(tdsRow.Pre, pdsRow.Pre);
                        edsRow.Rif = setDec(tdsRow.Rif, pdsRow.Rif);
                        edsRow.Uno = setDec(tdsRow.Uno, pdsRow.Uno);
                    }
                    else
                    {
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

                    if (isNew) this.PortieriNSkill.Rows.Add(edsRow);
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
                                                ExtTMDataSet prevDS,
                                                string ApplicationFolder)
        {
            try
            {
                this.Date = tds.Date;
                bool isNew = false;

                foreach (Db_TrophyDataSet.GiocatoriRow tdsRow in tds.Giocatori)
                {
                    isNew = false;

                    ExtTMDataSet.GiocatoriNSkillRow edsRow = this.GiocatoriNSkill.FindByPlayerID(tdsRow.PlayerID);

                    if (edsRow == null)
                    {
                        edsRow = this.GiocatoriNSkill.NewGiocatoriNSkillRow();
                        edsRow.PlayerID = tdsRow.PlayerID;
                        isNew = true;
                    }

                    ExtTMDataSet.GiocatoriNSkillRow pdsRow = null;
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
                        edsRow.Cal = setDec(tdsRow.Cal, pdsRow.Cal);
                        edsRow.Con = setDec(tdsRow.Con, pdsRow.Con);
                        edsRow.Cro = setDec(tdsRow.Cro, pdsRow.Cro);
                        edsRow.Fin = setDec(tdsRow.Fin, pdsRow.Fin);
                        edsRow.For = setDec(tdsRow.For, pdsRow.For);
                        edsRow.Mar = setDec(tdsRow.Mar, pdsRow.Mar);
                        edsRow.Pas = setDec(tdsRow.Pas, pdsRow.Pas);
                        edsRow.Pos = setDec(tdsRow.Pos, pdsRow.Pos);
                        edsRow.Res = setDec(tdsRow.Res, pdsRow.Res);
                        edsRow.Tec = setDec(tdsRow.Tec, pdsRow.Tec);
                        edsRow.Tes = setDec(tdsRow.Tes, pdsRow.Tes);
                        edsRow.Tir = setDec(tdsRow.Tir, pdsRow.Tir);
                        edsRow.Vel = setDec(tdsRow.Vel, pdsRow.Vel);
                        edsRow.Wor = setDec(tdsRow.Wor, pdsRow.Wor);
                    }
                    else
                    {
                        edsRow.Cal = tdsRow.Cal;
                        edsRow.Con = tdsRow.Con;
                        edsRow.Cro = tdsRow.Cro;
                        edsRow.Fin = tdsRow.Fin;
                        edsRow.For = tdsRow.For;
                        edsRow.Mar = tdsRow.Mar;
                        edsRow.Pas = tdsRow.Pas;
                        edsRow.Pos = tdsRow.Pos;
                        edsRow.Res = tdsRow.Res;
                        edsRow.Tec = tdsRow.Tec;
                        edsRow.Tes = tdsRow.Tes;
                        edsRow.Tir = tdsRow.Tir;
                        edsRow.Vel = tdsRow.Vel;
                        edsRow.Wor = tdsRow.Wor;
                    }

                    edsRow.InFormazione = tdsRow.InFormazione;
                    edsRow.Infortunato = tdsRow.Infortunato;
                    edsRow.Squalificato = tdsRow.Squalificato;

                    edsRow.Wage = tdsRow.Wage;
                    if (plyDB != null)
                    {
                        plyDB.Wage = tdsRow.Wage;
                        plyDB.AvRating = (float)tdsRow.Rating;
                    }

                    edsRow.SetFP(fun);
                    edsRow.Rec = tdsRow.Rec;

                    if (isNew) this.GiocatoriNSkill.Rows.Add(edsRow);
                }

                foreach (Db_TrophyDataSet.PortieriRow tdsRow in tds.Portieri)
                {
                    isNew = false;

                    ExtTMDataSet.PortieriNSkillRow edsRow = this.PortieriNSkill.FindByPlayerID(tdsRow.PlayerID);

                    if (edsRow == null)
                    {
                        edsRow = this.PortieriNSkill.NewPortieriNSkillRow();
                        edsRow.PlayerID = tdsRow.PlayerID;
                        isNew = true;
                    }

                    ExtraDS.GiocatoriRow plyDB = null;
                    if (PlayersDS != null)
                    {
                        plyDB = PlayersDS.Giocatori.FindByPlayerID(edsRow.PlayerID);
                    }

                    ExtTMDataSet.PortieriNSkillRow pdsRow = null;
                    if (prevDS != null) pdsRow = prevDS.PortieriNSkill.FindByPlayerID(tdsRow.PlayerID);

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
                        edsRow.Tir = setDec(tdsRow.Tir, pdsRow.Tir);
                        edsRow.Vel = setDec(tdsRow.Vel, pdsRow.Vel);
                        edsRow.Aer = setDec(tdsRow.Aer, pdsRow.Aer);
                        edsRow.Com = setDec(tdsRow.Com, pdsRow.Com);
                        edsRow.Ele = setDec(tdsRow.Ele, pdsRow.Ele);
                        edsRow.Lan = setDec(tdsRow.Lan, pdsRow.Lan);
                        edsRow.Pre = setDec(tdsRow.Pre, pdsRow.Pre);
                        edsRow.Rif = setDec(tdsRow.Rif, pdsRow.Rif);
                        edsRow.Uno = setDec(tdsRow.Uno, pdsRow.Uno);
                    }
                    else
                    {
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

                    if (isNew) this.PortieriNSkill.Rows.Add(edsRow);
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
            float[,] K = new float[,] { {4.000f,3.000f,3.000f,2.880f,3.000f,3.000f,2.000f,1.560f,1.560f,1.910f,2.630f,2.630f,4.240f},
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

            int[] skillCol = new int[] {7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};

            public float[] Skills
            {
                get
                {
                    float[] f = new float[14];

                    for (int i = 0; i < 14; i++)
                    {
                        f[i] = (float)((decimal)this[skillCol[i]]);
                    }

                    return f;
                }
            }
            public float[] Atts
            {
                get
                {
                    float[] f = new float[13];

                    f[0] = DC;
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

                    DC = f[0];
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
                max = (DC > max) ? DC : max;
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
                FPn = Tm_Utility.FPToNumber(FP);

                if (IsAdaNull())
                    Ada = 0;
                else if (Ada > 0)
                    Ada = Ada + 0;

                Atts = PosF.GetAttitude(Skills, this.FP, (float)this.Rou, (float)this.Ada);
                OSi = PosF.GetOSi(Atts, Skills);

                float kRou = PosF.gds.funRou.Value((float)Rou);

                decimal SSD = Tm_Utility.ASItoSkSum((decimal)this.ASI, false) - this.SkillSum;
                CStr = (decimal)MaxAttsToStar(MaxAtts() / kRou * (float)((SkillSum + SSD) / SkillSum));
            }

            public decimal SkillSum
            {
                get
                {
                    return For + Res + Vel + Mar + Con + Wor + Pas + Pos + Cro +
                        Tec + Tes + Fin + Cal + Tir;
                }
            }

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
                string p3 = (position.Length > 2)? position.Substring(0, 3): p2;

                return 
                (p2 == "DC") ? DC :
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

        partial class PortieriNSkillRow : System.Data.DataRow
        {
            bool isDirty = false;

            // Skill FP Gain
            float[] K = new float[] { 6.3636f, 0f, 6.3636f, 11.8181f, 6.3636f, 10.9090f, 6.3636f, 6.3636f, 0f, 0f, 0f };

            int[] skillCol = new int[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            public float[] Skills
            {
                get
                {
                    float[] f = new float[11];

                    for (int i = 0; i < 11; i++)
                    {
                        f[i] = (float)((decimal)this[skillCol[i]]);
                    }

                    return f;
                }
            }
            public float[] Atts
            {
                get
                {
                    float[] f = new float[1];

                    f[0] = PO;

                    return f;
                }
                set
                {
                    float[] f = value;

                    PO = f[0];
                }
            }
            
            public float MaxAtts()
            {
                return PO / 5;
            }

            public float MaxAttsToStar(float a)
            {
                return (a - 2.0f) / 3.0f;
            }

            public void SetFP(Gain_Function PFun)
            {
                float[] f = new float[11];
                f = Skills;
                Atts = PFun.GetAttitude(f, "GK", (float)this.Rou, 0.0f);
                OSi = PFun.GetOSi(Atts, Skills);

                float kRou = PFun.gds.funRou.Value((float)Rou);
                
                decimal SSD = Tm_Utility.ASItoSkSum((decimal)this.ASI, true) - this.SkillSum;
                CStr = (decimal)MaxAttsToStar(MaxAtts() / kRou * (float)((SkillSum + SSD) / SkillSum));
            }

            public decimal SkillSum
            {
                get
                {
                    return For + Res + Vel + Aer + Com + Tir +
                        Ele + Lan + Pre + Rif + Uno;
                }
            }

            public string ToExcelString()
            {
                string row = "";

                for (int i = 0; i < 17; i++)
                {
                    row += this[i].ToString() + "\t";
                }

                return row;
            }

            public bool IsPPASINull()
            {
                throw new NotImplementedException();
            }

            public bool IsStartOfBloomAgeNull()
            {
                throw new NotImplementedException();
            }
        }


        public void RecalculateSpecData(Gain_Function fun)
        {
            foreach (ExtTMDataSet.GiocatoriNSkillRow gnsRow in this.GiocatoriNSkill)
            {
                gnsRow.SetFP(fun);
            }

            foreach (ExtTMDataSet.PortieriNSkillRow gnsRow in this.PortieriNSkill)
            {
                gnsRow.SetFP(fun);
            }
        }

        public void RecalculateSpecData(Gain_Function fun, int plyID)
        {
            ExtTMDataSet.GiocatoriNSkillRow gnsRow = GiocatoriNSkill.FindByPlayerID(plyID);
            if (gnsRow != null)
                gnsRow.SetFP(fun);

            ExtTMDataSet.PortieriNSkillRow pnsRow = PortieriNSkill.FindByPlayerID(plyID);
            if (pnsRow != null)
                pnsRow.SetFP(fun);
        }

        public DB_TrophyDataSet2 Get_TDS2()
        {
            DB_TrophyDataSet2 tds = new DB_TrophyDataSet2();

            tds.Date = this.Date;

            foreach (ExtTMDataSet.GiocatoriNSkillRow tdsRow in this.GiocatoriNSkill)
            {
                DB_TrophyDataSet2.GiocatoriRow edsRow = tds.Giocatori.NewGiocatoriRow();

                edsRow.PlayerID = tdsRow.PlayerID;
                edsRow.Età = tdsRow.Età;
                edsRow.ASI = tdsRow.ASI;
                edsRow.Cal = tdsRow.Cal;
                edsRow.Con = tdsRow.Con;
                edsRow.Cro = tdsRow.Cro;
                edsRow.Fin = tdsRow.Fin;
                edsRow.For = tdsRow.For;
                edsRow.Mar = tdsRow.Mar;
                edsRow.Pas = tdsRow.Pas;
                edsRow.Pos = tdsRow.Pos;
                edsRow.Res = tdsRow.Res;
                edsRow.Tec = tdsRow.Tec;
                edsRow.Tes = tdsRow.Tes;
                edsRow.Tir = tdsRow.Tir;
                edsRow.Vel = tdsRow.Vel;
                edsRow.Wor = tdsRow.Wor;
                edsRow.InFormazione = tdsRow.InFormazione;
                edsRow.Infortunato = tdsRow.Infortunato;
                edsRow.Squalificato = tdsRow.Squalificato;

                tds.Giocatori.AddGiocatoriRow(edsRow);
            }

            foreach (ExtTMDataSet.PortieriNSkillRow pnsRow in this.PortieriNSkill)
            {
                DB_TrophyDataSet2.PortieriRow edsRow = tds.Portieri.NewPortieriRow();

                edsRow.PlayerID = pnsRow.PlayerID;
                edsRow.Età = pnsRow.Età;
                edsRow.ASI = pnsRow.ASI;

                edsRow.For = pnsRow.For;
                edsRow.Res = pnsRow.Res;
                edsRow.Tir = pnsRow.Tir;
                edsRow.Vel = pnsRow.Vel;
                edsRow.Aer = pnsRow.Aer;
                edsRow.Com = pnsRow.Com;
                edsRow.Ele = pnsRow.Ele;
                edsRow.Lan = pnsRow.Lan;
                edsRow.Pre = pnsRow.Pre;
                edsRow.Rif = pnsRow.Rif;
                edsRow.Uno = pnsRow.Uno;

                edsRow.InFormazione = pnsRow.InFormazione;
                edsRow.Infortunato = pnsRow.Infortunato;
                edsRow.Squalificato = pnsRow.Squalificato;

                tds.Portieri.AddPortieriRow(edsRow);
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
                    ExtTMDataSet.GiocatoriNSkillRow edsRow = this.GiocatoriNSkill.NewGiocatoriNSkillRow();
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
                    edsRow.Cal = tdsRow.Cal;
                    edsRow.Con = tdsRow.Con;
                    edsRow.Cro = tdsRow.Cro;
                    edsRow.Fin = tdsRow.Fin;
                    edsRow.For = tdsRow.For;
                    edsRow.Mar = tdsRow.Mar;
                    edsRow.Pas = tdsRow.Pas;
                    edsRow.Pos = tdsRow.Pos;
                    edsRow.Res = tdsRow.Res;
                    edsRow.Tec = tdsRow.Tec;
                    edsRow.Tes = tdsRow.Tes;
                    edsRow.Tir = tdsRow.Tir;
                    edsRow.Vel = tdsRow.Vel;
                    edsRow.Wor = tdsRow.Wor;

                    if (!tdsRow.IsRecNull())
                        edsRow.Rec = tdsRow.Rec;
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

                    decimal professionalism = -1;
                    if (!plyDB.IsProfessionalismNull())
                        professionalism = (decimal)plyDB.Professionalism;

                    decimal leadership = -1;
                    if (!plyDB.IsLeadershipNull())
                        leadership = (decimal)plyDB.Leadership;

                    decimal injury = -1;
                    if (!plyDB.IsInjPronNull())
                        injury = plyDB.InjPron;

                    decimal aggressivity = -1;
                    if (!plyDB.IsAggressivityNull())
                        aggressivity = (decimal)plyDB.Aggressivity;

                    edsRow.HidSk = "Pro=" + professionalism +
                        ";Lea=" + leadership +
                        ";Inj=" + injury +
                        ";Agg=" + aggressivity;

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
                    ExtTMDataSet.PortieriNSkillRow edsRow = this.PortieriNSkill.NewPortieriNSkillRow();
                    edsRow.PlayerID = tdsRow.PlayerID;

                    ExtraDS.GiocatoriRow plyDB = PlayersDS.Giocatori.FindByPlayerID(edsRow.PlayerID);
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

                    this.PortieriNSkill.Rows.Add(edsRow);
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
