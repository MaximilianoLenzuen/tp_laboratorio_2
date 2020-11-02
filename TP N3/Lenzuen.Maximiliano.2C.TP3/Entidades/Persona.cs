using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero};

        private string apellido;

        private int dni;

        private ENacionalidad nacionalidad;

        private string nombre;

        #region Properties
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidadDni(this.nacionalidad,value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad= value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidadDni(this.nacionalidad,value);
            }
        }


        #endregion

        #region Constructores

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad) :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Utiliza stringbuilder para generar los datos de la persona
        /// </summary>
        /// <returns>String con datos de persona</returns>
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"Nombre: {this.Nombre} {this.Apellido}\r\n");
            sb.AppendFormat($"Nacionalidad : {this.Nacionalidad}\r\n");

            return sb.ToString();
        }

        /// <summary>
        /// Validará que el dni corresponda a la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>El dni validado</returns>
        private int ValidadDni(ENacionalidad nacionalidad, int dato)
        {
            return this.ValidadDni(nacionalidad, dato.ToString());
        }

        /// <summary>
        /// Validará que el dni sea una cadena valida
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>El dni validado y parseado</returns>
        private int ValidadDni(ENacionalidad nacionalidad, string dato)
        {
            int validacion;
            int.TryParse(dato, out validacion);
            if (validacion != 0)
            {
                if ((nacionalidad == ENacionalidad.Argentino && (validacion >= 1 && validacion < 90000000)) || (nacionalidad == ENacionalidad.Extranjero && (validacion > 89999999 && validacion < 100000000)))
                {
                    return validacion;
                }
                else
                {
                    throw new NacionalidadInvalidaException(); 
                }
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        ///  Validará que el string recibido pueda utilizarse como nombre
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";
            if (dato.Count() > 1 && dato.Any(char.IsLetter))
            {
                retorno = dato;
            }
            return retorno;
        }
        #endregion

    }
}
