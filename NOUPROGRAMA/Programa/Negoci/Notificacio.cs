using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Negoci
{
    internal class Notificacio
    {
        //Atributs i Propietats
        public int id {  get; set; }
        public bool llegida {  get; set; }
        public bool eliminada { get; set; }
        public string descripcio { get; set; }
        
        //Constructor
        public Notificacio() { }

    }
}
