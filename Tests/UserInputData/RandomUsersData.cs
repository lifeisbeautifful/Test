﻿using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Tests.UserData
{
    public class RandomUsersData : IUserData
    {
        private string name;
        private double salary;
        private int durationWorked;
        private int grade;
        private string email;

        private char[] letters = "ABCDEFGHIJKLMNOPQURSTUVWXYZ".ToCharArray();
        private List<string> randomUserData = new List<string>();
        Random random = new Random();

        public string UserName => "admin";
        public string Password => "password";

        public string Name => GetRandomName();
        public double Salary => GetRandomSalary();
        public int DurationWorked => GetRandomDurationWorked();
        public int Grade => GetrandomGrade();
        public string Email => GetRandomEmail();

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
            salary = random.Next(0, 10000);
            return salary;
        }

       private int GetRandomDurationWorked()
        {
            durationWorked = random.Next(1, 10);
            return durationWorked;
        }

        private int GetrandomGrade()
        {
            grade = random.Next(0, 5);
            return grade;
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

        public ReadOnlyCollection<string> SetUserInputsToList()
        {
            randomUserData.Add(name);
            randomUserData.Add(salary.ToString());
            randomUserData.Add(durationWorked.ToString());
            randomUserData.Add(grade.ToString());
            randomUserData.Add(email);
            return randomUserData.AsReadOnly();
        }
    }
}