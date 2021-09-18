using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.Pages
{
    public class CreatePage : IUserData
    {
        private IWebDriver Driver { get; set; }

        public CreatePage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement CreateNewButton => Driver.FindElement(By.XPath("//a[text()='Create New']"));

        public CreatePage OpenCreatePage()
        {
            CreateNewButton.Click();
            return new CreatePage(Driver);
        }

        public void SetOrChangeUserData(string[] addition, params string[]userData)
        {
            List<IWebElement> inputs = Driver.FindElements(By.TagName("input")).ToList();
            int i = 0;

            for (int j = 0; j < inputs.Count; j++)
            {
                if (inputs[j].GetAttribute("value") == "")
                {
                    inputs[j].SendKeys(userData[i]);
                    i++;
                }

                if (j == inputs.Count - 1)
                {
                    inputs[j].Click();
                }
            }
        }
    }
}
