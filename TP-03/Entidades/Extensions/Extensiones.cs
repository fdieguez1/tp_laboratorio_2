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
        public static bool EstaRegistrado(this Incidencia incidencia){
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
        /// <param name="originalCollection"></param>
        /// <param name="evaluate"></param>
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
            return MyWhere(originalCollection, evaluate);
        }

        private static Collection<T> MyWhere<T>(this IEnumerable<T> originalCollection, Func<T, bool> evaluate)
        {
            Collection<T> col = new();
            foreach (T item in originalCollection)
            {
                if (evaluate(item))
                {
                    col.Add(item);
                }
            }
            return col;
        }

        public static float CalcularPorcentaje(this int total, int cantidadAEvaluar)
        {
            return (cantidadAEvaluar * 100 / (float)total);
        }

    }
}
