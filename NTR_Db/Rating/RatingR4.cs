using Common;
using NTR_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTR_Db
{
    public class RatingR4 : RatingFunction
    {
        private double _routineFactor = 0.006153231 * 25;
        private double wage_rate = 19.76;

        public new eRatingFunctionType RatingFunctionType => eRatingFunctionType.RatingR3;

        // Weights need to total 100
        private WeightMatrix _weightR4 = new double[,] {
            // Rating weights 
            // Str		 Sta		 Pac		 Mar		 Tac		 Wor		 Pos		 Pas         Cro		 Tec		 Hea		 Fin		 Lon		 Set
            {0.51872935, 0.29081119, 0.57222393, 0.89735816, 0.84487852, 0.50887940, 0.50887940, 0.13637928, 0.05248024, 0.09388931, 0.57549122, 0.00000000, 0.00000000, 0.0},	// DC
            {0.45240063, 0.31762087, 0.68150374, 0.77724031, 0.74690951, 0.50072196, 0.45947168, 0.17663123, 0.23886264, 0.18410349, 0.46453393, 0.00000000, 0.00000000, 0.0},	// DL/R
            {0.43789335, 0.31844356, 0.53515723, 0.63671706, 0.59109742, 0.51311701, 0.53184426, 0.32421168, 0.06318165, 0.27931537, 0.50093723, 0.19317517, 0.07490902, 0.0},	// DMC
            {0.42311032, 0.32315966, 0.62271745, 0.53932111, 0.51442838, 0.49835997, 0.47896659, 0.26434782, 0.22586124, 0.32182902, 0.45537227, 0.23961054, 0.09291562, 0.0},	// DML/R
            {0.31849880, 0.36581214, 0.50091016, 0.31726444, 0.28029020, 0.52022170, 0.55763723, 0.60199246, 0.10044356, 0.51811057, 0.38320838, 0.38594825, 0.14966211, 0.0},	// MC
            {0.35409971, 0.34443972, 0.64417234, 0.30427501, 0.27956082, 0.49925481, 0.46093655, 0.32887111, 0.38695101, 0.47884837, 0.37465446, 0.39194758, 0.15198852, 0.0},	// ML/R
            {0.32272636, 0.35024067, 0.48762872, 0.22888914, 0.19049636, 0.52620414, 0.57842512, 0.53330409, 0.07523792, 0.55942740, 0.39986691, 0.53866926, 0.20888391, 0.0},	// OMC
            {0.36311066, 0.33106245, 0.61831416, 0.19830147, 0.17415753, 0.50049575, 0.47737842, 0.28937553, 0.34729042, 0.52834210, 0.39939218, 0.55684664, 0.21593269, 0.0},	// OML/R
            {0.40622753, 0.29744114, 0.39446722, 0.09952139, 0.07503885, 0.50402399, 0.58505850, 0.36932466, 0.05210389, 0.53677990, 0.51998862, 0.83588627, 0.32413803, 0.0},	// F
            {0.37313433, 0.37313433, 0.37313433, 0.74626866, 0.52238806, 0.74626866, 0.52238806, 0.52238806, 0.37313433, 0.22388060, 0.22388060, 0.0, 0.0, 0.0 } };	// GK

        private WeightMatrix _weightRb = new double[,] {
            // REC weights 
            // Str		  Sta		  Pac		  Mar		   Tac		    Wor		    Pos		    Pas         Cro		    Tec		    Hea		    Fin		    Lon		    Set
            {0.10493615, 0.05208547, 0.07934211, 0.14448971, 0.13159554, 0.06553072, 0.07778375, 0.06669303, 0.05158306, 0.02753168, 0.12055170, 0.01350989, 0.02549169, 0.03887550},	// DC
            {0.07715535, 0.04943315, 0.11627229, 0.11638685, 0.12893778, 0.07747251, 0.06370799, 0.03830611, 0.10361093, 0.06253997, 0.09128094, 0.01314110, 0.02449199, 0.03726305},	// DL/R
            {0.08219824, 0.08668831, 0.07434242, 0.09661001, 0.08894242, 0.08998026, 0.09281287, 0.08868309, 0.04753574, 0.06042619, 0.05396986, 0.05059984, 0.05660203, 0.03060871},	// DMC
            {0.06744248, 0.06641401, 0.09977251, 0.08253749, 0.09709316, 0.09241026, 0.08513703, 0.06127851, 0.10275520, 0.07985941, 0.04618960, 0.03927270, 0.05285911, 0.02697852},	// DML/R
            {0.07304213, 0.08174111, 0.07248656, 0.08482334, 0.07078726, 0.09568392, 0.09464529, 0.09580381, 0.04746231, 0.07093008, 0.04595281, 0.05955544, 0.07161249, 0.03547345},	// MC
            {0.06527363, 0.06410270, 0.09701305, 0.07406706, 0.08563595, 0.09648566, 0.08651209, 0.06357183, 0.10819222, 0.07386495, 0.03245554, 0.05430668, 0.06572005, 0.03279859},	// ML/R
            {0.07842736, 0.07744888, 0.07201150, 0.06734457, 0.05002348, 0.08350204, 0.08207655, 0.11181914, 0.03756112, 0.07486004, 0.06533972, 0.07457344, 0.09781475, 0.02719742},	// OMC
            {0.06545375, 0.06145378, 0.10503536, 0.06421508, 0.07627526, 0.09232981, 0.07763931, 0.07001035, 0.11307331, 0.07298351, 0.04248486, 0.06462713, 0.07038293, 0.02403557},	// OML/R
            {0.07738289, 0.05022488, 0.07790481, 0.01356516, 0.01038191, 0.06495444, 0.07721954, 0.07701905, 0.02680715, 0.07759692, 0.12701687, 0.15378395, 0.12808992, 0.03805251},	// F
            // For       Rez         Vit         Ind         One         Ref         Aer         Sar         Com         Deg         Aru
            {0.07466384, 0.07466384, 0.07466384, 0.14932769, 0.10452938, 0.14932769, 0.10452938, 0.10344411, 0.07512610, 0.04492581, 0.04479831, 0.0, 0.0, 0.0 } };	// GK


        private WeightMatrix _weightR = new double[,] {
            // REC weights 
            // Str		 Sta		 Pac		 Mar		 Tac		 Wor		 Pos		 Pas         Cro		 Tec		 Hea		 Fin		 Lon		 Set
            {0.653962303361921, 0.330014238020285, 0.562994547223387, 0.891800163983125, 0.871069095865164, 0.454514672470839, 0.555697278549252, 0.42777598627972, 0.338218821750765, 0.134348455965202, 0.796916786677566, 0.048831870932616, 0.116363443378865, 0.282347752982916 },	//DC
            {0.565605120229193, 0.430973382039533, 0.917125432457378, 0.815702528287723, 0.99022325015212, 0.547995876625372, 0.522203232914265, 0.309928898819518, 0.837365352274204, 0.483822472259513, 0.656901420858592, 0.137582588344562, 0.163658117596413, 0.303915447383549 },	//DL/R
            {0.55838825558912, 0.603683502357502, 0.563792314670998, 0.770425088563048, 0.641965853834719, 0.675495235675077, 0.683863478201805, 0.757342915150728, 0.473070797767482, 0.494107823556837, 0.397547163237438, 0.429660916538242, 0.56364174077388, 0.224791093448809  },	//DMC
            {0.582074038075056, 0.420032202680124, 0.7887541874616, 0.726221389774063, 0.722972329840151, 0.737617252827595, 0.62234458453736, 0.466946909655194, 0.814382915598981, 0.561877829393632, 0.367446981999576, 0.360623408340649, 0.390057769678583, 0.249517737311268   },	//DML/R
            {0.578431939417021, 0.778134685048085, 0.574726322388294, 0.71400292078636, 0.635403391007978, 0.822308254446722, 0.877857040588335, 0.864265671245476, 0.433450219618618, 0.697164252367046, 0.412568516841575, 0.586627586272733, 0.617905053049757, 0.308426814834866 },	//MC
            {0.497429376361348, 0.545347364699553, 0.788280917110089, 0.578724574327427, 0.663235306043286, 0.772537143243647, 0.638706135095199, 0.538453108494387, 0.887935381275257, 0.572515970409641, 0.290549550901104, 0.476180499897665, 0.526149424898544, 0.287001645266184},	//ML/R
            {0.656437768926678, 0.617260722143117, 0.656569986958435, 0.63741054520629, 0.55148452726771, 0.922379789905246, 0.790553566121791, 0.999688557334153, 0.426203575603164, 0.778770912265944, 0.652374065121788, 0.662264393455567, 0.73120100926333, 0.274563618133769   },	//OMC
            {0.483341947292063, 0.494773052635464, 0.799434804259974, 0.628789194186491, 0.633847969631333, 0.681354437033551, 0.671233869875345, 0.536121458625519, 0.849389745477645, 0.684067723274814, 0.389732973354501, 0.499972692291964, 0.577231818355874, 0.272773352088982},	//OML/R
            {0.493917051093473, 0.370423904816088, 0.532148929996192, 0.0629206658586336, 0.0904950078155216, 0.415494774080483, 0.54106107545574, 0.468181146095801, 0.158106484131194, 0.461125738338018, 0.83399612271067, 0.999828328674183, 0.827171977606305, 0.253225855459207},	//F
            // For  Rez    Vit    Ind    One    Ref    Aer    Sar    Com    Deg    Aru
            {0.500, 0.333, 0.500, 1.000, 0.500, 1.000, 0.500, 0.500, 0.333, 0.333, 0.333, 0.0, 0.0, 0.0}};   // GK

        private WeightMatrix _recLast = new double[,] {
            //	DC		 DL/R		DMC		    DML/R		MC		    ML/R	    OMC		    OML/R	    F			GK
            { 14.866375, 15.980742, 15.8932675, 15.5835325, 17.6955092, 16.6189141, 18.1255351, 15.6304867, 13.2762119, 15.0 },
            { 18.956640, 22.895539, 23.1801296, 23.2813871, 26.8420884, 23.9940623, 27.8974544, 24.5432300, 19.5088591, 22.3} 
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

            RatingR4 R4 = new RatingR4();

            Rating res = R4.ComputeRating(pds);
        }

        public double funFix1(double i)
        {
            // i = (Math.Round(i * 10) / 10.0);
            return i;
        }

        public double funFix2(double i)
        {
            // i = (Math.Round(i * 100) / 100.0);
            return i;
        }

        public override Rating ComputeRating(PlayerDataSkills playerData)
        {
            var rou = playerData.Rou;
            var MathLogE = 1.4426950408889634;
            var FPn = playerData.FPn;
            var isGK = (FPn == 0);
            int[] positionIndices = Rating.GetPositionIndex(FPn);
            var positionArray = positionIndices[1] != -1 ? new int[] { positionIndices[0], positionIndices[1] } :
                new[] { positionIndices[0] };
            var FP = positionIndices[1] != -1 ? new int[] { positionIndices[0], positionIndices[1] } :
                new[] { positionIndices[0] };
            double[] REREC2 = new double[FP.Length];
            double[][] REREC = null;

            var positionsAll = new double[][] {
            /*0*/    new double [] {0, 2, 2, 1, 3, 3, 2, 4, 4, 3, 4, 4, 4},    // D C
            /*1*/    new double [] {2, 0, 1, 3, 1, 2, 4, 2, 3, 4, 3, 4, 4},    // D L
            /*2*/    new double [] {2, 1, 0, 3, 2, 1, 4, 3, 2, 4, 4, 3, 4},    // D R
            /*3*/    new double [] {1, 3, 3, 0, 2, 2, 1, 3, 3, 2, 4, 4, 3},    // DM C
            /*4*/    new double [] {3, 1, 2, 2, 0, 1, 3, 1, 2, 4, 2, 3, 4},    // DM L
            /*5*/    new double [] {3, 2, 1, 2, 1, 0, 3, 2, 1, 4, 3, 2, 4},    // DM R
            /*6*/    new double [] {2, 4, 4, 1, 3, 3, 0, 2, 2, 1, 3, 3, 2},    // M C
            /*7*/    new double [] {4, 2, 3, 3, 1, 2, 2, 0, 1, 3, 1, 2, 4},    // M L
            /*8*/    new double [] {4, 3, 2, 3, 2, 1, 2, 1, 0, 3, 2, 1, 4},    // M R
            /*9*/    new double [] {3, 4, 4, 2, 4, 4, 1, 3, 3, 0, 2, 2, 1},    // OM C
            /*10*/   new double [] {4, 3, 4, 4, 2, 3, 3, 1, 2, 2, 0, 1, 3},    // OM L
            /*11*/   new double [] {4, 4, 3, 4, 3, 2, 3, 2, 1, 2, 1, 0, 3},    // OM R
            /*12*/   new double [] {4, 4, 4, 3, 4, 4, 2, 4, 4, 1, 3, 3, 0 }    // F C
                };	

            double[] skills = new double[14];
            playerData.Skills.CopyTo(skills, 0);

            int SI = playerData.ASI;

            var rou2 = (3.0 / 100.0) * (100.0 - (100) * Math.Pow(Math.E, -rou * 0.035));

            rou = Math.Pow(5.0 / 3.0, MathLogE * Math.Log(rou * 10));
            
            for (var i = 0; i < positionArray.Length; i++)
            {
                var positionIndex = positionArray[i];

                REREC2[i] = calculateREREC2(positionIndex, skills, SI);

                if (i == 0) 
                    REREC = calculateREREC(positionIndex, skills, SI, rou2);
            }

            var phySum = 0.0;
            var tacSum = 0.0;
            var tecSum = 0.0;
            var weight = 0.0;

            if (isGK)
            {
                phySum = skills[0] * 1 + skills[1] * 1 + skills[2] * 1 + skills[7] * 1;
                tacSum = skills[4] * 1 + skills[6] * 1 + skills[8] * 1;
                tecSum = skills[3] * 1 + skills[5] * 1 + skills[9] * 1 + skills[10] * 1;
                weight = 48717927500;
            }
            else
            {
                phySum = skills[0] * 1 + skills[1] * 1 + skills[2] * 1 + skills[10] * 1;
                tacSum = skills[3] * 1 + skills[4] * 1 + skills[5] * 1 + skills[6] * 1;
                tecSum = skills[7] * 1 + skills[8] * 1 + skills[9] * 1 + skills[11] * 1 + skills[12] * 1 + skills[13] * 1;
                weight = 263533760000;
            }

            var allSum = phySum + tacSum + tecSum;
            var remainder = funFix1(Math.Pow(2.0, Math.Log(weight * SI) / Math.Log(Math.Pow(2.0, 7.0))) - allSum);

            var FP2 = (FP.Length == 1)? new int[] { FP[0] , -1 }: new int[] { FP[0], FP[1] };

            for (int i = 0; i < FP.Length; i++)
            {
                for (int j = 0; 2 + j <= FP[i]; j += 2) 
                    FP[i]--;
            }

            double[,] minR = new double[5, 2];
            double[] rectd = new double[2];
            double[] recbtd = new double[2];
            double[] rattd = new double[2];
            double[] ratingR4 = new double[2];
            double[] rouEffect = new double[2];
            double[] R4Pure = new double[2];
            double[] ratingR2 = new double[2];


            if (FP.Length > 1)
            {
                // REREC
                rectd[0] = REREC[0][FP[0]];
                rectd[1] = REREC[0][FP[1]];
                // RERECb
                recbtd[0] = funFix2(REREC2[0]);
                recbtd[1] = funFix2(REREC2[1]);
                // RatingR4
                rattd[0] = REREC[2][FP[0]];
                rattd[1] = REREC[2][FP[1]];

                for (int i = 1; i < 5; i++)
                {
                    minR[i, 0] = funFix2(REREC[2][FP[0]] * (1 - (20 - skills[1]) * i / 200));
                    minR[i, 1] = funFix2(REREC[2][FP[1]] * (1 - (20 - skills[1]) * i / 200));
                }

                minR[0, 0] = funFix2(REREC[2][FP[0]] * (1 - (20 - skills[1]) * 62 / 93 / 200));
                minR[0, 1] = funFix2(REREC[2][FP[1]] * (1 - (20 - skills[1]) * 62 / 93 / 200));

                ratingR4 = rattd;
                rouEffect[0] = funFix2(REREC[2][FP[0]] * 1 - REREC[1][FP[0]] * 1);
                rouEffect[1] = funFix2(REREC[2][FP[1]] * 1 - REREC[1][FP[1]] * 1);
                R4Pure[0] = REREC[1][FP[0]]; 
                R4Pure[1] = REREC[1][FP[1]];
                ratingR2[0] = funFix2(REREC[1][FP[0]] * (1 + rou * 0.4 * 0.00405));
                ratingR2[1] = funFix2(REREC[1][FP[1]] * (1 + rou * 0.4 * 0.00405));
            }
            else
            {
                rectd[0] = REREC[0][FP[0]];
                recbtd[0] = funFix2(REREC2[0]);
                rattd[0] = REREC[2][FP[0]];
                int staGK;
                if (skills.Length == 11) staGK = 4;
                else staGK = 1;

                for (int i = 1; i < 5; i++)
                {
                    minR[i,0] = funFix2(REREC[2][FP[0]] * (1 - (20 - skills[1]) * i / staGK / 200));
                }
                minR[0,0] = funFix2(REREC[2][FP[0]] * (1 - (20 - skills[1]) * 62 / 93 / staGK / 200));

                ratingR4 = rattd;
                rouEffect[0] = funFix2(REREC[2][FP[0]] * 1 - REREC[1][FP[0]] * 1);
                R4Pure[0] = REREC[1][FP[0]];
                ratingR2[0] = funFix2(R4Pure[0] * (1 + rou * 0.4 * 0.00405));
            }

            var playerID = playerData.ID;
            double[] SeasonTI = seasonTI(playerData);

            double CK = 0.0;
            double FK = 0.0;
            double PK = 0.0;

            if (!isGK) // The player is not a GK
            {
                var peak = new double[] { 4, 4, 6 };
                var goldstar = 0;
                
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 14; i++)
                    {
                        if (j == 0 && skills[i] == 20) goldstar++;
                        if (j == 1 && skills[i] != 20) skills[i] = skills[i] * 1 + remainder / (14 - goldstar);
                    }
                }
                CK = funFix2(skills[8] + skills[13] + skills[9] / 2.0 + rou2 * 2.5);
                FK = funFix2(skills[12] + skills[13] + skills[9] / 2.0 + rou2 * 2.5);
                PK = funFix2(skills[11] + skills[13] + skills[9] / 2.0 + rou2 * 2.5);

                var phySumToShow = (phySum / peak[0] * 5.0);
                var tacSumToShow = (tacSum / peak[1] * 5.0);
                var tecSumToShow = (tecSum / peak[2] * 5.0);
            }
            else
            {
                var peak = new double[] { 4, 3, 4 };

                var phySumToShow = (phySum / peak[0] * 5.0);
                var tacSumToShow = (tacSum / peak[1] * 5.0);
                var tecSumToShow = (tecSum / peak[2] * 5.0);
            }

            double[] R4a = null;
            double[] RECba = null;

            double ada = RatingFunctionAdaptability;
            if (playerData.Ada != 0)
                ada = playerData.Ada;

            if (!isGK)
            {
                R4a = new double[13];
                RECba = new double[13];

                ada = playerData.Ada;

                var R4all = new double[]
                {
                    REREC[2][0], // 01: DC
                    REREC[2][1], // 00: DL
                    REREC[2][1], // 02: DR
                    REREC[2][2], // 04: DMC
                    REREC[2][3], // 03: DML
                    REREC[2][3], // 05: DMR
                    REREC[2][4], // 07: MC
                    REREC[2][5], // 06: ML
                    REREC[2][5], // 08: MR
                    REREC[2][6], // 10: OMC
                    REREC[2][7], // 09: OML
                    REREC[2][7], // 11: OMR
                    REREC[2][8], // 12: FC
                    0
                };

                var RECball = new double[]
                {
                    REREC[0][0], // 01: DC
                    REREC[0][1], // 00: DL
                    REREC[0][1], // 02: DR
                    REREC[0][2], // 04: DMC
                    REREC[0][3], // 03: DML
                    REREC[0][3], // 05: DMR
                    REREC[0][4], // 07: MC
                    REREC[0][5], // 06: ML
                    REREC[0][5], // 08: MR
                    REREC[0][6], // 10: OMC
                    REREC[0][7], // 09: OML
                    REREC[0][7], // 11: OMR
                    REREC[0][8], // 12: FC
                    0
                };

                for (var i = 0; i < 5; i++)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        var num = (4 - i) * 3 + j;

                        if (num < 12 || num == 13)
                        {
                            if (num == 13) num--;
                            if ((FP2[1] != -1) && (positionsAll[FP2[0]][num] > positionsAll[FP2[1]][num]))
                                positionsAll[FP2[0]][num] = positionsAll[FP2[1]][num];
                            R4a[num] = funFix2(R4all[num] * (1 - (20 - ada) * positionsAll[FP2[0]][num] / 200));
                            RECba[num] = funFix2(RECball[num] * (1 - (20 - ada) * positionsAll[FP2[0]][num] / 200));
                        }
                    }
                }
            }

            double[] RECb = null;
            double[] R4 = null;
            double[] R4r = null;

            if (!isGK)
            {
                RECb = new double[]
                {
                    REREC[0][0], // 00: DC
                    REREC[0][1], // 01: DL
                    REREC[0][1], // 02: DR
                    REREC[0][2], // 03: DMC
                    REREC[0][3], // 04: DML
                    REREC[0][3], // 05: DMR
                    REREC[0][4], // 06: MC
                    REREC[0][5], // 07: ML
                    REREC[0][5], // 08: MR
                    REREC[0][6], // 09: OMC
                    REREC[0][7], // 10: OML
                    REREC[0][7], // 11: OMR
                    REREC[0][8], // 12: FC
                    0
                };

                R4 = new double[]
                {
                    REREC[1][0], // 00: DC
                    REREC[1][1], // 01: DL
                    REREC[1][1], // 02: DR
                    REREC[1][2], // 03: DMC
                    REREC[1][3], // 04: DML
                    REREC[1][3], // 05: DMR
                    REREC[1][4], // 06: MC
                    REREC[1][5], // 07: ML
                    REREC[1][5], // 08: MR
                    REREC[1][6], // 09: OMC
                    REREC[1][7], // 10: OML
                    REREC[1][7], // 11: OMR
                    REREC[1][8], // 12: FC
                    0
                };

                R4r = new double[]
                {
                    REREC[2][0], // 00: DC
                    REREC[2][1], // 01: DL
                    REREC[2][1], // 02: DR
                    REREC[2][2], // 03: DMC
                    REREC[2][3], // 04: DML
                    REREC[2][3], // 05: DMR
                    REREC[2][4], // 06: MC
                    REREC[2][5], // 07: ML
                    REREC[2][5], // 08: MR
                    REREC[2][6], // 09: OMC
                    REREC[2][7], // 10: OML
                    REREC[2][7], // 11: OMR
                    REREC[2][8], // 12: FC
                    0
                };
            }
            else
            {
                RECb = new double[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    REREC[0][9], // 13: GK
                };

                R4 = new double[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    REREC[1][9]  // 13: GK
                };

                R4r = new double[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    REREC[2][9]  // 13: GK
                };
            }

            var R4Rating = new Rating
            {
                rec = (RECba == null) ? RECb : RECba,
                rating = R4,
                ratingR = (R4a == null) ? R4r : R4a,
                CK = CK,
                FK = FK,
                PK = PK,
            };

            R4Rating.OSi = GetOSi(R4Rating, playerData);

            return R4Rating;
        }

        protected override (double min, double max) MinMaxRatingForSkillsum(int FPn, double skillsSum)
        {
            int[] FP = Rating.GetPositionIndex(FPn);
            int[] RP = new int[] { Tm_Utility.FpToRp(FP[0]), Tm_Utility.FpToRp(FP[1]) };

            if (RP[1] == -1)
            {
                double min = 0, max = 0;
                int i = 0;
                double d = 0;

                for (; d < skillsSum - 20; d += 20, i++)
                    min += OrderedWeightRat[RP[0], i] * 20;

                min += OrderedWeightRat[RP[0], i] * (skillsSum - d);

                i = 13;
                d = 0;

                for (; d < skillsSum - 20; d += 20, i--)
                    max += OrderedWeightRat[RP[0], i] * 20;

                max += OrderedWeightRat[RP[0], i] * (skillsSum - d);

                return (min, max);
            }
            else
            {
                double min1 = 0, max1 = 0, min2 = 0, max2 = 0;

                int i = 0;
                double d = 0;
                for (; d < skillsSum - 20; d += 20, i++)
                    min1 += OrderedWeightRat[RP[0], i] * 20;
                min1 += OrderedWeightRat[RP[0], i] * (skillsSum - d);

                i = 0;
                d = 0;
                for (; d < skillsSum - 20; d += 20, i++)
                    min2 += OrderedWeightRat[RP[1], i] * 20;
                min2 += OrderedWeightRat[RP[1], i] * (skillsSum - d);

                i = 13;
                d = 0;
                for (; d < skillsSum - 20; d += 20, i--)
                    max1 += OrderedWeightRat[RP[0], i] * 20;
                max1 += OrderedWeightRat[RP[0], i] * (skillsSum - d);

                i = 13;
                d = 0;
                for (; d < skillsSum - 20; d += 20, i--)
                    max2 += OrderedWeightRat[RP[1], i] * 20;
                max2 += OrderedWeightRat[RP[1], i] * (skillsSum - d);

                return ((min1 < min2) ? min2 : min1, max1 < max2 ? max2 : max1);
            }
        }

        internal override double[] Relevances(int FPn)
        {
            if (FPn != 0)
            {
                int[] posIndex = Rating.GetPositionIndex(FPn);

                double[] relevances = new double[14];

                for (int i = 0; i < 14; i++)
                {
                    double W1 = 80 * WeightRat[Tm_Utility.FpToRp(posIndex[0]), i];

                    if (posIndex[1] == -1)
                    {
                        relevances[i] = W1;
                        continue;
                    }

                    double W2 = 80 * WeightRat[Tm_Utility.FpToRp(posIndex[1]), i];

                    relevances[i] = (W1 > W2 ? W1 : W2);
                }

                return relevances;
            }
            else
            {
                double[] relevances = new double[11];

                for (int i = 0; i < 11; i++)
                {
                    relevances[i] = 80 * WeightRat[9, i];
                }

                return relevances;
            }
        }

        public double GetOSi(Rating R, PlayerDataSkills pds)
        {
            double rMax = R.rating[0];
            // Find the maximum speciality result

            for (int i = 1; i < R.rating.Length; i++)
                rMax = Math.Max(rMax, R.rating[i]);

            double skillsSum = pds.SkillSum;

            (double min, double max) = MinMaxRatingForSkillsum(pds.FPn, skillsSum);

            return (rMax - min) / (max - min) * 100;
        }

        private double[][] calculateREREC(int positionIndex, 
            double[] skills, double SI, double rou)
        {
            double weight;

            if (positionIndex == 13) 
                weight = 48717927500;
            else 
                weight = 263533760000;

            double[] rec = new double [10];           // RERECb
            double[] ratingR = new double[10];       // RatingR4
            double[] ratingR4 = new double[10];      // RatingR4 + routine
            double skillSum = 0;

            for (var i = 0; i < skills.Length; i++)
            {
                skillSum += skills[i];
            }
            for (var i = 0; 2 + i <= positionIndex; i += 2)
            {       // TrExMaとRECのweight表のずれ修正
                positionIndex--;
            }
            var remainder = Math.Round((Math.Pow(2, Math.Log(weight * SI) / Math.Log(Math.Pow(2, 7))) - skillSum) * 10) / 10;       // RatingR4 remainder
            for (var i = 0; i < 10; i++)
            {
                rec[i] = 0;
                ratingR[i] = 0;
            }
            for (var j = 0; j < 9; j++)
            {       // All position
                var remWeightREC = 0.0;       // REREC remainder weight sum
                var remWeightRat = 0.0;       // RatingR4 remainder weight sum
                var not20 = 0;                  // 20以外のスキル数
                if (positionIndex == 9) j = 9;  // GK

                for (var i = 0; i < WeightR.Cols; i++)
                {
                    rec[j] += skills[i] * WeightRb[j,i];
                    ratingR[j] += skills[i] * WeightR4[j,i];
                    if (skills[i] != 20)
                    {
                        remWeightREC += WeightRb[j,i];
                        remWeightRat += WeightR4[j,i];
                        not20++;
                    }
                }
                if (remainder / not20 > 0.9 || not20 == 0)
                {
                    if (positionIndex == 9) not20 = 11;
                    else not20 = 14;
                    remWeightREC = 1;
                    remWeightRat = 5;
                }

                rec[j] = (rec[j] + remainder * remWeightREC / not20 - 2.0) / 3.0;
                ratingR[j] += remainder * remWeightRat / not20;
                ratingR4[j] = ratingR[j] + rou * 5;
                ratingR[j] = ratingR[j];
                if (positionIndex == 9) j = 9;      // Loop end
            }

            var recAndRating = new double[3][];
            recAndRating[0] = rec;
            recAndRating[1] = ratingR;
            recAndRating[2] = ratingR4;

            return recAndRating;
        }

        private double calculateREREC2(int positionIndex, 
            double[] skills, double SI)
        {
            double skillWeightSum;
            double weight;

            if (positionIndex == 13)
            {
                skillWeightSum = Math.Pow(SI, 0.143) / 0.02979;         // GK Skillsum
                weight = 48717927500;
            }
            else
            {
                skillWeightSum = Math.Pow(SI, 1.0 / 6.99194) / 0.02336483;    // Other Skillsum
                weight = 263533760000;
            }

            var skillSum = 0.0;
            for (var j = 0; j < skills.Length; j++)
            {
                skillSum += skills[j];
            }
            var remainder = Math.Round((Math.Pow(2.0, Math.Log(weight * SI) / Math.Log(Math.Pow(2.0, 7.0))) - skillSum) * 10) / 10;       // 正確な余り
            var rec = 0.0;
            var weightSum = 0.0;
            var not20 = 0;

            for (int i = 0; 2 + i <= positionIndex; i += 2)
            {       // TrExMaとRECのweight表のずれ修正
                positionIndex--;
            }

            if (positionIndex == -1)
                return 0;

            skillWeightSum -= skillSum;         // REREC remainder
            for (var i = 0; i < WeightR.Cols; i++)
            {
                rec += skills[i] * WeightR[positionIndex,i];
                if (skills[i] != 20)
                {
                    weightSum += WeightR[positionIndex,i];
                    not20++;
                }
            }
            if (remainder / not20 > 0.9 || not20 == 0)
            {
                weightSum = 0;
                for (var i = 0; i < WeightR.Cols; i++) 
                    weightSum += WeightR[positionIndex,i];
                if (positionIndex == 9) not20 = 11;
                else not20 = 14;
            }
            rec += skillWeightSum * weightSum / not20;  // REREC Score
            if (positionIndex == 9) rec *= 1.27;                    // GK
            rec = (rec - RecLast[0,positionIndex]) / RecLast[1,positionIndex];

            return rec;
        }

        public double[] seasonTI(PlayerDataSkills playerData)
        {
            var wage = playerData.Wage;
            var today = new DateTime();
            var playerID = playerData.ID;

            // s50 start
            var SS = new DateTime(2017, 04, 17, 8, 0, 0, DateTimeKind.Utc);
            // first training
            var training1 = new DateTime(2017, 04, 17, 23, 0, 0, DateTimeKind.Utc);
            
            var day = (today - training1).TotalDays; // 1000 / 3600 / 24;
            while (day > 84 - 16 / 24) day -= 84;

            var session = Math.Floor(day / 7) + 1;                          // training sessions
            var ageMax = 20.1 + session / 12;                           // max new player age

            double age = (TmWeek.thisWeek().absweek - playerData.wBorn) / 12.0;

            var check = (today - SS).TotalDays;
            var season = 84;
            var count = 0;

            double SI = playerData.ASI;

            while (check > season)
            {
                check -= season;
                count++;
            }

            var weight = 0.0;
            if (playerData.FPn > 0) weight = 263533760000;
            else weight = 48717927500;

            double[] seasonTI;

            if (wage == 30000 || (playerID > 119142233 && count == 0))
            {   // s50 youth player ID
                seasonTI = null;
            }
            else
            {
                var TI1 = Math.Pow(2, Math.Log(weight * SI) / Math.Log(Math.Pow(2, 7))) - Math.Pow(2, Math.Log(weight * wage / (wage_rate)) / Math.Log(Math.Pow(2, 7)));
                TI1 = Math.Round(TI1 * 10);

                if (session == 0)
                    seasonTI = new double[] { TI1, TI1 };
                else
                    seasonTI = new double[] { TI1, TI1 / session };
            }

            if (playerID > 118768860 && age < ageMax)
            {       
                // s50 BOT player ID
                if (wage == 30000)
                    seasonTI = null;
                else
                {
                    wage_rate = 23.75;
                    var TI2 = Math.Pow(2, Math.Log(weight * SI) / Math.Log(Math.Pow(2, 7))) - Math.Pow(2, Math.Log(weight * wage / (wage_rate)) / Math.Log(Math.Pow(2, 7)));
                    seasonTI = new double[] { TI2, TI2 };
                }
            }

            return seasonTI;
        }

        public RatingR4()
        {
            SettingInitialize();
        }

        public WeightMatrix WeightR
        {
            get => (WeightMatrix)this["WeightR"];
            set => this["WeightR"] = value;
        }

        public WeightMatrix WeightRb
        {
            get => (WeightMatrix)this["WeightRb"];
            set => this["WeightRb"] = value;
        }

        public WeightMatrix RecLast
        {
            get => (WeightMatrix)this["RecLast"];
            set => this["RecLast"] = value;
        }

        public WeightMatrix WeightR4
        {
            get => (WeightMatrix)this["WeightR4"];
            set
            {
                this["WeightR4"] = value;
                OrderedWeightRat = SortRowsByCols(value);
            }
        }

        public override WeightMatrix WeightRat { get => WeightR4; set => WeightR4 = value; }
        
        /// <summary>
        /// This function initialize settings for the object
        /// </summary>
        public override void SettingInitialize()
        {
            Name = "RatingR4";
            ShortName = "R4";
            WeightR = _weightR;
            WeightR4 = _weightR4;
            WeightRb = _weightRb;
            RoutineFactor = _routineFactor;
            RecLast = _recLast;
            Def("RatingFunctionType", eRatingFunctionType.RatingR4);
        }
    }
}
