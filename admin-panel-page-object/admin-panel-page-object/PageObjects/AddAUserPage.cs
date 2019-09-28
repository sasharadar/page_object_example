using OpenQA.Selenium;

namespace admin_panel_page_object
{
    public class AddAUserPage : PageObject
    {
        private string _addAUserPageUrl;

        public AddAUserPage(IWebDriver driver) : base(driver)
        {
            _addAUserPageUrl = "http://thedemosite.co.uk/addauser.php";
        }

        public void Open()
        {
            OpenPage(_addAUserPageUrl);
        }
        
        public string GetExistingUsername()
        {
            return ExtractTextFromPageCode(@"The username.{1,10}\s", "<br>");
        }
        
        public string GetExistingPassword()
        {
            return ExtractTextFromPageCode(@"The password.{1,10}\s", "<br>");
        }

        public void CreateNewUser(string login, string password)
        {
            var loginField = FindElement(By.XPath("//*[@name='username']"));
            var passwordField = FindElement(By.XPath("//*[@name='password']"));
            var saveButton = FindElement(By.XPath("//*[@name='FormsButton2']"));
        
            loginField.SendKeys(login);
            passwordField.SendKeys(password);
            saveButton.Click();
        }
    }
}