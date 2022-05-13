using OpenQA.Selenium;
using DqLib;

namespace BookStoreApplication
{
    class Login : SeleniumLib
    {
        static void Main(string[] args)
        {
            new Login().Run();
        }

        public void Run()
        {
            string username = "aria";
            string password = "@riaLabel2022";

            StartBrowser("https://demoqa.com/login");

            Sleep(3000);

            UserLogin(username, password);

            RedirectBookStore();

            CloseBrowser();
        }

        public void UserLogin(string uName, string pass)
        {
            TextInput(By.Id("userName"), uName);

            TextInput(By.Id("password"), pass);

            Sleep(1000);

            SimpleClick(By.Id("login"));
            
            Sleep(2500);
        }

        static void RedirectBookStore()
        {
            new BookStore().Home();
        }
    }
}
