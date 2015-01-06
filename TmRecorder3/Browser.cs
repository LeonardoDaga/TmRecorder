using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TmRecorder3
{
    class Browser
    {
        string startnavigationAddress = "";

        internal void Import()
        {
            if (!startnavigationAddress.StartsWith("http://trophymanager.com/"))
                return;

            if (startnavigationAddress.StartsWith("http://trophymanager.com/buy-pro/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/forum/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/club/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/league/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/fixtures/league/") ||
                startnavigationAddress.StartsWith("http://trophymanager.com/home/"))
            {
                MessageBox.Show("This page cannot be imported in TmRecorder");
                return;
            }

            if (startnavigationAddress.StartsWith("http://trophymanager.com/players/"))
            {
                string str = HTML_Parser.GetNumberAfter(startnavigationAddress, "players/");
                if (str != "-1")
                {
                    MessageBox.Show("This page has to be imported in the Player Info Panel");
                    return;
                }
            }

        }
    }
}
