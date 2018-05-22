using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleAppYield.DynamicCls
{

    //ExpandoObject与DynamicObject区别
    //首先，ExpandoObject可以直接new()对象实例，实例.属性就可以get和set；实例.方法可以action，Func；
    //如果需要也可以使用ExpandoObject返回dynamic类型，进行对dynamic进行动态取值，例如ExpandoXML，比较直接，干，可塑性不大；
    //DynamicObject需要派生类进行继承，在派生类中重写method或member方法，感觉有无限的可能，可以自定义结果（out object result）的数据形式；
    //DynamicObject派生类相于一个工厂，根据原料(实例.属性或方法)，返回想要的自定义的值；


   public class DynamicProduct:DynamicObject
    {
        Dictionary<string, object> dic = new Dictionary<string, object>();
        //private string Nam { get; set; }

        public DynamicProduct(Dictionary<string,object> dic)
        {
            this.dic = dic;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            //Console.WriteLine("TrySetMember被调用了，Name:{0}", binder.Name);
            //base.TrySetMember(binder, value);
            //return true;
            var name = binder.Name;
            dic[name] = value;
            Console.WriteLine("写入 {0} = {1}", name, value);
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            //bool bol = base.TryGetMember(binder, out result);
            return dic.TryGetValue(binder.Name, out result);
        }
    }

    /// <summary>
   ///  把一个索引器写成属性的形式取值和赋值
    /// </summary>
    public class DynamicIndexer:DynamicObject
    {
        Indexer2 index2 = new Indexer2();//要求类中必须索引器
        public DynamicIndexer(Indexer2 index2)
        {
            this.index2 = index2;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = index2[binder.Name];
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            index2[binder.Name] = value.ToString();
            return true;
            //return base.TrySetMember(binder, value);
        }
    }

    /// <summary>
    /// 使用泛型的形式把索引器写成属性的形式取值和赋值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DynamicIndexer<T> : DynamicObject where T :new()
    {
        T t = new T();
        public DynamicIndexer(T tt)
        {
            this.t = tt;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            //可以加上一个判断，是否是索引器属性
            //GetIndexParameters.legnth

            //反射获取索引器属性值
            string name = binder.Name;
            PropertyInfo info = t.GetType().GetProperty("RenameIndex");//RenameIndex很重要，需要在索引器上加上IndexName特性
            result = info.GetValue(t, new object[] { name });

            //可以得到索引器的参数
            //PropertyInfo[] info = index2.GetType().GetProperties();
            //ParameterInfo[] param = info[0].GetIndexParameters();
            return true;

        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            //可以加上一个判断，是否是索引器属性

            //反射获取索引器属性值
            string name = binder.Name;
            PropertyInfo info = t.GetType().GetProperty("RenameIndex");//RenameIndex很重要，需要在索引器上加上IndexName特性
            info.SetValue(t, value, new object[] { name });
            return true;
        }
    
   
    }
    /// <summary>
    /// DynamicObject 的作用其实就是把字典（dictionary）类型索引器的取值方式，转换成属性的取值方式
    /// </summary>
    public class DynamicExec
    {
        /// <summary>
        ///  DynamicObject 的作用其实就是把字典（dictionary）类型索引器的取值方式，转换成属性的取值方式
        /// </summary>
        public static void Exec()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                {"Name","Frank"},
                {"Age",23}
            };

            dynamic myObj = new DynamicProduct(dic);
            Console.WriteLine(myObj.Name);
            Console.WriteLine(myObj.Age);

        }

        /// <summary>
        /// 把一个索引器写成属性的形式取值和赋值
        /// </summary>
        public static void Exec1()
        {
            Indexer2 index2 = new Indexer2();
            index2["aaa"] = "aa";
            index2["bbb"] = "bb";

            dynamic myObj = new DynamicIndexer(index2);
            myObj.ccc = "cc";
            Console.WriteLine(myObj.ccc);
            string value = myObj.aaa;
            Console.WriteLine(myObj.aaa);
        }

        /// <summary>
        /// 使用泛型的形式把索引器写成属性的形式取值和赋值
        /// </summary>
        public static void Exec2()
        {
            Indexer5 index5 = new Indexer5();
            index5["abc"] = 123;
            index5["mmm"] = "ccc";

            dynamic myObj = new DynamicIndexer<Indexer5>(index5);
            string value = myObj.mmm;
            Console.WriteLine(value);
            myObj.ddd = 999;
            Console.WriteLine(index5["ddd"]);
            Console.WriteLine(myObj.ddd);
        }
    }
}
