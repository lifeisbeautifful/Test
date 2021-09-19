using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Tests.Pages;
using Tests.UserData;

namespace Tests
{
    public class DeleteEmployeeTest:Drivers
    {
        private string urlHome = "http://eaapp.somee.com/";
        private string urlCreatePage = "http://eaapp.somee.com/Employee/Create";
        private UsersData data;
       
        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(urlHome);

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.Login();

            Navigate(urlCreatePage);
            CreatePage createPage = new CreatePage(Driver);
            data = new UsersData();
            createPage.SetUserData(data);
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
            employeeListPage.SearchEmployee(data.Name, "single");
            deletePage.DeleteEmployee(data.Name);
            employeeListPage.SearchEmployee(data.Name, "single");

            bool deleteResult = employeeListPage.CheckIfEmployeeDeleted(data.Name);
            Assert.IsTrue(deleteResult, "User is not deleted");
        }
    }
}
