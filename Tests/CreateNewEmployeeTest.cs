using System;
using System.Collections.Generic;
using NUnit.Framework;
using Tests.Pages;
using Tests.UserInputData;

namespace Tests
{
    public class CreateNewEmployeeTest:Drivers
    {
        private string urlHome = "http://eaapp.somee.com/";

        private UsersDataFromFile dataFromFile;
        private EmployeeListPage employeeListPage;
        private CreatePage createPage;

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(urlHome);

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.Login();

            employeeListPage = new EmployeeListPage(Driver);
            createPage = new CreatePage(Driver);
           
            dataFromFile = new UsersDataFromFile();
            dataFromFile.DeSerializeInputDataFromFile();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DeletePage deletePage = new DeletePage(Driver);
            deletePage.DeleteEmployee(dataFromFile.Name);
            Driver.Close();
        }

        /// <summary>
        /// Create new user with data from employeeCreatedData array
        /// </summary>
        [Test]
        public void SuccessCreateNewEmployee()
        {
            var page = employeeListPage.NavigateToEmployeePage();
            Assert.AreEqual(page,true,"User is not navigated to 'Employee List' page");

            createPage.OpenCreatePage()
                      .SetUserData(dataFromFile);
            var userData = dataFromFile.SetUserInputsToList();
            Assert.IsTrue(employeeListPage.IsAt, "User is not navigated back to 'Employee List' page from 'Create' page");

            var foundCreatedEmployee = employeeListPage.SearchEmployee(userData[0], "single");
            Assert.IsTrue(employeeListPage.CheckFoundEmployeeInputData(userData, foundCreatedEmployee), "Found user data does " +
               "not match with search criteria");
        }
    }
}
