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
        public double[] recb = new double[numPos]; // REC
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

        public double GetRecB(int FPn)
        {
            int[] posIndex = GetPositionIndex(FPn);

            double Rec1 = this.recb[posIndex[0]];

            if (posIndex.Length > 1 && posIndex[1] != -1)
            {
                return Math.Max(Rec1, recb[posIndex[1]]);
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
                recb[i] = 0;
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
                max.recb[i] = Math.Max(R1.recb[i], R2.recb[i]);
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
    }

    public abstract class RatingFunction
    {
        public abstract string Name { get; }
        public abstract string ShortName { get; }

        public abstract Rating ComputeRating(PlayerData playerData);
        public abstract Rating ComputeRating(TeamDS.GiocatoriNSkillRow gnsRow);
    }
}
