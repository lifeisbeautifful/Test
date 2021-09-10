using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Pages
{
    public class CreatePage
    {
        private IWebDriver Driver { get; set; }

        public CreatePage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement CreateNewBtn => Driver.FindElement(By.XPath("//a[text()='Create New']"));
        private IWebElement CreateLnk => Driver.FindElement(By.XPath("//input[@type='submit']"));

        public CreatePage OpenCreatePage()
        {
            CreateNewBtn.Click();
            return new CreatePage(Driver);
        }
    }
}
