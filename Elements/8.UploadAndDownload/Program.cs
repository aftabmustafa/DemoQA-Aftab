using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace _8.UploadAndDownload
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();
            IJavaScriptExecutor Js = (IJavaScriptExecutor)Driver;

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/upload-download");

            Thread.Sleep(1000);

            Driver.FindElement(By.Id("downloadButton")).Click();

            Thread.Sleep(3000);

            Driver.FindElement(By.Id("uploadFile")).SendKeys(@"C:\Users\" + System.Environment.UserName + @"\Downloads\sampleFile.jpeg");

            Thread.Sleep(3000);

            Driver.Close();
            Driver.Quit();
        }
    }
}
