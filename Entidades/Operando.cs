using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        double numero;
        public string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }

        /// <summary>
        /// Convierte un binario luego de validar que lo sea, en un decimal.
        /// </summary>
        /// <param name="binario">cadena de texto en formato binario</param>
        /// <returns>devuelve el numero convertido</returns>
        public string BinarioDecimal(string binario)
        {
            if (EsBinario(binario)) { 
            char[] invertido = binario.ToCharArray();
            Array.Reverse(invertido);
            int total = 0;

            for (int i = 0; i < invertido.Length; i++)
            {
                if (invertido[i] == '1')
                {
                    total += (int)Math.Pow(2, i);
                }
            }
            return total.ToString();
            }
            else
            {
                return "Valor invalido";
            }
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns>devuelve el numero convertido</returns>
        public string DecimalBinario(double numero)
        {
            int resto;
            string binario = "";
            if (numero > 0)
            {
                while (numero > 1)
                {
                    resto = (int)numero % 2;
                    numero /= 2;
                    binario = resto.ToString() + binario;
                }
                return binario;
            }
            else
            {
                return "Valor invalido";
            }
        }

        /// <summary>
        /// Convierte una cadena de texto en decimal a binario
        /// </summary>
        /// <param name="numero">cadena de texto a convertir</param>
        /// <returns>devuelve el numero convertido</returns>
        public string DecimalBinario(string numero)
        {
            int convertido;
            if (int.TryParse(numero, out convertido))
            {
                return DecimalBinario(convertido);
            }
            else
            {
                return "Valor invalido";
            }
        }
        /// <summary>
        /// Valida si una cadena proporcionada es un numero binario
        /// </summary>
        /// <param name="binario">cadena a evaluar</param>
        /// <returns>devuelve true si es binario, false si no lo es</returns>
        public bool EsBinario(string binario)
        {
            bool esBinario = true;
            foreach (char caracter in binario)
            {
                if (caracter != '0' && caracter != '1')
                {
                    esBinario = false;
                }
            }
            return esBinario;
        }

        /// <summary>
        /// Constructor de la clase operando, sin parametros, asigna el valor 0 a la propiedad Numero del objeto
        /// </summary>
        public Operando()
        {
            this.Numero = 0.ToString();
        }
        /// <summary>
        /// Constructor de la clase operando, con parametro double numero, asigna el valor del parametro a la propiedad Numero del objeto
        /// </summary>
        /// <param name="numero">numero a asignar</param>
        public Operando(double numero) : this()
        {
            this.Numero = numero.ToString();
        }
        /// <summary>
        /// Constructor de la clase operando, con parametro string strNumero, asigna el valor del parametro a la propiedad Numero del objeto
        /// </summary>
        /// <param name="numero">cadena de texto con el numero a asignar</param>
        public Operando(string strNumero) : this()
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// Convierte a double si es posible una cadena de texto, sino es devuelto un 0 por defecto.
        /// </summary>
        /// <param name="strNumero">cadena a evaluar</param>
        /// <returns>devuelve la conversion de la cadena ingresada, 0 si no logro convertirla</returns>
        public double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double valor))
            {
                return valor;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Sobrecarga del operador + para operaciones de suma de la clase Operando
        /// </summary>
        /// <param name="n1">primer objeto tipo Operando</param>
        /// <param name="n2">segundo objeto tipo Operando</param>
        /// <returns>Devuelve el resultado de la suma de sus atributos numero</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador - para operaciones de suma de la clase Operando
        /// </summary>
        /// <param name="n1">primer objeto tipo Operando</param>
        /// <param name="n2">segundo objeto tipo Operando</param>
        /// <returns>Devuelve el resultado de la resta de sus atributos numero</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador / para operaciones de suma de la clase Operando
        /// </summary>
        /// <param name="n1">primer objeto tipo Operando</param>
        /// <param name="n2">segundo objeto tipo Operando</param>
        /// <returns>Devuelve el resultado de la division de sus atributos numero</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador * para operaciones de suma de la clase Operando
        /// </summary>
        /// <param name="n1">primer objeto tipo Operando</param>
        /// <param name="n2">segundo objeto tipo Operando</param>
        /// <returns>Devuelve el resultado de la multiplicacion de sus atributos numero</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

    }
}
