using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Tests.DriverHelper;
using Tests.Pages;
using Tests.UserData;

namespace Tests
{
    public class DeleteEmployeeTest:Drivers
    {
        private string urlHome = "http://eaapp.somee.com/";
        private string urlCreatePage = "http://eaapp.somee.com/Employee/Create";

        private UsersData data;
        private EmployeeListPage employeeListPage;
        private CreatePage createPage;
        private DeletePage deletePage;
       
        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(urlHome);

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.Login();

            Navigate(urlCreatePage);
            createPage = new CreatePage(Driver);
            employeeListPage = new EmployeeListPage(Driver);
            deletePage = new DeletePage(Driver);

            data = new UsersData();
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
            Driver.Close();
        }

        /// <summary>
        /// Delete created in 'SetUp' employee
        /// </summary>
        [Test]
        public void DeleteUser()
        {
            employeeListPage.NavigateToEmployeePage();
            employeeListPage.SearchEmployee(data.Name, "single");
            deletePage.DeleteEmployee(data.Name);
            employeeListPage.SearchEmployee(data.Name, "single");

            bool deleteResult = employeeListPage.CheckIfEmployeeDeleted();
            Assert.IsTrue(deleteResult, "User is not deleted");
        }
    }
}
