﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTR_Common
{
    public class RatingR2
    {
        public decimal[] rec = new decimal[13]; // REREC
        public decimal[] ratingR = new decimal[13]; // RatingR2
        public decimal[] ratingR2 = new decimal[13]; // RatingR2 + routine

        static decimal rou_factor = 0.00405M;

        // Weights need to total 100
        static double[,] weights = new double[,] { {85,12, 3},  // D C
				                    {70,25, 5},  // D L
				                    {70,25, 5},  // D R
				                    {90,10, 0},  // DM C
				                    {50,40,10},  // DM L
				                    {50,40,10},  // DM R
				                    {85,12, 3},  // M C			   
				                    {90, 7, 3},  // M L
				                    {90, 7, 3},  // M R
				                    {90,10, 0},  // OM C
				                    {60,35, 5},  // OM  L
				                    {60,35, 5},  // OMR
				                    {80,18, 2},  // F
				                    {50,42, 8}}; // GK

        static double[,] weightR2 = new double[,] { {0.51872935	,	0.29081119	,	0.57222393	,	0.89735816	,	0.84487852	,	0.50887940	,	0.50887940	,	0.13637928	,	0.05248024	,	0.09388931	,	0.57549122	,	0.00000000	,	0.00000000	,	0.00000000	},	// DC
                {	0.46087883	,	0.31034824	,	0.65619359	,	0.73200504	,	0.70343948	,	0.49831122	,	0.46654859	,	0.16635132	,	0.22496087	,	0.19697949	,	0.48253326	,	0.07310254	,	0.02834753	,	0.00000000	},	// DL/R
                {	0.43732502	,	0.31888984	,	0.53618097	,	0.63897616	,	0.59319466	,	0.51330795	,	0.53166961	,	0.32536200	,	0.06340582	,	0.27886822	,	0.49996910	,	0.18940400	,	0.07344664	,	0.00000000	},	// DMC
                {	0.42233965	,	0.32373447	,	0.62437404	,	0.54169665	,	0.51669428	,	0.49853202	,	0.47851686	,	0.26551219	,	0.22685609	,	0.32146118	,	0.45396969	,	0.23513340	,	0.09117948	,	0.00000000	},	// DML/R
                {	0.34304950	,	0.35058989	,	0.49918296	,	0.34631352	,	0.30595388	,	0.52078076	,	0.56068322	,	0.52568923	,	0.08771222	,	0.47650463	,	0.41232903	,	0.41160135	,	0.15960981	,	0.00000000	},	// MC
                {	0.37404045	,	0.33153172	,	0.62642777	,	0.33260815	,	0.30559265	,	0.50117998	,	0.47502314	,	0.28759565	,	0.33838614	,	0.44322386	,	0.40347341	,	0.41859521	,	0.16232188	,	0.00000000	},	// ML/R
                {	0.31998474	,	0.35180968	,	0.49002842	,	0.23116817	,	0.19239312	,	0.52687030	,	0.57839880	,	0.53861416	,	0.07598706	,	0.56096162	,	0.39614367	,	0.53152625	,	0.20611401	,	0.00000000	},	// OMC
                {	0.36069138	,	0.33248748	,	0.62214126	,	0.20034326	,	0.17595073	,	0.50091992	,	0.47631079	,	0.29235505	,	0.35086625	,	0.52960856	,	0.39553712	,	0.54964726	,	0.21314094	,	0.00000000	},	// OML/R
                {	0.40324698	,	0.29906901	,	0.39676419	,	0.10106757	,	0.07620466	,	0.50471883	,	0.58512049	,	0.37506253	,	0.05291339	,	0.53882195	,	0.51604535	,	0.82935839	,	0.32160667	,	0.00000000	},	// F
                {	0.45462811	,	0.30278232	,	0.45462811	,	0.90925623	,	0.45462811	,	0.90925623	,	0.45462811	,	0.45462811	,	0.30278232	,	0.15139116	,	0.15139116	, 0, 0, 0}};	// GK

        // REC weights Str				   Sta				  Pac				 Mar				 Tac				 Wor				Pos				   Pas				  Cro				 Tec				Hea				   Fin				  Lon				 Set
        static double[,] weightR = new double[,] { {0.653962303361921,  0.330014238020285, 0.562994547223387, 0.891800163983125,  0.871069095865164,  0.454514672470839, 0.555697278549252, 0.42777598627972,  0.338218821750765, 0.134348455965202, 0.796916786677566, 0.048831870932616, 0.116363443378865, 0.282347752982916},	//DC
			           {0.565605120229193,  0.430973382039533, 0.917125432457378, 0.815702528287723,  0.99022325015212,   0.547995876625372, 0.522203232914265, 0.309928898819518, 0.837365352274204, 0.483822472259513, 0.656901420858592, 0.137582588344562, 0.163658117596413, 0.303915447383549},	//DL/R
			           {0.55838825558912,   0.603683502357502, 0.563792314670998, 0.770425088563048,  0.641965853834719,  0.675495235675077, 0.683863478201805, 0.757342915150728, 0.473070797767482, 0.494107823556837, 0.397547163237438, 0.429660916538242, 0.56364174077388,  0.224791093448809},	//DMC
			           {0.582074038075056,  0.420032202680124, 0.7887541874616,   0.726221389774063,  0.722972329840151,  0.737617252827595, 0.62234458453736,  0.466946909655194, 0.814382915598981, 0.561877829393632, 0.367446981999576, 0.360623408340649, 0.390057769678583, 0.249517737311268},	//DML/R
			           {0.578431939417021,  0.778134685048085, 0.574726322388294, 0.71400292078636,   0.635403391007978,  0.822308254446722, 0.877857040588335, 0.864265671245476, 0.433450219618618, 0.697164252367046, 0.412568516841575, 0.586627586272733, 0.617905053049757, 0.308426814834866},	//MC
			           {0.497429376361348,  0.545347364699553, 0.788280917110089, 0.578724574327427,  0.663235306043286,  0.772537143243647, 0.638706135095199, 0.538453108494387, 0.887935381275257, 0.572515970409641, 0.290549550901104, 0.476180499897665, 0.526149424898544, 0.287001645266184},	//ML/R
			           {0.656437768926678,  0.617260722143117, 0.656569986958435, 0.63741054520629,   0.55148452726771,   0.922379789905246, 0.790553566121791, 0.999688557334153, 0.426203575603164, 0.778770912265944, 0.652374065121788, 0.662264393455567, 0.73120100926333,  0.274563618133769},	//OMC
			           {0.483341947292063,  0.494773052635464, 0.799434804259974, 0.628789194186491,  0.633847969631333,  0.681354437033551, 0.671233869875345, 0.536121458625519, 0.849389745477645, 0.684067723274814, 0.389732973354501, 0.499972692291964, 0.577231818355874, 0.272773352088982},	//OML/R
			           {0.493917051093473,  0.370423904816088, 0.532148929996192, 0.0629206658586336, 0.0904950078155216, 0.415494774080483, 0.54106107545574,  0.468181146095801, 0.158106484131194, 0.461125738338018, 0.83399612271067,  0.999828328674183, 0.827171977606305, 0.253225855459207},	//F
        //			   For  Rez    Vit  Ind  One  Ref Aer  Sar  Com    Deg    Aru
			           {0.5, 0.333, 0.5, 1,   0.5, 1,  0.5, 0.5, 0.333, 0.333, 0.333, 0.0, 0.0, 0.0}}; //GK

        //				DC		   DL/R		  DMC		  DML/R		  MC		  ML/R		  OMC		  OML/R		  F			  GK
        static double[,] recLast = new double[,] { {14.866375, 15.980742, 15.8932675, 15.5835325, 17.6955092, 16.6189141, 18.1255351, 15.6304867, 13.2762119, 15},
                        {18.95664,  22.895539, 23.1801296, 23.2813871, 26.8420884, 23.9940623, 27.8974544, 24.54323,   19.5088591, 22.3}};

        /// <summary>
        /// This function returns REREC values (3 values, rec, ratingR2 and ratingR2 modified by
        /// the routine
        /// </summary>
        /// <param name="positionIndex"></param>
        /// <param name="skills"></param>
        /// <param name="SI"></param>
        /// <param name="rou"></param>
        /// <returns></returns>
        public static RatingR2 CalculateREREC(TeamDS.GiocatoriNSkillRow gnsRow)
        {
            decimal skillWeightSum, weight;
            decimal SI = gnsRow.ASI;
            decimal rou = gnsRow.Rou;

            RatingR2 R2 = new RatingR2();

            if (gnsRow.FPn == 0) // The player is a GK
            {
                skillWeightSum = (decimal)(Math.Pow((double)SI, 0.143) / 0.02979);
                weight = 48717927500;
            }
            else
            {
                skillWeightSum = (decimal)(Math.Pow((double)SI, 1 / 6.99194) / 0.02336483);
                weight = 263533760000;
            }

            decimal skillSum = gnsRow.SkillSum;

            // REREC remainder
            skillWeightSum -= skillSum;

            // RatingR2 remainder
            var remainder = Math.Round((Math.Pow(2.0, Math.Log((double)(weight * SI)) / Math.Log(Math.Pow(2, 7))) - (double)skillSum) * 10.0) / 10.0;

            int[] positionIndex = GetPositionIndex(gnsRow.FPn);

            for (int n = 0; n < 2; n++)
            {
                for (int i = 0; i <= positionIndex[n] - 2; i += 2)
                {		// TrExMaとRECのweight表のずれ修正
                    positionIndex[n]--;
                }

                for (int i = 0; i < 10; i++)
                {
                    R2.rec[i] = 0;
                    R2.ratingR[i] = 0;
                }

                for (var j = 0; j < 9; j++) // All position
                {
                    var remainderWeight = 0.0;		// REREC remainder weight sum
                    var remainderWeight2 = 0.0;		// RatingR2 remainder weight sum
                    var not20 = 0;					// 20以外のスキル数
                    if (positionIndex[n] == 9) j = 9;	// GK

                    for (var i = 0; i < 14; i++)
                    {
                        R2.rec[j] += gnsRow.Skills[i] * (decimal)weightR[j, i];
                        R2.ratingR[j] += gnsRow.Skills[i] * (decimal)weightR2[j, i];

                        if (gnsRow.Skills[i] != 20M)
                        {
                            remainderWeight += weightR[j, i];
                            remainderWeight2 += weightR2[j, i];
                            not20 += 1;
                        }
                    }

                    R2.rec[j] += (decimal)(skillWeightSum * (decimal)remainderWeight / (decimal)not20);		//REREC Score

                    if (positionIndex[n] == 9)
                        R2.rec[j] *= 1.27M;					//GK

                    R2.rec[j] = funFix((decimal)(((double)R2.rec[j] - recLast[0, j]) / recLast[1, j]));
                    R2.ratingR[j] += (decimal)(remainder * remainderWeight2 / not20);
                    R2.ratingR2[j] = funFix(R2.ratingR[j] * (1M + rou * rou_factor));
                    R2.ratingR[j] = funFix(R2.ratingR[j]);

                    if (positionIndex[n] == 9)
                        j = 9;		// Loop end
                }
            }

            R2.TransformToTMR();
            return R2;
        }

        private void TransformToTMR()
        {
            for (int i=12; i >= 0; i--)
            {
                int j = i / 3 * 2 + ((i % 3 > 0) ? 1 : 0);
                rec[i] = rec[j];
                ratingR[i] = ratingR[j];
                ratingR2[i] = ratingR2[j];
            }
        }

        private static decimal funFix(decimal i)
        {
            return (Math.Round(i * 100) / 100);
        }

        private static int[] GetPositionIndex(int FPn)
        {
            if (FPn == 0) return new int[] { 13, -1 };

            int[] FP = Common.Tm_Utility.FPnToFPvector(FPn);
            int[] Position = new int[2];

            for (int i = 0; i < 2; i++)
            {
                switch(FP[i])
                {
                    case 0:
                    case 3:
                    case 6:
                    case 9:
                    case 12: Position[i] = FP[i]; break;

                    case 1:
                    case 4:
                    case 7:
                    case 10: Position[i] = FP[i] + 1; break;

                    case 2:
                    case 5:
                    case 8:
                    case 11: Position[i] = FP[i] - 1; break;
                }
            }

            return Position;
        }
    }
}