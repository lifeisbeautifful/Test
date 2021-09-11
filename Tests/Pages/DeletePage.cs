using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Pages
{
    public class DeletePage
    {
        private IWebDriver Driver { get; set; }
        public DeletePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void DeleteEmployee(string data)
        {
            IWebElement deleteLnk = Driver.FindElement(By.LinkText("Delete"));
            deleteLnk.Click();

            IWebElement deleteBtn = Driver.FindElement(By.XPath("//div[@class='form-actions no-color']/input[@type='submit']"));
            deleteBtn.Click();
        }
    }
}
