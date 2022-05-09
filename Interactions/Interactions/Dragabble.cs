using OpenQA.Selenium;
using DqLib;

namespace Interactions
{
    class Dragabble : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/dragabble");

                Sleep(3000);

                SimpleDrag();
                Sleep(2000);

                AxisRestricted();
                Sleep(2000);

                SwitchToCR();
                Sleep(2000);

                CursorStyle();
                Sleep(2000);

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);

                Sleep(5000);

                CloseBrowser();
            }
        }

        public void SimpleDrag()
        {
            actionProvider.MoveToElement(FindElement(By.Id("dragBox")))
                          .ClickAndHold()
                          .MoveByOffset(100, 100)
                          .Build()
                          .Perform();
        }

        public void AxisRestricted()
        {
            SimpleClick(By.Id("draggableExample-tab-axisRestriction"));
            
            Driver.SwitchTo().ActiveElement();

            Sleep(1000);

            actionProvider.MoveToElement(FindElement(By.Id("restrictedX")))
                          .ClickAndHold()
                          .MoveByOffset(50, 0)
                          .MoveByOffset(0, 50)
                          .Build()
                          .Perform();

            actionProvider.MoveToElement(FindElement(By.Id("restrictedY")))
                          .ClickAndHold()
                          .MoveByOffset(50, 0)
                          .MoveByOffset(0, 50)
                          .Build()
                          .Perform();
        }

        public void SwitchToCR()
        {
            SimpleClick(By.Id("draggableExample-tab-containerRestriction"));
            
            Sleep(500);

            actionProvider.MoveToElement(FindElement(By.XPath("//div[contains(text(),'contained within the box')]")))
                          .ClickAndHold()
                          .MoveByOffset(100, 0)
                          .MoveByOffset(0, 500)
                          .Build()
                          .Perform();

            actionProvider.MoveToElement(FindElement(By.XPath("//span[contains(text(),'contained within my parent')]")))
                          .ClickAndHold()
                          .MoveByOffset(100, 100)
                          .Build()
                          .Perform();
        }

        public void CursorStyle()
        {
            SimpleClick(By.Id("draggableExample-tab-cursorStyle"));
            
            Sleep(500);

            // Check center cursor
            actionProvider
                .MoveToElement(FindElement(By.Id("cursorCenter")))
                .ClickAndHold()
                .MoveByOffset(200, 200)
                .Release()
                .ContextClick()
                .SendKeys(Keys.Escape)
                .Build()
                .Perform();

            // Check Top Left
            actionProvider
                .MoveToElement(FindElement(By.Id("cursorTopLeft")))
                .ClickAndHold()
                .MoveByOffset(200, 0)
                .Release()
                .ContextClick()
                .SendKeys(Keys.Escape)
                .Build()
                .Perform();

            // Check Bottom
            actionProvider
                .MoveToElement(FindElement(By.Id("cursorBottom")))
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
