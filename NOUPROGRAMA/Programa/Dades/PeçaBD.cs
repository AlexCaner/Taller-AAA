using MySql.Data.MySqlClient;
using Programa.Negoci;
using System;
using System.Data;

namespace Programa.Dades
{
    public class PeçaBD
    {
        ConnexioBD connexio = new ConnexioBD();
        public List<Peça> Totes() // Metode Crea LLista de peces y ho passa a peces
        {
            List<Peça> peces = new List<Peça>();
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                connection.Open();
                string sql = $"SELECT * FROM peces";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Peça peça;
                    peça = new Peça(reader["nomPeça"].ToString(), Convert.ToInt32(reader["quantitat"]));
                    peces.Add(peça);
                }
                reader.Close();
                connection.Close();
            }
            return peces;
        }
        public void InsertPecesBDD(string nomPeça, int quantitat)
        {
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                try
                {
                    connection.Open();
                    string sql = $"INSERT INTO peces (nomPeça, quantitat) VALUES (@nomPeça, @quantitat)";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@nomPeça", nomPeça);
                    sqlCommand.Parameters.AddWithValue("@quantitat", quantitat);
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
        public void EliminarPecesBDD(string nomPeça)
        {
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                try
                {
                    connection.Open();
                    string sql = $"DELETE FROM peces WHERE nomPeça = @nomPeça";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@nomPeça", nomPeça);

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
        public void UpdatePecesBDD(string nomPeça, int quantitatNou)
        {
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                try
                {
                    connection.Open();
                    string sql = $"UPDATE peces SET quantitat = @quantitat WHERE nomPeça = @nomPeça";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@nomPeça", nomPeça);
                    sqlCommand.Parameters.AddWithValue("@quantitat", quantitatNou);
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