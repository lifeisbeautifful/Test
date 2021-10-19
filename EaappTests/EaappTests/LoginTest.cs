using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using Eaapp.Urls;
using EaappUI.EaappUI.Pages;
using EaappFramework.EaappFramework.CoreWeb;
using EaappTests;

namespace Eaapp
{
    [TestFixture]
    [AllureNUnit]
    public class LoginTest 
    {

        [OneTimeSetUp]
        public void Setup()
        {
            BrowserManager.InitializeBrowser();
            BrowserManager.Current.Navigate(EAAPPUrls.urlHome);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            BrowserManager.Terminate();
        }

        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Oksana")]
        [Test(Description = "Login as admin user with valid credentials")]
        public void SuccessLoginWithValidCredentials()
        {
            EaappPages.HomePage.NavigateToLoginPage();
            EaappPages.LoginPage.Login();
            Assert.That(EaappPages.HomePage.IsLoggedIn(), Is.True, "User is not logged in");
        }
    }
}