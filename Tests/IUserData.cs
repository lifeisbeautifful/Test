using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public interface IUserData
    {
        public IWebElement UserName { get; set; }
        public IWebElement Password { get; set; }
        public IWebElement Name { get; set; }
        public IWebElement Salary { get; set; }
        public IWebElement DurationWorked { get; set; }
        public IWebElement Grade { get; set; }
        public IWebElement Email { get; set; }
        public void SetOrChangeUserData(string[] newUserData, params string[] oldUserData);
    }
}
