using System.Collections.Generic;

namespace Entidades
{
    public class NucleoDelSistema
    {
        private static List<Incidencia> incidencias;
        public static List<Incidencia> Incidencias
        {
            get { return incidencias; }
            set { incidencias = value; }
        }

        private static List<Usuario> usuarios;
        public static List<Usuario> Usuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }

        private static List<Error> errores;
        public static List<Error> Errores
        {
            get { return errores; }
            set { errores = value; }
        }
        static NucleoDelSistema()
        {
            Incidencias = new List<Incidencia>();
            Usuarios = new List<Usuario>();
            Errores = new List<Error>();
        }
    }
}
