namespace Entidades.Interfaces
{
    /// <summary>
    /// Interfaz que indica que metodos ha de implementar la clase que la aplique, para poder ser registrada
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRegistrable<T>
    {
        bool Registrar(T objeto);
        bool Cerrar(T objeto);
    }
}