using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herramientas.GUI
{
    public partial class Prueba : Form
    {
        public Prueba()
        {
            InitializeComponent();
        }

        private void btnExportador_Click(object sender, EventArgs e)
        {
            CLS.Exportador.Exportar(CacheManager.CLS.Cache.REPORTE_DE_PEDIDOS_2("1996-01-01","1998-12-31"));
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dtgDatos.DataSource = CacheManager.CLS.Cache.REPORTE_DE_PEDIDOS_2("1996-01-01", "1998-12-31");
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            CLS.Exportador.Exportar(CLS.DataGridViewTools.DataGridView_A_DataTable(dtgDatos));
        }
    }
}
