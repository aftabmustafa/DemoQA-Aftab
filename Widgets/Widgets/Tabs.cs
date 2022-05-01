using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Widgets
{
    class Tabs
    {
        public void Run(bool Continue)
        {
            IWebDriver Driver = new ChromeDriver();

            try
            {
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
                new ToolTips().Run(Continue);
        }
    }
}
