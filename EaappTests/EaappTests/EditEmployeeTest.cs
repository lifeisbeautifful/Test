using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using Eaapp.UserData;
using Eaapp.Urls;
using EaappUI.EaappUI.Pages;
using EaappFramework.EaappFramework.CoreWeb;
using EaappTests;

namespace Eaapp
{
    [TestFixture]
    [AllureNUnit]
    public class EditEmployeeTest : BaseFixture
    {
        private UsersData data;
        private RandomUsersData editedData;
        

        [OneTimeSetUp]
        public void Setup()
        {
            data = new UsersData { Name = "Oksana", Salary = "4000", DurationWorked = "3", Grade = "2", Email = "a@mailforspam.com" };
            editedData = new RandomUsersData();
          
            BrowserManager.Current.Navigate(EAAPPUrls.urlCreatePage);
            EaappPages.CreatePage.SetUserData(data);
            EaappPages.CreatePage.SaveUserData();
        }

      
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            EaappPages.EmployeeListPage.DeleteEmployee(editedData.Name);
        }

        
        [Test(Description = "Edit employee data")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Oksana")]
        public void EditEmployeeData()
        {
            EaappPages.HomePage.NavigateToEmployeePage();
            EaappPages.EmployeeListPage.SearchEmployee(data.Name);
            EaappPages.EmployeeListPage.ClickEditLink();
            EaappPages.EditPage.SetUserData(editedData);
            EaappPages.EditPage.SaveUserData();
            Assert.IsTrue(EaappPages.EmployeeListPage.IsAt, "User is not navigated back to 'Employee List' page from 'Edit' page");

            EaappPages.EmployeeListPage.SearchEmployee(editedData.Name);
            var userDataFromUI = EaappPages.EmployeeListPage.GetActualSearchResultFromUI();
            bool IfUserDataFromUIMatchExpectedData = EaappPages.EmployeeListPage.IsUIDataContainsSearchedData(userDataFromUI, editedData);
            Assert.IsTrue(IfUserDataFromUIMatchExpectedData, "Edited user data from UI does not match with data set during edit process");
        }
    }
}
