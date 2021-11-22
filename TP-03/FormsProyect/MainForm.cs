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
        public DB dbContext = new DB("Data Source=.;Initial Catalog=UTN;Integrated Security=True");


        private delegate void Callback(object sender, EventArgs e);
        public MainForm()
        {
            InitializeComponent();
        }
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

        private void btnCleanDb_Click(object sender, EventArgs e)
        {
            dbContext.DeleteAllUsers();
        }

        private void btnUsuariosDb_Click(object sender, EventArgs e)
        {
            dbContext.Post(NucleoDelSistema.Usuarios);
        }
    }
}
