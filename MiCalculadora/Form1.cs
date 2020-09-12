using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using TP_N_1;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Evento al apretar click, que validará que el resultado tenga un valor para poder convertir a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(this.lblResultado.Text)))
            {
                Numero parametro = new Numero(this.lblResultado.Text);
                this.lblResultado.Text = parametro.BinarioDecimal(this.lblResultado.Text);
            }
            else
            {
                MessageBox.Show("No hay ningun resultado para convertir", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que valirada que el resultado tenga un valor, para convertir a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCovertirABinario_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(this.lblResultado.Text)))
            {
                Numero parametro = new Numero(this.lblResultado.Text);
                this.lblResultado.Text = parametro.DecimalBinario(this.lblResultado.Text);
            }
            else
            {
                MessageBox.Show("No hay ningun resultado para convertir", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Vuelve a poner en su estado original a los textbox, label ,y comboBox
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = "";
        }

        /// <summary>
        /// Realizara la operacion correspondiente, previamente verificando que haya numeros y operador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNumero1.Text) || string.IsNullOrEmpty(this.txtNumero2.Text) || this.cmbOperador.SelectedIndex == 0 || string.IsNullOrEmpty(this.cmbOperador.Text))
            {
                MessageBox.Show("Debe ingresar ambos datos y la operacion!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
            }
        }

        /// <summary>
        /// Realizará el calculo correspondiente al operador
        /// </summary>
        /// <param name="numero1">txtNumero1</param>
        /// <param name="numero2">txtNumero2</param>
        /// <param name="operador">cmbOperador</param>
        /// <returns>Devolverá el resultado de la operación</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
                Numero numeroUno = new Numero(numero1);
                Numero numeroDos = new Numero(numero2);
                double resultado = Calculadora.Operar(numeroUno, numeroDos, operador);
                return resultado;
        }


    }
}
