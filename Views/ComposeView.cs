using System;
using System.Linq;
using CustomTestFramework.Core.Controls;
using CustomTestFramework.Core.Controls.Implementation;
using CustomTestFramework.Core.Controls.Interfaces;

namespace CustomTestFramework.Views
{
    public class ComposeView : AutomationView
    {

        public ITextBox ToTextbox
        {
            get
            {
                return new TextBox("To textbox", By.Name("to"));
            }
        }

        public ITextBox SubjectTextbox
        {
            get
            {
                return new TextBox("Subject textbox", By.Name("subjectbox"));
            }
        }

        public ITextBox BodyTextbox
        {
            get
            {
                return new TextBox("Body textbox", By.ClassName("Am Al editable LW-avf"));
            }
        }

        public IButton SendButton
        {
            get
            {
                return new Button("Send button", By.ClassName("T-I J-J5-Ji aoO T-I-atl L3"));
            }
        }
    }
}
