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
using System.Windows;

namespace Programa.Dades
{
    class PersonesBD
    {
        ConnexioBD connexio = new ConnexioBD();
        public Cliente TrobarClientBDD(string usuari)
        {
            Cliente client = null;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM Clients WHERE usuari = @usuari";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                sqlCommand.Parameters.AddWithValue("@usuari", usuari);

                MySqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read()) // Leer datos solo si hay resultados
                {
                    client = new Cliente(
                                        Convert.ToInt32(reader["idClient"]),
                                        reader["nom"].ToString(),
                                        reader["cognom"].ToString(),
                                        reader["direccio"].ToString(),
                                        reader["correu"].ToString(),
                                        Convert.ToInt32(reader["telefon"]),
                                        reader["usuari"].ToString(),
                                        reader["contrasenya"].ToString()
                    );
                }
                reader.Close();
                reader.Close();
                connection.Close();
            }
            return client;

        }
public Mecanic TrobarMecanicBDD(string usuari)
{
    Mecanic mecanic = null; // Inicializar mecánico como null
    MySqlConnection connection = connexio.ConnexioBDD();
    if (connection != null)
    {
        try
        {
            connection.Open();
            string sql = "SELECT * FROM Mecanics WHERE usuari = @usuari";
            MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
            sqlCommand.Parameters.AddWithValue("@usuari", usuari); // Añadir el parámetro

            MySqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read()) // Leer datos solo si hay resultados
            {
                mecanic = new Mecanic(
                                    Convert.ToInt32(reader["idMecanic"]),
                                    reader["nom"].ToString(),
                                    reader["cognom"].ToString(),
                                    reader["direccio"].ToString(),
                                    reader["correu"].ToString(),
                                    Convert.ToInt32(reader["telefon"]),
                                    reader["usuari"].ToString(),
                                    reader["contrasenya"].ToString()
                );
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            // Manejar excepciones (e.g., loguear el error)
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }
    }
    return mecanic;
}
        public bool TrobarUsuariMecanic(string usuari, string contrasenya)
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

                    // Añadir los parámetros a la consulta
                    sqlCommand.Parameters.AddWithValue("@usuari", usuari);
                    sqlCommand.Parameters.AddWithValue("@contrasenya", contrasenya);

                    // Ejecutar la consulta y obtener el número de filas coincidentes
                    int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    comprovacio = (count > 0);
                }
                catch (Exception ex)
                {
                    // Manejar la excepción (por ejemplo, mostrando un mensaje)
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    // Asegurarse de cerrar la conexión
                    connection.Close();
                }
            }
            return comprovacio;
        }
        public bool TrobarUsuariClient(string usuari, string contrasenya)
        {
            bool comprovacio = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT COUNT(*) FROM clients WHERE usuari = @usuari AND contrasenya = @contrasenya";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@usuari", usuari);
                    sqlCommand.Parameters.AddWithValue("@contrasenya", contrasenya);

                    int i = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    comprovacio = (i > 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Aquest usuari no existeix o la contrasenya no es correcte.");
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
