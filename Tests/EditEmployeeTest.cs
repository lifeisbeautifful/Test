using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Tests.DriverHelper;
using Tests.Pages;
using Tests.UserData;
using OpenQA.Selenium;

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

            createPage = new CreatePage(Driver);
            employeeListPage = new EmployeeListPage(Driver);

            data = new UsersData();
            editedData = new RandomUsersData();
          
            LoginPage loginPage = new LoginPage(Driver);

            if(!loginPage.IsUserLoggedIn())
            {
                loginPage.Login(data);
            }

            Navigate(urlCreateEmployee);//зробити
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
            var userDataFromUI = employeeListPage.GetUserDataFromUI(new RandomUsersData());
            bool IfUserDataFromUIMatchExpectedData = editedData.Equals(userDataFromUI);
            Assert.IsTrue(IfUserDataFromUIMatchExpectedData, "Edited user data from UI does not match with data set during edit process");
        }
        //var editedUserData = editedData.SetUserInputsToList();
        //var foundEditedEmployeeData = employeeListPage.TransferOnlyUserInputUIDataToReadOnlyCollection();
        //CollectionAssert.AreEqual(foundEditedEmployeeData, editedUserData);
    }
}
