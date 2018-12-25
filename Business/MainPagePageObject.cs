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
    public class MainPagePageObject
    {
        private readonly ClassLogger log = new ClassLogger();
        private const string newtweetField = "//div[contains(@*, 'Tweetstorm-tweet-box-0-label')]";
        private const string sendButton = "//div[@id='Tweetstorm-tweet-box-0']/descendant::button[contains(@class,'SendTweetsButton')]";
        private const string newpictureInput = "//div[contains(@id,'Tweetstorm-tweet-box-0')]/descendant::input[@class='file-input js-tooltip']";
        private const string newtweetModal = "//div[contains(@class,'js-new-items-bar-container')]";
        private const string firsttweetpath = "(//div[@class='js-tweet-text-container'])[1]";
        private const string usericon = "//li[@id='user-dropdown']";
        private const string signoutbutton = "//li[@id='signout-button']";
        public MainPagePageObject()
        {
            PageFactory.InitElements(DriverFactory.Driver, this);
        }
        //button to open modal window
        [FindsBy(How = How.Id, Using = "global-new-tweet-button")]
        private IWebElement tweetButton;
        //button to enter text
        [FindsBy(How = How.XPath, Using = newtweetField)]
        private IWebElement textTweet;
        //button to send tweet
        [FindsBy(How = How.XPath, Using = sendButton)]
        private IWebElement sendtweetButton;
        //input to send a pic
        [FindsBy(How = How.XPath, Using = newpictureInput)]
        private IWebElement sendpicInput;
        //[FindsBy(How=How.XPath, Using = newtweetModal)]
        //public By modalButton;
        [FindsBy(How = How.XPath, Using = newtweetModal)]
        public IWebElement modalnewtweetButton;
        //the first tweet
        [FindsBy(How = How.XPath, Using = firsttweetpath)]
        private IWebElement firsttweet;
        [FindsBy(How = How.XPath, Using = usericon)]
        private IWebElement user;
        [FindsBy(How = How.XPath, Using = signoutbutton)]
        private IWebElement usersignout;
        
        public void SeeTweets()
        {
            modalnewtweetButton.Click();
        }
        public void PostPic(string path)
        {
            sendpicInput.SendKeys(path);
        }

        public void btnTweetClick()
        {
            tweetButton.Click();
        }

        public void EnterText(string text)
        {
            log.LogBebug($"Sending tweet with text: {text}");
            textTweet.SendKeys(text);
        }

        public void SendTweet()
        {
            sendtweetButton.Click();
        }
        public string GetText()
        {
            string tweettext = firsttweet.Text;
            log.LogBebug($"Getting text from the first tweet on the page :  {tweettext}");
            return tweettext;
        }
        public void UserClickIcon()
        {
           user.Click();
        }
        public void SignOut()
        {
            usersignout.Click();
        }
        public bool CheckIfLogged()
        {
            if (user.Displayed)
            {
                log.LogBebug("User is logged in");
            }
            else
            {
                log.LogBebug("User is not logged in");
            }
            return user.Displayed;
        }
        
    }
}
