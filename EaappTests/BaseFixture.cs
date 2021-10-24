using Allure.Commons;
using Eaapp.Urls;
using EaappFramework.EaappFramework.CoreWeb;
using EaappUI.EaappUI.Pages;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;


namespace EaappTests
{
    [TestFixture]
    [AllureNUnit]
    public abstract class BaseFixture 
    {
        [OneTimeSetUp]
        public void Setup()
        {
            BrowserManager.InitializeBrowser(BrowserType.Chrome);
            BrowserManager.Current.Navigate(EAAPPUrls.urlLoginPage);
            EaappPages.LoginPage.Login();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Failure))
            {
                string fileName = $"{TestContext.CurrentContext.Test.Name} - {DateTime.Now:yyyy.MM.dd-hh.mm.ss}";
                var screenPath=BrowserManager.Current.TakeScreenShot(fileName);
                AllureLifecycle.Instance.AddAttachment(screenPath, TestContext.CurrentContext.Test.Name);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            BrowserManager.Terminate();
        }
    }
}
