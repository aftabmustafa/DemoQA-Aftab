using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Threading;


namespace PracticeForm
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();
            IJavaScriptExecutor Js = (IJavaScriptExecutor)Driver;

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

            Thread.Sleep(2000);

            RegistrationForm(Driver, Js);

            Thread.Sleep(5000);

            Driver.SwitchTo().ActiveElement();

            IWebElement CloseModalBtn = Driver.FindElement(By.XPath("//button[@id='closeLargeModal']"));
            Js.ExecuteScript("arguments[0].click()", CloseModalBtn);

            // Press Continue to Exit Script
            _ = 0;

            Driver.Close();
            Driver.Quit();
        }

        static void RegistrationForm(IWebDriver driver, IJavaScriptExecutor js)
        {
            IWebElement FName = driver.FindElement(By.XPath("//input[@id='firstName']"));
            FName.SendKeys("Aria");

            Thread.Sleep(1000);

            IWebElement LName = driver.FindElement(By.XPath("//input[@id='lastName']"));
            LName.SendKeys("Label");

            Thread.Sleep(1000);

            IWebElement Email = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            Email.SendKeys("aria@gmail.com");

            Thread.Sleep(1000);

            ChooseGender(driver, js, "//input[@value='Male']");
            Thread.Sleep(1000);

            ChooseGender(driver, js, "//input[@value='Female']");
            Thread.Sleep(1000);

            ChooseGender(driver, js, "//input[@value='Other']");
            Thread.Sleep(1000);

            ChooseGender(driver, js, "//input[@value='Male']");
            Thread.Sleep(1000);

            IWebElement Number = driver.FindElement(By.XPath("//input[@id='userNumber']"));
            Number.SendKeys("9191919191");

            TestCalendarKeyboardInput(driver, js);

            Thread.Sleep(2000);

            AutoCompleteSubject(driver, js);

            Thread.Sleep(2000);

            // Set Zoom level to 80%
            js.ExecuteScript("document.body.style.zoom='80%'");

            Thread.Sleep(2000);

            Hobbies(driver, js);

            Thread.Sleep(1000);

            Upload(driver);

            Thread.Sleep(2000);

            CurrentAddress(driver);

            Thread.Sleep(2000);

            SelectStateCity(driver, js);
        }

        static void ChooseGender(IWebDriver driver, IJavaScriptExecutor js, string xpath)
        {
            IWebElement SelectGender = driver.FindElement(By.XPath(xpath));
            js.ExecuteScript("arguments[0].click()", SelectGender);
        }

        static void TestCalendarKeyboardInput(IWebDriver driver, IJavaScriptExecutor js)
        {
            Actions action = new Actions(driver);
            IWebElement CalInputBox = driver.FindElement(By.XPath("//input[@id='dateOfBirthInput']"));
            CalInputBox.Click();

            Thread.Sleep(2000);

            action.MoveToElement(driver.FindElement(By.XPath("//input[@id='dateOfBirthInput']")))
            .KeyDown(Keys.Control)
            .SendKeys("a")
            .KeyUp(Keys.Control)
            .Perform();

            CalInputBox.SendKeys("01 Jan 2023");

            CalInputBox.SendKeys(Keys.Escape);

        }

        static void TestCalendarInput(IWebDriver driver, IJavaScriptExecutor js)
        {
            driver.FindElement(By.XPath("//input[@id='dateOfBirthInput']")).Click();

            // Expected Month
            string ExpMonth = "July 2022";

            // Current Month
            string CurrMonth = driver.FindElement(By.XPath("//div[contains(@class, 'react-datepicker__current-month')]")).Text;

            if (ExpMonth.Equals(CurrMonth))
            {
                System.Console.WriteLine("Month Selected");
            }
            else
            {
                for (int i = 1; i < 12; i++)
                {
                    IWebElement ForwardBtn = driver.FindElement(By.XPath("//button[text()='Next Month']"));
                    js.ExecuteScript("arguments[0].click()", ForwardBtn);

                    Thread.Sleep(1000);

                    CurrMonth = driver.FindElement(By.XPath("//div[contains(@class, 'react-datepicker__current-month')]")).Text;

                    if (ExpMonth.Equals(CurrMonth))
                    {
                        System.Console.WriteLine("Month Selected");
                        break;
                    }
                }
            }

            Thread.Sleep(2000);


            // Uncomment Next and Previous btn logic to test
            // Next Button
            //driver.FindElement(By.XPath("//button[text()='Next Month']")).Click();

            // Previous Button
            //driver.FindElement(By.XPath("//button[text()='Previous Month']")).Click();

        }

        static void TestCalendarDropdown(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//input[@id='dateOfBirthInput']")).Click();

            // Dropdown Month Test
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

        static void AutoCompleteSubject(IWebDriver driver, IJavaScriptExecutor js)
        {
            IWebElement InputBox = driver.FindElement(By.XPath("//input[@id='subjectsInput']"));

            InputBox.SendKeys("a");

            Thread.Sleep(2000);

            InputBox.SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);
            InputBox.SendKeys(Keys.Enter);

            InputBox.SendKeys("b");

            Thread.Sleep(2000);

            InputBox.SendKeys(Keys.Enter);

            InputBox.SendKeys("c");

            Thread.Sleep(2000);

            InputBox.SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);

            InputBox.SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);

            InputBox.SendKeys(Keys.Enter);

            Thread.Sleep(2000);

            driver.SwitchTo().ActiveElement();

            Actions action = new Actions(driver);

            // Clear All Input
            //action.MoveToElement(driver.FindElement(By.XPath("//div[contains(@class, 'subjects-auto-complete__clear-indicator')]"))).Click().Build().Perform();
            //Thread.Sleep(3000);

            // Clear Random Input
            IWebElement AutoCompleteParent = driver.FindElement(By.XPath("//div[contains(@class, 'subjects-auto-complete__value-container')]"));

            ReadOnlyCollection<IWebElement> AutoCompleteClear = AutoCompleteParent.FindElements(By.XPath("//div[contains(@class, 'subjects-auto-complete__multi-value__remove')]"));

            action.Click(AutoCompleteClear[new System.Random().Next(0, AutoCompleteClear.Count)]).Build().Perform();

            Thread.Sleep(3000);

        }

        static void Hobbies(IWebDriver driver, IJavaScriptExecutor js)
        {
            IWebElement Sports = driver.FindElement(By.XPath("//input[@id='hobbies-checkbox-1']"));
            js.ExecuteScript("arguments[0].click()", Sports);

            Thread.Sleep(2000);

            IWebElement Reading = driver.FindElement(By.XPath("//input[@id='hobbies-checkbox-2']"));
            js.ExecuteScript("arguments[0].click()", Reading);

            Thread.Sleep(2000);

            IWebElement Music = driver.FindElement(By.XPath("//input[@id='hobbies-checkbox-3']"));
            js.ExecuteScript("arguments[0].click()", Music);
        }

        static void Upload(IWebDriver driver)
        {
            // Please provide a sample file to upload or comment to continue
            driver.FindElement(By.XPath("//input[@id='uploadPicture']"))
                .SendKeys(@"C:\Users\" + System.Environment.UserName + @"\Downloads\sampleFile.jpeg");
        }

        static void CurrentAddress(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//textarea[@id='currentAddress']"))
                .SendKeys("Kumbha Karan er Bari");
        }

        static void SelectStateCity(IWebDriver driver, IJavaScriptExecutor js)
        {
            IWebElement StateInputBox = driver.FindElement(By.XPath("//input[@id='react-select-3-input']"));

            StateInputBox.SendKeys("a");
            Thread.Sleep(2000);
            StateInputBox.SendKeys(Keys.Enter);

            Thread.Sleep(2000);

            IWebElement CityInputBox = driver.FindElement(By.XPath("//input[@id='react-select-4-input']"));

            CityInputBox.SendKeys("L");
            Thread.Sleep(2000);
            CityInputBox.SendKeys(Keys.Enter);

            IWebElement SubmitBtn = driver.FindElement(By.XPath("//button[@id='submit']"));
            js.ExecuteScript("arguments[0].click()", SubmitBtn);
        }
    }
}
