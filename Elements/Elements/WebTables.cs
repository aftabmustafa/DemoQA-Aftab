using OpenQA.Selenium;
using DqLib;

namespace Elements
{
    class WebTables : SeleniumLib
    {
        public void Run()
        {
            try
            {
                StartBrowser("https://demoqa.com/webtables");

                Sleep(2000);

                SearchQuery();

                Sleep(2000);

                AddQuery();

                Sleep(2000);

                EditRecord();

                Sleep(2000);

                DeleteRecord();

                Sleep(5000);

                CloseBrowser();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                Sleep(5000);
                CloseBrowser();
            }

            if (Prompt())
                new Buttons().Run();
        }

        public void AddQuery()
        {
            string fName = "A";
            string lName = "Mustafa";
            string email = "email@gmail.com";
            string dept = "Tester";
            string age = "21";
            string salary = "500000000";

            SimpleClick(By.Id("addNewRecordButton"));

            Sleep(1000);

            TextInput(By.Id("firstName"), fName);

            Sleep(2000);

            TextInput(By.Id("lastName"), lName);

            Sleep(2000);

            TextInput(By.Id("userEmail"), email);

            Sleep(2000);

            TextInput(By.Id("age"), age);

            Sleep(2000);

            TextInput(By.Id("salary"), salary);

            Sleep(2000);

            TextInput(By.Id("department"), dept);

            Sleep(2000);

            SimpleClick(By.Id("submit"));

        }

        public void SearchQuery()
        {
            TextInput(By.Id("searchBox"), "Cierra");

            Sleep(3000);

            ActionClearInput(By.Id("searchBox"));
        }

        public void EditRecord()
        {
            SimpleClick(By.Id("edit-record-4"));

            Sleep(2000);

            ClearTextInput(By.Id("firstName"));
            TextInput(By.Id("firstName"), "Aftab");

            Sleep(2000);

            SimpleClick(By.Id("submit"));
        }

        public void DeleteRecord()
        {
            SimpleClick(By.Id("delete-record-4"));
        }
    }
}
