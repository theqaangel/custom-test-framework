using System;
using System.Linq;
using CustomTestFramework.Core.Controls.Interfaces;

namespace CustomTestFramework.Core.Controls.Implementation
{
    /// <summary>
    /// The class for Static Text control
    /// </summary>
    public class StaticText : Control, IStaticText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextBox"/> class.
        /// </summary>
        /// <param name="descriptiveName">The descriptive name of the control.</param>
        /// <param name="properties">The search expression properties.</param>
        public StaticText(string descriptiveName, params string[] properties)
            : base(descriptiveName, properties)
        {
        }
    }
}
