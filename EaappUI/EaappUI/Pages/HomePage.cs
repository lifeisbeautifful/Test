using Eaapp.Urls;
using EaappFramework.EaappFramework.CoreWeb;
using EaappFramework.EaappFramework.Elements;
using EaappUI.EaappUI.Pages;
using OpenQA.Selenium;

namespace Eaapp.Pages
{
    public class HomePage : BasePage
    {
      
        public HomePage(string pageUrl) : base(pageUrl)
        {

        }

        private CommonElement LoginLink => ElementFactory.Create<CommonElement>(Locator.Id("loginLink"));
        private CommonElement EmployeeListLink => ElementFactory.Create<CommonElement>(Locator.LinkText("Employee List"));
        private CommonElement LogOffLink => ElementFactory.Create<CommonElement>(Locator.LinkText("Log off"));

        private bool IsAt
        {
            get
            {
                try
                {
                    return LogOffLink.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public void NavigateToLoginPage()
        {
            LoginLink.Click();
        }

        public void NavigateToEmployeePage()
        {
            EmployeeListLink.Click();
        }

        public bool IsLoggedIn() => IsAt;
    }
}
