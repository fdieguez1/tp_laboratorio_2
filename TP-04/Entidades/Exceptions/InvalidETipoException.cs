using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    /// <summary>
    /// Excepcion que presenta un mensaje al intentar cargar un valor por fuera de los comprendidos dentro de ETipo enum
    /// </summary>
    public class InvalidETipoException : Exception
    {
        public InvalidETipoException() : base("El valor ingresado para el tipo no esta comprendido dentro de los tipos soportados")
        {
        }
    }
}
