using System;
using System.Linq;

namespace CustomTestFramework.Core.Controls.Interfaces
{
    /// <summary>
    /// Defines the interface for the button control
    /// </summary>
    public interface IButton : IControl
    {
        /// <summary>
        /// Gets the title of the button.
        /// </summary>
        string GetTitle();
    }
}
