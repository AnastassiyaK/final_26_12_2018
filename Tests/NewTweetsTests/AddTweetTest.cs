using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using OpenQA.Selenium;

namespace Tests
{
    public class AddTweetTest
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
            string login = "testtwe65442526";
            string password = "selenium";
            loginpage.LogIn(login, password);
        }

        [Test]
        [Order(4)]
        public void AddTweet()
        {
            LogIn();
            MainPagePageObject main = new MainPagePageObject();
            main.btnTweetClick();
            string tweet = $"tweet {DateTime.Now}";
            main.EnterText(tweet);
            main.SendTweet();
            WebDriverWait waiter = new WebDriverWait(DriverFactory.Driver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@class,'new-tweets-bar')]")));
            main.SeeTweets();
            Assert.That(tweet, Is.EqualTo(main.GetText()));

        }

        [TearDown]
        public void CloseBrowser()
        {
            DriverFactory.CloseAllDrivers();
        }


    }
}
