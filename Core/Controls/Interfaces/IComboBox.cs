using System;
using System.Linq;

namespace CustomTestFramework.Core.Controls.Interfaces
{
    /// <summary>
    /// Defines the interface for the combobox control
    /// </summary>
    public interface IComboBox : IControl
    {
        /// <summary>
        /// Selects the specified option id.
        /// </summary>
        /// <param name="optionId">The option id.</param>
        void Select(int optionId);

        /// <summary>
        /// Selects the specified option.
        /// </summary>
        /// <param name="option">The option.</param>
        void Select(string option);

        /// <summary>
        /// Gets the selected option.
        /// </summary>
        /// <returns></returns>
        string GetSelected();
    }
}
