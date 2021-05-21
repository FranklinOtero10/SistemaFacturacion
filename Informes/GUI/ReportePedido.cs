using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informes.GUI
{
    public partial class ReportePedido : Form
    {
        public ReportePedido()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            DataTable Datos = new DataTable();
            Datos = CacheManager.CLS.Cache.REPORTE_DE_PEDIDOS(dtpFechaInicio.Text, dtpFechaFinal.Text);
            REP.Pedidos Reportes = new REP.Pedidos();
            Reportes.SetDataSource(Datos);
            crvVisor.ReportSource = Reportes;
        }
    }
}
