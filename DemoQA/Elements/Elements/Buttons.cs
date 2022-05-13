using OpenQA.Selenium;
using DqLib;

namespace Elements
{
    class Buttons : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/buttons");

                Sleep(2000);

                DoubleClick(By.Id("doubleClickBtn"));

                Sleep(2000);

                ContextClick(By.Id("rightClickBtn"));

                Sleep(2000);

                // Single Click using CSS
                ClickUsingIndex(By.ClassName("btn-primary"), 2);


                // Single Click using XPath
                SimpleClick(By.XPath("//button[text()='Click Me']"));

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
                new Links().Run();
        }
    }
}
