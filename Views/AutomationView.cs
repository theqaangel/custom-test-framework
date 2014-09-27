using System;
using System.Linq;
using CustomTestFramework.Core.Controls.Interfaces;
using CustomTestFramework.Core.Reporting;

namespace CustomTestFramework.Views
{
    public class AutomationView
    {
        private readonly string name;

        protected AutomationView()
        {
            this.name = this.GetType().Name;
        }

        /// <summary>
        /// Determines whether this instance is presented.
        /// </summary>
        public void IsPresented()
        {
            var type = this.GetType();
            var controls = type.GetProperties()
                               .Where(property => typeof(IControl).IsAssignableFrom(property.PropertyType))
                               .Select(property => property.GetValue(this, null))
                               .Cast<IControl>();

            foreach (var control in controls)
            {
                try
                {
                    if (!control.IsVisible())
                    {
                        Report.Error(name + " is NOT presented. Its control " + control.DescriptiveName + " is not visible.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(name + " is NOT presented. ", ex);
                }
            }
            Report.Pass(name + " is presented.");
        }
    }
}