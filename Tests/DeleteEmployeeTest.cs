using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using Tests.DriverHelper;
using Tests.Pages;
using Tests.Urls;
using Tests.UserData;

namespace Tests
{
    public class DeleteEmployeeTest:Drivers
    {
       
        private UsersData data;
        private EmployeeListPage employeeListPage;
        private CreatePage createPage;
        private DeletePage deletePage;
       
        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(EAAPPUrls.urlHome);

            createPage = new CreatePage(Driver);
            employeeListPage = new EmployeeListPage(Driver);
            deletePage = new DeletePage(Driver);
            data = new UsersData();

            LoginPage loginPage = new LoginPage(Driver);

            if(!loginPage.IsUserLoggedIn())
            {
                loginPage.Login(data);
            }
            
            Navigate(EAAPPUrls.urlCreatePage);
            createPage.SetUserData(data);
            createPage.SaveUserData();
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
            employeeListPage.SearchEmployee(data.Name);
            deletePage.DeleteEmployee(data.Name);
            employeeListPage.SearchEmployee(data.Name);
            var actual = employeeListPage.GetActualSearchResultFromUI();
            bool IfUserExist = employeeListPage.CheckIfEmployeeExist(actual, data);
            Assert.IsFalse(IfUserExist, "User is not deleted");
        }
    }
}
