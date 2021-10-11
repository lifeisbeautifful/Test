using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;


namespace Tests.DriverHelper
{
    public class TakeScreenShot
    {
        private IWebDriver Driver { get; set; }

        public TakeScreenShot(IWebDriver driver)
        {
            Driver = driver;
        }

        public void ScreenShot()
        {
            if (TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Failure))
            {
                string fileName = $"{TestContext.CurrentContext.Test.Name} - {DateTime.Now:yyyy.MM.dd-hh.mm.ss}";
                FileInfo screenshotPath = new FileInfo($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\screenshots\\{fileName}.png");
                Directory.CreateDirectory(screenshotPath.DirectoryName);

                ITakesScreenshot screenshot = (ITakesScreenshot)Driver;
                Screenshot screen = screenshot.GetScreenshot();
                screen.SaveAsFile(screenshotPath.FullName, ScreenshotImageFormat.Png);
            }
        }
    }
}
