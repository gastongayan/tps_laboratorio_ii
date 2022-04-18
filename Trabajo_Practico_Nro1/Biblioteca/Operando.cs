using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Biblioteca
{
    public class Operando
    {
        //Atributo de la clase
        private double numero;

        /// <summary>
        /// Constructor por defecto, inicializa con valor 0
        /// </summary>
        public Operando() : this(0)
        {
        }

        /// <summary>
        /// Constructor con parametro numerico de doble presicion
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor con valor obtenido de un string
        /// Convierte e invoca al constructor numerico
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero)
        {
            double.TryParse(strNumero, out this.numero);

        }

        /// <summary>
        /// Valida y setea el valor recibido
        /// </summary>
        public string Numero
        {
            set { this.numero = ValidarOperando(value); }
           
        }

        /// <summary>
        /// Valida que el operador recibido como cadena, sea convertible a numerico double
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>numero convertido o 0 en caso de no convertir</returns>
        private double ValidarOperando(string strNumero)
        {
            double numero = 0;
            if (!double.TryParse(strNumero, out numero))
            {
                return numero;
            }
            return 0;
        } 

        /// <summary>
        /// Convierte dato recibido como cadena a un array de char, comprueba que sea binario y realiza convercion
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Valor convertido a decimal en formato cadena</returns>
        public static string BinarioDecimal(string binario)
        {
            char[] binarioChar = binario.ToCharArray();
            Array.Reverse(binarioChar);
            int resultado = 0;
            for(int i = 0; i < binarioChar.Length; i++)
            {
                if (binarioChar[i] == '1')
                {
                    resultado += (int)Math.Pow(2, i);
                }
            }
            return resultado.ToString();
            
        }

        /// <summary>
        /// Convierte dato recibido como cadena a double, realiza convercion invocando a la sobrecarga para parametro numerico
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Valor invalido si no se pudo convertir o resultado en binario</returns>
        public static string DecimalBinario(string numero)
        {
            double resultado = 0;
            if(double.TryParse(numero, out resultado) && resultado >= 0)
            {
                if(resultado == 0)
                {
                    return "0";
                }
                return DecimalBinario(resultado);
                
            }
            return "Valor invalido";
        }

        /// <summary>
        /// /// Convierte dato recibido a entero, realiza convercion 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>numero binario en formato cadena</returns>
        public static string DecimalBinario(double numero)
        {
            string numeroBinario = string.Empty;
            int numeroEntero = (int)numero;
            
            while (numeroEntero > 0)
            {
                numeroBinario = $"{(int)numeroEntero % 2}" + numeroBinario;
                numeroEntero = (int)numeroEntero / 2;
            }
            return numeroBinario;
        }

        /// <summary>
        /// Comprueba que la cadena recibida contenga solamente los digitos 1 y 0
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>true = es binario y false = no es binario</returns>
        private bool EsBinario(string binario)
        {
            char[] binarioChar = binario.ToCharArray();
            for(int i = 0; i < binarioChar.Length; i++)
            {
                if (binarioChar[i] != '0' && binarioChar[i] != '1')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Sobrecarga del operador - para objetos del tipo Operando
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>resultado de la resta</returns>
        public static double operator -(Operando num1, Operando num2)
        {
            return (num1.numero - num2.numero);
        }

        /// <summary>
        /// Sobrecarga del operador + para objetos del tipo Operando
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>resultado de la suma</returns>
        public static double operator +(Operando num1, Operando num2)
        {
            return (num1.numero + num2.numero);
        }

        /// <summary>
        /// Sobrecarga del operador * para objetos del tipo Operando
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>resultado de la multiplicacion</returns>
        public static double operator *(Operando num1, Operando num2)
        {
            return (num1.numero * num2.numero);
        }

        /// <summary>
        /// Sobrecarga del operador / para objetos del tipo Operando, en caso de que el divisor sea igual a 0 
        /// devuelve el valor minimo del tipo double    
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>resultado de la resta</returns>
        public static double operator /(Operando num1, Operando num2)
        {
            if(num2.numero == 0)
            {
                return Double.MinValue;
            }
            return (num1.numero / num2.numero);
        }



    }
}
