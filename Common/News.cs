using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class News
    {
        public static string[] GetNews()
        {
            Pop3MailClient DemoClient = new Pop3MailClient("pop.gmail.com", 995, true, "tmrecorder@gmail.com", "juvegrandissimamerda");
            DemoClient.IsAutoReconnect = true;

            //remove the following line if no tracing is needed
            DemoClient.Trace += new TraceHandler(Console.WriteLine);
            DemoClient.ReadTimeout = 4000; //give pop server 60 seconds to answer

            //establish connection
            DemoClient.Connect();

            //get mailbox statistics
            int NumberOfMails, MailboxSize;
            DemoClient.GetMailboxStats(out NumberOfMails, out MailboxSize);

            //get a list of mails
            List<int> EmailIds;
            DemoClient.GetEmailIdList(out EmailIds);

            //get a list of unique mail ids
            List<EmailUid> EmailUids;
            DemoClient.GetUniqueEmailIdList(out EmailUids);

            //get email size
            int size = DemoClient.GetEmailSize(1);

            //get email
            string Email;
            DemoClient.GetRawEmail(1, out Email);

            ////get a list of mails
            //List<int> EmailIds2;
            //DemoClient.GetEmailIdList(out EmailIds2);

            //ping server
            DemoClient.NOOP();

            //close connection
            DemoClient.Disconnect();

            string[] res = null;

            if (NumberOfMails > 0)
            {
                string msg = HTML_Parser.GetField(Email, "[TMR-START]", "[TMR-END]");
                res = msg.Split('|');
            }

            return res;
        }
    }
}
