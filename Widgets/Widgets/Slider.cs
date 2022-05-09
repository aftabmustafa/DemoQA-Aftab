using OpenQA.Selenium;
using DqLib;

namespace Widgets
{
    class Slider : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/slider");

                Sleep(3000);

                IWebElement InputSlider = FindElement(By.XPath("//input[contains(@class, 'range-slider')]"));
                actionProvider.MoveToElement(InputSlider)
                              .ClickAndHold()
                              .MoveByOffset(08, 0)
                              .MoveByOffset(-6, 0)
                              .MoveByOffset(-18, 0)
                              .MoveByOffset(16, 0)
                              .MoveByOffset(20, 0)
                              .Build()
                              .Perform();

                CloseBrowser();
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);

                CloseBrowser();
            }

            if (Prompt())
                new ProgressBar().Run();
        }
    }
}
