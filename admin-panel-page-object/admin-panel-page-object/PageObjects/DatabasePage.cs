using OpenQA.Selenium;

namespace admin_panel_page_object
{
    public class DatabasePage : PageObject
    {
        private string _addDbPageUrl;

        public DatabasePage(IWebDriver driver) : base(driver)
        {
            _addDbPageUrl = "http://thedemosite.co.uk/thedatabase.php";
        }

        public void Open()
        {
            OpenPage(_addDbPageUrl);
        }
    }
}