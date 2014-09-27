using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomTestFramework.Core.Reporting
{
    public class Report
    {
        public static void Error(string text)
        {
            text = "FAULT:\t" + text;
            Write(GetTimestamp() + "\t" + text + " :(");
            Assert.Fail();
        }

        public static void Pass(string text)
        {
            text = "PASS:\t" + text;
            Write(GetTimestamp() + "\t" + text + " :)");
        }

        public static void Info(string text)
        {
            text = "I:\t" + text;
            Write(GetTimestamp() + "\t" + text + " :|");
        }

        private static string GetTimestamp()
        {
            TimeSpan timespan = TimeSpan.FromMilliseconds(CustomTestContext.Instance.TCTimer.ElapsedMilliseconds);
            return timespan.ToString();
        }

        private static void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}