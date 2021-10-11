using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Tests.EaappFramework.CustomWaiters
{
    public static class WaitForUrl
    {
        private const int DefaultTimeoutInSeconds = 60;
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
