using Eaapp.LoginCredentials;
using EaappUI.EaappUI.Pages;
using EaappFramework.EaappFramework.Elements;
using EaappFramework.EaappFramework.CoreWeb;
using EaappFramework.EaappFramework.CoreWeb.Elements;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Eaapp.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(string pageUrl):base(pageUrl)
        {

        }

        private InputElement UsernameField => ElementFactory.Create<InputElement>(Locator.ClassName("form-control"));
        private InputElement PasswordField => ElementFactory.Create<InputElement>(Locator.Name("Password"));
        private CommonElement LoginButton => ElementFactory.Create<CommonElement>(Locator.XPath("//input[@type='submit']"));
       

        public void Login()
        {
            UsernameField.SendKeys(AdminLoginCredentials.UserName);
            PasswordField.SendKeys(AdminLoginCredentials.Password);
            LoginButton.Click();
        }
    }
}
