using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Tests.Pages;

namespace Tests
{
    public class TestDeleteEmployee:Drivers
    {
        private string urlHome = "http://eaapp.somee.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(urlHome);

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.IfLoggedOff("admin", "password");

            CreatePage createUser = new CreatePage(Driver);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Close();
        }

        [Test]
        public void DeleteUser()
        {
            string[] employeeData = { "Oksana", "4000", "2", "4", "a@mailforspam.com" };
            EmployeeListPage employeeListPage = new EmployeeListPage(Driver);
            DeletePage deletePage = new DeletePage(Driver);

            employeeListPage.EmployeePageNavigate();
            employeeListPage.SearchEmployee(employeeData[0], "single");
            deletePage.DeleteEmployee(employeeData[0]);
            employeeListPage.SearchEmployee(employeeData[0], "single");

            bool deleteResult = employeeListPage.CheckIfEmployeeDeleted(employeeData[0]);
            Assert.IsTrue(deleteResult, "User is not deleted");
        }
    }
}
