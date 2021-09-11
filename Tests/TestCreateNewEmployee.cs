using System;
using NUnit.Framework;
using Tests.Pages;

namespace Tests
{
    public class TestCreateNewEmployee:Drivers
    {
        public string urlHome = "http://eaapp.somee.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(urlHome);

            LoginPage loginPage = new LoginPage(Driver);
            loginPage.IfLoggedOff("admin", "password");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Close();
        }

        [Test]
        public void SuccessCreateNewEmployee()
        {
            string[] employeeCreatedData = { "Oksana", "4000", "2", "4", "a@mailforspam.com" };
            string[] employeeEditedData = { "Name", "3000", "1", "3", "a@mailforspam.com" };

            EmployeeListPage employeeListPage = new EmployeeListPage(Driver);
            var page = employeeListPage.EmployeePageNavigate();
            Assert.AreEqual(page,true,"User is not navigated to 'Employee List' page");

            CreatePage createPage = new CreatePage(Driver);
            createPage.OpenCreatePage()
                      .CreateEditEmployee(employeeEditedData,employeeCreatedData);
            Assert.IsTrue(employeeListPage.IsAt, "User is not navigated back to 'Employee List' page from 'Create' page");

            var foundCreatedEmployee = employeeListPage.SearchEmployee(employeeCreatedData[0], "single");
            Assert.IsTrue(employeeListPage.CheckFoundEmpData(foundCreatedEmployee, employeeCreatedData), "Found user data does " +
               "not match with search criteria");
        }
    }
}
