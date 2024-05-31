using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JAFM_Facturacion
{
    public partial class frmCatCli : Form
    {
        // Variables globales
        SqlDataAdapter da;              // Adaptador entre BD y Aplicación
        DataTable dt;                   // Tabla local
        CurrencyManager manejador;      // Administrador de navegación
        int miManejadorPosicion = 0;    // Posición actual del administrador
        Estado miEstado;                // Estado actual del formulario

        public frmCatCli()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar únicamente dígitos
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar únicamente dígitos
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void frmCatCli_Load(object sender, EventArgs e)
        {
            // Seleccionar el primer elemento de la lista
            lstTipoCliente.SelectedIndex = 0;

            // Cadena de conexión a la base de datos
            String conexion = "Data Source=(local);Initial Catalog=Aplicacion;Persist Security Info=true;User ID=pDos;Password=pDos";

            // Cadena para seleccionar los datos
            String seleccion = "SELECT * FROM Clientes";

            // Crear adaptadpr que comunica el manejador de la base de datos
            // con mi aplicación
            da = new SqlDataAdapter(seleccion, conexion);

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
            dt.Columns["TipoCliente"].DefaultValue = 0;
            dt.Columns["Activo"].DefaultValue = true;

            // Enlazar los componentes de la interfaz de usuario
            txtClave.DataBindings.Add("Text", dt, "Clave");
            txtNombre.DataBindings.Add("Text", dt, "Nombre");
            txtRepresentanteLegal.DataBindings.Add( "Text", dt, "RepresentanteLegal");
            txtDireccion.DataBindings.Add("Text", dt, "Direccion");
            txtCiudad.DataBindings.Add( "Text", dt, "Ciudad");
            txtEstado.DataBindings.Add( "Text", dt, "Estado");
            txtCodigoPostal.DataBindings.Add( "Text", dt, "CodigoPostal" );
            txtTelefono.DataBindings.Add("Text", dt, "Telefono");
            txtRFC.DataBindings.Add( "Text", dt, "RFC" );
            lstTipoCliente.DataBindings.Add( "SelectedIndex", dt, "TipoCliente" );
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
            // Validar los campos de Nombre y Dirección
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Error. Se debe proporcionar un nombre", "Facturación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtNombre.Focus();

                return;
            }

            if (txtDireccion.Text == "")
            {
                MessageBox.Show("Error. Se debe proporcionar una dirección", "Facturación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtDireccion.Focus();

                return;
            }

            // Guardar
            if (miEstado == Estado.Agregar)
            {
                // Calcular la nueva clave del cliente
                txtClave.Text = manejador.Count.ToString();
                // Actualizar el total de clientes
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
            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            manejador.CancelCurrentEdit();
            txtClave.Text = (manejador.Position + 1).ToString();
        }
    }
}
