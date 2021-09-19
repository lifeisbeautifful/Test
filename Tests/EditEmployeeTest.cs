using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Tests.Pages;

namespace Tests
{
    public class EditEmployeeTest:Drivers
    {
        private string urlHome = "http://eaapp.somee.com/";
        private string urlCreateEmployee = "http://eaapp.somee.com/Employee/Create";
        string[] employeeData = { "Oksana", "4000", "2", "4", "a@mailforspam.com" };
        string[] employeeEditedData = { "Name", "3000", "1", "3", "a@mailforspam.com" };

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(urlHome);

            LoginPage loginPage = new LoginPage(Driver);
           
            loginPage.Login();
            Navigate(urlCreateEmployee);
            CreatePage createPage = new CreatePage(Driver);
            UserData data = new UserData();
            createPage.SetUserData(data);
            //employeeListPage.SetOrChangeUserData(employeeEditedData, employeeData);
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
            UserData data = new UserData();

            employeeListPage.EmployeePageNavigate();
            employeeListPage.SearchEmployee(employeeData[0], "single");
            employeeListPage.TestEditLink();
            createPage.SetUserData(data);
            Assert.IsTrue(employeeListPage.IsAt, "User is not navigated back to 'Employee List' page from 'Edit' page");

            var foundEditedEmployee = employeeListPage.SearchEmployee(employeeData[0], "single");
            Assert.IsTrue(employeeListPage.CheckFoundEmpData(foundEditedEmployee, employeeData));
        }
    }
}
