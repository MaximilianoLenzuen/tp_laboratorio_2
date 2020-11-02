using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(archivo);
                sw.Write(datos);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if(sw != null)
                {
                    sw.Close();
                }
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }
    }
}
