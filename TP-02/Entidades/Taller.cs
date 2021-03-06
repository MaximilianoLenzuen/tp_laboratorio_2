﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {

        public enum ETipo
        {
            Ciclomotor, Sedan, Suv, Todos
        }


        private List<Vehiculo> vehiculos;

        private int espacioDisponible;

        #region "Constructores"
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Ciclomotor:
                        if(v is Ciclomotor)
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Sedan:
                        if(v is Sedan)
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Suv:
                        if(v is Suv)
                        sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            int aux = 0;
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo )
                {
                    aux = 1;
                }
            }

            if (aux == 0 && taller.vehiculos.Count() < taller.espacioDisponible)
            {
                taller.vehiculos.Add(vehiculo);
            }


            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            /* Soy conciente que podia utilizar un Contains y eliminarlo directamente sin utilizar un foreach
             Y que en un foreach no se debe/puede eliminar un elemento . pero utilizé esta logica para 
             utilizar denuevo la sobrecarga de == de vehiculo, de todos modos dejo la otra opcion.

            if (taller.vehiculos.Contains(vehiculo))
            {
                taller.vehiculos.Remove(vehiculo);
            }
            */
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                {
                    taller.vehiculos.Remove(vehiculo);
                    return taller;
                }
            }

            return taller;
        }
        #endregion
    }
}
