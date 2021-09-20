using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public interface IUserData
    {
        public  static string UserName { get; }
        public static string Password { get; }
        public string Name { get; }
        public double Salary { get; }
        public int DurationWorked { get; }
        public int Grade { get; }
        public string Email { get; }

        public List<string> SetUserInputsToList();
    }
}
