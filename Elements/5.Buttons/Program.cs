using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace _5.Buttons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();
            Actions ActionProvider = new Actions(Driver);

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/buttons");

            DoubleClick(Driver, ActionProvider);

            Thread.Sleep(2000);

            RightClick(Driver, ActionProvider);

            Thread.Sleep(2000);

            // Single Click using CSS
            Driver.FindElements(By.ClassName("btn-primary"))[2].Click();

            // Single Click using XPath
            //Driver.FindElement(By.XPath("//button[text()='Click Me']")).Click();

            Thread.Sleep(2000);

            Driver.Close();
            Driver.Quit();
        }

        static void DoubleClick(IWebDriver driver, Actions actionProvider)
        {
            IWebElement doubleClickBtn = driver.FindElement(By.Id("doubleClickBtn"));

            // XPath
            //IWebElement doubleClickBtn = driver.FindElement(By.XPath("//button[@id='doubleClickBtn']"));

            actionProvider.DoubleClick(doubleClickBtn).Build().Perform();
        }

        static void RightClick(IWebDriver driver, Actions actionProvider)
        {
            IWebElement RightClickBtn = driver.FindElement(By.Id("rightClickBtn"));

            // XPath
            //IWebElement RightClickBtn = driver.FindElement(By.XPath("//button[@id='rightClickBtn']"));
            actionProvider.ContextClick(RightClickBtn).Build().Perform();
        }
    }
}
