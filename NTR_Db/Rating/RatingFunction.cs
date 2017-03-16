using NTR_Common;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static List<REC_Weights> WeightsMatrixToTable(Matrix weightRat)
        {
            List<REC_Weights> recWeightsList = new List<REC_Weights>();

            for (int col=0; col<weightRat.Cols; col++)
            {
                REC_Weights recWeight = new REC_Weights(weightRat, col);
                recWeightsList.Add(recWeight);
            }

            return recWeightsList;
        }

        public static List<PROP_Weights> WeightsMatrixToPropTable(Matrix weightProp)
        {
            List<PROP_Weights> propWeightsList = new List<PROP_Weights>();

            for (int col = 0; col < weightProp.Cols; col++)
            {
                PROP_Weights propWeight = new PROP_Weights(weightProp, col);
                propWeightsList.Add(propWeight);
            }

            return propWeightsList;
        }

        public static List<ADA_Weights> WeightsMatrixToAdaTable(Matrix weightAda)
        {
            List<ADA_Weights> adaWeightsList = new List<ADA_Weights>();

            for (int col = 0; col < weightAda.Cols; col++)
            {
                ADA_Weights adaWeight = new ADA_Weights(weightAda, col);
                adaWeightsList.Add(adaWeight);
            }

            return adaWeightsList;
        }

    }

    public enum eCoefficient
    {
        K0,
        K1,
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

    public class PROP_Weights
    {
        public PROP_Weights(Matrix weightRat, int col)
        {
            Coefficent = ((eCoefficient)col).ToString();
            Coefficent.backColor = Color.LightGray;

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

        public FormattedString Coefficent { get; set; }
        public double DC { get; set; }
        public double DL { get; set; }
        public double DR { get; set; }
        public double DMC { get; set; }
        public double DML { get; set; }
        public double DMR { get; set; }
        public double MC { get; set; }
        public double ML { get; set; }
        public double MR { get; set; }
        public double OMC { get; set; }
        public double OML { get; set; }
        public double OMR { get; set; }
        public double FC { get; set; }
        public double GK { get; set; }
    }

    public class REC_Weights
    {
        public REC_Weights(Matrix weightRat, int col)
        {
            Skill = ((eSkill)col).ToString();
            Skill.backColor = Color.LightGray;

            if (col < (int)eSkillGK.Max)
                SkillGk = ((eSkillGK)col).ToString();
            else
                SkillGk = "-";

            SkillGk.backColor = Color.LightGray;

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

        public FormattedString Skill { get; set; }
        public double DC { get; set; }
        public double DL { get; set; }
        public double DR { get; set; }
        public double DMC { get; set; }
        public double DML { get; set; }
        public double DMR { get; set; }
        public double MC { get; set; }
        public double ML { get; set; }
        public double MR { get; set; }
        public double OMC { get; set; }
        public double OML { get; set; }
        public double OMR { get; set; }
        public double FC { get; set; }
        public FormattedString SkillGk { get; set; }
        public double GK { get; set; }
    }

    public class ADA_Weights
    {
        public ADA_Weights(Matrix weightAda, int col)
        {
            Position = ((eSkill)col).ToString();
            Position.backColor = Color.LightGray;

            DC = weightAda[0, col];
            DL = weightAda[1, col];
            DR = weightAda[2, col];
            DMC = weightAda[3, col];
            DML = weightAda[4, col];
            DMR = weightAda[5, col];
            MC = weightAda[6, col];
            ML = weightAda[7, col];
            MR = weightAda[8, col];
            OMC = weightAda[9, col];
            OML = weightAda[10, col];
            OMR = weightAda[11, col];
            FC = weightAda[12, col];
        }

        public FormattedString Position { get; set; }
        public double DC { get; set; }
        public double DL { get; set; }
        public double DR { get; set; }
        public double DMC { get; set; }
        public double DML { get; set; }
        public double DMR { get; set; }
        public double MC { get; set; }
        public double ML { get; set; }
        public double MR { get; set; }
        public double OMC { get; set; }
        public double OML { get; set; }
        public double OMR { get; set; }
        public double FC { get; set; }
    }

    public abstract class RatingFunction
    {
        public static Matrix adaFact = new double[,] {
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

        public abstract Matrix GetWeightREC();
        public abstract Matrix GetWeightRat();
        public abstract Matrix GetWeightREClf();
        public Matrix GetAdaptability()
        {
            return adaFact;
        }

        public abstract Rating ComputeRating(PlayerDataSkills playerData);
    }
}
