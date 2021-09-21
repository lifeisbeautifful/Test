using NUnit.Framework;
using Tests.DriverHelper;
using Tests.Pages;

namespace Tests
{
    public class Tests:Drivers
    {
        private string urlHome = "http://eaapp.somee.com/";

        private HomePage homePage;
        private LoginPage loginPage;
        private UsersData data;

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);//чекнути чи залогінено
            homePage = new HomePage(Driver);
            loginPage = new LoginPage(Driver);
            data = new UsersData();
        }

        [TearDown]
        public void TearDown()
        {
            TakeScreenShot screenShot = new TakeScreenShot(Driver);
            screenShot.TakeScreenShotAndCloseBrowser();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Close();
        }

        /// <summary>
        /// Login as admin user with valid credentials
        /// </summary>
        [Test]
        public void SuccessLoginWithValidCredentials()
        {
            Navigate(urlHome);
            homePage.NavigateToLoginPage();

            bool result = loginPage.Login(data);
            Assert.That(result, Is.True, "User is not logged in");
        }
    }
}