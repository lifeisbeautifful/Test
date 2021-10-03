﻿using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Tests.UserData
{
    public class RandomUsersData : IUserData, IEquatable<UsersData>
    {
        private string name;
        private string salary;
        private string durationWorked;
        private string grade;
        private string email;
      
        private char[] letters = "ABCDEFGHIJKLMNOPQURSTUVWXYZ".ToCharArray();
        Random random = new Random();

        public string UserName
        {
            get { return "admin"; }
            set { ; }
        }

        public string Password
        {
            get { return "password"; }
            set { ; }
        }

        public string Name 
        { 
            get 
            {
                if (name == null)
                {
                    return GetRandomName();
                }
                return name;
            }
            set 
            {
               name = value; 
            } 
        }

        public string Salary
        {
            get 
            {
                if (salary == null)
                {
                    salary = GetRandomSalary().ToString();
                    return salary;
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
                    durationWorked = GetRandomDurationWorked().ToString();
                    return durationWorked;
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
                    grade = GetrandomGrade().ToString();
                    return grade;
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
                    return GetRandomEmail();
                }
                return email;
            }
            set 
            {
               email = value ; 
            }
        }

        private string GetRandomName()
        {
            for (int i = 0; i < 5; i++)
            {
                int charNumber = random.Next(0, letters.Length - 1);
                name += letters[charNumber];
            }
            return name;
        }

        private double GetRandomSalary()
        {
            double randomSalary = random.Next(0, 10000);
            return randomSalary;
        }

       private int GetRandomDurationWorked()
       {
            int randomDurationWorked = random.Next(1, 10);
            return randomDurationWorked;
       }

        private int GetrandomGrade()
        {
            int randomGrade = random.Next(0, 5);
            return randomGrade;
        }
       
       private string GetRandomEmail()
        {
            for(int i = 0; i < 11; i++)
            {
                if (i == 5)
                {
                    email += "@";
                }

                if (i == 8)
                {
                    email += ".";
                }

                int charNumber = random.Next(0, letters.Length - 1);
                email += letters[charNumber];
            }
            return email;
        }

        public bool Equals(UsersData obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                if(Name == obj.Name && Salary == obj.Salary && DurationWorked == obj.DurationWorked
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
