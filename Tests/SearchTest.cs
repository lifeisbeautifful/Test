using NUnit.Framework;
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
        [TestCase("Test")]
        [TestCase("Karthik")]
        [TestCase("act")]
        [TestCase("fdg")]
        public void PerformSearch(string search)
        {
            employeeListPage.ClearSearchField();
            employeeListPage.SearchEmployee(search);
            var actualSearchResult = employeeListPage.GetActualSearchResultFromUI();
            employeeListPage.NavigateBack();
            var expectedSearchResult = employeeListPage.ExpectedSearchResult(search);
            bool ifFoundUsersFromUIMatchUsersWithSearchCriteria = employeeListPage.Compare(actualSearchResult, expectedSearchResult);
            Assert.IsTrue(ifFoundUsersFromUIMatchUsersWithSearchCriteria, "Found users on UI do not match users with such search criteria");
        }
        //employeeListPage.TransferAllFoundUIDataToReadOnlyCollection();
        //var result=employeeListPage.CheckIfFoundDataMatchSearchCriteriaData("Test");  
        //Assert.That(result, Is.True, "Not all found users follow search criteria");
        //CollectionAssert.AreEqual(expectedSearchResult, actualSearchResult);
    }
}
