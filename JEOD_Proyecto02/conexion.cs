using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace JEOD_Proyecto02
{
    internal class Conexion
    {
        public static MySqlConnection conexion()
        {
            string servidor = "localhost";
            string bd = "heladeria";
            string usuario = "root";
            string password = "emilio10";
            // se crea la cadena de conexion
            string cadenaConexion = "server=" + servidor + "; database=" + bd + "; uid=" + usuario + "; pwd=" + password + ";";
            try // Se intenta conectar a la base de datos
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                return conexionBD;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                return null;
            }
        }
    }
}
