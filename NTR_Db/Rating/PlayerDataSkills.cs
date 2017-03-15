﻿using Common;
using NTR_Common;

namespace NTR_Db
{
    public class PlayerDataSkills
    {
        public static PlayerDataSkills From(PlayerData playerData)
        {
            PlayerDataSkills pDS = new PlayerDataSkills();

            pDS.FPn = playerData.FPn;

            pDS.SkillSum = 0;

            for (int i = 0; i < ((pDS.FPn == 0)?11:14); i++)
            {
                pDS.Skills[i] = (double)playerData.Skills[i].actual;
                pDS.SkillSum += pDS.Skills[i];
            }
            pDS.ASI = playerData.ASI.actual;
            pDS.Rou = (double)playerData.Rou;
            pDS.Ada = (double)playerData.Ada;

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
            pDS.Ada = (double)gnsRow.Ada;

            return pDS;
        }

        public double[] Skills = new double[14];
        public int ASI { get; private set; }
        public double Rou { get; private set; }
        public double Ada { get; private set; }
        public int FPn { get; private set; }
        public double SkillSum { get; private set; }
    }
}