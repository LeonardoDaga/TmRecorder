using Common;
using NTR_Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NTR_Common.Tactics;

namespace NTR_Db
{
    public class TacticsFunction : StdSettings
    {
        #region _plTacticsSPosDict
        public PlTacticsSPosDictionary _plTacticsSPosDict = new PlTacticsSPosDictionary()
        {
            {
                (Tactics.Type.Dir, 0), new List<(int SPs, double[])> 
                {
                    ((int)(eSP.D | eSP.DM),
                    new double[]{0,0.556,0.556,1.111,0.556,1.111,1.111,0,0,0,0,0,0,0,}),
                }
            },
            {
                (Tactics.Type.Dir, 1), new List<(int SPs, double[])>
                {
                    ((int)(eSP.D | eSP.DM | eSP.M | eSP.OM),
                    new double[]{0,1.25,1.25,0,0,0.625,0.625,1.25,0,0,0,0,0,0,}),
                    ((int)(eSP.FC),
                    new double[]{0,0,0,0,0,0,0,0,0,0,2,2,1,0,}),
                }
            },
            {
                (Tactics.Type.Win, 0), new List<(int SPs, double[])>
                {
                    ((int)(eSP.DW | eSP.DMW),
                    new double[]{0.278,0.278,1.111,1.111,1.111,0.556,0.556,0,0,0,0,0,0,0}),
                }
            },
            {
                (Tactics.Type.Win, 1), new List<(int SPs, double[])>
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
                (Tactics.Type.Sho, 0), new List<(int SPs, double[])>
                {
                    ((int)(eSP.D | eSP.DM),
                    new double[]{0,0.455,0.909,0.909,0.909,0.909,0.909,0,0,0,0,0,0,0,}),
                }
            },
            {
                (Tactics.Type.Sho, 1), new List<(int SPs, double[])>
                {
                    ((int)(eSP.D | eSP.DM | eSP.M),
                    new double[]{0,0.625,0.625,0,0,0.625,0.625,1.25,0,1.25,0,0,0,0,}),
                    ((int)(eSP.OM | eSP.FC),
                    new double[]{0,0.417,0.417,0,0,0.417,0.417,0.833,0,0.833,0.417,0.833,0.417,0,}),
                }
            },
            {
                (Tactics.Type.Lon, 0), new List<(int SPs, double[])>
                {
                    ((int)(eSP.D | eSP.DM),
                    new double[]{0.435,0.217,0.87,0.87,0.435,0.87,0.87,0,0,0,0.435,0,0,0,}),
                }
            },
            {
                (Tactics.Type.Lon, 1), new List<(int SPs, double[])>
                {
                    ((int)(eSP.D | eSP.DM),
                    new double[]{0,0,0,0,0,0,0,2,1.5,1.5,0,0,0,0,}),
                    ((int)(eSP.OM | eSP.FC),
                    new double[]{0.909,0.682,0,0,0,0.682,0.682,0,0,0,0.909,0.909,0.227,0,}),
                }
            },
            {
                (Tactics.Type.Thr, 0), new List<(int SPs, double[])>
                {
                    ((int)(eSP.D | eSP.DM),
                    new double[]{0,0.556,0.833,1.111,1.111,0.556,0.833,0,0,0,0,0,0,0,}),
                }
            },
            {
                (Tactics.Type.Thr, 1), new List<(int SPs, double[])>
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
            { (Tactics.Type.Dir, 0), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.Win, 0), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.Sho, 0), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.Lon, 0), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.Thr, 0), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.Dir, 1), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.Win, 1), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.Sho, 1), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.Lon, 1), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } },
            { (Tactics.Type.Thr, 1), new double[]{ 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45, 0.45 } }
        };
        #endregion

        #region _tacticsToActionDict
        public TacticsToAcionDictionary _tacticsToActionDict = new TacticsToAcionDictionary()
        {
            { Tactics.Type.Std, new double[]{ 25.2, 13.8, 10.7, 8.97, 18.8, 5.29, 16.8, 0.5 } },
            { Tactics.Type.Dir, new double[]{ 26.3, 4.57, 5.71, 23.4, 16.6, 6.86, 16.6, 0.5 } },
            { Tactics.Type.Win, new double[]{ 19.7, 26, 7.89, 5.92, 16.1, 6.91, 17.4, 0.5 } },
            { Tactics.Type.Sho, new double[]{ 38.2, 10, 9.25, 7.79, 12.4, 6.33, 16.1, 0.5 } },
            { Tactics.Type.Lon, new double[]{ 25.8, 8.99, 16.9, 7.87, 13.5, 8.99, 18, 0.5 } },
            { Tactics.Type.Thr, new double[]{ 21.4, 8.04, 8.93, 5.36, 33.9, 7.14, 15.2, 0.5 } },
        };
        #endregion

        #region _possessionDict
        public PossessionDictionary _possessionDict = new PossessionDictionary()
        {
            { Tactics.Possession.Keeping, new double[]{ 1, 1, 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0 } },
            { Tactics.Possession.Gaining, new double[]{ 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 } },
        };
        #endregion

        #region _actionConstructionDict
        public ActionDictionary _actionConstructionDict = new ActionDictionary()
        {
            {(Tactics.ActionType.Shp,(int)(eSP.DC | eSP.DM | eSP.M | eSP.OM | eSP.FC)),new double[]{0,0.5,0.5,0,0,0.7,0.5,1,0,1,0,0,0,0} },

            { (Tactics.ActionType.Dir,(int)(eSP.GK)),new double[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 } },
            {(Tactics.ActionType.Dir,(int)(eSP.D|eSP.DM|eSP.M)),new double[]{ 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 } },
            {(Tactics.ActionType.Dir,(int)(eSP.OM|eSP.FC)),new double[]{ 0, 0.5, 0.5, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 } },

            {(Tactics.ActionType.Thr,(int)(eSP.D|eSP.DM|eSP.M)),new double[]{ 0, 0.6, 0.6, 0, 0, 0.6, 0.6, 1, 0.3, 1, 0, 0, 0, 0 } },
            {(Tactics.ActionType.Thr,(int)(eSP.OM|eSP.FC)),new double[]{ 0, 0.6, 1, 0, 0, 0.6, 0.6, 1, 0.3, 1, 0, 0, 0, 0 } },

            {(Tactics.ActionType.Lon,(int)(eSP.D|eSP.DM|eSP.M)),new double[]{ 0, 0, 0, 0, 0, 0, 0, 1, 0.7, 0.7, 0, 0, 0, 0 } },
            {(Tactics.ActionType.Lon,(int)(eSP.OM|eSP.FC)),new double[]{ 1, 0.8, 0, 0, 0, 0.8, 0.8, 0, 0, 0, 1, 0, 0, 0 } },
            {(Tactics.ActionType.Lon,(int)(eSP.GK)),new double[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 } },

            {(Tactics.ActionType.Win,(int)(eSP.DW|eSP.DMW|eSP.MW|eSP.OMW)),new double[]{0.3,0.6,1,0,0,0.6,0,0,1,1,0,0,0,0} },

            {(Tactics.ActionType.Cor,(int)(eSP.D)),new double[]{ 0.2, 0, 0.2, 0, 0, 0.2, 0, 0, 0, 0.2, 0, 0, 0, 0 } },
            {(Tactics.ActionType.Cor,(int)(eSP.DM)),new double[]{ 0.4, 0, 0.4, 0, 0, 0.4, 0, 0, 0, 0.4, 0, 0, 0, 0 } },
            {(Tactics.ActionType.Cor,(int)(eSP.M)),new double[]{ 0.6, 0, 0.6, 0, 0, 0.6, 0, 0, 0, 0.6, 0, 0, 0, 0 } },
            {(Tactics.ActionType.Cor,(int)(eSP.OM|eSP.FC)),new double[]{ 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 } },

            {(Tactics.ActionType.Fre,(int)(eSP.D)),new double[]{ 0.2, 0, 0.2, 0, 0, 0.2, 0, 0, 0, 0.2, 0, 0, 0, 0 } },
            {(Tactics.ActionType.Fre,(int)(eSP.DM)),new double[]{ 0.4, 0, 0.4, 0, 0, 0.4, 0, 0, 0, 0.4, 0, 0, 0, 0 } },
            {(Tactics.ActionType.Fre,(int)(eSP.M)),new double[]{ 0.6, 0, 0.6, 0, 0, 0.6, 0, 0, 0, 0.6, 0, 0, 0, 0 } },
            {(Tactics.ActionType.Fre,(int)(eSP.OM|eSP.FC)),new double[]{ 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 } },

            {(Tactics.ActionType.Pen,(int)(eSP.D)),new double[]{ 0.2, 0, 0.2, 0, 0, 0.2, 0, 0, 0, 0.2, 0, 0, 0, 0 } },
            {(Tactics.ActionType.Pen,(int)(eSP.DM)),new double[]{ 0.4, 0, 0.4, 0, 0, 0.4, 0, 0, 0, 0.4, 0, 0, 0, 0 } },
            {(Tactics.ActionType.Pen,(int)(eSP.M)),new double[]{ 0.6, 0, 0.6, 0, 0, 0.6, 0, 0, 0, 0.6, 0, 0, 0, 0 } },
            {(Tactics.ActionType.Pen,(int)(eSP.OM)),new double[]{ 0.8, 0, 0.8, 0, 0, 0.8, 0, 0, 0, 0.8, 0, 0, 0, 0 } },
            {(Tactics.ActionType.Pen,(int)(eSP.FC)),new double[]{ 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 } },
        };
        #endregion

        #region _actionFinalizationDict
        public ActionDictionary _actionFinalizationDict = new ActionDictionary()
        {
            {(Tactics.ActionType.Win,(int)(eSP.D  )),new double[]{0,0,0,0,0,0,0,0,0,0,0.16,0.1,0.04,0}},
            {(Tactics.ActionType.Win,(int)(eSP.DM )),new double[]{0,0,0,0,0,0,0,0,0,0,0.32,0.2,0.08,0}},
            {(Tactics.ActionType.Win,(int)(eSP.M  )),new double[]{0,0,0,0,0,0,0,0,0,0,0.48,0.3,0.2,0}},
            {(Tactics.ActionType.Win,(int)(eSP.OM )),new double[]{0,0,0,0,0,0,0,0,0,0,0.64,0.4,0.2,0}},
            {(Tactics.ActionType.Win,(int)(eSP.FC )),new double[]{0,0,0,0,0,0,0,0,0,0,0.8,0.5,0.2,0}},
            {(Tactics.ActionType.Shp,(int)(eSP.D  )),new double[]{0,0,0,0,0,0,0,0,0,0,0.08,0.16,0.08,0}},
            {(Tactics.ActionType.Shp,(int)(eSP.DM )),new double[]{0,0,0,0,0,0,0,0,0,0,0.16,0.32,0.16,0}},
            {(Tactics.ActionType.Shp,(int)(eSP.M  )),new double[]{0,0,0,0,0,0,0,0,0,0,0.24,0.48,0.4,0}},
            {(Tactics.ActionType.Shp,(int)(eSP.OM )),new double[]{0,0,0,0,0,0,0,0,0,0,0.32,0.64,0.4,0}},
            {(Tactics.ActionType.Shp,(int)(eSP.FC )),new double[]{0,0,0,0,0,0,0,0,0,0,0.4,0.8,0.4,0}},
            {(Tactics.ActionType.Dir,(int)(eSP.D  )),new double[]{0,0,0,0,0,0,0,0,0,0,0.16,0.16,0.08,0}},
            {(Tactics.ActionType.Dir,(int)(eSP.DM )),new double[]{0,0,0,0,0,0,0,0,0,0,0.32,0.32,0.16,0}},
            {(Tactics.ActionType.Dir,(int)(eSP.M  )),new double[]{0,0,0,0,0,0,0,0,0,0,0.48,0.48,0.4,0}},
            {(Tactics.ActionType.Dir,(int)(eSP.OM )),new double[]{0,0,0,0,0,0,0,0,0,0,0.64,0.64,0.4,0}},
            {(Tactics.ActionType.Dir,(int)(eSP.FC )),new double[]{0,0,0,0,0,0,0,0,0,0,0.8,0.8,0.4,0}},
            {(Tactics.ActionType.Thr,(int)(eSP.D  )),new double[]{0,0,0,0,0,0,0,0,0,0,0.02,0.2,0.08,0}},
            {(Tactics.ActionType.Thr,(int)(eSP.DM )),new double[]{0,0,0,0,0,0,0,0,0,0,0.04,0.4,0.16,0}},
            {(Tactics.ActionType.Thr,(int)(eSP.M  )),new double[]{0,0,0,0,0,0,0,0,0,0,0.06,0.6,0.4,0}},
            {(Tactics.ActionType.Thr,(int)(eSP.OM )),new double[]{0,0,0,0,0,0,0,0,0,0,0.08,0.8,0.4,0}},
            {(Tactics.ActionType.Thr,(int)(eSP.FC )),new double[]{0,0,0,0,0,0,0,0,0,0,0.1,1,0.4,0}},
            {(Tactics.ActionType.Lon,(int)(eSP.D  )),new double[]{0,0,0,0,0,0,0,0,0,0,0.08,0.16,0.02,0}},
            {(Tactics.ActionType.Lon,(int)(eSP.DM )),new double[]{0,0,0,0,0,0,0,0,0,0,0.16,0.32,0.04,0}},
            {(Tactics.ActionType.Lon,(int)(eSP.M  )),new double[]{0,0,0,0,0,0,0,0,0,0,0.24,0.48,0.1,0}},
            {(Tactics.ActionType.Lon,(int)(eSP.OM )),new double[]{0,0,0,0,0,0,0,0,0,0,0.32,0.64,0.1,0}},
            {(Tactics.ActionType.Lon,(int)(eSP.FC )),new double[]{0,0,0,0,0,0,0,0,0,0,0.4,0.8,0.1,0}},
            {(Tactics.ActionType.Cor,(int)(eSP.D  )),new double[]{0.2,0,0,0,0,0,0,0,0,0,0.2,0,0,0}},
            {(Tactics.ActionType.Cor,(int)(eSP.DM )),new double[]{0.4,0,0,0,0,0,0,0,0,0,0.4,0,0,0}},
            {(Tactics.ActionType.Cor,(int)(eSP.M  )),new double[]{0.6,0,0,0,0,0,0,0,0,0,0.6,0,0,0}},
            {(Tactics.ActionType.Cor,(int)(eSP.OM )),new double[]{0.8,0,0,0,0,0,0,0,0,0,0.8,0,0,0}},
            {(Tactics.ActionType.Cor,(int)(eSP.FC )),new double[]{1,0,0,0,0,0,0,0,0,0,1,0,0,0}},
        };
        #endregion

        #region _actionDefensiveDict
        public ActionDictionary _actionDefensiveDict = new ActionDictionary()
        {
            {(Tactics.ActionType.Dir,(int)(eSP.D  )),new double[]{0,0.6,0.6,1,0.6,1,1,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Dir,(int)(eSP.DM )),new double[]{0,0.48,0.48,0.8,0.48,0.8,0.8,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Dir,(int)(eSP.M  )),new double[]{0,0.3,0.3,0.5,0.3,0.5,0.5,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Dir,(int)(eSP.OM )),new double[]{0,0.15,0.15,0.25,0.15,0.25,0.25,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Dir,(int)(eSP.FC )),new double[]{0,0.06,0.06,0.1,0.06,0.1,0.1,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Win,(int)(eSP.DW )),new double[]{0.3,0.3,1,1,1,0.6,0.6,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Win,(int)(eSP.DMW)),new double[]{0.24,0.24,0.8,0.8,0.8,0.48,0.48,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Win,(int)(eSP.MW )),new double[]{0.18,0.18,0.6,0.6,0.6,0.36,0.36,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Win,(int)(eSP.OMW)),new double[]{0.12,0.12,0.4,0.4,0.4,0.24,0.24,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Shp,(int)(eSP.D  )),new double[]{0,0,0.7,1,0.7,1,1,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Shp,(int)(eSP.DM )),new double[]{0,0,0.56,0.8,0.56,0.8,0.8,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Shp,(int)(eSP.M  )),new double[]{0,0,0.42,0.6,0.42,0.6,0.6,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Shp,(int)(eSP.OM )),new double[]{0,0,0.28,0.4,0.28,0.4,0.4,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Shp,(int)(eSP.FC )),new double[]{0,0,0.14,0.2,0.14,0.2,0.2,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Lon,(int)(eSP.D  )),new double[]{0.7,0.4,1,1,0.7,1,1,0,0,0,0.7,0,0,0}},
            {(Tactics.ActionType.Lon,(int)(eSP.DM )),new double[]{0.56,0.32,0.8,0.8,0.56,0.8,0.8,0,0,0,0.56,0,0,0}},
            {(Tactics.ActionType.Lon,(int)(eSP.M  )),new double[]{0.42,0.24,0.6,0.6,0.42,0.6,0.6,0,0,0,0.42,0,0,0}},
            {(Tactics.ActionType.Lon,(int)(eSP.OM )),new double[]{0.28,0.16,0.4,0.4,0.28,0.4,0.4,0,0,0,0.28,0,0,0}},
            {(Tactics.ActionType.Lon,(int)(eSP.FC )),new double[]{0.14,0.08,0.2,0.2,0.14,0.2,0.2,0,0,0,0.14,0,0,0}},
            {(Tactics.ActionType.Thr,(int)(eSP.D  )),new double[]{0,0.7,1,1,1,0.7,0.7,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Thr,(int)(eSP.DM )),new double[]{0,0.56,0.8,0.8,0.8,0.56,0.56,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Thr,(int)(eSP.M  )),new double[]{0,0.42,0.6,0.6,0.6,0.42,0.42,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Thr,(int)(eSP.OM )),new double[]{0,0.28,0.4,0.4,0.4,0.28,0.28,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Thr,(int)(eSP.FC )),new double[]{0,0.14,0.2,0.2,0.2,0.14,0.14,0,0,0,0,0,0,0}},
            {(Tactics.ActionType.Cor,(int)(eSP.D  )),new double[]{0.6,0,0,0.8,0.8,0,0,0,0,0,1,0,0,0}},
            {(Tactics.ActionType.Cor,(int)(eSP.DM )),new double[]{0.48,0,0,0.64,0.64,0,0,0,0,0,0.8,0,0,0}},
            {(Tactics.ActionType.Cor,(int)(eSP.M  )),new double[]{0.36,0,0,0.48,0.48,0,0,0,0,0,0.6,0,0,0}},
            {(Tactics.ActionType.Cor,(int)(eSP.OM )),new double[]{0.24,0,0,0.32,0.32,0,0,0,0,0,0.4,0,0,0}},
            {(Tactics.ActionType.Cor,(int)(eSP.FC )),new double[]{0.12,0,0,0.16,0.16,0,0,0,0,0,0.2,0,0,0}},
            {(Tactics.ActionType.Pen,(int)(eSP.GK )),new double[]{0,0.3,0.3,1,1,1,1,1,0,0,0,0,0,0}},
            {(Tactics.ActionType.Fre,(int)(eSP.GK )),new double[]{0,0,0,0,1,1,1,1,1,0,0,0,0,0}},
            {(Tactics.ActionType.Cor,(int)(eSP.GK )),new double[]{0.5,0.5,0,1,0,1,1,1,1,0,0,0,0,0}},
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

        public float[] BallKeepingAndGaining(Rating rat)
        {
            double[] prK = PossessionDict[Possession.Keeping];
            double[] prG = PossessionDict[Possession.Gaining];

            float[] val = new float[2];
            float[] sval = new float[2];
            val[0] = 0.0f;
            val[1] = 0.0f;
            sval[0] = 0.0f;
            sval[1] = 0.0f;

            for (int i = 0; i < 14; i++)
            {
                float skVal = (float)(decimal)rat.R((ePos)i);
                float vK = (float)prK[i];
                float vG = (float)prG[i];
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

        public float[,] TacticsScore(Rating rat, int position)
        {
            float[,] vTct = new float[(int)Tactics.Type.Tot, 3];

            for (int tact = 0; tact < (int)Tactics.Type.Tot; tact++)
            {
                float vAcCSum = 0.0f;
                float vAcFSum = 0.0f;
                float vDefSum = 0.0f;

                vTct[tact, 0] = 0.0f;
                vTct[tact, 1] = 0.0f;
                vTct[tact, 2] = 0.0f;

                for (int actType = 0; actType < (int)ActionType.Tot; actType++)
                {
                    float fAct = (float)TacticsToAcionDict[(Tactics.Type)tact][actType];

                    var acr = ActionConstructionDict.SingleOrDefault(p => (p.Key.actionType == (ActionType)actType) &&
                        ((p.Key.SPs & position) > 0)).Value;

                    var afr = ActionFinalizationDict.SingleOrDefault(p => (p.Key.actionType == (ActionType)actType) &&
                        ((p.Key.SPs & position) > 0)).Value;

                    var dr = ActionDefensiveDict.SingleOrDefault(p => (p.Key.actionType == (ActionType)actType) &&
                        ((p.Key.SPs & position) > 0)).Value;

                    float vActCSk = 0.0f;
                    float vActFSk = 0.0f;
                    float vDefnSk = 0.0f;

                    float vAcSum = 0.0f;
                    float vAfSum = 0.0f;
                    float vDfSum = 0.0f;

                    for (int sk = 0; sk < 14; sk++)
                    {
                        float skVal = (float)(decimal)rat.R((ePos)sk);

                        if (acr != null)
                        {
                            float vAC = (float)acr[sk];
                            vActCSk += skVal * vAC;
                            vAcSum += vAC;
                        }

                        if (afr != null)
                        {
                            float vAF = (float)afr[sk];
                            vActFSk += skVal * vAF;
                            vAfSum += vAF;
                        }

                        if (dr != null)
                        {
                            float vD = (float)dr[sk];
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

        public static TacticsFunction Create(List<TAC_PlWeights> tacPlWeights, 
            List<TAC_GkWeights> tacGkWeights,
            List<TAC_Tac2ActWeights> tacTac2ActWeights,
            List<TAC_PossessionWeights> tacPossessionWeights,
            List<TAC_ActionWeights> tacActionConstruction,
            List<TAC_ActionWeights> tacActionFinalization,
            List<TAC_ActionWeights> tacActionDefensive,
            string fileName)
        {
            return new TacticsFunction(tacPlWeights,
                tacGkWeights,
                tacTac2ActWeights,
                tacPossessionWeights,
                tacActionConstruction,
                tacActionFinalization,
                tacActionDefensive, 
                fileName);
        }

        public TacticsFunction(List<TAC_PlWeights> tacPlWeights,
            List<TAC_GkWeights> tacGkWeights,
            List<TAC_Tac2ActWeights> tacTac2ActWeights,
            List<TAC_PossessionWeights> tacPossessionWeights,
            List<TAC_ActionWeights> tacActionConstruction,
            List<TAC_ActionWeights> tacActionFinalization,
            List<TAC_ActionWeights> tacActionDefensive,
            string fileName)
        {
            this._plTacticsSPosDict = Tactics.WeightListToDict(tacPlWeights);
            this._gkTacticsSPosDict = Tactics.WeightListToDict(tacGkWeights);
            this._tacticsToActionDict = Tactics.WeightListToDict(tacTac2ActWeights);
            this._possessionDict = Tactics.WeightListToDict(tacPossessionWeights);
            this._actionConstructionDict = Tactics.WeightListToDict(tacActionConstruction);
            this._actionFinalizationDict = Tactics.WeightListToDict(tacActionFinalization);
            this._actionDefensiveDict = Tactics.WeightListToDict(tacActionDefensive);
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
                case "DR": return eSP.DR;
                case "DL": return eSP.DL;
                case "DMC": return eSP.DMC;
                case "DMR": return eSP.DMR;
                case "DML": return eSP.DML;
                case "MC": return eSP.MC;
                case "MR": return eSP.MR;
                case "ML": return eSP.ML;
                case "OMC": return eSP.OMC;
                case "OMR": return eSP.OMR;
                case "OML": return eSP.OML;
                case "FC": return eSP.FC;
                default: return eSP.DC;
            }
        }

        #region Properties to Save definition
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

        public TacticsToAcionDictionary TacticsToAcionDict
        {
            get => (TacticsToAcionDictionary)this["TacticsToAcionDict"];
            set => this["TacticsToAcionDict"] = value;
        }

        public PossessionDictionary PossessionDict
        {
            get => (PossessionDictionary)this["PossessionDict"];
            set => this["PossessionDict"] = value;
        }

        public ActionDictionary ActionConstructionDict
        {
            get => (ActionDictionary)this["ActionConstructionDict"];
            set => this["ActionConstructionDict"] = value;
        }

        public ActionDictionary ActionFinalizationDict
        {
            get => (ActionDictionary)this["ActionFinalizationDict"];
            set => this["ActionFinalizationDict"] = value;
        }

        public ActionDictionary ActionDefensiveDict
        {
            get => (ActionDictionary)this["ActionDefensiveDict"];
            set => this["ActionDefensiveDict"] = value;
        }
        #endregion

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

        public static List<TAC_Tac2ActWeights> TacticsToAcionMatrixToTable(TacticsToAcionDictionary tacticsToActionDict)
        {
            List<TAC_Tac2ActWeights> resList = new List<TAC_Tac2ActWeights>();
            foreach (var entry in tacticsToActionDict)
            {
                var weights = entry.Value;

                resList.Add(new TAC_Tac2ActWeights(weights, entry.Key));
            }

            return resList;
        }

        public static List<TAC_PossessionWeights> PossessionMatrixToTable(PossessionDictionary possessionDict)
        {
            List<TAC_PossessionWeights> resList = new List<TAC_PossessionWeights>();
            foreach (var entry in possessionDict)
            {
                var weights = entry.Value;

                resList.Add(new TAC_PossessionWeights(weights, entry.Key));
            }

            return resList;
        }

        public static List<TAC_ActionWeights> ActionMatrixToTable(ActionDictionary actionPosDict)
        {
            List<TAC_ActionWeights> resList = new List<TAC_ActionWeights>();
            foreach (var entry in actionPosDict)
            {
                var weights = entry.Value;

                resList.Add(new TAC_ActionWeights(weights, entry.Key.actionType, entry.Key.SPs));
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
            TacticsToAcionDict = _tacticsToActionDict;
            PossessionDict = _possessionDict;
            ActionConstructionDict = _actionConstructionDict;
            ActionFinalizationDict = _actionFinalizationDict;
            ActionDefensiveDict = _actionDefensiveDict;
        }


        public static TacticsFunction CreateDefaultFunctions(string tacticsFunctionPath)
        {
            string tacticsFunctionDir = Path.GetDirectoryName(tacticsFunctionPath);

            TacticsFunction tf = new TacticsFunction();
            tf.SettingInitialize();

            string tacticsFunctionFile = Path.Combine(tacticsFunctionDir, "Default.tactics");

            tf.SettingsFilename = tacticsFunctionFile;
            tf.Save();

            return tf;
        }
    }
}
