using System;
using System.Collections.Generic;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using CustomTestFramework.Core.Controls.Interfaces;
using CustomTestFramework.Core.Reporting;

namespace CustomTestFramework.Core.Controls.Implementation
{
    /// <summary>
    /// The base class for all html controls
    /// </summary>
    public class Control : IControl
    {
        /// <summary>
        /// Gets or sets the descriptive name.
        /// </summary>
        /// <value>
        /// The name of the control.
        /// </value>
        public string DescriptiveName { get; set; }

        /// <summary>
        /// Gets or sets the web element for the control.
        /// </summary>
        protected Element WebElement { get; set; }

        /// <summary>
        /// Gets or sets the html control for the control.
        /// </summary>
        protected HtmlControl WebControl { get; set; }

        private Control() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Control"/> class.
        /// </summary>
        /// <param name="descriptiveName">The descriptive name of the control.</param>
        /// <param name="properties">The search expression properties.</param>
        public Control(string descriptiveName, params string[] properties)
        {
            this.DescriptiveName = descriptiveName;
            this.WebElement = null;
            if (Manager.Current.ActiveBrowser == null)
            {
                Report.Error("Browser is not started");
            }
            Init(descriptiveName, properties);
        }

        /// <summary>
        /// Gets the text content of the control
        /// </summary>
        public string TextContent
        {
            get
            {
                return this.WebElement.TextContent;
            }
        }

        /// <summary>
        /// Gets the parent control
        /// </summary>
        public IControl Parent
        {
            get
            {
                Control parent = new Control();
                parent.DescriptiveName = string.Format("{0}.Parent", this.DescriptiveName);
                parent.WebElement = this.WebElement.Parent;
                parent.WebControl = parent.WebElement.As<HtmlControl>();
                return parent;
            }
        }

        /// <summary>
        /// Gets the child controls
        /// </summary>
        public IList<IControl> ChildControls
        {
            get
            {
                List<IControl> childControls = new List<IControl>();
                for (int i = 0; i < this.WebElement.ChildNodes.Count; i++)
                {
                    Control c = new Control();
                    c.DescriptiveName = string.Format("{0}_child[{1}]", this.DescriptiveName, i);
                    c.WebElement = this.WebElement.ChildNodes[i];
                    c.WebControl = this.WebElement.ChildNodes[i].As<HtmlControl>();
                    childControls.Add(c);
                }
                return childControls;
            }
        }

        private void Init(string descriptiveName, params string[] properties)
        {
            if (this.WebElement == null)
            {
                try
                {
                    this.WebElement = Manager.Current.ActiveBrowser.WaitForElement(Manager.Current.Settings.ElementWaitTimeout, properties);
                    this.WebControl = this.WebElement.As<HtmlControl>();
                }
                catch (Exception ex)
                {
                    throw new Exception("Web Element " + descriptiveName + " CAN NOT be initialized", ex);
                }
            }
        }

        /// <summary>
        /// Clicks this control.
        /// </summary>
        public void Click()
        {
            if (this.WebControl != null)
            {
                try
                {
                    this.WebControl.Refresh();
                    this.WebControl.Wait.ForVisible();
                    this.WebControl.MouseClick();
                    Report.Info(this.DescriptiveName + " is clicked");
                }
                catch (Exception ex)
                {
                    throw new Exception(this.DescriptiveName + " is NOT clicked with the mouse", ex);
                }
            }
            else
            {
                Report.Error(this.DescriptiveName + " is NOT initialized");
            }
        }

        /// <summary>
        /// Determines whether this control is enabled.
        /// </summary>
        /// <returns>true if enabled, false otherwise</returns>
        public bool IsEnabled()
        {
            bool result = this.WebControl.IsEnabled;
            if (result)
            {
                Report.Info(this.DescriptiveName + " is Enabled");
            }
            else
            {
                Report.Info(this.DescriptiveName + " is Disabled");
            }
            return result;
        }

        /// <summary>
        /// Determines whether this control is visible.
        /// </summary>
        /// <returns>true if visible, false otherwise</returns>
        public bool IsVisible()
        {
            bool result = this.WebControl.IsVisible();
            if (result)
            {
                Report.Info(this.DescriptiveName + " is Visible");
            }
            else
            {
                Report.Info(this.DescriptiveName + " is NOT Visible");
            }
            return result;
        }
    }
}