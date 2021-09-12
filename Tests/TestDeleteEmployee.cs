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
        string[] employeeData = { "Oksana", "4000", "2", "4", "a@mailforspam.com" };
        string[] employeeEditedData = { "Name", "3000", "1", "3", "a@mailforspam.com" };

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(urlHome);

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.IfLoggedOff("admin", "password");

            EmployeeListPage employeeListPage = new EmployeeListPage(Driver);
            employeeListPage.SetOrChangeUserData(employeeEditedData, employeeData);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Close();
        }

        /// <summary>
        /// Delete created in 'SetUp' employee
        /// </summary>
        [Test]
        public void DeleteUser()
        {
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
