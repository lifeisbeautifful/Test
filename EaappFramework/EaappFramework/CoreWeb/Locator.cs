using OpenQA.Selenium;


namespace EaappFramework.EaappFramework.CoreWeb
{
    public sealed class Locator
    {
        internal By Wrapper;
        private Locator(By wrapper)
        {
            Wrapper = wrapper;
        }

        public static Locator Id(string id)
        {
            By byLocator = By.Id(id);
            return new Locator(byLocator);
        }

        public static Locator Name(string name)
        {
            By bylocator = By.Name(name);
            return new Locator(bylocator);
        }

        public static Locator ClassName(string className)
        {
            By bylocator = By.ClassName(className);
            return new Locator(bylocator);
        }

        public static Locator LinkText(string linkText)
        {
            By bylocator = By.LinkText(linkText);
            return new Locator(bylocator);
        }

        public static Locator XPath(string xpath)
        {
            By bylocator = By.XPath(xpath);
            return new Locator(bylocator);
        }

        public static Locator CssSelector(string css)
        {
            By bylocator = By.CssSelector(css);
            return new Locator(bylocator);
        }
    }
}
