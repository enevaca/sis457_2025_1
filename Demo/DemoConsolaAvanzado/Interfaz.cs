using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsolaAvanzado
{
    interface IVhehiculo
    {
        void acelerar(int kmh);
        void frenar();
        void girar(int angulos);
    }

    class Automovil : IVhehiculo
    {
        public void acelerar(int kmh)
        {
            Console.WriteLine($"Acelerando {kmh} km/h...");
        }

        public void frenar()
        {
            Console.WriteLine("Frenando...");
        }

        public void girar(int angulos)
        {
            Console.WriteLine($"Girando {angulos} grados...");
        }
    }
}
