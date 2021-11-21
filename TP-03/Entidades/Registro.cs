using System;
using System.Collections.Generic;
using Entidades.Exceptions;
using Entidades.Extensions;
using Entidades.Interfaces;

namespace Entidades
{
    public class Registro : IRentable<Registro>
    {
        static int prevId;
        private int id;
        private Cliente cliente;
        private Incidencia libro;


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

        static Registro()
        {
            prevId = 0;
        }


        public bool Alquilar(Registro objeto)
        {
            return NucleoDelSistema.Registros + objeto;
        }

        public bool Devolver(Registro objeto)
        {
            return NucleoDelSistema.Registros - objeto;
        }


        public Cliente Client
        {
            get
            {
                return this.cliente;
            }
            set
            {
                this.cliente = value;
            }
        }
        public Incidencia Book
        {
            get
            {
                return this.libro;
            }
            set
            {
                this.libro = value;
            }
        }
        private Registro()
        {
            this.id = ++prevId;
        }
        public Registro(Cliente client, Incidencia book) : this()
        {
            this.cliente = client;
            this.libro = book;
        }

        public static bool operator +(List<Registro> alquileres, Registro alquiler)
        {
            if (alquileres == null)
            {
                throw new NullReferenceException("Se necesitan una lista de alquileres para cargar un prestamo");
            }
            if (alquiler == null)
            {
                throw new NullReferenceException("Se necesita un libro para realizar la carga del prestamo");
            }
            if (alquileres != alquiler)
            {
                alquileres.Add(alquiler);
                return true;
            }
            return false;
        }
        public static bool operator -(List<Registro> alquileres, Registro alquiler)
        {
            if (alquileres == null)
            {
                throw new NullReferenceException("Se necesitan una lista de alquileres para efectuar una devolucion");
            }
            if (alquiler == null)
            {
                throw new NullReferenceException("Se necesita un libro para realizar la devolucion");
            }
            if (alquileres.Count < 0)
            {
                throw new Exception("No hay alquileres, no se puede devolver nada");
            }
            if (alquileres == alquiler)
            {
                alquileres.Remove(alquiler);
                return true;
            }
            return false;
        }
        public static bool operator ==(List<Registro> alquileres, Registro alquiler)
        {
            foreach (Registro item in alquileres)
            {
                if (item.Book.Id == alquiler.Book.Id)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(List<Registro> rentals, Registro rental)
        {
            return !(rentals == rental);
        }

        public override bool Equals(object obj)
        {
            if ((Registro)obj == this)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
