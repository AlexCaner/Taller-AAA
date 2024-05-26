using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Mirar si hacer el using para acceder a otras carpetas 

namespace Programa.Classes
{
    internal class Cliente:Persona
    {
        //Atributs i Propietats
        public int idClient { get; set; }
        public static int numClients { get; set; }

        //Constructors
        public Cliente() : base() { }
        public Cliente(int idClient, string nom, string cognom, string direccio, string correu, int telefon, string usuari) : this()
        {
            this.idClient = idClient;
            this.nom = nom;
            this.cognom = cognom;
            this.direccio = direccio;
            this.correu = correu;
            this.telefon = telefon;
        }
    }
}
