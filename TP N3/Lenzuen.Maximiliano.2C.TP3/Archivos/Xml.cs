using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            XmlSerializer serializer = null;
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, datos);
                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if(writer!= null)
                {
                    writer.Close();
                }
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = null;
            XmlSerializer serializer = null;
            try
            {
                reader = new XmlTextReader(archivo);
                serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(reader);
                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }
            }

        }
    }
}
