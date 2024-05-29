using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Classes
{
    internal class Mecanic:Persona
    {
        //Atributs i Propietats
        public int idMecanic { get; set; }
        public static int numMecanics { get; set; }
        //Constructor
        public Mecanic() : base() { }
        public Mecanic(int idMecanic, string nom, string cognom, string direccio, string correu, int telefon, string usuari, string contrasenya) : this()
        {
            this.idMecanic = idMecanic;
            this.nom = nom;
            this.cognom = cognom;
            this.direccio = direccio;
            this.correu = correu;
            this.telefon = telefon;
            this.usuari = usuari;
            this.contrasenya = contrasenya;
        }
    }
}
