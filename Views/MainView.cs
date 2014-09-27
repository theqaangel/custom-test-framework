using System;
using System.Linq;
using CustomTestFramework.Core.Controls;
using CustomTestFramework.Core.Controls.Implementation;
using CustomTestFramework.Core.Controls.Interfaces;
using CustomTestFramework.Core.Reporting;

namespace CustomTestFramework.Views
{
    public class MainView : AutomationView
    {

        public IButton ComposeButton
        {
            get
            {
                return new Button("Compose button", By.ClassName("T-I J-J5-Ji T-I-KE L3"));
            }
        }

        public IStaticText InboxLabel
        {
            get
            {
                return new StaticText("Inbox label", By.Title("~Inbox"));
            }
        }

        public int GetInboxMessagesCount()
        {
            int messagesCount = 0;

            string inboxMessages = this.InboxLabel.TextContent;
            if (inboxMessages.Contains("(") && inboxMessages.Contains(")"))
            {
                int start = inboxMessages.IndexOf("(")+1;
                int end = inboxMessages.IndexOf(")");
                int size = end - start;

                string count = inboxMessages.Substring(start, size);

                if (Int32.TryParse(count, out messagesCount))
                {
                    Report.Info(String.Format("Inbox messages are {0}", messagesCount));
                }
                else
                {
                    Report.Error("Inbox messages count can not be determined!");
                }
            }

            return messagesCount;
        }

        public void VerifyInboxMessagesCount(int expectedCount)
        {
            int inboxMessages = this.GetInboxMessagesCount();

            if (expectedCount == inboxMessages)
            {
                Report.Pass(String.Format("Inbox messages count is {0} as expected", expectedCount));
            }
            else
            {
                Report.Error(String.Format("Inbox messages count is {0} instead of {1}", inboxMessages, expectedCount));
            }
        }
    }
}
