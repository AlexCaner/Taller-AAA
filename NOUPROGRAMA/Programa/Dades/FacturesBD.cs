using MySql.Data.MySqlClient;
using Programa.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Dades
{
    class FacturesBD
    {
        ConnexioBD connexio = new ConnexioBD();
        public void InserirFacturaBD(string usuari, byte[] facturaHtml)
        {
            MySqlConnection connection = connexio.ConnexioBDD();

            try
            {
                // Conexión a la base de datos
                if (connection != null)
                {
                    connection.Open();

                    // Query para insertar la factura
                    string query = "INSERT INTO Facturas (usuari, FacturaHtml) VALUES (@usuari, @facturaHtml)";

                    // Crear un comando SQL
                    MySqlCommand sqlCommand = new MySqlCommand(query, connection);

                    // Asignar parámetros
                    sqlCommand.Parameters.AddWithValue("@usuari", usuari);
                    sqlCommand.Parameters.AddWithValue("@facturaHtml", facturaHtml);

                    // Ejecutar la consulta
                    sqlCommand.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al inserir la factura: " + ex.Message);
            }
        }

        // Método para recuperar la factura de la base de datos
        public byte[] ObtenerFacturaDeBaseDatos(string usuari)
        {
            byte[] facturaHtml = null;
            MySqlConnection connection = connexio.ConnexioBDD();

            try
            {
                // Conexión a la base de datos
                if (connection != null)
                {
                    connection.Open();

                    // Query para obtener la factura
                    string query = "SELECT FacturaHtml FROM Facturas WHERE usuari = @usuari";

                    // Crear un comando SQL
                    MySqlCommand sqlCommand = new MySqlCommand(query, connection);

                    // Ejecutar la consulta y obtener el resultado
                    MySqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        // Leer el contenido HTML como un arreglo de bytes
                        facturaHtml = (byte[])reader["FacturaHtml"];
                    }
                }

            
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la factura de la base de datos: " + ex.Message);
            }

            return facturaHtml;
        }
    }
}

