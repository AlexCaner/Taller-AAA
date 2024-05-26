using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Classes
{
    internal class Mecanic:Persona
    {
        //Atributs i Propietats
        public int idMecanic { get; set; }
        public static int numMecanics { get; set; }
        //Constructor
        public Mecanic() : base() { }
    }
}
