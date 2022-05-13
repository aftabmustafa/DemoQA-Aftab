using OpenQA.Selenium;
using DqLib;

namespace Interactions
{
    class Selectable : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/sortable");

                Sleep(3000);

                //TestList();

                TestGrid();

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);

                Sleep(5000);

                CloseBrowser();
            }

            if (Prompt())
                new Resizable().Run();
        }

        public void TestList()
        {
            var ListItems = FindElements(By.XPath("//div[@id='demo-tabpane-list']//li[contains(@class,'list-group-item')]"));

            actionProvider.MoveToElement(ListItems[0])
                          .Click()
                          .MoveToElement(ListItems[1])
                          .Click()
                          .MoveToElement(ListItems[2])
                          .Click()
                          .MoveToElement(ListItems[3])
                          .Click()
                          .MoveToElement(ListItems[0])
                          .Click()
                          .MoveToElement(ListItems[1])
                          .Click()
                          .MoveToElement(ListItems[2])
                          .Click()
                          .MoveToElement(ListItems[3])
                          .Click()
                          .Release()
                          .Build()
                          .Perform();

        }

        public void TestGrid()
        {
            SimpleClick(By.Id("demo-tab-grid"));

            var GridItems = FindElements(By.XPath("//div[@id='demo-tabpane-grid']//li[contains(@class,'list-group-item')]"));

            actionProvider.MoveToElement(GridItems[0])
                          .Click()
                          .MoveToElement(GridItems[3])
                          .Click()
                          .MoveToElement(GridItems[4])
                          .Click()
                          .MoveToElement(GridItems[5])
                          .Click()
                          .MoveToElement(GridItems[8])
                          .Click()
                          .MoveToElement(GridItems[6])
                          .Click()
                          .MoveToElement(GridItems[2])
                          .Click()
                          .MoveToElement(GridItems[1])
                          .Click()
                          .MoveToElement(GridItems[0])
                          .Click()
                          .MoveToElement(GridItems[3])
                          .Click()
                          .MoveToElement(GridItems[4])
                          .Click()
                          .MoveToElement(GridItems[5])
                          .Click()
                          .MoveToElement(GridItems[8])
                          .Click()
                          .MoveToElement(GridItems[6])
                          .Click()
                          .MoveToElement(GridItems[2])
                          .Click()
                          .MoveToElement(GridItems[1])
                          .Click()
                          .Release()
                          .Build()
                          .Perform();
        }
    }
}