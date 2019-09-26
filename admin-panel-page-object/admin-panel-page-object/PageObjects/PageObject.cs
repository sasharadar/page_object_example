using System;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;
using OpenQA.Selenium;

namespace admin_panel_page_object
{
    public class PageObject
    {
        private IWebDriver _driver;
        private string _parentWindowHandler;
        private IAlert _alert;

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
            return Contains(pageText, message);
        }

        public void SwitchToAlert()
        {
            _alert = _driver.SwitchTo().Alert();
        }

        public bool AlertContainsPhrase(string message)
        {
            if (_alert == null)
            {
                throw new NullReferenceException();
            }
            
            var text = _alert.Text;
            return Contains(text, message);
        }

        public void AcceptAlert()
        {
            _alert.Accept();
        }

        public string ExtractTextFromPageCode(string left, string right)
        {
            var pageText = _driver.PageSource;
            var regPattern = $@"{left}(\w+){right}";
            var match = new Regex(regPattern, RegexOptions.Multiline).Match(pageText);
            
            if (match.Groups.Count < 2)
            {
                throw new Exception("Can't find text in the Page Text!");
            }
            
            return match.Groups[1].Value; 
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

        private bool Contains(string text, string search)
        {
            var regPattern = string.Join(@".{1,10}", search.Split(' '));
            return new Regex(regPattern, RegexOptions.Multiline).IsMatch(text); 
        }
        
    
        public void Dispose()
        {
            _driver.Dispose();
        }

    }
}