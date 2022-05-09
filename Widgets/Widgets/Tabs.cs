using OpenQA.Selenium;
using DqLib;

namespace Widgets
{
    class Tabs : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/tabs");

                Sleep(3000);

                SimpleClick(By.Id("demo-tab-origin"));

                Sleep(2000);

                SimpleClick(By.Id("demo-tab-use"));

                Sleep(2000);

                SimpleClick(By.Id("demo-tab-what"));

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
                new ToolTips().Run();
        }
    }
}
