using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Herramientas.CLS
{
    class Exportador
    {
        public static Boolean Exportar(System.Data.DataTable pDatos)
        {
            Boolean Resultado = false;
            Application Proceso;
            Workbook Libro;
            Workbooks Libros;
            Worksheet Hoja;
            Sheets Hojas;
            Range Rango;
            Int32 nColumnas = 0;
            Int32 PosColumna = 0;
            Int32 PosFila = 0;
            Int32 nFilas = 0;

            try
            {
                //Inicializacion de variables
                Proceso = new Application();
                Libros = Proceso.Workbooks;
                Libro = Libros.Add(Missing.Value);
                Hojas = Libro.Worksheets;
                Hoja = Hojas.Item[1];
                //
                nColumnas = pDatos.Columns.Count;
                nFilas = pDatos.Rows.Count;

                if (nColumnas>0 && nFilas>0)
                {
                    Rango = Hoja.get_Range("A1", Missing.Value);
                    Rango = Rango.get_Resize(nFilas,nColumnas);
                    PosColumna = 1;

                    foreach (System.Data.DataColumn Columna  in pDatos.Columns)
                    {
                        Hoja.Cells[1, PosColumna] = Columna.Caption.ToString();
                        PosColumna += 1;
                    }

                    PosFila = 2;
                    foreach (System.Data.DataRow fila in pDatos.Rows)
                    {
                        PosColumna = 1;
                        foreach (System.Data.DataColumn Columna in pDatos.Columns)
                        {
                            Hoja.Cells[PosFila, PosColumna] = fila[Columna].ToString();
                            PosColumna += 1;
                        }
                        PosFila += 1;
                    }

                    Rango = Rango.get_Resize(nFilas+1,nColumnas);
                    Rango.Name = "Datos";
                    Proceso.Visible = true;
                    Proceso.UserControl = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }

            return Resultado;
        }
    }
}
