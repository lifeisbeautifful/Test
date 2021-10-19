using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using Eaapp.Urls;
using EaappUI.EaappUI.Pages;
using EaappFramework.EaappFramework.CoreWeb;
using EaappTests;

namespace Eaapp
{
    [TestFixture]
    [AllureNUnit]
    public class DeleteEmployeeTest : BaseFixture
    {
        private UsersData data;
       

        [OneTimeSetUp]
        public void Setup()
        {
            data = new UsersData { Name = "Oksana", Salary = "4000", DurationWorked = "3", Grade = "2", Email = "a@mailforspam.com" };
            BrowserManager.Current.Navigate(EAAPPUrls.urlCreatePage);
            EaappPages.CreatePage.SetUserData(data);
            EaappPages.CreatePage.SaveUserData();
        }

        
        [Test(Description = "Delete employee")]
        [AllureOwner("Oksana")]
        [AllureSeverity(SeverityLevel.critical)]
        public void DeleteUser()
        {
            EaappPages.EmployeeListPage.SearchEmployee(data.Name);
            EaappPages.EmployeeListPage.DeleteEmployee(data.Name);
            EaappPages.EmployeeListPage.SearchEmployee(data.Name);
            var actual = EaappPages.EmployeeListPage.GetActualSearchResultFromUI();
            bool IfUserExist = EaappPages.EmployeeListPage.CheckIfEmployeeExist(actual, data);
            Assert.IsFalse(IfUserExist, "User is not deleted");
        }
    }
}
