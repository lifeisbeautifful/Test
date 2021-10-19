using System;
using System.Diagnostics;


namespace Eaapp.EaappFramework.CustomWaiters
{
    public static class WaitForUrl
    {
        private const int DefaultTimeoutInSeconds = 10;
        public static void WaitForPageUrl(bool condition)
        {
            Stopwatch timer = Stopwatch.StartNew();

            do
            {
                if (condition)
                {
                    return;
                }
            } while (timer.Elapsed.TotalSeconds < DefaultTimeoutInSeconds);

            throw new TimeoutException();
        }
    }
}
