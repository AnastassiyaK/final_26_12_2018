using Business;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.LogInTests
{
    class LogInTests
    {
        [SetUp]
        public void StartUpUrl()
        {
            DriverFactory.InitBrowser("Chrome");
            LoginPageObject loginpage = new LoginPageObject();
            loginpage.GoToPage();
        }
        public void LogIn()
        {
            LoginPageObject loginpage = new LoginPageObject();
            string login = "tweet2_test";
            string password = "selenium";
            loginpage.LogIn(login, password);
        }
        public bool CheckIfLogged()
        {
            MainPagePageObject main = new MainPagePageObject();
            return main.CheckIfLogged();
        }
        [Test(Description = "Entering with valid creds")]
        [Order(1)]
        public void EnterWithCorrectCredentials()
        {
            LogIn();
            //MainPagePageObject main = new MainPagePageObject();
            Assert.That(CheckIfLogged(), Is.True);
        }
        [Test(Description = "Entering with invalid creds")]
        [Order(2)]
        public void EnterWithInvalidCredentials()
        {
            LoginPageObject loginpage = new LoginPageObject();
            string login = "tweet2_test1";
            string password = "selenium1";
            loginpage.LogIn(login, password);
            Assert.That(loginpage.AllertIsVisible, Is.True);
        }

        [Test(Description = "Closing all tabs with tweeter")]
        [Order(3)]
        public void ReopenTweeterTab()
        {
            LogIn();
            DriverFactory.ReopenTweeter();
            LoginPageObject loginpage = new LoginPageObject();
            loginpage.GoToPage();
            // LogIn();
            Assert.That(CheckIfLogged(), Is.True);

        }
        [TearDown]
        public void CloseBrowser()
        {
            DriverFactory.CloseAllDrivers();
        }
    }
}
