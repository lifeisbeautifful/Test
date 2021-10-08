using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Tests.DriverHelper;
using Tests.Pages;
using Tests.UserData;
using OpenQA.Selenium;
using Tests.Urls;

namespace Tests
{
    public class EditEmployeeTest:Drivers
    {
        
        private UsersData data;
        private RandomUsersData editedData;
        private CreatePage createPage;
        private EmployeeListPage employeeListPage;
        
       
        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(EAAPPUrls.urlHome);

            createPage = new CreatePage(Driver);
            employeeListPage = new EmployeeListPage(Driver);

            data = new UsersData();
            editedData = new RandomUsersData();
          
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
            employeeListPage.SearchEmployee(data.Name);
            employeeListPage.TestEditLink();
            createPage.SetUserData(editedData);
            createPage.SaveUserData();
            Assert.IsTrue(employeeListPage.IsAt(), "User is not navigated back to 'Employee List' page from 'Edit' page");

            employeeListPage.SearchEmployee(editedData.Name);
            var userDataFromUI = employeeListPage.GetActualSearchResultFromUI();
            bool IfUserDataFromUIMatchExpectedData = employeeListPage.IfUIDataContainsSearchedData(userDataFromUI, editedData);
            Assert.IsTrue(IfUserDataFromUIMatchExpectedData, "Edited user data from UI does not match with data set during edit process");
        }
        //var userDataFromUI = employeeListPage.GetUserDataFromUI();
        //employeeListPage.NavigateBack();
        //bool IfUserDataFromUIMatchExpectedData = editedData.Equals(userDataFromUI);
    }
}
