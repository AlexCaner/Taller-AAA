using Programa.Dades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Classes
{
    internal class Persones : IEnumerable<Persona>
    {
        //Atributs i Propietats
        List<Persona> persones { get; set; }
        PersonesBD personesBD = new PersonesBD();

        //Constructors
        public Persones()
        {
            persones = new List<Persona>();
        }
        public Mecanic TrobarMecanic(string usuari)
        {
           return personesBD.TrobarMecanicBDD(usuari);
        }
        public Cliente TrobarClient(string usuari)
        {
            return personesBD.TrobarClientBDD(usuari);

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
