using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace _3.RadioButton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();
            IJavaScriptExecutor Js = (IJavaScriptExecutor)Driver;

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/radio-button");

            Thread.Sleep(1000);

            #region 1. Using Id

            IWebElement YesBtn = Driver.FindElement(By.Id("yesRadio"));
            Js.ExecuteScript("arguments[0].click()", YesBtn);

            Thread.Sleep(1000);

            IWebElement ImpressBtn = Driver.FindElement(By.Id("impressiveRadio"));

            Js.ExecuteScript("arguments[0].click()", ImpressBtn);

            Thread.Sleep(3000);

            #endregion

            #region 2. Using XPath

            //IWebElement YesBtn = Driver.FindElements(By.XPath("//input[contains(@class,'custom-control-input')]"))[0];

            //Js.ExecuteScript("arguments[0].click()", YesBtn);

            //Thread.Sleep(2000);

            //IWebElement ImpressBtn = Driver.FindElements(By.XPath("//input[contains(@class,'custom-control-input')]"))[1];

            //Js.ExecuteScript("arguments[0].click()", ImpressBtn);

            //Thread.Sleep(2000);

            #endregion

            Driver.Close();
            Driver.Quit();
        }
    }
}
