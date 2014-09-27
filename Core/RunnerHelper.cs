using System;
using System.Configuration;
using System.Linq;
using ArtOfTest.WebAii.Core;
using CustomTestFramework.Core.Reporting;

namespace CustomTestFramework.Core
{
    public class RunnerHelper
    {
        public static void Run(string url)
        {
            Settings settings = new Settings();
            try
            {
                settings.ElementWaitTimeout = Int32.Parse(ConfigurationManager.AppSettings["elementWaitTimeout"]);
                settings.XMultiMgr = Boolean.Parse(ConfigurationManager.AppSettings["xMultiMgr"]);
                settings.UnexpectedDialogAction = ParseUnexpectedDialogAction(ConfigurationManager.AppSettings["unexpectedDialogAction"]);
                settings.CreateLogFile = Boolean.Parse(ConfigurationManager.AppSettings["createLogFile"]);
                settings.WaitCheckInterval = Int32.Parse(ConfigurationManager.AppSettings["waitCheckInterval"]);
                settings.LogAnnotations = Boolean.Parse(ConfigurationManager.AppSettings["logAnnotations"]);
                settings.AnnotationMode = ParseAnnotationMode(ConfigurationManager.AppSettings["annotationMode"]);
                settings.AnnotateExecution = Boolean.Parse(ConfigurationManager.AppSettings["annotateExecution"]);
                settings.ExecutionDelay = Int32.Parse(ConfigurationManager.AppSettings["executionDelay"]);
                settings.QueryEventLogErrorsOnExit = Boolean.Parse(ConfigurationManager.AppSettings["queryEventLogErrorsOnExit"]);
                settings.ClientReadyTimeout = Int32.Parse(ConfigurationManager.AppSettings["clientReadyTimeout"]);
                settings.ExecuteCommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["executionTimeout"]);
            }
            catch (Exception ex)
            {
                Report.Error(ex.StackTrace);
            }

            CustomTestContext.Instance.TestManager = new Manager(settings);
            
            CustomTestContext.Instance.TestManager.Start();

            CustomTestContext.Instance.TestManager.LaunchNewBrowser();

            CustomTestContext.Instance.TestBrowser = CustomTestContext.Instance.TestManager.ActiveBrowser;

            CustomTestContext.Instance.TestBrowser.ClearCache(BrowserCacheType.Cookies);

            CustomTestContext.Instance.TestBrowser.NavigateTo(url);

            CustomTestContext.Instance.IsRunning = true;
        }

        private static UnexpectedDialogAction ParseUnexpectedDialogAction(string unexpectedDialogAction)
        {
            switch (unexpectedDialogAction)
            {
                default:
                case "HandleAndFailTest":
                    {
                        return UnexpectedDialogAction.HandleAndFailTest;
                    }

                case "HandleAndContinue":
                    {
                        return UnexpectedDialogAction.HandleAndContinue;
                    }

                case "DoNotHandle":
                    {
                        return UnexpectedDialogAction.DoNotHandle;
                    }
            }
        }

        private static AnnotationMode ParseAnnotationMode(string annotationMode)
        {
            switch (annotationMode)
            {
                default:
                case "All":
                    {
                        return AnnotationMode.All;
                    }

                case "CustomOnly":
                    {
                        return AnnotationMode.CustomOnly;
                    }

                case "NativeOnly":
                    {
                        return AnnotationMode.NativeOnly;
                    }
            }
        }
    }
}