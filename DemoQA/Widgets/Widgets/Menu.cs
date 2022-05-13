using OpenQA.Selenium;
using DqLib;

namespace Widgets
{
    class Menu : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/menu");

                Sleep(3000);

                IWebElement MainItem1 = FindElement(By.XPath("//a[text()='Main Item 1']"));
                actionProvider.MoveToElement(MainItem1);

                Sleep(2000);

                IWebElement MainItem2 = FindElement(By.XPath("//a[text()='Main Item 2']"));
                actionProvider.MoveToElement(MainItem2);

                Sleep(2000);

                IWebElement MainItem2__SubItem = FindElement(By.XPath("//a[text()='SUB SUB LIST »']"));
                actionProvider.MoveToElement(MainItem2__SubItem);

                Sleep(2000);

                IWebElement SubSubItem1 = FindElement(By.XPath("//a[text()='Sub Sub Item 1']"));
                actionProvider.MoveToElement(SubSubItem1);

                Sleep(2000);

                IWebElement SubSubItem2 = FindElement(By.XPath("//a[text()='Sub Sub Item 2']"));
                actionProvider.MoveToElement(SubSubItem2);

                CloseBrowser();
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);

                CloseBrowser();
            }

            if (Prompt())
                new SelectMenu().Run();
        }
    }
}
