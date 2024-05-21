using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Classes
{
    internal class Vehicles
    {
        //Atributs i Propietats
        List<Vehicle> vehicles {  get; set; }

        //Constructors
        public Vehicles()
        {
            vehicles = new List<Vehicle>();
        }
    }
}
