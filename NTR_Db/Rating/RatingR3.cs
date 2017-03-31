using Common;
using NTR_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTR_Db
{
    public class RatingR3: RatingFunction
    {
        private double _routineFactor = 0.006153231 * 25;
        private double wage_rate = 19.76;

        public new eRatingFunctionType RatingFunctionType => eRatingFunctionType.RatingR3;

        // Weights need to total 100
        private WeightMatrix _weightRat = new double[,] {
            // Rating weights 
            // Str		 Sta		 Pac		 Mar		 Tac		 Wor		 Pos		 Pas         Cro		 Tec		 Hea		 Fin		 Lon		 Set
            {0.51872935, 0.29081119, 0.57222393, 0.89735816, 0.84487852, 0.50887940, 0.50887940, 0.13637928, 0.05248024, 0.09388931, 0.57549122, 0.00000000, 0.00000000, 0.0},	// DC
            {0.45240063, 0.31762087, 0.68150374, 0.77724031, 0.74690951, 0.50072196, 0.45947168, 0.17663123, 0.23886264, 0.18410349, 0.46453393, 0.00000000, 0.00000000, 0.0},	// DL/R
            {0.45240063, 0.31762087, 0.68150374, 0.77724031, 0.74690951, 0.50072196, 0.45947168, 0.17663123, 0.23886264, 0.18410349, 0.46453393, 0.00000000, 0.00000000, 0.0},	// DL/R
            {0.43789335, 0.31844356, 0.53515723, 0.63671706, 0.59109742, 0.51311701, 0.53184426, 0.32421168, 0.06318165, 0.27931537, 0.50093723, 0.19317517, 0.07490902, 0.0},	// DMC
            {0.42311032, 0.32315966, 0.62271745, 0.53932111, 0.51442838, 0.49835997, 0.47896659, 0.26434782, 0.22586124, 0.32182902, 0.45537227, 0.23961054, 0.09291562, 0.0},	// DML/R
            {0.42311032, 0.32315966, 0.62271745, 0.53932111, 0.51442838, 0.49835997, 0.47896659, 0.26434782, 0.22586124, 0.32182902, 0.45537227, 0.23961054, 0.09291562, 0.0},	// DML/R
            {0.31849880, 0.36581214, 0.50091016, 0.31726444, 0.28029020, 0.52022170, 0.55763723, 0.60199246, 0.10044356, 0.51811057, 0.38320838, 0.38594825, 0.14966211, 0.0},	// MC
            {0.35409971, 0.34443972, 0.64417234, 0.30427501, 0.27956082, 0.49925481, 0.46093655, 0.32887111, 0.38695101, 0.47884837, 0.37465446, 0.39194758, 0.15198852, 0.0},	// ML/R
            {0.35409971, 0.34443972, 0.64417234, 0.30427501, 0.27956082, 0.49925481, 0.46093655, 0.32887111, 0.38695101, 0.47884837, 0.37465446, 0.39194758, 0.15198852, 0.0},	// ML/R
            {0.32272636, 0.35024067, 0.48762872, 0.22888914, 0.19049636, 0.52620414, 0.57842512, 0.53330409, 0.07523792, 0.55942740, 0.39986691, 0.53866926, 0.20888391, 0.0},	// OMC
            {0.36311066, 0.33106245, 0.61831416, 0.19830147, 0.17415753, 0.50049575, 0.47737842, 0.28937553, 0.34729042, 0.52834210, 0.39939218, 0.55684664, 0.21593269, 0.0},	// OML/R
            {0.36311066, 0.33106245, 0.61831416, 0.19830147, 0.17415753, 0.50049575, 0.47737842, 0.28937553, 0.34729042, 0.52834210, 0.39939218, 0.55684664, 0.21593269, 0.0},	// OML/R
            {0.40622753, 0.29744114, 0.39446722, 0.09952139, 0.07503885, 0.50402399, 0.58505850, 0.36932466, 0.05210389, 0.53677990, 0.51998862, 0.83588627, 0.32413803, 0.0},	// F
            {0.37313433, 0.37313433, 0.37313433, 0.74626866, 0.52238806, 0.74626866, 0.52238806, 0.52238806, 0.37313433, 0.22388060, 0.22388060, 0.0, 0.0, 0.0}};   // GK

        private WeightMatrix _weightREC = new double[,] {
            // REC weights 
            // Str		  Sta		  Pac		  Mar		   Tac		    Wor		    Pos		    Pas         Cro		    Tec		    Hea		    Fin		    Lon		    Set
            {0.6539623,   0.3300142,  0.56299454, 0.89180016,  0.87106909,  0.45451467, 0.55569727, 0.4277759,  0.33821882, 0.13434845, 0.79691678, 0.04883187, 0.11636344, 0.28234775},	//DC
            {0.56560512,  0.43097338, 0.91712543, 0.81570252,  0.9902232,   0.54799587, 0.52220323, 0.30992889, 0.83736535, 0.48382247, 0.65690142, 0.13758258, 0.16365811, 0.30391544},	//DL/R
            {0.56560512,  0.43097338, 0.91712543, 0.81570252,  0.9902232,   0.54799587, 0.52220323, 0.30992889, 0.83736535, 0.48382247, 0.65690142, 0.13758258, 0.16365811, 0.30391544},	//DL/R
            {0.5583882,   0.6036835,  0.56379231, 0.77042508,  0.64196585,  0.67549523, 0.68386347, 0.75734291, 0.47307079, 0.49410782, 0.39754716, 0.42966091, 0.5636417,  0.22479109},	//DMC
            {0.58207403,  0.4200322,  0.788754,   0.72622138,  0.72297232,  0.73761725, 0.6223445,  0.4669469,  0.81438291, 0.56187782, 0.36744698, 0.3606234,  0.39005776, 0.24951773},	//DML/R
            {0.58207403,  0.4200322,  0.788754,   0.72622138,  0.72297232,  0.73761725, 0.6223445,  0.4669469,  0.81438291, 0.56187782, 0.36744698, 0.3606234,  0.39005776, 0.24951773},	//DML/R
            {0.57843193,  0.77813468, 0.57472632, 0.7140029,   0.63540339,  0.82230825, 0.87785704, 0.86426567, 0.43345021, 0.69716425, 0.41256851, 0.58662758, 0.61790505, 0.30842681},	//MC
            {0.49742937,  0.54534736, 0.78828091, 0.57872457,  0.6632353,   0.77253714, 0.63870613, 0.5384531,  0.88793538, 0.57251597, 0.29054955, 0.47618049, 0.52614942, 0.28700164},	//ML/R
            {0.49742937,  0.54534736, 0.78828091, 0.57872457,  0.6632353,   0.77253714, 0.63870613, 0.5384531,  0.88793538, 0.57251597, 0.29054955, 0.47618049, 0.52614942, 0.28700164},	//ML/R
            {0.65643776,  0.61726072, 0.65656998, 0.6374105,   0.5514845,   0.92237978, 0.79055356, 0.99968855, 0.42620357, 0.77877091, 0.65237406, 0.66226439, 0.731201,   0.27456361},	//OMC
            {0.48334194,  0.49477305, 0.7994348,  0.62878919,  0.63384796,  0.68135443, 0.67123386, 0.53612145, 0.84938974, 0.68406772, 0.38973297, 0.49997269, 0.57723181, 0.27277335},	//OML/R
            {0.48334194,  0.49477305, 0.7994348,  0.62878919,  0.63384796,  0.68135443, 0.67123386, 0.53612145, 0.84938974, 0.68406772, 0.38973297, 0.49997269, 0.57723181, 0.27277335},	//OML/R
            {0.49391705,  0.3704239,  0.53214892, 0.062920665, 0.090495007, 0.41549477, 0.541061,   0.46818114, 0.15810648, 0.46112573, 0.8339961,  0.99982832, 0.82717197, 0.25322585},	//F
            //			   For  Rez    Vit  Ind  One  Ref Aer  Sar  Com    Deg    Aru
            {0.5, 0.333, 0.5, 1.0,  0.5, 1.0,  0.5, 0.5, 0.333, 0.333, 0.333, 0.0, 0.0, 0.0}};   // GK


        private WeightMatrix _weightRECb = new double[,] {
            // REC weights 
            // Str		 Sta		 Pac		 Mar		 Tac		 Wor		 Pos		 Pas         Cro		 Tec		 Hea		 Fin		 Lon		 Set
            {0.10476131, 0.05214691, 0.07928798, 0.14443775, 0.13140328, 0.06543399, 0.07762453, 0.06649973, 0.05174317, 0.02761713, 0.12122597, 0.01365182, 0.02547069, 0.03869574},	// DC
            {0.07660230, 0.05043295, 0.11528887, 0.11701021, 0.12737497, 0.07681385, 0.06343039, 0.03777422, 0.10320519, 0.06396543, 0.09155298, 0.01367035, 0.02554511, 0.03733318},	// DL/R
            {0.07660230, 0.05043295, 0.11528887, 0.11701021, 0.12737497, 0.07681385, 0.06343039, 0.03777422, 0.10320519, 0.06396543, 0.09155298, 0.01367035, 0.02554511, 0.03733318},	// DL/R
            {0.08236460, 0.08557545, 0.07284710, 0.09846060, 0.08838358, 0.09150784, 0.09684525, 0.08929752, 0.04594195, 0.06011878, 0.05462556, 0.04891765, 0.05864571, 0.02646840},	// DMC
            {0.06705156, 0.06600599, 0.10002073, 0.08249862, 0.09719526, 0.09243450, 0.08504033, 0.06129130, 0.10295145, 0.08088686, 0.04665721, 0.03841339, 0.05222570, 0.02732710},	// DML/R
            {0.06705156, 0.06600599, 0.10002073, 0.08249862, 0.09719526, 0.09243450, 0.08504033, 0.06129130, 0.10295145, 0.08088686, 0.04665721, 0.03841339, 0.05222570, 0.02732710},	// DML/R
            {0.07333243, 0.08171847, 0.07197804, 0.08469622, 0.07098103, 0.09554048, 0.09470328, 0.09576006, 0.04729121, 0.07092367, 0.04588383, 0.05986604, 0.07170498, 0.03562024},	// MC
            {0.06527363, 0.06410270, 0.09701305, 0.07406706, 0.08563595, 0.09648566, 0.08651209, 0.06357183, 0.10819222, 0.07386495, 0.03245554, 0.05430668, 0.06572005, 0.03279859},	// ML/R
            {0.06527363, 0.06410270, 0.09701305, 0.07406706, 0.08563595, 0.09648566, 0.08651209, 0.06357183, 0.10819222, 0.07386495, 0.03245554, 0.05430668, 0.06572005, 0.03279859},	// ML/R
            {0.07886961, 0.07955547, 0.07497831, 0.06915926, 0.05059290, 0.08160950, 0.08206952, 0.10911727, 0.03482457, 0.07593779, 0.06515279, 0.07472116, 0.09098089, 0.03243097},	// OMC
            {0.06545375, 0.06145378, 0.10503536, 0.06421508, 0.07627526, 0.09232981, 0.07763931, 0.07001035, 0.11307331, 0.07298351, 0.04248486, 0.06462713, 0.07038293, 0.02403557},	// OML/R
            {0.06545375, 0.06145378, 0.10503536, 0.06421508, 0.07627526, 0.09232981, 0.07763931, 0.07001035, 0.11307331, 0.07298351, 0.04248486, 0.06462713, 0.07038293, 0.02403557},	// OML/R
            {0.07739710, 0.05095200, 0.07641981, 0.01310784, 0.01149133, 0.06383764, 0.07762980, 0.07632566, 0.02708970, 0.07771063, 0.12775187, 0.15339719, 0.12843583, 0.03845360},	// F
            // For  Rez    Vit  Ind  One  Ref Aer  Sar  Com    Deg    Aru
            {0.07466384, 0.07466384, 0.07466384, 0.14932769, 0.10452938, 0.14932769, 0.10452938, 0.10344411, 0.07512610, 0.04492581, 0.04479831, 0.0, 0.0, 0.0}};   // GK

        private WeightMatrix _WeightREClf = new double[,] {
            {14.866375,18.95664},		// DC      
            {15.980742,22.895539},      // DL/R    
            {15.980742,22.895539},      // DL/R    
            {15.8932675,23.1801296},    // DMC     
            {15.5835325,23.2813871},    // DML/R   
            {15.5835325,23.2813871},    // DML/R   
            {17.6955092,26.8420884},    // MC      
            {16.6189141,23.9940623},    // ML/R    
            {16.6189141,23.9940623},    // ML/R    
            {18.1255351,27.8974544},    // OMC     
            {15.6304867,24.54323},      // OML/R   
            {15.6304867,24.54323},      // OML/R   
            {13.2762119,19.5088591},    // F       
            {15,22.3},                  // GK      
            };

        public static void TestRating()
        {
            PlayerDataSkills pds = PlayerDataSkills.From(
                new PlayerData()
                {
                    Ada = 0,
                    ASI = new Common.intvar(40682,40682),
                    FPn = 33,
                    Rou = 15.8M,
                    Skills = new decvar[]
                    {
                        new decvar(11,11),
                        new decvar(13,13),
                        new decvar(14,14),
                        new decvar(15,15),
                        new decvar(17,17),
                        new decvar(15,15),
                        new decvar(14,14),
                        new decvar(15,15),
                        new decvar(19,19),
                        new decvar(10,10),
                        new decvar(9,9),
                        new decvar(11,11),
                        new decvar(7,7),
                        new decvar(18,18),
                    },
                    SPn = 12,
                });

            RatingR3 R3 = new RatingR3();

            Rating res = R3.ComputeRating(pds);
        }

        public override Rating ComputeRating(PlayerDataSkills playerData)
        {
            double skillWeightSum, weight;
            double SI = playerData.ASI;
            double rou = playerData.Rou;
            double ada = (playerData.Ada == 0) ? 10 : playerData.Ada;

            if (playerData.FPn == 0) // The player is a GK
            {
                skillWeightSum = (Math.Pow(SI, 0.143) / 0.02979);
                weight = 48717927500;
            }
            else
            {
                skillWeightSum = (Math.Pow(SI, 1 / 6.99194) / 0.02336483);
                weight = 263533760000;
            }

            double skillSum = playerData.SkillSum;

            // REREC remainder
            skillWeightSum -= skillSum;

            // RatingR2 remainder
            var remainder = Math.Round((Math.Pow(2.0, Math.Log(weight * SI) / Math.Log(Math.Pow(2, 7))) - skillSum) * 10.0) / 10.0;

            int[] positionIndex = Rating.GetPositionIndex(playerData.FPn);

            int numFP = (positionIndex[1] == -1) ? 1 : 2;

            Rating[] Rv = new NTR_Db.Rating[numFP];

            double LOG2E = 1.4426950408889634; 
            double rouMultiplier = Math.Pow(5.0/3.0, LOG2E * Math.Log(rou * 10)) * RoutineFactor;

            for (int n = 0; n < numFP; n++)
            {
                Rating R = new NTR_Db.Rating();

                for (var j = 0; j < 13; j++) // All position
                {
                    double remWeightREC = 0;
                    var remWeightRat = 0.0;		// RatingR2 remainder weight sum
                    var not20 = 0;					// 20以外のスキル数
                    if (playerData.FPn == 0) j = 13;	// GK

                    int weightLength = (playerData.FPn == 0) ? 11 : 14;
                    for (var i = 0; i < weightLength; i++)
                    {
                        R.rating[j] += playerData.Skills[i] * _weightRat[j, i];
                        R.rec[j] += playerData.Skills[i] * _weightREC[j, i];

                        if (playerData.Skills[i] != 20)
                        {
                            remWeightRat += _weightRat[j, i];
                            remWeightREC += _weightREC[j, i];
                            not20++;
                        }
                    }

                    R.rec[j] += skillWeightSum * remWeightREC / not20;
                    if (playerData.FPn == 0) R.rec[j] *= 1.27;

                    R.rec[j] = (R.rec[j] - _WeightREClf[j, 0]) / _WeightREClf[j, 1];
                    R.rating[j] += remainder * remWeightRat / not20;
                    R.ratingR[j] = R.rating[j] + rouMultiplier;

                    if (playerData.FPn == 0)
                        j = 13;		// Loop end
                    else
                    {
                        double adaFactor = 1 - (1 - _adaFact[j, positionIndex[n]]) * (20 - ada)/20;
                        R.rec[j] *= adaFactor;
                        R.rating[j] *= adaFactor;
                        R.ratingR[j] *= adaFactor;
                    }
                }

                if (playerData.FPn != 0) // The player is not a GK
                {
                    R.CK = (playerData.Skills[8] + playerData.Skills[13] + playerData.Skills[9] / 2) + rouMultiplier / 2;
                    R.FK = (playerData.Skills[12] + playerData.Skills[13] + playerData.Skills[9] / 2) + rouMultiplier / 2;
                    R.PK = (playerData.Skills[11] + playerData.Skills[13] + playerData.Skills[9] / 2) + rouMultiplier / 2;
                }

                Rv[n] = R;
            }

            Rating Rmax = Rating.Max(Rv);

            Rmax.OSi = GetOSi(Rmax, playerData);

            return Rmax;
        }

        internal static RatingFunction Create(List<REC_Weights> recWeights, List<REC_Weights> ratWeights,
            List<PROP_Weights> recLfWeights, List<ADA_Weights> adaWeights, double rouFactor, string fileName)
        {
            return new RatingR3(
                Rating.TableToWeightsMatrix(recWeights),
                Rating.TableToWeightsMatrix(ratWeights),
                Rating.PropTableToWeightsMatrix(recLfWeights),
                Rating.AdaTableToWeightsMatrix(adaWeights),
                rouFactor, fileName);
        }

        public RatingR3(WeightMatrix recMatrix, WeightMatrix ratMatrix, WeightMatrix recLfMatrix, WeightMatrix adaMatrix, double rouFactor, string fileName)
        {
            this._weightREC = recMatrix;
            this._weightRat = ratMatrix;
            this._WeightREClf = recLfMatrix;
            this._adaFact = adaMatrix;
            this._routineFactor = rouFactor;
            this.SettingsFilename = fileName;
            SettingInitialize();
        }

        public RatingR3()
        {
            SettingInitialize();
        }

        /// <summary>
        /// This function initialize settings for the object
        /// </summary>
        public override void SettingInitialize()
        {
            Name = "RatingR3";
            ShortName = "R3";
            WeightREC = _weightREC;
            WeightRat = _weightRat;
            WeightREClf = _WeightREClf;
            Adaptability = _adaFact;
            RoutineFactor = _routineFactor;
            Def("RatingFunctionType", eRatingFunctionType.RatingR3);
        }
    }
}
