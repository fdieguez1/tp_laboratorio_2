using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase que permite el uso de genericos para sus distintos atributos, aplica restricciones para estos tipos segun sea el orden en que se ingresen.
    /// </summary>
    /// <typeparam name="T1">Representa el titulo del error, debe ser un tipo por valor (struct)</typeparam>
    /// <typeparam name="T2">Representa el cuerpo del error, no tiene contraints</typeparam>
    /// <typeparam name="T3">Representa el timestamp, debe ser un tipo por valor(struct, ej: DateTime)</typeparam>
    public class ErrorDetalle<T1, T2, T3> where T1 : struct where T3 : struct
    {
        readonly T1 titulo;
        readonly T2 cuerpo;
        readonly T3 timestamp;

        /// <summary>
        /// Constructor de ErrorDetalle, requiere los 3 parametros que especifiquen un tipo para inicializar una instancia de esta clase
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="cuerpo"></param>
        /// <param name="pie"></param>
        public ErrorDetalle(T1 pagina, T2 cuerpo, T3 pie)
        {
            this.titulo = pagina;
            this.cuerpo = cuerpo;
            this.timestamp = pie;
        }

        /// <summary>
        /// Sobrecarga del metodo tostring, para representar mejor el detalle de error cuando asi se requiera
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\nTitulo: {this.titulo}");
            sb.AppendLine($"\nCuerpo: {this.cuerpo}");
            sb.AppendLine($"\n\n{this.timestamp}\n");
            return sb.ToString();
        }
    }
}