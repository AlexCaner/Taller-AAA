using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Dades
{
    class ConnexioBD
    {

        //Datos
        private string server = "localhost";
        private string database = "tallermecanic";
        private string user = "root";
        private string pwd = "";
        private string port = "3306";
        public MySqlConnection ConnexioBDD()
        {
            string conexio = $"Server={server};Port={port};Database={database};Uid={user};Pwd={pwd};";
            MySqlConnection connection = new MySqlConnection(conexio);
            //try
            //{
            //    connection.Open();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //    connection = null;
            //}
            return connection;
        }
    }
}