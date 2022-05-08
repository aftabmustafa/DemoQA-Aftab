using OpenQA.Selenium;
using DqLib;

namespace AlertFramesWindows
{
    class Alerts : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/alerts");

                Sleep(3000);

                SimpleAlert(Driver);
                Sleep(1000);

                TimedAlert(Driver);
                Sleep(1000);

                ConfirmAlert(Driver);
                Sleep(1000);

                PromptAlert(Driver);
                Sleep(1000);

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);
               
                CloseBrowser();
            }

            if (Prompt())
                new Frames().Run();
        }

        public void SimpleAlert(IWebDriver driver)
        {
            SimpleClick(By.Id("alertButton"));

            Sleep(2000);

            var AlertWin = driver.SwitchTo().Alert();

            AlertWin.Accept();
        }

        public void TimedAlert(IWebDriver driver)
        {
            SimpleClick(By.Id("timerAlertButton"));

            Sleep(6000);

            var AlertWin = driver.SwitchTo().Alert();
            AlertWin.Accept();
        }

        public void ConfirmAlert(IWebDriver driver)
        {
            SimpleClick(By.Id("confirmButton"));

            Sleep(2000);

            var AlertWin = driver.SwitchTo().Alert();

            AlertWin.Accept();
        }

        public void PromptAlert(IWebDriver driver)
        {
            SimpleClick(By.Id("promtButton"));

            Sleep(2000);

            var AlertWin = driver.SwitchTo().Alert();

            AlertWin.SendKeys("Hello World");

            Sleep(2000);

            AlertWin.Accept();
        }
    }
}
