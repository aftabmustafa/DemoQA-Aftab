using OpenQA.Selenium;
using DqLib;

namespace Widgets
{
    class AutoComplete : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/auto-complete");

                Sleep(3000);

                TestMultiple();

                TestSingle();

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);

                CloseBrowser();
            }

            if (Prompt())
                new DatePicker().Run();
        }
        
        public void TestMultiple()
        {
            IWebElement InputBox = FindElement(By.Id("autoCompleteMultipleInput"));

            InputBox.SendKeys("ee");
            Sleep(1000);
            InputBox.SendKeys(Keys.Enter);

            InputBox.SendKeys("Bl");
            Sleep(500);

            InputBox.SendKeys(Keys.ArrowDown);
            Sleep(1000);

            InputBox.SendKeys(Keys.Enter);
        }

        public void TestSingle()
        {
            IWebElement InputBox = FindElement(By.Id("autoCompleteSingleInput"));

            InputBox.SendKeys("ee");
            Sleep(1000);
            InputBox.SendKeys(Keys.Enter);
        }

    }
}
