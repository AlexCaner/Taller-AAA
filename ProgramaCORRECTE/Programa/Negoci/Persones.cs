using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Classes
{
    internal class Persones
    {
        //Atributs i Propietats
        List<Persona> persones { get; set; }

        //Constructors
        public Persones()
        {
            persones = new List<Persona>();
        }
    }
}
