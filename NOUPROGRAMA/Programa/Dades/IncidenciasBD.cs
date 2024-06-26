﻿using MySql.Data.MySqlClient;
using Programa.Negoci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Dades
{
    internal class IncidenciasBD
    {
        ConnexioBD connexio = new ConnexioBD();
        public List<Incidencia> TotesIncidencies() // Metode Crea LLista de incidencies y ho passa a incidencies
        {
            List<Incidencia> incidencies = new List<Incidencia>();
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                connection.Open();
                string sql = $"SELECT * FROM incidencia";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Incidencia incidencia;
                    incidencia = new Incidencia(Convert.ToInt32(reader["idIncidencia"]), reader["usuari"].ToString(), reader["matricula"].ToString(), reader["descripcio"].ToString(), reader["estat"].ToString());
                    incidencies.Add(incidencia);
                }
                reader.Close();
                connection.Close();
            }
            return incidencies;
        }
        public Incidencias TotesIncidenciesClientBD(string usuari) // Metode Crea LLista de incidencies y ho passa a incidencies
        {
            Incidencias incidencies = new Incidencias();
            MySqlConnection connection = connexio.ConnexioBDD();


            if (connection != null)
            {
                connection.Open();
                string sql = $"SELECT * FROM incidencia WHERE usuari = @usuari";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                sqlCommand.Parameters.AddWithValue("@usuari", usuari);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Incidencia incidencia;
                    incidencia = new Incidencia(Convert.ToInt32(reader["idIncidencia"]), reader["usuari"].ToString(), reader["matricula"].ToString(), reader["descripcio"].ToString(), reader["estat"].ToString());
                    incidencies.Add(incidencia);
                }
                reader.Close();
                connection.Close();
            }
            return incidencies;
        }
        public void InsertIncidenciaBDD(string usuari, string matricula, string descripcio, string estat)
        {
            //Creem la clase per obrir la connexió
            MySqlConnection connection = connexio.ConnexioBDD();

            //Si la connexió es correcte
            if (connection != null)
            {
                try
                {
                    //Obrim la connexió a la Base de Dades
                    connection.Open();

                    //Fem la consulta que necessitem, en aquest cas es un INSERT en la taula peces dels parametres que hem passat.
                    string sql = $"INSERT INTO peces (usuari, matricula, descripcio, estat) VALUES (@usuari, @matricula, @descripcio, @estat)";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@usuari", usuari);
                    sqlCommand.Parameters.AddWithValue("@matricula", matricula);
                    sqlCommand.Parameters.AddWithValue("@descripcio", descripcio);
                    sqlCommand.Parameters.AddWithValue("@estat", estat);
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

        
        public void EliminarIncidenciaBDD(int idIncidencia)
        {
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                try
                {
                    connection.Open();
                    string sql = $"DELETE FROM incidencia WHERE idIncidencia = @idIncidencia";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@idIncidencia", idIncidencia);

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
        public void UpdateIncidenciaBDD(int idIncidencia, string usuari, string matricula, string descripcio, string estat)
        { // Update que permet modificar el estat de la incidencia, es el unic valor que ha de ser modificable
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                try
                {
                    connection.Open();
                    string sql = $"UPDATE incidencia SET estat = @estat WHERE idIncidencia = @idIncidencia";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@idIncidencia", idIncidencia);
                    sqlCommand.Parameters.AddWithValue("@estat", estat);

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