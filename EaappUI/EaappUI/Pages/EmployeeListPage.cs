using Eaapp.Urls;
using EaappFramework.EaappFramework.CoreWeb;
using EaappFramework.EaappFramework.CoreWeb.Elements;
using EaappFramework.EaappFramework.Elements;
using EaappUI.EaappUI.Pages;
using NLog;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace Eaapp.Pages
{
    public class EmployeeListPage : BasePage
    {
        private Logger Logger => LogManager.GetCurrentClassLogger();
        
        public EmployeeListPage(string pageUrl) : base(pageUrl)
        {
            
        }

      
        private CommonElement CreateNewButton => ElementFactory.Create<CommonElement>(Locator.XPath("//a[text()='Create New']"));
        private InputElement SearchField => ElementFactory.Create<InputElement>(Locator.Name("searchTerm"));
        private CommonElement SearchButton => ElementFactory.Create<CommonElement>(Locator.CssSelector("input[value='Search']"));
        private CommonElement EditLink => ElementFactory.Create<CommonElement>(Locator.LinkText("Edit"));
        private List<IWebElement> employeesDataFromUI => BrowserManager.Current.FindElements(Locator.XPath("//table[@class='table']/tbody/tr//td"));
        private CommonElement deleteLink => ElementFactory.Create<CommonElement>(Locator.LinkText("Delete"));
        private CommonElement deleteButton => ElementFactory.Create<CommonElement>(Locator.XPath("//div[@class='form-actions no-color']/input[@type='submit']"));

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

        
        public CreatePage OpenCreatePage()
        {
            CreateNewButton.Click();
            return new CreatePage(EAAPPUrls.urlCreatePage);
        }

        public void DeleteEmployee(string data)
        {
            deleteLink.Click();
            deleteButton.Click();
        }

        public void SearchEmployee(string data)
        {
            Logger.Trace($"Search employee with {data} data");
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
            BrowserManager.Current.NavigateBack();
        }

        public void ClickEditLink()
        {
            EditLink.Click();
        }

        public bool CheckIfEmployeeExist(ReadOnlyCollection<UsersData> UIData, UsersData deletedUser)
        {
            if (UIData.Count < 1) { return false; }
            return IsUIDataContainsSearchedData(UIData, deletedUser);
        }
    }
}

