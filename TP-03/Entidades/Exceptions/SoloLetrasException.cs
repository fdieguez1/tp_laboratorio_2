using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    /// <summary>
    /// Excepcion que permite un mensaje personalizado cuando un string no contiene solo letras
    /// </summary>
    public class SoloLetrasException : Exception
    {
        public SoloLetrasException(string message) : base(message)
        {
        }
    }
}
