using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace _1.TextBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FName = "Aftab Mustafa";
            string Email = "email@gmail.com";
            string CAddress = "Current Address 1";
            string PAddress = "Permanent Address 2";

            IWebDriver Driver = new ChromeDriver();
            IJavaScriptExecutor Js = (IJavaScriptExecutor)Driver;

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/text-box");

            Thread.Sleep(2000);

            #region 1. Using ID

            Driver.FindElement(By.Id("userName")).SendKeys(FName);

            Thread.Sleep(1000);

            Driver.FindElement(By.Id("userEmail")).SendKeys(Email);

            Thread.Sleep(1000);

            Driver.FindElement(By.Id("currentAddress")).SendKeys(CAddress);

            Thread.Sleep(1000);

            Driver.FindElement(By.Id("permanentAddress")).SendKeys(PAddress);

            Thread.Sleep(1000);

            Js.ExecuteScript("window.scrollBy(0, 200)");

            Driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(2000);
            #endregion

            #region 2. Using XPath

            //Driver.FindElement(By.XPath("//input[@id='userName']")).SendKeys(FName);

            //Thread.Sleep(1000);

            //Driver.FindElement(By.XPath("//input[@id='userEmail']")).SendKeys(Email);

            //Thread.Sleep(1000);

            //Driver.FindElement(By.XPath("//textarea[@id='currentAddress']")).SendKeys(CAddress);

            //Thread.Sleep(1000);

            //Driver.FindElement(By.XPath("//textarea[@id='permanentAddress']")).SendKeys(PAddress);

            //Js.ExecuteScript("window.scrollBy(0, 200)");

            //Thread.Sleep(1000);

            //Driver.FindElement(By.XPath("//button[@id='submit']")).Click();

            //Thread.Sleep(3000);
            #endregion

            Driver.Close();

            Driver.Quit();
        }
    }
}
