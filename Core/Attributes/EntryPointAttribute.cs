using System;
using System.Linq;

namespace CustomTestFramework.Core.Attributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class EntryPointAttribute : Attribute
    {
        public string Url;

        public EntryPointAttribute(string url)
        {
            this.Url = url;
        }
    }
}