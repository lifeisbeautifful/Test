using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class UsersData : IUserData
    {
        public static string UserName => "admin";
        public static string Password => "password";
        public string Name => "Oksana";
        public double Salary => 4000;
        public int DurationWorked => 2;
        public int Grade => 4;
        public string Email => "a@mailforspam.com";

        private List<string> UserInputData = new List<string>();

        public List<string> GetUserData()
        {
            UserInputData.Add(Name);
            UserInputData.Add(Salary.ToString());
            UserInputData.Add(DurationWorked.ToString());
            UserInputData.Add(Grade.ToString());
            UserInputData.Add(Email);
            return UserInputData;
        }
    }
}
