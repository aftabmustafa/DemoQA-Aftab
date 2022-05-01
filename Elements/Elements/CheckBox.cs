using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Elements
{
    internal class CheckBox
    {
        public void Run(bool Continue)
        {
            IWebDriver Driver = new ChromeDriver();

            try
            {
                Driver.Manage().Window.Maximize();

                Driver.Navigate().GoToUrl("https://demoqa.com/checkbox");

                Thread.Sleep(2000);

                Thread.Sleep(2000);

                ExpandArrow(Driver);

                Thread.Sleep(2000);

                SelectCheckBox(Driver);

                Thread.Sleep(2000);

                RightCollapseBtn(Driver);

                Thread.Sleep(2000);

                RightExpandBtn(Driver);

                Thread.Sleep(5000);

                Driver.Close();
                Driver.Quit();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(5000);
                Driver.Quit();
            }

            if (Continue)
                new RadioButton().Run(Continue);
        }

        static void ExpandArrow(IWebDriver driver)
        {
            driver.FindElements(By.XPath("//button[@title='Toggle']"))[0].Click();
            Thread.Sleep(2000);

            driver.FindElements(By.XPath("//button[@title='Toggle']"))[1].Click();
            Thread.Sleep(2000);

            driver.FindElements(By.XPath("//button[@title='Toggle']"))[2].Click();
            Thread.Sleep(2000);

            driver.FindElements(By.XPath("//button[@title='Toggle']"))[3].Click();
            Thread.Sleep(2000);

            driver.FindElements(By.XPath("//button[@title='Toggle']"))[4].Click();
            Thread.Sleep(2000);

            driver.FindElements(By.XPath("//button[@title='Toggle']"))[5].Click();
            Thread.Sleep(2000);
        }

        static void SelectCheckBox(IWebDriver driver)
        {
            // Click on Home Folder Icon
            driver.FindElement(By.XPath("//span[text()='Home']")).Click();
        }

        static void RightExpandBtn(IWebDriver driver)
        {
            // Using Class
            driver.FindElement(By.ClassName("rct-option-expand-all")).Click();

            // Using XPath
            //driver.FindElement(By.XPath("//button[contains(@class,'rct-option-expand-all')]")).Click();
        }

        static void RightCollapseBtn(IWebDriver driver)
        {
            // Using Class
            driver.FindElement(By.ClassName("rct-option-collapse-all")).Click();

            // Using XPath
            //driver.FindElement(By.XPath("//button[contains(@class,'rct-option-collapse-all')]")).Click();
        }
    }
}
