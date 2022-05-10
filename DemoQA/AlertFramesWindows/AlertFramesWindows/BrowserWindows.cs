using NUnit.Framework;
using OpenQA.Selenium;
using DqLib;

namespace AlertFramesWindows
{
    class BrowserWindows : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/browser-windows");

                // If we got No Exception in these method, it means we've verified that browser has open NewTab / New Window.

                NewTab();

                Sleep(3000);

                NewWindow();

                Sleep(3000);

                NewWindowMessage();

                CloseBrowser(); 
            }

            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);
              
                CloseBrowser();
            }

            if (Prompt())
                new Alerts().Run();
        }

        public void NewTab()
        {
            IWebElement NewTabBtn = Driver.FindElement(By.XPath("//button[@id='tabButton']"));

            Assert.AreEqual(1, Driver.WindowHandles.Count);

            NewTabBtn.Click();

            Sleep(3000);

            Assert.AreEqual(2, Driver.WindowHandles.Count);

            System.Console.WriteLine();
            System.Console.WriteLine("-------------- New Tab Console Start --------------");
            System.Console.WriteLine($"Parent Tab ID - {Driver.WindowHandles[0]}");
            System.Console.WriteLine();

            var NewTabHandle = Driver.WindowHandles[1];
            Assert.IsTrue(!string.IsNullOrEmpty(NewTabHandle));

            System.Console.WriteLine($"Child Tab ID - {Driver.WindowHandles[1]}");
            System.Console.WriteLine("-------------- New Tab Console End --------------");

            Assert.AreEqual(Driver.SwitchTo().Window(NewTabHandle).Url, "https://demoqa.com/sample");

            Driver.SwitchTo().Window(Driver.WindowHandles[1]).Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }

        public void NewWindow()
        {
            IWebElement NewWindowBtn = Driver.FindElement(By.XPath("//button[@id='windowButton']"));
            NewWindowBtn.Click();

            Sleep(3000);

            Assert.AreEqual(2, Driver.WindowHandles.Count);

            var NewWindowHandle = Driver.WindowHandles[1];
            Assert.IsTrue(!string.IsNullOrEmpty(NewWindowHandle));

            string NewWindowMessage = Driver.SwitchTo().Window(Driver.WindowHandles[1]).FindElement(By.Id("sampleHeading")).Text;

            System.Console.WriteLine();
            System.Console.WriteLine("-------------- New Window Console Start --------------");
            System.Console.WriteLine($"Message from New Window: {NewWindowMessage}");
            System.Console.WriteLine("-------------- New Window Console End --------------");
            System.Console.WriteLine();


            Driver.SwitchTo().Window(Driver.WindowHandles[1]).Close();
            Sleep(2000);

            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }

        public void NewWindowMessage()
        {
            IWebElement NewWindowMessage = Driver.FindElement(By.XPath("//button[@id='messageWindowButton']"));

            NewWindowMessage.Click();

            Sleep(3000);

            Assert.AreEqual(2, Driver.WindowHandles.Count);

            var NewWindowMessageHandle = Driver.WindowHandles[1];
            Assert.IsTrue(!string.IsNullOrEmpty(NewWindowMessageHandle));

            Driver.SwitchTo().Window(Driver.WindowHandles[1]).Close();
            Sleep(2000);

            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }
    }
}
