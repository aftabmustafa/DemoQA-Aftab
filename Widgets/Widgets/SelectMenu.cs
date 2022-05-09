using OpenQA.Selenium;
using DqLib;

namespace Widgets
{
    class SelectMenu : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/select-menu");

                Sleep(3000);

                SelectValue();

                SelectOne();

                SelectOldStyle();

                MultiselectDropDown();

                StandardMultiSelect();

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);

                CloseBrowser();
            }
        }

        public void SelectValue()
        {
            SimpleClick(By.XPath("//div[text()='Select Option']"));

            Sleep(500);

            Driver.FindElement(By.XPath("//input[@id='react-select-2-input']"))
                  .SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
        }

        public void SelectOne()
        {
            SimpleClick(By.XPath("//div[text()='Select Title']"));

            Sleep(500);

            Driver.FindElement(By.XPath("//input[@id='react-select-3-input']"))
                  .SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
        }

        public void SelectOldStyle()
        {
            IWebElement OldStyleMenu = FindElement(By.Id("oldSelectMenu"));
            OldStyleMenu.Click();
            OldStyleMenu.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
        }

        public void MultiselectDropDown()
        {
            SimpleClick(By.XPath("//div[text()='Select...']"));

            Driver.FindElement(By.XPath("//input[@id='react-select-4-input']"))
                  .SendKeys(Keys.ArrowDown + Keys.Enter + Keys.ArrowDown + Keys.Enter + Keys.ArrowDown + Keys.Enter + Keys.ArrowDown + Keys.Enter);
        }

        public void StandardMultiSelect()
        {
            actionProvider.KeyDown(Keys.LeftControl)
                .MoveToElement(Driver.FindElements(By.XPath("//select[@id='cars']//option"))[1])
                .Click()
                .MoveToElement(Driver.FindElements(By.XPath("//select[@id='cars']//option"))[0])
                .Click()
                .Release().Build().Perform();
        }
    }
}
