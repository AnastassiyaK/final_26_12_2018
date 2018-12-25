using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class DriverFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    {
                        driver = new ChromeDriver();
                       
                            Drivers.Add("Chrome", Driver);
                        
                    }
                    break;

            }
        }

        public static void ReopenTweeter()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.First());

            int tabs = driver.WindowHandles.Count();
            for (int i = 1; i <= tabs; i++)
            {
                if (i != tabs)
                {
                    driver.Close();
                }
                else
                {
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    //driver.Navigate().GoToUrl("http://www.google.com");
                }
            }
        }
        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                //Drivers[key].Close();
                Drivers[key].Quit();
            }
            Drivers.Clear();
        }
    }
}
