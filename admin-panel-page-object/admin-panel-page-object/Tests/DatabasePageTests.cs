using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace admin_panel_page_object
{
    [TestFixture]
    public class DatabasePageTests
    {
        private DatabasePage _DbPage;

        [SetUp]
        public void Setup()
        {
            _DbPage = new DatabasePage(new ChromeDriver());    
        }
        
        [Test]
        public void Open_WhenCalled_PageIsOpened()
        {
            var expectedUrl = "http://thedemosite.co.uk/thedatabase.php";
            _DbPage.Open();
            
            Assert.AreEqual(expectedUrl, _DbPage.Url);
        }

        [TearDown]
        public void Teardown()
        {
            _DbPage.Dispose();
        }
    }
}