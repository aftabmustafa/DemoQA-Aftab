using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace ToolsTips
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();
            Actions action = new Actions(Driver);

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/tool-tips");

            Thread.Sleep(6000);

            IWebElement HoverBtn = Driver.FindElement(By.Id("toolTipButton"));
            action.MoveToElement(HoverBtn).Perform();
            Thread.Sleep(2000);

            IWebElement InputBoxHover = Driver.FindElement(By.Id("toolTipTextField"));
            action.MoveToElement(InputBoxHover).Perform();
            Thread.Sleep(2000);

            IWebElement AnchorHover = Driver.FindElement(By.XPath("//a[text()='Contrary']"));
            action.MoveToElement(AnchorHover).Perform();
            Thread.Sleep(2000);

            IWebElement DateHover = Driver.FindElement(By.XPath("//a[text()='1.10.32']"));
            action.MoveToElement(DateHover).Perform();

            _ = 0;

            Driver.Close();
            Driver.Quit();
        }
    }
}
