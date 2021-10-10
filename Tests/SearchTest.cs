using NUnit.Framework;
using Tests.DriverHelper;
using Tests.Pages;
using Tests.Urls;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace Tests
{
    [TestFixture]
    [AllureNUnit]
    public class SearchTest : Drivers
    {
       
        private EmployeeListPage employeeListPage;
        private UsersData data;

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            Navigate(EAAPPUrls.urlHome);
            data = new UsersData { Name = "Oksana", Salary = "4000", DurationWorked = "3", Grade = "2", Email = "a@mailforspam.com" };

            LoginPage loginPage = new LoginPage(Driver);

            if(!loginPage.IsUserLoggedIn())
            {
                loginPage.Login();
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
        [Test(Description ="Perform search with different parameters")]
        [TestCase("Test")]
        [TestCase("Karthik")]
        [TestCase("act")]
        [TestCase("fdg")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Oksana")]
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
    }
}
