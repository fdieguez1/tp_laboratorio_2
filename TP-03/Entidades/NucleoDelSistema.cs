using System.Collections.Generic;

namespace Entidades
{
    public class NucleoDelSistema
    {
        private static List<Registro> registros;
        public static List<Registro> Registros
        {
            get { return registros; }
            set { registros = value; }
        }

        private static List<Usuario> usuarios;
        public static List<Usuario> Usuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }

        private static List<Incidencia> incidencias;
        public static List<Incidencia> Incidencias
        {
            get { return incidencias; }
            set { incidencias = value; }
        }
        static NucleoDelSistema()
        {
            Registros = new List<Registro>();
            Usuarios = new List<Usuario>();
            Incidencias = new List<Incidencia>();
        }
    }
}
