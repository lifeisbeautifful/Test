using System;
using System.Collections.Generic;
using NUnit.Framework;
using Tests.Pages;

namespace Tests
{
    public class CreateNewEmployeeTest:Drivers
    {
        private string urlHome = "http://eaapp.somee.com/";
        private UsersData data;

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(urlHome);

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.Login();
            data = new UsersData();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DeletePage deletePage = new DeletePage(Driver);
            deletePage.DeleteEmployee(data.Name);
            Driver.Close();
        }

        /// <summary>
        /// Create new user with data from employeeCreatedData array
        /// </summary>
        [Test]
        public void SuccessCreateNewEmployee()
        {
            EmployeeListPage employeeListPage = new EmployeeListPage(Driver);
            var page = employeeListPage.EmployeePageNavigate();
            Assert.AreEqual(page,true,"User is not navigated to 'Employee List' page");

            CreatePage createPage = new CreatePage(Driver);
            createPage.OpenCreatePage()
                      .SetUserData(data);
            var userData = data.GetUserData();
            Assert.IsTrue(employeeListPage.IsAt, "User is not navigated back to 'Employee List' page from 'Create' page");

            var foundCreatedEmployee = employeeListPage.SearchEmployee(userData[0], "single");
            Assert.IsTrue(employeeListPage.CheckFoundEmployeeInputData(userData,foundCreatedEmployee), "Found user data does " +
               "not match with search criteria");
        }
    }
}
