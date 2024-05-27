using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.X509;
using Programa.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programa.Negoci;

namespace Programa.Dades
{
    class PersonesBD
    {
        ConnexioBD connexio = new ConnexioBD();
        public Cliente TrobarClientBDD(string usuari)
        {
            Cliente client = new Cliente();
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM Clients WHERE usuari = @usuari";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                client = new Cliente(
                                        Convert.ToInt32(reader["idClient"]),
                                        reader["nom"].ToString(),
                                        reader["cognom"].ToString(),
                                        reader["direccio"].ToString(),
                                        reader["correu"].ToString(),
                                        Convert.ToInt32(reader["telefon"]),
                                        reader["usuari"].ToString()
                );
                reader.Close();
                connection.Close();
            }
            return client;

        }
        public Mecanic TrobarMecanicBDD(string usuari)
        {
            Mecanic mecanic = new Mecanic();
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM Mecanics WHERE usuari = @usuari";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                mecanic = new Mecanic(
                                        Convert.ToInt32(reader["idMecanic"]),
                                        reader["nom"].ToString(),
                                        reader["cognom"].ToString(),
                                        reader["direccio"].ToString(),
                                        reader["correu"].ToString(),
                                        Convert.ToInt32(reader["telefon"]),
                                        reader["usuari"].ToString()
                );
                reader.Close();
                connection.Close();
            }
            return mecanic;
        }
        public bool TrobarUsuari(string usuari, string contrasenya)
        {
            bool comprovacio = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT COUNT(*) FROM Mecanics WHERE usuari = @usuari AND contrasenya = @contrasenya";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@usuari", usuari);
                    sqlCommand.Parameters.AddWithValue("@contrasenya", contrasenya);

                    // Execute the query and get the count of matching rows
                    int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    comprovacio = (count > 0);
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., log the error)
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return comprovacio;
        }
    }
}
