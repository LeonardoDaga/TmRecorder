using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Drawing;

namespace FieldFormationControl
{
    [Flags]
    public enum eSkills
    {
        // Summary:
        //     None skill
        None = 0,
        // Summary:
        //     A strong player has a strength skill is 15 or higher. 
        Strong = 1,
        //
        // Summary:
        //     A fast player has a pace skill is 15 or higher. 
        Fast = 2,
        //
        // Summary:
        //     A strong defender has marking and tackling skills average 15 or higher. 
        Defender = 4,
        //
        // Summary:
        //     A sound tactician is a player whose work rate and positioning skills average 15 or higher
        Tactician = 8,
        //
        // Summary:
        //     A playmaker averages 15 or higher in passing and technique
        Playmaker = 16,
        //
        // Summary:
        //     A dangerous winger is a player whose pace, crossing and technique skills average 15 or higher. 
        Winger = 32,
        //
        // Summary:
        //     A clinical finisher averages 15 or higher in finishing and long shot skills.  
        Finisher = 64,
        //
        // Summary:
        //     A header specialist has a heading skill of 15 or higher. 
        Header = 128,
        //
        // Summary:
        //     The player is a good goalkeeper. 
        GK = 256,
        //
        // Summary:
        //     The player is injuried. 
        RedCross = 512,
        //
        // Summary:
        //     The player has been a star player during last match 
        Star = 1024,
        //
        // Summary:
        //     The player has a red card 
        RedCard = 2048,
        //
        // Summary:
        //     The player has a yellow card
        YellowCard = 4096,
    }

    public class Shirt
    {
        int[] iPts = { 0, 5, 7, 0, 10, 0, 12, 2, 18, 2, 20, 0, 24, 0, 30, 5, 28, 10, 25, 8, 23, 8, 23, 20, 7, 20,
        7, 8, 5, 8, 2, 10};
        const int NUMSHIRTPTS = 16;
        Point[] pts = new Point[NUMSHIRTPTS];
        Point[] shpts = new Point[NUMSHIRTPTS];
        public static int XSize = 30;
        public static int YSize = 20;

        public Shirt(int posX = 25, int posY = 13)
        {
            for (int i = 0; i < NUMSHIRTPTS; i++)
            {
                pts[i].X = posX + iPts[i * 2];
                pts[i].Y = posY + iPts[i * 2 + 1];
                shpts[i].X = pts[i].X + 2;
                shpts[i].Y = pts[i].Y + 3;
            }
        }

        public void Draw(Graphics g, Brush brShade, Brush brBack, Pen pen)
        {
            // Draw the shirt
            g.FillPolygon(brShade, shpts);
            g.FillPolygon(brBack, pts);
            g.DrawPolygon(pen, pts);
        }
    }
}
