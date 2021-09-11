using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CreateEditEmployee(string[] userData, params string[] fieldInputs)
        {
            List<IWebElement> inputs = Driver.FindElements(By.TagName("input")).ToList();
            int i = 0;

            for (int j = 0; j < inputs.Count; j++)
            {
                if (inputs[j].GetAttribute("value") == "")
                {
                    inputs[j].SendKeys(fieldInputs[i]);
                    i++;
                }

                if (i < 5)
                {
                    if (inputs[j].GetAttribute("value") == fieldInputs[i])
                    {
                        inputs[j].Clear();
                        inputs[j].SendKeys(userData[i]);
                        i++;
                    }
                }

                if (j == inputs.Count - 1)
                {
                    inputs[j].Click();
                }
            }
        }
    }
}
