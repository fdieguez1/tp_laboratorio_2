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
    /// <summary>
    /// Clase principal donde se guardan los diferentes listados e instancias necesarios para la app, implementa el patron singleton y dos interfaces del tipo IExportable, para guardar usuarios y strings que representan los logs respectivamente.
    /// </summary>
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

        /// <summary>
        /// Obtiene la carpeta de mis documentos
        /// </summary>
        public static string UserFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// Verifica que un archivo exista dado un nombre de archivo, en la carpeta de mis documentos
        /// </summary>
        /// <param name="nombreArchivo">nombre del archivo</param>
        /// <returns>true si existe, false si no</returns>
        public bool FileExists(string nombreArchivo)
        {
            return File.Exists($"{UserFilesPath}{nombreArchivo}");
        }

        private static List<Incidencia> incidencias;
        /// <summary>
        /// Listado de incidencias
        /// </summary>
        public static List<Incidencia> Incidencias
        {
            get { return incidencias; }
            set { incidencias = value; }
        }

        private static List<Usuario> usuarios;
        /// <summary>
        /// Listado de usuarios
        /// </summary>
        public static List<Usuario> Usuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }

        private static List<Error> errores;
        /// <summary>
        /// Listado de errores
        /// </summary>
        public static List<Error> Errores
        {
            get { return errores; }
            set { errores = value; }
        }
        /// <summary>
        /// constructor estatico, inicializa los listados
        /// </summary>
        static NucleoDelSistema()
        {
            Incidencias = new List<Incidencia>();
            Usuarios = new List<Usuario>();
            Errores = new List<Error>();
        }

        /// <summary>
        /// implementa la interfaz para escribir archivos del tipo json
        /// </summary>
        /// <param name="data">Listado de usuarios a escribir en el archivo</param>
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
        /// <summary>
        /// implementa la interfaz para leer archivos del tipo json
        /// </summary>
        /// <param name="data">ubicacion del archivo a leer</param>
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

        /// <summary>
        /// Lee un archivo xml dado un path y devuelve un listado de usuarios
        /// </summary>
        /// <param name="path">ubicacion del archivo</param>
        /// <returns>listado de usuarios</returns>
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

        /// <summary>
        /// Escribe un archivo xml con un listado de usuarios
        /// </summary>
        /// <param name="data">listado de usuarios a escribir</param>
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

        /// <summary>
        /// Escribe un archivo json dada una lista de strings
        /// </summary>
        /// <param name="data">lista de strings</param>
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

        /// <summary>
        /// Leer un archivo json dado un path
        /// </summary>
        /// <param name="path">ubicacion del archivo</param>
        /// <returns>Devuelve una lista de strings </returns>
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

        /// <summary>
        /// Escibre un archivo xml con un listado de strings
        /// </summary>
        /// <param name="data">listado de strings a escribir</param>
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
        /// <summary>
        /// Lee un archivo xml y lo interpreta como un listado de strings
        /// </summary>
        /// <param name="path">ubicacion del archivo</param>
        /// <returns>Listado de strings a devolver</returns>

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
        /// <param name="cantidadUsuarios">usuarios a instanciar</param>
        /// <param name="cantidadErrores">errores a instanciar</param>
        /// <param name="cantidadIncidencias">incidencias a instanciar</param>
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
