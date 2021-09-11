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

        private IWebElement logOffLink => Driver.FindElement(By.LinkText("Log off"));
        private IWebElement usernameField => Driver.FindElement(By.ClassName("form-control"));
        private IWebElement passwordField => Driver.FindElement(By.Name("Password"));
        private IWebElement loginButton => Driver.FindElement(By.XPath("//input[@type='submit']"));
        private IWebElement loginLink => Driver.FindElement(By.Id("loginLink"));

        public HomePage IfLoggedOff(string username,string password)
        {
            if (loginLink.Displayed)
            {
                loginLink.Click();
                SuccessLoginWithValidCredentials(username,password); 
            }
            return new HomePage(Driver);
        }

        public bool SuccessLoginWithValidCredentials(string username, string password)
        {
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
            loginButton.Click();
            return logOffLink.Displayed;
        }
    }
}
