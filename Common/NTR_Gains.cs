using System.Data;
using System;

namespace Common
{
    partial class NTR_Gains
    {
        public string GainDSfilename = "";
        public float[] K_DEM = null;
        string[] spec = new string[] { "DC", "DR", "DL", "DMC", "DMR", "DML", "MC", "MR", "ML", "OMC", "OMR", "OML", "FC" };
        string[] fpSkill = new string[] { "Str", "Sta", "Pac", "Mar", "Tak", "Wor", "Pos", "Pas", "Cro", "Tec", "Hea", "Fin", "Lon", "Set" };
        string[] gkSkill = new string[] { "Str", "Sta", "Pac", "Han", "One", "Ref", "Ari", "Jum", "Com", "Kic", "Thr" };
        float _Amax = 0.0f;
        public NTR_Function funRou = new NTR_Function();

        private NTR_GainFunction _funGain = null;
        public NTR_GainFunction FunGain
        {
            get { return _funGain; }
            set
            {
                _funGain = value;
                FunGain.NormalizeGains = _normalizeGains;
            }
        }

        private bool _normalizeGains;
        public bool NormalizeGains
        {
            get { return _normalizeGains; }
            set
            {
                _normalizeGains = value;
                if (_funGain != null)
                    _funGain.NormalizeGains = _normalizeGains;
            }
        }

        partial class SkillFPGainDataTable
        {
        }

        public new XmlReadMode ReadXml(string namefile)
        {
            XmlReadMode xlmRM = base.ReadXml(namefile);

            Set_KSum_Gain();

            return xlmRM;
        }

        private void Set_KSum_Gain()
        {
            float K_Max = 0.0f;

            K_DEM = new float[spec.Length];

            for (int j = 0; j < spec.Length; j++)
            {
                K_DEM[j] = 0.0f;

                for (int i = 0; i < spec.Length; i++)
                {
                    K_DEM[j] = K_DEM[j] + K_FP(i, j);
                }

                if (K_Max < K_DEM[j]) K_Max = K_DEM[j];
            }

            for (int j = 0; j < spec.Length; j++)
            {
                K_DEM[j] = K_Max / K_DEM[j];
            }
        }

        public float K_FP(int skill, int spec)
        {
            float k = (float)this.SkillFPGain[skill][spec + 1];
            return k;
        }

        public decimal K_FPn_Max(int skill, int FPn)
        {
            int[] FpVect = Tm_Utility.FPnToFPvector(FPn);

            float k = 0;
            if (FpVect[1] == -1)
                k = (float)this.SkillFPGain[skill][FpVect[0] + 1];
            else
                k = Math.Max((float)this.SkillFPGain[skill][FpVect[0] + 1],
                             (float)this.SkillFPGain[skill][FpVect[1] + 1]);
            return (decimal)k;
        }
        public float A_FP(int aspec, int spec)
        {
            return (float)this.SpecFPAmpl[aspec][spec + 1];
        }
        public float K_GK(int skill)
        {
            return (float)this.SkillGKGain[skill][1];
        }
        public float A_max
        {
            get
            {
                if (_Amax == 0)
                {
                    for (int i = 0; i < SpecFPAmpl.Rows.Count; i++)
                    {
                        for (int j = 1; j < SpecFPAmpl.Columns.Count; j++)
                        {
                            if (_Amax < (float)SpecFPAmpl[i][j])
                            {
                                _Amax = (float)SpecFPAmpl[i][j];
                            }
                        }
                    }
                }
                return _Amax;
            }
        }

        public void SetDefaultValues()
        {
            // Speciality FP amplification
            float[,] A = new float[,]{  {1.666f,1.331f,1.331f,1.496f,1.166f,1.166f,1.336f,1.000f,1.000f,1.167f,1.000f,1.000f,1.000f},
                                        {1.331f,1.666f,1.500f,1.164f,1.500f,1.331f,1.166f,1.337f,1.167f,1.000f,1.333f,1.167f,1.000f},
                                        {1.331f,1.500f,1.666f,1.164f,1.331f,1.500f,1.166f,1.167f,1.337f,1.000f,1.167f,1.333f,1.000f},
                                        {1.498f,1.166f,1.166f,1.664f,1.331f,1.331f,1.502f,1.167f,1.167f,1.335f,1.000f,1.000f,1.000f},
                                        {1.164f,1.500f,1.331f,1.332f,1.666f,1.500f,1.000f,1.504f,1.337f,1.000f,1.333f,1.167f,1.000f},
                                        {1.164f,1.331f,1.500f,1.332f,1.500f,1.666f,1.000f,1.337f,1.504f,1.000f,1.167f,1.333f,1.000f},
                                        {1.331f,1.000f,1.000f,1.496f,1.166f,1.166f,1.668f,1.337f,1.337f,1.498f,1.167f,1.167f,1.332f},
                                        {1.000f,1.331f,1.166f,1.164f,1.500f,1.331f,1.336f,1.670f,1.504f,1.167f,1.500f,1.333f,1.000f},
                                        {1.000f,1.166f,1.331f,1.164f,1.331f,1.500f,1.336f,1.504f,1.670f,1.167f,1.333f,1.500f,1.000f},
                                        {1.164f,1.000f,1.000f,1.332f,1.000f,1.000f,1.502f,1.167f,1.167f,1.665f,1.333f,1.333f,1.502f},
                                        {1.000f,1.166f,1.000f,1.000f,1.331f,1.166f,1.166f,1.504f,1.337f,1.335f,1.667f,1.500f,1.166f},
                                        {1.000f,1.000f,1.166f,1.000f,1.166f,1.331f,1.166f,1.337f,1.504f,1.335f,1.500f,1.667f,1.166f},
                                        {1.000f,1.000f,1.000f,1.164f,1.000f,1.000f,1.336f,1.000f,1.000f,1.498f,1.167f,1.167f,1.668f}};

            // Skill FP Gain
            float[,] K = new float[,] { {4.000f,3.000f,3.000f,2.880f,3.000f,3.000f,2.000f,1.560f,1.560f,1.910f,2.630f,2.630f,4.240f},
                                        {0.330f,0.430f,0.430f,1.680f,0.430f,0.430f,2.000f,1.560f,1.560f,0.270f,2.630f,2.630f,2.470f},
                                        {4.000f,5.140f,5.140f,1.680f,5.140f,5.140f,0.290f,2.670f,2.670f,0.270f,4.500f,4.500f,2.470f},
                                        {4.000f,5.140f,5.140f,2.880f,5.140f,5.140f,3.430f,2.670f,2.670f,1.910f,0.380f,0.380f,0.350f},
                                        {4.000f,5.140f,5.140f,2.880f,5.140f,5.140f,3.430f,2.670f,2.670f,1.910f,0.380f,0.380f,0.350f},
                                        {0.330f,0.430f,0.430f,2.880f,0.430f,0.430f,3.430f,2.670f,2.670f,3.270f,2.630f,2.630f,2.470f},
                                        {0.330f,0.430f,0.430f,2.880f,0.430f,0.430f,3.430f,2.670f,2.670f,3.270f,2.630f,2.630f,2.470f},
                                        {2.330f,3.000f,3.000f,2.880f,3.000f,3.000f,3.430f,2.670f,2.670f,3.270f,0.380f,0.380f,0.350f},
                                        {2.330f,3.000f,3.000f,1.680f,3.000f,3.000f,0.290f,2.670f,2.670f,0.270f,4.500f,4.500f,0.350f},
                                        {2.330f,3.000f,3.000f,1.680f,3.000f,3.000f,3.430f,2.670f,2.670f,3.270f,4.500f,4.500f,2.470f},
                                        {4.000f,3.000f,3.000f,2.880f,3.000f,3.000f,2.000f,1.560f,1.560f,1.910f,2.630f,2.630f,4.240f},
                                        {0.330f,0.430f,0.430f,0.240f,0.430f,0.430f,0.290f,0.220f,0.220f,3.270f,2.630f,2.630f,4.240f},
                                        {0.330f,0.430f,0.430f,0.240f,0.430f,0.430f,0.290f,0.220f,0.220f,3.270f,2.630f,2.630f,4.240f},
                                        {0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f}};

            float[] gkK = new float[] { 6.3636f, 0f, 6.3636f, 11.8181f, 6.3636f, 10.9090f, 6.3636f, 6.3636f, 0f, 0f, 0f };

            this.SkillFPGain.Clear();
            this.SpecFPAmpl.Clear();
            this.SkillGKGain.Clear();

            for (int sk = 0; sk < fpSkill.Length; sk++)
            {
                SkillFPGainRow row = this.SkillFPGain.NewSkillFPGainRow();

                row[0] = fpSkill[sk];
                for (int sp = 0; sp < spec.Length; sp++)
                {
                    row[1 + sp] = K[sk, sp];
                }

                this.SkillFPGain.AddSkillFPGainRow(row);
            }

            for (int spa = 0; spa < spec.Length; spa++)
            {
                SpecFPAmplRow row = this.SpecFPAmpl.NewSpecFPAmplRow();

                row[0] = spec[spa];
                for (int sp = 0; sp < spec.Length; sp++)
                {
                    row[1 + sp] = A[spa, sp];
                }

                this.SpecFPAmpl.AddSpecFPAmplRow(row);
            }

            for (int sk = 0; sk < gkSkill.Length; sk++)
            {
                SkillGKGainRow row = this.SkillGKGain.NewSkillGKGainRow();

                row[0] = gkSkill[sk];
                row[1] = gkK[sk];

                this.SkillGKGain.AddSkillGKGainRow(row);
            }

            {
                SetNameRow row = this.SetName.NewSetNameRow();
                row[0] = "RUS Cheratte DataSet";
                this.SetName.AddSetNameRow(row);
                GainDSfilename = "RUSCheratte.xml";
            }

            Set_KSum_Gain();
        }

        public decimal A_Ada(int row, int col, decimal ada)
        {
            decimal k = (decimal)A_FP(row, col);
            return (k + ada / 20.0M * ((decimal)A_max - k));
        }

        public float A_Ada(int row, int col, float ada)
        {
            float k = A_FP(row, col);
            return (k + (float)ada / 20.0f * (A_max - k));
        }
    }
}
