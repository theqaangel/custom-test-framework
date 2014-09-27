using System;
using System.Linq;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.jQuery;
using CustomTestFramework.Core.Controls.Interfaces;
using CustomTestFramework.Core.Reporting;

namespace CustomTestFramework.Core.Controls.Implementation
{
    /// <summary>
    /// The class for TextBox control
    /// </summary>
    public class TextBox : Control, ITextBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextBox"/> class.
        /// </summary>
        /// <param name="descriptiveName">The descriptive name of the control.</param>
        /// <param name="properties">The search expression properties.</param>
        public TextBox(string descriptiveName, params string[] properties)
            : base(descriptiveName, properties)
        {
        }

        public void Enter(string text, params jQueryControl.jQueryControlEvents[] events)
        {
            Enter(text);
            foreach (jQueryControl.jQueryControlEvents evt in events)
            {
                this.WebControl.AsjQueryControl().InvokejQueryEvent(evt);
            }
        }

        /// <summary>
        /// Enters the specified text.
        /// </summary>
        public void Enter(string text)
        {
            Manager.Current.ActiveBrowser.Actions.SetText(this.WebControl, text);
            Report.Info(this.DescriptiveName + " text is set to: " + text);
        }

        /// <summary>
        /// Gets the text of the control.
        /// </summary>
        public string GetText()
        {
            string result = this.WebControl.AsjQueryControl().val;
            Report.Info(this.DescriptiveName + " text is: " + result);
            return result;
        }
    }
}
