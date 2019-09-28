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

        [Test]
        public void GoToDbPage_WhenCalled_ButtonIsClickedNewPageAppears()
        {
            var expectedUrl = "http://thedemosite.co.uk/thedatabase.php";
            _mainPage.Open();
            Thread.Sleep(2000);
            var dbPage = _mainPage.GoToDbPage();
            
            Assert.AreEqual(expectedUrl, dbPage.Url);
        }
        
        [Test]
        public void GoToAddAUserPage_WhenCalled_ButtonIsClickedNewPageAppears()
        {
            var expectedUrl = "http://thedemosite.co.uk/addauser.php";
            _mainPage.Open();
            Thread.Sleep(2000);
            var dbPage = _mainPage.GoToAddAUserPage();
            
            Assert.AreEqual(expectedUrl, dbPage.Url);
        }
        
        [Test]
        public void GoToGetYourDbOnlinePage_WhenCalled_ButtonIsClickedNewPageAppears()
        {
            var expectedUrl = "http://thedemosite.co.uk/getyourowndbonline.php";
            _mainPage.Open();
            Thread.Sleep(2000);
            var dbPage = _mainPage.GoToGetYourDbOnlinePage();
            
            Assert.AreEqual(expectedUrl, dbPage.Url);
        }
        
        [TearDown]
        public void Teardown()
        {
            _mainPage.Dispose();
        }
    }
}