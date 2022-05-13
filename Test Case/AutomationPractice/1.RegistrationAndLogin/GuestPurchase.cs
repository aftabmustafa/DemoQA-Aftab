using OpenQA.Selenium;
using DqLib;

namespace _1.RegistrationAndLogin
{
    internal class GuestPurchase : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("http://automationpractice.com/index.php");

                Sleep(3000);

                Scroll(0, 600);

                actionProvider.MoveToElement(FindElement(By.XPath("//ul[@id='homefeatured']//li"))).Build().Perform();

                Sleep(2000);

                SimpleClick(By.XPath("//ul[@id='homefeatured']//div[contains(@class, 'button-container')]//a"));

                Sleep(3000);

                SimpleClick(By.XPath("//div[@id='layer_cart']//div[contains(@class, 'button-container')]//a"));

                Sleep(3000);

                SimpleClick(By.XPath("//p[contains(@class, 'cart_navigation clearfix')]//a"));

                IWebElement LoginBtn = FindElement(By.XPath("//button[@id='SubmitLogin']"));

                if (LoginBtn.Displayed)
                    System.Console.WriteLine("Guest User Cannot Purchase");
                else
                    System.Console.WriteLine("User is Logged In");

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);
                CloseBrowser();
            }

            if (Prompt())
                new Register().Run("jilekav652@dmosoft.com", "1234567890");     // Provide your email and password for registration
        }
    }
}
