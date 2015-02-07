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
            //[7]	"GK long ball attack"	object {string}
            //[8]	"card"	object {string}
            //[9]	"Injuries"	object {string}
            if (Data.ActionCode.StartsWith("sho"))
            {
                chkActionType.SetItemChecked(0, true);
            }
            else if (Data.ActionCode.StartsWith("thr"))
            {
                chkActionType.SetItemChecked(1, true);
            }
            else if (Data.ActionCode.StartsWith("win"))
            {
                chkActionType.SetItemChecked(2, true);
            }
            else if (Data.ActionCode.StartsWith("cou"))
            {
                chkActionType.SetItemChecked(4, true);
            }
            else if (Data.ActionCode.StartsWith("lon"))
            {
                chkActionType.SetItemChecked(3, true);
            }
            else if (Data.ActionCode.StartsWith("doe"))
            {
                chkActionType.SetItemChecked(5, true);
            }
            else if (Data.ActionCode.StartsWith("dire"))
            {
                chkActionType.SetItemChecked(6, true);
            }
            else if (Data.ActionCode.StartsWith("kco"))
            {
                chkActionType.SetItemChecked(7, true);
            }
            else if (Data.ActionCode.StartsWith("card"))
            {
                chkActionType.SetItemChecked(8, true);
            }
            else if (Data.ActionCode.StartsWith("inj"))
            {
                chkActionType.SetItemChecked(9, true);
            }
            else 
            {
                chkActionType.SetItemChecked(0, true);
            }

            //[0]	"Failed attack"	object {string}
            //[1]	"Off Shot"	object {string}
            //[2]	"In Shot"	object {string}
            //[3]	"Goal"	object {string}
            //[4]	"Ban for the opposite team"	object {string}
            //[5]	"Ban for the opposite team"	object {string}
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
            else if (FullDescription.Contains("<yellow="))
            {
                chkOutcome.SetItemChecked(4, true);
            }
            else if (FullDescription.Contains("<injury="))
            {
                chkOutcome.SetItemChecked(5, true);
            }
            else // Failed attack
            {
                chkOutcome.SetItemChecked(0, true);
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

        public string FullDescription { get; set; }
    }
}
