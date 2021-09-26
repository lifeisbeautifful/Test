using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Tests.UserData;
using Tests.UserInputData;

namespace Tests.Pages
{
    public class EmployeeListPage 
    {
        private IWebDriver Driver;

        public EmployeeListPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private List<string> data = new List<string>();
        private IWebElement EmployeeListLink => Driver.FindElement(By.LinkText("Employee List"));
        private IWebElement CreateNewButton => Driver.FindElement(By.XPath("//a[text()='Create New']"));
        private IWebElement SearchField => Driver.FindElement(By.Name("searchTerm"));
        private IWebElement SearchButton => Driver.FindElement(By.CssSelector("input[value='Search']"));
        private IWebElement EditLink => Driver.FindElement(By.LinkText("Edit"));
        private List<IWebElement> employeesDataFromUI => Driver.FindElements(By.XPath("//table[@class='table']/tbody/tr//td")).ToList();

        public bool IsAt()
        {
            if (CreateNewButton.Displayed){ return true; }
            return false;
        }

        public bool NavigateToEmployeePage()
        {
            EmployeeListLink.Click();
            return IsAt();
        }

        public ReadOnlyCollection<IWebElement> SearchEmployee(string data)
        {
            SearchField.SendKeys(data);
            SearchButton.Click();
            return employeesDataFromUI.AsReadOnly();
        }

        public ReadOnlyCollection<string> TransferAllFoundUIDataToReadOnlyCollection()
        {
            for (int i = 0; i < employeesDataFromUI.Count; i++)
            {
                data.Add(employeesDataFromUI[i].Text);
            }
            return data.AsReadOnly();
        }

        public void NavigateBack()
        {
            Driver.Navigate().Back();
        }

        public bool CheckIfFoundDataMatchSearchCriteriaData(string searchCriteria)
        {
            int j = 0;

            for (int i = 0; i < employeesDataFromUI.Count; i++)
            {
                if (employeesDataFromUI[i].Text.StartsWith(searchCriteria) && !employeesDataFromUI[i].Text.Contains("@"))
                {
                    for (int k = 0; k < 6; k++)
                    {
                        if (employeesDataFromUI[i].Text == data[j])
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
      
        public ReadOnlyCollection<string> TransferOnlyUserInputUIDataToReadOnlyCollection()
        {
            List<string> actualFoundData = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                actualFoundData.Add(employeesDataFromUI[i].Text);
            }
            return actualFoundData.AsReadOnly();
        }

        public IUserData GetUserDataFromUI(IUserData data)
        {
            IUserData usersData=new UsersData();
            IUserData randomUsersData = new RandomUsersData();
            IUserData usersDataFromFile = new UsersDataFromFile();
            data.Name = employeesDataFromUI[0].Text;
            data.Salary = employeesDataFromUI[1].Text;
            data.DurationWorked = employeesDataFromUI[2].Text;
            data.Grade = employeesDataFromUI[3].Text;
            data.Email = employeesDataFromUI[4].Text;
            return data;
        }

            public CreatePage TestEditLink()
        {
            EditLink.Click();
            return new CreatePage(Driver);
        }

        public bool CheckIfEmployeeDeleted()
        {
            if (employeesDataFromUI.Count > 0) { return false; }
            return true;
        }
    }
}

