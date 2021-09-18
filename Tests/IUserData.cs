using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public interface IUserData
    {
        public IWebElement UserName { get; }
        public IWebElement Password { get; }
        public IWebElement Name { get; }
        public IWebElement Salary { get; }
        public IWebElement DurationWorked { get; }
        public IWebElement Grade { get; }
        public IWebElement Email { get; }
        //public void SetOrChangeUserData(string[] newUserData, params string[] oldUserData);
    }
}
