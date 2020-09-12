using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_N_1
{
    public class Numero
    {
        private double numero;

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(string numero)
        {
            SetNumero = numero;
        }

        public Numero(double numero) 
        {
            this.numero = numero;
        }

        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }

        /// <summary>
        /// Recibe un string que intentará parsear
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>en caso de no poder parsear, retornara 0</returns>
        public double ValidarNumero(string strNumero)
        {
            double retorno;
            double.TryParse(strNumero, out retorno);
            return retorno;
        }

        /// <summary>
        /// Validará que el lblResultado.Text sea un numero binario ( formado por 1 y 0)
        /// </summary>
        /// <param name="binario">Lo recib</param>
        /// <returns>Devolverá true si es binario, o false si no lo es </returns>
        private static bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario.Substring(i, 1) != "0" && binario.Substring(i, 1) != "1")
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Convertirá un numero binario a decimal
        /// </summary>
        /// <param name="binario">recibirá un string de lblResultado.Text</param>
        /// <returns>retornará un string de acuerdo al resultado</returns>
        public string BinarioDecimal(string binario)
        {
            int posicion=0;
            int acumulador = 0;
            if (EsBinario(binario))
            {
                for (int i = binario.Length; i > 0; i--)
                {
                    acumulador = (int)(acumulador + (int.Parse(binario.Substring(i - 1, 1)) * Math.Pow(2, posicion)));
                    posicion++;
                }
                return acumulador.ToString();
            }
            else
            {
                return "Valor Invalido ";
            }
        }

        /// <summary>
        /// Convertirá el numero de decimal a binario
        /// </summary>
        /// <param name="numero"> lo recibirá del resultado de una operación previa</param>
        /// <returns>Devuelve el numero en binario en formato string</returns>
        public string DecimalBinario(double numero)
        {
            int numeroAux;
            String cadena = "";
            if (numero < 0)
            {
                numero = numero * -1;
            }

            numeroAux = (int)numero;
            
                
                while (numeroAux > 0)
                {
                    if (numeroAux % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    numeroAux = (int)(numeroAux / 2);
                }
                return cadena;
            
        }

        // Sobrecarga del metodo previo
        public string DecimalBinario(string numero)
        {
            return DecimalBinario(double.Parse(numero));
        }


        public static double operator +(Numero numero1, Numero numero2)
        {
            return numero1.numero + numero2.numero;
        }
        
        public static double operator -(Numero numero1, Numero numero2)
        {
            return numero1.numero - numero2.numero;

        }
        
        public static double operator /(Numero numero1, Numero numero2)
        {
            if (numero2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return numero1.numero / numero2.numero;
            }
        }
        public static double operator *(Numero numero1, Numero numero2)
        {
            return numero1.numero * numero2.numero;
        }

    }


}

