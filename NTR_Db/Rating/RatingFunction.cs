using NTR_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTR_Db
{
    public class Rating
    {
        public const int numPos = 14;
        public double[] rec = new double[numPos]; // REC
        public double[] rating = new double[numPos]; // REC
        public double[] ratingR = new double[numPos]; // REC + routine

        public double CK { get; internal set; }
        public double FK { get; internal set; }
        public double PK { get; internal set; }

        public double GetRec(int FPn)
        {
            int[] posIndex = GetPositionIndex(FPn);

            double Rec1 = this.rec[posIndex[0]];

            if (posIndex.Length > 1 && posIndex[1] != -1)
            {
                return Math.Max(Rec1, rec[posIndex[1]]);
            }
            else
            {
                return Rec1;
            }
        }

        public static int[] GetPositionIndex(int FPn)
        {
            if (FPn == 0) return new int[] { 13, -1 };

            return Common.Tm_Utility.FPnToFPvector(FPn);
        }

        public Rating()
        {
            for (int i = 0; i < numPos; i++)
            {
                rec[i] = 0;
                rating[i] = 0;
                ratingR[i] = 0;
            }
        }

        public static Rating Max(Rating R1, Rating R2)
        {
            Rating max = new Rating();

            for (int i = 0; i < numPos; i++)
            {
                max.rec[i] = Math.Max(R1.rec[i], R2.rec[i]);
                max.rating[i] = Math.Max(R1.rating[i], R2.rating[i]);
                max.ratingR[i] = Math.Max(R1.ratingR[i], R2.ratingR[i]);
            }

            return max;
        }

        public static Rating Max(Rating[] R)
        {
            if (R.Length == 1)
                return R[0];

            Rating max = new Rating();

            for (int i = 0; i < numPos; i++)
            {
                max.rec[i] = Math.Max(R[0].rec[i], R[1].rec[i]);
                max.rating[i] = Math.Max(R[0].rating[i], R[1].rating[i]);
                max.ratingR[i] = Math.Max(R[0].ratingR[i], R[1].ratingR[i]);
            }

            return max;
        }

        public static List<REC_Weights> WeightsMatrixToTable(double[,] weightRat)
        {
            List<REC_Weights> recWeightsList = new List<REC_Weights>();

            for (int row=0; row<weightRat.GetLength(0); row++)
            {
                REC_Weights recWeight = new REC_Weights(weightRat, row);
                recWeightsList.Add(recWeight);
            }

            return recWeightsList;
        }
            
    }

    public enum eSkill
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

    public enum eSkillGK
    {
        Str,
        Sta,
        Pac,
        Han,
        One,
        Ref,
        Aer,
        Jum,
        Com,
        Kic,
        Thr,
        Max
    }

    public class REC_Weights
    {
        public REC_Weights(double[,] weightRat, int col)
        {
            Skill = ((eSkill)col).ToString();

            if (col < (int)eSkillGK.Max)
                SkillGk = ((eSkillGK)col).ToString();
            else
                SkillGk = "-";

            DC = weightRat[0, col];
            DL = weightRat[1, col];
            DR = weightRat[2, col];
            DMC = weightRat[3, col];
            DML = weightRat[4, col];
            DMR = weightRat[5, col];
            MC = weightRat[6, col];
            ML = weightRat[7, col];
            MR = weightRat[8, col];
            OMC = weightRat[9, col];
            OML = weightRat[10, col];
            OMR = weightRat[11, col];
            FC = weightRat[12, col];
            GK = weightRat[13, col];
        }

        string Skill { get; }
        double DC { get; set; }
        double DL { get; set; }
        double DR { get; set; }
        double DMC { get; set; }
        double DML { get; set; }
        double DMR { get; set; }
        double MC { get; set; }
        double ML { get; set; }
        double MR { get; set; }
        double OMC { get; set; }
        double OML { get; set; }
        double OMR { get; set; }
        double FC { get; set; }
        string SkillGk { get; }
        double GK { get; set; }
    }

    public abstract class RatingFunction
    {
        public static double[,] adaFact = new double[,] {
            {1f,0.8f,0.8f,0.9f,0.7f,0.7f,0.8f,0.6f,0.6f,0.7f,0.6f,0.6f,0.6f},
            {0.8f,1f,0.9f,0.7f,0.9f,0.8f,0.7f,0.8f,0.7f,0.6f,0.8f,0.7f,0.6f},
            {0.8f,0.9f,1f,0.7f,0.8f,0.9f,0.7f,0.7f,0.8f,0.6f,0.7f,0.8f,0.6f},
            {0.9f,0.7f,0.7f,1f,0.8f,0.8f,0.9f,0.7f,0.7f,0.8f,0.6f,0.6f,0.6f},
            {0.7f,0.9f,0.8f,0.8f,1f,0.9f,0.6f,0.9f,0.8f,0.6f,0.8f,0.7f,0.6f},
            {0.7f,0.8f,0.9f,0.8f,0.9f,1f,0.6f,0.8f,0.9f,0.6f,0.7f,0.8f,0.6f},
            {0.8f,0.6f,0.6f,0.9f,0.7f,0.7f,1f,0.8f,0.8f,0.9f,0.7f,0.7f,0.8f},
            {0.6f,0.8f,0.7f,0.7f,0.9f,0.8f,0.8f,1f,0.9f,0.7f,0.9f,0.8f,0.6f},
            {0.6f,0.7f,0.8f,0.7f,0.8f,0.9f,0.8f,0.9f,1f,0.7f,0.8f,0.9f,0.6f},
            {0.7f,0.6f,0.6f,0.8f,0.6f,0.6f,0.9f,0.7f,0.7f,1f,0.8f,0.8f,0.9f},
            {0.6f,0.7f,0.6f,0.6f,0.8f,0.7f,0.7f,0.9f,0.8f,0.8f,1f,0.9f,0.7f},
            {0.6f,0.6f,0.7f,0.6f,0.7f,0.8f,0.7f,0.8f,0.9f,0.8f,0.9f,1f,0.7f},
            {0.6f,0.6f,0.6f,0.7f,0.6f,0.6f,0.8f,0.6f,0.6f,0.9f,0.7f,0.7f,1f}};

        public abstract string Name { get; }
        public abstract string ShortName { get; }

        public abstract double[,] GetWeightRat();
        public abstract Rating ComputeRating(PlayerDataSkills playerData);
    }
}
