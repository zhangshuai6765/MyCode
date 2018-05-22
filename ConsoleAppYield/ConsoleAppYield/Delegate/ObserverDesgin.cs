using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield.Delegate
{
    /// <summary>
    /// 观察者设计模式
    /// 通过委托事件解耦的设计，把私有变量temperature可以做为参数传给监察者们的方法
    /// </summary>
    public class ObserverDesgin
    {
        static void Main12()
        {
            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            heater.BoilEvent += alarm.MakeAlert; // 注册方法
            heater.BoilEvent += (new Alarm()).MakeAlert; // 给匿名对象注册方法
            heater.BoilEvent += Display.ShowMsg; // 注册静态方法
            heater.BoilWater(); // 烧水，会自动调用注册过对象的方法
        }
    }

    /// <summary>
    /// 监察对象
    /// </summary>
    public class Heater
    {
        private int temperature;

        public delegate void BoilHandler(int param);

        public event BoilHandler BoilEvent;

        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    if (BoilEvent != null)
                    {
                        BoilEvent(temperature); // 调用所有注册对象的方法
                    }
                }
            }
        }
    }

    /// <summary>
    /// 监视者——警报器
    /// </summary>
    public class Alarm
    {
        public void MakeAlert(int param)
        {
            Console.WriteLine("Alarm：嘀嘀嘀，水已经 {0} 度了：", param);
        }
    }

    /// <summary>
    /// 监视者——显示器
    /// </summary>
    public class Display
    {
        public static void ShowMsg(int param) // 静态方法
        {
            Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", param);
        }
    }
}
