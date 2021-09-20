using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.Pages
{
    public class EmployeeListPage 
    {
        private IWebDriver Driver;

        public EmployeeListPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement EmployeeList => Driver.FindElement(By.LinkText("Employee List"));
        private IWebElement CreateNewButton => Driver.FindElement(By.XPath("//a[text()='Create New']"));
        private IWebElement SearchField => Driver.FindElement(By.Name("searchTerm"));
        private IWebElement SearchButton => Driver.FindElement(By.CssSelector("input[value='Search']"));
        private IWebElement editlnk => Driver.FindElement(By.LinkText("Edit"));

        public bool IsAt => CreateNewButton.Displayed;//вертає ексепшин треба, щоб фолс через try/catch

        public bool NavigateToEmployeePage()
        {
            EmployeeList.Click();
            return IsAt;
        }

        public List<IWebElement> SearchEmployee(string data, string quantity)
        {
            SearchField.SendKeys(data);
            SearchButton.Click();

            List<IWebElement> employeesData = Driver.FindElements(By.XPath("//table[@class='table']/tbody/tr/td")).ToList();
            List<IWebElement> employeesNames = Driver.FindElements(By.XPath("//table[@class='table']/tbody/tr/td[1]")).ToList();

            if (quantity == "mult") { return employeesNames; }
            return employeesData;
        }

        public bool CheckFoundEmployeeNames(List<IWebElement> data, params string[] empData)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Text.Contains(empData[0]))
                {
                    continue;
                }
                TakeScrenshot();
                return false;
            }
            return true;
        }

         public bool CheckFoundEmployeeInputData(List<string>expectedData, List<IWebElement>actualData)
        {
            for (int i = 0; i < expectedData.Count; i++)
            {
                if (expectedData[i] == actualData[i].Text) { continue; }
                Console.WriteLine($"Created user info does not match with entered data at index {i}");
                Console.WriteLine($"data.Text = {actualData[i].Text}");
                Console.WriteLine($"empData = {expectedData[i]}");
                TakeScrenshot();
                return false;
            }
            return true;
        }

        public CreatePage TestEditLink()
        {
            editlnk.Click();
            return new CreatePage(Driver);
        }

        public bool CheckIfEmployeeDeleted(string name)
        {
            List<IWebElement> employees = Driver.FindElements(By.XPath("//table[@class='table']/tbody/tr/td[1]")).ToList();
            if (employees.Count > 0) { TakeScrenshot(); return false; }
            return true;
        }

        public void TakeScrenshot()
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
                ss.SaveAsFile(@"C:\Users\ognyp\Desktop\SelScreens\FoundEmpScr.jpeg");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}

