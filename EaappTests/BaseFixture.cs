using Eaapp.Urls;
using EaappFramework.EaappFramework.CoreWeb;
using EaappUI.EaappUI.Pages;
using NUnit.Allure.Core;
using NUnit.Framework;
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
            BrowserManager.InitializeBrowser();
            BrowserManager.Current.Navigate(EAAPPUrls.urlLoginPage);
            EaappPages.LoginPage.Login();
        }

        //[TearDown]
        //public void TearDown()
        //{
        //    string fileName = $"{TestContext.CurrentContext.Test.Name} - {DateTime.Now:yyyy.MM.dd-hh.mm.ss}";
        //    BrowserManager.Current.TakeScreenShot(fileName);
        //}

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            BrowserManager.Terminate();
        }
    }
}
