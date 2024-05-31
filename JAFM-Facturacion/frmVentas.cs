using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JAFM_Facturacion
{
    public partial class frmVentas : Form
    {
        // Variables globales
        SqlDataAdapter daVentasMaestro; // Adaptador entre BD y Aplicación
        SqlDataAdapter daVentasDetalle; // Adaptador entre BD y Aplicación
        SqlDataAdapter daClientes;      // Adaptador entre BD y Aplicación
        SqlDataAdapter daArticulos;     // Adaptador entre BD y Aplicación
        DataSet ds;                     // Conjunto de datos local
        CurrencyManager manejador;      // Administrador de navegación
        int miManejadorPosicion = 0;    // Posición actual del administrador
        Estado miEstado;                // Estado actual del formulario

        public frmVentas()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar sólo dígitos y caracteres de control
            if ( ( Char.IsDigit(e.KeyChar) ) || ( Char.IsControl(e.KeyChar) ) )
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            // Seleccionar el tipo de venta
            cmbCondiciones.SelectedIndex = 0;

            // Cadena de conexión a la base de datos
            String conexion = "Data Source=(local);Initial Catalog=Aplicacion;Persist Security Info=true;User ID=pDos;Password=pDos";

            // Cadenas para seleccionar los datos
            String seleccionArticulos = "SELECT * FROM Articulos WHERE Activo = 'TRUE'";
            String seleccionClientes = "SELECT * FROM Clientes WHERE Activo = 'TRUE' ORDER BY Nombre";
            String seleccionVentasMaestro = "SELECT * FROM VentasMaestro";
            String seleccionVentasDetalle = "SELECT * FROM VentasDetalle";

            // Crear adaptadores para comunicar el manejador de la base de datos
            // con mi aplicación
            daVentasMaestro = new SqlDataAdapter(seleccionVentasMaestro, conexion);
            daVentasDetalle = new SqlDataAdapter(seleccionVentasDetalle, conexion);
            daClientes = new SqlDataAdapter(seleccionClientes, conexion);
            daArticulos = new SqlDataAdapter(seleccionArticulos, conexion);

            // Crear comando Update para VentasMAestro y VentasDetalle
            SqlCommandBuilder cmdBuilderVM = new SqlCommandBuilder(daVentasMaestro);
            daVentasMaestro.UpdateCommand = cmdBuilderVM.GetUpdateCommand();
            SqlCommandBuilder cmdBuilderVD = new SqlCommandBuilder(daVentasDetalle);
            daVentasDetalle.UpdateCommand = cmdBuilderVD.GetUpdateCommand();

            // Crear objeto DataSet
            ds = new DataSet();

            // Llenar la tablas del DataSet con los datos de la BD
            daVentasMaestro.Fill(ds,"VentasMaestro");
            daVentasDetalle.Fill(ds, "VentasDetalle");
            daArticulos.Fill(ds, "Articulos");
            daClientes.Fill(ds, "Clientes");

            // Crear la relación entre las tablas
            // VentasMaestro y VentasDetalle
            DataColumn columnaVM = ds.Tables["VentasMaestro"].Columns["Factura"];
            DataColumn columnaVD = ds.Tables["VentasDetalle"].Columns["Factura"];
            DataRelation relacionVMVD = new DataRelation("VMVD", columnaVM, columnaVD);
            ds.Relations.Add(relacionVMVD);

            // Llenar ComboBox de Clientes
            cmbCliente.DataSource = ds.Tables["Clientes"];
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "Clave";

            // Definir los valores por omisión (default) de las columnas
            // a enlazar con las casillas de verificación y otros componentes
            // Obligatorio para que funcione el método AddNew()
            ds.Tables["VentasMaestro"].Columns["Fecha"].DefaultValue = DateTime.Now;
            // Para el combobox de Cliente se usará el primer cliente de la lista
            int claveCliente = 0;
            if (ds.Tables["Clientes"].Rows.Count > 0)
                claveCliente = Convert.ToInt32(
                        ds.Tables["Clientes"].Rows[0]["Clave"]
                    );
            ds.Tables["VentasMaestro"].Columns["Cliente"].DefaultValue = claveCliente;
            ds.Tables["VentasMaestro"].Columns["Condiciones"].DefaultValue = 0;     // Contado
            ds.Tables["VentasMAestro"].Columns["Activo"].DefaultValue = true;

            // Enlazar los componentes de la interfaz de usuario
            // VentasMaestro
            txtClave.DataBindings.Add("Text", ds.Tables["VentasMaestro"], "Factura");
            dtpFecha.DataBindings.Add("Value", ds.Tables["VentasMaestro"], "Fecha");
            cmbCliente.DataBindings.Add("SelectedValue", ds.Tables["VentasMaestro"], "Cliente");
            cmbCondiciones.DataBindings.Add("SelectedIndex", ds.Tables["VentasMaestro"], "Condiciones");
            chkActivo.DataBindings.Add("Checked", ds.Tables["VentasMaestro"], "Activo");
            // Clientes
            txtRepresentanteLegal.DataBindings.Add("Text", ds.Tables["Clientes"], "RepresentanteLegal");
            txtDireccion.DataBindings.Add("Text", ds.Tables["Clientes"], "Direccion");
            txtCiudad.DataBindings.Add( "Text", ds.Tables["Clientes"], "Ciudad" );
            txtEstado.DataBindings.Add("Text", ds.Tables["Clientes"], "Estado");
            txtCodigoPostal.DataBindings.Add("Text", ds.Tables["Clientes"], "CodigoPostal");
            txtTelefono.DataBindings.Add("Text", ds.Tables["Clientes"], "Telefono");
            txtRFC.DataBindings.Add("Text", ds.Tables["Clientes"], "RFC");
            cmbTipoCliente.DataBindings.Add("SelectedIndex", ds.Tables["Clientes"], "TipoCliente");

            // Llenar la columna Descripcion del DataGrid con la tabla de Artículos
            DataGridViewComboBoxColumn columnaDescripcion =
                        (DataGridViewComboBoxColumn)dgvArticulos.Columns[1];

            columnaDescripcion.DataSource = ds.Tables["Articulos"];
            columnaDescripcion.DisplayMember = "Nombre";
            columnaDescripcion.ValueMember = "Clave";

            // Relacionar el manejador del enlace con la tabla
            manejador = (CurrencyManager)this.BindingContext[ds.Tables["VentasMaestro"]];

            // Establecer el total de registros
            txtTotalRegistros.Text = manejador.Count.ToString();

            // Establecer el estado en modo Ver
            establecerEstado(Estado.Ver);

            // Mostrar detalles
            mostrarDetalles();
        }

        // Método establecerEstado
        private void establecerEstado(Estado cual)
        {
            // Habilitar/Deshabilitar componentes de la interfaz
            // según el estado
            miEstado = cual;

            switch (miEstado)
            {
                case Estado.Ver:
                    panelNavegacion.Enabled = true;
                    panelDatosGenerales.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnModificar.Enabled = manejador.Count > 0;
                    btnGuardar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnSalir.Enabled = true;
                    break;

                default:
                    panelNavegacion.Enabled = false;
                    panelDatosGenerales.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnModificar.Enabled = false;
                    btnGuardar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnSalir.Enabled = false;
                    break;
            }
        }

        // Método para mostrar los detalles de la venta
        private void mostrarDetalles()
        { 
            // Eliminar cualquier detalles existente
            dgvArticulos.Rows.Clear();

            // Obtener todos los detalles de esta factura
            // desde la tabla VentasDetalle
            DataRow filaMaestroActual = ds.Tables["VentasMaestro"].Rows[manejador.Position];
            DataRow[] filasDetalles = filaMaestroActual.GetChildRows("VMVD");

            // Ciclo para recorrer todas las filas
            // y agregarlas como detalles del DataGridView
            foreach (DataRow fila in filasDetalles)
            {
                // Primer columna: Clave
                int claveArticulo = Convert.ToInt32(fila["Articulo"]);

                // Segunda columna: Descripción
                // Se actualiza automáticamente debido al Binding establecido

                // Tercer columna: Cantidad
                int cantidad = Convert.ToInt32(fila["Cantidad"]);

                // Cuarta columna: Precio Unitario
                // Obtener la fila de la tabla Articulos
                // para obtener el precio correspondiente
                DataRow[] articulos = ds.Tables["Articulos"].Select( "Clave=" + claveArticulo.ToString());
                decimal precio = 0;
                if (articulos.Length == 1)
                {
                    // Determinar el tipo de cliente
                    if (cmbTipoCliente.SelectedIndex == 0)                          // Precio Menudeo
                        precio = Convert.ToDecimal(articulos[0]["PrecioMenudeo"]);
                    else if (cmbTipoCliente.SelectedIndex == 1)                     // Precio Medio Mayoreo
                        precio = Convert.ToDecimal(articulos[0]["PrecioMedioMayoreo"]);
                    else
                        precio = Convert.ToDecimal(articulos[0]["PrecioMayoreo"]);  // Precio Mayoreo
                }

                // Quinta columna: Importe
                decimal importe = cantidad * precio;

                // Agregar una fila al DataGridView
                dgvArticulos.Rows.Add(claveArticulo, claveArticulo, cantidad, precio, importe);
            }   // fin del ciclo

            // Totalizar la factura
            totalizar();
        }

        private void totalizar()
        {
            // Calcular subtotal, iva y total
            decimal subTotal = 0;

            for (int i = 0; i < dgvArticulos.Rows.Count; i++) 
            {
                int cantidad = Convert.ToInt32(dgvArticulos.Rows[i].Cells[2].Value);
                decimal precio = Convert.ToDecimal(dgvArticulos.Rows[i].Cells[3].Value);
                decimal importe = cantidad * precio;
                subTotal += importe;
            }

            // Calcular IVA y Total
            decimal IVA = (decimal)(Convert.ToDouble(subTotal) * 0.16);
            decimal totalVenta = subTotal + IVA;

            // Mostrar totales en el formulario
            txtSubTotal.Text = String.Format( "{0:$#,##0.00}", subTotal);
            txtIVA.Text = String.Format("{0:$#,##0.00}", IVA);
            txtTotal.Text = String.Format("{0:$#,##0.00}", totalVenta);
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            manejador.Position = 0;
            mostrarDetalles();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (manejador.Position != 0)
                manejador.Position--;
            mostrarDetalles();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (manejador.Position != manejador.Count - 1)
                manejador.Position++;
            mostrarDetalles();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            manejador.Position = manejador.Count - 1;
            mostrarDetalles();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            miManejadorPosicion = manejador.Position;
            establecerEstado(Estado.Agregar);

            // Borrar los detalles
            dgvArticulos.Rows.Clear();

            manejador.AddNew();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            establecerEstado(Estado.Modificar);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Guardar
            if (miEstado == Estado.Agregar)
            {
                // Calcular la nueva clave del artículo
                txtClave.Text = manejador.Count.ToString();
                // Actualizar el total de artículos
                txtTotalRegistros.Text = manejador.Count.ToString();
            }

            manejador.EndCurrentEdit();                         // Guardado Local
            daVentasMaestro.Update(ds.Tables["VentasMaestro"]); // Guardado en la Base de Datos

            // Guardar los detalles de la ventas
            eliminarDetalles();                                 // Eliminación local
            insertarDetalles();                                 // Inserción local
            daVentasDetalle.Update(ds.Tables["VentasDetalle"]); // Guardado en la Base de Datos

            establecerEstado(Estado.Ver);
            manejador.Refresh();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            manejador.CancelCurrentEdit();

            if (miEstado == Estado.Agregar)
                manejador.Position = miManejadorPosicion;

            establecerEstado(Estado.Ver);
            mostrarDetalles();
        }

        private void eliminarDetalles()
        {
            // Obtener todas las filas de la factura
            DataRow[] detalles = ds.Tables["VentasDetalle"].Select( "Factura=" + txtClave.Text);

            // Ciclo para eliminar todas las filas seleccionadas
            foreach (DataRow fila in detalles)
                fila.Delete();
        }

        private void insertarDetalles()
        {
            // Ciclo para todas las filas del DataGridView
            // Excepto la última
            for (int i = 0; i < dgvArticulos.Rows.Count - 1; i++)
            { 
                // Insertar nuevo renglón en la tabla VentasDetalle
                DataRow nuevo = ds.Tables["VentasDetalle"].NewRow();

                nuevo["Factura"] = Convert.ToInt32(txtClave.Text);
                nuevo["Consecutivo"] = i + 1;
                nuevo["Articulo"] = Convert.ToInt32(dgvArticulos.Rows[i].Cells[0].Value);
                nuevo["Cantidad"] = Convert.ToInt32(dgvArticulos.Rows[i].Cells[2].Value);

                ds.Tables["VentasDetalle"].Rows.Add(nuevo);
            }
        }

        private void dgvArticulos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Solo se puede modificar la columna 1 (Descripción)
            // o la columna 2 (Cantidad)

            if (e.ColumnIndex == 1)
            {
                // Se actualiza la Descripción

                DataGridViewComboBoxCell celda = (DataGridViewComboBoxCell)dgvArticulos.CurrentCell;

                // Validar que la celda sea diferente de null
                if (celda == null)
                    return;

                // Primera columna: Clave
                int claveArticulo = Convert.ToInt32(celda.Value);

                // Segunda columna: Descripción
                // Cambia automáticamente

                // Tercera columna: Cantidad
                int cantidad = Convert.ToInt32(dgvArticulos.Rows[e.RowIndex].Cells[2].Value);

                // Cuarta columna: Precio
                // Obtener la fila de la tabla Articulos
                // para obtener el precio correspondiente
                DataRow[] articulos = ds.Tables["Articulos"].Select("Clave=" + claveArticulo.ToString());
                decimal precio = 0;
                if (articulos.Length == 1)
                {
                    // Determinar el tipo de cliente
                    if (cmbTipoCliente.SelectedIndex == 0)                          // Precio Menudeo
                        precio = Convert.ToDecimal(articulos[0]["PrecioMenudeo"]);
                    else if (cmbTipoCliente.SelectedIndex == 1)                     // Precio Medio Mayoreo
                        precio = Convert.ToDecimal(articulos[0]["PrecioMedioMayoreo"]);
                    else
                        precio = Convert.ToDecimal(articulos[0]["PrecioMayoreo"]);  // Precio Mayoreo
                }

                // Quinta columna: Importe
                decimal importe = cantidad * precio;

                // Actualizar la clave, el precio y el importe en el DataGridView
                dgvArticulos.Rows[e.RowIndex].Cells[0].Value = claveArticulo;
                dgvArticulos.Rows[e.RowIndex].Cells[3].Value = precio;
                dgvArticulos.Rows[e.RowIndex].Cells[4].Value = importe;
            }
            else if ( e.ColumnIndex == 2)
            {
                // Se actualiza la cantidad

                DataGridViewTextBoxCell celda = (DataGridViewTextBoxCell)dgvArticulos.CurrentCell;

                // Validar que la celda sea diferente de null
                if (celda == null)
                    return;

                int cantidad = Convert.ToInt32(celda.Value);
                decimal precio = Convert.ToDecimal(dgvArticulos.Rows[e.RowIndex].Cells[3].Value);
                decimal importe = cantidad * precio;

                // Actualizar el importe en el DataGridView
                dgvArticulos.Rows[e.RowIndex].Cells[4].Value = importe;
            }

            totalizar();
        }

        private void dgvArticulos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Este método se ejecuta cada vez que se inicia
            // a editar cualquier celda del DataGridView

            // Validar que sea la columna 2: Cantidad
            if ( dgvArticulos.CurrentCell.ColumnIndex == 2 )
            {
                // Validar que el control no sea nulo
                if (e.Control == null)
                    return;

                e.Control.KeyPress -= new System.Windows.Forms.KeyPressEventHandler( soloDigitos );
                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(soloDigitos);
            }
        }

        private void soloDigitos(object sender, KeyPressEventArgs e)
        {
            // Validar solo dígitos
            if ((Char.IsDigit(e.KeyChar)) || (Char.IsControl(e.KeyChar)))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgvArticulos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            totalizar();
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            // Cambiar registro según el valor proporcionado
            if (e.KeyCode == Keys.Enter)
            {
                int nuevaPosicion = Convert.ToInt32(txtClave.Text);
                miManejadorPosicion = manejador.Position;
                manejador.CancelCurrentEdit();

                // Validar que el número se encuentre en el rango
                // de filas existentes
                if ((nuevaPosicion >= 1) && (nuevaPosicion <= manejador.Count))
                    manejador.Position = nuevaPosicion - 1;
                else
                    manejador.Position = miManejadorPosicion;

                txtClave.Text = (manejador.Position + 1).ToString();
                mostrarDetalles();
            }

        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            manejador.CancelCurrentEdit();
            txtClave.Text = (manejador.Position + 1).ToString();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Crear objeto PrintDocument para el manejo de la impresión
            PrintDocument pdFactura = new PrintDocument();

            // Nombre del documento en la cola de impresión
            pdFactura.DocumentName = "Facturación - Factura";

            // Agregar manejador de eventos para el método Print
            pdFactura.PrintPage += new PrintPageEventHandler(ImprimirFactura);

            // Sin usar PrintPreviewDialog
            // pdFactura.Print();

            // Crear objeto PrintPreviewDialog para mostrar el listado
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pdFactura;
            ppd.ShowDialog();

            // Eliminar componentes
            ppd.Dispose();
            pdFactura.Dispose();
        }

        // Manejador del evento PrintPage
        private void ImprimirFactura(object sender, PrintPageEventArgs e)
        {
            // Objetos a utilizar durante la impresión
            Font tipoLetra = new Font("Arial", 14, FontStyle.Bold);
            Brush brocha = new SolidBrush(Color.Black);
            Pen pluma = new Pen(Color.Black);

            // Obtener valores de la hoja donde se imprime
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            float anchoPagina = e.MarginBounds.Width;

            // Alto del tipo de letra
            float alturaLetra = tipoLetra.GetHeight(e.Graphics);

            // Rectangulo para centrar el encabezado en la página
            RectangleF rf = new RectangleF(x, y, anchoPagina, alturaLetra);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            String encabezado = "Empresa Particular S.A. de C.V";
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            // Imprimir segunda línea del encabezado
            y += alturaLetra;
            rf = new RectangleF(x, y, anchoPagina, alturaLetra);
            sf.Alignment = StringAlignment.Center;
            encabezado = "Sistema de Facturación V1.0";
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            // Imprimir tercer línea del encabezado
            y += (alturaLetra * 2.0F);
            rf = new RectangleF(x, y, anchoPagina, alturaLetra);
            encabezado = "F  A  C  T  U  R  A";
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            // Saltar de línea
            y += alturaLetra;

            Font tipoLetraBold = new Font("Arial", 10, FontStyle.Bold);
            Font tipoLetraRegular = new Font("Arial", 10, FontStyle.Regular);
            alturaLetra = tipoLetraBold.GetHeight(e.Graphics);

            // Imprimir folio y fecha
            x = e.MarginBounds.Left;

            encabezado = "Folio:";
            SizeF sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = String.Format("{0,5}", Convert.ToInt32(txtClave.Text));
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraRegular);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Far;
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            // Saltar de línea
            y += alturaLetra;

            x = e.MarginBounds.Left;
            encabezado = "Fecha:";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = String.Format("{0:dd/MM/yyyy}", dtpFecha.Value);
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraRegular);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Far;
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            // Saltar de línea
            y += alturaLetra;

            x = e.MarginBounds.Left;
            encabezado = "Cliente:";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = cmbCliente.Text;
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraRegular);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            // Saltar de línea
            y += alturaLetra;

            x = e.MarginBounds.Left;
            encabezado = "Representante legal:";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = txtRepresentanteLegal.Text;
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraRegular);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = "Dirección:";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = txtDireccion.Text;
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraRegular);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            // Saltar de línea
            y += alturaLetra;

            x = e.MarginBounds.Left;
            encabezado = "Ciudad:";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = txtCiudad.Text;
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraRegular);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = "Estado:";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = txtEstado.Text;
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraRegular);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = "Código Postal:";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = txtCodigoPostal.Text;
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraRegular);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            // Saltar de línea
            y += alturaLetra;

            x = e.MarginBounds.Left;
            encabezado = "Teléfono:";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = txtTelefono.Text;
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraRegular);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = "R.F.C.:";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = txtRFC.Text;
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraRegular);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = "Tipo Cliente:";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = cmbTipoCliente.Text;
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraRegular);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            // Saltar de línea
            y += alturaLetra;

            x = e.MarginBounds.Left;
            encabezado = "Condiciones de la venta:";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = cmbCondiciones.Text;
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraRegular);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = "Estatus:";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += sizeTexto.Width;
            encabezado = (chkActivo.Checked ? "ACTIVO": "C  A  N  C  E  L  A  D  O");
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraRegular);
            rf = new RectangleF(x, y, sizeTexto.Width, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            // Imprimir detalles de la venta
            // Dibujar línea para encabezados de columnas
            y += (alturaLetra * 2.0F);
            x = e.MarginBounds.Left;
            e.Graphics.DrawLine(pluma, x, y, x + anchoPagina, y);

            // Calcular el ancho de todos los encabezados
            int anchoEncabezados =
                                     5 +                    // Clave
                                    20 +                    // Descripción
                                     8 +                    // Cantidad
                                    15 +                    // Precio Unitario
                                    15;                     // Importe
            encabezado = new String('m', anchoEncabezados);
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            x = e.MarginBounds.Left;
            y += alturaLetra;

            encabezado = "Clave";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            float xClave = x;
            float anchoClave = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoClave, alturaLetra);
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            encabezado = new String('m', 20);
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            x += anchoClave;
            float xDescripcion = x;
            float anchoDescripcion = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoDescripcion, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            encabezado = "Descripción";
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            encabezado = "Cantidad";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            x += anchoDescripcion;
            float xCantidad = x;
            float anchoCantidad = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoCantidad, alturaLetra);
            sf.Alignment = StringAlignment.Far;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            encabezado = "Precio Unitario";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetraBold);
            x += anchoCantidad;
            float xPrecio = x;
            float anchoPrecio = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoPrecio, alturaLetra);
            sf.Alignment = StringAlignment.Far;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            encabezado = "Importe";
            x += anchoPrecio;
            float xImporte = x;
            float anchoImporte = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoImporte, alturaLetra);
            sf.Alignment = StringAlignment.Far;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            // Dibujar línea para encabezados de columnas
            y += alturaLetra;
            x = e.MarginBounds.Left;
            e.Graphics.DrawLine(pluma, x, y, x + anchoPagina, y);

            // Ciclo para mostrar los renglones del datagridview
            for (int i = 0; i < dgvArticulos.Rows.Count - 1; i++)
            {
                // Saltar de línea
                y += alturaLetra;

                // Clave
                int claveArticulo = Convert.ToInt32(dgvArticulos.Rows[i].Cells[0].Value);
                String detalle = String.Format("{0,5}", claveArticulo);
                x = xClave;
                rf = new RectangleF(x, y, anchoClave, alturaLetra);
                sf.Alignment = StringAlignment.Far;
                e.Graphics.DrawString(detalle, tipoLetraRegular, brocha, rf, sf);

                // Descripción
                detalle = Convert.ToString(dgvArticulos.Rows[i].Cells[1].FormattedValue);
                x = xDescripcion;
                rf = new RectangleF(x, y, anchoDescripcion, alturaLetra);
                sf.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(detalle, tipoLetraRegular, brocha, rf, sf);

                // Cantidad
                int cantidad = Convert.ToInt32(dgvArticulos.Rows[i].Cells[2].Value);
                detalle = String.Format("{0,5}", cantidad);
                x = xCantidad;
                rf = new RectangleF(x, y, anchoCantidad, alturaLetra);
                sf.Alignment = StringAlignment.Far;
                e.Graphics.DrawString(detalle, tipoLetraRegular, brocha, rf, sf);

                // Precio Unitario
                detalle = Convert.ToString(dgvArticulos.Rows[i].Cells[3].FormattedValue);
                x = xPrecio;
                rf = new RectangleF(x, y, anchoPrecio, alturaLetra);
                sf.Alignment = StringAlignment.Far;
                e.Graphics.DrawString(detalle, tipoLetraRegular, brocha, rf, sf);

                // Importe
                detalle = Convert.ToString(dgvArticulos.Rows[i].Cells[4].FormattedValue);
                x = xImporte;
                rf = new RectangleF(x, y, anchoImporte, alturaLetra);
                sf.Alignment = StringAlignment.Far;
                e.Graphics.DrawString(detalle, tipoLetraRegular, brocha, rf, sf);

            }

            y += alturaLetra;
            x = e.MarginBounds.Left;
            e.Graphics.DrawLine(pluma, x, y, x + anchoPagina, y);

            // Imprimir totales
            y += alturaLetra;
            x = xPrecio;
            encabezado = "SubTotal:";
            rf = new RectangleF(x, y, anchoPrecio, alturaLetra);
            sf.Alignment = StringAlignment.Far;
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += anchoPrecio;
            encabezado = txtSubTotal.Text;
            rf = new RectangleF(x, y, anchoImporte, alturaLetra);
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            y += alturaLetra;
            x = xPrecio;
            encabezado = "I.V.A.:";
            rf = new RectangleF(x, y, anchoPrecio, alturaLetra);
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += anchoPrecio;
            encabezado = txtIVA.Text;
            rf = new RectangleF(x, y, anchoImporte, alturaLetra);
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            y += alturaLetra;
            x = xPrecio;
            encabezado = "Total:";
            rf = new RectangleF(x, y, anchoPrecio, alturaLetra);
            e.Graphics.DrawString(encabezado, tipoLetraBold, brocha, rf, sf);

            x += anchoPrecio;
            encabezado = txtTotal.Text;
            rf = new RectangleF(x, y, anchoImporte, alturaLetra);
            e.Graphics.DrawString(encabezado, tipoLetraRegular, brocha, rf, sf);

            e.HasMorePages = false;
        }
    }
}
