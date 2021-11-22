using System;
using System.Collections.Generic;
using Entidades.Enums;
using Entidades.Exceptions;
using Entidades.Extensions;
using Entidades.Interfaces;

namespace Entidades
{
    /// <summary>
    /// Clase que relaciona el error con el usuario, posee un estado que representa si esta abierta o cerrada e implementa la clase IRegistrable
    /// </summary>
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

        /// <summary>
        /// Constructor estatico, inicializa el valor de prevId en 0
        /// </summary>
        static Incidencia()
        {
            prevId = 0;
        }

        /// <summary>
        /// Metodo que implementa la interfaz IRegistrable, agrega una instancia de la incidencia al listado de incidencias del nucleo del sistema.
        /// </summary>
        /// <param name="objeto">incidencia a agregar</param>
        /// <returns>true si logro agregarla, false si no lo logro</returns>
        public bool Registrar(Incidencia objeto)
        {
            return NucleoDelSistema.Incidencias + objeto;
        }

        /// <summary>
        /// Metodo que implementa la interfaz IRegistrable, cierra una instancia de la incidencia perteneciente al listado de incidencias del nucleo del sistema. Cambia su estado a cerrada
        /// </summary>
        /// <param name="objeto">incidencia a cerrar</param>
        /// <returns>true si logro cerrarla, false si no lo logro</returns>
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
        /// <summary>
        /// constructor privado que setea el id de la instancia y su estado por defecto en Abierta
        /// </summary>
        private Incidencia()
        {
            this.id = ++prevId;
            this.estado = EEstado.Abierta;
        }

        //Constructor con parametros, requiere un usuario y un error para poder ser instanciada
        public Incidencia(Usuario user, Error error) : this()
        {
            this.usuario = user;
            this.error = error;
        }

        /// <summary>
        /// Sobrecarga del operador +, agrega una instancia de incidencia a un listado dado
        /// </summary>
        /// <param name="incidencias">listado objetivo</param>
        /// <param name="incidencia">instancia a agregar</param>
        /// <returns>true si logro agregarla, false si no lo logro</returns>
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
        /// <summary>
        /// Sobrecarga del operador -, cierra una incidencia en un listado dado
        /// </summary>
        /// <param name="incidencias">listado a evaluar</param>
        /// <param name="incidencia">instancia a cerrar</param>
        /// <returns>true si logro cerrarla, false si no lo logro</returns>
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
        /// <summary>
        /// sobrecarga del operador ==, indica si una incidencia existe en un determinado listado, buscando por ID
        /// </summary>
        /// <param name="incidencias">listado a evaluar</param>
        /// <param name="incidencia">incidencia a comparar</param>
        /// <returns>true si existe, false si no</returns>
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
        /// <summary>
        /// sobrecarga del operador !=, indica si una incidencia no existe en un determinado listado, buscando por ID
        /// </summary>
        /// <param name="incidencias">listado a evaluar</param>
        /// <param name="incidencia">incidencia a comparar</param>
        /// <returns>true si no existe, false si existe</returns>
        public static bool operator !=(List<Incidencia> incidencias, Incidencia incidencia)
        {
            return !(incidencias == incidencia);
        }

        /// <summary>
        /// Sobrecarga del metodo equals, devuelve si un objeto dado es del tipo de esta clase, si es igual
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Incidencia)
            {
                if ((Incidencia)obj == this)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del gethashcode, reutiliza el codigo de su clase base object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
