using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orion.GUI
{
    public partial class Principal : Form
    {
        SesionManager.CLS.Sesion oSesion = SesionManager.CLS.Sesion.Instancia;
        public Principal()
        {
            InitializeComponent();
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataManager.GUI.Prueba f = new DataManager.GUI.Prueba();
            f.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = oSesion.Usuario;

        }

        private void rolesDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (oSesion.ComprobarPermisos(3))
                {
                    General.GUI.RolesGestion f = new General.GUI.RolesGestion();
                    f.MdiParent = this;
                    f.Show();
                }
            }catch
            {

            }
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                General.GUI.PermisosEdicion f = new General.GUI.PermisosEdicion();
                f.MdiParent = this;
                f.Show();
                oSesion.CargarPermisos();
            }
            catch
            {

            }
        }

        private void reporteDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (oSesion.ComprobarPermisos(6))
                {
                    Informes.GUI.ReportePedido f = new Informes.GUI.ReportePedido();
                    f.MdiParent = this;
                    f.Show();
                }
            }
            catch
            {

            }
        }

        private void recargarPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oSesion.CargarPermisos();
        }

        private void gestiónDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Facturacion.GUI.VentasGestion f = new Facturacion.GUI.VentasGestion();
                f.MdiParent = this;
                f.Show();
            }
            catch
            {
            }
        }

        private void pruebasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Herramientas.GUI.Prueba f = new Herramientas.GUI.Prueba();
                f.MdiParent = this;
                f.Show();
            }
            catch
            {
            }
        }
    }
}
