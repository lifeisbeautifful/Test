using OpenQA.Selenium;
using Eaapp.LoginCredentials;
using Eaapp.EaappFramework.DriverHelper;

namespace Eaapp.Pages
{
    public class LoginPage
    {
        private IWebDriver Driver;
        IJavaScriptExecutor executor = (IJavaScriptExecutor)Drivers.Driver;
       
        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
           
        }

        private IWebElement LogOffLink => Driver.FindElement(By.LinkText("Log off"));
        private IWebElement UsernameField => Driver.FindElement(By.ClassName("form-control"));
        private IWebElement PasswordField => Driver.FindElement(By.Name("Password"));
        private IWebElement LoginButton => Driver.FindElement(By.XPath("//input[@type='submit']"));
        private IWebElement LoginLink => Driver.FindElement(By.Id("loginLink"));
        //private IWebElement LoginLink => (IWebElement)executor.ExecuteScript("return document.getElementById(loginLink')");

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

        public bool IsUserLoggedIn() => IsAt;
        
        public void Login()
        {
            LoginLink.Click();
            UsernameField.SendKeys(AdminLoginCredentials.UserName);
            PasswordField.SendKeys(AdminLoginCredentials.Password);
            LoginButton.Click();
            //executor.ExecuteScript("arguments[0].Click", LoginButton);
        }
    }
}
