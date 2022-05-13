using OpenQA.Selenium;
using System.Collections.ObjectModel;
using DqLib;

namespace PracticeForm
{
    internal class Form : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/automation-practice-form");

                Sleep(2000);

                RegistrationForm(Driver, Js);

                Sleep(5000);

                Driver.SwitchTo().ActiveElement();

                JsClick(By.XPath("//button[@id='closeLargeModal']"));

                CloseBrowser();
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);

                CloseBrowser();
            }
        }

        public void RegistrationForm(IWebDriver driver, IJavaScriptExecutor js)
        {
            TextInput(By.XPath("//input[@id='firstName']"), "Aria");

            Sleep(1000);

            TextInput(By.XPath("//input[@id='lastName']"), "Label");

            Sleep(1000);

            TextInput(By.XPath("//input[@id='userEmail']"), "aria@gmail.com");

            Sleep(1000);

            ChooseGender("//input[@value='Male']");
            Sleep(1000);

            ChooseGender("//input[@value='Female']");
            Sleep(1000);

            ChooseGender("//input[@value='Other']");
            Sleep(1000);

            ChooseGender("//input[@value='Male']");
            Sleep(1000);

            TextInput(By.XPath("//input[@id='userNumber']"), "9191919191");

            CalendarKeyboardInput(By.XPath("//input[@id='dateOfBirthInput']"), "01 Jan 2023");

            Sleep(2000);

            AutoCompleteSubject();

            Sleep(2000);

            // Set Zoom level to 80%
            Js.ExecuteScript("document.body.style.zoom='80%'");

            Sleep(2000);

            Hobbies();

            Sleep(1000);

            //Upload();

            Sleep(2000);

            CurrentAddress();

            Sleep(2000);

            SelectStateCity();
        }

        public void ChooseGender(string xpath)
        {
            JsClick(By.XPath(xpath));
        }

        // This needs little bit of improvement
        public void TestCalendarInput()
        {
            Driver.FindElement(By.XPath("//input[@id='dateOfBirthInput']")).Click();

            // Expected Month
            string ExpMonth = "July 2022";

            // Current Month
            string CurrMonth = Driver.FindElement(By.XPath("//div[contains(@class, 'react-datepicker__current-month')]")).Text;

            if (ExpMonth.Equals(CurrMonth))
            {
                System.Console.WriteLine("Month Selected");
            }
            else
            {
                for (int i = 1; i < 12; i++)
                {
                    JsClick(By.XPath("//button[text()='Next Month']"));

                    Sleep(1000);

                    CurrMonth = Driver.FindElement(By.XPath("//div[contains(@class, 'react-datepicker__current-month')]")).Text;

                    if (ExpMonth.Equals(CurrMonth))
                    {
                        System.Console.WriteLine("Month Selected");
                        break;
                    }
                }
            }

            Sleep(2000);


            // Uncomment Next and Previous btn logic to test
            // Next Button
            //SimpleClick(By.XPath("//button[text()='Next Month']"));

            // Previous Button
            //SimpleClick(By.XPath("//button[text()='Previous Month']"));

        }

        public void TestCalendarDropdown()
        {
            //driver.FindElement(By.XPath("//input[@id='dateOfBirthInput']")).Click();
            SimpleClick(By.XPath("//input[@id='dateOfBirthInput']"));

            // Dropdown Month Test
            IWebElement ClickMonthDropdown = Driver.FindElement(By.XPath("//select[contains(@class, 'react-datepicker__month-select')]"));
            //ClickMonthDropdown.Click();
            SimpleClick(ClickMonthDropdown);

            string ExpMonth = "August";

            string CurrMonthYear = Driver.FindElement(By.XPath("//div[contains(@class, 'react-datepicker__current-month')]")).Text;
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
            IWebElement ClickDateDropdown = Driver.FindElement(By.XPath("//select[contains(@class,'react-datepicker__year-select')]"));
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

        public void AutoCompleteSubject()
        {
            IWebElement InputBox = Driver.FindElement(By.XPath("//input[@id='subjectsInput']"));

            InputBox.SendKeys("a");

            Sleep(2000);

            InputBox.SendKeys(Keys.ArrowDown);
            Sleep(1000);
            InputBox.SendKeys(Keys.Enter);

            InputBox.SendKeys("b");

            Sleep(2000);

            InputBox.SendKeys(Keys.Enter);

            InputBox.SendKeys("c");

            Sleep(2000);

            InputBox.SendKeys(Keys.ArrowDown);
            Sleep(1000);

            InputBox.SendKeys(Keys.ArrowDown);
            Sleep(1000);

            InputBox.SendKeys(Keys.Enter);

            Sleep(2000);

            Driver.SwitchTo().ActiveElement();

            // Clear All Input
            //actionProvider.MoveToElement(driver.FindElement(By.XPath("//div[contains(@class, 'subjects-auto-complete__clear-indicator')]"))).Click().Build().Perform();
            //Sleep(3000);

            // Clear Random Input
            IWebElement AutoCompleteParent = Driver.FindElement(By.XPath("//div[contains(@class, 'subjects-auto-complete__value-container')]"));

            ReadOnlyCollection<IWebElement> AutoCompleteClear = AutoCompleteParent.FindElements(By.XPath("//div[contains(@class, 'subjects-auto-complete__multi-value__remove')]"));

            actionProvider.Click(AutoCompleteClear[new System.Random().Next(0, AutoCompleteClear.Count)]).Build().Perform();

            Sleep(3000);

        }

        public void Hobbies()
        {
            JsClick(By.XPath("//input[@id='hobbies-checkbox-1']"));

            Sleep(2000);

            JsClick(By.XPath("//input[@id='hobbies-checkbox-2']"));

            Sleep(2000);

            JsClick(By.XPath("//input[@id='hobbies-checkbox-3']"));
        }

        public void Upload()
        {
            // Please provide a sample file to upload or comment to continue
            UploadFile(By.XPath("//input[@id='uploadPicture']"), @"C:\Users\" + System.Environment.UserName + @"\Downloads\sampleFile.jpeg");
        }

        public void CurrentAddress()
        {
            TextInput(By.XPath("//textarea[@id='currentAddress']"), "Kumbha Karan er Bari");
        }

        public void SelectStateCity()
        {
            IWebElement StateInputBox = Driver.FindElement(By.XPath("//input[@id='react-select-3-input']"));

            StateInputBox.SendKeys("a");
            Sleep(2000);
            StateInputBox.SendKeys(Keys.Enter);

            Sleep(2000);

            IWebElement CityInputBox = Driver.FindElement(By.XPath("//input[@id='react-select-4-input']"));

            CityInputBox.SendKeys("L");
            Sleep(2000);
            CityInputBox.SendKeys(Keys.Enter);

            JsClick(By.XPath("//button[@id='submit']"));
        }
    }
}
