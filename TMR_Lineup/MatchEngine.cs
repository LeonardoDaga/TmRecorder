using System;
using System.Collections.Generic;
using System.Text;

namespace TMR_Lineup
{
    public enum eHPos
    {
        L, R, C, CL, CR,
    }

    public enum eVPos
    {
        GK, D, DM, M, OM, F
    }

    class PlayPos
    {
        public eHPos H;
        public eVPos V;
    }

    class Player
    {
        public int ID;
        public PlayPos Pos;
        public float VEL;
        public float FIS;
        public float RES;

        public float DEF;
        public float CRO;
        public float PAS;
        public float TEC;
        public float CDT;
        public float TIR;

        public float DET;
        public float CAR;
        public float FOR;
        public float ESP;
    }

    class LineUp
    {
        public Player[] players = new Player[16];
    }

    public enum ePossZone:int
    {
        DL = 0, 
        D = 1, 
        DR = 2, 
        M = 3, 
        OL = 4, 
        O = 5, 
        OR = 6,
        NUM_ZONES = 7
    }

    class Possession
    {
        public float[] Zone = new float[7];
    }

    class MatchEngine
    {
        void ComputeMatch(LineUp teamHome, LineUp teamAway)
        {
            // Calcola il possesso palla delle due squadre
            Possession possHome = ComputePossession(teamHome);
            Possession possAway = ComputePossession(teamAway);

        }

        private Possession ComputePossession(LineUp teamHome)
        {
            Possession resPossession = new Possession();

            // Il posseso palla deve essere calcolato su ognuna delle zone di campo
            resPossession.Zone[(int)ePossZone.DL] = 0f;
            foreach (Player pl in teamHome.players)
            {
                // DL Zone
                if ((pl.Pos.V == eVPos.D)&&(pl.Pos.H == eHPos.L))
                {
                    float fPoss = 0.0f;
                }
            }

            // Ritorna il risultato
            return resPossession;
        }
    }
}
