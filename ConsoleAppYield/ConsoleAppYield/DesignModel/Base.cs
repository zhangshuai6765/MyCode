using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield.DesignModel
{
    public class Base : IAnimal
    {

        public virtual void Bite()
        {
            //throw new NotImplementedException();
        }

        public virtual void Shout()
        {
            //throw new NotImplementedException();
        }

        //public virtual void Factory()
        //{
        //    //throw new NotImplementedException();
        //}
    }

    public class People : Base, IPeople
    {
        public void Hit()
        {
            //throw new NotImplementedException();
        }

        public override void Bite()
        {
            base.Bite();
        }

        public override void Shout()
        {
            base.Shout();
        }
    }

    public class Animal : Base
    {

    }

    public class Cat : Animal
    {
        public override void Bite()
        {
            base.Bite();
        }

        public override void Shout()
        {
            base.Shout();
        }
    }

    public class Dog : Animal
    {
        public override void Bite()
        {
            base.Bite();
        }

        public override void Shout()
        {
            base.Shout();
        }
    }

    /// <summary>
    /// 简单工厂模式
    /// </summary>
    public class Factory
    {
      // public static  Base b = null;
        public static Base GetInstance(string type)
        {
            Base b = null;
            switch(type)
            {
                case "People":
                    b = new People();
                    break;
                case "Cat":
                    b = new Cat();
                    break;
                case "Dog":
                    b = new Dog();
                    break;
            }

            return b;
        }
    }

    /// <summary>
    /// 策略模式
    /// </summary>
    public class Strategy
    {
        Base b;
        public Strategy(Base b)
        {
            this.b = b;
        }

        public void CommonMethod()
        {
            b.Bite();
            b.Shout();
            if(b is People)
            {
                ((People)b).Hit();
            }
            
        }
    }
}
