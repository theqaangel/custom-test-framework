using System;
using System.Configuration;
using System.Linq;

namespace CustomTestFramework.Core
{
    public class TestUser
    {
        public TestUser()
        {
            this.Username = ConfigurationManager.AppSettings["username"];
            this.Password = ConfigurationManager.AppSettings["password"];
        }

        public string Username { set; get; }

        public string Password { set; get; }

    }
}
