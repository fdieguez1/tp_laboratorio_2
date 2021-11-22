using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    /// <summary>
    /// Excepcion que presenta un mensaje al intentar cargar un valor por fuera de los comprendidos dentro de EEstado enum
    /// </summary>
    public class InvalidEEstadoException : Exception
    {
        public InvalidEEstadoException() : base("El valor ingresado para el estado no esta comprendido dentro de los estados soportados")
        {
        }
    }
}
