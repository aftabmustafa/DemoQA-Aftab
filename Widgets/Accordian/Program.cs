using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Accordian
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/accordian");

            Thread.Sleep(3000);

            IWebElement Heading1 = Driver.FindElement(By.Id("section1Heading"));
            Heading1.Click();

            Thread.Sleep(3000);
            Heading1.Click();

            IWebElement Heading2 = Driver.FindElement(By.Id("section2Heading"));
            Heading2.Click();

            Thread.Sleep(3000);

            IWebElement Heading3 = Driver.FindElement(By.Id("section3Heading"));
            Heading3.Click();

            Thread.Sleep(3000);

            _ = 0;

            Driver.Close();
            Driver.Quit();
        }
    }
}
