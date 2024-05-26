using Programa.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Negoci
{
    internal class Cotxe:Vehicle
    {
        public string carroceria {  get; set; }
        public int potencia {  get; set; }

        public Cotxe() : base() { }
    }
}
