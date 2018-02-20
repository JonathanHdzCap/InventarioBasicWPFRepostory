using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaEnlaceDatos;

namespace CapaLogicaNegocio
{
   public class clsUsuarios
    {
       clsManejador M = new clsManejador();

       public int IdEmpleado { get; set; }
       public string User { get; set; }
       public string Password { get; set; }

       public String RegistrarUsuarios() {
           List<clsParametro> lst = new List<clsParametro>();
           String Mensaje = "";
           try{
               lst.Add(new clsParametro("@IdEmpleado", IdEmpleado));
               lst.Add(new clsParametro("@Usuario", User));
               lst.Add(new clsParametro("@Contraseña", Password));
               lst.Add(new clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
               M.EjecutarSP("RegistrarUsuario",ref lst);
               return Mensaje = lst[3].Valor.ToString();
           }catch (Exception ex){
               throw ex;
           }
       }

       public String IniciarSesion() {
           List<clsParametro> lst = new List<clsParametro>();
           String Mensaje="";
           try{
               lst.Add(new clsParametro("@Usuario",User));
               lst.Add(new clsParametro("@Contraseña", Password));
               lst.Add(new clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
               M.EjecutarSP("IniciarSesion",ref lst);
               return Mensaje=lst[2].Valor.ToString();
           }catch (Exception ex){
               throw ex;
           }
       }

       public DataTable DevolverDatosSesion(String objUser,String objPassword) {
           List<clsParametro> lst = new List<clsParametro>();
           try{
               lst.Add(new clsParametro("@Usuario", objUser));
               lst.Add(new clsParametro("@Contraseña", objPassword));
               return M.Listado("DevolverDatosSesion",lst);
           }catch (Exception ex){
               throw ex;
           }
       }
    }
}
