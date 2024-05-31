namespace JAFM_Facturacion
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuCatalogos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCatArt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCatCli = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCatSal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcesos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProVen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAyuAce = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCatalogos,
            this.mnuProcesos,
            this.mnuAyuda});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(800, 33);
            this.mnuPrincipal.TabIndex = 0;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // mnuCatalogos
            // 
            this.mnuCatalogos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCatArt,
            this.mnuCatCli,
            this.toolStripMenuItem1,
            this.mnuCatSal});
            this.mnuCatalogos.Name = "mnuCatalogos";
            this.mnuCatalogos.Size = new System.Drawing.Size(108, 29);
            this.mnuCatalogos.Text = "&Catálogos";
            // 
            // mnuCatArt
            // 
            this.mnuCatArt.Name = "mnuCatArt";
            this.mnuCatArt.Size = new System.Drawing.Size(212, 34);
            this.mnuCatArt.Text = "&Artículos";
            this.mnuCatArt.Click += new System.EventHandler(this.mnuCatArt_Click);
            // 
            // mnuCatCli
            // 
            this.mnuCatCli.Name = "mnuCatCli";
            this.mnuCatCli.Size = new System.Drawing.Size(212, 34);
            this.mnuCatCli.Text = "C&lientes";
            this.mnuCatCli.Click += new System.EventHandler(this.mnuCatCli_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(209, 6);
            // 
            // mnuCatSal
            // 
            this.mnuCatSal.Name = "mnuCatSal";
            this.mnuCatSal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuCatSal.Size = new System.Drawing.Size(212, 34);
            this.mnuCatSal.Text = "&Salir";
            this.mnuCatSal.Click += new System.EventHandler(this.mnuCatSal_Click);
            // 
            // mnuProcesos
            // 
            this.mnuProcesos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProVen});
            this.mnuProcesos.Name = "mnuProcesos";
            this.mnuProcesos.Size = new System.Drawing.Size(99, 29);
            this.mnuProcesos.Text = "&Procesos";
            // 
            // mnuProVen
            // 
            this.mnuProVen.Name = "mnuProVen";
            this.mnuProVen.Size = new System.Drawing.Size(270, 34);
            this.mnuProVen.Text = "&Ventas";
            this.mnuProVen.Click += new System.EventHandler(this.mnuProVen_Click);
            // 
            // mnuAyuda
            // 
            this.mnuAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAyuAce});
            this.mnuAyuda.Name = "mnuAyuda";
            this.mnuAyuda.Size = new System.Drawing.Size(79, 29);
            this.mnuAyuda.Text = "Ay&uda";
            // 
            // mnuAyuAce
            // 
            this.mnuAyuAce.Name = "mnuAyuAce";
            this.mnuAyuAce.Size = new System.Drawing.Size(208, 34);
            this.mnuAyuAce.Text = "&Acerca de ...";
            this.mnuAyuAce.Click += new System.EventHandler(this.mnuAyuAce_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mnuPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuPrincipal;
            this.Name = "frmPrincipal";
            this.Text = "Facturación V1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuCatalogos;
        private System.Windows.Forms.ToolStripMenuItem mnuCatArt;
        private System.Windows.Forms.ToolStripMenuItem mnuCatCli;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuCatSal;
        private System.Windows.Forms.ToolStripMenuItem mnuProcesos;
        private System.Windows.Forms.ToolStripMenuItem mnuProVen;
        private System.Windows.Forms.ToolStripMenuItem mnuAyuda;
        private System.Windows.Forms.ToolStripMenuItem mnuAyuAce;
    }
}

