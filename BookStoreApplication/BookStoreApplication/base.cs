using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BookStoreApplication
{
    internal class Base_BookStore
    {
        public IWebDriver Driver;
        
        public Base_BookStore(string url)
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(url);
        }

        ~Base_BookStore()
        {
            Driver.Close();
            Driver.Quit();

        }

    }
}
