namespace Entidades.Interfaces
{
    public interface IRentable<T>
    {
        bool Alquilar(T objeto);
        bool Devolver(T objeto);
    }
}