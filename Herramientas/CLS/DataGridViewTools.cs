using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herramientas.CLS
{
    class DataGridViewTools
    {
        public static System.Data.DataTable DataGridView_A_DataTable(DataGridView pDatos )
        {
            System.Data.DataTable Resultado = new System.Data.DataTable();
            Object[] registro = new Object[pDatos.Columns.Count];
            Int32 Indice =0;

            foreach (DataGridViewColumn Columna in pDatos.Columns)
            {
                Resultado.Columns.Add(Columna.Name);
            }

            foreach (DataGridViewRow Fila in pDatos.Rows)
            {
                Indice = 0;
                foreach (DataGridViewCell Celda in Fila.Cells)
                {
                    registro[Indice] = Celda.Value;
                    Indice += 1;
                }
                Resultado.Rows.Add(registro);
            }

            return Resultado;
        }
    }
}
