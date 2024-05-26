using MySql.Data.MySqlClient;
using Programa.Negoci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Dades
{
    internal class NotificacionsBD
    {

        ConnexioBD connexio = new ConnexioBD();
        public List<Notificacio> TotesLesNoti()
        {
            List<Notificacio> notificacions = new List<Notificacio>();
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                connection.Open();
                string sql = $"SELECT * FROM notificacions";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Notificacio notificacio = new Notificacio(Convert.ToInt32(reader["idNotificacio"]), reader["usuari"].ToString(), reader["matricula"].ToString(), Convert.ToInt32(reader["llegida"]), reader["descripcio"].ToString());
                    notificacions.Add(notificacio);
                }
                reader.Close();
                connection.Close();
            }
            return notificacions;
        }
        public List<Notificacio> BorrarTotesLesNoti() // Metode Borra LLista de notificacions
        {
            List<Notificacio> notificacions = new List<Notificacio>();
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                connection.Open();
                string sql = $"DELETE * FROM notificacions";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                connection.Close();
            }
            return notificacions;
        }
        public void InsertNotiBDD(int llegida, string usuari, string matricula, string descripcio)
        {
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                try
                {
                    connection.Open();
                    string sql = $"INSERT INTO notificacions (llegida, usuari, matricula, descripcio) VALUES (@llegida, @usuari, @matricula, @descripcio)";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@llegida", llegida);
                    sqlCommand.Parameters.AddWithValue("@usuari", usuari);
                    sqlCommand.Parameters.AddWithValue("@matricula", matricula);
                    sqlCommand.Parameters.AddWithValue("@descripcio", descripcio);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {

                    };
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
        public void EliminarNotiBDD(int idNotificacio)
        {
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                try
                {
                    connection.Open();
                    string sql = $"DELETE FROM notificacions WHERE idNotificacio = @idNotificacio";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@idNotificacio", idNotificacio);

                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                    };
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
        public void UpdateNotiBDD(int idNotificacio, int llegida)
        {
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                try
                {
                    connection.Open();
                    string sql = $"UPDATE notificacions SET llegida = @llegida WHERE idNotificacio = @idNotificacio";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@idNotificacio", idNotificacio);
                    sqlCommand.Parameters.AddWithValue("@llegida", llegida);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                    };
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