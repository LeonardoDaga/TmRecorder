using System;
using Common;
using NTR_Common;

namespace NTR_Db
{
    public class PlayerDataSkills
    {
        public static PlayerDataSkills From(PlayerData playerData)
        {
            PlayerDataSkills pDS = new PlayerDataSkills();

            pDS.FPn = playerData.FPn;
            pDS.SPn = playerData.SPn;

            pDS.SkillSum = 0;

            for (int i = 0; i < ((pDS.FPn == 0) ? 11 : 14); i++)
            {
                pDS.Skills[i] = (double)playerData.Skills[i].actual;
                pDS.SkillSum += pDS.Skills[i];
            }
            pDS.ASI = playerData.ASI.actual;
            pDS.Rou = (double)playerData.Rou;
            pDS.Ada = (double)playerData.Ada;
            pDS.wBorn = playerData.wBorn;

            pDS.Hidden = new Hidden
            {
                Ada = (double)playerData.Ada,
                Inj = (double)playerData.InjPron,
                Pro = (playerData.Professionalism != null?(float)playerData.Professionalism:0.0),
                Agg = (playerData.Aggressivity != null ? (float)playerData.Aggressivity : 0.0),
            };

            return pDS;
        }

        public static PlayerDataSkills From(TeamDS.GiocatoriNSkillRow gnsRow)
        {
            PlayerDataSkills pDS = new PlayerDataSkills();

            pDS.SkillSum = 0;

            pDS.FPn = gnsRow.FPn;

            for (int i = 0; i < ((pDS.FPn == 0) ? 11 : 14); i++)
            {
                pDS.Skills[i] = (double)gnsRow.Skills[i];
                pDS.SkillSum += pDS.Skills[i];
            }

            pDS.ASI = gnsRow.ASI;
            pDS.Rou = (double)gnsRow.Rou;

            if (!gnsRow.IsAdaNull())
            {
                pDS.Hidden = new Hidden
                {
                    Ada = (double)gnsRow.Ada,
                    Inj = (double)(gnsRow.IsInjPronNull()?0:gnsRow.InjPron),
                    Pro = (double)(gnsRow.IsProNull() ? 0 : gnsRow.Pro),
                    Agg = (double)(gnsRow.IsAggNull() ? 0 : gnsRow.Agg)
                };
            }

            pDS.Ada = (double)gnsRow.Ada;
            pDS.wBorn = gnsRow.wBorn;

            return pDS;
        }

        public string Name { get; private set; }
        public double[] Skills = new double[14];
        public int ASI { get; private set; }
        public double Rou { get; private set; }
        public double Ada { get; private set; }
        public int FPn { get; private set; }
        public int SPn { get; private set; }
        public double SkillSum { get; private set; }
        public double Wage { get; private set; }

        public Hidden Hidden { get; private set; }

        public static PlayerDataSkills From(ExtTMDataSet.PlayerHistoryRow pr, 
            int FPn,
            double Rou = 0,
            int? Wage = null)
        {
            PlayerDataSkills pDS = new PlayerDataSkills();

            for (int i = 0; i < ((FPn == 0)?11:14); i++)
            {
                pDS.Skills[i] = (double)(decimal)pr.ItemArray[i + 1];
                pDS.SkillSum += pDS.Skills[i];
            }

            pDS.Rou = Rou;
            pDS.ASI = pr.ASI;
            pDS.FPn = FPn;
            pDS.Ada = 0;
            pDS.Wage = (double)((Wage == null)?0:Wage); 

            return pDS;
        }

        public static PlayerDataSkills From(ExtTMDataSet.GiocatoriNSkillRow gnsr)
        {
            PlayerDataSkills pDS = new PlayerDataSkills();

            for (int i = 0; i < ((gnsr.FPn == 0) ? 11 : 14); i++)
            {
                pDS.Skills[i] = (double)(decimal)gnsr.ItemArray[i + 7];
                pDS.SkillSum += pDS.Skills[i];
            }

            pDS.Rou = (double)gnsr.Rou;
            pDS.ASI = gnsr.ASI;
            pDS.FPn = gnsr.FPn;
            if (!gnsr.IsAdaNull())
                pDS.Ada = (double)gnsr.Ada;
            pDS.SPn = Tm_Utility.FPnToSPn(gnsr.FPn);

            pDS.Name = gnsr.Nome.Split('|')[0];
            pDS.Num = gnsr.Numero;
            pDS.ID = gnsr.PlayerID;
            pDS.wBorn = gnsr.wBorn;

            return pDS;
        }

        public double Str => Skills[0];
        public double Sta => Skills[1];
        public double Pac => Skills[2];

        public double Mar => Skills[3];
        public double Tac => Skills[4];
        public double Wor => Skills[5];
        public double Pos => Skills[6];
        public double Pas => Skills[7];
        public double Cro => Skills[8];
        public double Tec => Skills[9];
        public double Hea => Skills[10];
        public double Fin => Skills[11];
        public double Lon => Skills[12];
        public double Set => Skills[13];

        public double Han => Skills[3];
        public double One => Skills[4];
        public double Ref => Skills[5];
        public double Aer => Skills[6];
        public double Jum => Skills[7];
        public double Com => Skills[8];
        public double Kic => Skills[9];
        public double Thr => Skills[10];

        public int Num { get; private set; }
        public int ID { get; private set; }
        public int wBorn { get; private set; }
    }

    public class Hidden
    {
        public double Pro { get; set; }
        public double Agg { get; set; }
        public double Inj { get; set; }
        public double Ada { get; set; }
    }
}
