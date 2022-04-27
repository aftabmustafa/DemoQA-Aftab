using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Slider
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();
            Actions action = new Actions(Driver);

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

            _ = 0;

            Driver.Close();
            Driver.Quit();

        }
    }
}
