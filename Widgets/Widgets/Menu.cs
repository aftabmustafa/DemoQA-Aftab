using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;


namespace Widgets
{
    class Menu
    {
        public void Run(bool Continue)
        {
            IWebDriver Driver = new ChromeDriver();
            Actions action = new Actions(Driver);

            try
            {
                Driver.Manage().Window.Maximize();

                Driver.Navigate().GoToUrl("https://demoqa.com/menu");

                Thread.Sleep(3000);

                IWebElement MainItem1 = Driver.FindElement(By.XPath("//a[text()='Main Item 1']"));
                action.MoveToElement(MainItem1);

                Thread.Sleep(2000);

                IWebElement MainItem2 = Driver.FindElement(By.XPath("//a[text()='Main Item 2']"));
                action.MoveToElement(MainItem2);

                Thread.Sleep(2000);

                IWebElement MainItem2__SubItem = Driver.FindElement(By.XPath("//a[text()='SUB SUB LIST »']"));
                action.MoveToElement(MainItem2__SubItem);

                Thread.Sleep(2000);

                IWebElement SubSubItem1 = Driver.FindElement(By.XPath("//a[text()='Sub Sub Item 1']"));
                action.MoveToElement(SubSubItem1);

                Thread.Sleep(2000);

                IWebElement SubSubItem2 = Driver.FindElement(By.XPath("//a[text()='Sub Sub Item 2']"));
                action.MoveToElement(SubSubItem2);

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
                new SelectMenu().Run();
        }
    }
}
