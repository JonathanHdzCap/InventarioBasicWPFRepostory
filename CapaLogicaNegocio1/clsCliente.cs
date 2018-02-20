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
    public class clsCliente
    {
        private clsManejador M = new clsManejador();

        private String m_Dni;
        private String m_Apellidos;
        private String m_Nombres;
        private String m_Direccion;
        private String m_Telefono;


        public String Dni{
            get { return m_Dni; }
            set { m_Dni = value; }
        }

        public String Apellidos{
            get { return m_Apellidos; }
            set { m_Apellidos = value; }
        }

        public String Nombres{
            get { return m_Nombres; }
            set { m_Nombres = value; }
        }

        public String Telefono{
            get { return m_Telefono; }
            set { m_Telefono = value; }
        }

        public String Direccion{
            get { return m_Direccion; }
            set { m_Direccion = value; }
        }

        public DataTable Listado() {
           return M.Listado("ListarClientes", null);
        }

        public DataTable BuscarCliente(String objDatos) {
            DataTable dt = new DataTable();
            List<clsParametro> lst = new List<clsParametro>();
            lst.Add(new clsParametro("@Datos",objDatos));
            return dt=M.Listado("FiltrarDatosCliente",lst);
        }

        public String RegistrarCliente() {
            List<clsParametro> lst = new List<clsParametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new clsParametro("@DNI",m_Dni));
                lst.Add(new clsParametro("@Apellidos",m_Apellidos));
                lst.Add(new clsParametro("@Nombres",m_Nombres));
                lst.Add(new clsParametro("@Direccion",m_Direccion));
                lst.Add(new clsParametro("@Telefono",m_Telefono));
                lst.Add(new clsParametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,50));
                M.EjecutarSP("RegistrarCliente", ref lst);
                Mensaje=lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String ActualizarCliente()
        {
            List<clsParametro> lst = new List<clsParametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new clsParametro("@DNI", m_Dni));
                lst.Add(new clsParametro("@Apellidos", m_Apellidos));
                lst.Add(new clsParametro("@Nombres", m_Nombres));
                lst.Add(new clsParametro("@Direccion", m_Direccion));
                lst.Add(new clsParametro("@Telefono", m_Telefono));
                lst.Add(new clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarCliente", ref lst);
                Mensaje = lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}
