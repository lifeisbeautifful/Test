using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tests.Pages;

namespace Tests
{
    public class UsersData : IUserData
    {
        public string UserName { get { return "admin"; }set {; } }
        public string Password { get { return "password"; }set {; } }
        public string Name { get { return "Oksana"; } set {; } }
        public string Salary { get { return "4000"; } set {; } }
        public string DurationWorked { get { return "2"; } set {; } }
        public string Grade { get { return "4"; } set {; } }
        public string Email { get { return "a@mailforspam.com"; }set {; } }

        //private List<string> UserInputData = new List<string>();

        //public ReadOnlyCollection<string> SetUserInputsToList()//name GetUserData
        //{
        //    List<string> UserInputData = new List<string>();
        //    UserInputData.Add(Name);
        //    UserInputData.Add(Salary.ToString());
        //    UserInputData.Add(DurationWorked.ToString());
        //    UserInputData.Add(Grade.ToString());
        //    UserInputData.Add(Email);
        //    return UserInputData.AsReadOnly();
        //}

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                UsersData data = (UsersData)obj;

                if (data is UsersData)
                {
                    return Name == data.Name && Salary == data.Salary && DurationWorked == data.DurationWorked
                        && Grade == data.Grade && Email == data.Email;
                }
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
