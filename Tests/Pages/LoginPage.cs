using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Pages
{
    public class LoginPage
    {
        private string urlLogin = "http://eaapp.somee.com/Account/Login";

        private IWebDriver Driver;

        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement logOff => Driver.FindElement(By.LinkText("Log off"));
        private IWebElement username => Driver.FindElement(By.ClassName("form-control"));
        private IWebElement password => Driver.FindElement(By.Name("Password"));
        private IWebElement loginBtn => Driver.FindElement(By.XPath("//input[@type='submit']"));
        private IWebElement loginLink => Driver.FindElement(By.Id("loginLink"));

        public HomePage IfLoggedIn()
        {
            if (!loginLink.Displayed) { logOff.Click(); }
            return new HomePage(Driver);
        }

        public bool SuccessLoginWithValidCredentials(string username, string password)
        {
            this.username.SendKeys(username);
            this.password.SendKeys(password);
            loginBtn.Click();
            return logOff.Displayed;
        }
    }
}
