using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;


        #region Constructores
        
        public Universitario()
        {

        }
        
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Comparará 2 objetos para ver si son del mismo tipo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True si son del mismo tipo</returns>
        public override bool Equals(object obj)
        {
            if (this.GetType().Equals(obj.GetType()))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Utiliza stringbuilder para formar una cadena de string con los datos del universitario
        /// </summary>
        /// <returns>string con los datos</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(base.ToString());
            sb.AppendFormat($"Legajo : {this.legajo}\r\n");

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecarga

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return ((pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo) && pg1.Equals(pg2));
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

    }
}
