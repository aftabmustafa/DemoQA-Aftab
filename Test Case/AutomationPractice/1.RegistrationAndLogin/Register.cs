using OpenQA.Selenium;
using DqLib;
using System.Collections.ObjectModel;

namespace _1.RegistrationAndLogin
{
    internal class Register : SeleniumLib
    {
        public void Run(string Email, string Password)
        {
            try
            {
                StartBrowser("http://automationpractice.com/index.php");

                Sleep(3000);

                JsClick(By.XPath("//a[contains(@href, 'my-account')]"));

                Sleep(3000);

                TextInput(By.XPath("//input[@name='email_create']"), Email);

                Sleep(1500);

                SimpleClick(By.XPath("//button[@id='SubmitCreate']"));

                Sleep(10000);

                CreateAnAccount(Password);

                Sleep(10000);

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);
                CloseBrowser();
            }

            if (Prompt())
                new Login().Run();
        }

        public void CreateAnAccount(string Password)
        {
            string Title = "Male";

            if (Title.Equals("Male"))
            {
                SimpleClick(By.XPath("//input[@id='id_gender1']"));
            }
            else
            {
                SimpleClick(By.XPath("//input[@id='id_gender2']"));
            }

            Sleep(1500);

            // First Name
            TextInput(By.XPath("//input[@id='customer_firstname']"), "Aria");
            Sleep(1500);

            // Last Name
            TextInput(By.XPath("//input[@id='customer_lastname']"), "Label");
            Sleep(1500);

            // Password
            TextInput(By.XPath("//input[@name='passwd']"), Password);
            Sleep(1500);

            /* Select DOB Logic Start */

            SimpleClick(By.Id("days"));
            actionProvider
                .KeyDown(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter)
                .Build()
                .Perform();

            SimpleClick(By.Id("months"));
            actionProvider
            .KeyDown(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter)
            .Build()
            .Perform();

            SimpleClick(By.Id("years"));
            actionProvider
            .KeyDown(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter)
            .Build()
            .Perform();

            /* Select DOB Logic End */

            SimpleClick(By.XPath("//input[@id='newsletter']"));

            Sleep(1500);

            SimpleClick(By.XPath("//input[@id='optin']"));

            Sleep(1500);

            TextInput(By.XPath("//input[@id='company']"), "The Boring Company");

            Sleep(1500);

            TextInput(By.XPath("//input[@id='address1']"), "The Musk Address");

            Sleep(1500);

            TextInput(By.XPath("//input[@id='city']"), "KnowWhere");

            Sleep(2000);

            SimpleClick(By.XPath("//select[@name='id_state']"));

            Sleep(1500);

            ReadOnlyCollection<IWebElement> ChooseState = FindElements(By.XPath("//select[@name='id_state']//option"));

            ChooseState[new System.Random().Next(0, ChooseState.Count)].Click();

            Sleep(2000);

            TextInput(By.XPath("//input[@name='postcode']"), "00000");

            Sleep(2000);

            SimpleClick(By.XPath("//select[@name='id_country']"));

            Sleep(2000);

            SimpleClick(By.XPath("//select[@name='id_country']//option[2]"));

            Sleep(2000);

            TextInput(By.XPath("//textarea[@name='other']"), "Additional Information");

            Sleep(2000);

            TextInput(By.XPath("//input[@name='phone']"), "9191919191");

            Sleep(2000);

            TextInput(By.XPath("//input[@name='phone_mobile']"), "9191919191");
            
            Sleep(2000);

            // Click On Register Button
            SimpleClick(By.Id("submitAccount"));
        }
    }
}
