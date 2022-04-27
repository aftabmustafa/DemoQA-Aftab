using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace _4.WebTables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/webtables");

            Thread.Sleep(2000);

            SearchQuery(Driver);

            Thread.Sleep(2000);

            AddQuery(Driver);

            Thread.Sleep(2000);

            EditRecord(Driver);

            Thread.Sleep(2000);

            DeleteRecord(Driver);

            Thread.Sleep(5000);

            Driver.Close();
            Driver.Quit();
        }

        static void AddQuery(IWebDriver driver)
        {
            string fName = "A";
            string lName = "Mustafa";
            string email = "email@gmail.com";
            string dept = "Tester";
            string age = "21";
            string salary = "500000000";

            driver.FindElement(By.Id("addNewRecordButton")).Click();

            Thread.Sleep(1000);

            driver.FindElement(By.Id("firstName")).SendKeys(fName);
            Thread.Sleep(2000);
            driver.FindElement(By.Id("lastName")).SendKeys(lName);
            Thread.Sleep(2000);
            driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Thread.Sleep(2000);
            driver.FindElement(By.Id("age")).SendKeys(age);
            Thread.Sleep(2000);
            driver.FindElement(By.Id("salary")).SendKeys(salary);
            Thread.Sleep(2000);
            driver.FindElement(By.Id("department")).SendKeys(dept);
            Thread.Sleep(2000);

            driver.FindElement(By.Id("submit")).Click();

        }

        static void SearchQuery(IWebDriver driver)
        {
            IWebElement searchBox = driver.FindElement(By.Id("searchBox"));
            searchBox.SendKeys("Cierra");

            Thread.Sleep(3000);

            searchBox.Clear();

            // !!!Temporary fix
            searchBox.SendKeys("a");
        }

        static void EditRecord(IWebDriver driver)
        {
            driver.FindElement(By.Id("edit-record-4")).Click();

            Thread.Sleep(2000);

            driver.FindElement(By.Id("firstName")).Clear();
            driver.FindElement(By.Id("firstName")).SendKeys("Aftab");

            Thread.Sleep(2000);

            driver.FindElement(By.Id("submit")).Click();
        }

        static void DeleteRecord(IWebDriver driver)
        {
            driver.FindElement(By.Id("delete-record-4")).Click();
        }
    }
}
