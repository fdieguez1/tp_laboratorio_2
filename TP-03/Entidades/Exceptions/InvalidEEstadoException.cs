using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class InvalidEEstadoException : Exception
    {
        public InvalidEEstadoException() : base("El valor ingresado para el estado no esta comprendido dentro de los estados soportados")
        {
        }
    }
}
