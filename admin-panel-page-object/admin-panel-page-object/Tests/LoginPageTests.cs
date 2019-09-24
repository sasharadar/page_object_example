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
            _loginPage.Open();
            _loginPage.InputCredits("test", "test");
            _loginPage.ClickLogin();

            Assert.IsTrue(_loginPage.IsLoginSuccess());
        }

        [Test]
        public void Login_EmptyLogin_ReturnError()
        {
            
        }

        [Test]
        public void Login_EmptyPassword_ReturnError()
        {
            
        }

        [Test]
        public void Login_WrongCreds_ReturnError()
        {
            
        }
        
        [TearDown]
        public void Teardown()
        {
            _loginPage.Dispose();
        }
    }
}