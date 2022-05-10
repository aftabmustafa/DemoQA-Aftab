using OpenQA.Selenium;
using DqLib;

namespace AlertFramesWindows
{
    class NestedFrames : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/nestedframes");

                Sleep(3000);

                // Number of Frames Inside Default Content
                int CountIFrameInDefault = Driver.FindElements(By.TagName("iframe")).Count;
                System.Console.WriteLine($"Number of Frames inside Default Content: {CountIFrameInDefault}");

                // Locate Frame 1 inside Default Content
                IWebElement Frame1 = Driver.FindElement(By.Id("frame1"));

                Driver.SwitchTo().Frame(Frame1);

                IWebElement Frame1Element = Driver.FindElement(By.TagName("body"));

                string Frame1Text = Frame1Element.Text;
                System.Console.WriteLine($"Content Inside Frame 1 is: {Frame1Text}");

                int CountIFrameInFrame1 = Driver.FindElements(By.TagName("iframe")).Count;
                System.Console.WriteLine($"Number of iframes inside Frame 1: {CountIFrameInFrame1}");

                // Switch to Child Frame
                Driver.SwitchTo().Frame(0);

                string ChildFrameText = Driver.FindElement(By.TagName("p")).Text;

                System.Console.WriteLine($"Text Inside Child Frame: {ChildFrameText}");

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);

                CloseBrowser();
            }

            if (Prompt())
                new ModalDialogs().Run();
        }
    }
}
