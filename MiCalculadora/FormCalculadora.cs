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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
       
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string cmbOperadorResult = string.Empty;
            char displayOperador = '+';
            string numero1 = this.txtOperando1.Text;
            string numero2 = this.txtOperando2.Text;
            if(string.IsNullOrEmpty(numero1))
            {
                numero1 = "0";
            }
            if (string.IsNullOrEmpty(numero2))
            {
                numero2 = "0";
            }
            if (this.cmbOperadores.SelectedIndex == 0)
            {
                displayOperador = '+';
            }
            else
            {
                displayOperador = this.cmbOperadores.SelectedItem.ToString()[0];
            }
            cmbOperadorResult = this.cmbOperadores.SelectedItem.ToString();
            string result = Operar(numero1, numero2, cmbOperadorResult).ToString();
            this.lblDisplay.Text = result;
            this.lstHistorial.Items.Add($"{numero1} {displayOperador} {numero2} = {result}");
        }

        /// <summary>
        /// Recibe 3 strings, llama a la clase calculadora y a su metodo operar
        /// </summary>
        /// <param name="numero1">cadena de texto del primer operando</param>
        /// <param name="numero2">cadena de texto del segundo operando</param>
        /// <param name="operador">cadena de texto del operador</param>
        /// <returns>Devuelve el resultado de la operacion como double</returns>
        static double Operar(string numero1, string numero2, string operador)
        {
            Operando auxOperando1 = new Operando(numero1);
            Operando auxOperando2 = new Operando(numero2);
            if(numero2 == "0" && operador == "/")
            {
                MessageBox.Show("Intento de dividir por 0", "Error", MessageBoxButtons.OK);
            }
            double result = Calculadora.Operar(auxOperando1, auxOperando2, operador[0]);
            return result;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Limpia los campos y combos reiniciandolos a su valor por defecto, no limpia el historial de operaciones
        /// </summary>
        public void Limpiar()
        {
            this.txtOperando1.Text = string.Empty;
            this.txtOperando2.Text = string.Empty;
            this.cmbOperadores.SelectedIndex = 0;
            this.lblDisplay.Text = string.Empty;
        }

        private void btnDecimalABinario_Click(object sender, EventArgs e)
        {
            string resultadoEnPantalla = this.lblDisplay.Text;
            string nuevoResultado = string.Empty;
            if (!string.IsNullOrEmpty(resultadoEnPantalla))
            {
                Operando auxOperando = new Operando();
                nuevoResultado = auxOperando.DecimalBinario(resultadoEnPantalla);
                this.lblDisplay.Text = nuevoResultado;
                this.lstHistorial.Items.Add(nuevoResultado);
            }
            else
            {
                MessageBox.Show("Debe existir un resultado para ser convertido", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnBinarioADecimal_Click(object sender, EventArgs e)
        {
            string resultadoEnPantalla = this.lblDisplay.Text;
            string nuevoResultado = string.Empty;
            if (!string.IsNullOrEmpty(resultadoEnPantalla))
            {
                Operando auxOperando = new Operando();
                nuevoResultado = auxOperando.BinarioDecimal(resultadoEnPantalla);
                this.lblDisplay.Text = nuevoResultado;
                this.lstHistorial.Items.Add(nuevoResultado);
            }
            else
            {
                MessageBox.Show("Debe existir un resultado para ser convertido", "Error", MessageBoxButtons.OK);
            }
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?",
                                    "Confirmacion",
                                    MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
