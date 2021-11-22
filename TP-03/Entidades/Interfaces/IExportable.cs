using System.Collections.Generic;

namespace Entidades.Interfaces
{
    public interface IExportable<T>
    {
        void EscribirArchivoJson(List<T> data);
        List<T> LeerArchivoJson(string path);
        void EscribirArchivoXml(List<T> data);
        List<T> LeerArchivoXml(string path);
    }
}
