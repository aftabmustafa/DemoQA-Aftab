using OpenQA.Selenium;
using DqLib;

namespace _1.RegistrationAndLogin
{
    internal class Login : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("http://automationpractice.com/index.php");

                Sleep(3000);

                JsClick(By.XPath("//a[contains(@href, 'my-account')]"));

                Sleep(3000);

                TextInput(By.Id("email"), "jilekav652@dmosoft.com");

                Sleep(2000);

                TextInput(By.Id("passwd"), "1234567890");

                Sleep(2000);

                SimpleClick(By.Id("SubmitLogin"));

                Sleep(8000);

                CloseBrowser();
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);

                CloseBrowser();
            }
        }
    }
}
