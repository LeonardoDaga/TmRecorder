using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTR_Db
{
    public partial class ActionDecoder : Form
    {

        public ActionDecoder()
        {
            InitializeComponent();
        }

        public NTR_SquadDb.ActionsDecoderRow Data { get; set; }

        public string FullDescription { get; set; }
        public string Description { get; set; }

        private void ActionDecoder_Load(object sender, EventArgs e)
        {
            lblActionDescription.Text = Description;

            //[0]	"Short Pass"	object {string}
            //[1]	"Through Ball"	object {string}
            //[2]	"Wing"	object {string}
            //[3]	"Long Ball"	object {string}
            //[4]	"Counter Attack"	object {string}
            //[5]	"Corner"	object {string}
            //[6]	"Freekick"	object {string}
            //[7]	"GK counterattack"	object {string}
            //[8]	"GK long ball attack"	object {string}
            //[9]	"Penalty"	object {string}
            //[10]	"card"	object {string}
            //[11]	"Injuries"	object {string}
            //[12]	"Substitution"	object {string}
            //[13]	"Not identified"	object {string}
            int actionType;
            if (Data.ActionCode.StartsWith("sho"))
            {
                actionType = 0;
            }
            else if (Data.ActionCode.StartsWith("thr"))
            {
                actionType = 1;
            }
            else if (Data.ActionCode.StartsWith("win"))
            {
                actionType = 2;
            }
            else if (Data.ActionCode.StartsWith("cou"))
            {
                actionType = 4;
            }
            else if (Data.ActionCode.StartsWith("lon"))
            {
                actionType = 3;
            }
            else if (Data.ActionCode.StartsWith("doe"))
            {
                actionType = 5;
            }
            else if (Data.ActionCode.StartsWith("dire"))
            {
                actionType = 6;
            }
            else if (Data.ActionCode.StartsWith("kco"))
            {
                actionType = 7;
            }
            else if (Data.ActionCode.StartsWith("klo"))
            {
                actionType = 8;
            }
            else if (Data.ActionCode.StartsWith("p_sh"))
            {
                actionType = 9;
            }
            else if (Data.ActionCode.StartsWith("p_as"))
            {
                actionType = 10;
            }
            else if (Data.ActionCode.StartsWith("card"))
            {
                actionType = 11;
            }
            else if (Data.ActionCode.StartsWith("inj"))
            {
                actionType = 12;
            }
            else if (Data.ActionCode.StartsWith("cod"))
            {
                actionType = 13;
            }
            else 
            {
                actionType = 14;
            }
            chkActionType.SetItemChecked(actionType, true);

            //[0]	"Failed attack"	object {string}
            //[1]	"Off Shot"	object {string}
            //[2]	"In Shot"	object {string}
            //[3]	"Goal"	object {string}
            //[4]	"Penalty"	object {string}
            //[5]	"Ban for the opposite team"	object {string}
            //[6]	"Injury"	object {string}
            //[7]	"No outcome"	object {string}
            if (FullDescription.Contains("<goal;"))
            {
                chkOutcome.SetItemChecked(3, true);
            }
            else if (FullDescription.Contains("<shot;") && FullDescription.Contains(";target=off>"))
            {
                chkOutcome.SetItemChecked(1, true);
            }
            else if (FullDescription.Contains("<shot;") && FullDescription.Contains(";target=on>"))
            {
                chkOutcome.SetItemChecked(2, true);
            }
            else if ((FullDescription.Contains("<yellow=")) || (FullDescription.Contains("<red=")) || (FullDescription.Contains("<yellow_red=")))
            {
                chkOutcome.SetItemChecked(5, true);
            }
            else if (FullDescription.Contains("<injury="))
            {
                chkOutcome.SetItemChecked(6, true);
            }
            else if (FullDescription.Contains("<sub_out="))
            {
                chkOutcome.SetItemChecked(7, true);
            }
            else if (actionType == 10)
            {
                chkOutcome.SetItemChecked(4, true);
            }
            else if (actionType == 9)
            {
                chkOutcome.SetItemChecked(7, true);
            }
            else if (actionType == 11) // card action without a card from the referee
            {
                chkOutcome.SetItemChecked(7, true);
            }
            else if (actionType == 13) // action with no fault
            {
                chkOutcome.SetItemChecked(7, true);
            }
            else // Failed attack
            {
                if (actionType < 9)
                    chkOutcome.SetItemChecked(0, true);
                else
                    chkOutcome.SetItemChecked(7, true);
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (int ix in chkActionType.CheckedIndices)
            {
                Data.Type = (byte)ix;
            }

            foreach (int ix in chkOutcome.CheckedIndices)
            {
                Data.Outcome = (byte)ix;
            }
        }

        public static object GetStats(string p)
        {
            throw new NotImplementedException();
        }
    }
}
