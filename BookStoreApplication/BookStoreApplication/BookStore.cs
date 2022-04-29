using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace BookStoreApplication
{
    internal class BookStore
    {
        public void Home(IWebDriver driver)
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://demoqa.com/books");

            SearchBook(driver, "Git");
            AddBook(driver);

            SearchBook(driver, "script");
            AddBook(driver);

            NavigateProfile(driver);

            DeleteBooks(driver);

            Logout(driver);
        }

        private void SearchBook(IWebDriver driver, string BookName)
        {
            driver.FindElement(By.XPath("//input[@id='searchBox']")).SendKeys(BookName);
            Thread.Sleep(1000);
        }

        private void AddBook(IWebDriver driver)
        {
            var books = driver.FindElements(By.XPath("//div[@class='rt-tr-group']//span//a"));
            books[0].Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//button[text()='Add To Your Collection']")).Click();
            Thread.Sleep(1000);

            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().DefaultContent();

            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//button[text()='Back To Book Store']")).Click();
            Thread.Sleep(1000);
        }

        private void NavigateProfile(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://demoqa.com/profile");
            Thread.Sleep(2000);
        }

        private void DeleteBooks(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//div[contains(@class,'text-right')]//button[text()='Delete All Books']")).Click();

            Thread.Sleep(1000);

            driver.SwitchTo().ActiveElement();

            Thread.Sleep(1000);

            driver.FindElement(By.Id("closeSmallModal-ok")).Click();

            Thread.Sleep(1000);

            driver.SwitchTo().Alert().Accept();
        }

        private void Logout(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//div[contains(@class,'text-right')]//button[text()='Log out']")).Click();
            Thread.Sleep(3000);
        }
    }
}
