using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Revisará que para la operacion se utilize un operador adecuado
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Devuelve el operador validado, o + </returns>
        private static string ValidarOperacion(char operador)
        {
            string retorno = "+";
            if (operador == '/' || operador == '*' || operador == '-')
            {
                return operador.ToString();
            }

            return retorno;
        }

        /// <summary>
        /// Realiza operaciones entre 2 numeros
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Devuelve el resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno;
            switch (ValidarOperacion(Convert.ToChar(operador)))
            {
                case "/":
                    retorno = num1 / num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                default:
                    retorno = num1 + num2;
                    break;

            }
            return retorno;
        }

    }
}
