using System;
using System.Linq;
using CustomTestFramework.Core.Controls;
using CustomTestFramework.Core.Controls.Implementation;
using CustomTestFramework.Core.Controls.Interfaces;
using CustomTestFramework.Core.Reporting;

namespace CustomTestFramework.Views
{
    public class LoginView : AutomationView
    {
        public ITextBox EmailTextBox
        {
            get
            {
                return new TextBox("Email textbox", By.Id("Email"));
            }
        }

        public ITextBox PasswdTextBox
        {
            get
            {
                return new TextBox("Passwd textbox", By.Id("Passwd"));
            }
        }

        public IButton SignInButton
        {
            get
            {
                return new Button("Sign In button", By.Id("signIn"));
            }
        }

        public void LogIn(string username, string password)
        {
            try
            {
                this.EmailTextBox.Enter(username);
                this.PasswdTextBox.Enter(password);
                this.SignInButton.Click();
            }
            catch
            {
                Report.Error("Lod In failed");
            }
        }
    }
}
