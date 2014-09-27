using System;
using System.Linq;

namespace CustomTestFramework.Core.Controls
{
    /// <summary>
    /// This class simplifies the usage of test studio search expression strings
    /// </summary>
    public class By
    {
        /// <summary>
        /// Gets the search expression string by id
        /// </summary>
        public static string Id(string id)
        {
            return ("id=" + id);
        }

        /// <summary>
        /// Gets the search expression string by value
        /// </summary>
        public static string Value(string value)
        {
            return ("value=" + value);
        }

        /// <summary>
        /// Gets the search expression string by class that contains the specified className
        /// </summary>
        public static string ClassName(string className)
        {
            string value = className.Replace("~","");
            return ("class=~" + value);
        }

        /// <summary>
        /// Gets the search expression string by data-bind attribute that contains the specified dataBind
        /// </summary>
        public static string DataBind(string dataBind)
        {
            string value = dataBind.Replace("~", "");
            return ("data-bind=~" + value);
        }

        /// <summary>
        /// Gets the search expression string by name attribute
        /// </summary>
        public static string Name(string name)
        {
            return ("name=" + name);
        }

        /// <summary>
        /// Gets the search expression string by title attribute
        /// </summary>
        public static string Title(string title)
        {
            return ("title=" + title);
        }

        /// <summary>
        /// Gets the search expression string by type attribute
        /// </summary>
        public static string Type(string type)
        {
            return ("type=" + type);
        }

        /// <summary>
        /// Gets the search expression string by inner text
        /// </summary>
        public static string InnerText(string innerText)
        {
            return ("InnerText=" + innerText);
        }

    }
}
