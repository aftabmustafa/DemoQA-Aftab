using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace BookStoreApplication
{
    class Login
    {
        static void Main(string[] args)
        {
            string username = "aria";
            string password = "@riaLabel2022";

            IWebDriver Driver = new ChromeDriver();

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/login");

            Thread.Sleep(3000);

            UserLogin(Driver, username, password);

            RedirectBookStore(Driver);

            Driver.Close();
            Driver.Quit();
        }

        static void UserLogin(IWebDriver driver, string uName, string pass)
        {
            driver.FindElement(By.Id("userName")).SendKeys(uName);
            driver.FindElement(By.Id("password")).SendKeys(pass);

            Thread.Sleep(1000);

            driver.FindElement(By.Id("login")).Click();
            Thread.Sleep(2500);
        }

        static void RedirectBookStore(IWebDriver driver)
        {
            new BookStore().Home(driver);
        }
    }
}
