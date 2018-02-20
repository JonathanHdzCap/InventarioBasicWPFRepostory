using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using CapaEnlaceDatos;
using System.Windows;

namespace CapaLogicaNegocio
{
    public class clsProducto
    {
        private clsManejador M = new clsManejador();

        private Int32 m_IdP;
        private Int32 m_IdCategoria;
        private String m_Producto;
        private String m_Marca;
        private Int32 m_Stock;
        private Decimal m_PrecioCompra;
        private Decimal m_PrecioVenta;
        private DateTime m_FechaVencimiento;

        public Int32 IdP
        {
            get { return m_IdP; }
            set { m_IdP = value; }
        }

        public Int32 IdCategoria
        {
            get { return m_IdCategoria; }
            set { m_IdCategoria = value; }
        }

        public String Producto
        {
            get { return m_Producto; }
            set { m_Producto = value; }
        }

        public String Marca
        {
            get { return m_Marca; }
            set { m_Marca = value; }
        }

        public Int32 Stock
        {
            get { return m_Stock; }
            set { m_Stock = value; }
        }

        public Decimal PrecioCompra
        {
            get { return m_PrecioCompra; }
            set { m_PrecioCompra = value; }
        }

        public Decimal PrecioVenta
        {
            get { return m_PrecioVenta; }
            set { m_PrecioVenta = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return m_FechaVencimiento; }
            set { m_FechaVencimiento = value; }
        }

        public List<clsProducto> Listar()
        {
            DataTable dt = M.Listado("ListadoProductos", null);
            List<clsProducto> list = new List<clsProducto>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsProducto objTemp = new clsProducto();

                    objTemp.IdP = Int32.Parse(dt.Rows[i][0].ToString());
                    objTemp.IdCategoria = Int32.Parse(dt.Rows[i][1].ToString());
                    objTemp.Producto = dt.Rows[i][2] != null ? dt.Rows[i][2].ToString() : "";
                    objTemp.Marca = dt.Rows[i][3] != null ? dt.Rows[i][3].ToString() : "";                    
                    objTemp.PrecioCompra = dt.Rows[i][4] != null ? Decimal.Parse(dt.Rows[i][4].ToString()) : 0;
                    objTemp.PrecioVenta = dt.Rows[i][5] != null ? Decimal.Parse(dt.Rows[i][5].ToString()) : 0;
                    objTemp.Stock = dt.Rows[i][6] != null ? Int32.Parse(dt.Rows[i][6].ToString()) : 0;
                    objTemp.FechaVencimiento = DateTime.Parse(dt.Rows[i][7].ToString());
                    list.Add(objTemp);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede convertir Productos a Entidad",ex);
            }
            return list;
        }

        public DataTable BusquedaProductos(String objDatos)
        {
            DataTable dt = new DataTable();
            List<clsParametro> lst = new List<clsParametro>();
            try
            {
                lst.Add(new clsParametro("@Datos", objDatos));
                dt = M.Listado("FiltrarDatosProducto", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public String RegistrarProductos()
        {
            List<clsParametro> lst = new List<clsParametro>();
            String Mensaje = "";

            try
            {
                lst.Add(new clsParametro("@IdCategoria", m_IdCategoria));
                lst.Add(new clsParametro("@Nombre", m_Producto));
                lst.Add(new clsParametro("@Marca", m_Marca));
                lst.Add(new clsParametro("@Stock", m_Stock));
                lst.Add(new clsParametro("@PrecioCompra", m_PrecioCompra));
                lst.Add(new clsParametro("@PrecioVenta", m_PrecioVenta));
                lst.Add(new clsParametro("@FechaVencimiento", m_FechaVencimiento));
                lst.Add(new clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarProducto", ref lst);
                Mensaje = lst[7].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String ActualizarProductos()
        {
            List<clsParametro> lst = new List<clsParametro>();
            String Mensaje = "";

            try
            {
                lst.Add(new clsParametro("@IdProducto", m_IdP));
                lst.Add(new clsParametro("@IdCategoria", m_IdCategoria));
                lst.Add(new clsParametro("@Nombre", m_Producto));
                lst.Add(new clsParametro("@Marca", m_Marca));
                lst.Add(new clsParametro("@Stock", m_Stock));
                lst.Add(new clsParametro("@PrecioCompra", m_PrecioCompra));
                lst.Add(new clsParametro("@PrecioVenta", m_PrecioVenta));
                lst.Add(new clsParametro("@FechaVencimiento", m_FechaVencimiento));
                lst.Add(new clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarProducto", ref lst);
                Mensaje = lst[8].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}