using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    /// <summary>
    /// Excepcion que presenta mensajes personalizados para la gestion de archivos
    /// </summary>
    public class ErrorArchivosException : Exception
    {
        public ErrorArchivosException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }

        public ErrorArchivosException(string mensaje) : base(mensaje)
        {
        }
    }
}
