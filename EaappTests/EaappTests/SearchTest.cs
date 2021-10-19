using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using Eaapp.Urls;
using EaappUI.EaappUI.Pages;
using EaappTests;

namespace Eaapp
{
    [TestFixture]
    [AllureNUnit]
    public class SearchTest : BaseFixture
    {

        [OneTimeSetUp]
        public void Setup()
        {
            EaappPages.HomePage.NavigateToEmployeePage();
        }

     
        [Test(Description = "Perform search with different parameters")]
        [TestCase("Test")]
        [TestCase("Karthik")]
        [TestCase("act")]
        [TestCase("fdg")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Oksana")]
        public void PerformSearch(string search)
        {
            EaappPages.EmployeeListPage.ClearSearchField();
            EaappPages.EmployeeListPage.SearchEmployee(search);
            var actualSearchResult = EaappPages.EmployeeListPage.GetActualSearchResultFromUI();
            EaappPages.EmployeeListPage.NavigateBack();
            var expectedSearchResult = EaappPages.EmployeeListPage.ExpectedSearchResult(search);
            bool ifFoundUsersFromUIMatchUsersWithSearchCriteria = EaappPages.EmployeeListPage.Compare(actualSearchResult, expectedSearchResult);
            Assert.IsTrue(ifFoundUsersFromUIMatchUsersWithSearchCriteria, "Found users on UI do not match users with such search criteria");
        }
    }
}
