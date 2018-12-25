using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class LoginPageObject
    {
        private readonly ClassLogger log = new ClassLogger();
        private const string Url = "https://twitter.com/login";
        private const string LoginInput = "//input[@class='js-username-field email-input js-initial-focus']";
        private const string PasswordInput = "//input[@class='js-password-field']";
        private const string ButtonLogIn = "//button[contains(@class,'submit')]";
        private const string allertlogin = "(//div[@id='message-drawer']//span)[1]";
        [FindsBy(How = How.XPath, Using = LoginInput)]
        private IWebElement inputLogin { get; set; }

        [FindsBy(How = How.XPath, Using = PasswordInput)]
        private IWebElement inputPassword { get; set; }

        [FindsBy(How = How.XPath, Using = ButtonLogIn)]
        private IWebElement btnLogIn { get; set; }
        [FindsBy(How = How.XPath, Using = allertlogin)]
        private IWebElement allertincorrectcreds { get; set; }
        

        public LoginPageObject()
        {
            PageFactory.InitElements(DriverFactory.Driver, this);
        }

        public MainPagePageObject LogIn(string username, string password)
        {
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            btnLogIn.Click();
            log.LogBebug($"Username:{username},Password:{password} were entered");
            log.LogBebug("Button 'LogIn' was pressed");
            return new MainPagePageObject();
        }
        public void GoToPage()
        {
            DriverFactory.Driver.Navigate().GoToUrl(Url);
        }
        public bool AllertIsVisible()
        {
            log.LogBebug($"Message : '{allertincorrectcreds.Text}' is shown.User is not logged in");
           return allertincorrectcreds.Displayed;
        }
        public bool LogInIsVisible()
        {
            log.LogBebug("User is signed out.");
            return inputLogin.Displayed && inputPassword.Displayed && btnLogIn.Displayed;
        }
    }
}
