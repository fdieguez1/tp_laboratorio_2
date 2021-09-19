using System;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case '+':
                    num1 + num2;
                    break;
                case '-':
                    num1 - num2;
                    break;
                case '/':
                    num1 / num2;
                    break;
                case '*':
                    num1 * num2;
                    break;
            }
        }
        /// <summary>
        /// Retorna si el caracter inglesado corresponde a un operador, caso contrario retorna el operador de suma '+'
        /// </summary>
        /// <param name="operador">caracter a evaluar</param>
        /// <returns></returns>
        private static char ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '/' && operador != '*')
            {
                return '+';
            }
            else
            {
                return operador;
            }
        }
    }
}
