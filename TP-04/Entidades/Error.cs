using Entidades.Enums;
using Entidades.Exceptions;
using Entidades.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase encargada de representar un error, guarda un detalle de error, el cual es una clase que permite la utilizacion de distintos formatos implementando atributos genericos
    /// </summary>
    public class Error
    {
        static int idAnterior;
        private int id;
        private ETipo tipo;
        string titulo;
        List<ErrorDetalle<int, string, DateTime>> contenido;

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

        /// <summary>
        /// Constructor estatico, inicializa el id anterior en 0
        /// </summary>
        static Error()
        {
            idAnterior = 0;
        }

        /// <summary>
        /// Constructor de error, necesita un titulo y un tipo para poder ser creado
        /// </summary>
        /// <param name="title"></param>
        /// <param name="tipo"></param>
        private Error(string title, ETipo tipo)
        {
            this.id = ++idAnterior;
            this.titulo = title;
            this.tipo = tipo;
        }

        /// <summary>
        /// Sobrecarga del constructor de error, agregando el detalle de error con tipos ya especificados
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="tipo"></param>
        public Error(string title, List<ErrorDetalle<int, string, DateTime>> content, ETipo tipo) : this(title, tipo)
        {
            this.contenido = content;
        }

        //Sobrecarga del metodo ToString para representar de mejor manera el objeto cuando asi se requiera
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Id:{this.Id} - {this.Tipo}");
            return sb.ToString();
        }
    }
}
