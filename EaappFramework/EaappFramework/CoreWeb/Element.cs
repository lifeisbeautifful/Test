using OpenQA.Selenium;


namespace EaappFramework.EaappFramework.CoreWeb
{
    public abstract class Element
    {
        internal IWebElement ParentWrapper;
        internal Locator LocatorWrapper;

        internal IWebElement Wrapper => ParentWrapper == null ? BrowserManager.Current.FindElement(LocatorWrapper)
            : ParentWrapper.FindElement(LocatorWrapper.Wrapper);

        public void Click()
        {
            Wrapper.Click();
        }

        public bool Displayed
        {
            get
            {
                return Wrapper.Displayed;
            }
        }

        public string Text
        {
            get
            {
                string text = Wrapper.Text;
                return text;
            }
        }
    }
} 
