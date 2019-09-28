using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace admin_panel_page_object
{
    [TestFixture]
    public class AddAUserPageTests
    {
        private AddAUserPage _addAUserPage;

        [SetUp]
        public void Setup()
        {
            _addAUserPage = new AddAUserPage(new ChromeDriver());
        }

        [Test]
        public void Open_WhenCalled_PageIsOpened()
        {
            var expectedUrl = "http://thedemosite.co.uk/addauser.php";
            _addAUserPage.Open();
            
            Assert.AreEqual(expectedUrl, _addAUserPage.Url);
        }
        
        [Test]
        [TestCase("testlogin","password")]
        [TestCase("CAPSLOCK","UPPER")]
        public void AddUser_WhenCall_UserCredentialsOnThePage(string login, string password)
        {
            _addAUserPage.Open();
            _addAUserPage.CreateNewUser(login, password);

            var loginFromPage = _addAUserPage.GetExistingUsername();
            var passwordFromPage = _addAUserPage.GetExistingPassword();
            
            Assert.AreEqual(login, loginFromPage);
            Assert.AreEqual(password, passwordFromPage);
        }

        [Test]
        [TestCase("testlogin","password")]
        [TestCase("CAPSLOCK","UPPER")]
        public void AddUser_WhenCall_UserCouldBeUsedForLogin(string login, string password)
        {
            _addAUserPage.Open();
            _addAUserPage.CreateNewUser(login, password);

            var loginPage = new LoginPage(_addAUserPage.GetDriver());
            loginPage.Open();
            loginPage.InputCredits(login, password);
            loginPage.ClickLogin();
            
            Assert.IsTrue(loginPage.IsLoginSuccess());
        }

        [Test]
        public void Login_EmptyLogin_ReturnAlert()
        {
            _addAUserPage.Open();
            _addAUserPage.CreateNewUser("", "password");
            _addAUserPage.SwitchToAlert();
            
            Assert.IsTrue(_addAUserPage.AlertContainsPhrase("Username too short"));
        }

        [Test]
        public void Login_EmptyPassword_ReturnAlert()
        {
            _addAUserPage.Open();
            _addAUserPage.CreateNewUser("login", "");
            _addAUserPage.SwitchToAlert();
            
            Assert.IsTrue(_addAUserPage.AlertContainsPhrase("Password too short"));
        }
        
        [TearDown]
        public void Teardown()
        {
            _addAUserPage.Dispose();
        }
    }
}