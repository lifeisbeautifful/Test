using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Pages
{
    public class HomePage
    {
        private IWebDriver Driver;

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement loginLink => Driver.FindElement(By.Id("loginLink"));
        

        public void NavigateToLoginPage()
        {

        }
    }
}
