using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Elements
{
    internal class TextBox
    {
        public void Run(bool Continue)
        {
            string FName = "Aftab Mustafa";
            string Email = "email@gmail.com";
            string CAddress = "Current Address 1";
            string PAddress = "Permanent Address 2";

            IWebDriver Driver = new ChromeDriver();
            IJavaScriptExecutor Js = (IJavaScriptExecutor)Driver;

            try
            {
                Driver.Manage().Window.Maximize();
                Driver.Navigate().GoToUrl("https://demoqa.com/text-box");

                Thread.Sleep(1000);

                Driver.FindElement(By.Id("userName")).SendKeys(FName);

                Thread.Sleep(1000);

                Driver.FindElement(By.Id("userEmail")).SendKeys(Email);

                Thread.Sleep(1000);

                Driver.FindElement(By.Id("currentAddress")).SendKeys(CAddress);

                Thread.Sleep(1000);

                Driver.FindElement(By.Id("permanentAddress")).SendKeys(PAddress);

                Thread.Sleep(1000);

                Js.ExecuteScript("window.scrollBy(0, 200)");

                Thread.Sleep(1000);

                IWebElement SubmitBtn = Driver.FindElement(By.Id("submit"));

                SubmitBtn.Click();

                System.Console.WriteLine("Text Box Check Successful");

                Thread.Sleep(2000);

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
                new CheckBox().Run(Continue);
        }
    }
}
