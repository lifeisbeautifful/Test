using EaappFramework.EaappFramework.CoreWeb;
using EaappFramework.EaappFramework.CoreWeb.Elements;
using EaappFramework.EaappFramework.Elements;
using EaappUI.EaappUI.Pages;

namespace Eaapp.Pages
{

 public class EditPage : BasePage
 {
        public EditPage(string pageUrl) : base(pageUrl)
        {

        }


        private CommonElement CreateNewButton => ElementFactory.Create<CommonElement>(Locator.XPath("//a[text()='Create New']"));
        private InputElement NameInput => ElementFactory.Create<InputElement>(Locator.Id("Name"));
        private InputElement SalaryInput => ElementFactory.Create<InputElement>(Locator.Id("Salary"));
        private InputElement DurationWorkedInput => ElementFactory.Create<InputElement>(Locator.Id("DurationWorked"));
        private InputElement GradeInput => ElementFactory.Create<InputElement>(Locator.Id("Grade"));
        private InputElement EmailInput => ElementFactory.Create<InputElement>(Locator.Id("Email"));
        private CommonElement CreateButton => ElementFactory.Create<CommonElement>(Locator.CssSelector("input[type='Submit']"));


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
