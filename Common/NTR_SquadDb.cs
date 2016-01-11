using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Common
{

    public partial class NTR_SquadDb
    {
        partial class PlayerDataTable
        {
            public void ReadSafeXml(string fullName)
            {
                this.DataSet.EnforceConstraints = false;
                ReadXml(fullName);

                Dictionary<int, NTR_SquadDb.PlayerRow> listDuplicates = new Dictionary<int, NTR_SquadDb.PlayerRow>();

                foreach (NTR_SquadDb.PlayerRow player in this)
                {
                    var playersFound = (from c in this
                                        where c.PlayerID == player.PlayerID
                                        select c);

                    if (playersFound.Count() > 1)
                    {
                        if (!listDuplicates.ContainsKey(player.PlayerID))
                            listDuplicates.Add(player.PlayerID, player);
                    }
                }

                foreach (var item in listDuplicates)
                {
                    RemovePlayerRow(item.Value);
                }

                if (listDuplicates.Count > 0)
                    WriteXml(fullName);

                this.DataSet.EnforceConstraints = true;
            }
        }

        partial class ActionsDataTable
        {
            public void WriteXmlBySeason(string dirPath)
            {
                var actionTable = new NTR_SquadDb.ActionsDataTable();

                NTR_SquadDb ds = (NTR_SquadDb)DataSet;

                foreach (int seasons in ds.SeasonsWithData)
                {
                    DateTime startDate = TmWeek.GetDateTimeOfSeasonStart((int)seasons);
                    DateTime endDate = startDate.AddDays(7 * 12);

                    var selectedSeasonActions = (from c in this
                                                 where c.MatchRow.Date >= startDate && c.MatchRow.Date < endDate
                                                 select c);

                    actionTable.Clear();

                    foreach (var row in selectedSeasonActions)
                    {
                        ActionsRow ar = actionTable.NewActionsRow();
                        ar.ItemArray = row.ItemArray;
                        actionTable.AddActionsRow(ar);
                    }

                    FileInfo fi = new FileInfo(Path.Combine(dirPath, string.Format("Actions-Season{0}.5.xml", seasons)));
                    actionTable.WriteXml(fi.FullName);
                }
            }
        }

        partial class HistDataDataTable
        {
            public void WriteXmlBySeason(string dirPath)
            {
                var histTable = new NTR_SquadDb.HistDataDataTable();

                NTR_SquadDb ds = (NTR_SquadDb)DataSet;

                foreach (int seasons in ds.SeasonsWithData)
                {
                    int startWeek = TmWeek.GetWeekOfSeasonStart((int)seasons);
                    int endWeek = startWeek + 12;

                    var selectedSeasonActions = (from c in this
                                                 where c.Week >= startWeek && c.Week < endWeek
                                                 select c);

                    histTable.Clear();

                    foreach (var row in selectedSeasonActions)
                    {
                        HistDataRow hrow = histTable.NewHistDataRow();
                        hrow.ItemArray = row.ItemArray;
                        histTable.AddHistDataRow(hrow);
                    }

                    FileInfo fi = new FileInfo(Path.Combine(dirPath, string.Format("HistData-Season{0}.5.xml", seasons)));
                    histTable.WriteXml(fi.FullName);
                }
            }

        }

        partial class MatchDataTable
        {
        }

        public NTR_Gains GDS { get; set; }

        public bool LoadGains(string gainSetName)
        {
            if (GDS == null)
                GDS = new NTR_Gains();

            FileInfo fi = new FileInfo(gainSetName);

            if (fi.Exists)
            {
                GDS.Clear();

                try
                {
                    GDS.ReadXml(gainSetName);
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("The read of the Gain set " +
                        gainSetName + " has generated an error. The default gainset has been selected.\n Please change the gain set using the Options panel");
                    GDS.SetDefaultValues();
                    return false;
                }

                GDS.GainDSfilename = gainSetName;
                return true;
            }
            else
            {
                GDS.SetDefaultValues();
                return false;
            }
        }

        public void Invalidate()
        {
            _weeksWithData = null;
            _seasonsWithData = null;
        }

        private List<int> _weeksWithData = null;
        public List<int> WeeksWithData
        {
            get
            {
                if (_weeksWithData == null)
                {
                    _weeksWithData = new List<int>();

                    var dates = (from c in HistData
                                 group c by c.Week into g
                                 select g).OrderByDescending(p => p.Key);

                    foreach (var date in dates)
                        _weeksWithData.Add((int)date.Key);

                    var matches = (from c in Match
                                   group c by TmWeek.GetTmAbsWk(c.Date) into g
                                   select g).OrderByDescending(p => p.Key);

                    foreach (var match in matches)
                    {
                        if (!_weeksWithData.Contains(match.Key))
                            _weeksWithData.Add(match.Key);
                    }
                }

                return _weeksWithData;
            }
        }

        private List<int> _seasonsWithData = null;
        public List<int> SeasonsWithData
        {
            get
            {
                if (_seasonsWithData == null)
                {
                    _seasonsWithData = new List<int>();

                    foreach (var week in WeeksWithData)
                    {
                        int season = TmWeek.GetSeasonFromWeek(week);
                        if (!_seasonsWithData.Contains(season))
                        {
                            _seasonsWithData.Add(season);
                        }
                    }
                }

                return _seasonsWithData;
            }
        }

        partial class HistDataDataTable
        {
        }

        public partial class HistDataRow
        {
            public decimal TI
            {
                get { return _TI; }
                set { _TI = value; }
            }

            public decimal For
            {
                get { return _For; }
                set { _For = value; }
            }
            public decimal Res
            {
                get { return _Res; }
                set { _Res = value; }
            }
            public decimal Vel
            {
                get { return _Vel; }
                set { _Vel = value; }
            }
            public decimal Mar
            {
                get { return _Mar_Pre; }
                set { _Mar_Pre = value; }
            }
            public decimal Cro
            {
                get { return _Cro_Com; }
                set { _Cro_Com = value; }
            }
            public decimal Con
            {
                get { return _Con_Uno; }
                set { _Con_Uno = value; }
            }
            public decimal Pas
            {
                get { return _Pas_Ele; }
                set { _Pas_Ele = value; }
            }
            public decimal Pos
            {
                get { return _Pos_Aer; }
                set { _Pos_Aer = value; }
            }
            public decimal Tec
            {
                get { return _Tec_Tir; }
                set { _Tec_Tir = value; }
            }
            public decimal Tes
            {
                get { return _Tes_Lan; }
                set { _Tes_Lan = value; }
            }
            public decimal Wor
            {
                get { return _Wor_Rif; }
                set { _Wor_Rif = value; }
            }
            public decimal Pre
            {
                get { return _Mar_Pre; }
                set { _Mar_Pre = value; }
            }
            public decimal Com
            {
                get { return _Cro_Com; }
                set { _Cro_Com = value; }
            }
            public decimal Uno
            {
                get { return _Con_Uno; }
                set { _Con_Uno = value; }
            }
            public decimal Ele
            {
                get { return _Pas_Ele; }
                set { _Pas_Ele = value; }
            }
            public decimal Aer
            {
                get { return _Pos_Aer; }
                set { _Pos_Aer = value; }
            }
            public decimal Tir
            {
                get { return _Tec_Tir; }
                set { _Tec_Tir = value; }
            }
            public decimal Lan
            {
                get { return _Tes_Lan; }
                set { _Tes_Lan = value; }
            }
            public decimal Rif
            {
                get { return _Wor_Rif; }
                set { _Wor_Rif = value; }
            }
            public decimal Fin
            {
                get { return _Fin; }
                set { _Fin = value; }
            }
            public decimal Cal
            {
                get { return _Cal; }
                set { _Cal = value; }
            }
            public decimal Dis
            {
                get { return _Dis; }
                set { _Dis = value; }
            }

            public DateTime Date
            {
                get { return TmWeek.TmWeekToDate(Week); }
            }
        }

        partial class ScoutReviewDataTable
        {
        }

        public partial class PlayerRow : global::System.Data.DataRow
        {
            //[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            //[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            //public int DC
            //{
            //    get
            //    {
            //        return ((int)(this[this.tablePlayer.PlayerIDColumn]));
            //    }
            //}

        }

        //internal void UpdateDecimals(Content content)
        //{
        //    int newWeek = content.Week;

        //    // Find the closest week to the input week
        //    int closestWeek = -1;
        //    foreach (int week in this.WeeksWithData)
        //    {
        //        if (week >= newWeek) continue;

        //        if (newWeek - week < newWeek - closestWeek)
        //            closestWeek = week;
        //    }

        //    if (closestWeek == -1)
        //        return;

        //    foreach (PlayerRow playerRow in content.squadDB.Player)
        //    {
        //        int idPlayer = playerRow.PlayerID;

        //        // Get relative history rows
        //        HistDataRow newRow = HistData.FindByPlayerIDWeek(idPlayer, newWeek);
        //        HistDataRow oldRow = HistData.FindByPlayerIDWeek(idPlayer, closestWeek);

        //        if (oldRow == null)
        //            continue;

        //        int numSkillToUpdate = (playerRow.FPn == 0) ? 11 : 14;
        //        for (int i = 0; i < numSkillToUpdate; i++)
        //        {
        //            int trainStep = Tm_Training.TrCode2ToTrValue(newRow.Training, (Tm_Training.eTrainingType)(i + 1));

        //            if (trainStep == 1)
        //                newRow[4 + i] = (decimal)oldRow[4 + i] + 0.1M;
        //            else if (trainStep == -1)
        //                newRow[4 + i] = (decimal)oldRow[4 + i] - 0.1M;
        //            else if (trainStep == 0)
        //                newRow[4 + i] = (decimal)oldRow[4 + i];
        //        }
        //    }
        //}

        public void UpdateDecimalsHistory()
        {
            for (int week = WeeksWithData.Count - 2; week >= 0; week--)
            {
                int newWeek = WeeksWithData[week];
                int closestWeek = WeeksWithData[week + 1];

                foreach (PlayerRow playerRow in Player)
                {
                    int idPlayer = playerRow.PlayerID;

                    // Get relative history rows
                    HistDataRow newRow = HistData.FindByPlayerIDWeek(idPlayer, newWeek);
                    HistDataRow oldRow = HistData.FindByPlayerIDWeek(idPlayer, closestWeek);

                    if (newRow == null)
                        continue;
                    if (oldRow == null)
                        continue;

                    int numSkillToUpdate = (playerRow.FPn == 0) ? 11 : 14;
                    for (int i = 0; i < numSkillToUpdate; i++)
                    {
                        int trainStep;

                        if (newRow.IsTrainingNull())
                            trainStep = 0;
                        else
                            trainStep = Tm_Training.TrCode2ToTrValue(newRow.Training, (Tm_Training.eTrainingType)(i + 1));

                        if (trainStep == 1)
                            newRow[4 + i] = (decimal)oldRow[4 + i] + 0.1M;
                        else if (trainStep == -1)
                            newRow[4 + i] = (decimal)oldRow[4 + i] - 0.1M;
                        else if (trainStep == 0)
                            newRow[4 + i] = (decimal)oldRow[4 + i];
                    }
                }
            }
        }
    }


}
