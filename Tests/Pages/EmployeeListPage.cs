using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private IWebElement Editlnk => Driver.FindElement(By.LinkText("Edit"));
        private List<IWebElement> employeesData => Driver.FindElements(By.XPath("//table[@class='table']/tbody/tr/td")).ToList();
        private List<IWebElement> foundEmployeesData => Driver.FindElements(By.XPath("//table[@class='table']/tbody/tr//td")).ToList();
        private List<IWebElement> allEmployeesData => Driver.FindElements(By.XPath("//table[@class='table']/tbody/tr//td")).ToList();
        private List<IWebElement> employees => Driver.FindElements(By.XPath("//table[@class='table']/tbody/tr/td[1]")).ToList();





        public bool IsAt()
        {
            if (CreateNewButton.Displayed){ return true; }
            return false;
        }

        public bool NavigateToEmployeePage()
        {
            EmployeeList.Click();
            return IsAt();
        }

        public ReadOnlyCollection<IWebElement> SearchEmployee(string data)
        {
            SearchField.SendKeys(data);
            SearchButton.Click();
            return employeesData.AsReadOnly();
        }

        public bool CheckFoundEmployeeMultiple(ReadOnlyCollection<IWebElement> data, string search)
        {
            List<string> fEmployeesData = new List<string>();
            //Create list of IWebelements ('FoundEmployeesData') with all data which user see while search was performed

            //Save all data from 'FoundEmployeesData' to string List
            for(int i = 0; i < foundEmployeesData.Count; i++)
            {
                fEmployeesData.Add(foundEmployeesData[i].Text);
            }

            Driver.Navigate().Back();
            //Save all user data from DB to 'allEmployeesData' list
            int j = 0;

            for (int i = 0; i < allEmployeesData.Count; i++)
            {
                if (allEmployeesData[i].Text.StartsWith(search) && !allEmployeesData[i].Text.Contains("@"))
                {
                    for (int k = 0; k < 6; k++)
                    {
                        if (allEmployeesData[i].Text == fEmployeesData[j])
                        {
                            if (k < 5) 
                            { i++; }

                            j++;
                            continue;
                        }
                        return false;
                    }
                }
            }
            return true;
        }

         public bool CheckFoundEmployeeSingle(ReadOnlyCollection<string>expectedData, ReadOnlyCollection<IWebElement>actualData)
        {
            for (int i = 0; i < 5; i++)
            {
                if (expectedData[i] == actualData[i].Text) { continue; }
                Console.WriteLine($"Created user info does not match with entered data at index {i}");
                Console.WriteLine($"data.Text = {actualData[i].Text}");
                Console.WriteLine($"empData = {expectedData[i]}");
                return false;
            }
            return true;
        }

        public CreatePage TestEditLink()
        {
            Editlnk.Click();
            return new CreatePage(Driver);
        }

        public bool CheckIfEmployeeDeleted()
        {
            if (employees.Count > 0) { return false; }
            return true;
        }
    }
}

