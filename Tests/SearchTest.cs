using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Tests.DriverHelper;
using Tests.Pages;

namespace Tests
{
    public class SearchTest:Drivers
    {
        private string urlHome = "http://eaapp.somee.com/";

        private EmployeeListPage employeeListPage;

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(urlHome);

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.Login();

            employeeListPage = new EmployeeListPage(Driver);
            employeeListPage.NavigateToEmployeePage();
        }

        [TearDown]
        public void TearDown()
        {
            TakeScreenShot screenShot = new TakeScreenShot(Driver);
            screenShot.ScreenShot();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        { 
            Driver.Close();
        }

        /// <summary>
        /// Search for all users that contain "Test" in name
        /// </summary>
        [Test]
        public void PerformSearch()
        {
            var employees = employeeListPage.SearchEmployee("Test", "mult");
            bool result = employeeListPage.CheckFoundEmployeeNames(employees, "Test");
            Assert.That(result, Is.True, "Not all found users follow search criteria");
        }    
    }
}
