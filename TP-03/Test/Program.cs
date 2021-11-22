using Entidades;
using Entidades.Enums;
using Entidades.Exceptions;
using Entidades.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main()
        {
            NucleoDelSistema instanciaCore = new NucleoDelSistema();

            //Random a utilizar
            Random Rnd = new Random();
            //conteo de variantes de tipo de error
            int conteoSexos = Enum.GetNames(typeof(EGenero)).Length;
            int conteoTipo = Enum.GetNames(typeof(ETipo)).Length;

            ErrorDetalle<int, string, DateTime> auxErrorDetalle;
            List<ErrorDetalle<int, string, DateTime>> errorDescriptions;

            Usuario auxUsuario;
            Error auxError;

            if (instanciaCore.FileExists("\\ArchivoJson.json"))
            {
                //Leo los usuarios del archivo
                NucleoDelSistema.Usuarios.AddRange(instanciaCore.LeerArchivoJson($"{NucleoDelSistema.userFilesPath}\\ArchivoJson.json"));
                Console.WriteLine($"Leidos {NucleoDelSistema.Usuarios.Count} usuarios");
            }
            else
            {
                //Instancio 100 usuarios para relacionar con los errores a modo de prueba con valores aleatorios

                int conteoUsuarios;
                for (conteoUsuarios = 0; conteoUsuarios < 100; conteoUsuarios++)
                {
                    NucleoDelSistema.Usuarios.Add(new Usuario(Rnd.Next(10, 45), (EGenero)Rnd.Next(0, conteoSexos)));
                }
                Console.WriteLine($"Instanciados {conteoUsuarios} usuarios");
            }

            List<string> errorTitles = new List<string>()
            {
                "Null reference error", "App not responding", "Connection lost", "Stack overflow exception", "Input string was not in the correct format"
            };

            //Instancio 100 errores a modo de prueba con valores aleatorios
            int errorCount;
            for (errorCount = 0; errorCount < 100; errorCount++)
            {
                errorDescriptions = new List<ErrorDetalle<int, string, DateTime>>();
                for (int p = 0; p < 3; p++)
                {
                    auxErrorDetalle = new ErrorDetalle<int, string, DateTime>(p, Guid.NewGuid().ToString(), DateTime.Now);
                }
                NucleoDelSistema.Errores.Add(new Error(errorTitles[Rnd.Next(0, errorTitles.Count)], errorDescriptions, (ETipo)Rnd.Next(0, conteoTipo)));
            }
            Console.WriteLine($"Instanciados {errorCount} errores");

            //Instancio 101 incidencias que son la entidad que relaciona errores con usuarios
            int incidencesCount;
            for (incidencesCount = 0; incidencesCount < 101; incidencesCount++)
            {
                auxUsuario = NucleoDelSistema.Usuarios[Rnd.Next(0, NucleoDelSistema.Usuarios.Count)];
                auxError = NucleoDelSistema.Errores[Rnd.Next(0, NucleoDelSistema.Errores.Count)];
                try
                {
                    bool funciono = NucleoDelSistema.Incidencias + new Incidencia(auxUsuario, auxError);
                    if (!funciono)
                    {
                        Console.WriteLine("Como llegaste aca?, debería haber ocurrido una excepcion >:(");
                    }
                }
                catch (IncidenceLoadException ex)
                {
                    Console.WriteLine($"Error: {ex.Message} \n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} \n");
                }

            }
            Console.WriteLine($"Instanciadas {incidencesCount} incidencias\n");

            int conteoIncidencias = NucleoDelSistema.Incidencias.Count;

            //Utilizo un metodo propio que hace uso de genericos, interfaces y delegados (intenta hacer lo mismo que un Where de LINQ)
            int conteoMayores = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Edad > 17).Count();
            int conteoMenores = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Edad <= 17 && x.Error.Tipo.EsBloqueante()).Count();
            int conteoMasculinosMenores = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Genero == EGenero.Masculino && x.Usuario.Edad <= 17).Count();
            int conteoFemeninosMayores = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Genero == EGenero.Femenino && x.Usuario.Edad > 17).Count();
            int conteoNoBinariosConCrash = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Usuario.Genero == EGenero.NoBinario && x.Error.Tipo == ETipo.Crash).Count();

            //Metodo de extension de int para calcular un porcentaje, dado un segundo parametro tambien de tipo int.
            float porcentajeMayores = conteoIncidencias.CalcularPorcentaje(conteoMayores);
            float porcentajeMenores = conteoIncidencias.CalcularPorcentaje(conteoMenores);
            float porcentajeMasculino = conteoIncidencias.CalcularPorcentaje(conteoMasculinosMenores);
            float porcentajeFemeninoMayores = conteoIncidencias.CalcularPorcentaje(conteoFemeninosMayores);
            float porcentajeNoBinarioConCrash = conteoIncidencias.CalcularPorcentaje(conteoNoBinariosConCrash);

            Console.WriteLine($"Porcentaje de errores registrados por mayores de edad: {porcentajeMayores:0.00}%");
            Console.WriteLine($"Porcentaje de errores registrados por menores de edad tipo bloqueantes: {porcentajeMenores:0.00}%\n");
            Console.WriteLine($"Porcentaje de errores registrados por masculinos menores de edad: {porcentajeMasculino:0.00}%");
            Console.WriteLine($"Porcentaje de errores registrados por femeninos mayores de edad: {porcentajeFemeninoMayores:0.00}%");
            Console.WriteLine($"Porcentaje de errores del tipo Crash registrados por no binarios: {porcentajeNoBinarioConCrash:0.00}%\n");

            int conteoBloqueantes = NucleoDelSistema.Incidencias.FiltrarColleccion(x => x.Error.Tipo.EsBloqueante()).Count();
            int conteoNoBloqueantes = NucleoDelSistema.Incidencias.FiltrarColleccion(x => !x.Error.Tipo.EsBloqueante()).Count();
            float porcentajeBloqueantes = conteoIncidencias.CalcularPorcentaje(conteoBloqueantes);
            float porcentajeNoBloqueantes = conteoIncidencias.CalcularPorcentaje(conteoNoBloqueantes);
            Console.WriteLine($"Porcentaje de errores bloqueantes: {porcentajeBloqueantes:0.00}%");
            Console.WriteLine($"Porcentaje de errores no bloqueantes: {porcentajeNoBloqueantes:0.00}%\n");

            Console.WriteLine("Guardando archivo xml con el ultimo usuario en mis documentos...");

            instanciaCore.EscribirArchivoXml(NucleoDelSistema.Usuarios);
            Console.WriteLine("Archivo guardado");

            Console.WriteLine("Guardando archivo json con usuarios en mis documentos...");
            instanciaCore.EscribirArchivoJson(NucleoDelSistema.Usuarios);
            Console.WriteLine("Archivo guardado");

        }
    }
}
