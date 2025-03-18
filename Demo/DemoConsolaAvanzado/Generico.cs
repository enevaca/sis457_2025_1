using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsolaAvanzado
{
    class Generico<T, K>
    {
        public T campo1 { get; set; }
        public K campo2 { get; set; }

        public T imprimir(T campo)
        {
            Console.WriteLine($"Método genérico {campo}");
            return campo;
        }
    }
}
