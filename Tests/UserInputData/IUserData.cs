using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Tests
{
    public interface IUserData
    {
        string UserName { get; }
        string Password { get;  }
        string Name { get; }
        double Salary { get; }
        int DurationWorked { get; }
        int Grade { get; }
        string Email { get; }

        ReadOnlyCollection<string> SetUserInputsToList();
    }
}
