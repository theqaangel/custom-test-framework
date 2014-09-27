using System;
using System.Linq;
using ArtOfTest.WebAii.jQuery;

namespace CustomTestFramework.Core.Controls.Interfaces
{
    /// <summary>
    /// Defines the interface for the texbox control
    /// </summary>
    public interface ITextBox : IControl
    {
        /// <summary>
        /// Enters the specified text.
        /// </summary>
        void Enter(string text);

        /// <summary>
        /// Enters the specified text.
        /// </summary>
        void Enter(string text, params jQueryControl.jQueryControlEvents[] events);
        
        /// <summary>
        /// Gets the text of the control.
        /// </summary>
        string GetText();
    }
}
