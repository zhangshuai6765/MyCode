using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace ConsoleAppYield.DynamicCls
{
    public class Empolyee
    {
        public string FirstName { get; set; }

        public void Speak()
        {
            Console.WriteLine("My name is{0}", FirstName);
        }
    }

    public class DynamicTest
    {
        private object GetASpeak()
        {
            return new Empolyee() { FirstName = "zhangshuai" };
        }

        public void Exec()
        {
            Empolyee o = GetASpeak() as Empolyee;
            o.Speak();

            //反射
            object o1 = GetASpeak();
            MethodInfo info = o1.GetType().GetMethod("Speak");
            info.Invoke("Speak", null);

            //dynamic
            dynamic o2 = GetASpeak();
            o2.Speak();
            
            //程序未添加Dogs这个程序集引用
            //反射程序集
            //Type dogType = Assembly.Load("Dogs").GetType("Dogs.Dog");//命名空间.类名
            //dynamic dog = Activator.CreateInstance(dogType);
            //dog.Speak();
        }

        public void Exec1()
        {
            //ExpandoObject：表示一个对象，该对象包含可在运行时动态添加和移除的成员。
            dynamic expando = new ExpandoObject();
            expando.Name = "zhangshuai";
            //ExpandoObject不仅可以动态定义属性，还可以动态定义方法
            expando.Speak = new Action(() => Console.WriteLine("My name is {0}", expando.Name));
            expando.Speak();

            expando.ReturnSpeak = new Func<int>(delegate() { return 1; });//匿名方法 2.0
            expando.ReturnSpeak = new Func<int>(() => { return 1; });//匿名方法 3.0  （）的意思是省略了delegate
            expando.ReturnSpeak = new Func<int>(() => 1);//匿名方法 3.0还可以这么写
            expando.ReturnSpeak = new Func<int>(ReturnInt);
            int value = expando.ReturnSpeak();
        }

        private int ReturnInt()
        {
            return 1;
        }

        public void Exec2()
        {
            //处理xml基本就是这4种方法
            //1.XmlDocument
            //2.Linq to Xml

            //3.XDocument
            var doc = XDocument.Load(@"DynamicCls\Employees.xml");
            foreach (var item in doc.Element("Employees").Elements("Employee"))
            {
                Console.WriteLine(item.Element("FirstName").Value);
            }

            //4.dynamic 没看明白
            var doc2 = XDocument.Load(@"DynamicCls\Employees.xml").AsExpando();
            foreach (var employee in doc2.Employees)
            {
                Console.WriteLine(employee.FirstName);
            }
        }
    }

    public static class ExpandoXML
    {
        public static dynamic AsExpando(this XDocument doc)
        {
            return CreateExpando(doc.Root);
        }

        private static dynamic CreateExpando(XElement element)
        {
            var result = new ExpandoObject() as IDictionary<string, object>;
            if (element.Elements().Any(e => e.HasElements))
            {
                var list = new List<ExpandoObject>();
                result.Add(element.Name.ToString(), list);
                foreach (var childElement in element.Elements())
                {
                    list.Add(CreateExpando(childElement));
                }
            }
            else
            {
                foreach (var leafElement in element.Elements())
                {
                    result.Add(leafElement.Name.ToString(), leafElement.Value);
                }
            }
            return result;
        }
    }
}
