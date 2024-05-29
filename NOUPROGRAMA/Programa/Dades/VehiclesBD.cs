using MySql.Data.MySqlClient;
using Programa.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Dades
{
    internal class VehiclesBD
    {
        ConnexioBD connexio = new ConnexioBD();

        public List<Vehicle> TotsElsVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM Cotxes";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle vehicle = new Vehicle(
                        reader["matricula"].ToString(),
                        reader["marca"].ToString(),
                        reader["model"].ToString(),
                        Convert.ToInt32(reader["kilometratge"]),
                        Convert.ToDateTime(reader["anyFabriacio"]),
                        reader["tipusMotor"].ToString()
                        );
                    vehicles.Add(vehicle);
                }
                reader.Close();
                connection.Close();
            }
            return vehicles;
        }

        public void InsertarVehicleBDD(string matricula, string marca, string model, int kilometratge, DateTime anyFabriacio, string tipusMotor)
        {
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO cotxes (matricula, marca, model, kilometratge, anyFabriacio, tipusMotor) VALUES (@matricula, @marca, @model, @kilometratge, @anyFabriacio, @tipusMotor)";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@matricula", matricula);
                    sqlCommand.Parameters.AddWithValue("@marca", marca);
                    sqlCommand.Parameters.AddWithValue("@model", model);
                    sqlCommand.Parameters.AddWithValue("@kilometratge", kilometratge);
                    sqlCommand.Parameters.AddWithValue("@anyFabriacio", anyFabriacio);
                    sqlCommand.Parameters.AddWithValue("@tipusMotor", tipusMotor);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}