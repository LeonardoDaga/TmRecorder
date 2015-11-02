using Common;
using NTR_Common;
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

        public static Dictionary<string, string[]> ParseAsSimpleDictionary(string coded)
        {
            if (coded == null) return null;

            ActionsList actionList = Parse(coded);

            string[] Titles = new string[]
                {"ShortPass","ThroughBall","Wing","LongBall","CounterAttack",
                "Corner","Freekick","GkLongBall","GkCounterAttack","Penalty"};

            Dictionary<string, string[]> outputAnalysis = new Dictionary<string, string[]>();

            foreach (KeyValuePair<byte, ActionsItem> item in actionList)
            {
                if (item.Key > 9) continue;

                string failed = "";
                string shot_off = "";
                string shot_in = "";
                string goal = "";

                int total = 0;
                foreach (var i in item.Value)
                {
                    if (i.Key < 4) total += i.Value;
                    if (i.Key == 0) failed = i.Value.ToString();
                    if (i.Key == 1) shot_off = i.Value.ToString();
                    if (i.Key == 2) shot_in = i.Value.ToString();
                    if (i.Key == 3) goal = i.Value.ToString();
                }

                string[] values = new string[4]
                    {total.ToString(), shot_off, shot_in, goal};
                outputAnalysis.Add(Titles[item.Key], values);
            }

            return outputAnalysis;
        }

        public static ItemDictionary ParseAsItemDictionary(string coded)
        {
            if (coded == null) return null;

            ActionsList actionList = Parse(coded);

            ItemDictionary outputAnalysis = new ItemDictionary();

            string[] Titles = new string[]
                {"ShortPass","ThroughBall","Wing","LongBall","CounterAttack",
                "Corner","Freekick","GkLongBall","GkCounterAttack","Penalty"};
            string[] Cols = new string[]
                {"Tot","Fld","ShIn","SOut","Gol"};

            foreach (KeyValuePair<byte, ActionsItem> item in actionList)
            {
                if (item.Key > 9) continue;

                string failed = "";
                string shot_off = "";
                string shot_in = "";
                string goal = "";

                int total = 0;
                foreach (var i in item.Value)
                {
                    if (i.Key < 4) total += i.Value;
                    if (i.Key == 0) failed = i.Value.ToString();
                    if (i.Key == 1) shot_off = i.Value.ToString();
                    if (i.Key == 2) shot_in = i.Value.ToString();
                    if (i.Key == 3) goal = i.Value.ToString();
                }

                string[] strSplit = HTML_Parser.Split(Titles[item.Key], ",");

                outputAnalysis[Titles[item.Key], "Title"] = strSplit[0];
                outputAnalysis[Titles[item.Key], Cols[0]] = total.ToString();
                outputAnalysis[Titles[item.Key], Cols[1]] = failed.ToString();
                outputAnalysis[Titles[item.Key], Cols[2]] = shot_off.ToString();
                outputAnalysis[Titles[item.Key], Cols[3]] = shot_in.ToString();
                outputAnalysis[Titles[item.Key], Cols[4]] = goal.ToString();
            }

            return outputAnalysis;
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
            "Short Pass",           // 0 Short Pass
            "Throu Ball",           // 1 Through Ball
            "Wing",           // 2 Wing
            "Long Ball",           // 3 Long Ball
            "Cnt Attack",           // 4 Counter Attack
            "Corner",           // 5 Corner
            "Freekick",           // 6 Freekick
            "GK CntAtk",           // 7 GK counterattack
            "GK LngBll",           // 8 GK long ball attack
            "Penalty",      	 //  9 Penalty Shot
            "Penalty Fault",           // 10 Penalty Fault
            "Yellow/Red Card",           // 11 Yellow/Red Card
            "Injury",           // 12 Injury
            "Substitution",           // 13 Substitution
            "Not identified",           // 14 Not identified
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
