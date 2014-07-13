using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicenseCodeComputer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnComputeCode_Click(object sender, EventArgs e)
        {
            string mainTeamId = Common.HTML_Parser.GetFirstNumberInString(txtIdTeam.Text);
            txtCodes.Text = "";
            txtCodes.Text += "The ID and the codes:\r\n";
            txtCodes.Text += "Team ID:" + mainTeamId + " ---> Code:" + GetCode(mainTeamId).ToString() + "\r\n";

            txtCodes.Text += "\r\nThank you :-)";
        }

        private UInt64 GetCode(string clubId)
        {
            int str = clubId.GetHashCode();
            double hashstr = (double)clubId.GetHashCode();

            UInt64 checkCode = (UInt64)(hashstr / (Int64)(DateTime.Now.Year / 2) * Math.E * 1000);

            return checkCode;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            string data = Clipboard.GetText();

            string mainTeamId = Common.HTML_Parser.GetField(data, "<strong>Club ID:</strong> ", "<br />");

            List<string> otherTeamsId = Common.HTML_Parser.GetFieldsCut(data, "<td style=\"width:30px\" class=\"align_center\"><img src=\"/pics/club_logos/", "_25.png?img");

            txtCodes.Text = "";
            txtCodes.Text += "The ID and the codes:\r\n";
            txtCodes.Text += "Team ID:" + mainTeamId + " ---> Code:" + GetCode(mainTeamId).ToString() + "\r\n";

            foreach (string otherTeamId in otherTeamsId)
            {
                txtCodes.Text += "Team ID:" + otherTeamId + " ---> Code:" + GetCode(otherTeamId).ToString() + "\r\n";
            }

            txtCodes.Text += "\r\nThank you :-)";
        }
    }
}
