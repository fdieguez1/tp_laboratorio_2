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
        //cargas de prueba y muestra de estadisticas en aplicacion de consola
        static void Main()
        {
            NucleoDelSistema.Instance.CargaTest(10, 10, 11);
          
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

            NucleoDelSistema.Instance.EscribirArchivoXml(NucleoDelSistema.Usuarios);
            Console.WriteLine("Archivo guardado");

            Console.WriteLine("Guardando archivo json con usuarios en mis documentos...");
            NucleoDelSistema.Instance.EscribirArchivoJson(NucleoDelSistema.Usuarios);
            Console.WriteLine("Archivo guardado");

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }
    }
}
