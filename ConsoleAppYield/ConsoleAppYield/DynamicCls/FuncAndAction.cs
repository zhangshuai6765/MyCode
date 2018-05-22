using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield.DynamicCls
{
    /// <summary>
    /// Func可以没有参数，但必须有返回值
    /// Func和Action委托的唯一区别在于Func要有返回值， Action没有返回值
    /// </summary>
    class FuncAndAction
    {
        public void Test()
        {
            int value=5;
            Action a = MM;
            a();

            Func<int> f1 = MM1;

            int v = f1();

            Func<int, int> f2 = MM1;
            int vv = f2(value);

            Action<int> a1 = MM;
            a1(value);
        }

        public void MM()
        {

        }

        public void MM(int param)
        {

        }

        public int MM1()
        {
            return 1;
        }

        public int MM1(int param)
        {
            return 2;
        }
    }
}
