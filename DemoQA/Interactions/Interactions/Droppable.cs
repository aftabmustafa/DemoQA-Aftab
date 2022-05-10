using OpenQA.Selenium;
using DqLib;

namespace Interactions
{
    class Droppable : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/droppable");

                Sleep(3000);

                TestSimpleDroppable();
                Sleep(2000);

                TestAccept();
                Sleep(2000);

                PreventPropogation();
                Sleep(2000);

                SwitchToRevert();
                Sleep(2000);

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);

                Sleep(5000);

                CloseBrowser();
            }

            if (Prompt())
                new Dragabble().Run();
        }

        public void TestSimpleDroppable()
        {
            var DragElement = FindElement(By.XPath("//div[@id='simpleDropContainer']//div[@id='draggable']"));

            var DropBoxElement = FindElement(By.XPath("//div[@id='simpleDropContainer']//div[@id='droppable']"));

            actionProvider.MoveToElement(DragElement)
                          .ClickAndHold()
                          .MoveToElement(DropBoxElement)
                          .Release()
                          .Build()
                          .Perform();
        }

        public void TestAccept()
        {
            SimpleClick(By.Id("droppableExample-tab-accept"));

            IWebElement ParentElement = FindElement(By.Id("acceptDropContainer"));

            IWebElement AcceptDrop = FindElement(By.Id("acceptable"));

            IWebElement DiscardDrop = FindElement(By.XPath("//div[@id='acceptDropContainer']//div[@id='notAcceptable']"));

            IWebElement DroppableBox = FindElement(By.XPath("//div[@id='acceptDropContainer']//div[@id='droppable']"));

            // Drop Acceptable
            actionProvider.MoveToElement(AcceptDrop)
                          .ClickAndHold()
                          .MoveToElement(DroppableBox)
                          .MoveToElement(ParentElement)
                          .Release()
                          .Build()
                          .Perform();

            // Drop Not Acceptavle
            actionProvider.MoveToElement(DiscardDrop)
                          .ClickAndHold()
                          .MoveToElement(DroppableBox)
                          .Release()
                          .Build()
                          .Perform();
        }

        public void PreventPropogation()
        {
            SimpleClick(By.Id("droppableExample-tab-preventPropogation"));

            actionProvider.MoveToElement(FindElement(By.Id("dragBox")))
                          .ClickAndHold()
                          .MoveToElement(FindElement(By.Id("notGreedyInnerDropBox")))
                          .Release()
                          .Build()
                          .Perform();

            actionProvider.MoveToElement(FindElement(By.Id("dragBox")))
                          .ClickAndHold()
                          .MoveToElement(FindElement(By.Id("greedyDropBox")))
                          .Release()
                          .ClickAndHold()
                          .MoveToElement(FindElement(By.Id("greedyDropBoxInner")))
                          .Release()
                          .Build()
                          .Perform();
        }

        public void SwitchToRevert()
        {
            SimpleClick(By.Id("droppableExample-tab-revertable"));

            IWebElement RevertBox = FindElement(By.Id("revertable"));

            IWebElement NotRevertBox = FindElement(By.Id("notRevertable"));

            IWebElement DroppableBox = FindElement(By.XPath("//div[@class='revertable-drop-container']//div[@id='droppable']"));

            actionProvider.MoveToElement(RevertBox)
                          .ClickAndHold()
                          .MoveToElement(DroppableBox)
                          .Release()
                          .Build()
                          .Perform();

            actionProvider.MoveToElement(NotRevertBox)
                          .ClickAndHold()
                          .MoveToElement(DroppableBox)
                          .Release()
                          .Build()
                          .Perform();
        }
    }
}
