﻿using System;
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

        public Operando()
        {
            this.Numero = 0.ToString();
        }
        public Operando(double numero) : this()
        {
            this.Numero = numero.ToString();
        }
        public Operando(string strNumero) : this()
        {
            this.Numero = strNumero;
        }
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
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

    }
}
