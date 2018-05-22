using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleAppYield
{
    public class AsyncCls
    {
        public string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            threadId = AppDomain.GetCurrentThreadId();
            return "MyCallTime was " + callDuration.ToString();
        }
    }
    public delegate string AsyncDelegate(int callDuration, out int threadId);
}
