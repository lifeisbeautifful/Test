

namespace EaappFramework.EaappFramework.CoreWeb.Elements
{
    public class InputElement : Element
    {
        public void SendKeys(string text)
        {
            Wrapper.SendKeys(text);
        }

        public void Clear()
        {
            Wrapper.Clear();
        }
    }
}
