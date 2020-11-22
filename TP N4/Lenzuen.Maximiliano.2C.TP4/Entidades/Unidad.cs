using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Unidad : EntidadMilitar , IMostrarDatos
    {
        private int espacioPoblacion;

        public Unidad()
        {

        }

        public Unidad(string nombre, int madera, int comida, int oro, int piedra) :base(nombre,comida,madera,oro,piedra)
        {
            this.espacioPoblacion = 1;
        }

        public string MostrarDatos()
        {
            return this.Nombre;
        }


        public override string ToString()
        {
            return this.MostrarDatos();
        }


        public int EspacioPoblacion
        {
            get { return this.espacioPoblacion; }
        }

    }
}
