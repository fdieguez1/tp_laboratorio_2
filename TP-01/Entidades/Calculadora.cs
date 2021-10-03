using System;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Retorna el resultado de la operacion, dados dos operandos y un operador
        /// </summary>
        /// <param name="num1">Operando num1 primer numero a utilizar</param>
        /// <param name="num2">Operando num2 segundo numero a utilizar</param>
        /// <param name="operador">operador a ultilizar</param>
        /// <returns>Devuelve un double con el resultado de la operacion</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case '-':
                    return num1 - num2;
                case '/':
                    return num1 / num2;
                case '*':
                    return num1 * num2;
                case '+':
                default:
                    return num1 + num2;
            }
        }

        /// <summary>
        /// Retorna si el caracter ingresado corresponde a un operador, caso contrario retorna el operador de suma '+'
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
