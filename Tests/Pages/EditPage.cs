using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.Pages
{
    public class EditPage
    {
        private IWebDriver Driver { get; set; }
        public EditPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void EditEmployee(string[] newUserData, params string[] oldUserData)
        {
            List<IWebElement> inputs = Driver.FindElements(By.TagName("input")).ToList();
            int i = 0;

            for (int j = 0; j < inputs.Count; j++)
            {
                if (i < 5)
                {
                    if (inputs[j].GetAttribute("value") == oldUserData[i])
                    {
                        inputs[j].Clear();
                        inputs[j].SendKeys(newUserData[i]);
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
