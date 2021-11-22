using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    /// <summary>
    /// Excepcion que muestra un mensaje especifico para la carga de incidencias al estar repetidas
    /// </summary>
    public class IncidenceLoadException : Exception
    {
        public IncidenceLoadException() : base("Incidencia repetida")
        {
        }
    }
}
