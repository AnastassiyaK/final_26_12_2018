using Business;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.LogOutTests
{
    class LogOutTests
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
        [Test(Description = "LogOut")]
        [Order(5)]
        public void LogOut()
        {
            LogIn();
            MainPagePageObject main = new MainPagePageObject();
            main.UserClickIcon();
            main.SignOut();
            LoginPageObject loginpage = new LoginPageObject();
            loginpage.GoToPage();
            Assert.That(loginpage.LogInIsVisible(), Is.True);
        }
        [TearDown]
        public void CloseBrowser()
        {
            DriverFactory.CloseAllDrivers();
        }
    }
}
