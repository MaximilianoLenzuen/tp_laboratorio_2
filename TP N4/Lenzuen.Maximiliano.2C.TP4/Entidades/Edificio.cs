using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Edificio : EntidadMilitar , IMostrarDatos
    {
        public Edificio()
        {

        }

        public Edificio(string nombre, int costoMadera,int costoComida, int costoOro , int costoPiedra) : base(nombre, costoComida, costoMadera, costoOro, costoPiedra)
        {

        }

        public string MostrarDatos()
        {
            return this.Nombre;
        }


        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Edificio e, Edificio f)
        {
            return e.Nombre == f.Nombre;
        }
        public static bool operator !=(Edificio e, Edificio f)
        {
            return e.Nombre == f.Nombre;
        }
    }
}
