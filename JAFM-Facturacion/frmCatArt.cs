using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JAFM_Facturacion
{
    // Tipo de dato para el estado del formulario
    enum Estado { Agregar, Modificar, Ver }

    public partial class frmCatArt : Form
    {
        // Variables globales
        SqlDataAdapter da;              // Adaptador entre BD y Aplicación
        DataTable dt;                   // Tabla local
        CurrencyManager manejador;      // Administrador de navegación
        int miManejadorPosicion = 0;    // Posición actual del administrador
        Estado miEstado;                // Estado actual del formulario
        int numeroPagina = 0;           // El número de la página del listado


        public frmCatArt()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cerrar catálogo
            this.Close();
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar únicamente dígitos
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void chkOtro_CheckedChanged(object sender, EventArgs e)
        {
            txtEspecificar.ReadOnly = !chkOtro.Checked;
        }

        private void ValidarFracciones(object sender, KeyPressEventArgs e)
        {
            // Validar sólo digitos y un punto decimal
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if ( (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') < 0 ) )
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void NumeroAMoneda(object sender, EventArgs e)
        {
            // Si el campo está vacío, asignarle 0
            if ((sender as TextBox).Text == "")
                (sender as TextBox).Text = "0.00";

            // Dar formato de moneda
            (sender as TextBox).Text = String.Format("{0:$#,##0.00}",
                                        Double.Parse((sender as TextBox).Text));
        }

        private void MonedaANumero(object sender, EventArgs e)
        {
            // Quitar el formato de moneda
            double valorOriginal = Double.Parse((sender as TextBox).Text,
                            System.Globalization.NumberStyles.Currency);

            (sender as TextBox).Text = String.Format("{0:0.00}", valorOriginal );

            // Poner cursor al final del textbox
            (sender as TextBox).Select(0, (sender as TextBox).Text.Length);
        }

        private void frmCatArt_Load(object sender, EventArgs e)
        {
            // Cadena de conexión a la base de datos
            String conexion = "Data Source=(local);Initial Catalog=Aplicacion;Persist Security Info=true;User ID=pDos;Password=pDos";

            // Cadena para seleccionar los datos
            String seleccion = "SELECT * FROM Articulos";

            // Crear adaptadpr que comunica el manejador de la base de datos
            // con mi aplicación
            da = new SqlDataAdapter(seleccion,conexion);

            // Crear el comando Update
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
            da.UpdateCommand = cmdBuilder.GetUpdateCommand();

            // Crear objeto DataTable
            dt = new DataTable();

            // Llenar la tabla con los datos de la BD
            da.Fill(dt);

            // Definir los valores por omisión (default) de las columnas
            // a enlazar con las casillas de verificación
            // Obligatorio para que funcione el método AddNew()
            dt.Columns["Windows"].DefaultValue = false;
            dt.Columns["Macintosh"].DefaultValue = false;
            dt.Columns["Linux"].DefaultValue = false;
            dt.Columns["Otro"].DefaultValue = false;
            dt.Columns["Activo"].DefaultValue = true;
            dt.Columns["Tipo"].DefaultValue = "H";
            dt.Columns["PrecioMenudeo"].DefaultValue = 0.00;
            dt.Columns["PrecioMedioMayoreo"].DefaultValue = 0.00;
            dt.Columns["PrecioMayoreo"].DefaultValue = 0.00;


            // Enlazar los componentes de la interfaz de usuario
            txtClave.DataBindings.Add( "Text", dt, "Clave" );
            txtNombre.DataBindings.Add( "Text", dt, "Nombre" );
            txtDescripcion.DataBindings.Add("Text", dt, "Descripcion");
            txtMarca.DataBindings.Add("Text", dt, "Marca");

            Binding bHardware = new Binding( "Checked", dt, "Tipo" );
            // Eventos Format (BD -> Componente) y Parse (Componente -> BD)
            bHardware.Format += new ConvertEventHandler(CaracterABoolean);
            bHardware.Parse += new ConvertEventHandler(BooleanACaracter);
            rbHardware.DataBindings.Add( bHardware );

            Binding bSoftware = new Binding("Checked", dt, "Tipo");
            // Eventos Format (BD -> Componente) y Parse (Componente -> BD)
            bSoftware.Format += new ConvertEventHandler(CaracterABoolean);
            bSoftware.Parse += new ConvertEventHandler(BooleanACaracter);
            rbSoftware.DataBindings.Add( bSoftware );

            chkWindows.DataBindings.Add( "Checked", dt, "Windows" );
            chkMacintosh.DataBindings.Add( "Checked", dt, "Macintosh" );
            chkLinux.DataBindings.Add( "Checked", dt, "Linux" );
            chkOtro.DataBindings.Add( "Checked", dt, "Otro" );
            txtEspecificar.DataBindings.Add( "Text", dt, "Especificar" );

            Binding bMenudeo = new Binding( "Text", dt, "PrecioMenudeo");
            // Eventos Format (BD -> Componente) y Parse (Componente -> BD)
            bMenudeo.Format += new ConvertEventHandler(DecimalAStringMoneda);
            bMenudeo.Parse += new ConvertEventHandler(StringMonedaADecimal);
            txtPMenudeo.DataBindings.Add(bMenudeo);

            Binding bMedioMayoreo = new Binding("Text", dt, "PrecioMedioMayoreo");
            // Eventos Format (BD -> Componente) y Parse (Componente -> BD)
            bMedioMayoreo.Format += new ConvertEventHandler(DecimalAStringMoneda);
            bMedioMayoreo.Parse += new ConvertEventHandler(StringMonedaADecimal);
            txtPMedioMay.DataBindings.Add(bMedioMayoreo);

            Binding bMayoreo = new Binding("Text", dt, "PrecioMayoreo");
            // Eventos Format (BD -> Componente) y Parse (Componente -> BD)
            bMayoreo.Format += new ConvertEventHandler(DecimalAStringMoneda);
            bMayoreo.Parse += new ConvertEventHandler(StringMonedaADecimal);
            txtPMayoreo.DataBindings.Add(bMayoreo);

            chkActivo.DataBindings.Add( "Checked", dt, "Activo" );

            
            // Relacionar el manejador del enlace con la tabla
            manejador = (CurrencyManager)this.BindingContext[dt];

            // Establecer el total de registros
            txtTotalRegistros.Text = manejador.Count.ToString();

            // Establecer el estado en modo Ver
            establecerEstado(Estado.Ver);
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

        // Métodos Format y Parse
        private void CaracterABoolean(Object sender, ConvertEventArgs cEA)
        {
            // Verificar que sea el tipo deseado
            if (cEA.DesiredType != typeof(bool))
                return;

            bool valor = false;

            String cual = ((Binding) sender).Control.Text;

            if (cual.Equals("&Hardware"))
                valor = true;

            if (cEA.Value.ToString().Equals("H"))
                cEA.Value = valor;
            else
                cEA.Value = !valor;
        }

        private void BooleanACaracter(object sender, ConvertEventArgs cEA)
        { 
            // Verificar que sea el tipo deseado String
            if ( cEA.DesiredType != typeof(String) )
                return;

            String valor1 = "S";
            String valor2 = "H";

            String cual = ((Binding)sender).Control.Text;

            if (cual.Equals("&Hardware"))
            {
                valor1 = "H";
                valor2 = "S";
            }

            if ((bool)cEA.Value)
                cEA.Value = valor1;
            else
                cEA.Value = valor2;
        }

        private void DecimalAStringMoneda(object sender, ConvertEventArgs cEA)
        {
            // Verificar que sea el tipo deseado String
            if (cEA.DesiredType != typeof(String))
                return;

            // Utilizar el método format para dar formato al valor como moneda
            cEA.Value = String.Format( "{0:$#,##0.00}", (decimal) cEA.Value );
        }

        private void StringMonedaADecimal(object sender, ConvertEventArgs cEA)
        {
            // Verificar que sea el tipo deseado decimal
            if (cEA.DesiredType != typeof(decimal))
                return;

            // Utilizar el método Parse para quitar el formato de moneda
            cEA.Value = 
                        Decimal.Parse(cEA.Value.ToString(),
                            System.Globalization.NumberStyles.Currency);
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            manejador.Position = 0;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (manejador.Position != 0)
                manejador.Position--;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (manejador.Position != manejador.Count - 1)
                manejador.Position++;
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            manejador.Position = manejador.Count - 1;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            establecerEstado(Estado.Modificar);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            manejador.CancelCurrentEdit();

            if (miEstado == Estado.Agregar)
                manejador.Position = miManejadorPosicion;

            establecerEstado(Estado.Ver);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar los campos de Nombre, Descripción y Marca
            if (txtNombre.Text == "")
            {
                MessageBox.Show( "Error. Se debe proporcionar un nombre", "Facturación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error );
                
                txtNombre.Focus();
                
                return;
            }

            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Error. Se debe proporcionar una descripción", "Facturación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtDescripcion.Focus();

                return;
            }

            if (txtMarca.Text == "")
            {
                MessageBox.Show("Error. Se debe proporcionar una marca", "Facturación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtMarca.Focus();

                return;
            }

            // Guardar
            if (miEstado == Estado.Agregar)
            { 
                // Calcular la nueva clave del artículo
                txtClave.Text = manejador.Count.ToString();
                // Actualizar el total de artículos
                txtTotalRegistros.Text = manejador.Count.ToString();
            }

            manejador.EndCurrentEdit();         // Guardado Local
            da.Update(dt);                      // Guardado en la Base de Datos
            establecerEstado(Estado.Ver);
            manejador.Refresh();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            miManejadorPosicion = manejador.Position;
            establecerEstado(Estado.Agregar);
            manejador.AddNew();
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            // Cambiar registro según el valor proporcionado
            if ( e.KeyCode == Keys.Enter)
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
            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            manejador.CancelCurrentEdit();
            txtClave.Text = (manejador.Position + 1).ToString();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Inicializar el número de página
            numeroPagina = 1;

            // Crear objeto PrintDocument para el manejo de la impresión
            PrintDocument pdArticulos = new PrintDocument();

            // Nombre del documento en la cola de impresión
            pdArticulos.DocumentName = "Facturación - Catálogo de Artículos";

            // Agregar manejador de eventos para el método Print
            pdArticulos.PrintPage += new PrintPageEventHandler(ImprimirCatalogoArticulos);

            // Sin usar PrintPreviewDialog
            // pdArticulos.Print();

            // Crear objeto PrintPreviewDialog para mostrar el listado
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pdArticulos;
            ppd.ShowDialog();

            // Eliminar componentes
            ppd.Dispose();
            pdArticulos.Dispose();
        }

        // Manejador del evento PrintPage
        private void ImprimirCatalogoArticulos(object sender, PrintPageEventArgs e)
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
            RectangleF rf = new RectangleF(x,y,anchoPagina, alturaLetra);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            String encabezado = "Empresa Particular S.A. de C.V";
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            // Imprimir número de página
            encabezado = String.Format("Página: {0,3}", numeroPagina);
            sf.Alignment = StringAlignment.Far;
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
            encabezado = "Listado del Catálogo de Artículos";
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            // Dibujar línea para encabezados de columnas
            y += alturaLetra;
            e.Graphics.DrawLine(pluma, x, y, x + anchoPagina, y);

            // Poner los encabezados de las columnas
            tipoLetra = new Font("Arial", 8, FontStyle.Regular);
            alturaLetra = tipoLetra.GetHeight(e.Graphics);

            encabezado = "Clave";
            SizeF sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetra);
            x = e.MarginBounds.Left;
            float xClave = x;
            float anchoClave = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoClave, alturaLetra);
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            encabezado = new String('m', 20);
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetra);
            x += anchoClave;
            float xNombre = x;
            float anchoNombre = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoNombre, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            encabezado = "Nombre";
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            encabezado = new String('m',50);
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetra);
            x += anchoNombre;
            float xDescripcion = x;
            float anchoDescripcion = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoDescripcion, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            encabezado = "Descripción";
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            // Segundo renglón del encabezado
            y += alturaLetra;
            encabezado = new String('m', 20);
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetra);
            x = xNombre;
            float xMarca = x;
            float anchoMarca = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoMarca, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            encabezado = "Marca";
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            encabezado = new String('m', 8);
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetra);
            x += anchoMarca;
            float xTipo = x;
            float anchoTipo = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoTipo, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            encabezado = "Tipo";
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            encabezado = "Windows";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetra);
            x += anchoTipo;
            float xWindows = x;
            float anchoWindows = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoWindows, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            encabezado = "Macintosh";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetra);
            x += anchoWindows;
            float xMacintosh = x;
            float anchoMacintosh = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoMacintosh, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            encabezado = "Linux";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetra);
            x += anchoMacintosh;
            float xLinux = x;
            float anchoLinux = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoLinux, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            encabezado = "Otro";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetra);
            x += anchoLinux;
            float xOtro = x;
            float anchoOtro = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoOtro, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            encabezado = "Especificar";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetra);
            x += anchoOtro;
            float xEspecificar = x;
            float anchoEspecificar = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoEspecificar, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            // Tercer renglón del encabezado
            y += alturaLetra;

            encabezado = "Precio Menudeo";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetra);
            x = xNombre;
            float xPMenudeo = x;
            float anchoPMenudeo = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoPMenudeo, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            encabezado = "Precio Medio Mayoreo";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetra);
            x += anchoPMenudeo;
            float xPMedMayoreo = x;
            float anchoPMedMayoreo = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoPMedMayoreo, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            encabezado = "Precio Mayoreo";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetra);
            x += anchoPMedMayoreo;
            float xPMayoreo = x;
            float anchoPMayoreo = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoPMayoreo, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            encabezado = "Activo";
            sizeTexto = e.Graphics.MeasureString(encabezado, tipoLetra);
            x += anchoPMayoreo;
            float xActivo = x;
            float anchoActivo = sizeTexto.Width;
            rf = new RectangleF(x, y, anchoActivo, alturaLetra);
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(encabezado, tipoLetra, brocha, rf, sf);

            // Dibujar línea para encabezados de columnas
            y += alturaLetra;
            x = e.MarginBounds.Left;
            e.Graphics.DrawLine(pluma, x, y, x + anchoPagina, y);

            // Calcular el número de artículos que caben en la página
            y += alturaLetra;
            float numeroArticulos = (e.MarginBounds.Bottom - y) / (alturaLetra * 3);

            // Calcular el rango de artículos a imprimir
            // dependiendo del número de la página
            int inicioFila = (int) numeroArticulos * (numeroPagina - 1);
            int finalFila = inicioFila + (int)numeroArticulos;

            // Verificar no sobrepasar el total de artículos de la tabla
            if (finalFila > dt.Rows.Count)
            { 
                finalFila = dt.Rows.Count;
                e.HasMorePages = false;
            }
            else
                e.HasMorePages = true;

            // Ciclo para imprimir todos los artículos de la página
            for (int i = inicioFila; i < finalFila; i++)
            {
                // Salto de línea
                y += alturaLetra;

                // Clave
                int claveArticulo = Convert.ToInt32(dt.Rows[i][0]);
                String detalle = String.Format("{0,5}", claveArticulo);
                x = xClave;
                rf = new RectangleF(x, y, anchoClave, alturaLetra);
                sf.Alignment = StringAlignment.Far;
                e.Graphics.DrawString(detalle, tipoLetra, brocha, rf, sf);

                // Nombre
                detalle = Convert.ToString(dt.Rows[i][1]);
                x = xNombre;
                rf = new RectangleF(x, y, anchoNombre, alturaLetra);
                sf.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(detalle, tipoLetra, brocha, rf, sf);

                // Descripción
                detalle = Convert.ToString(dt.Rows[i][2]);
                x = xDescripcion;
                rf = new RectangleF(x, y, anchoDescripcion, alturaLetra);
                sf.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(detalle, tipoLetra, brocha, rf, sf);

                // Segunda línea
                y += alturaLetra;

                // Marca
                detalle = Convert.ToString(dt.Rows[i][3]);
                x = xMarca;
                rf = new RectangleF(x, y, anchoMarca, alturaLetra);
                sf.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(detalle, tipoLetra, brocha, rf, sf);

                // Tipo
                // H -> Hardware, S -> Software
                detalle = Convert.ToString(dt.Rows[i][4]);
                if (detalle.Equals("H"))
                    detalle = "Hardware";
                else
                    detalle = "Software";
                x = xTipo;
                rf = new RectangleF(x, y, anchoTipo, alturaLetra);
                sf.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(detalle, tipoLetra, brocha, rf, sf);

                // Windows
                bool sisOp = Convert.ToBoolean(dt.Rows[i][5]);
                if (sisOp)
                    detalle = "Si";
                else
                    detalle = "No";
                x = xWindows;
                rf = new RectangleF(x, y, anchoWindows, alturaLetra);
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(detalle, tipoLetra, brocha, rf, sf);

                // Macintosh
                sisOp = Convert.ToBoolean(dt.Rows[i][6]);
                if (sisOp)
                    detalle = "Si";
                else
                    detalle = "No";
                x = xMacintosh;
                rf = new RectangleF(x, y, anchoMacintosh, alturaLetra);
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(detalle, tipoLetra, brocha, rf, sf);

                // Linux
                sisOp = Convert.ToBoolean(dt.Rows[i][7]);
                if (sisOp)
                    detalle = "Si";
                else
                    detalle = "No";
                x = xLinux;
                rf = new RectangleF(x, y, anchoLinux, alturaLetra);
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(detalle, tipoLetra, brocha, rf, sf);

                // Otro
                sisOp = Convert.ToBoolean(dt.Rows[i][8]);
                if (sisOp)
                    detalle = "Si";
                else
                    detalle = "No";
                x = xOtro;
                rf = new RectangleF(x, y, anchoOtro, alturaLetra);
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(detalle, tipoLetra, brocha, rf, sf);

                // Especificar
                detalle = Convert.ToString(dt.Rows[i][9]);
                x = xEspecificar;
                rf = new RectangleF(x, y, anchoEspecificar, alturaLetra);
                sf.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(detalle, tipoLetra, brocha, rf, sf);

                // Tercer línea
                y += alturaLetra;

                // Precio Menudeo
                double precio = Convert.ToDouble(dt.Rows[i][10]);
                detalle = String.Format("{0:$#,##0.00}", precio);
                x = xPMenudeo;
                rf = new RectangleF(x, y, anchoPMenudeo, alturaLetra);
                sf.Alignment = StringAlignment.Far;
                e.Graphics.DrawString(detalle, tipoLetra, brocha, rf, sf);

                // Precio Medio Mayoreo
                precio = Convert.ToDouble(dt.Rows[i][11]);
                detalle = String.Format("{0:$#,##0.00}", precio);
                x = xPMedMayoreo;
                rf = new RectangleF(x, y, anchoPMedMayoreo, alturaLetra);
                sf.Alignment = StringAlignment.Far;
                e.Graphics.DrawString(detalle, tipoLetra, brocha, rf, sf);

                // Precio Mayoreo
                precio = Convert.ToDouble(dt.Rows[i][12]);
                detalle = String.Format("{0:$#,##0.00}", precio);
                x = xPMayoreo;
                rf = new RectangleF(x, y, anchoPMayoreo, alturaLetra);
                sf.Alignment = StringAlignment.Far;
                e.Graphics.DrawString(detalle, tipoLetra, brocha, rf, sf);

                // Activo
                bool status = Convert.ToBoolean(dt.Rows[i][13]);
                if (status)
                    detalle = "Si";
                else
                    detalle = "No";
                x = xActivo;
                rf = new RectangleF(x, y, anchoActivo, alturaLetra);
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(detalle, tipoLetra, brocha, rf, sf);

            }
        }
    }
}
