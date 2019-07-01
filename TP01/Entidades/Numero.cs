using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        /// <summary>
        /// Constructor por defecto de numero.
        /// </summary>
        private double numero;

        #region constructores
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// constructor de numero que toma un string
        /// </summary>
        /// <param name="numero">string recibido</param>
        public Numero(string numero) : this()
        {
            SetNumero = numero;
        }

        /// <summary>
        /// constructor de numero toma un double
        /// </summary>
        /// <param name="d1">double recibido</param>
        public Numero(double d1) : this()
        {
            this.numero = d1;
        }

        #endregion

        # region metodos
        /// <summary>
        /// metodo que valida que el string recibido pueda convertirse en double
        /// </summary>
        /// <param name="numeroValida">sring a validar</param>
        /// <returns>0D si no valida | valor double si valida</returns>
        private static double ValidarNumero(string numeroValida)
        {
            double retorno;
            bool aplica = double.TryParse(numeroValida, out retorno);
            if (!aplica)
            {
                retorno = 0D;
            }
            return retorno;
        }

        /// <summary>
        /// asigna valor validado al atributo de la clase.
        /// </summary>        
        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }


        /// <summary>
        /// metodo que convierte valor de binario a decimal
        /// </summary>
        /// <param name="input">valor a convertir</param>
        /// <returns>0D si no valida | valor double si valida</returns>
        public string BinarioADecimal(string input)
        {
            char[] array = input.ToCharArray();            
            Array.Reverse(array);
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {                    
                    sum += (int)Math.Pow(2, i);
                }
            }
            return sum.ToString();
        }

        /// <summary>
        ///  metodo que convierte resultado de decimal a binario
        /// </summary>
        /// <param name="input">valor a convertir</param>
        /// <returns>numero convertido o mensaje de error</returns>
        public string DecimalBinario(string input)
        {
            double numero = 0;
            Double.TryParse(input, out numero);
            string binario = "";
            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        binario = "0" + binario;
                    }
                    else
                    {
                        binario = "1" + binario;
                    }
                    numero = (int)numero / 2;
                }
            }
            else if (numero == 0)
            {
                binario = "0";
            }
            else
            {
                binario = "Error, ingresar numeros positivos.";
            }
            return binario;
        }



        #endregion

        #region sobrecarga de operadores
        /// <summary>
        /// sobrecarga de operador suma
        /// </summary>
        /// <param name="n1">operando 1</param>
        /// <param name="n2">operando 2</param>
        /// <returns>resultado como double</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double retorno = n1.numero + n2.numero;
            return retorno;
        }

        /// <summary>
        /// sobrecarga de operador resta
        /// </summary>
        /// <param name="n1">operando 1</param>
        /// <param name="n2">óperando 2</param>
        /// <returns>resultado como double</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double retorno = n1.numero - n2.numero;
            return retorno;
        }

        /// <summary>
        /// sobrecarga de operador multiplicacion
        /// </summary>
        /// <param name="n1">operando 1</param>
        /// <param name="n2">operando 2</param>
        /// <returns>resultado como double</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double retorno = n1.numero * n2.numero;
            return retorno;
        }

        /// <summary>
        /// sobrecarga de operador division
        /// </summary>
        /// <param name="n1">operando 1</param>
        /// <param name="n2">operando 2</param>
        /// <returns>resultado como double</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = n1.numero / n2.numero;
            return retorno;
        }

        /// <summary>
        ///sobrecarga de operador igual
        /// </summary>
        /// <param name="n1">objeto numero</param>
        /// <param name="d1">double</param>
        /// <returns>bool</returns>
        public static bool operator ==(Numero n1, double d1)
        {
            bool retorno = false;
            if (n1.numero == d1)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// sobrecarga de operador distinto
        /// </summary>
        /// <param name="n1">objeto numero</param>
        /// <param name="d1">double</param>
        /// <returns>bool</returns>
        public static bool operator !=(Numero n1, double d1)
        {
            return !(n1 == d1);
        }

        # endregion
    }
}
