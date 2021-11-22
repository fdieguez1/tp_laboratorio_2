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
        private string connectionString;
        Incidencia auxIncidencia;

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
                    Usuario auxUser = new Usuario();
                    auxUser.Id = (int)sqlDataReader["Id"];
                    auxUser.Edad = (int)sqlDataReader["Edad"];
                    auxUser.Genero = (EGenero)sqlDataReader["Genero"];
                    users.Add(auxUser);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conection.Close();
            }
            return users;
        }

    }
}
