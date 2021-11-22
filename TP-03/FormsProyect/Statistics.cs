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

            int conteoIncidencias = NucleoDelSistema.Incidencias.Count;

            //Utilizo un metodo propio que hace uso de genericos, interfaces y delegados (intenta hacer lo mismo que un Where de LINQ)
            int conteoMayores = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Edad > 17).Count();
            int conteoMenoresBloqueante = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Edad <= 17 && x.Error.Tipo.EsBloqueante()).Count();
            int conteoMasculinosMenores = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Genero == EGenero.Masculino && x.Usuario.Edad <= 17).Count();
            int conteoFemeninosMayores = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Genero == EGenero.Femenino && x.Usuario.Edad > 17).Count();
            int conteoNoBinariosConCrash = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Genero == EGenero.NoBinario && x.Error.Tipo == ETipo.Crash).Count();

            //Metodo de extension de int para calcular un porcentaje, dado un segundo parametro tambien de tipo int.
            float porcentajeMayores = conteoIncidencias.CalcularPorcentaje(conteoMayores);
            statisticsLogs.Add($"Porcentaje de mayores con errores: {porcentajeMayores:0.00}%");
            float porcentajeMenoresBloqueante = conteoIncidencias.CalcularPorcentaje(conteoMenoresBloqueante);
            statisticsLogs.Add($"Porcentaje de menores con error bloqueante: {porcentajeMenoresBloqueante:0.00}%");

            float porcentajeMasculinoMenores = conteoIncidencias.CalcularPorcentaje(conteoMasculinosMenores);
            statisticsLogs.Add($"Porcentaje de masculinos menores con errores: {porcentajeMasculinoMenores:0.00}%");
            float porcentajeFemeninoMayores = conteoIncidencias.CalcularPorcentaje(conteoFemeninosMayores);
            statisticsLogs.Add($"Porcentaje de femeninos mayores con errores: {porcentajeFemeninoMayores:0.00}%");
            float porcentajeNoBinarioConCrash = conteoIncidencias.CalcularPorcentaje(conteoNoBinariosConCrash);
            statisticsLogs.Add($"Porcentaje de no binarios con errores de tipo crash: {porcentajeNoBinarioConCrash:0.00}%");

            int conteoBloqueantes = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Error.Tipo.EsBloqueante()).Count();
            int conteoNoBloqueantes = NucleoDelSistema.Incidencias.FiltrarColleccion(x => !x.Error.Tipo.EsBloqueante()).Count();
            float porcentajeBloqueantes = conteoIncidencias.CalcularPorcentaje(conteoBloqueantes);
            statisticsLogs.Add($"Porcentaje de errores bloqueantes: {porcentajeBloqueantes:0.00}%");
            float porcentajeNoBloqueantes = conteoIncidencias.CalcularPorcentaje(conteoNoBloqueantes);
            statisticsLogs.Add($"Porcentaje de errores no bloqueantes: {porcentajeNoBloqueantes:0.00}%");

            lbxEstadisticas.DataSource = statisticsLogs;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
