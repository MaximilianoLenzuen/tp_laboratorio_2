using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class EntidadMilitar
    {
        private string nombre;

        private int costoComida;

        private int costoMadera;

        private int costoOro;

        private int costoPiedra;

        public EntidadMilitar()
        {

        }

        public EntidadMilitar(string nombre, int costoComida, int costoMadera, int costoOro , int costoPiedra)
        {
            this.nombre = nombre;
            this.costoComida = costoComida;
            this.costoMadera = costoMadera;
            this.costoOro = costoOro;
            this.costoPiedra = costoPiedra;
        }

        #region Properties
        public int CostoComida
        {
            get { return this.costoComida; }
            set { costoComida = value; }
        }

        public int CostoMadera
        {
            get { return this.costoMadera; }
            set { costoMadera = value; }
        }
        public int CostoOro
        {
            get { return this.costoOro; }
            set { costoOro = value; }
        }
        public int CostoPiedra
        {
            get { return this.costoPiedra; }
            set { costoPiedra = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        #endregion

    }
}
