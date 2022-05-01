using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Threading;

namespace Widgets
{
    class DatePicker
    {
        public void Run(bool Continue)
        {
            IWebDriver Driver = new ChromeDriver();
            Actions actionProvider = new Actions(Driver);

            try
            {
                Driver.Manage().Window.Maximize();

                Driver.Navigate().GoToUrl("https://demoqa.com/date-picker");

                Thread.Sleep(3000);

                TestSelectDate(Driver, actionProvider);

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
                new Slider().Run(Continue);
        }

        static void TestSelectDate(IWebDriver driver, Actions action)
        {
            IWebElement CalendarInput = driver.FindElement(By.XPath("//input[@id='datePickerMonthYearInput']"));
            CalendarInput.Click();

            Thread.Sleep(1000);

            action.MoveToElement(driver.FindElement(By.XPath("//input[@id='datePickerMonthYearInput']")))
                  .KeyDown(Keys.Control)
                  .SendKeys("a")
                  .KeyUp(Keys.Control)
                  .Perform();

            CalendarInput.SendKeys("01 Jan 2023");

            CalendarInput.SendKeys(Keys.Escape);

            // Next Button
            driver.FindElement(By.XPath("//button[text()='Next Month']")).Click();

            // Previous Button
            driver.FindElement(By.XPath("//button[text()='Previous Month']")).Click();

            // Calendar Dropdown test

            // Month Dropdown Test
            IWebElement ClickMonthDropdown = driver.FindElement(By.XPath("//select[contains(@class, 'react-datepicker__month-select')]"));
            ClickMonthDropdown.Click();

            string ExpMonth = "August";

            string CurrMonthYear = driver.FindElement(By.XPath("//div[contains(@class, 'react-datepicker__current-month')]")).Text;
            string[] CurrMonthArrYear = CurrMonthYear.Split();

            ReadOnlyCollection<IWebElement> MonthOptions = ClickMonthDropdown.FindElements(By.TagName("option"));

            if (ExpMonth.Equals(CurrMonthArrYear[0]))
            {
                System.Console.WriteLine("Month Selected");
            }
            else
            {
                foreach (IWebElement MonthOption in MonthOptions)
                {
                    string SelectedMonth = MonthOption.Text;

                    if (SelectedMonth.Equals(ExpMonth))
                    {
                        MonthOption.Click();
                        break;
                    }
                }
            }

            // Dropdown Year Test
            IWebElement ClickDateDropdown = driver.FindElement(By.XPath("//select[contains(@class,'react-datepicker__year-select')]"));
            ClickDateDropdown.Click();

            string ExpYear = "2023";

            ReadOnlyCollection<IWebElement> DateOptions = ClickDateDropdown.FindElements(By.TagName("option"));

            if (ExpYear.Equals(CurrMonthArrYear[1]))
            {
                System.Console.WriteLine("Date Selected");
            }
            else
            {
                foreach (IWebElement DateOption in DateOptions)
                {
                    string SelectedDate = DateOption.Text;

                    if (SelectedDate.Equals(ExpYear))
                    {
                        DateOption.Click();
                        break;
                    }
                }
            }
        }

        static void TestDateTimeCalendar(IWebDriver driver, Actions action)
        {
            driver.FindElement(By.Id("dateAndTimePickerInput")).Click();
            Thread.Sleep(1000);

            driver.SwitchTo().ActiveElement();

            IWebElement DateTimeInput = driver.FindElement(By.XPath("//input[@id='dateAndTimePickerInput']"));

            action.KeyDown(Keys.Control)
                .SendKeys("a")
                .SendKeys(Keys.Delete)
                .SendKeys(Keys.Delete)
                .Build()
                .Perform();
            DateTimeInput.SendKeys("April 24, 2025 06:22 PM");
        }

        static void PickTime(IWebDriver driver, Actions action)
        {
            IWebElement CalendarInput = driver.FindElement(By.XPath("//input[@id='dateAndTimePickerInput']"));
            CalendarInput.Click();

            Thread.Sleep(1000);

            driver.SwitchTo().ActiveElement();

            driver.FindElement(By.XPath("//li[text()='22:45']")).Click();
            Thread.Sleep(1000);
        }
    }
}
