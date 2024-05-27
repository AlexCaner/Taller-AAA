using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Classes
{
    internal class Vehicle
    {
        //Atributs i Propietats
        public string matricula {  get; set; }
        public string marca { get; set; }
        public string model { get; set; }
        public int kilometratge { get; set; }
        public DateTime anyFabriacio { get; set; }
        public string tipusMotor { get; set; }

        //Constructors (Hi hauria d'haver un amb tots els parametres)
        public Vehicle() { }
        public Vehicle(string matricula, string marca, string model, int kilometratge, DateTime anyFabriacio, string tipusMotor)
        {
            this.matricula = matricula;
            this.marca = marca;
            this.model = model;
            this.kilometratge = kilometratge;
            this.anyFabriacio = anyFabriacio;
            this.tipusMotor = tipusMotor;
        }


        //Metodes Publics
        public bool NecessitaPeces() {  return true; } //Hem de modificar-lo

    }
}
