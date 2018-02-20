using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using CapaEnlaceDatos;

namespace CapaLogicaNegocio
{
   public class clsCategoria
    {
       private clsManejador M = new clsManejador();

        private Int32 m_IdC;
        private Int32 m_IdCategoria;
        private String m_Descripcion;

        public Int32 IdC {
            get { return m_IdC; }
            set { m_IdC = value; }
        }
        public Int32 IdCategoria
        {
            get { return m_IdCategoria; }
            set { m_IdCategoria = value; }
        }

        public String Descripcion
        {
            get { return m_Descripcion; }
            set { m_Descripcion = value; }
        }

        public DataTable Listar() {
            return M.Listado("ListarCategoria",null);
        }

        public String RegistrarCategoria() {
            List<clsParametro> lst = new List<clsParametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new clsParametro("@Descripcion",m_Descripcion));
                lst.Add(new clsParametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,50));
                M.EjecutarSP("RegistrarCategoria",ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {    
                throw ex;
            }
            return Mensaje;
        }

        public DataTable BuscarCategoria(String objDescripcin) {
            List<clsParametro> lst = new List<clsParametro>();
            DataTable dt = new DataTable();
            try
            {
                lst.Add(new clsParametro("@Datos", objDescripcin));
                return dt = M.Listado("BuscarCategoria",lst);
            }
            catch (Exception ex)
            {    
                throw ex;
            }
        }

        public String ActualizarCategoria() { 
            List<clsParametro> lst = new List<clsParametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new clsParametro("@IdC",m_IdC));
                lst.Add(new clsParametro("@Descripcion",m_Descripcion));
                lst.Add(new clsParametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,50));
                M.EjecutarSP("ActualizarCategoria", ref lst);
                Mensaje = lst[2].Valor.ToString();
            }
            catch (Exception ex)
            {    
                throw ex;
            }
            return Mensaje;
        }
    }
}
