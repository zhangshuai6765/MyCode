using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield
{
    class Transportation
    {
        public Transportation()
        {
            Console.WriteLine("Transportation?");
        }

        public virtual void Say()
        {
            Console.WriteLine("121");
        }
    }

    class Sedan : Transportation
    {
        public Sedan()
        {
            Console.WriteLine("Transportation:Sedan");
        }

        public override void Say()
        {
            Console.WriteLine("Sedan");
        }
    }

    class Bicycles : Transportation
    {
        public Bicycles()
        {
            Console.WriteLine("Transportation:Bicycles");
        }

        public override void Say()
        {
            Console.WriteLine("Bicycles");
        }
    }
}
