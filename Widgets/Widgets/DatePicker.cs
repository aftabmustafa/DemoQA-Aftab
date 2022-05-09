using OpenQA.Selenium;
using System.Collections.ObjectModel;
using DqLib;

namespace Widgets
{
    class DatePicker : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/date-picker");

                Sleep(3000);

                TestSelectDate();

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);

                CloseBrowser();
            }

            if (Prompt())
                new Slider().Run();
        }

        public void TestSelectDate()
        {
            IWebElement CalendarInput = FindElement(By.XPath("//input[@id='datePickerMonthYearInput']"));
            CalendarInput.Click();

            Sleep(1000);

            actionProvider.MoveToElement(CalendarInput)
                          .KeyDown(Keys.Control)
                          .SendKeys("a")
                          .KeyUp(Keys.Control)
                          .Perform();

            CalendarInput.SendKeys("01 Jan 2023");

            CalendarInput.SendKeys(Keys.Escape);

            // Next Button
            SimpleClick(By.XPath("//button[text()='Next Month']"));

            // Previous Button
            SimpleClick(By.XPath("//button[text()='Previous Month']"));

            // Calendar Dropdown test

            // Month Dropdown Test
            IWebElement ClickMonthDropdown = FindElement(By.XPath("//select[contains(@class, 'react-datepicker__month-select')]"));
            ClickMonthDropdown.Click();

            string ExpMonth = "August";

            string CurrMonthYear = FindElement(By.XPath("//div[contains(@class, 'react-datepicker__current-month')]")).Text;
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
            IWebElement ClickDateDropdown = FindElement(By.XPath("//select[contains(@class,'react-datepicker__year-select')]"));
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

        public void TestDateTimeCalendar()
        {
            SimpleClick(By.Id("dateAndTimePickerInput"));
            Sleep(1000);

            Driver.SwitchTo().ActiveElement();

            IWebElement DateTimeInput = FindElement(By.XPath("//input[@id='dateAndTimePickerInput']"));

            actionProvider.KeyDown(Keys.Control)
                          .SendKeys("a")
                          .SendKeys(Keys.Delete)
                          .SendKeys(Keys.Delete)
                          .Build()
                          .Perform();

            DateTimeInput.SendKeys("April 24, 2025 06:22 PM");
        }

        public void PickTime()
        {
            SimpleClick(By.XPath("//input[@id='dateAndTimePickerInput']"));

            Sleep(1000);

            Driver.SwitchTo().ActiveElement();

            SimpleClick(By.XPath("//li[text()='22:45']"));

            Sleep(1000);
        }
    }
}
