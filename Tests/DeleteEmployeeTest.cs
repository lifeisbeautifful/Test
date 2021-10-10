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
    public class DeleteEmployeeTest : Drivers
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
            data = new UsersData { Name = "Oksana", Salary = "4000", DurationWorked = "3", Grade = "2", Email = "a@mailforspam.com" };

            LoginPage loginPage = new LoginPage(Driver);

            if(!loginPage.IsUserLoggedIn())
            {
                loginPage.Login();
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
        [Test(Description ="Delete employee")]
        [AllureOwner("Oksana")]
        [AllureSeverity(SeverityLevel.critical)]
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
