using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace BrowserWindows
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();
            IJavaScriptExecutor Js = (IJavaScriptExecutor)Driver;

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");

            // If we got No Exception in these method, it means we've verified that browser has open NewTab / New Window.

            NewTab(Driver);

            Thread.Sleep(3000);

            NewWindow(Driver);

            Thread.Sleep(3000);

            NewWindowMessage(Driver);

            // Look at Console Please!
            _ = 0;

            Driver.Close();
            Driver.Quit();
        }

        static void NewTab(IWebDriver driver)
        {
            IWebElement NewTabBtn = driver.FindElement(By.XPath("//button[@id='tabButton']"));

            Assert.AreEqual(1, driver.WindowHandles.Count);

            NewTabBtn.Click();

            Thread.Sleep(3000);

            Assert.AreEqual(2, driver.WindowHandles.Count);

            System.Console.WriteLine();
            System.Console.WriteLine("-------------- New Tab Console Start --------------");
            System.Console.WriteLine($"Parent Tab ID - {driver.WindowHandles[0]}");
            System.Console.WriteLine();

            var NewTabHandle = driver.WindowHandles[1];
            Assert.IsTrue(!string.IsNullOrEmpty(NewTabHandle));

            System.Console.WriteLine($"Child Tab ID - {driver.WindowHandles[1]}");
            System.Console.WriteLine("-------------- New Tab Console End --------------");

            Assert.AreEqual(driver.SwitchTo().Window(NewTabHandle).Url, "https://demoqa.com/sample");

            driver.SwitchTo().Window(driver.WindowHandles[1]).Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        static void NewWindow(IWebDriver driver)
        {
            IWebElement NewWindowBtn = driver.FindElement(By.XPath("//button[@id='windowButton']"));
            NewWindowBtn.Click();

            Thread.Sleep(3000);

            Assert.AreEqual(2, driver.WindowHandles.Count);

            var NewWindowHandle = driver.WindowHandles[1];
            Assert.IsTrue(!string.IsNullOrEmpty(NewWindowHandle));

            string NewWindowMessage = driver.SwitchTo().Window(driver.WindowHandles[1]).FindElement(By.Id("sampleHeading")).Text;

            System.Console.WriteLine();
            System.Console.WriteLine("-------------- New Window Console Start --------------");
            System.Console.WriteLine($"Message from New Window: {NewWindowMessage}");
            System.Console.WriteLine("-------------- New Window Console End --------------");
            System.Console.WriteLine();


            driver.SwitchTo().Window(driver.WindowHandles[1]).Close();
            Thread.Sleep(2000);

            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        static void NewWindowMessage(IWebDriver driver)
        {
            IWebElement NewWindowMessage = driver.FindElement(By.XPath("//button[@id='messageWindowButton']"));

            NewWindowMessage.Click();

            Thread.Sleep(3000);

            Assert.AreEqual(2, driver.WindowHandles.Count);

            var NewWindowMessageHandle = driver.WindowHandles[1];
            Assert.IsTrue(!string.IsNullOrEmpty(NewWindowMessageHandle));

            driver.SwitchTo().Window(driver.WindowHandles[1]).Close();
            Thread.Sleep(2000);

            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }
    }
}

