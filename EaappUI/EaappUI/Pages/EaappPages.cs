using Eaapp.Pages;
using Eaapp.Urls;

namespace EaappUI.EaappUI.Pages
{
    public static class EaappPages
    {
        public static CreatePage CreatePage => new CreatePage(EAAPPUrls.urlCreatePage);
        public static EmployeeListPage EmployeeListPage => new EmployeeListPage(EAAPPUrls.urlEmployeeListPage);
        public static HomePage HomePage => new HomePage(EAAPPUrls.urlHome);
        public static LoginPage LoginPage => new LoginPage(EAAPPUrls.urlLoginPage);
        public static EditPage EditPage => new EditPage(EAAPPUrls.urlEditPage);
    }
}
