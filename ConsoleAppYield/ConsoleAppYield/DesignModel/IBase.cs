using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppYield.DesignModel
{
    public interface IPeople : IAnimal
    {
        void Hit();
    }

    public interface IAnimal
    {
        void Bite();

        void Shout();
    }
}
