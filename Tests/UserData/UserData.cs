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

       
        public static string UserName => "admin";
        public static string Password => "password";
        public IWebElement Name => Driver.FindElement(By.Id("Name"));
        public IWebElement Salary => Driver.FindElement(By.Id("Salary"));
        public IWebElement DurationWorked => Driver.FindElement(By.Id("DurationWorked"));
        public IWebElement Grade => Driver.FindElement(By.Id("Grade"));
        public IWebElement Email => Driver.FindElement(By.Id("Email"));
    }
}
