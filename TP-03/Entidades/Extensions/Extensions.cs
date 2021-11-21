using System;

namespace Entidades.Extensions
{
    public static class Extensions
    {
        public static bool EstaAlquilado(this Incidencia libro){
            foreach(Registro item in NucleoDelSistema.Registros)
            {
                if (item.Book == libro)
                {
                    return true;
                }
            }
            return false;
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
    }
}
