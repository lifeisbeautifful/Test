﻿using OpenQA.Selenium;


namespace Eaapp.Pages
{
    public class DeletePage
    {
        private IWebDriver Driver { get; set; }

        public DeletePage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement deleteLink => Driver.FindElement(By.LinkText("Delete"));
        private IWebElement deleteButton => Driver.FindElement(By.XPath("//div[@class='form-actions no-color']/input[@type='submit']"));


        public void DeleteEmployee(string data)
        {
            deleteLink.Click();
            deleteButton.Click();
        }
    }
}