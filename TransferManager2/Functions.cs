using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace TransferManager
{
    class SearchSettings
    {
        public int playersPerPage;
        public int pageNum;

        public bool ScanSettings(string page)
        {
            string tag25 = HTML_Parser.GetTagContainingText(page, "id=pages_25");
            string tag50 = HTML_Parser.GetTagContainingText(page, "id=pages_50");
            // string tag100 = HTML_Parser.GetTagContainingText(page, "id=pages_100");

            if (tag25.Contains("#ccff00"))
                playersPerPage = 25;
            else if (tag50.Contains("#ccff00"))
                playersPerPage = 50;
            else // (tag100.Contains("#ccff00"))
                playersPerPage = 100;

            return false;
        }
    }
}
