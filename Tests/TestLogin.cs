using NUnit.Framework;
using Tests.Pages;

namespace Tests
{
    public class Tests:Drivers
    {
        public string urlHome = "http://eaapp.somee.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            ChooseDriver(Browsers.Chrome);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Close();
        }

        [Test]
        public void SuccessLoginWithValidCredentials()
        {
           
        }
    }
}