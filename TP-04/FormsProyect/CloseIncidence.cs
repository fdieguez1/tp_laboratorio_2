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
    public partial class CloseIncidence : Form
    {
        public CloseIncidence()
        {
            InitializeComponent();
        }

        private void CloseIncidence_Load(object sender, EventArgs e)
        {
            dgvIncidences.DataSource = new List<Incidencia>(NucleoDelSistema.Incidencias);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Incidencia auxIncidencia;
            auxIncidencia = dgvIncidences.CurrentRow.DataBoundItem as Incidencia;
            bool cierreOk = NucleoDelSistema.Incidencias - auxIncidencia;
            if (cierreOk)
            {
                MessageBox.Show("Cierre de incidencia Ok");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al cerrar la incidencia");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
