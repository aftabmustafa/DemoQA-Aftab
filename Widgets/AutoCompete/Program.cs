using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace AutoCompete
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();
            Actions action = new Actions(Driver);

            Driver.Manage().Window.Maximize();
            
            Driver.Navigate().GoToUrl("https://demoqa.com/auto-complete");

            Thread.Sleep(3000);



            Driver.Close();
            Driver.Quit();
        }
    }
}
