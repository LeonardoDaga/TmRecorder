using Common;
using NTR_Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTR_Db
{
    public class TacticsFunction : StdSettings
    {
        #region _plTacticsSPosDict
        public PlTacticsSPosDictionary _plTacticsSPosDict = new PlTacticsSPosDictionary()
        {
            {
                (Tactics.Type.Direct, 0), new List<(int SPs, double[])> 
                {
                    ((int)(eSP.D | eSP.DM),
                    new double[]{0,0.556,0.556,1.111,0.556,1.111,1.111,0,0,0,0,0,0,0,}),
                }
            },
            {
                (Tactics.Type.Direct, 1), new List<(int SPs, double[])>
                {
                    ((int)(eSP.D | eSP.DM | eSP.M | eSP.OM),
                    new double[]{0,1.25,1.25,0,0,0.625,0.625,1.25,0,0,0,0,0,0,}),
                    ((int)(eSP.FC),
                    new double[]{0,0,0,0,0,0,0,0,0,0,2,2,1,0,}),
                }
            },
            {
                (Tactics.Type.Wings, 0), new List<(int SPs, double[])>
                {
                    ((int)(eSP.DW | eSP.DMW),
                    new double[]{0.278,0.278,1.111,1.111,1.111,0.556,0.556,0,0,0,0,0,0,0}),
                }
            },
            {
                (Tactics.Type.Wings, 1), new List<(int SPs, double[])>
                {
                    ((int)(eSP.D | eSP.DM),
                    new double[]{0.294,0.588,1.176,0,0,0.588,0,0,1.176,1.176,0,0,0,0,}),
                    ((int)(eSP.OMW),
                    new double[]{0.2,0.4,0.8,0,0,0.4,0,0,0.8,0.8,0.8,0.6,0.2,0,}),
                    ((int)(eSP.OMC | eSP.FC),
                    new double[]{0,0,0,0,0,0,0,0,0,0,2.5,1.875,0.625,0,}),
                }
            },
            {
                (Tactics.Type.ShortPass, 0), new List<(int SPs, double[])>
                {
                    ((int)(eSP.D | eSP.DM),
                    new double[]{0,0.455,0.909,0.909,0.909,0.909,0.909,0,0,0,0,0,0,0,}),
                }
            },
            {
                (Tactics.Type.ShortPass, 1), new List<(int SPs, double[])>
                {
                    ((int)(eSP.D | eSP.DM | eSP.M),
                    new double[]{0,0.625,0.625,0,0,0.625,0.625,1.25,0,1.25,0,0,0,0,}),
                    ((int)(eSP.OM | eSP.FC),
                    new double[]{0,0.417,0.417,0,0,0.417,0.417,0.833,0,0.833,0.417,0.833,0.417,0,}),
                }
            },
            {
                (Tactics.Type.LongBalls, 0), new List<(int SPs, double[])>
                {
                    ((int)(eSP.D | eSP.DM),
                    new double[]{0.435,0.217,0.87,0.87,0.435,0.87,0.87,0,0,0,0.435,0,0,0,}),
                }
            },
            {
                (Tactics.Type.LongBalls, 1), new List<(int SPs, double[])>
                {
                    ((int)(eSP.D | eSP.DM),
                    new double[]{0,0,0,0,0,0,0,2,1.5,1.5,0,0,0,0,}),
                    ((int)(eSP.OM | eSP.FC),
                    new double[]{0.909,0.682,0,0,0,0.682,0.682,0,0,0,0.909,0.909,0.227,0,}),
                }
            },
            {
                (Tactics.Type.Through, 0), new List<(int SPs, double[])>
                {
                    ((int)(eSP.D | eSP.DM),
                    new double[]{0,0.556,0.833,1.111,1.111,0.556,0.833,0,0,0,0,0,0,0,}),
                }
            },
            {
                (Tactics.Type.Through, 1), new List<(int SPs, double[])>
                {
                    ((int)(eSP.DM | eSP.M),
                    new double[]{0,0.625,0.313,0,0,0.625,0.625,1.25,0.313,1.25,0,0,0,0}),
                }
            }
        };
        #endregion

        #region _gkTacticsSPosDict
        public GkTacticsSPosDictionary _gkTacticsSPosDict = new GkTacticsSPosDictionary()
        {
            { (Tactics.Type.Direct, 0), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.Wings, 0), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.ShortPass, 0), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.LongBalls, 0), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.Through, 0), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.Direct, 1), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.Wings, 1), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.ShortPass, 1), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.LongBalls, 1), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.Through, 1), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } }
        };
        #endregion

        public double ComputeTactics(PlayerDataSkills playerData, Tactics.Type type, int attacking)
        {
            double tactics = 0;

            if (playerData.FPn == 0)
            {
                double[] gkWeights = _gkTacticsSPosDict[(type, attacking)];

                for (int col = 0; col < 11; col++)
                {
                    tactics += playerData.Skills[col] * gkWeights[col];
                }

                return tactics;
            }

            eSP playerSP = SPn2eSP(playerData.SPn);

            var weights = _plTacticsSPosDict[(type, attacking)];

            var weight = weights.Where(c => (c.SPs & (int)playerSP) > 0);

            if (weight.Count() > 0)
            {
                double[] Weights = weight.Single().Weights;

                for (int col = 0; col < 14; col++)
                {
                    tactics += playerData.Skills[col] * Weights[col];
                }
            }
            else
            {
                for (int col = 0; col < 14; col++)
                {
                    tactics += playerData.Skills[col] * 5 / 14;
                }
            }

            return tactics;
        }

        public static TacticsFunction Create(List<TAC_PlWeights> tacPlWeights, 
            List<TAC_GkWeights> tacGkWeights, string fileName)
        {
            return new TacticsFunction(tacPlWeights, tacGkWeights, fileName);
        }

        public TacticsFunction(List<TAC_PlWeights> tacPlWeights,
            List<TAC_GkWeights> tacGkWeights, string fileName)
        {
            this._plTacticsSPosDict = Tactics.WeightListToDict(tacPlWeights);
            this._gkTacticsSPosDict = Tactics.WeightListToDict(tacGkWeights);
            this.SettingsFilename = fileName;
            SettingInitialize();
        }

        public TacticsFunction()
        { }

        public TacticsFunction(string fileName)
        {
            this.SettingsFilename = fileName;
            SettingInitialize();
        }

        private eSP SPn2eSP(int sPn)
        {
            string SP = Tm_Utility.FPnToFP(sPn);
            switch(SP)
            {
                case "GK": return eSP.GK;
                case "DC": return eSP.DC;
                case "DL": return eSP.DL;
                case "DR": return eSP.DR;
                case "DMC": return eSP.DMC;
                case "DML": return eSP.DML;
                case "DMR": return eSP.DMR;
                case "MC": return eSP.MC;
                case "ML": return eSP.ML;
                case "MR": return eSP.MR;
                case "OMC": return eSP.OMC;
                case "OML": return eSP.OML;
                case "OMR": return eSP.OMR;
                case "FC": return eSP.FC;
                default: return eSP.DC;
            }
        }

        public PlTacticsSPosDictionary PlTacticsSPosDict
        {
            get => (PlTacticsSPosDictionary)this["PlTacticsSPosDict"];
            set => this["PlTacticsSPosDict"] = value;
        }

        public GkTacticsSPosDictionary GkTacticsSPosDict
        {
            get => (GkTacticsSPosDictionary)this["GkTacticsSPosDict"];
            set => this["GkTacticsSPosDict"] = value;
        }

        public static List<TAC_PlWeights> PlWeightsMatrixToTable(PlTacticsSPosDictionary plTacticsSPosDict)
        {
            List<TAC_PlWeights> resList = new List<TAC_PlWeights>();
            foreach (var entry in plTacticsSPosDict)
            {
                foreach (var item in entry.Value)
                {
                    resList.Add(new TAC_PlWeights(item.Weights, entry.Key.tactics, entry.Key.atk, item.SPs));
                }
            }

            return resList;
        }

        public static List<TAC_GkWeights> GkWeightsMatrixToTable(GkTacticsSPosDictionary gkTacticsSPosDict)
        {
            List<TAC_GkWeights> resList = new List<TAC_GkWeights>();
            foreach (var entry in gkTacticsSPosDict)
            {
                var weights = entry.Value;

                resList.Add(new TAC_GkWeights(weights, entry.Key.tactics, entry.Key.atk));
            }

            return resList;
        }

        public static TacticsFunction Load(string fileName)
        {
            TacticsFunction tf = new TacticsFunction(fileName);

            if (!tf.SettingsFileExists())
                return null;

            tf.SettingInitialize();

            tf.Load();

            return tf;
        }

        private void SettingInitialize()
        {
            PlTacticsSPosDict = _plTacticsSPosDict;
            GkTacticsSPosDict = _gkTacticsSPosDict;
        }


        public static void CreateDefaultFunctions(string tacticsFunctionPath)
        {
            string tacticsFunctionDir = Path.GetDirectoryName(tacticsFunctionPath);

            TacticsFunction tf = new TacticsFunction();
            tf.SettingInitialize();

            string tacticsFunctionFile = Path.Combine(tacticsFunctionDir, "Default.tactics");

            tf.SettingsFilename = tacticsFunctionFile;
            tf.Save();
        }
    }
}
