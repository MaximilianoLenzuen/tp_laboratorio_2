using Entidades;
using Excepctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FormularioInventario : Form
    {
        private Civilizacion civilizacion;

        Thread refresher;

        
        public FormularioInventario()
        {
            InitializeComponent();
            this.refresher = new Thread(this.ActualizarStockRecursos);

        }


        private void FormularioInventario_Load(object sender, EventArgs e)
        {
            this.civilizacion = Civilizacion.GetCivilizacion(1500, 600, 600, 700);
            this.refresher.Start();
        }

        private void ActualizarStockRecursos()
        {
            while (true)
            {
                Thread.Sleep(50);
                if (this.txtStockComida.InvokeRequired &&
                    this.txtStockMadera.InvokeRequired &&
                    this.txtStockOro.InvokeRequired &&
                    this.txtStockPiedra.InvokeRequired &&
                    this.txtPoblacion.InvokeRequired)
                {
                    this.txtStockComida.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.txtStockComida.Text = civilizacion.StockComida.ToString();
                    });
                    this.txtStockMadera.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.txtStockMadera.Text = civilizacion.StockMadera.ToString();
                    });
                    this.txtStockOro.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.txtStockOro.Text = civilizacion.StockOro.ToString();
                    });
                    this.txtStockPiedra.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.txtStockPiedra.Text = civilizacion.StockPiedra.ToString();
                    });
                    this.txtPoblacion.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.txtPoblacion.Text = civilizacion.PoblacionActual.ToString();
                    });
                }
            }
        }

        /// <summary>
        /// Actualiza los costos de la unidad buscada previamente y llenara los campos con informacion
        /// </summary>
        /// <param name="comida"></param>
        /// <param name="madera"></param>
        /// <param name="oro"></param>
        /// <param name="piedra"></param>
        /// <param name="tipo"></param>
        private void ActualizarCostos(int comida, int madera, int oro, int piedra,string tipo)
        {
            this.txtCostoComida.Text = comida.ToString();
            this.txtCostoMadera.Text = madera.ToString();
            this.txtCostoOro.Text = oro.ToString();
            this.txtCostoPiedra.Text = piedra.ToString();
            this.txtTipo.Text = tipo;
        }

        /// <summary>
        /// Vaciará los campos con informacion de unidades
        /// </summary>
        private void ActualizarTxt(object sender, EventArgs e)
        {
            this.txtCostoComida.Text = "";
            this.txtCostoMadera.Text = "";
            this.txtCostoOro.Text = "";
            this.txtCostoPiedra.Text = "";
            this.txtTipo.Text = "";
            this.txtBuscador.Text = "";
        }

        /// <summary>
        /// Recibe un nombre que enviará a una base de datos y completará los campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AccesoDataBase database = new AccesoDataBase();
            Unidad unidad;
            Edificio edificio;
            
            try
            {
                string tipo = database.BuscarTipoPorNombre(this.txtBuscador.Text);
                if (tipo == "Unidad")
                {
                    unidad = database.BuscarUnidad(this.txtBuscador.Text);
                    ActualizarCostos(unidad.CostoComida, unidad.CostoMadera, unidad.CostoOro, unidad.CostoPiedra, "Unidad");
                }
                else
                {
                    edificio = database.BuscarEdificio(this.txtBuscador.Text);
                    ActualizarCostos(edificio.CostoComida, edificio.CostoMadera, edificio.CostoOro, edificio.CostoPiedra, "Edificio");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// En base a lo que el usuario busco previamente, se fijará qué tipo de entidadmilitar es realizando validaciones y la agregará a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCostoComida.Text))
            {
                if(this.txtTipo.Text == "Unidad")
                {
                    Unidad unidad = new Unidad(this.txtBuscador.Text,
                                                int.Parse(this.txtCostoMadera.Text),
                                                int.Parse(this.txtCostoComida.Text),
                                                int.Parse(this.txtCostoOro.Text),
                                                int.Parse(this.txtCostoPiedra.Text));
                    try
                    {
                        this.civilizacion += unidad;
                        MessageBox.Show("Carga realizada con exito en la base de datos");
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    Edificio edificio = new Edificio(this.txtBuscador.Text,
                                                int.Parse(this.txtCostoMadera.Text),
                                                int.Parse(this.txtCostoComida.Text),
                                                int.Parse(this.txtCostoOro.Text),
                                                int.Parse(this.txtCostoPiedra.Text));
                    try
                    {
                        this.civilizacion += edificio;
                        MessageBox.Show("Carga realizada con exito en la base de datos");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                MessageBox.Show("Primero debe buscar una unidad para comprar!!");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea guardar la civilizacion en un archivo XML y texto ubicados en el escritorio?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                Civilizacion.Guardar(this.civilizacion);
                Civilizacion.GuardarTexto(this.civilizacion);
            }
            this.refresher.Abort();
            this.Close();
        }
    }
}
