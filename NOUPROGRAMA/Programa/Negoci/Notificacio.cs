
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
        public int idNotificacio { get; set; }
        public string usuari { get; set; }
        public string matricula { get; set; }
        public int llegida { get; set; }
        public string descripcio { get; set; }

        //Constructor
        public Notificacio() { }
        public Notificacio(string descripcio) { this.descripcio = descripcio; }
        public Notificacio(string usuari, string matricula, string descripcio) : this(descripcio)
        {
            this.usuari = usuari;
            this.matricula = matricula;
        }
        public Notificacio(int idNotificacio, string usuari, string matricula, int llegida, string descripcio) : this(usuari, matricula, descripcio)
        {
            this.idNotificacio = idNotificacio;
            this.llegida = llegida;
        }

    }
}
