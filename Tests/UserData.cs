using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class UserData : IUserData
    {
        private IWebDriver Driver;

        public UserData(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement UserName => Driver.FindElement(By.ClassName("form-control"));
        public IWebElement Password => Driver.FindElement(By.Name("Password"));
        public IWebElement Name => Driver.FindElement(By.Id("Name"));
        public IWebElement Salary => Driver.FindElement(By.Id("Salary"));
        public IWebElement DurationWorked => Driver.FindElement(By.Id("DurationWorked"));
        public IWebElement Grade => Driver.FindElement(By.Id("Grade"));
        public IWebElement Email => Driver.FindElement(By.Id("Email"));
    }
}
