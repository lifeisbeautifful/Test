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

       public UserData() {; }

        public static string UserName => "admin";
        public static string Password => "password";
        public string Name => "Oksana";
        public double Salary => 4000;
        public int DurationWorked => 2;
        public int Grade => 4;
        public string Email => "a@mailforspam.com";
    }
}
