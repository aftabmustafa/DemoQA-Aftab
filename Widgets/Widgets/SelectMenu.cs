using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Widgets
{
    class SelectMenu
    {
        public void Run()
        {
            IWebDriver Driver = new ChromeDriver();

            try
            {
                Driver.Manage().Window.Maximize();

                Driver.Navigate().GoToUrl("https://demoqa.com/select-menu");

                Thread.Sleep(3000);

                SelectValue(Driver);

                SelectOne(Driver);

                SelectOldStyle(Driver);

                MultiselectDropDown(Driver);

                StandardMultiSelect(Driver);

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
        }

        static void SelectValue(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//div[text()='Select Option']"))
               .Click();

            Thread.Sleep(500);

            driver.FindElement(By.XPath("//input[@id='react-select-2-input']"))
                .SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
        }

        static void SelectOne(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//div[text()='Select Title']"))
                .Click();

            Thread.Sleep(500);

            driver.FindElement(By.XPath("//input[@id='react-select-3-input']"))
                .SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
        }

        static void SelectOldStyle(IWebDriver driver)
        {
            IWebElement OldStyleMenu = driver.FindElement(By.Id("oldSelectMenu"));
            OldStyleMenu.Click();
            OldStyleMenu.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
        }

        static void MultiselectDropDown(IWebDriver driver)
        {
            IWebElement MultiSelectMenu = driver.FindElement(By.XPath("//div[text()='Select...']"));
            MultiSelectMenu.Click();

            driver.FindElement(By.XPath("//input[@id='react-select-4-input']"))
                .SendKeys(Keys.ArrowDown + Keys.Enter + Keys.ArrowDown + Keys.Enter + Keys.ArrowDown + Keys.Enter + Keys.ArrowDown + Keys.Enter);
        }

        static void StandardMultiSelect(IWebDriver driver)
        {

            IWebElement MultiSelectText = driver.FindElement(By.Id("cars"));

            Actions actions = new Actions(driver);

            actions.KeyDown(Keys.LeftControl)
                .MoveToElement(driver.FindElements(By.XPath("//select[@id='cars']//option"))[1])
                .Click()
                .MoveToElement(driver.FindElements(By.XPath("//select[@id='cars']//option"))[0])
                .Click()
                .Release().Build().Perform();
        }

    }
}
