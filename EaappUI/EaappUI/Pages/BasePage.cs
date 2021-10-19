using Eaapp.EaappFramework.CustomWaiters;
using EaappFramework.EaappFramework.CoreWeb;

namespace EaappUI.EaappUI.Pages
{
    public abstract class BasePage
    {
        protected BasePage(string pageUrl)
        {
            WaitForUrl.WaitForPageUrl(BrowserManager.Current.PageUrl.Contains(pageUrl));
        }
    }
}
