using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.Pages
{
    public class CreatePage 
    {
        private IWebDriver Driver { get; set; }

        public CreatePage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement CreateNewButton => Driver.FindElement(By.XPath("//a[text()='Create New']"));
        private IWebElement NameInput => Driver.FindElement(By.Id("Name"));
        private IWebElement SalaryInput => Driver.FindElement(By.Id("Salary"));
        private IWebElement DurationWorkedInput => Driver.FindElement(By.Id("DurationWorked"));
        private IWebElement GradeInput => Driver.FindElement(By.Id("Grade"));
        private IWebElement EmailInput => Driver.FindElement(By.Id("Email"));
        private IWebElement CreateButton => Driver.FindElement(By.CssSelector("input[type='Submit']"));

        public CreatePage OpenCreatePage()
        {
            CreateNewButton.Click();
            return new CreatePage(Driver);
        }

        public void SetOrChangeUserData()
        {
            NameInput.SendKeys(UserData.Name);
            SalaryInput.SendKeys(UserData.Salary.ToString());
            DurationWorkedInput.SendKeys(UserData.DurationWorked.ToString());
            GradeInput.SendKeys(UserData.Grade.ToString());
            EmailInput.SendKeys(UserData.Email);
            CreateButton.Click();
        }
    }
}
