using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsola
{
    public class Persona
    {
        public string cedulaIdentidad { get; set; }
        public string nombres { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public long celular { get; set; }

        public virtual void saludar()
        {
            Console.WriteLine($"Soy {nombres} {primerApellido} y mi CI es {cedulaIdentidad}");
        }

        public int edad()
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (DateTime.Now.Month < fechaNacimiento.Month) edad--;
            else if (DateTime.Now.Month == fechaNacimiento.Month 
                && DateTime.Now.Day < fechaNacimiento.Day) edad--;
            return edad;
        }
    }
}
