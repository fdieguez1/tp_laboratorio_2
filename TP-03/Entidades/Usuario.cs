using Entidades.Enums;
using Entidades.Exceptions;
using Entidades.Extensions;
using System;
using System.Text;

namespace Entidades
{
    public class Usuario 
    {
        static int idAnterior;
        int id;
        int edad;
        EGenero genero;
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

        public Usuario()
        {
            this.Id = ++idAnterior;
        }

        public Usuario(int edad, EGenero genero) : this()
        {
            this.edad = edad;
            this.genero = genero;
        }

        public int Edad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }
        public EGenero Genero
        {
            get { return this.genero; }
            set
            {
                this.genero = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Id:{this.Id} - {this.Edad}, {this.Genero}");
            return sb.ToString();
        }


    }
}
