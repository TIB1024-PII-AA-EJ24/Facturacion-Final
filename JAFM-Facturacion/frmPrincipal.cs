using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JAFM_Facturacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void mnuAyuAce_Click(object sender, EventArgs e)
        {
            // Mostrar cuadro de diálogo
            // con los datos del autor del programa
            MessageBox.Show("Elaborado por:\nLic. Jaime A. Félix Medina",
                "Sistema de Facturación V1.0",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void mnuCatSal_Click(object sender, EventArgs e)
        {
            // Terminar la aplicación
            Application.Exit();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Preguntar si realmente desea salir
            DialogResult opcion = MessageBox.Show("¿Deseas salir?",
                            "Sistema de Facturación V1.0",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2);   // El botón 2 es la opción No

            if ( opcion != DialogResult.Yes )
                e.Cancel = true;
        }

        private void mnuCatArt_Click(object sender, EventArgs e)
        {
            // Mostrar el catálogo de artículos
            frmCatArt catArt = new frmCatArt();
            catArt.ShowDialog();
        }

        private void mnuCatCli_Click(object sender, EventArgs e)
        {
            // Mostrar el catálogo de clientes
            frmCatCli catCli = new frmCatCli();
            catCli.ShowDialog();
        }

        private void mnuProVen_Click(object sender, EventArgs e)
        {
            // Mostrar la opción de Ventas
            frmVentas ventas = new frmVentas();
            ventas.ShowDialog();
        }
    }
}
