using OpenQA.Selenium;

namespace admin_panel_page_object
{
    public class LoginPage : PageObject
    {
        private string _loginPageUrl;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            _loginPageUrl = "http://thedemosite.co.uk/login.php";
        }

        public void InputCredits(string login, string password)
        {
            var loginField = FindElement(By.XPath("//*[@name='username']"));
            var passwordField = FindElement(By.XPath("//*[@name='password']"));

            loginField.SendKeys(login);
            passwordField.SendKeys(password);
        }

        public void ClickLogin()
        {
            var loginButton = FindElement(By.XPath("//*[@name='FormsButton2']"));
            loginButton.Click();
        }

        public void Open()
        {
            OpenPage(_loginPageUrl);
        }

        public bool IsLoginSuccess()
        {
            return PageContainsPhrase("Successful Login");
        }
    }
}