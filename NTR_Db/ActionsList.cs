using System;
using System.Collections.Generic;
using System.Data;
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

        public static ActionsList Parse(string coded)
        {
            if (coded == null)
                return null;

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

        public static NTR_SquadDb.ActionsTableDataTable ParseAsTable(string coded)
        {
            if (coded == null) return null;

            ActionsList actionList = Parse(coded);

            NTR_SquadDb.ActionsTableDataTable adt = new NTR_SquadDb.ActionsTableDataTable();

            foreach (KeyValuePair<byte, ActionsItem> item in actionList)
            {
                if (item.Key > 9) continue;

                NTR_SquadDb.ActionsTableRow ar = adt.NewActionsTableRow();
                ar.Name = ActionStat.ActionStatStr[item.Key];

                int total = 0;

                foreach (var i in item.Value)
                {
                    if (i.Key < 4) total += i.Value;
                    if (i.Key == 0) ar.Failed = i.Value;
                    if (i.Key == 1) ar.Shot_Off = i.Value;
                    if (i.Key == 2) ar.Shot_in = i.Value;
                    if (i.Key == 3) ar.Goal = i.Value;
                }
                
                ar.Total = total;

                adt.AddActionsTableRow(ar);
            }

            return adt;
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

        public static EnumerableRowCollection<ActionStat> GetStats(string listOfActions)
        {
            ActionsList actionList = ActionsList.Parse(listOfActions);

            if (actionList == null)
                return null;

            var actionStats = (from a in actionList
                               select new ActionStat(a));

            return actionStats as EnumerableRowCollection<ActionStat>;
        }
    }

    public class ActionStat
    {
        public string Name;
        public int Total;
        public int Failed;
        public int Shot_off;
        public int Shot_in;
        public int Goal;
        private KeyValuePair<byte, ActionsItem> a;

        public static string[] ActionStatStr = new string[]
        {
            "Short Pass",           // Short Pass
            "Throu Ball",           // Through Ball
            "Wing",           // Wing
            "Long Ball",           // Long Ball
            "Cnt Attack",           // Counter Attack
            "Corner",           // Corner
            "Freekick",           // Freekick
            "GK CntAtk",           // GK counterattack
            "GK LngBll",           // GK long ball attack
            "Penalty",      	 //  Penalty Shot
            "Penalty Fault",           // Penalty Fault
            "Yellow/Red Card",           // Yellow/Red Card
            "Injury",           // Injury
            "Substitution",           // Substitution
            "Not identified",           // Not identified
        };

        public ActionStat(KeyValuePair<byte, ActionsItem> a)
        {
            Name = ActionStatStr[a.Key];
            ActionsItem ai = a.Value;

            int total = 0;
            foreach(var i in ai)
            {
                total++;
                if (i.Key == 0) Failed = i.Value;
                if (i.Key == 1) Shot_off = i.Value;
                if (i.Key == 2) Shot_in = i.Value;
                if (i.Key == 3) Goal = i.Value;
            }
            Total = total;
        }
    }
}
