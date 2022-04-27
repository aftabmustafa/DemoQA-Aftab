using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Frames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://demoqa.com/frames");

            Thread.Sleep(3000);

            // Different Ways to Switch Frame
            // 1.
            //Driver.SwitchTo().Frame(0);

            // 2.
            Driver.SwitchTo().Frame("frame1");

            //Heading Id of First Frame
            IWebElement Frame1Heading = Driver.FindElement(By.Id("sampleHeading"));

            string Frame1Text = Frame1Heading.Text;

            System.Console.WriteLine(Frame1Text);

            Driver.SwitchTo().ParentFrame();

            // 1.
            //Driver.SwitchTo().Frame(1);

            // 2.
            Driver.SwitchTo().Frame("frame2");

            // Heading Id of Second Frame
            IWebElement Frame2Heading = Driver.FindElement(By.Id("sampleHeading"));
            string Frame2Text = Frame2Heading.Text;

            System.Console.WriteLine(Frame2Text);

            _ = 0;
            
            Driver.Close();
            Driver.Quit();
        }
    }
}
