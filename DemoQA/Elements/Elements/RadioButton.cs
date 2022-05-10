using OpenQA.Selenium;
using DqLib;

namespace Elements
{
    internal class RadioButton : SeleniumLib
    {
        public void Run()
        {
            try
            { 
                StartBrowser("https://demoqa.com/radio-button");

                Sleep(1000);

                JsClick(By.Id("yesRadio"));

                Sleep(1000);

                JsClick(By.Id("impressiveRadio"));

                Sleep(3000);

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);
                CloseBrowser();
            }

            if (Prompt())
                new WebTables().Run();
        }
    }
}
