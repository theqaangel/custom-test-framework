using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using CustomTestFramework.Core.Attributes;
using CustomTestFramework.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomTestFramework.Core
{
    [TestClass]
    public class BaseTestCase
    {
        private string url;
        protected TestUser testUser;

        public TestContext TestContext { set; get; }

        //Views
        protected MainView mainView;
        protected LoginView loginView;
        protected ComposeView composeView;

        public BaseTestCase()
        {
            InitEntryPoint();
            InitViews();
            testUser = new TestUser();
        }

        private void InitEntryPoint()
        {
            this.url = GetEntryPointUrl(this.GetType());
        }

        private void InitViews()
        {
            mainView = new MainView();
            loginView = new LoginView();
            composeView = new ComposeView();
        }

        private string GetEntryPointUrl(MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException("memberInfo");
            }

            var entryPointAttribute = memberInfo.GetCustomAttribute<EntryPointAttribute>(true);
            if (entryPointAttribute != null)
            {
                return entryPointAttribute.Url;
            }
            return null;
        }

        [TestInitialize]
        public void BeforeEach()
        {
            var memberInfo = this.GetType().GetMethod(TestContext.TestName);
            var methodEntryPoint = GetEntryPointUrl(memberInfo);
            if (methodEntryPoint != null)
            {
                this.url = methodEntryPoint;
            }

            CustomTestContext.Instance.TCTimer = new Stopwatch();
            CustomTestContext.Instance.TCTimer.Start();

            //Stop Debug Trace
            Debug.Close();
            
            RunnerHelper.Run(this.url);
        }

        [TestCleanup]
        public void AfterEach()
        {
            if (CustomTestContext.Instance.TestManager != null)
            {
                CustomTestContext.Instance.TestManager.Dispose();
                CustomTestContext.Instance.IsRunning = false; 
            }
            
            foreach (Process proc in Process.GetProcessesByName("iexplore"))
            {
                proc.Kill();
            }

            CustomTestContext.Instance.TCTimer.Reset();
        }
    }
}