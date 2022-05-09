using OpenQA.Selenium;
using DqLib;

namespace Interactions
{
    class Sortable : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/sortable");

                Sleep(3000);

                //TestNormalList();

                TestGrid();

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);

                CloseBrowser();
            }

            if(Prompt()) 
                new Selectable().Run();
        }

        public void TestNormalList()
        {
            var ListItems = FindElements(By.XPath("//div[@id='demo-tabpane-list']//div[contains(@class,'list-group-item')]"));

            actionProvider.MoveToElement(ListItems[1])
                          .ClickAndHold()
                          .MoveToElement(ListItems[3])
                          .Release()
                          .MoveToElement(ListItems[4])
                          .ClickAndHold()
                          .MoveToElement(ListItems[5])
                          .Release()
                          .MoveToElement(ListItems[0])
                          .ClickAndHold()
                          .MoveToElement(ListItems[3])
                          .Release()
                          .Build()
                          .Perform();
        }

        public void TestGrid()
        {
            SimpleClick(By.Id("demo-tab-grid"));

            var GridItems = FindElements(By.XPath("//div[@id='demo-tabpane-grid']//div[contains(@class,'list-group-item')]"));

            actionProvider.MoveToElement(GridItems[0])
                          .ClickAndHold()
                          .MoveToElement(GridItems[3])
                          .MoveToElement(GridItems[4])
                          .MoveToElement(GridItems[5])
                          .MoveToElement(GridItems[8])
                          .MoveToElement(GridItems[6])
                          .MoveToElement(GridItems[2])
                          .MoveToElement(GridItems[1])
                          .Release()
                          .Build()
                          .Perform();
        }
    }
}
