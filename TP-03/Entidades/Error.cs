using Entidades.Enums;
using Entidades.Exceptions;
using Entidades.Extensions;
using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Error
    {
        static int idAnterior;
        private int id;
        private ETipo tipo;

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value.SoloNumeros())
                {
                    this.id = value;
                }
                else
                {
                    throw new SoloNumerosException("El id debe ser un numero");
                }
            }
        }
        public ETipo Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                if (value >= 0)
                {
                    this.tipo = value;
                }
                else
                {
                    throw new InvalidETipoException();
                }
            }
        }

        string titulo;
        List<ErrorDetalle<int, string, DateTime>> contenido;
        static Error()
        {
            idAnterior = 0;
        }

        public string Titulo
        {
            get
            {
                return this.titulo;
            }
            set
            {
                this.titulo = value;
            }
        }
        public List<ErrorDetalle<int, string, DateTime>> Contenido
        {
            get
            {
                return this.contenido;
            }
            set
            {
                this.contenido = value;
            }
        }

        private Error(string title, ETipo tipo)
        {
            this.id = ++idAnterior;
            this.titulo = title;
            this.tipo = tipo;
        }

        public Error(string title, List<ErrorDetalle<int, string, DateTime>> content, ETipo tipo) : this(title, tipo)
        {
            this.contenido = content;
        }
    }
}
