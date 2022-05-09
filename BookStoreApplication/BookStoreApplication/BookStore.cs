using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DqLib;

namespace BookStoreApplication
{
    internal class BookStore : SeleniumLib
    {
        public void Home()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://demoqa.com/books");

            SearchBook("Git");
            AddBook();

            SearchBook("script");
            AddBook();

            NavigateProfile();

            DeleteBooks();

            Logout();
        }

        private void SearchBook(string BookName)
        {
            TextInput(By.XPath("//input[@id='searchBox']"), BookName);

            Sleep(1000);
        }

        private void AddBook()
        {
            var books = FindElements(By.XPath("//div[@class='rt-tr-group']//span//a"));
            books[0].Click();
            Sleep(1000);

            SimpleClick(By.XPath("//button[text()='Add To Your Collection']"));
            Sleep(1000);

            Driver.SwitchTo().Alert().Accept();
            Driver.SwitchTo().DefaultContent();

            Sleep(1000);

            SimpleClick(By.XPath("//button[text()='Back To Book Store']"));
            Sleep(1000);
        }

        private void NavigateProfile()
        {
            Driver.Navigate().GoToUrl("https://demoqa.com/profile");
            Sleep(2000);
        }

        private void DeleteBooks()
        {
            SimpleClick(By.XPath("//div[contains(@class,'text-right')]//button[text()='Delete All Books']"));

            Sleep(1000);

            Driver.SwitchTo().ActiveElement();

            Sleep(1000);

            SimpleClick(By.Id("closeSmallModal-ok"));

            Sleep(1000);

            Driver.SwitchTo().Alert().Accept();
        }

        private void Logout()
        {
            SimpleClick(By.XPath("//div[contains(@class,'text-right')]//button[text()='Log out']"));
            Sleep(3000);
        }
    }
}
