using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using Entidades.Interfaces;
using System.Xml.Serialization;
using System;
using Entidades.Exceptions;
using Entidades.Enums;

namespace Entidades
{
    public class NucleoDelSistema : IExportable<Usuario>, IExportable<string>
    {
        //Random a utilizar
        public static Random Rnd = new Random();

        /// <summary>
        /// Singleton de nucleo del sistema para acceder a una unica instancia a lo largo del ciclo de vida de la app
        /// </summary>
        private static NucleoDelSistema instance = null;
        public static NucleoDelSistema Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NucleoDelSistema();
                }
                return instance;
            }
        }

        public static string UserFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public bool FileExists(string nombreArchivo)
        {
            return File.Exists($"{UserFilesPath}{nombreArchivo}");
        }

        private static List<Incidencia> incidencias;
        public static List<Incidencia> Incidencias
        {
            get { return incidencias; }
            set { incidencias = value; }
        }

        private static List<Usuario> usuarios;
        public static List<Usuario> Usuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }

        private static List<Error> errores;
        public static List<Error> Errores
        {
            get { return errores; }
            set { errores = value; }
        }
        static NucleoDelSistema()
        {
            Incidencias = new List<Incidencia>();
            Usuarios = new List<Usuario>();
            Errores = new List<Error>();
        }
        public void EscribirArchivoJson(List<Usuario> data)
        {
            try
            {
                string path = $"{UserFilesPath}\\ArchivoJson.json";
                string jsonString = JsonSerializer.Serialize(data);
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    streamWriter.WriteLine(jsonString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Usuario> LeerArchivoJson(string path)
        {
            List<Usuario> auxUsuario;
            string json = string.Empty;
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    while (!streamReader.EndOfStream)
                    {
                        json += $"{streamReader.ReadLine()}\n";
                    }
                }
                auxUsuario = JsonSerializer.Deserialize<List<Usuario>>(json);
            }
            catch (Exception)
            {
                throw;
            }
            return auxUsuario;
        }

        public List<Usuario> LeerArchivoXml(string path)
        {
            List<Usuario> auxUser = null;
            try
            {
                using (XmlTextReader reader = new XmlTextReader(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Usuario>));
                    auxUser = (List<Usuario>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new ErrorArchivosException("Ocurrió un error al deserializar.", ex);
            }
            return auxUser;
        }

        public void EscribirArchivoXml(List<Usuario> data)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter($"{UserFilesPath}\\ArchivoXml.xml", Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Usuario>));
                    serializer.Serialize(writer, data);
                }
            }
            catch (Exception ex)
            {
                throw new ErrorArchivosException("Problema al escribir el archivo", ex);
            }
        }

        public void EscribirArchivoJson(List<string> data)
        {
            try
            {
                string path = $"{UserFilesPath}\\ArchivoJsonLogs.json";
                string jsonString = JsonSerializer.Serialize(data);
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    streamWriter.WriteLine(jsonString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        List<string> IExportable<string>.LeerArchivoJson(string path)
        {
            List<string> auxLogs;
            string json = string.Empty;
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    while (!streamReader.EndOfStream)
                    {
                        json += $"{streamReader.ReadLine()}\n";
                    }
                }
                auxLogs = JsonSerializer.Deserialize<List<string>>(json);
            }
            catch (Exception)
            {
                throw;
            }
            return auxLogs;
        }

        public void EscribirArchivoXml(List<string> data)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter($"{UserFilesPath}\\ArchivoXmlLogs.xml", Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                    serializer.Serialize(writer, data);
                }
            }
            catch (Exception ex)
            {
                throw new ErrorArchivosException("Problema al escribir el archivo", ex);
            }
        }

        List<string> IExportable<string>.LeerArchivoXml(string path)
        {
            List<string> auxString = null;
            try
            {
                using (XmlTextReader reader = new XmlTextReader(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Usuario>));
                    auxString = (List<string>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new ErrorArchivosException("Ocurrió un error al deserializar.", ex);
            }
            return auxString;
        }


        /// <summary>
        /// Metodo de carga de prueba, instancia segun los parametros dados las distintas entidades para el analisis de datos
        /// </summary>
        /// <param name="cantidadUsuarios"></param>
        /// <param name="cantidadErrores"></param>
        /// <param name="cantidadIncidencias"></param>
        public void CargaTest(int cantidadUsuarios, int cantidadErrores, int cantidadIncidencias)
        {
            //conteo de variantes de tipo de error
            int conteoSexos = Enum.GetNames(typeof(EGenero)).Length;
            int conteoTipo = Enum.GetNames(typeof(ETipo)).Length;

            ErrorDetalle<int, string, DateTime> auxErrorDetalle;
            List<ErrorDetalle<int, string, DateTime>> errorDescriptions;

            Usuario auxUsuario;
            Error auxError;

            if (FileExists("\\ArchivoJson.json"))
            {
                //Leo los usuarios del archivo
                NucleoDelSistema.Usuarios.AddRange(LeerArchivoJson($"{NucleoDelSistema.UserFilesPath}\\ArchivoJson.json"));
                Console.WriteLine($"Leidos {NucleoDelSistema.Usuarios.Count} usuarios");
            }
            else
            {
                //Instancio usuarios para relacionar con los errores a modo de prueba con valores aleatorios

                int conteoUsuarios;
                for (conteoUsuarios = 0; conteoUsuarios < cantidadUsuarios; conteoUsuarios++)
                {
                    NucleoDelSistema.Usuarios.Add(new Usuario(Rnd.Next(10, 45), (EGenero)Rnd.Next(0, conteoSexos)));
                }
                Console.WriteLine($"Instanciados {conteoUsuarios} usuarios");
            }

            List<string> errorTitles = new List<string>()
            {
                "Null reference error", "App not responding", "Connection lost", "Stack overflow exception", "Input string was not in the correct format"
            };

            //Instancio errores a modo de prueba con valores aleatorios
            int errorCount;
            for (errorCount = 0; errorCount < cantidadErrores; errorCount++)
            {
                errorDescriptions = new List<ErrorDetalle<int, string, DateTime>>();
                for (int p = 0; p < 3; p++)
                {
                    auxErrorDetalle = new ErrorDetalle<int, string, DateTime>(p, Guid.NewGuid().ToString(), DateTime.Now);
                }
                NucleoDelSistema.Errores.Add(new Error(errorTitles[Rnd.Next(0, errorTitles.Count)], errorDescriptions, (ETipo)Rnd.Next(0, conteoTipo)));
            }
            Console.WriteLine($"Instanciados {errorCount} errores");

            //Instancio incidencias que son la entidad que relaciona errores con usuarios
            int incidencesCount;
            for (incidencesCount = 0; incidencesCount < cantidadIncidencias; incidencesCount++)
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
        }
    }


}
