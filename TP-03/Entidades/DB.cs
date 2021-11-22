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
    public class DB
    {
        /*
        Table generation script:
        CREATE TABLE dbo.users (
	        Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	        Edad int NOT NULL,
	        Genero int NOT NULL
        )
        */

        private string connectionString;
        Usuario auxUser;

        /// <summary>
        /// Propiedad que se encarga de exponer el atributo de connection string, representa los datos que se utilizan para la conexion a la base de datos
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return this.connectionString;
            }
            set
            {
                this.connectionString = value;
            }
        }
        /// <summary>
        /// Constructor de la clase, necesita de un conexion string para poderse instanciar
        /// </summary>
        /// <param name="connectionString"></param>
        public DB(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        /// <summary>
        /// Metodo Get, devuelve una lista de usuarios dada una consulta sql en formato de string
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns>Listado de usuarios de la base</returns>
        public List<Usuario> Get(string consulta)
        {
            SqlConnection conection = new SqlConnection(this.connectionString);
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
        public void Post(List<Usuario> data)
        {
            string consulta = string.Empty;
            foreach (Usuario user in data)
            {
                consulta += $"INSERT INTO dbo.Users VALUES ({user.Edad}, {(int)user.Genero}) ";
            }
            SqlConnection conection = new SqlConnection(this.connectionString);
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
        public void DeleteAllUsers()
        {
            string consulta = "DELETE FROM dbo.users;";
            SqlConnection conection = new SqlConnection(this.connectionString);
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
