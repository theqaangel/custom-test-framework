using System;
using System.Linq;
using CustomTestFramework.Core.Controls.Interfaces;
using CustomTestFramework.Core.Reporting;

namespace CustomTestFramework.Core.Controls.Implementation
{
    /// <summary>
    /// 
    /// </summary>
    public class Button : Control, IButton
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="descriptiveName">Name of the descriptive.</param>
        /// <param name="properties">The properties.</param>
        public Button(string descriptiveName, params string[] properties)
            : base(descriptiveName, properties)
        {
        }

        /// <summary>
        /// Gets the title of the button.
        /// </summary>
        public string GetTitle()
        {
            string result = this.WebElement.TextContent;
            Report.Info(this.DescriptiveName + " title text is: " + result);

            return result;
        }
    }
}