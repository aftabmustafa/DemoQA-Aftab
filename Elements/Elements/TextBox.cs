using OpenQA.Selenium;
using DqLib;

namespace Elements
{
    internal class TextBox : SeleniumLib
    {
        public void Run(bool Continue)
        {
            string FName = "Aftab Mustafa";
            string Email = "email@gmail.com";
            string CAddress = "Current Address 1";
            string PAddress = "Permanent Address 2";

            IJavaScriptExecutor Js = (IJavaScriptExecutor)Driver;

            try
            {
                StartBrowser("https://demoqa.com/text-box");

                Sleep(1000);

                TextInput(By.Id("userName"), FName);

                Sleep(1000);

                TextInput(By.Id("userEmail"), Email);

                Sleep(1000);

                TextInput(By.Id("currentAddress"), CAddress);

                Sleep(1000);

                TextInput(By.Id("permanentAddress"), PAddress);

                Sleep(1000);

                //Js.ExecuteScript("window.scrollBy(0, 200)");

                Scroll(0, 200);

                Sleep(1000);

                SimpleClick(By.Id("submit"));

                Sleep(2000);

                CloseBrowser();

            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);
                CloseBrowser();
            }

            if (Continue)
                new CheckBox().Run(Continue);
        }
    }
}
