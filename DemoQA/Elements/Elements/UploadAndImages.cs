using OpenQA.Selenium;
using DqLib;

namespace Elements
{
    class UploadAndImages : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/upload-download");

                Sleep(1000);

                SimpleClick(By.Id("downloadButton"));

                Sleep(3000);

                //Driver.FindElement(By.Id("uploadFile")).SendKeys(@"C:\Users\" + System.Environment.UserName + @"\Downloads\sampleFile.jpeg");

                UploadFile(By.Id("uploadFile"), @"C:\Users\" + System.Environment.UserName + @"\Downloads\sampleFile.jpeg");

                // This path is only for My Laptop
                //UploadFile(By.Id("uploadFile"), @"C:\Users\gulam\Downloads\sampleFile.jpeg");

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
                new DynamicProperties().Run();
        }
    }
}
