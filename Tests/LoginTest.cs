using NUnit.Framework;
using Tests.DriverHelper;
using Tests.Pages;

namespace Tests
{
    public class Tests:Drivers
    {
        private string urlHome = "http://eaapp.somee.com/";

        private LoginPage loginPage;
        private UsersData data;

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            loginPage = new LoginPage(Driver);
            data = new UsersData();
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
            Driver.Quit();
        }

        /// <summary>
        /// Login as admin user with valid credentials
        /// </summary>
        [Test]
        public void SuccessLoginWithValidCredentials()
        {
            Navigate(urlHome);
           
            loginPage.Login(data);
            Assert.That(loginPage.CheckIfUserLoggedIn(), Is.True, "User is not logged in");
        }
    }
}