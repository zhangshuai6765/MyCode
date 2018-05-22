using ConsoleAppYield.Delegate;
using ConsoleAppYield.DesignModel;
using ConsoleAppYield.DynamicCls;
using ConsoleAppYield.MemcacheTest;
using ConsoleAppYield.Testa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield
{
    class Program
    {
        private static int threadId;
        static void Main(string[] args) 
        {
            #region 委托
            //ConsoleAppYield.Delegate.AsyncDelegate.Main1234();
            //Console.ReadKey();

            //Subscriber.Exec();

            //delegateExample.Main123();

            //Console.ReadKey();

            #endregion

            string ruleItem = "[产品编码][工厂编码][流水号]GG";
            string[] arrayList = ruleItem.Split(new char[2] { '[', ']' });
            arrayList = arrayList.Where(m => !string.IsNullOrEmpty(m)).ToArray();


            IntToHex to = new IntToHex();
            for (int i = 0; i < 20000; i++)
            {
                string encryptstr = to.SetEncryption(2, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                Console.WriteLine(encryptstr);
            }
            Console.ReadKey();
            string to2 = to.IntToHex2(3201017, "0123456789ABCDEF");

            test1 t1 = new test1();
            t1.sync<yucha>();

            string zipname = "a33445566_b_c";
            string aaaa2 = zipname.Substring(0, zipname.IndexOf('_'));
            string appendCode = "20171114171236Z12";
            int secondRang = 10;
            string dateCode = appendCode.Substring(0, 14);

            DateTime dt123 = DateTime.ParseExact(dateCode, "yyyyMMddHHmmss", null);
            DateTime minDate11 = dt123.AddSeconds(-secondRang);
            DateTime maxDate = dt123.AddSeconds(secondRang);

            List<string> doubleList = new List<string>();

            for (DateTime minDate = dt123.AddSeconds(-secondRang); minDate < maxDate; minDate = minDate.AddSeconds(1))
            {
                double d = Convert.ToDouble(minDate.ToString("yyyyMMddHHmmss"));
                doubleList.Add(d + "Z12");
            }

            string ds = minDate11.ToString("yyyyMMddHHmmss");
            double dd = Convert.ToDouble(ds);


            //DateTime currentTime = DateTime.Now;
            //DateTime dt12345 = new DateTime(2018, 1, 1, 20, 10, 10);
            //TimeSpan d3 = currentTime.Subtract(dt12345).Duration();
            //int day = Convert.ToInt32(d3.Days);
            //int hour = Convert.ToInt32(d3.Hours);

            yucha.Test();
            //Intersect   Except
            List<string> list1 = new List<string>();
            list1.Add("1");
            list1.Add("2");
            list1.Add("3");
            list1.Add("5");
            list1.Add("9");

            List<string> list2 = new List<string>();
            //list2.Add("4");
            list2.Add("3");
            list2.Add("9");

            List<string> except = list2.Intersect(list1).ToList();
            List<string> aaa = list2.Except(except).ToList();


            bool abc = "abc".StartsWith("abd");

            //流向模拟数据
            DistinctTest.Distinct();


            //string path1 = "http://localhost:8091/wwwroot/DownloadFile/DownloadJcode/aaa.zip";
            //string path2 = path1.Substring(path1.IndexOf("DownloadFile"));
            //异步
            //AsyncCls async = new AsyncCls();
            //AsyncDelegate d = new AsyncDelegate(async.TestMethod);

            //IAsyncResult ar = d.BeginInvoke(3000, out threadId, new AsyncCallback(CallbackMethod), d);


            decimal dec = decimal.Round((decimal)36 / 127, 2) * 100;

            string stra = "123123123213123[常量:A1][对象:Product][加密位:2][加密位:4]";
            string[] sArray1 = stra.Split(new char[2] { '[', ']' });
            sArray1 = sArray1.Where(m => m != "").ToArray();
            if (sArray1.Any(m => m.Contains("加密位")))
            {

            }
            foreach (string i in sArray1)
                Console.WriteLine(i.ToString());

            //字符串转日期
            string str1 = "20170427165129";

            string a3 = str1.Substring(0, 14);

            DateTime dt = DateTime.ParseExact(str1, "yyyyMMddHHmmss", null);

          


            TreeCode code = new TreeCode();
            code.GetData();

            

            GroupByTest.GroupBy();
            string adb = "0123456789ABCDEFGHIJKLMNPQRSTUVWXYZ";
            string max = adb.Substring(adb.Length-1, 1);
            string maxValue = max.PadLeft(8, max.ToCharArray()[0]);



            AnyConvert convert = new AnyConvert();
            string adc = convert.X2X("zzzzzz", 62, 10);


            int a = Convert.ToInt32("16", 35);
            string sssd = "abcdef";
            sssd = sssd.Substring(0, 4);
            sssd = sssd.PadLeft(4, '0');


            string abe = DateTime.Now.ToString("y");
            

            string format = DateTime.Now.ToString("yyMMddHHmmss");
            string sss = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string sss1 = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            int TimeDuration = 60;
            int interval = 5;
            for (int i = 1; i <= TimeDuration / interval; i++)
            {
                int j = 0;
                j = i * interval;
                if (j <= TimeDuration)
                {
                    Console.WriteLine(j);
                }
            }




            


            string str= DateTime.Now.Ticks.ToString();
            List<bool> bList= LambdaExpress().Select(s => s.Key == "zs1").ToList();
            //List<string> strList = LambdaExpress().Select(delegate(string str)
            //{
            //    if (str == "zs1")
            //    {
            //        return str;
            //    }
            //    return "";
            //});

            int index = LambdaExpress().Where(m => m.Key == "zs1").First().Value;

            TestFat t = new TestFat();
            t.t1 = "1";
            t.t2 = "2";
            TestSon son = new TestSon();
            son = ConsoleAppYield.Testc.WhereTest<TestFat, TestSon>.AConvertToB(t);
            //son =. AConvertToB<TestFat>(son);


            HeapAndStack hs = new HeapAndStack();
            hs.Exec();
            Console.ReadKey();

            DynamicCls.DynamicExec.Exec2();

            //DynamicCls.Suoyinqi qi = new DynamicCls.Suoyinqi();
            //qi.Test();

            //DynamicCls.FanShe fs = new DynamicCls.FanShe();
            //fs.DataTableToT();

            //Console.ReadKey();

            DynamicCls.DynamicTest cls = new DynamicCls.DynamicTest();
            cls.Exec2();

            Console.ReadKey();

            Transportation transportation = new Transportation();
            transportation.Say();
            Transportation sedan = new Sedan();//这行代码与Sedan sedan=new Sedan()虽然调用say()方法都是子类的say方法;
                                                //但是实例化对象意思不一样，前者代表实例化的父类对象，后者代表实例化子类对象;
            sedan.Say();
            Console.ReadKey();

            //Memcache
            //OperateCache cache = new OperateCache();
            //cache.test();


            #region c# 中基类变量指向派生类对象的实例化

            //A a1 = new A();

            //C c = new C();
            //int m = c.m;

            //A a = new B();
            //a.Amethod();


            //A a = new C();
            //a.Amethod();
            
            #endregion

            People p = (People)Factory.GetInstance("People");
            p.Hit();

            //时间戳
            UnixStampDemp.StampToDataTime("10000");


            foreach (var item in YieldTest.Power(2,8))
            {
                Console.Write("{0} ", item);
            }

            //Console.ReadKey();

            HelloCollection helloCollection = new HelloCollection();
            foreach (var item in helloCollection )
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        private static void CallbackMethod(IAsyncResult ar)
        {
            AsyncDelegate dlgt = (AsyncDelegate)ar.AsyncState;

            // Call EndInvoke to retrieve the results.  
            string ret = dlgt.EndInvoke(out threadId, ar);

            Console.WriteLine("The call executed on thread zhangshuai");

        }


        private static Dictionary<string, int> LambdaExpress()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < 10; i++)
            {
                dic.Add("zs" + i, i);
            }
            return dic;
        }
    }

    public class YieldTest
    {
        public static IEnumerable Power(int number, int exponent) //==IEnumerable<int>
        {
            int counter = 0;
            int result = 1;
            while (counter++ < exponent)
            {
                result = result * number;
                yield return result;//虽然返回的值是int类型，但是因为有yield 所以会把值存放到泛型列表中
            }
        }
    }
    

    public class HelloCollection:IEnumerable
    {
        //private int[] array = new int[10];
        public IEnumerator GetEnumerator()
        {
            Enumerator enumerator = new Enumerator(0);
            return enumerator;
        }

        public class Enumerator:IEnumerator,IDisposable
        {
            private int state;
            private object current;

            public Enumerator(int state)
            {
                this.state = state;
            }

            public object Current
            {
                //get { throw new NotImplementedException(); }
                get { return current; }
            }

            public bool MoveNext()
            {
                //throw new NotImplementedException();

                switch(state)
                {
                    case 0:
                        current = "hello1";
                        state = 1;
                        return true;
                    case 1:
                        current = "world2";
                        state=2;
                        return true;
                    case 2:
                        break;
                }

                return false;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                //throw new NotImplementedException();
            }
        }
    }
}
