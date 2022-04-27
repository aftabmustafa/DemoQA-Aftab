using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace ProgressBar
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/progress-bar");

            Thread.Sleep(3000);

            var ProgressControlBtn = Driver.FindElement(By.Id("startStopButton"));

            ProgressControlBtn.Click();

            Thread.Sleep(new System.Random().Next(3, 8) * 1000);

            ProgressControlBtn.Click();

            _ = 0;

            Driver.Close();
            Driver.Quit();
        }
    }
}
