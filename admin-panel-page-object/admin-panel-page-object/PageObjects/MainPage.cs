using System;
using OpenQA.Selenium;

namespace admin_panel_page_object
{
    public class MainPage : PageObject
    {
        private string _mainPageUrl;
        
        public MainPage(IWebDriver driver) : base(driver)
        {
            _mainPageUrl = "http://thedemosite.co.uk";
        }
        
        public void Open()
        {
            OpenPage(_mainPageUrl);
        }

        public LoginPage GoToLoginPage()
        {
            var loginButton = FindElement(By.XPath("//*[@href='login.php']"));
            loginButton.Click();
            
            return new LoginPage(GetDriver());
        }
    }
}