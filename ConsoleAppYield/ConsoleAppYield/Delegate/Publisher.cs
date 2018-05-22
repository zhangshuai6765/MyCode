using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield.Delegate
{
    /// <summary>
    /// 限制只允许一个客户端注册
    ///https://blog.csdn.net/beyonddeg/article/details/53528482
    /// </summary>
    public class Publishser
    {
        public delegate string GeneralEventHandler();

        private event GeneralEventHandler NumberChanged; // 声明一个私有事件

        // 注册事件
        public void Register(GeneralEventHandler method)
        {
            NumberChanged = method;
        }

        // 取消注册
        public void UnRegister(GeneralEventHandler method)
        {
            NumberChanged -= method;
        }

        

        public void DoSomething()
        {
            // 做某些其余的事情
            if (NumberChanged != null)
            { // 触发事件
                string rtn = NumberChanged();
                Console.WriteLine("Return: {0}", rtn); // 打印返回的字符串，输出为Subscriber3
            }
        }
        public string DoEvent()
        {
            return "bbb";
        }
    }


    public class Subscriber
    {
        public string DoEvent()
        {
            return "aaa";
        }

        public static void Exec()
        {
            Publishser publisher = new Publishser();
            publisher.Register(new Subscriber().DoEvent);
            publisher.Register(publisher.DoEvent);
            publisher.DoSomething();
        }
    }
}
