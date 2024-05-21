using Programa.Negoci;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Classes
{
    internal class Vehicles:IEnumerable<Vehicle>
    {
        //Atributs i Propietats
        List<Vehicle> vehicles {  get; set; }

        //Constructors
        public Vehicles()
        {
            vehicles = new List<Vehicle>();
        }
        public IEnumerator<Vehicle> GetEnumerator()
        {
            return vehicles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return vehicles.GetEnumerator();
        }
    }
}
