using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsolaAvanzado
{
    internal class Inmutable
    {
        public readonly int year;
        public Inmutable(int year)
        {
            this.year = year;
        }

        void changeYear()
        {
            //year = 2015; // No se puede modificar un readonly
        }
    }
}
