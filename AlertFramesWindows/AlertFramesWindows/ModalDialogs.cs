using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace AlertFramesWindows
{
    class ModalDialogs
    {
        public void Run()
        {
            IWebDriver Driver = new ChromeDriver();

            try
            {
                Driver.Manage().Window.Maximize();

                Driver.Navigate().GoToUrl("https://demoqa.com/modal-dialogs");

                Thread.Sleep(3000);

                IWebElement SmallModalBtn = Driver.FindElement(By.Id("showSmallModal"));
                SmallModalBtn.Click();

                Thread.Sleep(3000);

                IWebElement CloseSmallModalBtn = Driver.FindElement(By.XPath("//button[@id='closeSmallModal']"));
                CloseSmallModalBtn.Click();

                Thread.Sleep(3000);

                IWebElement LargeModalBtn = Driver.FindElement(By.Id("showLargeModal"));
                LargeModalBtn.Click();

                Thread.Sleep(3000);

                IWebElement LargeModalCloseBtn = Driver.FindElement(By.XPath("//button[@id='closeLargeModal']"));
                LargeModalCloseBtn.Click();

                Thread.Sleep(2000);

                _ = 0;

                Driver.Close();
                Driver.Quit();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Thread.Sleep(5000);
                Driver.Close();
                Driver.Quit();
            }
        }
    }
}
