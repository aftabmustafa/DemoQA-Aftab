using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Alerts
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/alerts");

            Thread.Sleep(3000);

            SimpleAlert(Driver);
            Thread.Sleep(1000);

            TimedAlert(Driver);
            Thread.Sleep(1000);

            ConfirmAlert(Driver);
            Thread.Sleep(1000);

            PromptAlert(Driver);
            Thread.Sleep(1000);

            _ = 0;

            Driver.Close();
            Driver.Quit();
        }

        static void SimpleAlert(IWebDriver driver)
        {
            IWebElement AlertBtn = driver.FindElement(By.Id("alertButton"));
            AlertBtn.Click();

            Thread.Sleep(2000);

            var AlertWin = driver.SwitchTo().Alert();

            AlertWin.Accept();
        }

        static void TimedAlert(IWebDriver driver)
        {
            IWebElement AlertBtn = driver.FindElement(By.Id("timerAlertButton"));
            AlertBtn.Click();

            Thread.Sleep(6000);

            var AlertWin = driver.SwitchTo().Alert();
            AlertWin.Accept();
        }

        static void ConfirmAlert(IWebDriver driver)
        {
            IWebElement AlertBtn = driver.FindElement(By.Id("confirmButton"));
            AlertBtn.Click();

            Thread.Sleep(2000);

            var AlertWin = driver.SwitchTo().Alert();

            AlertWin.Accept();
        }

        static void PromptAlert(IWebDriver driver) 
        {
            IWebElement AlertBtn = driver.FindElement(By.Id("promtButton"));
            AlertBtn.Click();

            Thread.Sleep(2000);

            var AlertWin = driver.SwitchTo().Alert();

            AlertWin.SendKeys("Hello World");

            Thread.Sleep(2000);

            AlertWin.Accept();
        }
    }
}
