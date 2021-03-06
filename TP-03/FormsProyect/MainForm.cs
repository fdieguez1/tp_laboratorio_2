using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsProyect
{
    /// <summary>
    /// delegado que sera utilizado para la carga de un evento que escuchara por actualizaciones en la interfaz (recarga de data grid views)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void RefreshInterface(object sender, EventArgs e);
    public partial class MainForm : Form
    {
        //Evento para actualizar los listados del mainform
        public event RefreshInterface OnRefreshInterface;
        /// <summary>
        /// Singleton del main form para acceder a una unica instancia a lo largo del ciclo de vida de la app
        /// </summary>
        private static MainForm instance = null;
        public static MainForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainForm();
                }
                return instance;
            }
        }


        /// <summary>
        /// Instancio la conexion a la DB pasandole un connection string
        /// </summary>
        public DBContext dbContext = new DBContext();

        /// <summary>
        /// Delegado para utilizar en caso de que se requiera una invocacion de un metodo en otro hilo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private delegate void Callback(object sender, EventArgs e);
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NucleoDelSistema.Instance.CargaTest(20, 20, 21);
            RefreshDataGridViews(sender, e);
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvErrors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIncidences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            OnRefreshInterface = (sender, e) => { this.Show(); this.Focus(); };
            OnRefreshInterface += RefreshDataGridViews;
            dgvErrors.Columns[0].Width = 50;
            dgvErrors.Columns[1].Width = 100;
            dgvUsers.Columns[0].Width = 50;
            dgvIncidences.Columns[0].Width = 50;
            dgvIncidences.Columns[1].Width = 100;
        }

        /// <summary>
        /// Metodo que carga nuevamente los data grid views con los ultimos valores existentes en el Nucleo del sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RefreshDataGridViews(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Callback callback = new Callback(RefreshDataGridViews);
                object[] args = new object[]
                {
                    sender,
                    e
                };

                this.Invoke(callback, args);
            }
            else
            {
                dgvUsers.DataSource = new List<Usuario>(NucleoDelSistema.Usuarios);
                dgvErrors.DataSource = new List<Error>(NucleoDelSistema.Errores);
                dgvIncidences.DataSource = new List<Incidencia>(NucleoDelSistema.Incidencias);
            }
        }



        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            bool messageOk = MessageBox.Show("Seguro desea salir?", "Cerrando app", MessageBoxButtons.YesNo) == DialogResult.Yes;
            if (messageOk)
            {
                Application.Exit();
            }

        }

        private void bntAddIncidence_Click(object sender, EventArgs e)
        {
            //Esta tarea corre en el mismo hilo, para bloquear la UI hasta terminar los cambios
            Form AddForm = new AddIncidence();
            if (AddForm.ShowDialog() == DialogResult.OK)
            {
                MainForm.Instance.RefreshDataGridViews(sender, e);
            }
        }

        private void btnCloseIncidence_Click(object sender, EventArgs e)
        {
            //Esta tarea corre en el mismo hilo, para bloquear la UI hasta terminar los cambios
            Form AddForm = new CloseIncidence();
            if (AddForm.ShowDialog() == DialogResult.OK) {
                MainForm.Instance.RefreshDataGridViews(sender, e);
            }
            
        }

        private void btnSeeStatistics_Click(object sender, EventArgs e)
        {
            //Corro esto en otro hilo para no bloquear la UI principal, se pueden ejecutar estadisticas o dejar abierto este dialog y seguir utilizando el hilo principal
            Task.Run(() =>
            {
                Form AddForm = new Statistics();
                AddForm.ShowDialog();
            });
        }


        /// <summary>
        /// Limpia la base de datos de registros de usuarios en la tabla dbo.users, corre en un hilo secundario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCleanDb_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    DBContext.DeleteAllUsers();
                    MessageBox.Show("Limpieza de usuarios en la DB correcta");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrio un problema al limpiar la base, Exception: {ex.Message}", "Error en la DB");
                }
            });

        }

        /// <summary>
        /// Carga en la base de datos registros de usuarios en la tabla dbo.users, corre en un hilo secundario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUsuariosDb_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    DBContext.Post(NucleoDelSistema.Usuarios);
                    MessageBox.Show("Carga de usuarios en la DB correcta");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrio un problema al cargar usuarios a la base, Exception: {ex.Message}", "Error en la DB");
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Corro esto en otro hilo para no bloquear la UI principal, se pueden ejecutar estadisticas o dejar abierto este dialog y seguir utilizando el hilo principal
            Task.Run(() =>
            {
                Form AddForm = new DbUsersQuery();
                AddForm.ShowDialog();
            });
        }
    }
}
