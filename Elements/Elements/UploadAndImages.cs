using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Elements
{
    class UploadAndImages
    {
        public void Run(bool Continue)
        {
            IWebDriver Driver = new ChromeDriver();

            try
            {
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

            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Thread.Sleep(5000);
                Driver.Close();
                Driver.Quit();
            }

            if (Continue)
                new DynamicProperties().Run();
        }
    }
}
