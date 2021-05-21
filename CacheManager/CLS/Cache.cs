using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManager.CLS
{
    public static class Cache
    {
        public static DataTable INICIAR_SESION(String pUsuario,String pClave)
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionBD Consultor = new DataManager.CLS.OperacionBD();
            String Consulta= @"SELECT a.IDUsuario, a.Usuario, a.IDEmpleado,
            a.IDRol, CONCAT(b.Nombres,' ',b.Apellidos) Empleado, 
            c.Rol FROM usuarios a, empleados b, roles c 
            WHERE a.Usuario='"+pUsuario+ @"' 
            AND a.Clave=SHA1(MD5('"+pClave+ @"'))
            AND a.IDEmpleado=b.IDEmpleado
            AND a.IDRol=c.IDRol;";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }

        public static DataTable TODOS_LOS_ROLES()
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionBD Consultor = new DataManager.CLS.OperacionBD();
            String Consulta = @"SELECT IdRol, Rol FROM roles ORDER BY Rol;";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }

        public static DataTable PERMISOS_DE_UN_ROL(String pIDRol)
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionBD Consultor = new DataManager.CLS.OperacionBD();
            String Consulta = @"SELECT a.IDOpcion, a.Opcion,
            IF(IFNULL((SELECT IDPermiso FROM permisos z WHERE z.IDRol = " + pIDRol + @" AND z.IDOpcion = a.IDOpcion),0)=0,0,1) as Seleccion,
            IFNULL((SELECT IDPermiso FROM permisos z WHERE z.IDRol = " + pIDRol+ @" AND z.IDOpcion = a.IDOpcion),0) AS IDPermiso 
            FROM opciones a ORDER BY Opcion ASC ;";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }

        public static DataTable REPORTE_DE_PEDIDOS(String pFechaInicio, String pFechaFinal)
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionBD Consultor = new DataManager.CLS.OperacionBD();
            String Consulta = @"SELECT
            a.OrderID,
            a.OrderDate,
            a.CustomerID, (SELECT ContactName FROM northwind.customers z WHERE z.CustomerID = a.CustomerID) Customer,
            ROUND(SUM(b.Quantity*b.UnitPrice),2) Total
            FROM northwind.orders a, northwind.orderdetails b
            WHERE a.OrderID = b.OrderID AND OrderDate BETWEEN '" + pFechaInicio+"' AND '"+pFechaFinal+@"'
            GROUP BY b.OrderID;";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }

        public static DataTable PERMISOS_DE_UN_USUARIO(String pIDRol)
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionBD Consultor = new DataManager.CLS.OperacionBD();
            String Consulta = @"SELECT DISTINCT a.IDOpcion, b.Opcion
            FROM permisos a, Opciones b 
            WHERE a.IDOpcion = b.IDOpcion
            AND a.IDRol = "+pIDRol+";";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }

        public static DataTable REPORTE_DE_PEDIDOS_2(String pFechaInicio, String pFechaFinal)
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionBD Consultor = new DataManager.CLS.OperacionBD();
            String Consulta = @"SELECT
            a.OrderID,
            CAST(a.OrderDate AS CHAR) as OrderDate,
            a.CustomerID, (SELECT ContactName FROM northwind.customers z WHERE z.CustomerID = a.CustomerID) Customer,
            ROUND(SUM(b.Quantity*b.UnitPrice),2) Total
            FROM northwind.orders a, northwind.orderdetails b
            WHERE a.OrderID = b.OrderID AND OrderDate BETWEEN '" + pFechaInicio + "' AND '" + pFechaFinal + @"'
            GROUP BY b.OrderID;";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }
    }
}
