using Entidades.Exceptions;
using Entidades.Extensions;
using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Incidencia
    {
        static int idAnterior;
        private int id;

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

        string titulo;
        List<Error<int, string, DateTime>> contenido;
        static Incidencia()
        {
            idAnterior = 0;
        }

        public string Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }
        public List<Error<int, string, DateTime>> Contenido
        {
            get { return this.contenido; }
            set { this.contenido = value; }
        }

        private Incidencia(string title)
        {
            this.id = ++idAnterior;
            this.titulo = title;
        }

        public Incidencia(string title, List<Error<int, string, DateTime>> content) : this(title)
        {
            this.contenido = content;
        }
    }
}
