using OpenQA.Selenium;
using DqLib;

namespace Widgets
{
    class Accordian : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/accordian");

                Sleep(3000);

                // Toggle Seaction 1 Heading Start
                SimpleClick(By.Id("section1Heading"));

                Sleep(3000);

                SimpleClick(By.Id("section1Heading"));

                // Toggle Seaction 1 Heading End

                Sleep(2000);

                SimpleClick(By.Id("section2Heading"));

                Sleep(2000);

                SimpleClick(By.Id("section3Heading"));

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
                new AutoComplete().Run();
        }
    }
}
