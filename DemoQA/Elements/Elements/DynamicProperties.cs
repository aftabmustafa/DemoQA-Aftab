using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using DqLib;

namespace Elements
{
    class DynamicProperties : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/dynamic-properties");

                // If we get any exceptionm error then test Failed else Pass

                IWebElement EnableAfter5Btn = Driver.FindElement(By.Id("enableAfter"));
                IWebElement ChameleonBtn = Driver.FindElement(By.Id("colorChange"));

                ReadOnlyCollection<IWebElement> IsVisibleBtn = Driver.FindElements(By.Id("visibleAfter"));

                string InitialColor = ChameleonBtn.GetCssValue("color");

                Assert.IsFalse(EnableAfter5Btn.Enabled);
                Assert.IsTrue(IsVisibleBtn.Count == 0);

                Sleep(5100);

                ReadOnlyCollection<IWebElement> VisibleBtn = Driver.FindElements(By.Id("visibleAfter"));

                Assert.IsTrue(EnableAfter5Btn.Enabled);
                Assert.IsTrue(VisibleBtn.Count > 0);
                Assert.AreNotEqual(InitialColor, ChameleonBtn.GetCssValue("color"));

                System.Console.WriteLine("Test End");

                Sleep(3000);

                CloseBrowser();
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);
                CloseBrowser();
            }
        }
    }
}
