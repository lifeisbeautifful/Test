using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
        private IWebElement SearchInput => Driver.FindElement(By.XPath("//input[@type='submit']"));
        private IWebElement CreateNewButton => Driver.FindElement(By.XPath("//a[text()='Create New']"));

        public bool EmployeePageNavigate()
        {
            EmployeeList.Click();
            return CreateNewButton.Displayed;
        }
    }
}
