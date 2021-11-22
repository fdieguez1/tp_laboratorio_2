using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
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
        public DB(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

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
