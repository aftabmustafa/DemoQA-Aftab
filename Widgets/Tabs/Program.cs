using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Tabs
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/tabs");

            Thread.Sleep(3000);

            IWebElement OriginTab = Driver.FindElement(By.Id("demo-tab-origin"));
            OriginTab.Click();

            Thread.Sleep(2000);

            IWebElement UseTab = Driver.FindElement(By.Id("demo-tab-use"));
            UseTab.Click();

            Thread.Sleep(2000);

            IWebElement WhatTab = Driver.FindElement(By.Id("demo-tab-what"));
            WhatTab.Click();

            Thread.Sleep(2000);

            _ = 0;

            Driver.Close();
            Driver.Quit();
        }
    }
}
