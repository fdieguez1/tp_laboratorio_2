using System.Text;

namespace Entidades
{
    public class Error<T1, T2, T3> where T1 : struct where T3 : struct
    {
        readonly T1 titulo;
        readonly T2 cuerpo;
        readonly T3 timestamp;

        public Error(T1 pagina, T2 cuerpo, T3 pie)
        {
            this.titulo = pagina;
            this.cuerpo = cuerpo;
            this.timestamp = pie;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\nPágina: {this.titulo}");
            sb.AppendLine($"\nTexto: {this.cuerpo}");
            sb.AppendLine($"\n\n{this.timestamp}\n");
            return sb.ToString();
        }
    }
}