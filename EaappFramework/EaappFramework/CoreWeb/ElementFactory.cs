

namespace EaappFramework.EaappFramework.CoreWeb
{
    public static class ElementFactory
    {
        public static TElement Create<TElement>(Locator locator) where TElement : Element, new()
        {
            TElement element = new TElement() { LocatorWrapper = locator };
            return element;
        }
    }
}
