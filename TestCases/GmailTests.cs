using System;
using System.Linq;
using System.Threading;
using CustomTestFramework.Core;
using CustomTestFramework.Core.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomTestFramework.TestCases
{
    [TestClass,
    EntryPoint("http://gmail.com")]
    public class GmailTests : BaseTestCase
    {
        [TestMethod,
        Description("Verify Log In")]
        public void LogInTest()
        {
            loginView.EmailTextBox.Enter(testUser.Username);
            loginView.PasswordTextBox.Enter(testUser.Password);
            loginView.SignInButton.Click();

            mainView.IsPresented();
        }

        //[TestMethod,
        //Description("Verify mail composing")]
        //public void ComposeMailTest()
        //{
        //    loginView.LogIn(testUser.Username, testUser.Password);

        //    mainView.IsPresented();

        //    int inboxMessages = mainView.GetInboxMessagesCount();

        //    mainView.ComposeButton.Click();
        //    composeView.ToTextbox.Enter(testUser.Username);
        //    composeView.SubjectTextbox.Enter("test subject");
        //    composeView.BodyTextbox.Enter("test body");
        //    composeView.SendButton.Click();

        //    mainView.InboxLabel.Click();

        //    mainView.VerifyInboxMessagesCount(inboxMessages + 1);
        //}

    }
}