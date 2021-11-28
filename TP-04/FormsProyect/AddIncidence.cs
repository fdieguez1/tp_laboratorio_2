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
    public partial class AddIncidence : Form
    {
        public AddIncidence()
        {
            InitializeComponent();
        }

        private void AddIncidence_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = NucleoDelSistema.Usuarios;
            dgvErrors.DataSource = NucleoDelSistema.Errores;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvErrors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            Incidencia auxIncidencia;
            Error auxError;
            Usuario auxUsuario;
            auxUsuario = dgvUsers.CurrentRow.DataBoundItem as Usuario;
            auxError = dgvErrors.CurrentRow.DataBoundItem as Error;
            auxIncidencia = new Incidencia(auxUsuario, auxError);
            bool cargaOk = NucleoDelSistema.Incidencias + auxIncidencia;
            if (cargaOk)
            {
                MessageBox.Show("Carga de incidencia Ok");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar la incidencia");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
