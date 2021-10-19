using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using Eaapp.UserInputData;
using EaappUI.EaappUI.Pages;
using EaappTests;

namespace Eaapp
{
    [TestFixture]
    [AllureNUnit]
    public class CreateNewEmployeeTest : BaseFixture
    {
       
        private UsersDataFromFile dataFromFile;
       
        
        [OneTimeSetUp]
        public void Setup()
        {
            dataFromFile = new UsersDataFromFile();
            dataFromFile.DeSerializeInputDataFromFile();
        }

       
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            EaappPages.EmployeeListPage.DeleteEmployee(dataFromFile.Name);
        }

        
        [Test(Description ="Create a new employee")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Oksana")]
        public void SuccessCreateNewEmployee()
        {
            EaappPages.HomePage.NavigateToEmployeePage();
            EaappPages.EmployeeListPage.OpenCreatePage()
                      .SetUserData(dataFromFile);
            EaappPages.CreatePage.SaveUserData();
            Assert.IsTrue(EaappPages.EmployeeListPage.IsAt, "User is not navigated back to 'Employee List' page from 'Create' page");
            
            EaappPages.EmployeeListPage.SearchEmployee(dataFromFile.Name);
            var userDataFromUI = EaappPages.EmployeeListPage.GetActualSearchResultFromUI();

            bool IfDataFromFileMatchDataFromUI = EaappPages.EmployeeListPage.IsUIDataContainsSearchedData(userDataFromUI, dataFromFile);
            Assert.IsTrue(IfDataFromFileMatchDataFromUI, "User data from UI does not match user data set from file");
        }
    }
}
