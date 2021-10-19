using OpenQA.Selenium.Chrome;


namespace EaappFramework.EaappFramework.CoreWeb
{
    public sealed class BrowserManager
    {
        private static Browser _browser;
        public static Browser Current => _browser;

        public static void InitializeBrowser()
        {
            _browser = new Browser(new ChromeDriver());
            _browser.MaximizeWindow();
        }

        public static void Terminate()
        {
            _browser.Quit();
        }
    }
}
