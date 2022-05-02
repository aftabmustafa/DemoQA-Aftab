using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace DqLib
{
    public class SeleniumLib
    {
        public IWebDriver Driver;
        public IJavaScriptExecutor Js;

        public void StartBrowser(string url)
        {
            Driver = new ChromeDriver();

            Js = (IJavaScriptExecutor)Driver;

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl(url);
        }

        public void FindElement(By by)
        {
            Driver.FindElement(by);
        }

        public void FindElements(By by)
        {
            Driver.FindElements(by);
        }

        public void TextInput(By by, string input)
        {
            Driver.FindElement(by).SendKeys(input);
        }

        public void Scroll(int X, int Y)
        {
            Js.ExecuteScript($"window.scrollBy({X}, {Y})");
        }

        public void SimpleClick(By by)
        {
            Driver.FindElement(by).Click();
        }

        public void Sleep(int time)
        {
            Thread.Sleep(time);
        }

        public void CloseBrowser()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
