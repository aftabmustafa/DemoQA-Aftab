using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading;

namespace _7.BrokenLinks_Images
{
    internal class Program
    {
        // Put breakpoints inside ValidateImage() and ValidateHttpLink() methods to see Console Output
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();
            IJavaScriptExecutor Js = (IJavaScriptExecutor)Driver;

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/broken");

            Thread.Sleep(1000);

            ReadOnlyCollection<IWebElement> ImgElement = Driver.FindElements(By.TagName("img"));

            // Valid Image Index
            ValidateImage(Js, ImgElement[2]);


            // Broken Image Index
            //ValidateImage(Js, ImgElement[3]);

            // Valid URL
            IWebElement FirstUrl = Driver.FindElement(By.XPath("//a[text()='Click Here for Valid Link']"));
            string FirstUrlHref = FirstUrl.GetAttribute("href");
            ValidateHttpLink(FirstUrlHref);

            // Invalid URL
            //IWebElement SecondUrl = Driver.FindElement(By.XPath("//a[text()='Click Here for Broken Link']"));
            //string SecondUrlHref = SecondUrl.GetAttribute("href");
            //ValidateHttpLink(SecondUrlHref);

            Driver.Close();
            Driver.Quit();

        }

        static void ValidateImage(IJavaScriptExecutor js, IWebElement imgElement)
        {
            Boolean IsValid = (Boolean)(js.ExecuteScript("return arguments[0].complete" + "&& typeof arguments[0].naturalWidth != \"undefined\" " + "&& arguments[0].naturalWidth > 0", imgElement));

            if (IsValid)            // Breakpoint waiting for you here!
            {
                System.Console.WriteLine("Valid Image");
            }
            else
            {
                System.Console.WriteLine("Invalid Image");
            }
        }

        static bool ValidateHttpLink(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            request.AllowAutoRedirect = true;

            try                     // Breakpoint waiting for you here!
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("\nResponse Status Code is OK and StatusDescription is: {0}", response.StatusDescription);
                    response.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}