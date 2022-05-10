using OpenQA.Selenium;
using System.Collections.ObjectModel;
using DqLib;

namespace Elements
{
    class BrokenLinks : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/broken");

                Sleep(1000);

                ReadOnlyCollection<IWebElement> ImgElement = Driver.FindElements(By.TagName("img"));

                // Valid Image Index
                System.Console.WriteLine(ValidateImage(ImgElement[2]));


                // Broken Image Index
                //System.Console.WriteLine(ValidateImage(ImgElement[3]));

                // Valid URL
                IWebElement FirstUrl = Driver.FindElement(By.XPath("//a[text()='Click Here for Valid Link']"));
                string FirstUrlHref = FirstUrl.GetAttribute("href");
                System.Console.WriteLine(ValidateUrl(FirstUrlHref));

                // Invalid URL
                //IWebElement SecondUrl = Driver.FindElement(By.XPath("//a[text()='Click Here for Broken Link']"));
                //string SecondUrlHref = SecondUrl.GetAttribute("href");
                //System.Console.WriteLine(ValidateUrl(SecondUrlHref));

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);
                CloseBrowser();
            }

            if (Prompt())
                new UploadAndImages().Run();
        }

    }
}
