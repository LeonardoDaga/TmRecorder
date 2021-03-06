using NTR_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTR_Db
{
    public class RatingR2: RatingFunction
    {
        private double _routineFactor = 0.00405;

        public new eRatingFunctionType RatingFunctionType => eRatingFunctionType.RatingR2;

        // Weights need to total 100
        private WeightMatrix _weightRat = new double[,] {
            // Rating weights 
            // Str		   Sta			Pac			 Mar		  Tac		   Wor		    Pos			 Pas          Cro		   Tec			Hea			 Fin		  Lon		   Set
            {0.51872935  , 0.29081119 , 0.57222393 , 0.89735816 , 0.84487852 , 0.50887940 , 0.50887940 , 0.13637928 , 0.05248024 , 0.09388931 , 0.57549122 , 0.00000000 , 0.00000000 , 0.00000000  },	// DC
            { 0.46087883 , 0.31034824 , 0.65619359 , 0.73200504 , 0.70343948 , 0.49831122 , 0.46654859 , 0.16635132 , 0.22496087 , 0.19697949 , 0.48253326 , 0.07310254 , 0.02834753 , 0.00000000  },	// DL/R
            { 0.46087883 , 0.31034824 , 0.65619359 , 0.73200504 , 0.70343948 , 0.49831122 , 0.46654859 , 0.16635132 , 0.22496087 , 0.19697949 , 0.48253326 , 0.07310254 , 0.02834753 , 0.00000000  },	// DL/R
            { 0.43732502 , 0.31888984 , 0.53618097 , 0.63897616 , 0.59319466 , 0.51330795 , 0.53166961 , 0.32536200 , 0.06340582 , 0.27886822 , 0.49996910 , 0.18940400 , 0.07344664 , 0.00000000  },	// DMC
            { 0.42233965 , 0.32373447 , 0.62437404 , 0.54169665 , 0.51669428 , 0.49853202 , 0.47851686 , 0.26551219 , 0.22685609 , 0.32146118 , 0.45396969 , 0.23513340 , 0.09117948 , 0.00000000  },	// DML/R
            { 0.42233965 , 0.32373447 , 0.62437404 , 0.54169665 , 0.51669428 , 0.49853202 , 0.47851686 , 0.26551219 , 0.22685609 , 0.32146118 , 0.45396969 , 0.23513340 , 0.09117948 , 0.00000000  },	// DML/R
            { 0.34304950 , 0.35058989 , 0.49918296 , 0.34631352 , 0.30595388 , 0.52078076 , 0.56068322 , 0.52568923 , 0.08771222 , 0.47650463 , 0.41232903 , 0.41160135 , 0.15960981 , 0.00000000  },	// MC
            { 0.37404045 , 0.33153172 , 0.62642777 , 0.33260815 , 0.30559265 , 0.50117998 , 0.47502314 , 0.28759565 , 0.33838614 , 0.44322386 , 0.40347341 , 0.41859521 , 0.16232188 , 0.00000000  },	// ML/R
            { 0.37404045 , 0.33153172 , 0.62642777 , 0.33260815 , 0.30559265 , 0.50117998 , 0.47502314 , 0.28759565 , 0.33838614 , 0.44322386 , 0.40347341 , 0.41859521 , 0.16232188 , 0.00000000  },	// ML/R
            { 0.31998474 , 0.35180968 , 0.49002842 , 0.23116817 , 0.19239312 , 0.52687030 , 0.57839880 , 0.53861416 , 0.07598706 , 0.56096162 , 0.39614367 , 0.53152625 , 0.20611401 , 0.00000000  },	// OMC
            { 0.36069138 , 0.33248748 , 0.62214126 , 0.20034326 , 0.17595073 , 0.50091992 , 0.47631079 , 0.29235505 , 0.35086625 , 0.52960856 , 0.39553712 , 0.54964726 , 0.21314094 , 0.00000000  },	// OML/R
            { 0.36069138 , 0.33248748 , 0.62214126 , 0.20034326 , 0.17595073 , 0.50091992 , 0.47631079 , 0.29235505 , 0.35086625 , 0.52960856 , 0.39553712 , 0.54964726 , 0.21314094 , 0.00000000  },	// OML/R
            { 0.40324698 , 0.29906901 , 0.39676419 , 0.10106757 , 0.07620466 , 0.50471883 , 0.58512049 , 0.37506253 , 0.05291339 , 0.53882195 , 0.51604535 , 0.82935839 , 0.32160667 , 0.00000000  },	// F
            { 0.45462811 , 0.30278232 , 0.45462811 , 0.90925623 , 0.45462811 , 0.90925623 , 0.45462811 , 0.45462811 , 0.30278232 , 0.15139116 , 0.15139116  , 0, 0, 0 } };  // GK

        private WeightMatrix _weightREC = new double[,] {
            // REC weights 
            // Str				 Sta				Pac				    Mar				   Tac				   Wor				Pos				   Pas				  Cro				 Tec				Hea				   Fin				  Lon				 Set
            {0.653962303361921,  0.330014238020285, 0.562994547223387, 0.891800163983125,  0.871069095865164,  0.454514672470839, 0.555697278549252, 0.42777598627972,  0.338218821750765, 0.134348455965202, 0.796916786677566, 0.048831870932616, 0.116363443378865, 0.282347752982916},	//DC
			{0.565605120229193,  0.430973382039533, 0.917125432457378, 0.815702528287723,  0.99022325015212,   0.547995876625372, 0.522203232914265, 0.309928898819518, 0.837365352274204, 0.483822472259513, 0.656901420858592, 0.137582588344562, 0.163658117596413, 0.303915447383549},	//DL/R
			{0.565605120229193,  0.430973382039533, 0.917125432457378, 0.815702528287723,  0.99022325015212,   0.547995876625372, 0.522203232914265, 0.309928898819518, 0.837365352274204, 0.483822472259513, 0.656901420858592, 0.137582588344562, 0.163658117596413, 0.303915447383549},	//DL/R
			{0.55838825558912,   0.603683502357502, 0.563792314670998, 0.770425088563048,  0.641965853834719,  0.675495235675077, 0.683863478201805, 0.757342915150728, 0.473070797767482, 0.494107823556837, 0.397547163237438, 0.429660916538242, 0.56364174077388,  0.224791093448809},	//DMC
			{0.582074038075056,  0.420032202680124, 0.7887541874616,   0.726221389774063,  0.722972329840151,  0.737617252827595, 0.62234458453736,  0.466946909655194, 0.814382915598981, 0.561877829393632, 0.367446981999576, 0.360623408340649, 0.390057769678583, 0.249517737311268},	//DML/R
			{0.582074038075056,  0.420032202680124, 0.7887541874616,   0.726221389774063,  0.722972329840151,  0.737617252827595, 0.62234458453736,  0.466946909655194, 0.814382915598981, 0.561877829393632, 0.367446981999576, 0.360623408340649, 0.390057769678583, 0.249517737311268},	//DML/R
			{0.578431939417021,  0.778134685048085, 0.574726322388294, 0.71400292078636,   0.635403391007978,  0.822308254446722, 0.877857040588335, 0.864265671245476, 0.433450219618618, 0.697164252367046, 0.412568516841575, 0.586627586272733, 0.617905053049757, 0.308426814834866},	//MC
			{0.497429376361348,  0.545347364699553, 0.788280917110089, 0.578724574327427,  0.663235306043286,  0.772537143243647, 0.638706135095199, 0.538453108494387, 0.887935381275257, 0.572515970409641, 0.290549550901104, 0.476180499897665, 0.526149424898544, 0.287001645266184},	//ML/R
			{0.497429376361348,  0.545347364699553, 0.788280917110089, 0.578724574327427,  0.663235306043286,  0.772537143243647, 0.638706135095199, 0.538453108494387, 0.887935381275257, 0.572515970409641, 0.290549550901104, 0.476180499897665, 0.526149424898544, 0.287001645266184},	//ML/R
			{0.656437768926678,  0.617260722143117, 0.656569986958435, 0.63741054520629,   0.55148452726771,   0.922379789905246, 0.790553566121791, 0.999688557334153, 0.426203575603164, 0.778770912265944, 0.652374065121788, 0.662264393455567, 0.73120100926333,  0.274563618133769},	//OMC
			{0.483341947292063,  0.494773052635464, 0.799434804259974, 0.628789194186491,  0.633847969631333,  0.681354437033551, 0.671233869875345, 0.536121458625519, 0.849389745477645, 0.684067723274814, 0.389732973354501, 0.499972692291964, 0.577231818355874, 0.272773352088982},	//OML/R
			{0.483341947292063,  0.494773052635464, 0.799434804259974, 0.628789194186491,  0.633847969631333,  0.681354437033551, 0.671233869875345, 0.536121458625519, 0.849389745477645, 0.684067723274814, 0.389732973354501, 0.499972692291964, 0.577231818355874, 0.272773352088982},	//OML/R
			{0.493917051093473,  0.370423904816088, 0.532148929996192, 0.0629206658586336, 0.0904950078155216, 0.415494774080483, 0.54106107545574,  0.468181146095801, 0.158106484131194, 0.461125738338018, 0.83399612271067,  0.999828328674183, 0.827171977606305, 0.253225855459207},	//F
            // For  Rez    Vit  Ind  One  Ref Aer  Sar  Com    Deg    Aru
			{0.5, 0.333, 0.5, 1,   0.5, 1,  0.5, 0.5, 0.333, 0.333, 0.333, 0.0, 0.0, 0.0}}; //GK

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
                    var remWeightREC = 0.0;		// REREC remainder weight sum
                    var remWeightRat = 0.0;		// RatingR2 remainder weight sum
                    var not20 = 0;					// 20以外のスキル数
                    if (playerData.FPn == 0) j = 13;	// GK

                    int weightLength = (playerData.FPn == 0) ? 11 : 14;
                    for (var i = 0; i < weightLength; i++)
                    {
                        R.rec[j] += playerData.Skills[i] * _weightREC[j, i];
                        R.rating[j] += playerData.Skills[i] * _weightRat[j, i];

                        if (playerData.Skills[i] != 20)
                        {
                            remWeightREC += _weightREC[j, i];
                            remWeightRat += _weightRat[j, i];
                            not20 += 1;
                        }
                    }

                    R.rec[j] += rerecRemainder * remWeightREC / not20;		//REREC Score

                    if (positionIndex[n] == 13)
                        R.rec[j] *= 1.27;					//GK

                    R.rec[j] = (R.rec[j] - _WeightREClf[j, 0]) / _WeightREClf[j, 1];
                    R.rating[j] += ratingRemainder * remWeightRat / not20;
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

        //internal static RatingFunction Create(List<REC_Weights> recWeights, List<REC_Weights> ratWeights,
        //    List<PROP_Weights> recLfWeights, List<ADA_Weights> adaWeights, double rouFactor, string fileName)
        //{
        //    return new RatingR2(
        //        Rating.TableToWeightsMatrix(recWeights),
        //        Rating.TableToWeightsMatrix(ratWeights),
        //        Rating.PropTableToWeightsMatrix(recLfWeights),
        //        Rating.AdaTableToWeightsMatrix(adaWeights),
        //        rouFactor, fileName);
        //}

        //public RatingR2(WeightMatrix recMatrix, WeightMatrix ratMatrix, WeightMatrix recLfMatrix, WeightMatrix adaMatrix, double rouFactor, string fileName)
        //{
        //    this._weightREC = recMatrix;
        //    this._weightRat = ratMatrix;
        //    this._WeightREClf = recLfMatrix;
        //    this._adaFact = adaMatrix;
        //    this._routineFactor = rouFactor;
        //    this.SettingsFilename = fileName;
        //    SettingInitialize();
        //}

        public RatingR2()
        {
            SettingInitialize();
        }

        public WeightMatrix WeightREClf
        {
            get => (WeightMatrix)this["WeightREClf"];
            set => this["WeightREClf"] = value;
        }

        public WeightMatrix WeightREC
        {
            get => (WeightMatrix)this["WeightREC"];
            set => this["WeightREC"] = value;
        }
        public override WeightMatrix WeightRat
        {
            get => (WeightMatrix)this["WeightRat"];
            set
            {
                this["WeightRat"] = value;
                OrderedWeightRat = SortRowsByCols(value);
            }
        }

        public WeightMatrix Adaptability
        {
            get => (WeightMatrix)this["Adaptability"];
            set => this["Adaptability"] = value;
        }


        /// <summary>
        /// This function initialize settings for the object
        /// </summary>
        public override void SettingInitialize()
        {
            Name = "RatingR2";
            ShortName = "R2";
            WeightREC = _weightREC;
            WeightRat = _weightRat;
            WeightREClf = _WeightREClf;
            Adaptability = _adaFact;
            RoutineFactor = _routineFactor;
            Def("RatingFunctionType", eRatingFunctionType.RatingR2);
        }
    }
}
