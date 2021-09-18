using NUnit.Framework;
using Tests.Pages;

namespace Tests
{
    public class Tests:Drivers
    {
        private string urlHome = "http://eaapp.somee.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);//чекнути чи залогінено
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
            HomePage homePage = new HomePage(Driver);
            LoginPage loginPage = new LoginPage(Driver);

            Navigate(urlHome);
            homePage.NavigateToLoginPage();

            bool result=loginPage.SuccessLoginWithValidCredentials("admin", "password");
            Assert.That(result, Is.True, "User is not logged in");
        }
    }
}