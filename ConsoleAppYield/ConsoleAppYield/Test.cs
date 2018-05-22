using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield
{
    public class Test
    {
        public void Method()
        {
            List<string> strList = new List<string>();
        }
    }

    public abstract class Test1 : Test
    {
        
    }

    public class A
    {
        public A()
        {
            Amethod();
        }

        public virtual void Amethod()
        {

        }

        public void AAmethod()
        {

        }
    }

    public class B:A
    {
        public int m = 1;
        public int n;
        public int t;
        public B()
        {
            n = 1;
        }

        public override void Amethod()
        {
            Console.WriteLine(string.Format("m is {0},n is {1}", m, n));
            //base.Amethod();
        }
        public static string s = null;
    }

    public class C:B
    {
        public C()
        {

        }

        public override void Amethod()
        {
              //base.Amethod();
        }

        public new int m;
    }
}
