namespace Entidades.Interfaces
{
    public interface IExportable<T>
    {
        T EscribirArchivo(string path);
        bool LeerArchivo(T tipo, string path);

    }
}
