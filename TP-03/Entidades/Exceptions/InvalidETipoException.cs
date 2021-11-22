using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class InvalidETipoException : Exception
    {
        public InvalidETipoException() : base("El valor ingresado para el tipo no esta comprendido dentro de los tipos soportados")
        {
        }
    }
}
