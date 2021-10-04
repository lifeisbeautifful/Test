using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using Tests.DriverHelper;
using Tests.Pages;
using Tests.Urls;

namespace Tests
{
    public class SearchTest:Drivers
    {
       
        private EmployeeListPage employeeListPage;
        private UsersData data;

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(EAAPPUrls.urlHome);
            data = new UsersData();

            LoginPage loginPage = new LoginPage(Driver);

            if(!loginPage.IsUserLoggedIn())
            {
                loginPage.Login(data);
            }

            employeeListPage = new EmployeeListPage(Driver);
            employeeListPage.NavigateToEmployeePage();
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
        /// Search for all users that contain "Test" in name
        /// </summary>
        [Test]
        public void PerformSearch()
        {
            employeeListPage.SearchEmployee("Test");
            var actualSearchResult = employeeListPage.GetActualSearchResultFromUI();
            employeeListPage.NavigateBack();
            var expectedSearchResult = employeeListPage.ExpectedSearchResult("Test");
            CollectionAssert.AreEqual(expectedSearchResult, actualSearchResult);
        }
        //employeeListPage.TransferAllFoundUIDataToReadOnlyCollection();
        //var result=employeeListPage.CheckIfFoundDataMatchSearchCriteriaData("Test");  
        //Assert.That(result, Is.True, "Not all found users follow search criteria");
    }
}
