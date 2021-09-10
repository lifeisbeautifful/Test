using System;
using NUnit.Framework;
using Tests.Pages;

namespace Tests
{
    public class TestCreateNewEmployee:Drivers
    {
        public string urlHome = "http://eaapp.somee.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(urlHome);

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.IfLoggedIn();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Close();
        }

        [Test]
        public void SuccessCreateNewEmployee()
        {
            CreatePage createPage = new CreatePage(Driver);
            createPage.OpenCreatePage();
        }
    }
}
