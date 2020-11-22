using System;
using Entidades;
using Excepctions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class Tests
    {

        [TestMethod]
        [ExpectedException(typeof(AlcanzadoLimitePoblacion))]
        public void ValidarLimitePoblacion()
        {   // Arrange
            Civilizacion civ = Civilizacion.GetCivilizacion(5000, 5000, 5000, 5000);
            Unidad unidad = new Unidad("Woad Raider", 0, 65, 35, 0);
            // Act
            for (int i = 0; i < 16; i++)
            {
                civ += unidad;
            }
            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(NoExisteEnDB))]
        public void ValidarBuscador()
        {   // Arrange
            AccesoDataBase database = new AccesoDataBase();
            // Act
            database.BuscarTipoPorNombre("PEPE");
            // Assert
        }
        [TestMethod]
        public void ValidarUnidades()
        {   // Arrange
            // Act
            Civilizacion civ = Civilizacion.GetCivilizacion(8000, 8000, 8000, 8000);

            // Assert
            Assert.IsNotNull(civ.Unidades);
        }


    }
}
