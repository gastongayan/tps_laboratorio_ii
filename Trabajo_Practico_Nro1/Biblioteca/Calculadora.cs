using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Calculadora
    {
        /// <summary>
        /// Valida que el operador recibido por parametro sea igual a * / - +, caso contrario retorna +
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>operador validado</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador == '*' || operador == '/' || operador == '+' || operador == '-')
            {
                return operador;
            }
            return '+';
        }

        /// <summary>
        /// Reliza las operaciones solicitadas por el formulario, utilizando las sobrecarga de los operadores
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>resultado de la operacion matematica</returns>
        public double Operar(Operando num1, Operando num2, string operador)
        {
            double resultado = 0;
           if (num1 != null && num2 != null)
           {
                switch (operador)
                {
                    case "+":
                        resultado = num1 + num2;
                        break;
                    case "-":
                        resultado = num2 - num1;
                        break;
                    case "*":
                        resultado = num1 * num2;
                        break;
                    case "/":
                        resultado = num1 / num2;
                        break;
                }
           }
            return resultado;
        }
    }

   
}
