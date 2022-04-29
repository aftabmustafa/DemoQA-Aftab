using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace AutoCompete
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();

            Driver.Manage().Window.Maximize();
            
            Driver.Navigate().GoToUrl("https://demoqa.com/auto-complete");

            Thread.Sleep(3000);

            TestMultiple(Driver);

            TestSingle(Driver);

            Driver.Close();
            Driver.Quit();
        }

        static void TestMultiple(IWebDriver driver)
        {
            IWebElement InputBox = driver.FindElement(By.Id("autoCompleteMultipleInput"));

            InputBox.SendKeys("ee");
            Thread.Sleep(1000);
            InputBox.SendKeys(Keys.Enter);

            InputBox.SendKeys("Bl");
            Thread.Sleep(500);

            InputBox.SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);

            InputBox.SendKeys(Keys.Enter);
        }

        static void TestSingle(IWebDriver driver)
        {
            IWebElement InputBox = driver.FindElement(By.Id("autoCompleteSingleInput"));

            InputBox.SendKeys("ee");
            Thread.Sleep(1000);
            InputBox.SendKeys(Keys.Enter);
        }
    }
}
