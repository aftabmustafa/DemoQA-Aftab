using OpenQA.Selenium;
using System.Runtime.InteropServices;
using DqLib;

namespace Elements  
{
    class Links : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/links");

                Sleep(1000);

                // 1st Link under Open New Tab
                NewTabHandler("simpleLink");

                // 2nd Link under Open New Tab
                //NewTabHandler("dynamicLink");

                Sleep(3000);

                Scroll(0, 150);

                APILinkHandler("created");
                Sleep(1000);

                APILinkHandler("no-content");
                Sleep(2000);

                APILinkHandler("moved");
                Sleep(2000);

                APILinkHandler("bad-request");
                Sleep(2000);

                APILinkHandler("unauthorized");
                Sleep(2000);

                APILinkHandler("forbidden");
                Sleep(2000);

                APILinkHandler("invalid-url");

                Sleep(2000);

                CloseBrowser();
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);
                CloseBrowser();
            }

            if (Prompt())
                new BrokenLinks().Run();
        }

        // Optional is only for learning purpose
        public void NewTabHandler([Optional] string Path)
        {
            SimpleClick(By.Id(Path));

            Sleep(1000);

            Driver.SwitchTo().Window(Driver.WindowHandles[1]);

            Sleep(1000);

            Driver.Close();

            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }

        public void APILinkHandler([Optional] string Path)
        {
            SimpleClick(By.Id(Path));
        }

    }
}
