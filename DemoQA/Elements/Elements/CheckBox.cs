using OpenQA.Selenium;
using DqLib;

namespace Elements
{
    internal class CheckBox : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/checkbox");

                Sleep(2000);

                ExpandArrow();

                Sleep(2000);

                SelectCheckBox();

                Sleep(2000);

                RightCollapseBtn();

                Sleep(2000);

                RightExpandBtn();

                Sleep(5000);

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(5000);
                
                CloseBrowser();
            }

            if (Prompt())
                new RadioButton().Run();
        }

        public void ExpandArrow()
        {
            FindElements(By.XPath("//button[@title='Toggle']"))[0].Click();
            Sleep(2000);

            FindElements(By.XPath("//button[@title='Toggle']"))[1].Click();
            Sleep(2000);

            FindElements(By.XPath("//button[@title='Toggle']"))[2].Click();
            Sleep(2000);

            FindElements(By.XPath("//button[@title='Toggle']"))[3].Click();
            Sleep(2000);

            FindElements(By.XPath("//button[@title='Toggle']"))[4].Click();
            Sleep(2000);

            FindElements(By.XPath("//button[@title='Toggle']"))[5].Click();
            Sleep(2000);
        }

        public void SelectCheckBox()
        {
            // Click on Home Folder Icon
            SimpleClick(By.XPath("//span[text()='Home']"));
        }

        public void RightExpandBtn()
        {
            // Using Class
            SimpleClick(By.ClassName("rct-option-expand-all"));

            // Using XPath
            //SimpleClick(By.XPath("//button[contains(@class,'rct-option-expand-all')]"));
        }

        public void RightCollapseBtn()
        {
            // Using Class
            SimpleClick(By.ClassName("rct-option-collapse-all"));

            // Using XPath
            //SimpleClick(By.XPath("//button[contains(@class,'rct-option-collapse-all')]"));
        }
    }
}
