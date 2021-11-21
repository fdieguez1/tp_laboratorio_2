using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class SoloLetrasException : Exception
    {
        public SoloLetrasException(string message) : base(message)
        {
        }
    }
}
