﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tests.Pages;

namespace Tests
{
    public class UsersData : IUserData, IEquatable<UsersData>
    {
        private string name;
        private string salary;
        private string durationWorked;
        private string grade;
        private string email;

        public string UserName { get { return "admin"; } set {; } }
        public string Password { get { return "password"; }set {; } }

        public string Name 
        { 
            get 
            {
                if (name == null)
                {
                    name = "Oksana";
                }
                return name;
            } 
            set 
            {
                name = value; ;
            } 
        }

        public string Salary 
        { 
            get 
            {
                if (salary == null)
                {
                    salary = "4000";
                }
                return salary;
            } 
            set 
            {
                salary = value; 
            }
        }

        public string DurationWorked 
        { 
            get
            {
                if (durationWorked == null)
                {
                    durationWorked = "2";
                }
                return durationWorked;
            } 
            set 
            {
                durationWorked = value; 
            } 
        }

        public string Grade 
        { 
            get 
            {
                if (grade == null)
                {
                    grade = "4";
                }
                return grade;
            } 
            set 
            {
                grade = value; 
            } 
        }

        public string Email 
        { 
            get
            {
                if (email == null)
                {
                    email = "a@mailforspam.com";
                }
                return email;
            }
            set 
            {
                email = value;
            } 
        }

        public bool Equals(UsersData obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                if (Name == obj.Name && Salary == obj.Salary && DurationWorked == obj.DurationWorked
                       && Grade == obj.Grade && Email == obj.Email)
                {
                    return true;
                }
                    return false;
            }
        }

        public override bool Equals(object obj) => Equals(obj as UsersData);
    }
}
