using OpenQA.Selenium;


namespace Tests.Pages
{
    public class LoginPage
    {
        private IWebDriver Driver;
       
        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
           
        }

        private IWebElement LogOffLink => Driver.FindElement(By.LinkText("Log off"));
        private IWebElement UsernameField => Driver.FindElement(By.ClassName("form-control"));
        private IWebElement PasswordField => Driver.FindElement(By.Name("Password"));
        private IWebElement LoginButton => Driver.FindElement(By.XPath("//input[@type='submit']"));
        private IWebElement LoginLink => Driver.FindElement(By.Id("loginLink"));

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

        public bool IsUserLoggedIn()
        {
            if (IsAt) { return true; }
            return false;
        }

        public void Login(IUserData data)
        {
            LoginLink.Click();
            UsernameField.SendKeys(data.UserName);
            PasswordField.SendKeys(data.Password);
            LoginButton.Click();
        }
    }
}
