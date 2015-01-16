using Common;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NTR_Db
{
}
namespace NTR_Db
{
}
namespace NTR_Db {

    public partial class NTR_SquadDb 
    {
        public NTR_Common.GainDS GDS { get; set; }

        private List<int> _weeksWithData = null;
        public List<int> WeeksWithData
        {
            get
            {
                if ((_weeksWithData == null) || (_weeksWithData.Count != HistData.Count))
                {
                    _weeksWithData = new List<int>();

                    var dates = (from c in HistData
                                 group c by c.Week into g
                                 select g).OrderByDescending(p => p.Key);

                    foreach (var date in dates)
                        _weeksWithData.Add((int)date.Key);
                }

                return _weeksWithData;
            }
        }

        partial class HistDataDataTable
        {
        }
    
        public partial class HistDataRow
        {
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
        }

       partial class ScoutReviewDataTable
        {
        }
    
        public partial class PlayerRow: global::System.Data.DataRow
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

        internal void UpdateDecimals(Content content)
        {
            int newWeek = content.Week;

            // Find the closest week to the input week
            int closestWeek = -1;
            foreach(int week in this.WeeksWithData)
            {
                if (week >= newWeek) continue;

                if (newWeek - week < newWeek - closestWeek)
                    closestWeek = week;
            }

            foreach(PlayerRow playerRow in content.squadDB.Player)
            {
                int idPlayer = playerRow.PlayerID;

                // Get relative history rows
                HistDataRow newRow = HistData.FindByPlayerIDWeek(idPlayer, newWeek);
                HistDataRow oldRow = HistData.FindByPlayerIDWeek(idPlayer, closestWeek);

                int numSkillToUpdate = (playerRow.FPn == 0)?11:14;
                for (int i = 0; i < numSkillToUpdate ; i++)
                {
                    int trainStep = Tm_Training.TrCode2ToTrValue(newRow.Training, (Tm_Training.eTrainingType)(i+1));

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
