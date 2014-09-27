using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomTestFramework.Core.Controls.Interfaces
{
    /// <summary>
    /// Defines the base interface for controls, which are components with visual representation.
    /// </summary>
    public interface IControl
    {
        /// <summary>
        /// Clicks this control.
        /// </summary>
        void Click();

        /// <summary>
        /// Determines whether this control is enabled.
        /// </summary>
        /// <returns></returns>
        bool IsEnabled();

        /// <summary>
        /// Determines whether this control is visible.
        /// </summary>
        /// <returns></returns>
        bool IsVisible();

        /// <summary>
        /// Gets or sets the descriptive name.
        /// </summary>
        /// <value>The name of the control.</value>
        string DescriptiveName { get; set; }

        /// <summary>
        /// Gets the text content of the control
        /// </summary>
        string TextContent { get; }

        /// <summary>
        /// Gets the parent control
        /// </summary>
        IControl Parent { get; }

        /// <summary>
        /// Gets the child controls
        /// </summary>
        IList<IControl> ChildControls { get; }
    }
}
