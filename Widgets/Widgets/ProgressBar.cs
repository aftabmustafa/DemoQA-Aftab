using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Widgets
{
    class ProgressBar
    {
        public void Run(bool Continue)
        {
            IWebDriver Driver = new ChromeDriver();

            try
            {
                Driver.Manage().Window.Maximize();

                Driver.Navigate().GoToUrl("https://demoqa.com/progress-bar");

                Thread.Sleep(3000);

                var ProgressControlBtn = Driver.FindElement(By.Id("startStopButton"));

                ProgressControlBtn.Click();

                Thread.Sleep(new System.Random().Next(3, 8) * 1000);

                ProgressControlBtn.Click();

                Driver.Close();
                Driver.Quit();
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Thread.Sleep(5000);

                Driver.Close();
                Driver.Quit();
            }

            if (Continue)
                new Tabs().Run(Continue);
        }
    }
}
