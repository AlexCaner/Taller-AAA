using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Mirar si hacer el using para acceder a otras carpetas 

namespace Programa.Classes
{
    internal class Client:Persona
    {
        //Atributs i Propietats
        public int idClient { get; set; }
        public static int numClients { get; set; }
        //Constructor
        public Client() : base() { }
    }
}
