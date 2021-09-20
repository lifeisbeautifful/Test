using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Tests.DriverHelper;
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
        private CreatePage createPage;
        private EmployeeListPage employeeListPage;
       
        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(urlHome);

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.Login();

            Navigate(urlCreateEmployee);
            createPage = new CreatePage(Driver);
            employeeListPage = new EmployeeListPage(Driver);

            data = new UsersData();
            editedData = new RandomUsersData();
            createPage.SetUserData(data);
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
            employeeListPage.NavigateToEmployeePage();
            employeeListPage.SearchEmployee(data.Name, "single");
            employeeListPage.TestEditLink();
            createPage.SetUserData(editedData);
            var editedUserData = editedData.SetUserInputsToList();
            Assert.IsTrue(employeeListPage.IsAt(), "User is not navigated back to 'Employee List' page from 'Edit' page");

            var foundEditedEmployee = employeeListPage.SearchEmployee(editedUserData[0], "single");
            Assert.IsTrue(employeeListPage.CheckFoundEmployeeInputData(editedUserData,foundEditedEmployee));
        }
    }
}
