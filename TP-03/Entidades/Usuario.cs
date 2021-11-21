using Entidades.Enums;
using Entidades.Exceptions;
using Entidades.Extensions;

namespace Entidades
{
    public sealed class Cliente
    {
        static int idAnterior;
        int id;
        int edad;
        ETipo genero;
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

        static Cliente()
        {
            idAnterior = 0;
        }

        private Cliente()
        {
            this.Id = ++idAnterior;
        }

        public Cliente(int edad, ETipo genero) : this()
        {
            this.edad = edad;
            this.genero = genero;
        }

        public int Edad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }
        public ETipo Genero
        {
            get { return this.genero; }
            set
            {
                this.genero = value;
            }
        }
    }
}
