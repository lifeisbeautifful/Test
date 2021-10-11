﻿using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using Eaapp.EaappFramework;
using Eaapp.UserInputData;
using Eaapp.Pages;
using Eaapp.Urls;
using Eaapp.EaappFramework.DriverHelper;

namespace Eaapp
{
    [TestFixture]
    [AllureNUnit]
    public class CreateNewEmployeeTest : Drivers
    {
       
        private UsersDataFromFile dataFromFile;
        private EmployeeListPage employeeListPage;
        private CreatePage createPage;
        

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(EAAPPUrls.urlHome);

            employeeListPage = new EmployeeListPage(Driver);
            createPage = new CreatePage(Driver);

            dataFromFile = new UsersDataFromFile();
            dataFromFile.DeSerializeInputDataFromFile();

            LoginPage loginPage = new LoginPage(Driver);

            if (!loginPage.IsUserLoggedIn())
            { 
                loginPage.Login();
            }
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
            deletePage.DeleteEmployee(dataFromFile.Name);
            Driver.Quit();
        }

        /// <summary>
        /// Create new user with data from employeeCreatedData array
        /// </summary>
        [Test(Description ="Create a new employee")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Oksana")]
        public void SuccessCreateNewEmployee()
        {
            var page = employeeListPage.NavigateToEmployeePage();
            Assert.AreEqual(page, true, "User is not navigated to 'Employee List' page");

            createPage.OpenCreatePage()
                      .SetUserData(dataFromFile);
            createPage.SaveUserData();
            Assert.IsTrue(employeeListPage.IsAt, "User is not navigated back to 'Employee List' page from 'Create' page");
            
            employeeListPage.SearchEmployee(dataFromFile.Name);
            var userDataFromUI = employeeListPage.GetActualSearchResultFromUI();

            bool IfDataFromFileMatchDataFromUI = employeeListPage.IsUIDataContainsSearchedData(userDataFromUI, dataFromFile);
            Assert.IsTrue(IfDataFromFileMatchDataFromUI, "User data from UI does not match user data set from file");
        }
    }
}