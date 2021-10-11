using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace Eaapp.Pages
{
    public class EmployeeListPage 
    {
        private IWebDriver Driver;

        public EmployeeListPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement EmployeeListLink => Driver.FindElement(By.LinkText("Employee List"));
        private IWebElement CreateNewButton => Driver.FindElement(By.XPath("//a[text()='Create New']"));
        private IWebElement SearchField => Driver.FindElement(By.Name("searchTerm"));
        private IWebElement SearchButton => Driver.FindElement(By.CssSelector("input[value='Search']"));
        private IWebElement EditLink => Driver.FindElement(By.LinkText("Edit"));
        private List<IWebElement> employeesDataFromUI => Driver.FindElements(By.XPath("//table[@class='table']/tbody/tr//td")).ToList();

        public bool IsAt
        {
            get
            {
                try
                {
                    return CreateNewButton.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public bool NavigateToEmployeePage()
        {
            EmployeeListLink.Click();
            return IsAt;
        }
        
        public void SearchEmployee(string data)
        {
            SearchField.SendKeys(data);
            SearchButton.Click();
        }

        public ReadOnlyCollection<UsersData> GetActualSearchResultFromUI()
        {
            UsersData data = new UsersData();
            List<UsersData> usersDataFromUI = new List<UsersData>();

            for (int i = 0; i < employeesDataFromUI.Count; i++)
            {
                data.Name = employeesDataFromUI[i].Text;
                i++;
                data.Salary = employeesDataFromUI[i].Text;
                i++;
                data.DurationWorked = employeesDataFromUI[i].Text;
                i++;
                data.Grade = employeesDataFromUI[i].Text;
                i++;
                data.Email = employeesDataFromUI[i].Text;
                i++;
                usersDataFromUI.Add(data);
            }
            return usersDataFromUI.AsReadOnly();
        }

        public ReadOnlyCollection<UsersData> ExpectedSearchResult(string searchCriteria)
        {
            UsersData expectedSearchResult = new UsersData();
            List<UsersData> expectedResult = new List<UsersData>();
           
            for (int i = 0; i < employeesDataFromUI.Count; i++)
            {
                if (employeesDataFromUI[i].Text.StartsWith(searchCriteria) && !employeesDataFromUI[i].Text.Contains("@"))
                {
                    expectedSearchResult.Name = employeesDataFromUI[i].Text;
                    i++;
                    expectedSearchResult.Salary = employeesDataFromUI[i].Text;
                    i++;
                    expectedSearchResult.DurationWorked = employeesDataFromUI[i].Text;
                    i++;
                    expectedSearchResult.Grade = employeesDataFromUI[i].Text;
                    i++;
                    expectedSearchResult.Email = employeesDataFromUI[i].Text;
                    i++;
                    expectedResult.Add(expectedSearchResult);
                }
            }
            return expectedResult.AsReadOnly();
        }

        public bool IsUIDataContainsSearchedData(ReadOnlyCollection<UsersData> usersDataFromUI, IUserData userData)
        {
            return usersDataFromUI.Any(user => user.Name == userData.Name && user.Salary == userData.Salary
              && user.DurationWorked == userData.DurationWorked && user.Grade == userData.Grade && user.Email == userData.Email);
        }

        public bool Compare(ReadOnlyCollection<UsersData> actual, ReadOnlyCollection<UsersData> expected)
        {
            for (int i = 0; i < actual.Count; i++)
            {
                if (actual[i].Equals(expected[i]))
                {
                    continue;
                }
                return false;
            }
            return true;
        }

        public void ClearSearchField()
        {
            SearchField.Clear();
        }

        public void NavigateBack()
        {
            Driver.Navigate().Back();
        }

        public CreatePage TestEditLink()
        {
            EditLink.Click();
            return new CreatePage(Driver);
        }

        public bool CheckIfEmployeeExist(ReadOnlyCollection<UsersData> UIData, UsersData deletedUser)
        {
            if (UIData.Count < 1) { return false; }
            return IsUIDataContainsSearchedData(UIData, deletedUser);
        }
    }
}

