using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Classes
{
    internal class Persona
    {
        //Atributs i Propietats
        public string nom {  get; set; }
        public string cognom {  get; set; }
        public int telefon { get; set; }
        public string correu {  get; set; }
        public string direccio {  get; set; }
        public string usuari { get; set; }

        //Constructors (Hi hauria d'haver un constructor amb tots els parametres)
        public Persona() { }
    }
}
