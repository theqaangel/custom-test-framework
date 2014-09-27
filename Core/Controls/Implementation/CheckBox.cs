using System;
using System.Linq;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.jQuery;
using CustomTestFramework.Core.Controls.Interfaces;
using CustomTestFramework.Core.Reporting;

namespace CustomTestFramework.Core.Controls.Implementation
{
    /// <summary>
    /// The class for CheckBox control
    /// </summary>
    public class CheckBox : Control, ICheckBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBox"/> class.
        /// </summary>
        /// <param name="descriptiveName">The descriptive name of the control.</param>
        /// <param name="properties">The search expression properties.</param>
        public CheckBox(string descriptiveName, params string[] properties)
            : base(descriptiveName, properties)
        {
        }

        /// <summary>
        /// Determines whether this control is checked.
        /// </summary>
        /// <returns>
        /// true if the control is checked, false otherwise
        /// </returns>
        public bool IsChecked()
        {
            HtmlInputCheckBox checkBox = this.WebElement.As<HtmlInputCheckBox>();
            bool isChecked = checkBox.Checked;
            Report.Info(this.DescriptiveName + (isChecked ? " is checked " : " is NOT checked "));
            return isChecked;
        }

        /// <summary>
        /// Checks this control.
        /// </summary>
        public void Check()
        {
            HtmlInputCheckBox checkBox = this.WebElement.As<HtmlInputCheckBox>();
            checkBox.Check(true, true);
            Report.Info(this.DescriptiveName + " is checked ");
        }

        /// <summary>
        /// Unchecks this control.
        /// </summary>
        public void UnCheck()
        {
            HtmlInputCheckBox checkBox = this.WebElement.As<HtmlInputCheckBox>();
            checkBox.Check(false, true);
            Report.Info(this.DescriptiveName + " is unchecked ");
        }
    }
}