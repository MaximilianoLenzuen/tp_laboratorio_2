using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;
using EntidadesAbstractas;

namespace Test
{
    [TestClass]
    public class Test
    {

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidarDniException()
        {   // Arrange
            string dni = "123asda";
            // Act
            Alumno alumno = new Alumno(23, "Maxi", "Lenzuen", dni, Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void ValidarSinProfesorException()
        {   // Arrange
            Universidad uni = new Universidad();
            Random random = new Random();
            Universidad.EClases clase = (Universidad.EClases)random.Next(0, 3);

            // Act
            uni += clase;
            // Assert
        }

        [TestMethod]
        public void ValidarAlumnos()
        {   // Arrange
            // Act
            Universidad uni = new Universidad();
            // Assert
            Assert.IsNotNull(uni.Alumnos);
        }
    }
}
