using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hardcodeo de entidades militares
            Civilizacion civ = Civilizacion.GetCivilizacion(500, 8000, 500, 0);
            Edificio edificioCastillo = new Edificio("Castillo", 0, 0, 0, 650);
            Edificio edificioGaleria = new Edificio("Galeria",175,0,0,0);
            Edificio edificioEstablo = new Edificio("Establo", 175, 0, 0, 0);
            Unidad unidad = new Unidad("Caballeria Ligera", 0, 80, 0, 0);
            // Se empiezan a agregar estas entidades a la civilizacion ( Persisten en la base de datos)
            // Siendo 15 el limite de poblacion, agrego a 15 unidades para alcanzarlo y lanzar excepcion al siguiente intento
            for (int i = 0; i < 15; i++)
            {
                civ += unidad;
            }
            try
            {
                civ += unidad;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            civ += edificioEstablo;
            civ += edificioGaleria;
            // Se intenta agregar un castillo sin poseer piedra
            try
            {
                civ += edificioCastillo;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            /// Se guardan los datos en un archivo xml en el escritorio
            Civilizacion.Guardar(civ);
            /// Se guardan el un archivo de texto en el escritorio
            Civilizacion.GuardarTexto(civ);
            /// Se leen los datos del archivo de texto
            Console.WriteLine(Civilizacion.LeerTexto());
            Console.WriteLine("PD: Los celtas no tienen camellos :c");
            Console.ReadKey();

            
        }
    }
}
