using Entidades;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main()
        {
            Random Rnd = new Random();
            int conteoGeneros = Enum.GetNames(typeof(ETipo)).Length;
            
            Error<int, string, DateTime> auxPagina;
            List<Error<int, string, DateTime>> paginas;

            Usuario auxCliente;
            Incidencia auxLibro;

            int conteoClientes;
            for (conteoClientes = 0; conteoClientes < 10; conteoClientes++)
            {
                NucleoDelSistema.Usuarios.Add(new Usuario(Rnd.Next(15, 45), (ETipo)Rnd.Next(0, conteoGeneros)));
            }
            Console.WriteLine($"Cargados {conteoClientes} clientes");

            List<string> bookNames = new List<string>()
            {
                "Don Quijote", "Historia de dos ciudades", "El señor de los anillos", "El Principito", "El Hobbit"
            };

            int bookCount;
            for (bookCount = 0; bookCount < 20; bookCount++)
            {
                paginas = new List<Error<int, string, DateTime>>();
                for (int p = 0; p < 3; p++)
                {
                    auxPagina = new Error<int, string, DateTime>(p, Guid.NewGuid().ToString(), DateTime.Now);
                }
                NucleoDelSistema.Incidencias.Add(new Incidencia(bookNames[Rnd.Next(0, bookNames.Count)], paginas));
            }
            Console.WriteLine($"Cargados {bookCount} libros");

            int rentalsCount;
            for (rentalsCount = 0; rentalsCount < 10; rentalsCount++)
            {
                auxCliente = NucleoDelSistema.Usuarios[Rnd.Next(0, NucleoDelSistema.Usuarios.Count)];
                auxLibro = NucleoDelSistema.Incidencias[Rnd.Next(0, NucleoDelSistema.Usuarios.Count)];
                NucleoDelSistema.Registros.Add(new Registro(auxCliente, auxLibro));
            }
            Console.WriteLine($"Cargados {rentalsCount} alquileres");

            List<Registro> TitulosAlquiladosSinRepetir = NucleoDelSistema.Registros.Where(x => x.Client.Edad > 18).ToList();

        }
    }
}
