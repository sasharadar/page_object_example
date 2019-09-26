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
            _addAUserPage.Open();
        }


        [TearDown]
        public void Teardown()
        {
            _addAUserPage.Dispose();
        }
    }
}