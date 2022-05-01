using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime.InteropServices;
using System.Threading;

namespace Elements
{
    class Links
    {
        public void Run(bool Continue)
        {
            IWebDriver Driver = new ChromeDriver();
            IJavaScriptExecutor Js = (IJavaScriptExecutor)Driver;

            try
            {
                Driver.Manage().Window.Maximize();

                Driver.Navigate().GoToUrl("https://demoqa.com/links");

                Thread.Sleep(1000);

                // 1st Link under Open New Tab
                NewTabHandler(Driver, "simpleLink");

                // 2nd Link under Open New Tab
                //NewTabHandler(Driver, "dynamicLink");

                Thread.Sleep(3000);

                Js.ExecuteScript("window.scrollBy(0, 150)");

                APILinkHandler(Driver, "created");
                Thread.Sleep(1000);

                APILinkHandler(Driver, "no-content");
                Thread.Sleep(2000);

                APILinkHandler(Driver, "moved");
                Thread.Sleep(2000);

                APILinkHandler(Driver, "bad-request");
                Thread.Sleep(2000);

                APILinkHandler(Driver, "unauthorized");
                Thread.Sleep(2000);

                APILinkHandler(Driver, "forbidden");
                Thread.Sleep(2000);

                APILinkHandler(Driver, "invalid-url");

                Thread.Sleep(2000);

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
                new BrokenLinks().Run(Continue);
        }
        // Optional is only for learning purpose
        static void NewTabHandler(IWebDriver driver, [Optional] string Path)
        {
            driver.FindElement(By.Id(Path)).Click();

            Thread.Sleep(1000);

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            Thread.Sleep(1000);

            driver.Close();

            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        static void APILinkHandler(IWebDriver driver, [Optional] string Path)
        {
            driver.FindElement(By.Id(Path)).Click();
        }

    }
}
