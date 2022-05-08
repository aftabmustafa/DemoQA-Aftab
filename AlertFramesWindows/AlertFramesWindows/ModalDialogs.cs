using OpenQA.Selenium;
using DqLib;

namespace AlertFramesWindows
{
    class ModalDialogs : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/modal-dialogs");

                Sleep(3000);

                // Click On Small Btn
                SimpleClick(By.Id("showSmallModal"));

                Sleep(3000);

                // Close Small Modal
                SimpleClick(By.XPath("//button[@id='closeSmallModal']"));

                Sleep(3000);

                // Click Large Modal
                SimpleClick(By.Id("showLargeModal"));

                Sleep(3000);

                // Close Large Modal
                SimpleClick(By.XPath("//button[@id='closeLargeModal']"));

                Sleep(2000);

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);

                CloseBrowser();
            }
        }
    }
}
