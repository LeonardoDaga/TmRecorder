using TM_Scanner;
using System.Collections.Generic;
namespace TM_Player_Scanner
{


    partial class PlayerScanInfo
    {
        internal void FindNameID(string page)
        {
            List<string> tables = HTML_Parser.GetTags(page, "table");

            // Analyze players section
            string[] lines = tables[0].Split('\n');

            foreach (string line in lines)
            {
                if (!line.Contains("showprofile.php?playerid=")) continue;

                int iniID = line.IndexOf("showprofile.php?playerid=") + 25;
                int endID = line.IndexOf("\'", iniID);

                PlayerScanInfo.GiocatoriRow gr = Giocatori.NewGiocatoriRow();

                string line2scan = line.Substring(iniID, endID - iniID);
                gr.PlayerID = int.Parse(line2scan);
                gr.Nome = HTML_Parser.GetField(line.Substring(endID), "&nbsp;", "</span>");

                Giocatori.AddGiocatoriRow(gr);
            }

            // Analyze GK section
            lines = tables[1].Split('\n');

            foreach (string line in lines)
            {
                if (!line.Contains("showprofile.php?playerid=")) continue;

                int iniID = line.IndexOf("showprofile.php?playerid=") + 25;
                int endID = line.IndexOf("\'", iniID);

                PlayerScanInfo.GiocatoriRow gr = Giocatori.NewGiocatoriRow();

                string line2scan = line.Substring(iniID, endID - iniID);
                gr.PlayerID = int.Parse(line2scan);
                gr.Nome = HTML_Parser.GetField(line.Substring(endID), "<span>", "</span>");

                Giocatori.AddGiocatoriRow(gr);
            }
        }
    }
}
