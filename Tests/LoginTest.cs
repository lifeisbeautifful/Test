using NUnit.Framework;
using Tests.DriverHelper;
using Tests.Pages;
using Tests.Urls;

namespace Tests
{
    public class Tests:Drivers
    {
       
        private LoginPage loginPage;
        private UsersData data;

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
            loginPage = new LoginPage(Driver);
            data = new UsersData { Name = "Oksana", Salary = "4000", DurationWorked = "3", Grade = "2", Email = "a@mailforspam.com" };
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
            Navigate(EAAPPUrls.urlHome);
           
            loginPage.Login(data);
            Assert.That(loginPage.IsUserLoggedIn(), Is.True, "User is not logged in");
        }
    }
}