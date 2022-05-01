using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using System.Threading;
namespace Elements
{
    class DynamicProperties
    {
        public void Run()
        {
            IWebDriver Driver = new ChromeDriver();

            Driver.Manage().Window.Maximize();

            try
            {
                Driver.Navigate().GoToUrl("https://demoqa.com/dynamic-properties");

                // If we get any exceptionm error then test failed else Pass

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

                System.Console.WriteLine("Test End");

                Thread.Sleep(3000);

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

            Driver.Quit();

        }
    }
}
