using NTR_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTR_Db.Tactics
{
    public class TacticsFunction
    {
        private double ComputeTactics(string type, int attacking)
        {
            decimal tactics = 0;
            if (FPn == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    tactics += Skills[i].actual * 5M / 14M;
                }
                return tactics;
            }

            string SP = Tm_Utility.FPnToFP(SPn);

            var tacticGainRows = GFun.GDS.TacticsGain.Where(p => (p.Tactics == type) && (p.DorA == attacking) && (p.FPos.Contains(SP)));

            if (tacticGainRows.Count() == 0)
            {
                for (int i = 0; i < 14; i++)
                    tactics += Skills[i].actual * 5M / 14M;
            }
            else
            {
                GainDS.TacticsGainRow gr = (GainDS.TacticsGainRow)tacticGainRows.First();
                for (int i = 0; i < 14; i++)
                    tactics += Skills[i].actual * (decimal)(float)gr[2 + i];
            }
            return tactics;
        }
    }

    public class Tactics
    {
        public enum Type
        {
            Direct,
            Wings,
            ShortPass,
            LongBalls,
            Through
        }

        public enum Position : int
        {
            Attack = 0,
            Defense = 1,
        }

        public enum Skill
        {
            Str,
            Sta,
            Pac,
            Mar,
            Tak,
            Wor,
            Pos,
            Pas,
            Cro,
            Tec,
            Hea,
            Fin,
            Lon,
            Set
        }

        public static List<TAC_PlayerWeights> WeightsMatrixToPlayerWeightsTable(Matrix weights, string[,] rules)
        {
            List<TAC_PlayerWeights> tacWeightsList = new List<TAC_PlayerWeights>();

            for (int row = 0; row < weights.Rows; row++)
            {
                TAC_PlayerWeights Weight = new TAC_PlayerWeights(weights, rules, row);
                tacWeightsList.Add(Weight);
            }

            return tacWeightsList;
        }

        internal static (Matrix weights, string[,] rules) PlayerWeightsTableToWeightsMatrix(List<TAC_PlayerWeights> tacWeightsList)
        {
            Matrix weights = new Matrix(tacWeightsList.Count, 14);

            for (int r = 0; r < weights.Rows; r++)
            {
                double[] row = tacWeightsList[r].Row;

                for (int c = 0; c < weights.Cols; c++)
                {
                    weights[r, c] = row[c];
                }
            }

            string [,] rules = new string[tacWeightsList.Count, 3];

            for (int r = 0; r < weights.Rows; r++)
            {
                rules[r, 0] = tacWeightsList[r].Tactics.ToString();
                rules[r, 1] = tacWeightsList[r].DorA.ToString();
                rules[r, 2] = tacWeightsList[r].FPos.ToString();
            }

            return (weights, rules);
        }
    }

    public class TAC_PlayerWeights
    {
        public TAC_PlayerWeights(Matrix weights, string[,] rules, int row)
        {
            Tactics = rules[row, 0];
            DorA = rules[row, 1];
            FPos = rules[row, 2];

            Str = weights[0, row];
            Sta = weights[1, row];
            Pac = weights[2, row];
            Mar = weights[3, row];
            Tac = weights[4, row];
            Wor = weights[5, row];
            Pos = weights[6, row];
            Pas = weights[7, row];
            Cro = weights[8, row];
            Tec = weights[9, row];
            Hea = weights[10, row];
            Fin = weights[11, row];
            Lon = weights[12, row];
            Set = weights[13, row];
        }

        public FormattedString Tactics { get; set; }
        public FormattedString DorA { get; set; }
        public double Str { get; set; }
        public double Sta { get; set; }
        public double Pac { get; set; }
        public double Mar { get; set; }
        public double Tac { get; set; }
        public double Wor { get; set; }
        public double Pos { get; set; }
        public double Pas { get; set; }
        public double Cro { get; set; }
        public double Tec { get; set; }
        public double Hea { get; set; }
        public double Fin { get; set; }
        public double Lon { get; set; }
        public double Set { get; set; }
        public FormattedString FPos { get; set; }

        public double[] Row => new double[]
            {Str,Sta,Pac,
            Mar,Tac,Wor,
            Pos,Pas,Cro,
            Tec,Hea,Fin,
            Lon,Set};
    }

    public class TAC_GkWeights
    {
        public TAC_GkWeights(Matrix weights, string[,] rules, int row)
        {
            Tactics = rules[row, 0];
            DorA = rules[row, 1];

            Str = weights[0, row];
            Sta = weights[1, row];
            Pac = weights[2, row];
            Han = weights[3, row];
            One = weights[4, row];
            Ref = weights[5, row];
            Aer = weights[6, row];
            Jum = weights[7, row];
            Com = weights[8, row];
            Kic = weights[9, row];
            Thr = weights[10, row];
        }

        public FormattedString Tactics { get; set; }
        public FormattedString DorA { get; set; }
        public double Str { get; set; }
        public double Sta { get; set; }
        public double Pac { get; set; }
        public double Han { get; set; }
        public double One { get; set; }
        public double Ref { get; set; }
        public double Aer { get; set; }
        public double Jum { get; set; }
        public double Com { get; set; }
        public double Kic { get; set; }
        public double Thr { get; set; }

        public double[] Row => new double[]
            {Str,Sta,Pac,
            Han,One,Ref,
            Aer,Jum,Com,
            Kic,Thr};
    }
}
