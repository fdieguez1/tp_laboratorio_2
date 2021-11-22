using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Enums
{
    /// <summary>
    /// ordenados por gravedad para identificar los errores bloqueantes
    /// </summary>
    public enum ETipo
    {

        //Errores no bloqueantes
        NonFatal = 0,

        //Errores bloqueantes
        ANR = 1,
        Crash = 2
    }
}
