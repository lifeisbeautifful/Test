using EaappFramework.EaappFramework.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EaappFramework.EaappFramework.CoreWeb
{
    public sealed class Browser
    {
        private readonly IWebDriver _driverWrapper;
        private readonly WebDriverWait _waitWrapper;
        internal readonly ITakesScreenshot _screenShotWrapper;

        internal Browser(IWebDriver driverWrapper)
        {
            _driverWrapper = driverWrapper;
            _waitWrapper = new WebDriverWait(_driverWrapper, TimeSpan.FromSeconds(10));
            _screenShotWrapper = (ITakesScreenshot) _driverWrapper;
        }

        public string PageUrl
        {
            get
            {
                string url = _driverWrapper.Url;
                return url;
            }
        }

        internal IWebElement FindElement(Locator locator)
        {
            IWebElement element = _driverWrapper.FindElement(locator.Wrapper);
            return element;
        }

        internal void Quit()
        {
            _driverWrapper.Quit();
        }

        internal void MaximizeWindow()
        {
            _driverWrapper.Manage().Window.Maximize();
        }

        public List<IWebElement> FindElements(Locator locator)
        {
            List<IWebElement> elements = _driverWrapper.FindElements(locator.Wrapper).ToList();
            return elements;
        }

        public void Navigate(string url)
        {
            _driverWrapper.Navigate().GoToUrl(url);
        }

        public string TakeScreenShot(string fileName)
        {
            FileInfo screenshotPath = new FileInfo($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\screenshots\\{fileName}.png");
            Directory.CreateDirectory(screenshotPath.DirectoryName);
            Screenshot screen = _screenShotWrapper.GetScreenshot();
            screen.SaveAsFile(screenshotPath.FullName, ScreenshotImageFormat.Png);
            return screenshotPath.FullName;
        }

        public void NavigateBack()
        {
            _driverWrapper.Navigate().Back();
        }

        public void WaitForElement(CommonElement element)
        {
            _waitWrapper.Until(driver =>
            {
                bool IsElementVisible = element.Displayed;
                return IsElementVisible;
            });
        }
    }
}
