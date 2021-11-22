using Entidades.Enums;
using Entidades.Exceptions;
using Entidades.Extensions;

namespace Entidades
{
    public sealed class Usuario
    {
        static int idAnterior;
        int id;
        int edad;
        ESexo genero;
        public int Id
        {
            get { return this.id; }
            set
            {
                if (value.SoloNumeros())
                    this.id = value;
                else
                    throw new SoloNumerosException("El id debe ser un numero");
            }
        }

        static Usuario()
        {
            idAnterior = 0;
        }

        private Usuario()
        {
            this.Id = ++idAnterior;
        }

        public Usuario(int edad, ESexo genero) : this()
        {
            this.edad = edad;
            this.genero = genero;
        }

        public int Edad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }
        public ESexo Genero
        {
            get { return this.genero; }
            set
            {
                this.genero = value;
            }
        }
    }
}
