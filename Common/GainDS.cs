using System;
using System.Data;

namespace Common
{
    partial class GainDS
    {
        partial class TacticsGainDataTable
        {
        }

        public string GainDSfilename = "";
        public float[] K_DEM = null;
        string[] spec = new string[] { "DC", "DR", "DL", "DMC", "DMR", "DML", "MC", "MR", "ML", "OMC", "OMR", "OML", "FC" };
        string[] fpSkill = new string[] { "Str", "Sta", "Pac", "Mar", "Tak", "Wor", "Pos", "Pas", "Cro", "Tec", "Hea", "Fin", "Lon", "Set" };
        string[] gkSkill = new string[] { "Str", "Sta", "Pac", "Han", "One", "Ref", "Ari", "Jum", "Com", "Kic", "Thr" };
        string[] tactSkill = new string[] { "DirD", "DirA", "WinD", "WinA", "ShPD", "ShPA", "LonD", "LonA", "ThrD", "ThrA" };

        // Skill Tactics Gain
        static float[,] T = new float[,] { {0.000f,0.556f,0.556f,1.111f,0.556f,1.111f,1.111f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f},
                                        {0.000f,1.250f,1.250f,0.000f,0.000f,0.625f,0.625f,1.250f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f},
                                        {0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,2.000f,2.000f,1.000f,0.000f},
                                        {0.278f,0.278f,1.111f,1.111f,1.111f,0.556f,0.556f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f},
                                        {0.294f,0.588f,1.176f,0.000f,0.000f,0.588f,0.000f,0.000f,1.176f,1.176f,0.000f,0.000f,0.000f,0.000f},
                                        {0.200f,0.400f,0.800f,0.000f,0.000f,0.400f,0.000f,0.000f,0.800f,0.800f,0.800f,0.600f,0.200f,0.000f},
                                        {0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,2.500f,1.875f,0.625f,0.000f},
                                        {0.000f,0.455f,0.909f,0.909f,0.909f,0.909f,0.909f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f},
                                        {0.000f,0.625f,0.625f,0.000f,0.000f,0.625f,0.625f,1.250f,0.000f,1.250f,0.000f,0.000f,0.000f,0.000f},
                                        {0.000f,0.417f,0.417f,0.000f,0.000f,0.417f,0.417f,0.833f,0.000f,0.833f,0.417f,0.833f,0.417f,0.000f},
                                        {0.435f,0.217f,0.870f,0.870f,0.435f,0.870f,0.870f,0.000f,0.000f,0.000f,0.435f,0.000f,0.000f,0.000f},
                                        {0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,2.000f,1.500f,1.500f,0.000f,0.000f,0.000f,0.000f},
                                        {0.909f,0.682f,0.000f,0.000f,0.000f,0.682f,0.682f,0.000f,0.000f,0.000f,0.909f,0.909f,0.227f,0.000f},
                                        {0.000f,0.556f,0.833f,1.111f,1.111f,0.556f,0.833f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f,0.000f},
                                        {0.000f,0.625f,0.313f,0.000f,0.000f,0.625f,0.625f,1.250f,0.313f,1.250f,0.000f,0.000f,0.000f,0.000f},
                                        {0.000f,0.426f,0.851f,0.000f,0.000f,0.426f,0.426f,0.426f,0.213f,0.426f,0.213f,0.957f,0.638f,0.000f} };

        static string[,] TRul = new string[,] {{"DirD","Dir","D",  "DC,DL,DR,DMC,DMR,DML"               },
                                            {"Dir1","Dir","A",  "DC,DL,DR,DMC,DMR,DML,MC,ML,MR,OMC,OMR,OML"          },
                                            {"Dir2","Dir","A",  "FC"                  },
                                            {"WinD","Win","D",  "DR,DL,DMR,DML"      },
                                            {"Win1","Win","A",  "DL,DR,DML,DMR,MR,ML"},
                                            {"Win2","Win","A",  "OML,OMR"            },
                                            {"Win3","Win","A",  "OMC,FC"              },
                                            {"ShP1","ShP","D",  "DC,DL,DR,DMC,DMR,DML"               },
                                            {"ShP2","ShP","A",  "DC,DL,DR,DMC,DMR,DML,MC,ML,MR"             },
                                            {"ShP3","ShP","A",  "OMC,OMR,OML,FC"               },
                                            {"LonD","Lon","D",  "DC,DL,DR,DMC,DMR,DML"               },
                                            {"Lon1","Lon","A",  "DC,DL,DR,DMC,DMR,DML"               },
                                            {"Lon2","Lon","A",  "OMC,OMR,OML,FC"               },
                                            {"ThrD","Thr","D",  "DC,DL,DR,DMC,DMR,DML"               },
                                            {"Thr1","Thr","A",  "DMC,DMR,DML,MC,ML,MR"               },
                                            {"Thr2","Thr","A",  "OMC,OMR,OML,FC"               }};

        float _Amax = 0.0f;
        public Function funRou = new Function();

        partial class SkillFPGainDataTable
        {
        }

        private bool _normalizeGains;
        private static readonly int NumTactics = 6;

        public bool NormalizeGains
        {
            get { return _normalizeGains; }
            set
            {
                _normalizeGains = value;
            }
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

        /// <summary>
        /// Gain respect to the skill
        /// </summary>
        /// <param name="skill">skill</param>
        /// <param name="pos">actual position</param>
        /// <returns></returns>
        public float K_FP(int skill, int pos)
        {
            return (float)this.SkillFPGain[skill][pos + 1];
        }

        public decimal K_FPn_Max(int skill, int FPn)
        {
            int[] FpVect = Tm_Utility.FPnToFPvector(FPn);

            float k = 0;
            if (FpVect[1] == -1)
                k = (float)this.SkillFPGain[skill][FpVect[0] + 1];
            else
                k = System.Math.Max((float)this.SkillFPGain[skill][FpVect[0] + 1],
                             (float)this.SkillFPGain[skill][FpVect[1] + 1]);
            return (decimal)k;
        }

        /// <summary>
        /// Gain reduction for the out-of-position
        /// </summary>
        /// <param name="fpos">favourite position</param>
        /// <param name="pos">actual position</param>
        /// <returns></returns>
        public float A_FP(int fpos, int pos)
        {
            return (float)this.SpecFPAmpl[fpos][pos + 1];
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

        public float A_Ada(int row, int col, float ada)
        {
            float k = A_FP(row, col);
            return (k + ada / 20.0f * (A_max - k));
        }

        public decimal A_Ada(int row, int col, decimal ada)
        {
            float k = A_FP(row, col);
            return (decimal)(k + (float)(ada / 20.0M) * (A_max - k));
        }

        public bool CheckTacticsFilling()
        {
            if (TacticsGain.Count > 0) return false;

            TacticsGain.Clear();

            for (int i = 0; i < GainDS.T.GetUpperBound(0); i++)
            {
                TacticsGainRow tacticsRow = (TacticsGainRow)TacticsGain.NewRow();
                tacticsRow.Tactics = GainDS.TRul[i, 1];
                tacticsRow.DorA = GainDS.TRul[i, 2] == "D" ? 0 : 1;
                tacticsRow.FPos = GainDS.TRul[i, 3];
                tacticsRow.Str = T[i, 0];
                tacticsRow.Sta = T[i, 1];
                tacticsRow.Pac = T[i, 2];
                tacticsRow.Mar = T[i, 3];
                tacticsRow.Tac = T[i, 4];
                tacticsRow.Wor = T[i, 5];
                tacticsRow.Pos = T[i, 6];
                tacticsRow.Pas = T[i, 7];
                tacticsRow.Cro = T[i, 8];
                tacticsRow.Tec = T[i, 9];
                tacticsRow.Hea = T[i, 10];
                tacticsRow.Fin = T[i, 11];
                tacticsRow.Lon = T[i, 12];
                tacticsRow.Set = T[i, 13];

                TacticsGain.AddTacticsGainRow(tacticsRow);
            }

            return true;
        }
    }
}
