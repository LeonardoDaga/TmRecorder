//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Common
//{
//    public class Tactics
//    {
//        public enum FactorType
//        {
//            Standard,
//            Modified
//        }

//        public enum Type
//        {
//            Direct,
//            Wings,
//            ShortPass,
//            LongBalls,
//            Through
//        }

//        public enum Position: int
//        {
//            Attack = 0,
//            Defense = 1,
//        }

//        static public float[] Factor(FactorType factType,
//                                   ExtTMDataSet.GiocatoriNSkillRow gnsr,
//                                   Type type,
//                                   float limit)
//        {
//            if (factType == FactorType.Standard)
//                return Standard(gnsr, type, limit);
//            else
//                return Modified(gnsr, type, limit);
//        }

//        static public float[] Factor(FactorType factType,
//                                   ExtTMDataSet.GiocatoriNSkillRow gnsr,
//                                   Type type)
//        {
//            if (factType == FactorType.Standard)
//                return Standard(gnsr, type, 5.0f);
//            else
//                return Modified(gnsr, type, 5.0f);
//        }

//        static public float[] Standard(ExtTMDataSet.GiocatoriNSkillRow gnsr,
//                                   Type type, 
//                                   float limit)
//        {
//            float[] f = new float[4];
//            f[0] = f[1] = f[2] = f[3] = float.NaN;

//            switch(type)
//            {
//                case Type.Direct:
//                    f[0] = 1.0f + 0.2f * ((float)gnsr.Pas - limit) / 10.0f
//                                 + 0.2f * ((float)gnsr.Vel - limit) / 10.0f;
//                    f[1] = 0;
//                    return f;
//                case Type.Wings:
//                    f[0] = 1.0f + 0.32f * ((float)gnsr.Vel - limit) / 10.0f
//                            + 0.32f * ((float)gnsr.Tec - limit) / 10.0f
//                            + 0.32f * ((float)gnsr.Cro - limit) / 10.0f;
//                    f[1] = 0;
//                    return f;
//                case Type.ShortPass:
//                    f[0] = 1.0f + 0.22f * ((float)gnsr.Pas - limit) / 10.0f
//                             + 0.22f * ((float)gnsr.Wor - limit) / 10.0f;
//                    f[1] = 0;
//                    return f;
//                case Type.LongBalls:
//                    f[0] = 1.0f + 0.2f * ((float)gnsr.Pas - limit) / 10.0f
//                             + 0.2f * ((float)gnsr.Cro - limit) / 10.0f;
//                    f[1] = 0;
//                    return f;
//                case Type.Through:
//                    f[0] = 1.0f + 0.32f * ((float)gnsr.Pas - limit) / 10.0f
//                             + 0.32f * ((float)gnsr.Vel - limit) / 10.0f;
//                    f[1] = 0;
//                    return f;
//            }

//            return f;
//        }

//        static public float[] Modified(ExtTMDataSet.GiocatoriNSkillRow gnsr,
//                                   Type type,
//                                   float limit)
//        {
//            float[] f = new float[2];

//            switch (type)
//            {
//                case Type.Direct:
//                    f[0] = 12.07f * ((float)gnsr.Vel) / 10.0f
//                         + 12.07f * ((float)gnsr.Res) / 10.0f
//                         + 12.07f * ((float)gnsr.Pas) / 10.0f
//                         + 6.9f * ((float)gnsr.Pos) / 10.0f
//                         + 6.9f * ((float)gnsr.Wor) / 10.0f;
//                    f[1] = 10.60f * ((float)gnsr.Mar) / 10.0f
//                         + 10.60f * ((float)gnsr.Pos) / 10.0f
//                         + 10.60f * ((float)gnsr.Wor) / 10.0f
//                         + 6.06f * ((float)gnsr.Vel) / 10.0f
//                         + 6.06f * ((float)gnsr.Con) / 10.0f
//                         + 6.06f * ((float)gnsr.Res) / 10.0f;
//                    return f;
//                case Type.Wings:
//                    f[0] = 1.0f + 0.32f * ((float)gnsr.Vel - limit) / 10.0f
//                            + 0.32f * ((float)gnsr.Tec - limit) / 10.0f
//                            + 0.32f * ((float)gnsr.Cro - limit) / 10.0f;
//                    f[1] = 0;
//                    return f;
//                case Type.ShortPass:
//                    f[0] = 1.0f + 0.22f * ((float)gnsr.Pas - limit) / 10.0f
//                             + 0.22f * ((float)gnsr.Wor - limit) / 10.0f;
//                    f[1] = 0;
//                    return f;
//                case Type.LongBalls:
//                    f[0] = 1.0f + 0.2f * ((float)gnsr.Pas - limit) / 10.0f
//                             + 0.2f * ((float)gnsr.Cro - limit) / 10.0f;
//                    f[1] = 0;
//                    return f;
//                case Type.Through:
//                    f[0] = 1.0f + 0.32f * ((float)gnsr.Pas - limit) / 10.0f
//                             + 0.32f * ((float)gnsr.Vel - limit) / 10.0f;
//                    f[1] = 0;
//                    return f;
//            }

//            return f;
//        }

//    }
//}
