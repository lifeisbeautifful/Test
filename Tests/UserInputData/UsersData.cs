using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Tests
{
    public class UsersData : IUserData
    {
        public string UserName => "admin";
        public string Password => "password";
        public string Name => "Oksana";
        public double Salary => 4000;
        public int DurationWorked => 2;
        public int Grade => 4;
        public string Email => "a@mailforspam.com";

        //private List<string> UserInputData = new List<string>();

        public ReadOnlyCollection<string> SetUserInputsToList()//name GetUserData
        {
            List<string> UserInputData = new List<string>();
            UserInputData.Add(Name);
            UserInputData.Add(Salary.ToString());
            UserInputData.Add(DurationWorked.ToString());
            UserInputData.Add(Grade.ToString());
            UserInputData.Add(Email);
            return UserInputData.AsReadOnly();
        }
    }
}
