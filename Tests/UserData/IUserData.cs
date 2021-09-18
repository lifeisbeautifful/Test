using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public interface IUserData
    {
        public static string UserName { get; }
        public static string Password { get; }
        public static string Name { get; }
        public static double Salary { get; }
        public static int DurationWorked { get; }
        public static int Grade { get; }
        public static string Email { get; }
        //public void SetOrChangeUserData(string[] newUserData, params string[] oldUserData);
    }
}
