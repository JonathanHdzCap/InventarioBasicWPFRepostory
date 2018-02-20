using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaEnlaceDatos;

namespace CapaLogicaNegocio
{
   public class clsEmpleado
    {
       clsManejador M = new clsManejador();

       public int IdCargo { get; set; }
       public int IdEmpleado { get; set; }
       public String Dni{get;set;}
       public String Apellidos{get;set;}
       public String Nombres { get; set; }
       public Char Sexo { get; set; }
       public DateTime FechaNac { get; set; }
       public String Direccion { get; set; }
       public Char EstadoCivil { get; set; }


       public String MantenimientoEmpleados() {
           List<clsParametro> lst = new List<clsParametro>();
           String Mensaje = "";
           try{
               lst.Add(new clsParametro("@IdEmpleado", IdEmpleado));
               lst.Add(new clsParametro("@IdCargo", IdCargo));
               lst.Add(new clsParametro("@Dni", Dni));
               lst.Add(new clsParametro("@Apellidos", Apellidos));
               lst.Add(new clsParametro("@Nombres", Nombres));
               lst.Add(new clsParametro("@Sexo", Sexo));
               lst.Add(new clsParametro("@FechaNac", FechaNac));
               lst.Add(new clsParametro("@Direccion", Direccion));
               lst.Add(new clsParametro("@EstadoCivil", EstadoCivil));
               lst.Add(new clsParametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,100));
               M.EjecutarSP("MantenimientoEmpleados",ref lst);
               return Mensaje = lst[9].Valor.ToString();

           }
           catch (Exception ex){
               throw ex;
           }
       }

       public DataTable ListadoEmpleados() {
          return M.Listado("ListadoEmpleados", null);
       }

       public String GenerarIdEmpleado() {
           List<clsParametro> lst = new List<clsParametro>();
           int objIdEmpleado;
           try{
               lst.Add(new clsParametro("@IdEmpleado","",SqlDbType.Int,ParameterDirection.Output,4));
               M.EjecutarSP("GenerarIdEmpleado", ref lst);
               objIdEmpleado = Convert.ToInt32(lst[0].Valor.ToString());
           }catch (Exception ex){
               throw ex;
           }
           return Convert.ToString(objIdEmpleado);
       }

       public DataTable BuscarEmpleado(String objDatos)
       {
           DataTable dt = new DataTable();
           List<clsParametro> lst = new List<clsParametro>();
           lst.Add(new clsParametro("@Datos", objDatos));
           return dt = M.Listado("Buscar_Empleado", lst);
       }

    }
}
