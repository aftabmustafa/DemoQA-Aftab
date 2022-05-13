using OpenQA.Selenium;
using DqLib;

namespace Interactions
{
    class Resizable : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/sortable");

                Sleep(3000);

                //ConstraintBox(Driver, actionProvider);

                FreeBox();

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);

                Sleep(5000);

                CloseBrowser();
            }

            if (Prompt())
                new Droppable().Run();
        }

        public void ConstraintBox()
        {
            var RegularBox = FindElement(By.XPath("//div[@id='resizableBoxWithRestriction']//span[contains(@class,'react-resizable-handle')]"));

            actionProvider.MoveToElement(RegularBox)
                          .ClickAndHold()
                          .MoveByOffset(300, 300)
                          .MoveByOffset(-450, -450)
                          .MoveByOffset(100, 200)
                          .MoveByOffset(200, 100)
                          .Release()
                          .Build()
                          .Perform();
        }

        public void FreeBox()
        {
            var RegularBox = FindElement(By.XPath("//div[@id='resizable']//span[contains(@class,'react-resizable-handle')]"));

            Scroll(0, 600);

            actionProvider.MoveToElement(RegularBox)
                          .ClickAndHold()
                          .MoveByOffset(200, 200)
                          .MoveByOffset(-200, 200)
                          .MoveByOffset(100, 100)
                          .MoveByOffset(200, 200)
                          .Release()
                          .Build()
                          .Perform();
        }
    }
}