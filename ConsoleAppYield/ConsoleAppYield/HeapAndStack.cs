using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield
{
   
    public class Thing
    {

    }

    public class Animal:Thing
    {
        public int Weight { get; set; }
    }
    public class Vegetable:Thing
    {
        public int Height { get; set; }
    }

    /// <summary>
    /// Heap是堆 
    /// Stack 是栈
    /// </summary>
    public class HeapAndStack
    {
        public void Exec()
        {
            Thing x = new Animal();
            Switcharoo(x);//ref x

            Console.WriteLine("x is Animal :" + (x is Animal).ToString());//true

            Console.WriteLine("x is Vegetable:" + (x is Vegetable).ToString());//false

            Switcharoo(ref x);//ref x 与 out x形式基本类似,结果相同

            Console.WriteLine("x is Animal :" + (x is Animal).ToString());//false

            Console.WriteLine("x is Vegetable:" + (x is Vegetable).ToString());//true
            
        }

        /// <summary>
        /// 【栈中值引用类型指针传递】
        /// 1.栈中有一个x指针，x指针指向堆中Animal类型；
        /// 2.在调用Switcharoo方法后，栈中压一个新的pValue指针，把pValue指针指向x[栈中];
        /// 3.Vegetable类型在堆中创建，由栈中的pValue指针指向；
        /// 4.但是栈中x的指针类型还是Animal，没有指向Vegetable; 
        /// </summary>
        /// <param name="pValue"></param>
        public void Switcharoo(Thing pValue) // ref Thing pValue
        {
            pValue = new Vegetable();//pValue新的对象，但是x的指针还是指向的Animal
        }

        /// <summary>
        /// 参数带有ref关键字时，引用类型传递的是引用类型的指针
        /// 1.栈中有一个x指针，x指针指向堆中Animal类型；
        /// 2.在调用Switcharoo方法后，栈中压一个新的pValue指针，把pValue指针指向x[栈中];
        /// 3.Vegetable类型在堆中创建，由栈中的pValue指针指向；
        /// 4.因为参数带有ref关键字，用引用方式传递引用类型，所以更改x的指针指向Vegetable类型；
        /// </summary>
        /// <param name="pValue"></param>
        public void Switcharoo(ref Thing pValue) // ref Thing pValue
        {
            pValue = new Vegetable();//pValue新的对象，由于ref,x的指针更改为指向的Vegetable
        }
    }
}
