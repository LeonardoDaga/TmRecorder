using NTR_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTR_Db
{
    public class RatingAC: RatingFunction
    {
        private double _routineFactor = 0.004;

        public new eRatingFunctionType RatingFunctionType => eRatingFunctionType.RatingAtleticoCassina;

        // Weights need to total 100
        private WeightMatrix _weightRat = new double[,] {
            // Rating weights 
            // Str	    Sta		  Pac		Mar		  Tac		Wor		Pos		Pas          Cro	  Tec		Hea		Fin		  Lon		 Set
            {0.51871, 0.27930, 0.57355, 0.89732, 0.84484, 0.51021, 0.51021, 0.13976, 0.05383, 0.09659, 0.57547, 0.00000, 0.00000, 0.00000},
            {0.46086, 0.28421, 0.65924, 0.73198, 0.70341, 0.50136, 0.46960, 0.17403, 0.22803, 0.20312, 0.48251, 0.07310, 0.02835, 0.00000},
            {0.46086, 0.28421, 0.65924, 0.73198, 0.70341, 0.50136, 0.46960, 0.17403, 0.22803, 0.20312, 0.48251, 0.07310, 0.02835, 0.00000},
            {0.43731, 0.30263, 0.53807, 0.63895, 0.59317, 0.51520, 0.53356, 0.33013, 0.06531, 0.28268, 0.49995, 0.18940, 0.07344, 0.00000},
            {0.42232, 0.30691, 0.62633, 0.54167, 0.51667, 0.50049, 0.48047, 0.27044, 0.22882, 0.32540, 0.45395, 0.23512, 0.09118, 0.00000},
            {0.42232, 0.30691, 0.62633, 0.54167, 0.51667, 0.50049, 0.48047, 0.27044, 0.22882, 0.32540, 0.45395, 0.23512, 0.09118, 0.00000},
            {0.34304, 0.31527, 0.50332, 0.34630, 0.30594, 0.52491, 0.56481, 0.53605, 0.09186, 0.48479, 0.41231, 0.41158, 0.15960, 0.00000},
            {0.37403, 0.29561, 0.63063, 0.33259, 0.30558, 0.50538, 0.47923, 0.29814, 0.34260, 0.45165, 0.40346, 0.41858, 0.16232, 0.00000},
            {0.37403, 0.29561, 0.63063, 0.33259, 0.30558, 0.50538, 0.47923, 0.29814, 0.34260, 0.45165, 0.40346, 0.41858, 0.16232, 0.00000},
            {0.31997, 0.27581, 0.49895, 0.23116, 0.19239, 0.53579, 0.58732, 0.56094, 0.08492, 0.57882, 0.39613, 0.53150, 0.20611, 0.00000},
            {0.36068, 0.29319, 0.62674, 0.20034, 0.17594, 0.50552, 0.48091, 0.30390, 0.35547, 0.53883, 0.39552, 0.54963, 0.21313, 0.00000},
            {0.36068, 0.29319, 0.62674, 0.20034, 0.17594, 0.50552, 0.48091, 0.30390, 0.35547, 0.53883, 0.39552, 0.54963, 0.21313, 0.00000},
            {0.40323, 0.24615, 0.40297, 0.10106, 0.07620, 0.51092, 0.59132, 0.39061, 0.05914, 0.55125, 0.51602, 0.82933, 0.32159, 0.00000},
            {0.61401, 0.11695, 0.61401, 0.73097, 0.61401, 0.73097, 0.61401, 0.61401, 0.11695, 0.11695, 0.11695, 0.00000, 0.00000, 0.00000}
        };  // GK

        private WeightMatrix _weightREC = new double[,] {
            // REC weights 
            // Str				 Sta				Pac				    Mar				   Tac				   Wor				Pos				   Pas				  Cro				 Tec				Hea				   Fin				  Lon				 Set
            {0.51871, 0.27930, 0.57355, 0.89732, 0.84484, 0.51021, 0.51021, 0.13976, 0.05383, 0.09659, 0.57547, 0.00000, 0.00000, 0.00000},
            {0.46086, 0.28421, 0.65924, 0.73198, 0.70341, 0.50136, 0.46960, 0.17403, 0.22803, 0.20312, 0.48251, 0.07310, 0.02835, 0.00000},
            {0.46086, 0.28421, 0.65924, 0.73198, 0.70341, 0.50136, 0.46960, 0.17403, 0.22803, 0.20312, 0.48251, 0.07310, 0.02835, 0.00000},
            {0.43731, 0.30263, 0.53807, 0.63895, 0.59317, 0.51520, 0.53356, 0.33013, 0.06531, 0.28268, 0.49995, 0.18940, 0.07344, 0.00000},
            {0.42232, 0.30691, 0.62633, 0.54167, 0.51667, 0.50049, 0.48047, 0.27044, 0.22882, 0.32540, 0.45395, 0.23512, 0.09118, 0.00000},
            {0.42232, 0.30691, 0.62633, 0.54167, 0.51667, 0.50049, 0.48047, 0.27044, 0.22882, 0.32540, 0.45395, 0.23512, 0.09118, 0.00000},
            {0.34304, 0.31527, 0.50332, 0.34630, 0.30594, 0.52491, 0.56481, 0.53605, 0.09186, 0.48479, 0.41231, 0.41158, 0.15960, 0.00000},
            {0.37403, 0.29561, 0.63063, 0.33259, 0.30558, 0.50538, 0.47923, 0.29814, 0.34260, 0.45165, 0.40346, 0.41858, 0.16232, 0.00000},
            {0.37403, 0.29561, 0.63063, 0.33259, 0.30558, 0.50538, 0.47923, 0.29814, 0.34260, 0.45165, 0.40346, 0.41858, 0.16232, 0.00000},
            {0.31997, 0.27581, 0.49895, 0.23116, 0.19239, 0.53579, 0.58732, 0.56094, 0.08492, 0.57882, 0.39613, 0.53150, 0.20611, 0.00000},
            {0.36068, 0.29319, 0.62674, 0.20034, 0.17594, 0.50552, 0.48091, 0.30390, 0.35547, 0.53883, 0.39552, 0.54963, 0.21313, 0.00000},
            {0.36068, 0.29319, 0.62674, 0.20034, 0.17594, 0.50552, 0.48091, 0.30390, 0.35547, 0.53883, 0.39552, 0.54963, 0.21313, 0.00000},
            {0.40323, 0.24615, 0.40297, 0.10106, 0.07620, 0.51092, 0.59132, 0.39061, 0.05914, 0.55125, 0.51602, 0.82933, 0.32159, 0.00000},
            {0.61401, 0.11695, 0.61401, 0.73097, 0.61401, 0.73097, 0.61401, 0.61401, 0.11695, 0.11695, 0.11695, 0.00000, 0.00000, 0.00000}
        };

        private WeightMatrix _WeightREClf = new double[,] 
        {
            {0, 1},	   // DC      
            {0, 1},    // DL/R    
            {0, 1},    // DL/R    
            {0, 1},    // DMC     
            {0, 1},    // DML/R   
            {0, 1},    // DML/R   
            {0, 1},    // MC      
            {0, 1},    // ML/R    
            {0, 1},    // ML/R    
            {0, 1},    // OMC     
            {0, 1},    // OML/R   
            {0, 1},    // OML/R   
            {0, 1},    // F       
            {0, 1.25},    // GK      
        };

        public override Rating ComputeRating(PlayerDataSkills playerData)
        {
            double rerecRemainder, weight;
            double SI = playerData.ASI;
            double rou = playerData.Rou;
            double ada = (playerData.Ada == 0) ? 10 : playerData.Ada;

            if (playerData.FPn == 0) // The player is a GK
            {
                rerecRemainder = (Math.Pow(SI, 0.143) / 0.02979);
                weight = 48717927500;
            }
            else
            {
                rerecRemainder = (Math.Pow(SI, 1 / 6.99194) / 0.02336483);
                weight = 263533760000;
            }

            double skillSum = playerData.SkillSum;

            // REREC remainder
            rerecRemainder -= skillSum;

            // RatingR2 remainder
            var ratingRemainder = Math.Round((Math.Pow(2.0, Math.Log(weight * SI) / Math.Log(Math.Pow(2, 7))) - skillSum) * 10.0) / 10.0;

            int[] positionIndex = Rating.GetPositionIndex(playerData.FPn);

            int numFP = (positionIndex[1] == -1) ? 1 : 2;

            Rating[] Rv = new NTR_Db.Rating[numFP];

            for (int n = 0; n < numFP; n++)
            {
                Rating R = new NTR_Db.Rating();

                for (var j = 0; j < 13; j++) // All position
                {
                    if (playerData.FPn == 0) j = 13;	// GK

                    int weightLength = (playerData.FPn == 0) ? 11 : 14;
                    for (var i = 0; i < weightLength; i++)
                    {
                        R.rec[j] += 0.06 * playerData.Skills[i] * _weightREC[j, i];
                        R.rating[j] += playerData.Skills[i] * _weightRat[j, i];
                    }

                    if (positionIndex[n] == 13)
                        R.rec[j] *= 1.27;					//GK

                    R.rec[j] = (R.rec[j] - _WeightREClf[j, 0]) / _WeightREClf[j, 1];

                    R.ratingR[j] = R.rating[j] * (1 + rou * RoutineFactor);
                    R.rating[j] = R.rating[j];

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

                Rv[n] = R;
            }

            Rating Rmax = Rating.Max(Rv);

            double LOG2E = 1.4426950408889634;
            double rouMultiplier = Math.Pow(5.0 / 3.0, LOG2E * Math.Log(rou * 10)) * RoutineFactor;
            if (playerData.FPn != 0) // The player is not a GK
            {
                Rmax.CK = (playerData.Skills[8] + playerData.Skills[13] + playerData.Skills[9] / 2) + rouMultiplier / 2;
                Rmax.FK = (playerData.Skills[12] + playerData.Skills[13] + playerData.Skills[9] / 2) + rouMultiplier / 2;
                Rmax.PK = (playerData.Skills[11] + playerData.Skills[13] + playerData.Skills[9] / 2) + rouMultiplier / 2;
            }

            Rmax.OSi = GetOSi(Rmax, playerData);

            return Rmax;
        }

        internal static RatingFunction Create(List<REC_Weights> recWeights, List<REC_Weights> ratWeights,
            List<PROP_Weights> recLfWeights, List<ADA_Weights> adaWeights, double rouFactor, string fileName)
        {
            return new RatingAC(
                Rating.TableToWeightsMatrix(recWeights),
                Rating.TableToWeightsMatrix(ratWeights),
                Rating.PropTableToWeightsMatrix(recLfWeights),
                Rating.AdaTableToWeightsMatrix(adaWeights),
                rouFactor, fileName);
        }

        public RatingAC(WeightMatrix recMatrix, WeightMatrix ratMatrix, WeightMatrix recLfMatrix, WeightMatrix adaMatrix, double rouFactor, string fileName)
        {
            this._weightREC = recMatrix;
            this._weightRat = ratMatrix;
            this._WeightREClf = recLfMatrix;
            this._adaFact = adaMatrix;
            this._routineFactor = rouFactor;
            this.SettingsFilename = fileName;
            SettingInitialize();
        }

        public RatingAC()
        {
            SettingInitialize();
        }

        /// <summary>
        /// This function initialize settings for the object
        /// </summary>
        public override void SettingInitialize()
        {
            Name = "Rating Atletico Cassina";
            ShortName = "AC";
            WeightREC = _weightREC;
            WeightRat = _weightRat;
            WeightREClf = _WeightREClf;
            Adaptability = _adaFact;
            RoutineFactor = _routineFactor;
            Def("RatingFunctionType", eRatingFunctionType.RatingAtleticoCassina);
        }
    }
}
