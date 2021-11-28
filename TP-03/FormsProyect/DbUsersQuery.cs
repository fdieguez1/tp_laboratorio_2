using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsProyect
{
    public partial class DbUsersQuery : Form
    {
        public DbUsersQuery()
        {
            InitializeComponent();
        }

        private void DbUsersQuery_Load(object sender, EventArgs e)
        {
            List<Usuario> usuarios = new List<Usuario>();
            Task.Run(() =>
            {
                try
                {
                    usuarios = DBContext.Get("SELECT * FROM dbo.Usuarios");
                    MessageBox.Show("Consulta correcta");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrio un problema al cargar usuarios a la base, Exception: {ex.Message}", "Error en la DB");
                }
            }).Wait();
            lstBox.DataSource = usuarios;


        }
    }
}
