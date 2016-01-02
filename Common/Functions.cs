using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public abstract class Gain_Function
    {
        public float DC, DR, DL, DMC, DMR, DML, MC, MR, ML, OMC, OML, OMR, FC;

        public bool NormalizeGains;

        public GainDS gds;

        public string[] position = new string[] { "DC", "DR", "DL", "DMC", "DMR", "DML", "MC", "MR", "ML", "OMC", "OMR", "OML", "FC" };

        internal float[] Atts
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

        #region Attitude Computation
        public float[] GetAttitude(float[] skills, string FP, float Rou, float Ada)
        {
            if (FP != "GK")
            {
                return GetAttitude_PL(skills, FP, Rou, Ada);
            }
            else
            {
                return GetAttitude_GK(skills, Rou);
            }
        }
        public abstract float[] GetAttitude_PL(float[] skills, string FP, float Rou, float Ada);
        public abstract float[] GetAttitude_GK(float[] skills, float Rou);
        #endregion

        #region OSi Computation
        public float GetOSi(float[] atts, float[] skills)
        {
            if (atts.Length > 1)
            {
                return GetOSi_PL(atts, skills);
            }
            else
            {
                return GetOSi_GK(atts, skills);
            }
        }
        public abstract float GetOSi_PL(float[] atts, float[] skills);
        public abstract float GetOSi_GK(float[] atts, float[] skills);
        #endregion

        public enum FunctionType
        {
            RusCheratte, AtleticoCassina, None
        }

        public FunctionType Type;

        public static FunctionType FromName(string type)
        {
            if (type == "RusCheratte") return FunctionType.RusCheratte;
            else if (type == "AtleticoCassina") return FunctionType.AtleticoCassina;
            else return FunctionType.None;
        }

        public static object ToString(FunctionType type)
        {
            if (type == FunctionType.RusCheratte) return "RusCheratte";
            else if (type == FunctionType.AtleticoCassina) return "AtleticoCassina";
            else return "None";
        }
    }

    public class AtleticoCassina_Function : Gain_Function
    {
        public AtleticoCassina_Function()
        {
            Type = FunctionType.AtleticoCassina;
        }

        public override float[] GetAttitude_PL(float[] origSkills, string FP, float Rou, float Ada)
        {
            FP = FP.Replace(" ", "").Replace("\xa0", "");
            
            // Skill modified by the gain reduction
            float[] skills;

            DC = DR = DL = DMC = DMR = DML = MC = MR = ML = OMC = OML = OMR = FC = 0.0f;

            // Attitudes to the position
            float[] atts = Atts;

            for (int pos = 0; pos < 13; pos++)
            {
                skills = DetermineSkillReduction(origSkills, FP, pos, Ada);

                for (int skill = 0; skill < 14; skill++)
                {
                    atts[pos] += 0.1f * gds.K_FP(skill, 0) * skills[skill];
                }
            }

            Atts = atts;

            FP = TM_Compatible.ConvertNewFP(FP);

            string[] FPs = FP.Split('/');

            float kRou = gds.funRou.Value(Rou);
            if (kRou > 1)
            {
                DC = DC * kRou;
                DR = DR * kRou;
                DL = DL * kRou;
                DMC = DMC * kRou;
                DMR = DMR * kRou;
                DML = DML * kRou;
                MC = MC * kRou;
                MR = MR * kRou;
                ML = ML * kRou;
                OMC = OMC * kRou;
                OMR = OMR * kRou;
                OML = OML * kRou;
                FC = FC * kRou;
            }

            if (NormalizeGains)
            {
                DC *= gds.K_DEM[0];
                DR *= gds.K_DEM[1];
                DL *= gds.K_DEM[2];
                DMC *= gds.K_DEM[3];
                DMR *= gds.K_DEM[4];
                DML *= gds.K_DEM[5];
                MC *= gds.K_DEM[6];
                MR *= gds.K_DEM[7];
                ML *= gds.K_DEM[8];
                OMC *= gds.K_DEM[9];
                OMR *= gds.K_DEM[10];
                OML *= gds.K_DEM[11];
                FC *= gds.K_DEM[12];
            }

            return Atts;
        }

        public override float[] GetAttitude_GK(float[] skills, float Rou)
        {
            float[] PO = new float[1];

            for (int skill = 0; skill < 11; skill++)
            {
                float fval = skills[skill];
                PO[0] += 0.1f * gds.K_GK(skill) * fval;
            }

            float kRou = gds.funRou.Value(Rou);
            if (kRou > 1)
            {
                kRou = gds.funRou.Value(Rou);
            }

            PO[0] = PO[0] * kRou;

            return PO;
        }

        public override float GetOSi_PL(float[] atts, float[] skills)
        {
            float AttMax = 0;
            // Find the maximum speciality result
            AttMax = Math.Max(DC, DL);
            AttMax = Math.Max(AttMax, DR);
            AttMax = Math.Max(AttMax, DMC);
            AttMax = Math.Max(AttMax, DMR);
            AttMax = Math.Max(AttMax, DML);
            AttMax = Math.Max(AttMax, MC);
            AttMax = Math.Max(AttMax, ML);
            AttMax = Math.Max(AttMax, MR);
            AttMax = Math.Max(AttMax, OMC);
            AttMax = Math.Max(AttMax, OML);
            AttMax = Math.Max(AttMax, OMR);
            AttMax = Math.Max(AttMax, FC);

            float skillsSum = 0.0f;
            foreach (float skill in skills)
            {
                skillsSum += skill;
            }


            float OSi = (100f - (skillsSum * 5 - AttMax) / 10.0f) * AttMax / 50f;
            return OSi * (OSi / 25f); 
        }

        public override float GetOSi_GK(float[] atts, float[] skills)
        {
            float GK = atts[0];

            float skillsSum = 0.0f;
            foreach (float skill in skills)
            {
                skillsSum += skill;
            }

            float OSi = (100f - (skillsSum * 5 - GK) / 10.0f) * GK / 50f;
            return OSi * (OSi / 25f); 
        }

        #region Private Functions
        private float[] DetermineSkillReduction(float[] skills, string FP, int pos, float ada)
        {
            string[] FPs = FP.Split('/');
            int fpos, fpos1, fpos2;
            float[] resskills = new float[14];

            for (fpos = 0; fpos < 14; fpos++)
                if (FPs[0] == position[fpos]) break;
            fpos1 = fpos;

            for (fpos = 0; fpos < 14; fpos++)
                if (FPs[0] == position[fpos]) break;
            fpos2 = fpos;

            float minReduction = Math.Max(gds.A_Ada(fpos1, pos, ada), gds.A_Ada(fpos2, pos, ada));

            for (int i = 0; i < 14; i++)
            {
                resskills[i] = skills[i] * minReduction;
            }

            return resskills;
        }
        #endregion
    }

    public class RusCheratte_Function : Gain_Function
    {
        public RusCheratte_Function()
        {
            Type = FunctionType.RusCheratte;
        }

        public override float[] GetAttitude_PL(float[] skills, string FP, float Rou, float Ada)
        {
            FP = FP.Replace(" ", "").Replace("\xa0", "");
            DC = DR = DL = DMC = DMR = DML = MC = MR = ML = OMC = OML = OMR = FC = 0.0f;

            for (int skill = 0; skill < 13; skill++)
            {
                float fval = skills[skill];
                DC += 0.1f * gds.K_FP(skill, 0) * fval;
                DR += 0.1f * gds.K_FP(skill, 1) * fval;
                DL += 0.1f * gds.K_FP(skill, 2) * fval;
                DMC += 0.1f * gds.K_FP(skill, 3) * fval;
                DMR += 0.1f * gds.K_FP(skill, 4) * fval;
                DML += 0.1f * gds.K_FP(skill, 5) * fval;
                MC += 0.1f * gds.K_FP(skill, 6) * fval;
                MR += 0.1f * gds.K_FP(skill, 7) * fval;
                ML += 0.1f * gds.K_FP(skill, 8) * fval;
                OMC += 0.1f * gds.K_FP(skill, 9) * fval;
                OMR += 0.1f * gds.K_FP(skill, 10) * fval;
                OML += 0.1f * gds.K_FP(skill, 11) * fval;
                FC += 0.1f * gds.K_FP(skill, 12) * fval;
            }

            FP = TM_Compatible.ConvertNewFP(FP);

            string[] FPs = FP.Split('/');

            float kRou = gds.funRou.Value(Rou);
            if (kRou > 1)
            {
                kRou = gds.funRou.Value(Rou);
            }

            if (FPs.Length == 1)
            {
                int n;
                for (n = 0; n < 13; n++)
                    if (FP == position[n]) break;

                DC = DC * gds.A_Ada(n, 0, Ada) * kRou;
                DR = DR * gds.A_Ada(n, 1, Ada) * kRou;
                DL = DL * gds.A_Ada(n, 2, Ada) * kRou;
                DMC = DMC * gds.A_Ada(n, 3, Ada) * kRou;
                DMR = DMR * gds.A_Ada(n, 4, Ada) * kRou;
                DML = DML * gds.A_Ada(n, 5, Ada) * kRou;
                MC = MC * gds.A_Ada(n, 6, Ada) * kRou;
                MR = MR * gds.A_Ada(n, 7, Ada) * kRou;
                ML = ML * gds.A_Ada(n, 8, Ada) * kRou;
                OMC = OMC * gds.A_Ada(n, 9, Ada) * kRou;
                OMR = OMR * gds.A_Ada(n, 10, Ada) * kRou;
                OML = OML * gds.A_Ada(n, 11, Ada) * kRou;
                FC = FC * gds.A_Ada(n, 12, Ada) * kRou;
            }

            if (FPs.Length == 2)
            {
                int n1, n2;
                for (n1 = 0; n1 < 13; n1++)
                    if (FPs[0] == position[n1]) break;
                for (n2 = 0; n2 < 13; n2++)
                    if (FPs[1] == position[n2]) break;

                DC = Math.Max(DC * gds.A_Ada(n1, 0, Ada), DC * gds.A_Ada(n2, 0, Ada)) * kRou;
                DR = Math.Max(DR * gds.A_Ada(n1, 1, Ada), DR * gds.A_Ada(n2, 1, Ada)) * kRou;
                DL = Math.Max(DL * gds.A_Ada(n1, 2, Ada), DL * gds.A_Ada(n2, 2, Ada)) * kRou;
                DMC = Math.Max(DMC * gds.A_Ada(n1, 3, Ada), DMC * gds.A_Ada(n2, 3, Ada)) * kRou;
                DMR = Math.Max(DMR * gds.A_Ada(n1, 4, Ada), DMR * gds.A_Ada(n2, 4, Ada)) * kRou;
                DML = Math.Max(DML * gds.A_Ada(n1, 5, Ada), DML * gds.A_Ada(n2, 5, Ada)) * kRou;
                MC = Math.Max(MC * gds.A_Ada(n1, 6, Ada), MC * gds.A_Ada(n2, 6, Ada)) * kRou;
                MR = Math.Max(MR * gds.A_Ada(n1, 7, Ada), MR * gds.A_Ada(n2, 7, Ada)) * kRou;
                ML = Math.Max(ML * gds.A_Ada(n1, 8, Ada), ML * gds.A_Ada(n2, 8, Ada)) * kRou;
                OMC = Math.Max(OMC * gds.A_Ada(n1, 9, Ada), OMC * gds.A_Ada(n2, 9, Ada)) * kRou;
                OMR = Math.Max(OMR * gds.A_Ada(n1, 10, Ada), OMR * gds.A_Ada(n2, 10, Ada)) * kRou;
                OML = Math.Max(OML * gds.A_Ada(n1, 11, Ada), OML * gds.A_Ada(n2, 11, Ada)) * kRou;
                FC = Math.Max(FC * gds.A_Ada(n1, 12, Ada), FC * gds.A_Ada(n2, 12, Ada)) * kRou;
            }

            if (NormalizeGains)
            {
                DC *= gds.K_DEM[0];
                DR *= gds.K_DEM[1];
                DL *= gds.K_DEM[2];
                DMC *= gds.K_DEM[3];
                DMR *= gds.K_DEM[4];
                DML *= gds.K_DEM[5];
                MC *= gds.K_DEM[6];
                MR *= gds.K_DEM[7];
                ML *= gds.K_DEM[8];
                OMC *= gds.K_DEM[9];
                OMR *= gds.K_DEM[10];
                OML *= gds.K_DEM[11];
                FC *= gds.K_DEM[12];
            }

            return Atts;
        }

        public override float[] GetAttitude_GK(float[] skills, float Rou)
        {
            float[] PO = new float[1];

            for (int skill = 0; skill < 11; skill++)
            {
                float fval = skills[skill];
                PO[0] += 0.1f * gds.K_GK(skill) * fval;
            }

            float kRou = gds.funRou.Value(Rou);
            if (kRou > 1)
            {
                kRou = gds.funRou.Value(Rou);
            }

            PO[0] = PO[0] * kRou;

            return PO;
        }

        public override float GetOSi_PL(float[] atts, float[] skills)
        {
            float AttMax = 0;
            // Find the maximum speciality result
            AttMax = Math.Max(DC, DL);
            AttMax = Math.Max(AttMax, DR);
            AttMax = Math.Max(AttMax, DMC);
            AttMax = Math.Max(AttMax, DMR);
            AttMax = Math.Max(AttMax, DML);
            AttMax = Math.Max(AttMax, MC);
            AttMax = Math.Max(AttMax, ML);
            AttMax = Math.Max(AttMax, MR);
            AttMax = Math.Max(AttMax, OMC);
            AttMax = Math.Max(AttMax, OML);
            AttMax = Math.Max(AttMax, OMR);
            AttMax = Math.Max(AttMax, FC);

            float skillsSum = 0.0f;
            foreach (float skill in skills)
            {
                skillsSum += skill;
            }

            float OSi = (100f - (skillsSum * 5 - AttMax) / 10.0f) * AttMax / 50f;
            float k = (AttMax * AttMax * AttMax) / (27000f + (AttMax * AttMax * AttMax));
            return k * OSi * (OSi / 25f);
        }

        public override float GetOSi_GK(float[] atts, float[] skills)
        {
            float GK = atts[0];

            float SkS = 0.0f;
            foreach (float skill in skills)
            {
                SkS += skill;
            }

            // return GK / (skillsSum / 110f);
            float OSi = (100f - (SkS * 5 - GK) / 10.0f) * GK / 50f;
            float k = (GK * GK * GK) / (27000f + (GK * GK * GK));
            return k * OSi * (OSi / 50f);
        }
    }

    public class Function
    {
        public Function(FunctionType function, float[] pars)
        {
            Params = pars;
            Type = function;
        }

        public Function()
        {
            Params = null;
            Type = FunctionType.Linear;
        }

        public enum FunctionType
        {
            Linear, Exponential, Log, Quadratic, None
        }

        public float[] Params = null;
        public FunctionType Type = FunctionType.Linear;

        public float Value(float x)
        {
            if (Params == null) return 1.0F;

            switch (Type)
            {
                case FunctionType.Linear: return Linear(x);
                default: return 1.0F;
            }
        }

        public decimal Value(decimal x)
        {
            if (Params == null) return 1.0M;

            switch (Type)
            {
                case FunctionType.Linear: return Linear(x);
                default: return 1.0M;
            }
        }

        private float Linear(float x)
        {
            if (Params.Length >= 2) return Params[0] + x * Params[1];
            else return 1.0F;
        }

        private decimal Linear(decimal x)
        {
            if (Params.Length >= 2) return (decimal)(Params[0] + (float)x * Params[1]);
            else return 1.0M;
        }

        public static FunctionType FromName(string type)
        {
            if (type == "Linear") return FunctionType.Linear;
            else if (type == "Exponential") return FunctionType.Exponential;
            else if (type == "Log") return FunctionType.Log;
            else if (type == "Quadratic") return FunctionType.Quadratic;
            else return FunctionType.None;
        }

        public static string ToString(FunctionType type)
        {
            if (type == FunctionType.Linear) return "Linear";
            else if (type == FunctionType.Exponential) return "Exponential";
            else if (type == FunctionType.Log) return "Log";
            else if (type == FunctionType.Quadratic) return "Quadratic";
            else return "None";
        }
    }
}
