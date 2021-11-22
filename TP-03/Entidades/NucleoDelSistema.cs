using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using Entidades.Interfaces;
using System.Xml.Serialization;
using System;
using Entidades.Exceptions;

namespace Entidades
{
    public class NucleoDelSistema : IExportable<Usuario>
    {
        public static string userFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public bool FileExists(string nombreArchivo)
        {
            return File.Exists($"{userFilesPath}{nombreArchivo}");
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
                string path = $"{userFilesPath}\\ArchivoJson.json";
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
                using (XmlTextWriter writer = new XmlTextWriter($"{userFilesPath}\\ArchivoXml.xml", Encoding.UTF8))
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
    }
}
