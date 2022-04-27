using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using System.Threading;

namespace _9.DynamicProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/dynamic-properties");

            IWebElement EnableAfter5Btn = Driver.FindElement(By.Id("enableAfter"));
            IWebElement ChameleonBtn = Driver.FindElement(By.Id("colorChange"));

            ReadOnlyCollection<IWebElement> IsVisibleBtn = Driver.FindElements(By.Id("visibleAfter"));

            string InitialColor = ChameleonBtn.GetCssValue("color");

            Assert.IsFalse(EnableAfter5Btn.Enabled);
            Assert.IsTrue(IsVisibleBtn.Count == 0);

            Thread.Sleep(5100);

            ReadOnlyCollection<IWebElement> VisibleBtn = Driver.FindElements(By.Id("visibleAfter"));

            Assert.IsTrue(EnableAfter5Btn.Enabled);
            Assert.IsTrue(VisibleBtn.Count > 0);
            Assert.AreNotEqual(InitialColor, ChameleonBtn.GetCssValue("color"));

            _ = 0;

            System.Console.WriteLine("Test End");

            Thread.Sleep(3000);

            Driver.Close();
            Driver.Quit();
        }
    }
}
