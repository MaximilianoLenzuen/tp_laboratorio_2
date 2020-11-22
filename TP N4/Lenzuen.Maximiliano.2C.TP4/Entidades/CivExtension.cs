using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class CivExtension
    {
        /// <summary>
        /// Extenderá a la civilizacion y verificará que se posean los recursos para la operacion
        /// </summary>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <returns> Validará recursos</returns>

        private static bool ValidarRecursos(this Civilizacion civ, EntidadMilitar unidad)
        {
            if (unidad.CostoComida <= civ.StockComida &&
                        unidad.CostoMadera <= civ.StockMadera &&
                        unidad.CostoOro <= civ.StockOro && unidad.CostoPiedra <= civ.StockPiedra)
            {
                return true;
            }
            return false;
        }
    }
}
