using NTR_Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NTR_Db
{
    public class Rating
    {
        public const int NumPos = 14;
        public double[] rec = new double[NumPos]; // REC
        public double[] rating = new double[NumPos]; // Rating
        // Rating + routine
        public double[] ratingR = new double[NumPos]; 

        public double CK { get; internal set; }
        public double FK { get; internal set; }
        public double PK { get; internal set; }
        public double OSi { get; internal set; }

        public double DC => ratingR[(int)ePos.DC];
        public double DR => ratingR[(int)ePos.DR];
        public double DL => ratingR[(int)ePos.DL];
        public double DMC => ratingR[(int)ePos.DMC];
        public double DMR => ratingR[(int)ePos.DMR];
        public double DML => ratingR[(int)ePos.DML];
        public double MC => ratingR[(int)ePos.MC];
        public double MR => ratingR[(int)ePos.MR];
        public double ML => ratingR[(int)ePos.ML];
        public double OMC => ratingR[(int)ePos.OMC];
        public double OMR => ratingR[(int)ePos.OMR];
        public double OML => ratingR[(int)ePos.OML];
        public double FC => ratingR[(int)ePos.FC];
        public double GK => ratingR[(int)ePos.GK];

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
            for (int i = 0; i < NumPos; i++)
            {
                rec[i] = 0;
                rating[i] = 0;
                ratingR[i] = 0;
            }
        }

        //public static Rating Max(Rating R1, Rating R2)
        //{
        //    Rating max = new Rating();

        //    for (int i = 0; i < NumPos; i++)
        //    {
        //        max.rec[i] = Math.Max(R1.rec[i], R2.rec[i]);
        //        max.rating[i] = Math.Max(R1.rating[i], R2.rating[i]);
        //        max.ratingR[i] = Math.Max(R1.ratingR[i], R2.ratingR[i]);
        //    }

        //    return max;
        //}

        public static Rating Max(Rating[] R)
        {
            if (R.Length == 1)
                return R[0];

            Rating max = new Rating();

            for (int i = 0; i < NumPos; i++)
            {
                max.rec[i] = Math.Max(R[0].rec[i], R[1].rec[i]);
                max.rating[i] = Math.Max(R[0].rating[i], R[1].rating[i]);
                max.ratingR[i] = Math.Max(R[0].ratingR[i], R[1].ratingR[i]);
            }

            return max;
        }

        //public static List<REC_Weights> WeightsMatrixToTable(WeightMatrix weightRat)
        //{
        //    List<REC_Weights> recWeightsList = new List<REC_Weights>();

        //    for (int col=0; col<weightRat.Cols; col++)
        //    {
        //        REC_Weights recWeight = new REC_Weights(weightRat, col);
        //        recWeightsList.Add(recWeight);
        //    }

        //    return recWeightsList;
        //}

        //internal static WeightMatrix TableToWeightsMatrix(List<REC_Weights> recWeights)
        //{
        //    WeightMatrix weightMx = new WeightMatrix(recWeights[0].Column.Length, recWeights.Count);

        //    for (int col = 0; col < weightMx.Cols; col++)
        //    {
        //        double[] column = recWeights[col].Column;
        //        for (int row = 0; row < weightMx.Rows; row++)
        //        {
        //            weightMx[row, col] = column[row];
        //        }
        //    }

        //    return weightMx;
        //}

        //public static List<PROP_Weights> WeightsMatrixToPropTable(WeightMatrix weightProp)
        //{
        //    List<PROP_Weights> propWeightsList = new List<PROP_Weights>();

        //    for (int col = 0; col < weightProp.Cols; col++)
        //    {
        //        PROP_Weights propWeight = new PROP_Weights(weightProp, col);
        //        propWeightsList.Add(propWeight);
        //    }

        //    return propWeightsList;
        //}

        //internal static WeightMatrix PropTableToWeightsMatrix(List<PROP_Weights> propWeights)
        //{
        //    WeightMatrix weightMx = new WeightMatrix(propWeights[0].Column.Length, propWeights.Count);

        //    for (int col = 0; col < weightMx.Cols; col++)
        //    {
        //        double[] column = propWeights[col].Column;
        //        for (int row = 0; row < weightMx.Rows; row++)
        //        {
        //            weightMx[row, col] = column[row];
        //        }
        //    }

        //    return weightMx;
        //}

        //public static List<ADA_Weights> WeightsMatrixToAdaTable(WeightMatrix weightAda)
        //{
        //    List<ADA_Weights> adaWeightsList = new List<ADA_Weights>();

        //    for (int col = 0; col < weightAda.Cols; col++)
        //    {
        //        ADA_Weights adaWeight = new ADA_Weights(weightAda, col);
        //        adaWeightsList.Add(adaWeight);
        //    }

        //    return adaWeightsList;
        //}

        //internal static WeightMatrix AdaTableToWeightsMatrix(List<ADA_Weights> adaWeights)
        //{
        //    WeightMatrix weightMx = new WeightMatrix(adaWeights[0].Column.Length, adaWeights.Count);

        //    for (int col = 0; col < weightMx.Cols; col++)
        //    {
        //        double[] column = adaWeights[col].Column;
        //        for (int row = 0; row < weightMx.Rows; row++)
        //        {
        //            weightMx[row, col] = column[row];
        //        }
        //    }

        //    return weightMx;
        //}

        public double R(ePos pos)
        {
            return rating[(int)pos];
        }
        public double REC(ePos pos)
        {
            return rec[(int)pos];
        }

        public float GetRating(string pos)
        {
            ePos epos = (ePos)Enum.Parse(typeof(ePos), pos);
            return (float)rating[(int)epos];
        }
    }

    public enum eCoefficient
    {
        K0,
        K1,
    }

    //public enum eSkill
    //{
    //    Str,
    //    Sta,
    //    Pac,
    //    Mar,
    //    Tak,
    //    Wor,
    //    Pos,
    //    Pas,
    //    Cro,
    //    Tec,
    //    Hea,
    //    Fin,
    //    Lon,
    //    Set
    //}

    public enum ePos
    {
        DC,
        DR,
        DL,
        DMC,
        DMR,
        DML,
        MC,
        MR,
        ML,
        OMC,
        OMR,
        OML,
        FC,
        GK,
    }

    //public enum eSkillGK
    //{
    //    Str,
    //    Sta,
    //    Pac,
    //    Han,
    //    One,
    //    Ref,
    //    Aer,
    //    Jum,
    //    Com,
    //    Kic,
    //    Thr,
    //    Max
    //}

    //public class PROP_Weights
    //{
    //    //public PROP_Weights(WeightMatrix weightRat, int col)
    //    //{
    //    //    Coefficent = ((eCoefficient)col).ToString();
    //    //    Coefficent.backColor = Color.LightGray;

    //    //    DC = weightRat[0, col];
    //    //    DR = weightRat[1, col];
    //    //    DL = weightRat[2, col];
    //    //    DMC = weightRat[3, col];
    //    //    DMR = weightRat[4, col];
    //    //    DML = weightRat[5, col];
    //    //    MC = weightRat[6, col];
    //    //    MR = weightRat[7, col];
    //    //    ML = weightRat[8, col];
    //    //    OMC = weightRat[9, col];
    //    //    OMR = weightRat[10, col];
    //    //    OML = weightRat[11, col];
    //    //    FC = weightRat[12, col];
    //    //    GK = weightRat[13, col];
    //    //}

    //    public FormattedString Coefficent { get; set; }
    //    public double DC { get; set; }
    //    public double DR { get; set; }
    //    public double DL { get; set; }
    //    public double DMC { get; set; }
    //    public double DMR { get; set; }
    //    public double DML { get; set; }
    //    public double MC { get; set; }
    //    public double MR { get; set; }
    //    public double ML { get; set; }
    //    public double OMC { get; set; }
    //    public double OMR { get; set; }
    //    public double OML { get; set; }
    //    public double FC { get; set; }
    //    public double GK { get; set; }

    //    public double[] Column => new double[]
    //                {DC,DR,DL,
    //                DMC,DMR,DML,
    //                MC,MR,ML,
    //                OMC,OMR,OML,
    //                FC,GK};
    //}

    //public class REC_Weights
    //{
    //    //public REC_Weights(WeightMatrix weightREC, int col)
    //    //{
    //    //    Skill = ((eSkill)col).ToString();
    //    //    Skill.backColor = Color.LightGray;

    //    //    if (col < (int)eSkillGK.Max)
    //    //        SkillGk = ((eSkillGK)col).ToString();
    //    //    else
    //    //        SkillGk = "-";

    //    //    SkillGk.backColor = Color.LightGray;

    //    //    DC = weightREC[0, col];
    //    //    DR = weightREC[1, col];
    //    //    DL = weightREC[2, col];
    //    //    DMC = weightREC[3, col];
    //    //    DMR = weightREC[4, col];
    //    //    DML = weightREC[5, col];
    //    //    MC = weightREC[6, col];
    //    //    MR = weightREC[7, col];
    //    //    ML = weightREC[8, col];
    //    //    OMC = weightREC[9, col];
    //    //    OMR = weightREC[10, col];
    //    //    OML = weightREC[11, col];
    //    //    FC = weightREC[12, col];
    //    //    GK = weightREC[13, col];
    //    //}

    //    public FormattedString Skill { get; set; }
    //    public double DC { get; set; }
    //    public double DR { get; set; }
    //    public double DL { get; set; }
    //    public double DMC { get; set; }
    //    public double DMR { get; set; }
    //    public double DML { get; set; }
    //    public double MC { get; set; }
    //    public double MR { get; set; }
    //    public double ML { get; set; }
    //    public double OMC { get; set; }
    //    public double OMR { get; set; }
    //    public double OML { get; set; }
    //    public double FC { get; set; }
    //    public FormattedString SkillGk { get; set; }
    //    public double GK { get; set; }

    //    //public double[] Column => new double[]
    //    //            {DC,DR,DL,
    //    //            DMC,DMR,DML,
    //    //            MC,MR,ML,
    //    //            OMC,OMR,OML,
    //    //            FC,GK};   
    //}

    //public class ADA_Weights
    //{
    //    //public ADA_Weights(WeightMatrix weightAda, int col)
    //    //{
    //    //    Position = ((ePos)col).ToString();
    //    //    Position.backColor = Color.LightGray;

    //    //    DC = weightAda[0, col];
    //    //    DR = weightAda[1, col];
    //    //    DL = weightAda[2, col];
    //    //    DMC = weightAda[3, col];
    //    //    DMR = weightAda[4, col];
    //    //    DML = weightAda[5, col];
    //    //    MC = weightAda[6, col];
    //    //    MR = weightAda[7, col];
    //    //    ML = weightAda[8, col];
    //    //    OMC = weightAda[9, col];
    //    //    OMR = weightAda[10, col];
    //    //    OML = weightAda[11, col];
    //    //    FC = weightAda[12, col];
    //    //}

    //    public FormattedString Position { get; set; }
    //    public double DC { get; set; }
    //    public double DR { get; set; }
    //    public double DL { get; set; }
    //    public double DMC { get; set; }
    //    public double DMR { get; set; }
    //    public double DML { get; set; }
    //    public double MC { get; set; }
    //    public double MR { get; set; }
    //    public double ML { get; set; }
    //    public double OMC { get; set; }
    //    public double OMR { get; set; }
    //    public double OML { get; set; }
    //    public double FC { get; set; }

    //    public double[] Column => new double[]
    //                {DC,DR,DL,
    //                DMC,DMR,DML,
    //                MC,MR,ML,
    //                OMC,OMR,OML,
    //                FC};
    //}

    public class RatingFunction: StdSettings
    {
        public WeightMatrix _adaFact = new double[,] {
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

        //public static RatingFunction Create(eRatingFunctionType funType, 
        //    List<REC_Weights> recWeights, 
        //    List<REC_Weights> ratWeights, 
        //    List<PROP_Weights> recLfWeights, 
        //    List<ADA_Weights> adaWeights, 
        //    double rouFactor, string fileName)
        //{
        //    switch(funType)
        //    {
        //        case eRatingFunctionType.RatingR2:
        //            return RatingR2.Create(recWeights, ratWeights,
        //                recLfWeights, adaWeights,
        //                rouFactor, fileName);
        //        case eRatingFunctionType.RatingAtleticoCassina:
        //            return RatingAC.Create(recWeights, ratWeights,
        //                recLfWeights, adaWeights,
        //                rouFactor, fileName);
        //        case eRatingFunctionType.RUSCheratte:
        //            return RatingRC.Create(recWeights, ratWeights,
        //                recLfWeights, adaWeights,
        //                rouFactor, fileName);
        //        case eRatingFunctionType.RatingL2:
        //            return RatingL2.Create(recWeights, ratWeights,
        //                recLfWeights, adaWeights,
        //                rouFactor, fileName);
        //        case eRatingFunctionType.RatingR3:
        //        default:
        //            return RatingR3.Create(recWeights, ratWeights,
        //                recLfWeights, adaWeights,
        //                rouFactor, fileName);
        //    }
        //}

        protected WeightMatrix OrderedWeightRat { get; set; }

        public eRatingFunctionType RatingFunctionType
        {
            get => (eRatingFunctionType)this["RatingFunctionType"];
            set => this["RatingFunctionType"] = value;
        }
        public double RoutineFactor
        {
            get => (double)this["RoutineFactor"];
            set => this["RoutineFactor"] = value;
        }
        public string ShortName
        {
            get => (string)this["ShortName"];
            set => this["ShortName"] = value;
        }
        public string Name
        {
            get => (string)this["Name"];
            set => this["Name"] = value;
        }

        protected WeightMatrix SortRowsByCols(WeightMatrix mIn)
        {
            double t;
            WeightMatrix m = mIn.Clone();

            for (int r=0; r< m.Rows; r++)
            {
                for (int c = m.Cols - 1; c > 0; c--)
                {
                    for (int p = 0; p < c; p++)
                    {
                        if (m[r, p] > m[r, p+1])
                        {
                            t = m[r, p];
                            m[r, p] = m[r, p + 1];
                            m[r, p + 1] = t;
                        }
                    }
                }
            }

            return m;
        }

        /// <summary>
        /// This function initialize settings for the object
        /// </summary>
        public virtual void SettingInitialize()
        {
        }

        public virtual WeightMatrix WeightRat
        {
            get; set;
        }

        public double GetOSi(Rating R, PlayerDataSkills pds)
        {
            double rMax = R.rating[0];
            // Find the maximum speciality result

            for (int i = 1; i < R.rating.Length; i++)
                rMax = Math.Max(rMax, R.rating[i]);

            WeightMatrix ratMx = WeightRat;

            double skillsSum = pds.SkillSum;

            (double min, double max) = MinMaxRatingForSkillsum(pds.FPn, skillsSum);

            return (rMax - min) / (max - min) * 100;
        }

        protected virtual (double min, double max) MinMaxRatingForSkillsum(int FPn,double skillsSum)
        {
            int[] FP = Rating.GetPositionIndex(FPn);

            if (FP[1] == -1)
            {
                double min = 0, max = 0;
                int i = 0;
                double d = 0;

                for (; d < skillsSum - 20; d += 20, i++)
                    min += OrderedWeightRat[FP[0], i] * 20;

                min += OrderedWeightRat[FP[0], i] * (skillsSum - d);

                i = 13;
                d = 0;

                for (; d < skillsSum - 20; d += 20, i--)
                    max += OrderedWeightRat[FP[0], i] * 20;

                max += OrderedWeightRat[FP[0], i] * (skillsSum - d);

                return (min, max);
            }
            else
            {
                double min1 = 0, max1 = 0, min2 = 0, max2 = 0;

                int i = 0;
                double d = 0;
                for (; d < skillsSum - 20; d += 20, i++)
                    min1 += OrderedWeightRat[FP[0], i] * 20;
                min1 += OrderedWeightRat[FP[0], i] * (skillsSum - d);

                i = 0;
                d = 0;
                for (; d < skillsSum - 20; d += 20, i++)
                    min2 += OrderedWeightRat[FP[1], i] * 20;
                min2 += OrderedWeightRat[FP[1], i] * (skillsSum - d);

                i = 13;
                d = 0;
                for (; d < skillsSum - 20; d += 20, i--)
                    max1 += OrderedWeightRat[FP[0], i] * 20;
                max1 += OrderedWeightRat[FP[0], i] * (skillsSum - d);

                i = 13;
                d = 0;
                for (; d < skillsSum - 20; d += 20, i--)
                    max2 += OrderedWeightRat[FP[1], i] * 20;
                max2 += OrderedWeightRat[FP[1], i] * (skillsSum - d);

                return ((min1 < min2)?min2:min1, max1<max2?max2:max1);
            }
        }

        public virtual Rating ComputeRating(PlayerDataSkills playerData) { return null; }

        public virtual void WriteOnFile(string fileName) { }

        public static RatingFunction Load(string fileName)
        {
            RatingFunction rf = new RatingFunction();
            rf.SettingsFilename = fileName;

            if (!rf.SettingsFileExists())
                return null;

            rf.Load();

            rf = CreateFunctionType(rf.RatingFunctionType);

            rf.SettingsFilename = fileName;
            rf.Load();

            return rf;
        }

        static RatingFunction CreateFunctionType(eRatingFunctionType functionType)
        {
            switch(functionType)
            {
                case eRatingFunctionType.RatingR2:
                    return new RatingR2();
                case eRatingFunctionType.RatingR3:
                    return new RatingR3();
                case eRatingFunctionType.RatingR4:
                    return new RatingR4();
                case eRatingFunctionType.RatingAtleticoCassina:
                    return new RatingAC();
                case eRatingFunctionType.RUSCheratte:
                    return new RatingRC();
                case eRatingFunctionType.RatingL2:
                    return new RatingL2();
                case eRatingFunctionType.RatingR5:
                    return new RatingR5();
            }

            return null;
        }

        public static void CreateDefaultFunctions(string ratingFunctionPath)
        {
            string ratingFunctionDir = Path.GetDirectoryName(ratingFunctionPath);

            foreach (eRatingFunctionType functionType in Enum.GetValues(typeof(eRatingFunctionType)))
            {
                string ratingFunctionFile = Path.Combine(ratingFunctionDir, functionType.ToString() + ".rating");

                FileInfo fi = new FileInfo(ratingFunctionFile);
                if (fi.Exists)
                    continue;

                RatingFunction rf = CreateFunctionType(functionType);

                rf.SettingsFilename = ratingFunctionFile;
                rf.Save();
            }
        }

        internal virtual double[] Relevances(int FPn)
        {
            if (FPn != 0)
            {
                int[] posIndex = Rating.GetPositionIndex(FPn);

                double[] relevances = new double[14];

                for (int i = 0; i < 14; i++)
                {
                    double W1 = 80*WeightRat[posIndex[0], i];

                    if (posIndex[1] == -1)
                    {
                        relevances[i] = W1;
                        continue;
                    }

                    double W2 = 80* WeightRat[posIndex[1], i];

                    relevances[i] = (W1 > W2 ? W1 : W2);
                }

                return relevances;
            }
            else
            {
                double[] relevances = new double[11];

                for (int i = 0; i < 11; i++)
                {
                    relevances[i] = 80 * WeightRat[13, i];
                }

                return relevances;
            }
        }

        public double RatingFunctionAdaptability { get; set; }

        public bool UseREC { get; set; }
    }
}
