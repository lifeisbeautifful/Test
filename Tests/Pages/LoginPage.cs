using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Pages
{
    public class LoginPage
    {
        private IWebDriver Driver;

        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
        }
        private bool IsAt => LogOffLink.Displayed;
        private IWebElement LogOffLink => Driver.FindElement(By.LinkText("Log off"));
        private IWebElement UsernameField => Driver.FindElement(By.ClassName("form-control"));
        private IWebElement PasswordField => Driver.FindElement(By.Name("Password"));
        private IWebElement LoginButton => Driver.FindElement(By.XPath("//input[@type='submit']"));
        private IWebElement LoginLink => Driver.FindElement(By.Id("loginLink"));

        public HomePage IfLoggedOff(string username,string password)
        {
            if (LoginLink.Displayed)
            {
                LoginLink.Click();
                SuccessLoginWithValidCredentials(username,password); 
            }
            return new HomePage(Driver);
        }

        public bool SuccessLoginWithValidCredentials(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
            return IsAt;
        }
    }
}
