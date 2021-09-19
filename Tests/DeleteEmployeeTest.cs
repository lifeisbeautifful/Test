using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Tests.Pages;

namespace Tests
{
    public class DeleteEmployeeTest:Drivers
    {
        private string urlHome = "http://eaapp.somee.com/";
        private string urlCreatePage = "http://eaapp.somee.com/Employee/Create";
        string[] employeeData = { "Oksana", "4000", "2", "4", "a@mailforspam.com" };
        string[] employeeEditedData = { "Name", "3000", "1", "3", "a@mailforspam.com" };

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(urlHome);

            LoginPage loginPage = new LoginPage(Driver);
           
            loginPage.Login();
            Navigate(urlCreatePage);
            CreatePage createPage = new CreatePage(Driver);
            UserData data = new UserData();
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
            employeeListPage.SearchEmployee(employeeData[0], "single");
            deletePage.DeleteEmployee(employeeData[0]);
            employeeListPage.SearchEmployee(employeeData[0], "single");

            bool deleteResult = employeeListPage.CheckIfEmployeeDeleted(employeeData[0]);
            Assert.IsTrue(deleteResult, "User is not deleted");
        }
    }
}
