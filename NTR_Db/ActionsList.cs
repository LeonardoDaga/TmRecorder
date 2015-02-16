using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace NTR_Db
{
    [Serializable]
    public class PlayersActionList : Dictionary<int, ActionsList>
    {
        public static PlayersActionList Parse(string coded)
        {
            PlayersActionList ai = new PlayersActionList();

            string[] items = coded.Split('§');
            foreach (string item in items)
            {
                string[] strs = item.Split('=');
                int key = int.Parse(strs[0]);
                ActionsList val = ActionsList.Parse(strs[1]);
                ai.Add(key, val);
            }

            return ai;
        }

        public override string ToString()
        {
            string str = "";

            foreach (KeyValuePair<int, ActionsList> item in this)
            {
                str += item.Key.ToString() + "=" + item.Value.ToString() + "§";
            }

            return str;
        }
    }

    [Serializable]
    public class ActionsItem : Dictionary<byte, short>
    {
        // Outcomes type (attack)
        //[0]	"Failed attack"	object {string}
        //[1]	"Off Shot"	object {string}
        //[2]	"In Shot"	object {string}
        //[3]	"Goal"	object {string}
        //[4]	"Ban for the opposite team"	object {string}
        //[5]	"Injury for the opposite team"	object {string}        
        
        // Outcomes type (defense)
        //[6]	"Failed attack"	object {string}
        //[7]	"Off Shot"	object {string}
        //[8]	"In Shot"	object {string}
        //[9]	"Goal"	object {string}

        internal void AddAttack(byte outcome)
        {
            if (!this.ContainsKey(outcome))
                this.Add(outcome, 0);

            this[outcome]++;
        }

        internal void AddDefend(byte outcome)
        {
            if (!this.ContainsKey((byte)(outcome + 6)))
                this.Add((byte)(outcome + 6), 0);

            this[(byte)(outcome + 6)]++;
        }

        public static ActionsItem Parse(string coded)
        {
            ActionsItem ai = new ActionsItem();

            string[] items = coded.Split('|');
            foreach (string item in items)
            {
                if (item == "") continue;

                string[] strs = item.Split(':');
                byte key = byte.Parse(strs[0]);
                short val = short.Parse(strs[1]);
                ai.Add(key, val);
            }

            return ai;
        }

        public override string ToString()
        {
            string str = "";

            foreach (KeyValuePair<byte, short> item in this)
            {
                str += item.Key.ToString() + ":" + item.Value.ToString() + "|";
            }

            return str;
        }
    }

    [Serializable]
    public class ActionsList : Dictionary<byte, ActionsItem>
    {
        // Action Type
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
        //[10]	"Substitution"	object {string}
        //[11]	"Not identified"	object {string}

        // Outcome
        //[0]	"Failed attack"	object {string}
        //[1]	"Off Shot"	object {string}
        //[2]	"In Shot"	object {string}
        //[3]	"Goal"	object {string}
        //[4]	"Ban for the opposite team"	object {string}
        //[5]	"Injury for the opposite team"	object {string}        
        //[6]	"No outcome"	object {string}

        public override string ToString()
        {
            string str = "";

            foreach(KeyValuePair<byte, ActionsItem> item in this)
            {
                str += item.Key.ToString() + "," + item.Value.ToString() + ";";
            }

            return str;
        }

        internal static ActionsList Parse(string coded)
        {
            ActionsList al = new ActionsList();

            string[] items = coded.Split(';');
            foreach (string item in items)
            {
                if (item == "") continue;

                string[] strs = item.Split(',');
                byte key = byte.Parse(strs[0]);
                ActionsItem val = ActionsItem.Parse(strs[1]);
                al.Add(key, val);
            }

            return al;
        }

        public void AddNewAttackAction(NTR_SquadDb.ActionsDecoderRow actionDecRow)
        {
            if (!this.ContainsKey(actionDecRow.Type))
                this.Add(actionDecRow.Type, new ActionsItem());

            ActionsItem action = this[actionDecRow.Type];
            action.AddAttack(actionDecRow.Outcome);
        }

        public void AddNewDefendAction(NTR_SquadDb.ActionsDecoderRow actionDecRow)
        {
            if (actionDecRow.Outcome >= 4) return;

            if (!this.ContainsKey(actionDecRow.Type))
                this.Add(actionDecRow.Type, new ActionsItem());

            ActionsItem action = this[actionDecRow.Type];

            action.AddDefend(actionDecRow.Outcome);
        }
    }
}
