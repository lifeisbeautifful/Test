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
        public static string Name => "Oksana";
        public static double Salary => 4000;
        public static int DurationWorked => 2;
        public static int Grade => 4;
        public static string Email => "a@mailforspam.com";
    }
}
