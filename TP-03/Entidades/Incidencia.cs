using System;
using System.Collections.Generic;
using Entidades.Enums;
using Entidades.Exceptions;
using Entidades.Extensions;
using Entidades.Interfaces;

namespace Entidades
{
    public class Incidencia : IRegistrable<Incidencia>
    {
        static int prevId;
        private int id;
        private Usuario usuario;
        private Error error;
        private EEstado estado;


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
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                if (value >= 0)
                {
                    this.estado = value;
                }
                else
                {
                    throw new InvalidEEstadoException();
                }
            }
        }

        static Incidencia()
        {
            prevId = 0;
        }


        public bool Registrar(Incidencia objeto)
        {
            return NucleoDelSistema.Incidencias + objeto;
        }

        public bool Cerrar(Incidencia objeto)
        {
            return NucleoDelSistema.Incidencias - objeto;
        }


        public Usuario Usuario
        {
            get
            {
                return this.usuario;
            }
            set
            {
                this.usuario = value;
            }
        }
        public Error Error
        {
            get
            {
                return this.error;
            }
            set
            {
                this.error = value;
            }
        }
        private Incidencia()
        {
            this.id = ++prevId;
            this.estado = EEstado.Abierta;
        }
        public Incidencia(Usuario user, Error error) : this()
        {
            this.usuario = user;
            this.error = error;
        }

        public static bool operator +(List<Incidencia> incidencias, Incidencia incidencia)
        {
            if (incidencias == null)
            {
                throw new NullReferenceException("Se necesitan una lista de alquileres para cargar un prestamo");
            }
            if (incidencia == null)
            {
                throw new NullReferenceException("Se necesita un libro para realizar la carga del prestamo");
            }
            if (incidencias != incidencia)
            {
                incidencias.Add(incidencia);
                return true;
            }
            else
            {
                throw new IncidenceLoadException();
            }
        }
        public static bool operator -(List<Incidencia> incidencias, Incidencia incidencia)
        {
            if (incidencias == null)
            {
                throw new NullReferenceException("Se necesitan una lista de incidencias para efectuar una cierre");
            }
            if (incidencia == null)
            {
                throw new NullReferenceException("Se necesita un error para realizar el cierre");
            }
            if (incidencias.Count < 0)
            {
                throw new Exception("No hay incidencias, no se puede cerrar nada");
            }
            foreach (Incidencia item in incidencias)
            {
                if (item == incidencia)
                {
                    item.Estado = EEstado.Cerrada;
                    return true;
                }
            }
            return false;
        }
        public static bool operator ==(List<Incidencia> incidencias, Incidencia incidencia)
        {
            foreach (Incidencia item in incidencias)
            {
                if (item.Id == incidencia.Id)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(List<Incidencia> incidencias, Incidencia incidencia)
        {
            return !(incidencias == incidencia);
        }

        public override bool Equals(object obj)
        {
            if ((Incidencia)obj == this)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
