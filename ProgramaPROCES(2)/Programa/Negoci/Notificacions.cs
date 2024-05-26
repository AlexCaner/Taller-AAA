using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Negoci
{
    internal class Notificacions
    {
        //Atributs i Propietats
        List<Notificacio> notificacions {  get; set; }

        //Constructors
        public Notificacions()
        {
            notificacions = new List<Notificacio>();
        }
    }
}
