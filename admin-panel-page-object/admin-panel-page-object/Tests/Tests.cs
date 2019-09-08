using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace admin_panel_page_object
{
    [TestFixture]
    public class MainPageTests
    {
        private MainPage _mainPage;

        [SetUp]
        public void Setup()
        {
            _mainPage = new MainPage(new ChromeDriver());
        }
        
        [Test]
        public void Open_WhenCalled_PageIsOpened()
        {
            var expectedUrl = "http://thedemosite.co.uk/";
            
            _mainPage.Open();
            
            Assert.AreEqual(expectedUrl, _mainPage.Url);
        }

        [Test]
        public void GoToLoginPage_WhenCalled_ButtonIsClickedNewPageAppears()
        {
            var expectedUrl = "http://thedemosite.co.uk/login.php";
            
            _mainPage.Open();
            Thread.Sleep(2000);
            var loginPage = _mainPage.GoToLoginPage();
            
            Assert.AreEqual(expectedUrl, loginPage.Url);
        }

        [TearDown]
        public void Teardown()
        {
            _mainPage.Dispose();
        }
    }

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

        [TearDown]
        public void Teardown()
        {
            _loginPage.Dispose();
        }
    }
}