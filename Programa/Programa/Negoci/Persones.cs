using Programa.Dades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Classes
{
    internal class Persones:IEnumerable<Persona>
    {
        //Atributs i Propietats
        List<Persona> persones { get; set; }

        //Constructors
        public Persones()
        {
            persones = new List<Persona>();
        }
        public IEnumerator<Persona> GetEnumerator()
        {
            return persones.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return persones.GetEnumerator();
        }
    }
}
