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
        public string id {  get; set; }
        public string usuari {  get; set; }
        public string matricula {  get; set; }
        public bool llegida {  get; set; }
        public string descripcio { get; set; }
        
        //Constructor
        public Notificacio() { }
        public Notificacio(string descripcio) { this.descripcio = descripcio; } //Este no creo que haga falta
        public Notificacio(string usuari, string matricula, string descripcio):this(descripcio)
        {
            this.usuari = usuari;
            this.matricula = matricula;
        }
        public Notificacio(int id, string usuari, string matricula, string descripcio) : this(descripcio)
        {
            this.usuari = usuari;
            this.matricula = matricula;
        }
    }
}
