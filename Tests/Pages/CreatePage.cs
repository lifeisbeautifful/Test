using OpenQA.Selenium;


namespace Tests.Pages
{
    public class CreatePage 
    {
        private IWebDriver Driver { get; set; }

        public CreatePage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement CreateNewButton => Driver.FindElement(By.XPath("//a[text()='Create New']"));
        private IWebElement NameInput => Driver.FindElement(By.Id("Name"));
        private IWebElement SalaryInput => Driver.FindElement(By.Id("Salary"));
        private IWebElement DurationWorkedInput => Driver.FindElement(By.Id("DurationWorked"));
        private IWebElement GradeInput => Driver.FindElement(By.Id("Grade"));
        private IWebElement EmailInput => Driver.FindElement(By.Id("Email"));
        private IWebElement CreateButton => Driver.FindElement(By.CssSelector("input[type='Submit']"));

        public CreatePage OpenCreatePage()
        {
            CreateNewButton.Click();
            return new CreatePage(Driver);
        }

        public void SetUserData(IUserData data)
        {
            NameInput.Clear();
            NameInput.SendKeys(data.Name);
            SalaryInput.Clear();
            SalaryInput.SendKeys(data.Salary.ToString());
            DurationWorkedInput.Clear();
            DurationWorkedInput.SendKeys(data.DurationWorked.ToString());
            GradeInput.Clear();
            GradeInput.SendKeys(data.Grade.ToString());
            EmailInput.Clear();
            EmailInput.SendKeys(data.Email);
        }

        public void SaveUserData()
        {
            CreateButton.Click();
        }
    }
}
