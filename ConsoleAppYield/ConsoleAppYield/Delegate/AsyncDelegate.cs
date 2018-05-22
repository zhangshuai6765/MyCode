using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace ConsoleAppYield.Delegate
{
    public delegate int AddDelegate(int x, int y);

    /// <summary>
    /// 异步调用委托
    /// </summary>
    public class AsyncDelegate
    {
        public static void Main1234()
        {
            Console.WriteLine("Client application started!\n");
            Thread.CurrentThread.Name = "Main Thread";
            Calculator cal = new Calculator();
            AddDelegate del = new AddDelegate(cal.Add);
            string data = "Any data you want to pass.";

            AsyncCallback callback = new AsyncCallback(OnComplete);
            del.BeginInvoke(2, 5, callback, data); //异步调用方法

            // 做某些其它的事情，模拟需要执行3 秒钟
            for (int i = 1; i <= 3; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(i));
                Console.WriteLine("{0}: Client executed {1} second(s).", Thread.CurrentThread.Name, i);
            }
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }

        /// <summary>
        /// 异步回调函数
        /// 调用del.BeginInvoke()后不再需要保存IAysncResult返回值，回调函数的参数里已经定义 
        /// </summary>
        /// <param name="ar"></param>
        public static void OnComplete(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar;
            AddDelegate del = (AddDelegate)result.AsyncDelegate;
            string data = (string)ar.AsyncState;
            int rtn = del.EndInvoke(ar);
            Console.WriteLine("{0}: Result, {1}; Data: {2}\n", Thread.CurrentThread.Name, rtn, data);
        }
    }


    public class Calculator
    {
        public int Add(int x,int y)
        {
            if(Thread.CurrentThread.IsThreadPoolThread)
            {
                Thread.CurrentThread.Name = "Pool Thread";
            }
            Console.WriteLine("Method invoked");

            for (int i = 1; i <= 2; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("{0}:Add execute {1} second(s).", Thread.CurrentThread.Name, i);
            }
            Console.WriteLine("Method Complete!");
            return x + y;
        }

    }
}
