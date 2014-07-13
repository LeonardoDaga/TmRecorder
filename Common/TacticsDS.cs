namespace Common 
{    
    public partial class TacticsDS 
    {
        public enum PossMode : int
        {
            Keeping = 0,
            Gaining = 1
        }

        public enum Tactics : int
        {
            Std = 0,
            Win = 1,
            ShP = 2,
            Dir = 3,
            ThP = 4,
            Lon = 5,
            Tot = 6,
        }

        public enum ActionType : int
        {
            ShP = 0,
            Cro = 1,
            Lon = 2,
            Dir = 3,
            ThP = 4,
            Fre = 5,
            Cor = 6,
            Pen = 7,
            Tot = 8,
        }

        public float[] BallKeepingAndGaining(ExtTMDataSet.GiocatoriNSkillRow gnsr)
        {
            PossessionRow prK = this.tablePossession[(int)PossMode.Keeping];
            PossessionRow prG = this.tablePossession[(int)PossMode.Gaining];

            float[] val = new float[2];
            float[] sval = new float[2];
            val[0] = 0.0f;
            val[1] = 0.0f;
            sval[0] = 0.0f;
            sval[1] = 0.0f;

            for (int i = 0; i < 14; i++)
            {
                float skVal = (float)(decimal)gnsr[7 + i];
                float vK = (float)prK[1 + i];
                float vG = (float)prG[1 + i];
                val[0] += skVal * vK;
                val[1] += skVal * vG;
                sval[0] += vK;
                sval[1] += vG;
            }
            val[0] /= sval[0];
            val[1] /= sval[1];

            val[0] *= 5;
            val[1] *= 5;

            return val;
        }

        public float[,] TacticsScore(ExtTMDataSet.GiocatoriNSkillRow gnsr, int position)
        {
            float[,] vTct = new float[(int)Tactics.Tot, 3];
            string rule = Position.BitP2String((int)position);

            for (int tact = 0; tact < (int)Tactics.Tot; tact++)
            {
                float vAcCSum = 0.0f;
                float vAcFSum = 0.0f;
                float vDefSum = 0.0f;

                vTct[tact, 0] = 0.0f;
                vTct[tact, 1] = 0.0f;
                vTct[tact, 2] = 0.0f;

                for (int actType = 0; actType < (int)ActionType.Tot; actType++)
                {
                    float fAct = (float)this.tableTactics2Actions[tact][actType + 1];

                    ActionConstructionRow acr = tableActionConstruction.FindByActionRule(actType.ToString(), rule);
                    if (acr == null)
                        acr = tableActionConstruction.FindByActionRule(actType.ToString(), "ALL");
                    ActionFinalizationRow afr = tableActionFinalization.FindByActionRule(actType.ToString(), rule);
                    if (afr == null)
                        afr = tableActionFinalization.FindByActionRule(actType.ToString(), "ALL");
                    DefenseRow dr = tableDefense.FindByActionRule(actType.ToString(), rule);
                    if (dr == null)
                        dr = tableDefense.FindByActionRule(actType.ToString(), "ALL");

                    float vActCSk = 0.0f;
                    float vActFSk = 0.0f;
                    float vDefnSk = 0.0f;

                    float vAcSum = 0.0f;
                    float vAfSum = 0.0f;
                    float vDfSum = 0.0f;

                    for (int sk = 0; sk < 14; sk++)
                    {
                        float skVal = (float)(decimal)gnsr[7 + sk];

                        if (acr != null)
                        {
                            float vAC = (float)acr[2 + sk];
                            vActCSk += skVal * vAC;
                            vAcSum += vAC;
                        }

                        if (afr != null)
                        {
                            float vAF = (float)afr[2 + sk];
                            vActFSk += skVal * vAF;
                            vAfSum += vAF;
                        }

                        if (dr != null)
                        {
                            float vD = (float)dr[2 + sk];
                            vDefnSk += skVal * vD;
                            vDfSum += vD;
                        }
                    }

                    vTct[tact, 0] += vActCSk * (fAct / 100.0f);
                    vTct[tact, 1] += vActFSk * (fAct / 100.0f);
                    vTct[tact, 2] += vDefnSk * (fAct / 100.0f);

                    vAcCSum += (fAct / 100.0f);
                    vAcFSum += (fAct / 100.0f);
                    vDefSum += (fAct / 100.0f);
                }

                vTct[tact, 0] /= vAcCSum;
                vTct[tact, 1] /= vAcFSum;
                vTct[tact, 2] /= vDefSum;
            }

            return vTct;
        }
    }
}
