using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Widgets
{
    class Accordian
    {
        public void Run(bool Continue)
        {
            IWebDriver Driver = new ChromeDriver();

            try
            {
                Driver.Manage().Window.Maximize();

                Driver.Navigate().GoToUrl("https://demoqa.com/accordian");

                Thread.Sleep(3000);

                IWebElement Heading1 = Driver.FindElement(By.Id("section1Heading"));
                Heading1.Click();

                Thread.Sleep(3000);
                Heading1.Click();

                IWebElement Heading2 = Driver.FindElement(By.Id("section2Heading"));
                Heading2.Click();

                Thread.Sleep(3000);

                IWebElement Heading3 = Driver.FindElement(By.Id("section3Heading"));
                Heading3.Click();

                Thread.Sleep(3000);

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

            if (Continue)
                new AutoComplete().Run(Continue);
        }
    }
}
