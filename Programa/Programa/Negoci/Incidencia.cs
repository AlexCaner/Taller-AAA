using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Negoci
{
    internal class Incidencia
    {

        //Atributs i Propietats
        public int id {  get; set; }
        public string usuari { get; set; }
        public string matricula { get; set; }
        public string descripcio { get; set; }
        public string estat {  get; set; }

        //Constructor
        public Incidencia() { }
        public Incidencia(string usuari, string matricula, string descripcio, string estat)
        {
            this.usuari = usuari;
            this.matricula = matricula;
            this.descripcio = descripcio;
            this.estat = estat;
        }
        public Incidencia(int id, string usuari, string matricula, string descripcio, string estat)
        {
            this.usuari = usuari;
            this.matricula = matricula;
            this.descripcio = descripcio;
            this.estat = estat; 
        }
    }

}

