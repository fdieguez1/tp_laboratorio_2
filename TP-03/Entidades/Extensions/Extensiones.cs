using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Entidades.Extensions
{
    public static class Extensiones
    {
        /// <summary>
        /// Devuelve un booleano representando si una determinada incidencia ya se encuentra registrada
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool EstaRegistrado(this Incidencia incidencia)
        {
            return NucleoDelSistema.Incidencias == incidencia;
        }

        /// <summary>
        /// Devuelve si un tipo dado, es bloqueante, es decir es un anr o crash
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public static bool EsBloqueante(this ETipo tipo)
        {
            return tipo > ETipo.NonFatal;
        }

        /// <summary>
        /// Devuelve si un string dado solo contiene letras
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool SoloLetras(this string str)
        {
            foreach (char c in str)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Devuelve si un string dado solo contiene numeros
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool SoloNumeros(this int number)
        {
            foreach (char c in number.ToString())
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Metodo de extension para filtrar cualquier tipo de collecion que implemente IEnumerable (reutilizo codigo mio realizado para un challenge para una entrevista de trabajo 
        /// url del codigo original, devuelve una lazy collection: https://github.com/fdieguez1/TestPixowl/blob/main/Entidades/Ejercicio1/Ejercicio.cs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalCollection">collecion a ser evaluada</param>
        /// <param name="evaluate">delegado a utilizar en la comparacion</param>
        /// <returns></returns>
        public static IEnumerable<T> FiltrarColleccion<T>(this IEnumerable<T> originalCollection, Func<T, bool> evaluate)
        {
            if (originalCollection == null)
            {
                throw new ArgumentNullException(nameof(originalCollection));
            }
            if (evaluate == null)
            {
                throw new ArgumentNullException(nameof(evaluate));
            }
            //Uso una collection para poder usar el add, y asi luego retornar la coleccion filtrada del tipo dado
            Collection<T> col = new Collection<T>();
            foreach (T item in originalCollection)
            {
                if (evaluate(item))
                {
                    col.Add(item);
                }
            }
            return col;
        }

        /// <summary>
        /// Metodo de extension para un int, dado un int como parametro calcula el porcentaje que representa este, en relacion al int que llama a la funcion.
        /// </summary>
        /// <param name="total">int original que llama a la funcion</param>
        /// <param name="cantidadAEvaluar">int a evaluar</param>
        /// <returns>float porcentaje que representa el segundo en relacion al primero</returns>
        public static float CalcularPorcentaje(this int total, int cantidadAEvaluar)
        {
            return (cantidadAEvaluar * 100 / (float)total);
        }

    }
}
