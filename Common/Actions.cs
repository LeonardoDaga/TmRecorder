using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Action
    {
        public static int Count(string str, string actType)
        {
            int ix = 0;
            int cnt = 0;
            string estr = str.Replace('|', ',');

            while (ix != -1)
            {
                ix = estr.IndexOf(actType, ix);

                if (ix == -1) continue;

                int ixi = estr.LastIndexOf(',', ix);

                string q = estr.Substring(ixi + 1, ix - ixi - 1);

                int quantity = int.Parse(q);

                cnt += quantity;

                ix++;
            }

            return cnt;
        }

        public static int Count(string str, string[] actTypes)
        {
            int cnt = 0;
            string estr = str.Replace('|', ',');

            foreach (string actType in actTypes)
            {
                int ix = 0;
                while (ix != -1)
                {
                    ix = estr.IndexOf(actType, ix);

                    if (ix == -1) continue;

                    int ixi = estr.LastIndexOf(',', ix);

                    string q = estr.Substring(ixi + 1, ix - ixi - 1);

                    int quantity = int.Parse(q);

                    cnt += quantity;

                    ix++;
                }
            }

            return cnt;
        }
    }

    public class ActionItem
    {
        public int playerID;
        public string actions;

        public ActionItem(int id, string acts)
        {
            playerID = id;
            actions = ActionsSum("", acts);
        }

        internal void Add(string analysis)
        {
            actions = ActionsSum(actions, analysis);
        }

        private string ActionsSum(string oldActions, string plActions)
        {
            // actions are the actions to add
            string[] actions = plActions.Split(',');

            foreach (string action in actions)
            {
                if (action == "")
                    continue;

                if (oldActions == "")
                {
                    oldActions = "1" + action;
                    continue;
                }

                int ix = oldActions.IndexOf(action);
                if (ix == -1)
                {
                    oldActions += ",1" + action;
                    continue;
                }

                int ixi = oldActions.LastIndexOf(',', ix);

                string q = oldActions.Substring(ixi + 1, ix - ixi - 1);

                int quantity = int.Parse(q);

                if (oldActions.Length > ix + 2)
                {
                    if (ixi == -1)
                    {
                        oldActions = (quantity + 1).ToString() + action +
                                                    oldActions.Substring(ix + 2);
                    }
                    else
                    {
                        oldActions = oldActions.Substring(0, ixi) + "," +
                                                    (quantity + 1).ToString() + action +
                                                    oldActions.Substring(ix + 2);
                    }
                }
                else
                {
                    if (ixi == -1)
                    {
                        oldActions = (quantity + 1).ToString() + action;
                    }
                    else
                    {
                        oldActions = oldActions.Substring(0, ixi) + "," +
                                        (quantity + 1).ToString() + action;
                    }
                }
            }

            return oldActions;
        }
    }

    public class ActionList : List<ActionItem>
    {
        public int UntranslatedActions = 0;
        public int TranslatedActions = 0;

        public void AddAnalysis(int plID, string analysis)
        {
            int i = 0;
            for (; i < this.Count; i++)
            {
                if (this[i].playerID == plID) break;
            }

            if (i == Count) // not found
            {
                Add(new ActionItem(plID, analysis));
            }
            else
            {
                this[i].Add(analysis);
            }

            TranslatedActions++;
        }
    }
}
