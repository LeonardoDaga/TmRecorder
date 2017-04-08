using NTR_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTR_Db
{
    public class RatingRC: RatingFunction
    {
        private double _routineFactor = 0.004;

        public new eRatingFunctionType RatingFunctionType => eRatingFunctionType.RUSCheratte;

        // Weights need to total 100
        private WeightMatrix _weightRat = new double[,] {
            // Rating weights 
            // Str	    Sta		  Pac		Mar		  Tac		Wor		Pos		Pas     Cro	  Tec		Hea		Fin		  Lon		 Set
            {0.69832, 0.05761, 0.69832, 0.69832, 0.69832, 0.05761, 0.05761, 0.40677, 0.40677, 0.40677, 0.69832, 0.05761, 0.05761, 0},
            {0.46055, 0.06601, 0.78907, 0.78907, 0.78907, 0.06601, 0.06601, 0.46055, 0.46055, 0.46055, 0.46055, 0.06601, 0.06601, 0},
            {0.46055, 0.06601, 0.78907, 0.78907, 0.78907, 0.06601, 0.06601, 0.46055, 0.46055, 0.46055, 0.46055, 0.06601, 0.06601, 0},
            {0.52632, 0.30702, 0.30702, 0.52632, 0.52632, 0.52632, 0.52632, 0.52632, 0.30702, 0.30702, 0.52632, 0.04386, 0.04386, 0},
            {0.46055, 0.06601, 0.78907, 0.78907, 0.78907, 0.06601, 0.06601, 0.46055, 0.46055, 0.46055, 0.46055, 0.06601, 0.06601, 0},
            {0.46055, 0.06601, 0.78907, 0.78907, 0.78907, 0.06601, 0.06601, 0.46055, 0.46055, 0.46055, 0.46055, 0.06601, 0.06601, 0},
            {0.36049, 0.36049, 0.05227, 0.61824, 0.61824, 0.61824, 0.61824, 0.61824, 0.05227, 0.61824, 0.36049, 0.05227, 0.05227, 0},
            {0.29456, 0.29456, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.29456, 0.04154, 0.04154, 0},
            {0.29456, 0.29456, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.29456, 0.04154, 0.04154, 0},
            {0.34022, 0.04809, 0.04809, 0.34022, 0.34022, 0.58247, 0.58247, 0.58247, 0.04809, 0.58247, 0.34022, 0.58247, 0.58247, 0},
            {0.39788, 0.39788, 0.68079, 0.05749, 0.05749, 0.39788, 0.39788, 0.05749, 0.68079, 0.68079, 0.39788, 0.39788, 0.39788, 0},
            {0.39788, 0.39788, 0.68079, 0.05749, 0.05749, 0.39788, 0.39788, 0.05749, 0.68079, 0.68079, 0.39788, 0.39788, 0.39788, 0},
            {0.69033, 0.40215, 0.40215, 0.05698, 0.05698, 0.40215, 0.40215, 0.05698, 0.05698, 0.40215, 0.69033, 0.69033, 0.69033, 0},
            {0.58333, 0.00000, 0.58333, 1.08333, 0.58333, 1.00000, 0.58333, 0.58333, 0.00000, 0.00000, 0.00000, 0.00000, 0.00000, 0}
        };  // GK

        private WeightMatrix _weightREC = new double[,] {
            // REC weights 
            // Str				 Sta				Pac				    Mar				   Tac				   Wor				Pos				   Pas				  Cro				 Tec				Hea				   Fin				  Lon				 Set
            {0.69832, 0.05761, 0.69832, 0.69832, 0.69832, 0.05761, 0.05761, 0.40677, 0.40677, 0.40677, 0.69832, 0.05761, 0.05761, 0},
            {0.46055, 0.06601, 0.78907, 0.78907, 0.78907, 0.06601, 0.06601, 0.46055, 0.46055, 0.46055, 0.46055, 0.06601, 0.06601, 0},
            {0.46055, 0.06601, 0.78907, 0.78907, 0.78907, 0.06601, 0.06601, 0.46055, 0.46055, 0.46055, 0.46055, 0.06601, 0.06601, 0},
            {0.52632, 0.30702, 0.30702, 0.52632, 0.52632, 0.52632, 0.52632, 0.52632, 0.30702, 0.30702, 0.52632, 0.04386, 0.04386, 0},
            {0.46055, 0.06601, 0.78907, 0.78907, 0.78907, 0.06601, 0.06601, 0.46055, 0.46055, 0.46055, 0.46055, 0.06601, 0.06601, 0},
            {0.46055, 0.06601, 0.78907, 0.78907, 0.78907, 0.06601, 0.06601, 0.46055, 0.46055, 0.46055, 0.46055, 0.06601, 0.06601, 0},
            {0.36049, 0.36049, 0.05227, 0.61824, 0.61824, 0.61824, 0.61824, 0.61824, 0.05227, 0.61824, 0.36049, 0.05227, 0.05227, 0},
            {0.29456, 0.29456, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.29456, 0.04154, 0.04154, 0},
            {0.29456, 0.29456, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.50415, 0.29456, 0.04154, 0.04154, 0},
            {0.34022, 0.04809, 0.04809, 0.34022, 0.34022, 0.58247, 0.58247, 0.58247, 0.04809, 0.58247, 0.34022, 0.58247, 0.58247, 0},
            {0.39788, 0.39788, 0.68079, 0.05749, 0.05749, 0.39788, 0.39788, 0.05749, 0.68079, 0.68079, 0.39788, 0.39788, 0.39788, 0},
            {0.39788, 0.39788, 0.68079, 0.05749, 0.05749, 0.39788, 0.39788, 0.05749, 0.68079, 0.68079, 0.39788, 0.39788, 0.39788, 0},
            {0.69033, 0.40215, 0.40215, 0.05698, 0.05698, 0.40215, 0.40215, 0.05698, 0.05698, 0.40215, 0.69033, 0.69033, 0.69033, 0},
            {0.58333, 0.00000, 0.58333, 1.08333, 0.58333, 1.00000, 0.58333, 0.58333, 0.00000, 0.00000, 0.00000, 0.00000, 0.00000, 0}
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
            return new RatingRC(
                Rating.TableToWeightsMatrix(recWeights),
                Rating.TableToWeightsMatrix(ratWeights),
                Rating.PropTableToWeightsMatrix(recLfWeights),
                Rating.AdaTableToWeightsMatrix(adaWeights),
                rouFactor, fileName);
        }

        public RatingRC(WeightMatrix recMatrix, WeightMatrix ratMatrix, WeightMatrix recLfMatrix, WeightMatrix adaMatrix, double rouFactor, string fileName)
        {
            this._weightREC = recMatrix;
            this._weightRat = ratMatrix;
            this._WeightREClf = recLfMatrix;
            this._adaFact = adaMatrix;
            this._routineFactor = rouFactor;
            this.SettingsFilename = fileName;
            SettingInitialize();
        }

        public RatingRC()
        {
            SettingInitialize();
        }

        /// <summary>
        /// This function initialize settings for the object
        /// </summary>
        public override void SettingInitialize()
        {
            Name = "Rating RUS Cheratte";
            ShortName = "RC";
            WeightREC = _weightREC;
            WeightRat = _weightRat;
            WeightREClf = _WeightREClf;
            Adaptability = _adaFact;
            RoutineFactor = _routineFactor;
            Def("RatingFunctionType", eRatingFunctionType.RUSCheratte);
        }
    }
}
