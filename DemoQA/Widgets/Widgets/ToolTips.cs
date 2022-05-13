using OpenQA.Selenium;
using DqLib;

namespace Widgets
{
    class ToolTips : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/tool-tips");

                Sleep(6000);

                IWebElement HoverBtn = FindElement(By.Id("toolTipButton"));
                actionProvider.MoveToElement(HoverBtn).Perform();
                Sleep(2000);

                IWebElement InputBoxHover = FindElement(By.Id("toolTipTextField"));
                actionProvider.MoveToElement(InputBoxHover).Perform();
                Sleep(2000);

                IWebElement AnchorHover = FindElement(By.XPath("//a[text()='Contrary']"));
                actionProvider.MoveToElement(AnchorHover).Perform();
                Sleep(2000);

                IWebElement DateHover = FindElement(By.XPath("//a[text()='1.10.32']"));
                actionProvider.MoveToElement(DateHover).Perform();

                CloseBrowser();
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);

                CloseBrowser();
            }

            if (Prompt())
                new Menu().Run();
        }
    }
}
