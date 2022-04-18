using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        
        /// <summary>
        /// Inicializa componentes del formulario
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Realiza carga del formulario y asigna los operadores al combo box correspondiente al operador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add(' ');
            cmbOperador.Items.Add('/');
            cmbOperador.Items.Add('*');
            cmbOperador.Items.Add('+');
            cmbOperador.Items.Add('-');
            Limpiar();
        }

        /// <summary>
        /// Metodo del boton limpiar, invoca al metodo creado a tal fin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Restablece los datos de los text box dandole valores vacios
        /// </summary>
        private void Limpiar()
        {
            lblResultado.Text = "";
            cmbOperador.SelectedIndex = 0;
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            btnConvertirABinario.Enabled = false;
        }

        /// <summary>
        /// Inicia el proceso de operacion matematica al oprimir el boton Operar
        /// realiza todas las validaciones correspondientes para cualquier tipo de valor no admitido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            string operador;
            double temp;
            string operaciones;
            string signo = "";
            if(string.IsNullOrEmpty(txtNumero1.Text) || string.IsNullOrEmpty(txtNumero2.Text))
            {
                MessageBox.Show("Debe ingresar al menos un valor en cada campo para realizar la operacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
            }
            else
            {
                if (cmbOperador.SelectedItem == null || cmbOperador.SelectedItem.ToString() == " ")
                {
                    cmbOperador.Text = "+";
                    operador = "+";
                }
                else
                {
                    operador = cmbOperador.SelectedItem.ToString();
                }
                if(Double.TryParse(txtNumero1.Text, out temp) && Double.TryParse(txtNumero2.Text, out temp) && !Double.IsNaN(temp))
                {
                    resultado = Operar(txtNumero1.Text, txtNumero2.Text, operador);
                    if(resultado < 0)
                    {
                        signo = "- ";
                    }
                    lblResultado.Text = signo + resultado.ToString();
                    operaciones = ($"{txtNumero1.Text} {operador} {txtNumero2.Text} = {lblResultado.Text}");
                    lstOperaciones.Items.Add(operaciones.ToString());
                    btnConvertirABinario.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Datos ingresados incorrectos, porfavor ingrese valores numericos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Limpiar();

                }



            }
                
           
        }

        /// <summary>
        /// Setea los valores para los operandos e invoca el metodo operar de la clase Calculadora
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>resultado de la operacion matematica</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            
            Calculadora calculadora = new Calculadora();
            Operando operador1 = new Operando(numero1);
            Operando operador2 = new Operando(numero2);
            resultado = calculadora.Operar(operador1, operador2, operador);
            return resultado;

   
        }
       
        /// <summary>
        /// Metodo del boton cerrar, confirma que este seguro de salir, caso contrario permanece en el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult Result;
            Result = MessageBox.Show("Desea salir?", "Salir",  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (Result == DialogResult.No)
            {
                Application.Exit();
            }
        }


        /// <summary>
        /// Pregunta si desea salir al cerrar desde la (X) caso afirmativo cierra, caso contrario permanece en el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            DialogResult Result;
            Result = MessageBox.Show("Desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.No)
            {
                e.Cancel = true;
            }
            
        }

        /// <summary>
        /// Metodo para invocar a la convercion binaria a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblResultado.Text)){
                
                lblResultado.Text = Operando.DecimalBinario(lblResultado.Text);
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = true;
            }
        }

        /// <summary>
        /// Metodo para invocar a la convercion binaria a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }
    }
}
