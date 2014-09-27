using System;
using System.Linq;

namespace CustomTestFramework.Core.Controls.Interfaces
{
    /// <summary>
    /// Defines the interface for the checkbox control
    /// </summary>
    public interface ICheckBox : IControl
    {
        /// <summary>
        /// Determines whether this control is checked.
        /// </summary>
        /// <returns>true if the control is checked, false otherwise</returns>
        bool IsChecked();

        /// <summary>
        /// Checks this control.
        /// </summary>
        void Check();

        /// <summary>
        /// Unchecks this control.
        /// </summary>
        void UnCheck();
    }
}
