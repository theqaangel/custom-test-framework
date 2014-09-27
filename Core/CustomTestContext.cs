using System;
using System.Diagnostics;
using System.Linq;
using ArtOfTest.WebAii.Core;

namespace CustomTestFramework.Core
{
    public sealed class CustomTestContext
    {
        private static volatile CustomTestContext instance;
        private static object syncRoot = new Object();

        public CustomTestContext()
        {
        }

        public static CustomTestContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CustomTestContext();
                    }
                }

                return instance;
            }
        }

        public Stopwatch TCTimer { get; set; }

        public bool IsRunning { get; set; }

        public Manager TestManager { get; set; }

        public Browser TestBrowser { get; set; }
    }
}