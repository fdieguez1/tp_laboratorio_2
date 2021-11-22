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
        public DB dbContext = new DB("Data Source=.;Initial Catalog=UTN;Integrated Security=True;TimeOut=3");

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

        /// <summary>
        /// Metodo encargado de traer al frente el formulario (No esta funcionando, es un problema relacionado a hilos ya que esperando un momento antes de realizar el focus el formulario se muestra correctamente)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowMainForm(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Callback callback = new Callback(ShowMainForm);
                object[] args = new object[]
                {
                    sender,
                    e
                };

                this.Invoke(callback, args);
            }
            else
            {
                this.Show();
                this.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NucleoDelSistema.Instance.CargaTest(10, 10, 11);
            RefreshDataGridViews(sender, e);
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvErrors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIncidences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            OnRefreshInterface = (sender, e) => { this.Show(); this.Focus(); };
            OnRefreshInterface += RefreshDataGridViews;
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
            //Corro esto en otro hilo para no bloquear la UI principal, se pueden ejecutar multiples cargas o dejar abierto este dialog y seguir utilizando el hilo principal
            Task.Run(() =>
            {
                Form AddForm = new AddIncidence();
                AddForm.ShowDialog();
            });
        }

        private void btnCloseIncidence_Click(object sender, EventArgs e)
        {
            //Corro esto en otro hilo para no bloquear la UI principal, se pueden ejecutar multiples cierres o dejar abierto este dialog y seguir utilizando el hilo principal
            Task.Run(() =>
            {
                Form AddForm = new CloseIncidence();
                AddForm.ShowDialog();
            });
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

        private void MainForm_Activated(object sender, EventArgs e)
        {
            //Invoco al evento al activar el form
            OnRefreshInterface?.Invoke(sender, e);
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
                    dbContext.DeleteAllUsers();
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
                    dbContext.Post(NucleoDelSistema.Usuarios);
                    MessageBox.Show("Carga de usuarios en la DB correcta");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrio un problema al cargar usuarios a la base, Exception: {ex.Message}", "Error en la DB");
                }
            });
        }
    }
}
