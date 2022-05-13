using OpenQA.Selenium;
using DqLib;

namespace Widgets
{
    class ProgressBar : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/progress-bar");

                Sleep(3000);

                var ProgressControlBtn = FindElement(By.Id("startStopButton"));

                ProgressControlBtn.Click();

                Sleep(new System.Random().Next(3, 8) * 1000);

                ProgressControlBtn.Click();

                CloseBrowser();
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);

                CloseBrowser();
            }

            if (Prompt())
                new Tabs().Run();
        }
    }
}
