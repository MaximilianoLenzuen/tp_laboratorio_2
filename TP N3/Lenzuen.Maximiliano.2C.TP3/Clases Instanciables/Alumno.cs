using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia,Deudor,Becado};

        private EEstadoCuenta estadoCuenta;

        private EClases claseQueToma;

        #region Constructores

        public Alumno()
        {

        }

        public Alumno(int id, string nombre , string apellido, string dni, Persona.ENacionalidad nacionalidad, EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad, EClases claseQueToma,EEstadoCuenta estadoCuenta) :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Sobrecargas

        public static bool operator ==(Alumno a, EClases clase)
        {
            return (a.estadoCuenta != EEstadoCuenta.Deudor && a != clase);
        }
        public static bool operator !=(Alumno a, EClases clase)
        {
            return !(a.claseQueToma == clase);
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Generará el string con los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Generará un string que contiene la clase que toma
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE {this.claseQueToma}";
        }

        /// <summary>
        /// Devolverá todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
