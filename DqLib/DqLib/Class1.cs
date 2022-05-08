using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Threading;
using System.Net;

namespace DqLib
{
    public class SeleniumLib
    {
        public IWebDriver Driver;
        public IJavaScriptExecutor Js;
        public Actions actionProvider;

        public void StartBrowser(string url)
        {
            Driver = new ChromeDriver();

            Js = (IJavaScriptExecutor)Driver;

            actionProvider = new Actions(Driver);

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl(url);
        }

        public void FindElement(By by)
        {
            Driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Driver.FindElements(by);
        }

        public bool Prompt()
        {
            Console.WriteLine("Do you want to continue?(Y/N): ");
            string UserChoice = Console.ReadLine();

            if (UserChoice == "Y" || UserChoice == "y")
                return true;
            else
                return false;
        }

        public void CalendarKeyboardInput(By by,string input)
        {
            IWebElement CalInputBox = Driver.FindElement(by);
            CalInputBox.Click();

            Thread.Sleep(2000);

            actionProvider.MoveToElement(Driver.FindElement(by))
                          .KeyDown(Keys.Control)
                          .SendKeys("a")
                          .KeyUp(Keys.Control)
                          .Perform();

            CalInputBox.SendKeys(input);

            CalInputBox.SendKeys(Keys.Escape);
        }

        public void TextInput(By by, string input)
        {
            Driver.FindElement(by).SendKeys(input);
        }

        public void ClearTextInput(By by)
        {
            Driver.FindElement(by).Clear();
        }

        public void ActionClearInput(By by)
        {
            IWebElement e = Driver.FindElement(by);

            actionProvider.MoveToElement(e)
                .KeyDown(Keys.Control)
                .SendKeys("a")
                .KeyUp(Keys.Control)
                .SendKeys(Keys.Backspace)
                .Perform();
        }

        public void Scroll(int X, int Y)
        {
            Js.ExecuteScript($"window.scrollBy({X}, {Y})");
        }

        public void ClickUsingIndex(By by, int i)
        {
            Driver.FindElements(by)[i].Click();
        }

        public void SimpleClick(By by)
        {
            Driver.FindElement(by).Click();
        }

        public void SimpleClick(IWebElement WebElement)
        {
            WebElement.Click();
        }

        public void JsClick(By by)
        {
            IWebElement e = Driver.FindElement(by);
            Js.ExecuteScript("arguments[0].click()", e);
        }

        public void DoubleClick(By by)
        {
            actionProvider.MoveToElement(Driver.FindElement(by))
                          .DoubleClick()
                          .Build()
                          .Perform();
        }

        public void ContextClick(By by)
        {
            actionProvider.MoveToElement(Driver.FindElement(by))
                          .ContextClick()
                          .Build()
                          .Perform();
        }

        public void Sleep(int time)
        {
            Thread.Sleep(time);
        }

        public void UploadFile(By by, string path)
        {
            Driver.FindElement(by).SendKeys(path);
        }

        public string ValidateImage(IWebElement e)
        {
            Boolean IsValid = (Boolean)(Js.ExecuteScript("return arguments[0].complete" + "&& typeof arguments[0].naturalWidth != \"undefined\" " + "&& arguments[0].naturalWidth > 0", e));

            if (IsValid)
            {
                return "Valid Image";
            }
            else
            {
                return "Invalid Image";
            }
        }

        public string ValidateUrl(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            request.AllowAutoRedirect = true;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.Close();
                    return $"Response Status Code is OK and Status Description is {response.StatusDescription}";
                }
                else
                {
                    return $"Response Status Code is NOT Ok and Status Description is {response.StatusDescription}";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public void CloseBrowser()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
