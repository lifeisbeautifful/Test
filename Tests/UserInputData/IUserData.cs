using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Tests
{
    public interface IUserData
    {
        string UserName { get; set; }
        string Password { get; set; }
        string Name { get; set; }
        string Salary { get; set; }
        string DurationWorked { get; set; }
        string Grade { get; set; }
        string Email { get; set; }

        ReadOnlyCollection<string> SetUserInputsToList();
    }
}
