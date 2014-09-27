using System;
using System.Linq;
using ArtOfTest.WebAii.Core;
using CustomTestFramework.Core.Controls.Interfaces;
using CustomTestFramework.Core.Reporting;

namespace CustomTestFramework.Core.Controls.Implementation
{
    /// <summary>
    /// The class for ComboBox control
    /// </summary>
    public class ComboBox : Control, IComboBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        /// <param name="descriptiveName">The descriptive name of the control.</param>
        /// <param name="properties">The search expression properties.</param>
        public ComboBox(string descriptiveName, params string[] properties) : base(descriptiveName, properties)
        {
        }

        /// <summary>
        /// Selects the specified option id.
        /// </summary>
        /// <param name="optionId">The option id.</param>
        public void Select(int optionId)
        {
            Manager.Current.ActiveBrowser.Actions.SelectDropDown(this.WebElement, optionId);
            Report.Info("Option number " + optionId + " is selected in " + this.DescriptiveName);
        }

        /// <summary>
        /// Selects the specified option.
        /// </summary>
        /// <param name="option">The option.</param>
        public void Select(string option)
        {
            Manager.Current.ActiveBrowser.Actions.SelectDropDown(this.WebElement, option);
            Report.Info("Option " + option + " is selected in " + this.DescriptiveName);
        }

        /// <summary>
        /// Gets the selected option.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetSelected()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
