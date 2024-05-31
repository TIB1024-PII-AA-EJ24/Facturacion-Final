namespace JAFM_Facturacion
{
    partial class frmVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbCondiciones = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbTipoCliente = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRepresentanteLegal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.panelNavegacion.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panelDatosGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNavegacion
            // 
            this.panelNavegacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelNavegacion.Controls.Add(this.btnImprimir);
            this.panelNavegacion.Controls.Add(this.txtTotalRegistros);
            this.panelNavegacion.Controls.Add(this.txtClave);
            this.panelNavegacion.Controls.Add(this.label2);
            this.panelNavegacion.Controls.Add(this.label1);
            this.panelNavegacion.Controls.Add(this.btnUltimo);
            this.panelNavegacion.Controls.Add(this.btnSiguiente);
            this.panelNavegacion.Controls.Add(this.btnAnterior);
            this.panelNavegacion.Controls.Add(this.btnPrimero);
            this.panelNavegacion.Location = new System.Drawing.Point(1, 2);
            this.panelNavegacion.Margin = new System.Windows.Forms.Padding(2);
            this.panelNavegacion.Name = "panelNavegacion";
            this.panelNavegacion.Size = new System.Drawing.Size(751, 65);
            this.panelNavegacion.TabIndex = 0;
            // 
            // txtTotalRegistros
            // 
            this.txtTotalRegistros.Location = new System.Drawing.Point(407, 23);
            this.txtTotalRegistros.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalRegistros.Name = "txtTotalRegistros";
            this.txtTotalRegistros.ReadOnly = true;
            this.txtTotalRegistros.Size = new System.Drawing.Size(68, 20);
            this.txtTotalRegistros.TabIndex = 7;
            this.txtTotalRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(314, 23);
            this.txtClave.Margin = new System.Windows.Forms.Padding(2);
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
            this.label2.Location = new System.Drawing.Point(385, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "de";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "C&lave";
            // 
            // btnUltimo
            // 
            this.btnUltimo.Location = new System.Drawing.Point(548, 21);
            this.btnUltimo.Margin = new System.Windows.Forms.Padding(2);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(67, 23);
            this.btnUltimo.TabIndex = 5;
            this.btnUltimo.Text = ">>";
            this.btnUltimo.UseVisualStyleBackColor = true;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(477, 21);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(2);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(67, 23);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = ">";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(207, 21);
            this.btnAnterior.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(67, 23);
            this.btnAnterior.TabIndex = 3;
            this.btnAnterior.Text = "<";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnPrimero
            // 
            this.btnPrimero.Location = new System.Drawing.Point(137, 21);
            this.btnPrimero.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(67, 23);
            this.btnPrimero.TabIndex = 2;
            this.btnPrimero.Text = "<<";
            this.btnPrimero.UseVisualStyleBackColor = true;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // panelBotones
            // 
            this.panelBotones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBotones.Controls.Add(this.btnSalir);
            this.panelBotones.Controls.Add(this.btnCancelar);
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Controls.Add(this.btnModificar);
            this.panelBotones.Controls.Add(this.btnNuevo);
            this.panelBotones.Location = new System.Drawing.Point(1, 453);
            this.panelBotones.Margin = new System.Windows.Forms.Padding(2);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(749, 65);
            this.panelBotones.TabIndex = 2;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(505, 22);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(67, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(423, 22);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(67, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(341, 22);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(67, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(259, 22);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(67, 23);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(177, 22);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(67, 23);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // panelDatosGenerales
            // 
            this.panelDatosGenerales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDatosGenerales.Controls.Add(this.txtTotal);
            this.panelDatosGenerales.Controls.Add(this.label18);
            this.panelDatosGenerales.Controls.Add(this.txtIVA);
            this.panelDatosGenerales.Controls.Add(this.label17);
            this.panelDatosGenerales.Controls.Add(this.txtSubTotal);
            this.panelDatosGenerales.Controls.Add(this.label16);
            this.panelDatosGenerales.Controls.Add(this.dgvArticulos);
            this.panelDatosGenerales.Controls.Add(this.label15);
            this.panelDatosGenerales.Controls.Add(this.chkActivo);
            this.panelDatosGenerales.Controls.Add(this.label14);
            this.panelDatosGenerales.Controls.Add(this.cmbCondiciones);
            this.panelDatosGenerales.Controls.Add(this.label13);
            this.panelDatosGenerales.Controls.Add(this.cmbTipoCliente);
            this.panelDatosGenerales.Controls.Add(this.label12);
            this.panelDatosGenerales.Controls.Add(this.label11);
            this.panelDatosGenerales.Controls.Add(this.txtRFC);
            this.panelDatosGenerales.Controls.Add(this.txtTelefono);
            this.panelDatosGenerales.Controls.Add(this.label10);
            this.panelDatosGenerales.Controls.Add(this.txtCodigoPostal);
            this.panelDatosGenerales.Controls.Add(this.label9);
            this.panelDatosGenerales.Controls.Add(this.txtEstado);
            this.panelDatosGenerales.Controls.Add(this.label8);
            this.panelDatosGenerales.Controls.Add(this.txtCiudad);
            this.panelDatosGenerales.Controls.Add(this.label7);
            this.panelDatosGenerales.Controls.Add(this.txtDireccion);
            this.panelDatosGenerales.Controls.Add(this.label6);
            this.panelDatosGenerales.Controls.Add(this.txtRepresentanteLegal);
            this.panelDatosGenerales.Controls.Add(this.label5);
            this.panelDatosGenerales.Controls.Add(this.cmbCliente);
            this.panelDatosGenerales.Controls.Add(this.label4);
            this.panelDatosGenerales.Controls.Add(this.dtpFecha);
            this.panelDatosGenerales.Controls.Add(this.label3);
            this.panelDatosGenerales.Location = new System.Drawing.Point(1, 56);
            this.panelDatosGenerales.Margin = new System.Windows.Forms.Padding(2);
            this.panelDatosGenerales.Name = "panelDatosGenerales";
            this.panelDatosGenerales.Size = new System.Drawing.Size(751, 403);
            this.panelDatosGenerales.TabIndex = 1;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(586, 378);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(134, 20);
            this.txtTotal.TabIndex = 31;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(525, 380);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 13);
            this.label18.TabIndex = 30;
            this.label18.Text = "Total:";
            // 
            // txtIVA
            // 
            this.txtIVA.Location = new System.Drawing.Point(586, 357);
            this.txtIVA.Margin = new System.Windows.Forms.Padding(2);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ReadOnly = true;
            this.txtIVA.Size = new System.Drawing.Size(134, 20);
            this.txtIVA.TabIndex = 29;
            this.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(525, 359);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 28;
            this.label17.Text = "IVA (16%):";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(586, 336);
            this.txtSubTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(135, 20);
            this.txtSubTotal.TabIndex = 27;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(525, 338);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "Sub Total:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.Descripcion,
            this.Cantidad,
            this.PrecioUnitario,
            this.Importe});
            this.dgvArticulos.Location = new System.Drawing.Point(35, 172);
            this.dgvArticulos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.RowHeadersWidth = 30;
            this.dgvArticulos.RowTemplate.Height = 20;
            this.dgvArticulos.Size = new System.Drawing.Size(684, 161);
            this.dgvArticulos.TabIndex = 25;
            this.dgvArticulos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvArticulos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulos_CellValueChanged);
            this.dgvArticulos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvArticulos_EditingControlShowing);
            this.dgvArticulos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvArticulos_RowsRemoved);
            // 
            // Clave
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Clave.DefaultCellStyle = dataGridViewCellStyle1;
            this.Clave.HeaderText = "Clave";
            this.Clave.MinimumWidth = 8;
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            this.Clave.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Clave.Width = 45;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MinimumWidth = 8;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Descripcion.Width = 300;
            // 
            // Cantidad
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle2;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 8;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cantidad.Width = 95;
            // 
            // PrecioUnitario
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.PrecioUnitario.DefaultCellStyle = dataGridViewCellStyle3;
            this.PrecioUnitario.HeaderText = "Precio Unitario";
            this.PrecioUnitario.MinimumWidth = 8;
            this.PrecioUnitario.Name = "PrecioUnitario";
            this.PrecioUnitario.ReadOnly = true;
            this.PrecioUnitario.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PrecioUnitario.Width = 95;
            // 
            // Importe
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.Importe.DefaultCellStyle = dataGridViewCellStyle4;
            this.Importe.HeaderText = "Importe";
            this.Importe.MinimumWidth = 8;
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Importe.Width = 95;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(270, 140);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(217, 31);
            this.label15.TabIndex = 24;
            this.label15.Text = "D E T A L L E S";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Location = new System.Drawing.Point(408, 112);
            this.chkActivo.Margin = new System.Windows.Forms.Padding(2);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 23;
            this.chkActivo.Text = "Acti&vo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(359, 113);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Estatus:";
            // 
            // cmbCondiciones
            // 
            this.cmbCondiciones.FormattingEnabled = true;
            this.cmbCondiciones.Items.AddRange(new object[] {
            "Contado",
            "Credito"});
            this.cmbCondiciones.Location = new System.Drawing.Point(158, 111);
            this.cmbCondiciones.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCondiciones.Name = "cmbCondiciones";
            this.cmbCondiciones.Size = new System.Drawing.Size(168, 21);
            this.cmbCondiciones.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(34, 113);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Con&diciones de la venta:";
            // 
            // cmbTipoCliente
            // 
            this.cmbTipoCliente.Enabled = false;
            this.cmbTipoCliente.FormattingEnabled = true;
            this.cmbTipoCliente.Items.AddRange(new object[] {
            "Menudeo",
            "Medio Mayoreo",
            "Mayoreo"});
            this.cmbTipoCliente.Location = new System.Drawing.Point(603, 90);
            this.cmbTipoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipoCliente.Name = "cmbTipoCliente";
            this.cmbTipoCliente.Size = new System.Drawing.Size(117, 21);
            this.cmbTipoCliente.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(535, 92);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Tipo Cliente:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(359, 92);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "RFC:";
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(405, 90);
            this.txtRFC.Margin = new System.Windows.Forms.Padding(2);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.ReadOnly = true;
            this.txtRFC.Size = new System.Drawing.Size(127, 20);
            this.txtRFC.TabIndex = 17;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(158, 90);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(168, 20);
            this.txtTelefono.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 92);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Teléfono:";
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(677, 70);
            this.txtCodigoPostal.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.ReadOnly = true;
            this.txtCodigoPostal.Size = new System.Drawing.Size(43, 20);
            this.txtCodigoPostal.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(599, 72);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Código Postal:";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(405, 70);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(2);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(168, 20);
            this.txtEstado.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(359, 72);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Estado:";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(158, 70);
            this.txtCiudad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.ReadOnly = true;
            this.txtCiudad.Size = new System.Drawing.Size(168, 20);
            this.txtCiudad.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 72);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Ciudad:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(469, 49);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(251, 20);
            this.txtDireccion.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(412, 51);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Dirección:";
            // 
            // txtRepresentanteLegal
            // 
            this.txtRepresentanteLegal.Location = new System.Drawing.Point(158, 49);
            this.txtRepresentanteLegal.Margin = new System.Windows.Forms.Padding(2);
            this.txtRepresentanteLegal.Name = "txtRepresentanteLegal";
            this.txtRepresentanteLegal.ReadOnly = true;
            this.txtRepresentanteLegal.Size = new System.Drawing.Size(251, 20);
            this.txtRepresentanteLegal.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 51);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Representante legal:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(158, 27);
            this.cmbCliente.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(268, 21);
            this.cmbCliente.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cl&iente:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(158, 6);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(227, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Fecha:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(664, 20);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 534);
            this.ControlBox = false;
            this.Controls.Add(this.panelDatosGenerales);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelNavegacion);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmVentas";
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.frmVentas_Load);
            this.panelNavegacion.ResumeLayout(false);
            this.panelNavegacion.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.panelDatosGenerales.ResumeLayout(false);
            this.panelDatosGenerales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
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
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRepresentanteLegal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.ComboBox cmbTipoCliente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbCondiciones;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewComboBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.Button btnImprimir;
    }
}