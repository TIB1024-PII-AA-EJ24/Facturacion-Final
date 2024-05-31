namespace JAFM_Facturacion
{
    partial class frmCatCli
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
            this.panelNavegacion = new System.Windows.Forms.Panel();
            this.txtTotalRegistros = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panelDatosGenerales = new System.Windows.Forms.Panel();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lstTipoCliente = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRepresentanteLegal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelNavegacion.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panelDatosGenerales.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNavegacion
            // 
            this.panelNavegacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelNavegacion.Controls.Add(this.txtTotalRegistros);
            this.panelNavegacion.Controls.Add(this.txtClave);
            this.panelNavegacion.Controls.Add(this.label2);
            this.panelNavegacion.Controls.Add(this.label1);
            this.panelNavegacion.Controls.Add(this.btnUltimo);
            this.panelNavegacion.Controls.Add(this.btnSiguiente);
            this.panelNavegacion.Controls.Add(this.btnAnterior);
            this.panelNavegacion.Controls.Add(this.btnPrimero);
            this.panelNavegacion.Location = new System.Drawing.Point(1, 1);
            this.panelNavegacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelNavegacion.Name = "panelNavegacion";
            this.panelNavegacion.Size = new System.Drawing.Size(533, 65);
            this.panelNavegacion.TabIndex = 0;
            // 
            // txtTotalRegistros
            // 
            this.txtTotalRegistros.Location = new System.Drawing.Point(305, 23);
            this.txtTotalRegistros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTotalRegistros.Name = "txtTotalRegistros";
            this.txtTotalRegistros.ReadOnly = true;
            this.txtTotalRegistros.Size = new System.Drawing.Size(68, 20);
            this.txtTotalRegistros.TabIndex = 7;
            this.txtTotalRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(213, 23);
            this.txtClave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(68, 20);
            this.txtClave.TabIndex = 1;
            this.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClave_KeyDown);
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClave_KeyPress);
            this.txtClave.Leave += new System.EventHandler(this.txtClave_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "de";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "C&lave";
            // 
            // btnUltimo
            // 
            this.btnUltimo.Location = new System.Drawing.Point(447, 21);
            this.btnUltimo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(67, 23);
            this.btnUltimo.TabIndex = 5;
            this.btnUltimo.Text = ">>";
            this.btnUltimo.UseVisualStyleBackColor = true;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(376, 21);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(67, 23);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = ">";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(106, 21);
            this.btnAnterior.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(67, 23);
            this.btnAnterior.TabIndex = 3;
            this.btnAnterior.Text = "<";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnPrimero
            // 
            this.btnPrimero.Location = new System.Drawing.Point(35, 21);
            this.btnPrimero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(67, 23);
            this.btnPrimero.TabIndex = 2;
            this.btnPrimero.Text = "<<";
            this.btnPrimero.UseVisualStyleBackColor = true;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // panelBotones
            // 
            this.panelBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBotones.Controls.Add(this.btnSalir);
            this.panelBotones.Controls.Add(this.btnCancelar);
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Controls.Add(this.btnModificar);
            this.panelBotones.Controls.Add(this.btnNuevo);
            this.panelBotones.Location = new System.Drawing.Point(1, 317);
            this.panelBotones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(531, 65);
            this.panelBotones.TabIndex = 2;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(396, 22);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(67, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(314, 22);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(67, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(232, 22);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(67, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(150, 22);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(67, 23);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(68, 22);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(67, 23);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // panelDatosGenerales
            // 
            this.panelDatosGenerales.Controls.Add(this.chkActivo);
            this.panelDatosGenerales.Controls.Add(this.label12);
            this.panelDatosGenerales.Controls.Add(this.lstTipoCliente);
            this.panelDatosGenerales.Controls.Add(this.label11);
            this.panelDatosGenerales.Controls.Add(this.txtRFC);
            this.panelDatosGenerales.Controls.Add(this.label10);
            this.panelDatosGenerales.Controls.Add(this.txtTelefono);
            this.panelDatosGenerales.Controls.Add(this.label9);
            this.panelDatosGenerales.Controls.Add(this.txtCodigoPostal);
            this.panelDatosGenerales.Controls.Add(this.label8);
            this.panelDatosGenerales.Controls.Add(this.txtEstado);
            this.panelDatosGenerales.Controls.Add(this.label7);
            this.panelDatosGenerales.Controls.Add(this.txtCiudad);
            this.panelDatosGenerales.Controls.Add(this.label6);
            this.panelDatosGenerales.Controls.Add(this.txtDireccion);
            this.panelDatosGenerales.Controls.Add(this.label5);
            this.panelDatosGenerales.Controls.Add(this.txtRepresentanteLegal);
            this.panelDatosGenerales.Controls.Add(this.label4);
            this.panelDatosGenerales.Controls.Add(this.txtNombre);
            this.panelDatosGenerales.Controls.Add(this.label3);
            this.panelDatosGenerales.Location = new System.Drawing.Point(1, 70);
            this.panelDatosGenerales.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelDatosGenerales.Name = "panelDatosGenerales";
            this.panelDatosGenerales.Size = new System.Drawing.Size(531, 243);
            this.panelDatosGenerales.TabIndex = 1;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Location = new System.Drawing.Point(145, 205);
            this.chkActivo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 19;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 206);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Estatus:";
            // 
            // lstTipoCliente
            // 
            this.lstTipoCliente.FormattingEnabled = true;
            this.lstTipoCliente.Items.AddRange(new object[] {
            "Menudeo",
            "Medio Mayoreo",
            "Mayoreo"});
            this.lstTipoCliente.Location = new System.Drawing.Point(145, 173);
            this.lstTipoCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstTipoCliente.Name = "lstTipoCliente";
            this.lstTipoCliente.Size = new System.Drawing.Size(103, 30);
            this.lstTipoCliente.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 173);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Tipo d&e Cliente:";
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(145, 152);
            this.txtRFC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRFC.MaxLength = 15;
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(127, 20);
            this.txtRFC.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 154);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "R.&F.C.:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(145, 131);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(168, 20);
            this.txtTelefono.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 133);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "&Teléfono:";
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(145, 110);
            this.txtCodigoPostal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCodigoPostal.MaxLength = 5;
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(43, 20);
            this.txtCodigoPostal.TabIndex = 11;
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPostal_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 112);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Código &Postal:";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(145, 90);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEstado.MaxLength = 20;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(168, 20);
            this.txtEstado.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 92);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Est&ado:";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(145, 69);
            this.txtCiudad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCiudad.MaxLength = 20;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(168, 20);
            this.txtCiudad.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "C&iudad:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(145, 48);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDireccion.MaxLength = 30;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(251, 20);
            this.txtDireccion.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "&Dirección:";
            // 
            // txtRepresentanteLegal
            // 
            this.txtRepresentanteLegal.Location = new System.Drawing.Point(145, 27);
            this.txtRepresentanteLegal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRepresentanteLegal.MaxLength = 30;
            this.txtRepresentanteLegal.Name = "txtRepresentanteLegal";
            this.txtRepresentanteLegal.Size = new System.Drawing.Size(251, 20);
            this.txtRepresentanteLegal.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "&Representante legal:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(145, 7);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.MaxLength = 30;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(251, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "N&ombre";
            // 
            // frmCatCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 382);
            this.ControlBox = false;
            this.Controls.Add(this.panelDatosGenerales);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelNavegacion);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmCatCli";
            this.Text = "Catálogo de Clientes";
            this.Load += new System.EventHandler(this.frmCatCli_Load);
            this.panelNavegacion.ResumeLayout(false);
            this.panelNavegacion.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.panelDatosGenerales.ResumeLayout(false);
            this.panelDatosGenerales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNavegacion;
        private System.Windows.Forms.TextBox txtTotalRegistros;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnPrimero;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Panel panelDatosGenerales;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lstTipoCliente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRepresentanteLegal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
    }
}