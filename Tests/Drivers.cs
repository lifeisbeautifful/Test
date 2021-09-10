using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class Drivers
    {
        private IWebDriver Driver { get; set; }

        public enum Browsers
        {
            Chrome,
            FireFox
        }

        public void ChooseDriver(Browsers br)
        {
            switch (br)
            {
                case Browsers.Chrome:
                    ChromeOptions option = new ChromeOptions();
                    option.AddArgument("--headless");
                    Driver = new ChromeDriver();
                    break;
                case Browsers.FireFox:
                    FirefoxOptions optionFF = new FirefoxOptions();
                    optionFF.AddArgument("--headless");
                    Driver = new FirefoxDriver(optionFF);
                    break;
            }
        }

        public void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}
