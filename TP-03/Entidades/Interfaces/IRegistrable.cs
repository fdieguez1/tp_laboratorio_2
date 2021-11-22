namespace Entidades.Interfaces
{
    public interface IRegistrable<T>
    {
        bool Registrar(T objeto);
        bool Cerrar(T objeto);
    }
}