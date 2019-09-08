using OpenQA.Selenium;

namespace admin_panel_page_object
{
    public class PageObject
    {
        private IWebDriver _driver;

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
    
        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}