using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Tests.Pages;
using Tests.UserData;

namespace Tests
{
    public class EditEmployeeTest:Drivers
    {
        private string urlHome = "http://eaapp.somee.com/";
        private string urlCreateEmployee = "http://eaapp.somee.com/Employee/Create";
        private UsersData data;
        private RandomUsersData editedData;
       
        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(urlHome);

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.Login();

            Navigate(urlCreateEmployee);
            CreatePage createPage = new CreatePage(Driver);

            data = new UsersData();
            editedData = new RandomUsersData();
            createPage.SetUserData(data);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DeletePage deletePage = new DeletePage(Driver);
            deletePage.DeleteEmployee(editedData.Name);
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
         
            employeeListPage.EmployeePageNavigate();
            employeeListPage.SearchEmployee(data.Name, "single");
            employeeListPage.TestEditLink();
            createPage.SetUserData(editedData);
            var editedUserData = editedData.SetRandomUserData();
            Assert.IsTrue(employeeListPage.IsAt, "User is not navigated back to 'Employee List' page from 'Edit' page");

            var foundEditedEmployee = employeeListPage.SearchEmployee(editedUserData[0], "single");
            Assert.IsTrue(employeeListPage.CheckFoundEmployeeInputData(editedUserData,foundEditedEmployee));
        }
    }
}
