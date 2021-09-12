using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Tests.Pages;

namespace Tests
{
    public class TestEditEmployee:Drivers
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
            DeletePage deletePage = new DeletePage(Driver);
            deletePage.DeleteEmployee(employeeEditedData[0]);
            Driver.Close();
        }

        /// <summary>
        /// Edit created in 'SetUp' employee 
        /// </summary>
        [Test]
        public void EditEmployeeData()
        {
            CreatePage createPage = new CreatePage(Driver);
            EmployeeListPage employeeListPage = new EmployeeListPage(Driver);
            EditPage editPage = new EditPage(Driver);

            employeeListPage.EmployeePageNavigate();
            employeeListPage.SearchEmployee(employeeData[0], "single");
            employeeListPage.TestEditLink();
            editPage.SetOrChangeUserData(employeeEditedData, employeeData);
            Assert.IsTrue(employeeListPage.IsAt, "User is not navigated back to 'Employee List' page from 'Edit' page");

            var foundEditedEmployee = employeeListPage.SearchEmployee(employeeEditedData[0], "single");
            Assert.IsTrue(employeeListPage.CheckFoundEmpData(foundEditedEmployee, employeeEditedData));
        }
    }
}
