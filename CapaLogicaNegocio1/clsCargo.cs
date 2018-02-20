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
   public class clsCargo
    {
       private clsManejador M = new clsManejador();

        Int32 m_IdCargo;
        String m_Descripcion;

        public Int32 IdCargo
        {
            get { return m_IdCargo; }
            set { m_IdCargo = value; }
        }

        public String Descripcion
        {
            get { return m_Descripcion; }
            set { m_Descripcion = value; }
        }

        public DataTable Listar() {
            return M.Listado("ListarCargo", null);
        }

        public String RegistrarCargo() {
            String Mensaje = "";
            List<clsParametro> lst = new List<clsParametro>();
            try
            {
                lst.Add(new clsParametro("@Descripcion", m_Descripcion));
                lst.Add(new clsParametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,50));
                M.EjecutarSP("RegistrarCargo",ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {               
               throw ex;
            }
            return Mensaje;
        }

      public String ActualizarCargo() {
            String Mensaje = "";
            List<clsParametro> lst = new List<clsParametro>();
            try
            {
                lst.Add(new clsParametro("@IdCargo", m_IdCargo));
                lst.Add(new clsParametro("@Descripcion", m_Descripcion));
                lst.Add(new clsParametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,100));
                M.EjecutarSP("ActualizarCargo", ref lst);
                Mensaje = lst[2].Valor.ToString();
            }
            catch (Exception ex)
            {               
               throw ex;
            }
            return Mensaje;
        }

        public DataTable BusquedaCargo(String objDescripcion) {
            DataTable dt=new DataTable();
            List<clsParametro> lst = new List<clsParametro>();
            try
            {
                lst.Add(new clsParametro("@Descripcion",objDescripcion));
                return dt = M.Listado("BuscarCargo",lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
