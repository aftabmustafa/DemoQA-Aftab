using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Widgets
{
    class Slider
    {
        public void Run(bool Continue)
        {
            IWebDriver Driver = new ChromeDriver();
            Actions action = new Actions(Driver);

            try
            {
                Driver.Manage().Window.Maximize();

                Driver.Navigate().GoToUrl("https://demoqa.com/slider");

                Thread.Sleep(3000);

                IWebElement InputSlider = Driver.FindElement(By.XPath("//input[contains(@class, 'range-slider')]"));
                action.MoveToElement(InputSlider)
                      .ClickAndHold()
                      .MoveByOffset(08, 0)
                      .MoveByOffset(-6, 0)
                      .MoveByOffset(-18, 0)
                      .MoveByOffset(16, 0)
                      .MoveByOffset(20, 0)
                      .Build()
                      .Perform();

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
                new ProgressBar().Run(Continue);
        }
    }
}
