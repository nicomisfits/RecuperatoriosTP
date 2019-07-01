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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor del form
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private static string numeroTxt1;
        private static string numeroTxt2;

        /// <summary>
        /// Limpia los textbox y el combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
        }

        /// <summary>
        /// textbox 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtNumero1_TextChanged(object sender, EventArgs e)
        {
            numeroTxt1 = txtNumero1.Text;
        }

        /// <summary>
        /// textbox 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtNumero2_TextChanged(object sender, EventArgs e)
        {
            numeroTxt2 = txtNumero2.Text;
        }

        /// <summary>
        /// Boton operador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(numeroTxt1);
            Numero numero2 = new Numero(numeroTxt2);
            string operador = Calculadora.ValidarOperador(this.cmbOperacion.SelectedItem.ToString());
            double resultado = Calculadora.Operar(numero1, numero2, operador);
            this.lblResultado.Text = resultado.ToString();
        }

        /// <summary>
        /// boton conversor a Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnToDec_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero(this.lblResultado.Text);
            this.lblResultado.Text = numero.BinarioADecimal(this.lblResultado.Text);
        }

        /// <summary>
        /// Boton Conversor a Binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnToBin_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero(this.lblResultado.Text);
            this.lblResultado.Text = numero.DecimalBinario(this.lblResultado.Text);
        }

        /// <summary>
        /// boton para cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
