using Entidades;
using Entidades.Enums;
using Entidades.Extensions;
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
    public partial class Statistics : Form
    {
        List<string> statisticsLogs;
        public Statistics()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (statisticsLogs.Count > 0)
            {
                NucleoDelSistema.Instance.EscribirArchivoJson(statisticsLogs);
                MessageBox.Show($"Guardado de estadisticas exitoso en ruta: {NucleoDelSistema.UserFilesPath}");
            }
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            statisticsLogs = new List<string>();

            int conteoIncidenciasAbiertas = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Estado != EEstado.Cerrada).Count();

            //Utilizo un metodo propio que hace uso de genericos, interfaces y delegados (intenta hacer lo mismo que un Where de LINQ)
            int conteoMayores = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Edad > 17).Count();
            int conteoMenoresBloqueante = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Edad <= 17 && x.Error.Tipo.EsBloqueante() && x.Estado != EEstado.Cerrada).Count();
            int conteoMasculinosMenores = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Genero == EGenero.Masculino && x.Usuario.Edad <= 17 && x.Estado != EEstado.Cerrada).Count();
            int conteoFemeninosMayores = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Genero == EGenero.Femenino && x.Usuario.Edad > 17 && x.Estado != EEstado.Cerrada).Count();
            int conteoNoBinariosConCrash = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Genero == EGenero.NoBinario && x.Error.Tipo == ETipo.Crash && x.Estado != EEstado.Cerrada).Count();

            //Metodo de extension de int para calcular un porcentaje, dado un segundo parametro tambien de tipo int.
            float porcentajeMayores = conteoIncidenciasAbiertas.CalcularPorcentaje(conteoMayores);
            statisticsLogs.Add($"Porcentaje de mayores de edad con errores: {porcentajeMayores:0.00}%");
            float porcentajeMenoresBloqueante = conteoIncidenciasAbiertas.CalcularPorcentaje(conteoMenoresBloqueante);
            statisticsLogs.Add($"Porcentaje de menores de edad con error bloqueante: {porcentajeMenoresBloqueante:0.00}%");

            float porcentajeMasculinoMenores = conteoIncidenciasAbiertas.CalcularPorcentaje(conteoMasculinosMenores);
            statisticsLogs.Add($"Porcentaje de masculinos menores con errores: {porcentajeMasculinoMenores:0.00}%");
            float porcentajeFemeninoMayores = conteoIncidenciasAbiertas.CalcularPorcentaje(conteoFemeninosMayores);
            statisticsLogs.Add($"Porcentaje de femeninos mayores con errores: {porcentajeFemeninoMayores:0.00}%");
            float porcentajeNoBinarioConCrash = conteoIncidenciasAbiertas.CalcularPorcentaje(conteoNoBinariosConCrash);
            statisticsLogs.Add($"Porcentaje de no binarios con errores de tipo crash: {porcentajeNoBinarioConCrash:0.00}%");

            int conteoBloqueantes = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Error.Tipo.EsBloqueante() && x.Estado != EEstado.Cerrada).Count();
            int conteoNoBloqueantes = NucleoDelSistema.Incidencias.FiltrarColleccion(x => !x.Error.Tipo.EsBloqueante() && x.Estado != EEstado.Cerrada).Count();
            float porcentajeBloqueantes = conteoIncidenciasAbiertas.CalcularPorcentaje(conteoBloqueantes);
            statisticsLogs.Add($"Porcentaje de errores bloqueantes: {porcentajeBloqueantes:0.00}%");
            float porcentajeNoBloqueantes = conteoIncidenciasAbiertas.CalcularPorcentaje(conteoNoBloqueantes);
            statisticsLogs.Add($"Porcentaje de errores no bloqueantes: {porcentajeNoBloqueantes:0.00}%");

            lbxEstadisticas.DataSource = statisticsLogs;

            progressBar1.Value = Convert.ToInt32(porcentajeMayores);
            progressBar2.Value = Convert.ToInt32(porcentajeMenoresBloqueante);
            progressBar3.Value = Convert.ToInt32(porcentajeMasculinoMenores);
            progressBar4.Value = Convert.ToInt32(porcentajeFemeninoMayores);
            progressBar5.Value = Convert.ToInt32(porcentajeNoBinarioConCrash);
            progressBar6.Value = Convert.ToInt32(porcentajeBloqueantes);
            progressBar7.Value = Convert.ToInt32(porcentajeNoBloqueantes);
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
