using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    /// <summary>
    /// Excepcion que muestra un mensaje personalizado al verificar que un valor no solo contiene numeros
    /// </summary>
    public class SoloNumerosException : Exception
    {
        public SoloNumerosException(string message) : base(message)
        {
        }
    }
}
