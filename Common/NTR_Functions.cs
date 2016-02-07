using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public abstract class NTR_GainFunction
    {
        public decimal DC, DR, DL, DMC, DMR, DML, MC, MR, ML, OMC, OML, OMR, FC;

        public bool NormalizeGains;

        public GainDS GDS;

        public string[] position = new string[] { "DC", "DR", "DL", "DMC", "DMR", "DML", "MC", "MR", "ML", "OMC", "OMR", "OML", "FC" };

        internal decimal[] Atts
        {
            get
            {
                decimal[] f = new decimal[13];

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
                decimal[] f = value;

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
        public decimal[] GetAttitude(Common.decvar[] skillsvar, int FPn, decimal Rou, decimal Ada)
        {
            decimal[] skills = new decimal[14];

            if (FPn != 0) // FP != GK
            {
                for (int i=0; i<14; i++)
                {
                    skills[i] = skillsvar[i].actual;
                }
                return GetAttitude_PL(skills, FPn, Rou, Ada);
            }
            else
            {
                for (int i = 0; i < 11; i++)
                {
                    skills[i] = skillsvar[i].actual;
                }
                return GetAttitude_GK(skills, Rou);
            }
        }

        public decimal[] GetAttitude(decimal[] skills, int FPn, decimal Rou, decimal Ada)
        {
            if (FPn != 0) // FP != GK
            {
                return GetAttitude_PL(skills, FPn, Rou, Ada);
            }
            else
            {
                return GetAttitude_GK(skills, Rou);
            }
        }
        public abstract decimal[] GetAttitude_PL(decimal[] skills, int FPn, decimal Rou, decimal Ada);
        public abstract decimal[] GetAttitude_GK(decimal[] skills, decimal Rou);
        #endregion

        #region PSP Computation
        public decimal GetPSP(decimal[] atts, decimal Età)
        {
            if (atts.Length > 1)
            {
                return GetPSP_PL(atts, Età);
            }
            else
            {
                return GetPSP_GK(atts, Età);
            }
        }
        public abstract decimal GetPSP_PL(decimal[] atts, decimal Età);
        public abstract decimal GetPSP_GK(decimal[] atts, decimal Età);
        #endregion

        #region OSi Computation
        public decimal GetOSi(float[] atts, float[] skills)
        {
            decimal[] datts = new decimal[atts.Length];
            decimal[] dskills = new decimal[skills.Length];

            for (int i = 0; i < atts.Length; i++)
                datts[i] = (decimal)atts[i];
            for (int i = 0; i < skills.Length; i++)
                dskills[i] = (decimal)skills[i];

            if (atts.Length > 1)
            {
                return GetOSi_PL(datts, dskills);
            }
            else
            {
                return GetOSi_GK(datts, dskills);
            }
        }
        public decimal GetOSi(decimal[] atts, decimal[] skills)
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
        public abstract decimal GetOSi_PL(decimal[] atts, decimal[] skills);
        public abstract decimal GetOSi_GK(decimal[] atts, decimal[] skills);
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

    public class NTR_AtleticoCassina_Function : NTR_GainFunction
    {
        public NTR_AtleticoCassina_Function()
        {
            Type = FunctionType.AtleticoCassina;
        }

        public override decimal[] GetAttitude_PL(decimal[] origSkills, int FPn, decimal Rou, decimal Ada)
        {
            // Skill modified by the gain reduction
            decimal[] skills;

            DC = DR = DL = DMC = DMR = DML = MC = MR = ML = OMC = OML = OMR = FC = 0.0M;

            // Attitudes to the position
            decimal[] atts = Atts;

            for (int pos = 0; pos < 13; pos++)
            {
                skills = DetermineSkillReduction(origSkills, FPn, pos, Ada);

                for (int skill = 0; skill < 14; skill++)
                {
                    atts[pos] += 0.1M * (decimal)GDS.K_FP(skill, 0) * skills[skill];
                }
            }

            Atts = atts;

            decimal kRou = (decimal)GDS.funRou.Value(Rou);
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
                DC *= (decimal)GDS.K_DEM[0];
                DR *= (decimal)GDS.K_DEM[1];
                DL *= (decimal)GDS.K_DEM[2];
                DMC *= (decimal)GDS.K_DEM[3];
                DMR *= (decimal)GDS.K_DEM[4];
                DML *= (decimal)GDS.K_DEM[5];
                MC *= (decimal)GDS.K_DEM[6];
                MR *= (decimal)GDS.K_DEM[7];
                ML *= (decimal)GDS.K_DEM[8];
                OMC *= (decimal)GDS.K_DEM[9];
                OMR *= (decimal)GDS.K_DEM[10];
                OML *= (decimal)GDS.K_DEM[11];
                FC *= (decimal)GDS.K_DEM[12];
            }

            return Atts;
        }

        public override decimal[] GetAttitude_GK(decimal[] skills, decimal Rou)
        {
            decimal[] PO = new decimal[1];

            for (int skill = 0; skill < 11; skill++)
            {
                decimal fval = skills[skill];
                PO[0] += 0.1M * (decimal)GDS.K_GK(skill) * fval;
            }

            decimal kRou = GDS.funRou.Value(Rou);
            if (kRou > 1)
            {
                kRou = GDS.funRou.Value(Rou);
            }

            PO[0] = PO[0] * kRou;

            return PO;
        }

        public override decimal GetOSi_PL(decimal[] atts, decimal[] skills)
        {
            decimal AttMax = 0;
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

            decimal skillsSum = 0.0M;
            foreach (decimal skill in skills)
            {
                skillsSum += skill;
            }

            decimal OSi = (100M - (skillsSum * 5 - AttMax) / 10.0M) * AttMax / 50M;
            decimal k = (AttMax * AttMax * AttMax) / (27000M + (AttMax * AttMax * AttMax));
            return k * OSi * (OSi / 25M);
        }

        public override decimal GetOSi_GK(decimal[] atts, decimal[] skills)
        {
            decimal GK = atts[0];

            decimal SkS = 0.0M;
            foreach (decimal skill in skills)
            {
                SkS += skill;
            }

            // return GK / (skillsSum / 110f);
            decimal OSi = (100M - (SkS * 5 - GK) / 10.0M) * GK / 50M;
            decimal k = (GK * GK * GK) / (27000M + (GK * GK * GK));
            return k * OSi * (OSi / 50M);
        }

        public override decimal GetPSP_PL(decimal[] atts, decimal Età)
        {
            decimal PSP = 0.0M;

            Atts = atts;

            // Find the maximum speciality result
            PSP = Math.Max(DC, DL);
            PSP = Math.Max(PSP, DR);
            PSP = Math.Max(PSP, DMC);
            PSP = Math.Max(PSP, DMR);
            PSP = Math.Max(PSP, DML);
            PSP = Math.Max(PSP, MC);
            PSP = Math.Max(PSP, ML);
            PSP = Math.Max(PSP, MR);
            PSP = Math.Max(PSP, OMC);
            PSP = Math.Max(PSP, OML);
            PSP = Math.Max(PSP, OMR);
            PSP = Math.Max(PSP, FC);

            PSP = PSP * (1M + (30M - Età) / Età);

            return PSP;
        }

        public override decimal GetPSP_GK(decimal[] atts, decimal Età)
        {
            decimal PO = atts[0];
            return PO * (1M + (30M - Età) / Età);
        }

        #region Private Functions
        private decimal[] DetermineSkillReduction(decimal[] skills, int FPn, int pos, decimal ada)
        {
            int[] fpos = Common.Tm_Utility.FPnToFPvector(FPn);
            decimal[] resskills = new decimal[14];

            decimal minReduction = Math.Max((decimal)GDS.A_Ada(fpos[0], pos, ada), (decimal)GDS.A_Ada(fpos[1], pos, ada));

            for (int i = 0; i < 14; i++)
            {
                resskills[i] = skills[i] * minReduction;
            }

            return resskills;
        }
        #endregion
    }

    public class NTR_RusCheratte_Function : NTR_GainFunction
    {
        public NTR_RusCheratte_Function()
        {
            Type = FunctionType.RusCheratte;
        }

        public override decimal[] GetAttitude_PL(decimal[] skills, int FPn, decimal Rou, decimal Ada)
        {
            DC = DR = DL = DMC = DMR = DML = MC = MR = ML = OMC = OML = OMR = FC = 0.0M;

            for (int skill = 0; skill < 13; skill++)
            {
                decimal fval = skills[skill];
                DC += 0.1M * (decimal)GDS.K_FP(skill, 0) * fval;
                DR += 0.1M * (decimal)GDS.K_FP(skill, 1) * fval;
                DL += 0.1M * (decimal)GDS.K_FP(skill, 2) * fval;
                DMC += 0.1M * (decimal)GDS.K_FP(skill, 3) * fval;
                DMR += 0.1M * (decimal)GDS.K_FP(skill, 4) * fval;
                DML += 0.1M * (decimal)GDS.K_FP(skill, 5) * fval;
                MC += 0.1M * (decimal)GDS.K_FP(skill, 6) * fval;
                MR += 0.1M * (decimal)GDS.K_FP(skill, 7) * fval;
                ML += 0.1M * (decimal)GDS.K_FP(skill, 8) * fval;
                OMC += 0.1M * (decimal)GDS.K_FP(skill, 9) * fval;
                OMR += 0.1M * (decimal)GDS.K_FP(skill, 10) * fval;
                OML += 0.1M * (decimal)GDS.K_FP(skill, 11) * fval;
                FC += 0.1M * (decimal)GDS.K_FP(skill, 12) * fval;
            }

            decimal kRou = GDS.funRou.Value(Rou);
            if (kRou > 1)
            {
                kRou = GDS.funRou.Value(Rou);
            }

            int[] fpVect = Common.Tm_Utility.FPnToFPvector(FPn);

            if (fpVect[1] == -1)
            {
                int n = fpVect[0];

                DC = DC * GDS.A_Ada(n, 0, Ada) * kRou;
                DR = DR * GDS.A_Ada(n, 1, Ada) * kRou;
                DL = DL * GDS.A_Ada(n, 2, Ada) * kRou;
                DMC = DMC * GDS.A_Ada(n, 3, Ada) * kRou;
                DMR = DMR * GDS.A_Ada(n, 4, Ada) * kRou;
                DML = DML * GDS.A_Ada(n, 5, Ada) * kRou;
                MC = MC * GDS.A_Ada(n, 6, Ada) * kRou;
                MR = MR * GDS.A_Ada(n, 7, Ada) * kRou;
                ML = ML * GDS.A_Ada(n, 8, Ada) * kRou;
                OMC = OMC * GDS.A_Ada(n, 9, Ada) * kRou;
                OMR = OMR * GDS.A_Ada(n, 10, Ada) * kRou;
                OML = OML * GDS.A_Ada(n, 11, Ada) * kRou;
                FC = FC * GDS.A_Ada(n, 12, Ada) * kRou;
            }
            else
            {
                int n1 = fpVect[0];
                int n2 = fpVect[1];

                DC = Math.Max(DC * GDS.A_Ada(n1, 0, Ada), DC * GDS.A_Ada(n2, 0, Ada)) * kRou;
                DR = Math.Max(DR * GDS.A_Ada(n1, 1, Ada), DR * GDS.A_Ada(n2, 1, Ada)) * kRou;
                DL = Math.Max(DL * GDS.A_Ada(n1, 2, Ada), DL * GDS.A_Ada(n2, 2, Ada)) * kRou;
                DMC = Math.Max(DMC * GDS.A_Ada(n1, 3, Ada), DMC * GDS.A_Ada(n2, 3, Ada)) * kRou;
                DMR = Math.Max(DMR * GDS.A_Ada(n1, 4, Ada), DMR * GDS.A_Ada(n2, 4, Ada)) * kRou;
                DML = Math.Max(DML * GDS.A_Ada(n1, 5, Ada), DML * GDS.A_Ada(n2, 5, Ada)) * kRou;
                MC = Math.Max(MC * GDS.A_Ada(n1, 6, Ada), MC * GDS.A_Ada(n2, 6, Ada)) * kRou;
                MR = Math.Max(MR * GDS.A_Ada(n1, 7, Ada), MR * GDS.A_Ada(n2, 7, Ada)) * kRou;
                ML = Math.Max(ML * GDS.A_Ada(n1, 8, Ada), ML * GDS.A_Ada(n2, 8, Ada)) * kRou;
                OMC = Math.Max(OMC * GDS.A_Ada(n1, 9, Ada), OMC * GDS.A_Ada(n2, 9, Ada)) * kRou;
                OMR = Math.Max(OMR * GDS.A_Ada(n1, 10, Ada), OMR * GDS.A_Ada(n2, 10, Ada)) * kRou;
                OML = Math.Max(OML * GDS.A_Ada(n1, 11, Ada), OML * GDS.A_Ada(n2, 11, Ada)) * kRou;
                FC = Math.Max(FC * GDS.A_Ada(n1, 12, Ada), FC * GDS.A_Ada(n2, 12, Ada)) * kRou;
            }

            if (NormalizeGains)
            {
                DC *= (decimal)GDS.K_DEM[0];
                DR *= (decimal)GDS.K_DEM[1];
                DL *= (decimal)GDS.K_DEM[2];
                DMC *= (decimal)GDS.K_DEM[3];
                DMR *= (decimal)GDS.K_DEM[4];
                DML *= (decimal)GDS.K_DEM[5];
                MC *= (decimal)GDS.K_DEM[6];
                MR *= (decimal)GDS.K_DEM[7];
                ML *= (decimal)GDS.K_DEM[8];
                OMC *= (decimal)GDS.K_DEM[9];
                OMR *= (decimal)GDS.K_DEM[10];
                OML *= (decimal)GDS.K_DEM[11];
                FC *= (decimal)GDS.K_DEM[12];
            }

            return Atts;
        }

        public override decimal[] GetAttitude_GK(decimal[] skills, decimal Rou)
        {
            decimal[] PO = new decimal[1];

            for (int skill = 0; skill < 11; skill++)
            {
                decimal fval = skills[skill];
                PO[0] += 0.1M * (decimal)GDS.K_GK(skill) * fval;
            }

            decimal kRou = GDS.funRou.Value(Rou);
            if (kRou > 1)
            {
                kRou = GDS.funRou.Value(Rou);
            }

            PO[0] = PO[0] * kRou;

            return PO;
        }

        public override decimal GetOSi_PL(decimal[] atts, decimal[] skills)
        {
            decimal AttMax = 0;
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

            decimal skillsSum = 0.0M;
            foreach (decimal skill in skills)
            {
                skillsSum += skill;
            }

            decimal OSi = (100M - (skillsSum * 5 - AttMax) / 10.0M) * AttMax / 50M;
            decimal k = (AttMax * AttMax * AttMax) / (27000M + (AttMax * AttMax * AttMax));
            return k * OSi * (OSi / 25M);
        }

        public override decimal GetOSi_GK(decimal[] atts, decimal[] skills)
        {
            decimal GK = atts[0];

            decimal SkS = 0.0M;
            foreach (decimal skill in skills)
            {
                SkS += skill;
            }

            // return GK / (skillsSum / 110f);
            decimal OSi = (100M - (SkS * 5 - GK) / 10.0M) * GK / 50M;
            decimal k = (GK * GK * GK) / (27000M + (GK * GK * GK));
            return k * OSi * (OSi / 50M);
        }

        public override decimal GetPSP_PL(decimal[] atts, decimal Età)
        {
            decimal PSP = 0.0M;

            Atts = atts;

            // Find the maximum speciality result
            PSP = Math.Max(DC, DL);
            PSP = Math.Max(PSP, DR);
            PSP = Math.Max(PSP, DMC);
            PSP = Math.Max(PSP, DMR);
            PSP = Math.Max(PSP, DML);
            PSP = Math.Max(PSP, MC);
            PSP = Math.Max(PSP, ML);
            PSP = Math.Max(PSP, MR);
            PSP = Math.Max(PSP, OMC);
            PSP = Math.Max(PSP, OML);
            PSP = Math.Max(PSP, OMR);
            PSP = Math.Max(PSP, FC);

            PSP = PSP * (1M + (30M - Età) / Età);

            return PSP;
        }

        public override decimal GetPSP_GK(decimal[] atts, decimal Età)
        {
            decimal PO = atts[0];
            return PO * (1M + (30M - Età) / Età);
        }
    }

    public class NTR_Function
    {
        public NTR_Function(FunctionType function, float[] pars)
        {
            Params = pars;
            Type = function;
        }

        public NTR_Function()
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

        private float Linear(float x)
        {
            if (Params.Length >= 2) return Params[0] + x * Params[1];
            else return 1.0F;
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

        private decimal Linear(decimal x)
        {
            if (Params.Length >= 2) return (decimal)Params[0] + x * (decimal)Params[1];
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
