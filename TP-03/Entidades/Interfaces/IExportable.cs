using System.Collections.Generic;

namespace Entidades.Interfaces
{
    /// <summary>
    /// Interfaz que indica que metodos ha de implementar una clase que la aplique para ser capaz de escribir y leer archivos en formato json y xml
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IExportable<T>
    {
        void EscribirArchivoJson(List<T> data);
        List<T> LeerArchivoJson(string path);
        void EscribirArchivoXml(List<T> data);
        List<T> LeerArchivoXml(string path);
    }
}
