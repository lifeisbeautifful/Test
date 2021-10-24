using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace EaappFramework.EaappFramework.CoreWeb
{
    public sealed class BrowserManager
    {
        private static Browser _browser;
        public static Browser Current => _browser;

        public static void InitializeBrowser(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    _browser = new Browser(new ChromeDriver());
                    break;
                case BrowserType.Firefox:
                    _browser = new Browser(new FirefoxDriver());
                    break;
            }
            _browser.MaximizeWindow();
        }

        public static void Terminate()
        {
            _browser.Quit();
        }
    }
}
