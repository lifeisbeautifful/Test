using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.Pages
{
    public class EmployeeListPage:IsetUserData
    {
        private IWebDriver Driver;
        public EmployeeListPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement EmployeeList => Driver.FindElement(By.LinkText("Employee List"));
        private IWebElement CreateNewButton => Driver.FindElement(By.XPath("//a[text()='Create New']"));
        IWebElement searchField => Driver.FindElement(By.Name("searchTerm"));
        IWebElement searchButton => Driver.FindElement(By.CssSelector("input[value='Search']"));

        public bool IsAt => CreateNewButton.Displayed;

        public bool EmployeePageNavigate()
        {
            EmployeeList.Click();
            return IsAt;
        }

        public List<IWebElement> SearchEmployee(string data, string quantity)
        {
            searchField.SendKeys(data);
            searchButton.Click();

            List<IWebElement> employeesData = Driver.FindElements(By.XPath("//table[@class='table']/tbody/tr/td")).ToList();
            List<IWebElement> employeesNames = Driver.FindElements(By.XPath("//table[@class='table']/tbody/tr/td[1]")).ToList();

            if (quantity == "mult") { return employeesNames; }
            return employeesData;
        }

        public bool CheckFoundEmpData(List<IWebElement> data, params string[] empData)
        {
            if (empData[0] == "mult")
            {
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i].Text.Contains(empData[1]))
                    {
                        continue;
                    }
                    TakeScrenshot();
                    return false;
                }
                return true;
            }
            else
            {
                for (int i = 0; i < empData.Length; i++)
                {
                    if (empData[i] == data[i].Text) { continue; }
                    Console.WriteLine($"Created user info does not match with entered data at index {i}");
                    Console.WriteLine($"data.Text = {data[i].Text}");
                    Console.WriteLine($"empData = {empData[i]}");
                    TakeScrenshot();
                    return false;
                }
                return true;
            }
        }

        public CreatePage TestEditLink()
        {
            IWebElement editlnk = Driver.FindElement(By.LinkText("Edit"));
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

        public void SetOrChangeUserData(string[] userData, params string[] additionData)
        {
            CreatePage createPage = new CreatePage(Driver);
            EmployeePageNavigate();
            createPage.OpenCreatePage()
                      .SetOrChangeUserData(userData, additionData);
        }
    }
}

