namespace View
{
    partial class FormularioInventario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnComprar = new System.Windows.Forms.Button();
            this.txtCostoPiedra = new System.Windows.Forms.TextBox();
            this.txtCostoOro = new System.Windows.Forms.TextBox();
            this.txtCostoMadera = new System.Windows.Forms.TextBox();
            this.txtCostoComida = new System.Windows.Forms.TextBox();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtStockComida = new System.Windows.Forms.TextBox();
            this.txtStockMadera = new System.Windows.Forms.TextBox();
            this.txtStockOro = new System.Windows.Forms.TextBox();
            this.txtStockPiedra = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtPoblacion = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnComprar
            // 
            this.btnComprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprar.Location = new System.Drawing.Point(600, 568);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(169, 50);
            this.btnComprar.TabIndex = 0;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            this.btnComprar.Click += new System.EventHandler(this.ActualizarTxt);
            // 
            // txtCostoPiedra
            // 
            this.txtCostoPiedra.Location = new System.Drawing.Point(600, 504);
            this.txtCostoPiedra.Name = "txtCostoPiedra";
            this.txtCostoPiedra.Size = new System.Drawing.Size(121, 20);
            this.txtCostoPiedra.TabIndex = 1;
            // 
            // txtCostoOro
            // 
            this.txtCostoOro.Location = new System.Drawing.Point(600, 467);
            this.txtCostoOro.Name = "txtCostoOro";
            this.txtCostoOro.Size = new System.Drawing.Size(121, 20);
            this.txtCostoOro.TabIndex = 2;
            // 
            // txtCostoMadera
            // 
            this.txtCostoMadera.Location = new System.Drawing.Point(600, 425);
            this.txtCostoMadera.Name = "txtCostoMadera";
            this.txtCostoMadera.Size = new System.Drawing.Size(121, 20);
            this.txtCostoMadera.TabIndex = 3;
            // 
            // txtCostoComida
            // 
            this.txtCostoComida.Location = new System.Drawing.Point(600, 388);
            this.txtCostoComida.Name = "txtCostoComida";
            this.txtCostoComida.Size = new System.Drawing.Size(121, 20);
            this.txtCostoComida.TabIndex = 4;
            // 
            // txtBuscador
            // 
            this.txtBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscador.Location = new System.Drawing.Point(600, 290);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(168, 31);
            this.txtBuscador.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(600, 327);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(169, 46);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtStockComida
            // 
            this.txtStockComida.Location = new System.Drawing.Point(628, 21);
            this.txtStockComida.Name = "txtStockComida";
            this.txtStockComida.Size = new System.Drawing.Size(60, 20);
            this.txtStockComida.TabIndex = 7;
            // 
            // txtStockMadera
            // 
            this.txtStockMadera.Location = new System.Drawing.Point(628, 47);
            this.txtStockMadera.Name = "txtStockMadera";
            this.txtStockMadera.Size = new System.Drawing.Size(60, 20);
            this.txtStockMadera.TabIndex = 8;
            // 
            // txtStockOro
            // 
            this.txtStockOro.Location = new System.Drawing.Point(628, 73);
            this.txtStockOro.Name = "txtStockOro";
            this.txtStockOro.Size = new System.Drawing.Size(60, 20);
            this.txtStockOro.TabIndex = 9;
            // 
            // txtStockPiedra
            // 
            this.txtStockPiedra.Location = new System.Drawing.Point(628, 99);
            this.txtStockPiedra.Name = "txtStockPiedra";
            this.txtStockPiedra.Size = new System.Drawing.Size(60, 20);
            this.txtStockPiedra.TabIndex = 10;
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(600, 541);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(120, 20);
            this.txtTipo.TabIndex = 11;
            // 
            // txtPoblacion
            // 
            this.txtPoblacion.Location = new System.Drawing.Point(628, 125);
            this.txtPoblacion.Name = "txtPoblacion";
            this.txtPoblacion.Size = new System.Drawing.Size(30, 20);
            this.txtPoblacion.TabIndex = 12;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(257, 554);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(181, 53);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormularioInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::View.Properties.Resources.ImagenTp4;
            this.ClientSize = new System.Drawing.Size(777, 630);
            this.ControlBox = false;
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtPoblacion);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.txtStockPiedra);
            this.Controls.Add(this.txtStockOro);
            this.Controls.Add(this.txtStockMadera);
            this.Controls.Add(this.txtStockComida);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscador);
            this.Controls.Add(this.txtCostoComida);
            this.Controls.Add(this.txtCostoMadera);
            this.Controls.Add(this.txtCostoOro);
            this.Controls.Add(this.txtCostoPiedra);
            this.Controls.Add(this.btnComprar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormularioInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.FormularioInventario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.TextBox txtCostoPiedra;
        private System.Windows.Forms.TextBox txtCostoOro;
        private System.Windows.Forms.TextBox txtCostoMadera;
        private System.Windows.Forms.TextBox txtCostoComida;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtStockComida;
        private System.Windows.Forms.TextBox txtStockMadera;
        private System.Windows.Forms.TextBox txtStockOro;
        private System.Windows.Forms.TextBox txtStockPiedra;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.TextBox txtPoblacion;
        private System.Windows.Forms.Button btnCerrar;
    }
}

