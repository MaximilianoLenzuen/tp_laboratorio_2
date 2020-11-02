using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD };

        private List<Alumno> alumnos;

        private List<Jornada> jornada;

        private List<Profesor> profesores;

        #region Propiedades
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }


        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { jornada = value; }
        }


        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Jornada this[int i]
        {
            get { return this.jornada[i];}
            set { this.jornada[i] = value; }
        }
        #endregion

        #region Constructores
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Se fijara si existe el alumno en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Se fijara si existe el profesor en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Verificará que profesor puede dar la clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profe in u.Instructores)
            {
                if(profe == clase)
                {
                    return profe;
                }
            }

            throw new SinProfesorException();
        }


        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            foreach (Profesor profe in u.Instructores)
            {
                if (profe != clase)
                {
                    retorno = profe;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Intentará crear la jornada, de no poder lanzara excepcion
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {

            Jornada nuevaJornada = new Jornada(clase, g == clase);
            foreach (Alumno alumno in g.Alumnos)
            {
                if(alumno == clase)
                {
                    nuevaJornada += alumno;
                }
            }
            g.Jornadas.Add(nuevaJornada);

            return g;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            
            return u;
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guardará todos los datos en un archivo de tipo xml en el escritorio
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "Universidad.xml", uni);
        }
        /// <summary>
        /// Recibirá todos los datos de una carpeta del escritorio
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "Universidad.xml", out Universidad universidad);
            return universidad;
        }

        /// <summary>
        ///  Mostrará todos los datos de las jornadas con respectivos profesores y alumnos
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Jornada:");
            foreach (Jornada jornada in this.Jornadas)
            {
                sb.AppendLine(jornada.ToString());
                sb.AppendLine("<------------------------------------------------>");

            }
            /*
            foreach (Profesor profe in this.Instructores)
            {
                sb.AppendLine(profe.ToString());
                sb.AppendLine("<------------------------------------------------>");

            }
            */
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del tostring que devolvera el string de otra funcion
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion



    }
}
