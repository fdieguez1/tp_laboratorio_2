using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase encargada de instanciar la conexion con la base de datos y de realizar consultas
    /// </summary>
    public class DBContext
    {
        /*
        Table generation script:
        CREATE TABLE dbo.users (
	        Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	        Edad int NOT NULL,
	        Genero int NOT NULL
        )
        */

        public static string connectionString = "Data Source=.;Initial Catalog=UTN;Integrated Security=True;TimeOut=3";
        static Usuario auxUser;

        /// <summary>
        /// Metodo Get, devuelve una lista de usuarios dada una consulta sql en formato de string
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns>Listado de usuarios de la base</returns>
        public static List<Usuario> Get(string consulta)
        {
            SqlConnection conection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(consulta, conection);
            List<Usuario> users = new List<Usuario>();
            try
            {
                conection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    auxUser = new Usuario();
                    auxUser.Id = (int)sqlDataReader["Id"];
                    auxUser.Edad = (int)sqlDataReader["Edad"];
                    auxUser.Genero = (EGenero)sqlDataReader["Genero"];
                    auxUser.Nombre = sqlDataReader["Nombre"].ToString();
                    users.Add(auxUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conection.Close();
            }
            return users;
        }
        /// <summary>
        /// Metodo post, publica los datos dados en forma de lista de usuarios a la base de datos.
        /// </summary>
        /// <param name="data">Listado de usuarios a publicar</param>
        public static void Post(List<Usuario> data)
        {
            string consulta = string.Empty;
            foreach (Usuario user in data)
            {
                consulta += $"INSERT INTO dbo.Usuarios VALUES ({user.Edad}, {(int)user.Genero}, '{user.Nombre}');";
            }
            SqlConnection conection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(consulta, conection);
            try
            {
                conection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conection.Close();
            }
        }
        /// <summary>
        /// Metodo DeleteAllUsers, elimina todos los registros de la base de datos de la tabla users (no reeestablece la semilla del Id, por lo que la proxima carga, iniciara retomando el conteo de los Ids previos)
        /// </summary>
        public static void DeleteAllUsers()
        {
            string consulta = "DELETE FROM dbo.Usuarios;";
            SqlConnection conection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(consulta, conection);
            try
            {
                conection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conection.Close();
            }
        }
    }
}
