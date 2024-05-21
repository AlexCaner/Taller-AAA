using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Classes
{
    internal class Moto:Vehicle
    {
        //Atributs i Propietats
        public string tipusMoto {  get; set; }
        public int potencia {  get; set; }

        //Constructors
        public Moto():base() { }
    }
}
