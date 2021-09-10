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

        public HomePage IfLoggedIn()
        {
            if (logOff.Displayed) { logOff.Click(); }
            return new HomePage(Driver);
        }

    }
}
