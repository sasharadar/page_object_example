using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace admin_panel_page_object
{
    public class PageObject
    {
        private IWebDriver _driver;
        private string _parentWindowHandler;

        public string Url
        {
            get
            {
                return _driver.Url;
            }
        }

        public PageObject(IWebDriver driver)
        {
            _driver = driver;
        }
    
        public void OpenPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public IWebElement FindElement(By by)
        {
            return _driver.FindElement(by);
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }
        
        public bool PageContainsPhrase(string message)
        {
            var pageText = _driver.PageSource;
            var regPattern = string.Join(@".{1,10}", message.Split(' '));
            return new Regex(regPattern, RegexOptions.Multiline).IsMatch(pageText);
        }

        public void SwitchToAlert()
        {
            var alert = _driver.SwitchTo().Alert();
            var text = alert.Text;
        }

        public void SwitchToPopup()
        {
            _parentWindowHandler = _driver.CurrentWindowHandle; // Store your parent window
            var subWindowHandler = "";

            var handles = _driver.WindowHandles; // get all window handles
            foreach (var handle in handles)
            {
                subWindowHandler = handle;
            }

            _driver.SwitchTo().Window(subWindowHandler); // switch to popup window
        }

        public void SwitchToMain()
        {
            if (_parentWindowHandler == null)
            {
                throw new NullReferenceException();
            }
            
            _driver.SwitchTo().Window(_parentWindowHandler); // switch back to parent window

        }
        
    
        public void Dispose()
        {
            _driver.Dispose();
        }

    }
}