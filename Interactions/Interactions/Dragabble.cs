using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Interactions
{
    class Dragabble
    {
        public void Run()
        {
            IWebDriver Driver = new ChromeDriver();
            Actions actionProvider = new Actions(Driver);

            try
            {
                Driver.Manage().Window.Maximize();

                Driver.Navigate().GoToUrl("https://demoqa.com/dragabble");

                Thread.Sleep(3000);

                SimpleDrag(Driver, actionProvider);
                Thread.Sleep(2000);

                AxisRestricted(Driver, actionProvider);
                Thread.Sleep(2000);

                SwitchToCR(Driver, actionProvider);
                Thread.Sleep(2000);

                CursorStyle(Driver, actionProvider);
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
        }
        static void SimpleDrag(IWebDriver driver, Actions action)
        {
            action.MoveToElement(driver.FindElement(By.Id("dragBox")))
                .ClickAndHold()
                .MoveByOffset(100, 100)
                .Build()
                .Perform();
        }

        static void AxisRestricted(IWebDriver driver, Actions action)
        {
            driver.FindElement(By.Id("draggableExample-tab-axisRestriction")).Click();
            driver.SwitchTo().ActiveElement();

            Thread.Sleep(1000);

            action.MoveToElement(driver.FindElement(By.Id("restrictedX")))
                .ClickAndHold()
                .MoveByOffset(50, 0)
                .MoveByOffset(0, 50)
                .Build()
                .Perform();

            action.MoveToElement(driver.FindElement(By.Id("restrictedY")))
                .ClickAndHold()
                .MoveByOffset(50, 0)
                .MoveByOffset(0, 50)
                .Build()
                .Perform();
        }

        static void SwitchToCR(IWebDriver driver, Actions action)
        {
            driver.FindElement(By.Id("draggableExample-tab-containerRestriction")).Click();
            Thread.Sleep(500);

            action.MoveToElement(driver.FindElement(By.XPath("//div[contains(text(),'contained within the box')]")))
             .ClickAndHold()
             .MoveByOffset(100, 0)
             .MoveByOffset(0, 500)
             .Build()
             .Perform();

            action.MoveToElement(driver.FindElement(By.XPath("//span[contains(text(),'contained within my parent')]")))
               .ClickAndHold()
               .MoveByOffset(100, 100)
               .Build()
               .Perform();
        }

        static void CursorStyle(IWebDriver driver, Actions action)
        {
            driver.FindElement(By.Id("draggableExample-tab-cursorStyle")).Click();
            Thread.Sleep(500);

            // Check center cursor
            new Actions(driver)
                .MoveToElement(driver.FindElement(By.Id("cursorCenter")))
                .ClickAndHold()
                .MoveByOffset(200, 200)
                .Release()
                .ContextClick()
                .SendKeys(Keys.Escape)
                .Build()
                .Perform();

            // Check Top Left
            action.MoveToElement(driver.FindElement(By.Id("cursorTopLeft")))
                  .ClickAndHold()
                  .MoveByOffset(200, 0)
                  .Release()
                  .ContextClick()
                  .SendKeys(Keys.Escape)
                  .Build()
                  .Perform();

            // Check Bottom
            action.MoveToElement(driver.FindElement(By.Id("cursorBottom")))
                  .ClickAndHold()
                  .MoveByOffset(200, -200)
                  .Release()
                  .ContextClick()
                  .SendKeys(Keys.Escape)
                  .Build()
                  .Perform();
        }

    }
}
