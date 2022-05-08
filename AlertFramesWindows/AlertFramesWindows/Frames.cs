using OpenQA.Selenium;
using DqLib;

namespace AlertFramesWindows
{
    class Frames : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/frames");

                Sleep(3000);

                // Different Ways to Switch Frame
                // 1.
                //Driver.SwitchTo().Frame(0);

                // 2.
                Driver.SwitchTo().Frame("frame1");

                //Heading Id of First Frame
                IWebElement Frame1Heading = Driver.FindElement(By.Id("sampleHeading"));

                string Frame1Text = Frame1Heading.Text;

                System.Console.WriteLine(Frame1Text);

                Driver.SwitchTo().ParentFrame();

                // 1.
                //Driver.SwitchTo().Frame(1);

                // 2.
                Driver.SwitchTo().Frame("frame2");

                // Heading Id of Second Frame
                IWebElement Frame2Heading = Driver.FindElement(By.Id("sampleHeading"));
                string Frame2Text = Frame2Heading.Text;

                System.Console.WriteLine(Frame2Text);

                CloseBrowser();
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);

                CloseBrowser();
            }

            if (Prompt())
                new NestedFrames().Run();
        }
    }
}
