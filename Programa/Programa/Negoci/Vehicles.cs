using Programa.Dades;
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
        VehiclesBD vehiclesBD = new VehiclesBD();


        //Constructors
        public Vehicles()
        {
            vehicles = new List<Vehicle>();
        }

        public void TotsElsVehicles()
        {
            vehicles = vehiclesBD.TotsElsVehicles();
        }
        public void InsertVehicle(string matricula, string marca, string model, int kilometratge, DateTime anyFabriacio, string tipusMotor)
        {
            vehiclesBD.InsertarVehicleBDD(matricula, marca, model, kilometratge, anyFabriacio, tipusMotor);
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
