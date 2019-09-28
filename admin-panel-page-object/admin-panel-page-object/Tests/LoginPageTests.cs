using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace admin_panel_page_object
{
    [TestFixture]
    public class LoginPageTests
    {
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage(new ChromeDriver());
        }
        
        [Test]
        public void Open_WhenCalled_PageIsOpened()
        {
                var expectedUrl = "http://thedemosite.co.uk/login.php";
            _loginPage.Open();
            
            Assert.AreEqual(expectedUrl, _loginPage.Url);
        }

        [Test]
        public void Login_UseExistingCreds_Success()
        {
            var username = _loginPage.GetExistingLogin();
            var password = _loginPage.GetExistingPassword();
            
            _loginPage.Open();
            _loginPage.InputCredits(username, password);
            _loginPage.ClickLogin();

            Assert.IsTrue(_loginPage.IsLoginSuccess());
        }

        [Test]
        public void Login_EmptyLogin_ReturnAlert()
        {
            _loginPage.Open();
            _loginPage.InputCredits("", "test");
            _loginPage.ClickLogin();
            _loginPage.SwitchToAlert();
            
            Assert.IsTrue(_loginPage.AlertContainsPhrase("Username too short"));
        }

        [Test]
        public void Login_EmptyPassword_ReturnAlert()
        {
            _loginPage.Open();
            _loginPage.InputCredits("test", "");
            _loginPage.ClickLogin();
            _loginPage.SwitchToAlert();
            
            Assert.IsTrue(_loginPage.AlertContainsPhrase("Password too short"));
        }

        [Test]
        public void Login_AcceptAlert_ReturnToThePage()
        {
            _loginPage.Open();
            _loginPage.InputCredits("", "");
            _loginPage.ClickLogin();
            _loginPage.SwitchToAlert();
            _loginPage.AcceptAlert();
            _loginPage.InputCredits("check", "check");
        }

        [Test]
        public void Login_WrongCreds_ShowMessage()
        {
            _loginPage.Open();
            _loginPage.InputCredits("unregistereduser", "test");
            _loginPage.ClickLogin();

            Assert.IsFalse(_loginPage.IsLoginSuccess());
        }
        
        [TearDown]
        public void Teardown()
        {
            _loginPage.Dispose();
        }
    }
}