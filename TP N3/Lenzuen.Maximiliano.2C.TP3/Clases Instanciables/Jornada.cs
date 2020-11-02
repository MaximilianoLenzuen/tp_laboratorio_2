using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;

        private Universidad.EClases clase;

        private Profesor instructor;

        #region Properties
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }


        public Universidad.EClases Clase
        {
            get { return clase; }
            set { clase = value; }
        }


        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        #endregion

        #region Constructores
        public Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guardara la jornada en una carpeta localizada en el escritorio
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" +"Jornada.txt";
            return texto.Guardar(ruta, jornada.ToString());
        }

        /// <summary>
        /// Leerá la jornada en un archivo localizado en el escritorio
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "Jornada.txt";

            if (!(texto.Leer(path, out string retorno)))
            {
                retorno = null;
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga del tostring que devolverá todos los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CLASE DE {this.Clase} POR {this.Instructor}");
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in this.Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Sobrecargas
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada jornada, Alumno a)
        {
            if(jornada != a)
            {
                jornada.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return jornada;
        }
        #endregion

    }
}
