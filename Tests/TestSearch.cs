using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Tests.Pages;

namespace Tests
{
    public class TestSearch:Drivers
    {
        public string urlHome = "http://eaapp.somee.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(urlHome);

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.IfLoggedOff("admin", "password");

            EmployeeListPage employeeListPage = new EmployeeListPage(Driver);
            employeeListPage.EmployeePageNavigate();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        { 
            Driver.Close();
        }

        [Test]
        public void PerformSearch()
        {
            EmployeeListPage employeeListPage = new EmployeeListPage(Driver);
            var employees = employeeListPage.SearchEmployee("Test", "mult");
            bool result = employeeListPage.CheckFoundEmpData(employees, "mult", "Test");
            Assert.That(result, Is.True, "Not all found users follow search criteria");
        }
            
    }
}
