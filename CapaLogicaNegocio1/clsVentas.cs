using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaEnlaceDatos;

namespace CapaLogicaNegocio
{
   public class clsVentas
    {
       clsManejador M = new clsManejador();

       public int IdEmpleado { get; set; }
       public int IdCliente { get; set; }
       public string Serie { get; set; }
       public string NroComprobante { get; set; }
       public string TipoDocumento { get; set; }
       public DateTime FechaVenta { get; set; }
       public decimal Total { get; set; }

       public String GenerarSerieDocumento()
       {
           List<clsParametro> lst = new List<clsParametro>();
           String Serie="";
           try{
               lst.Add(new clsParametro("@Serie", "", SqlDbType.VarChar, ParameterDirection.Output, 5));
               M.EjecutarSP("[Serie Documento]", ref lst);
               Serie = Convert.ToString(lst[0].Valor.ToString());
           }catch (Exception ex){
               throw ex;
           }
           return Convert.ToString(Serie);
       }

       public String NumeroComprobante(String objTipoDocumento) {
           List<clsParametro> lst = new List<clsParametro>();
           String NroCorrelativo="";
           try{
               lst.Add(new clsParametro("@TipoDocumento", objTipoDocumento));
               lst.Add(new clsParametro("@NroCorrelativo", "", SqlDbType.VarChar, ParameterDirection.Output, 7));
               M.EjecutarSP("[Numero Correlativo]", ref lst);
               NroCorrelativo = Convert.ToString(lst[1].Valor.ToString());
           }catch (Exception ex){ 
               throw ex;
           }
           return Convert.ToString(NroCorrelativo);
       }

       public String GenerarIdVenta() {
           List<clsParametro> lst = new List<clsParametro>();
           int objIdVenta;
           try{
               lst.Add(new clsParametro("@IdVenta", "", SqlDbType.Int, ParameterDirection.Output, 4));
               M.EjecutarSP("GenerarIdVenta", ref lst);
               objIdVenta = Convert.ToInt32(lst[0].Valor.ToString());
           }catch (Exception ex){
               throw ex;
           }
           return Convert.ToString(objIdVenta);
       }

       public String RegistrarVenta() {
           String Mensaje = "";
           List<clsParametro> lst = new List<clsParametro>();
           try{
               lst.Add(new clsParametro("@IdEmpleado",IdEmpleado));
               lst.Add(new clsParametro("@IdCliente",IdCliente));
               lst.Add(new clsParametro("@Serie",Serie));
               lst.Add(new clsParametro("@NroDocumento",NroComprobante));
               lst.Add(new clsParametro("@TipoDocumento",TipoDocumento));
               lst.Add(new clsParametro("@FechaVenta",FechaVenta));
               lst.Add(new clsParametro("@Total",Total));
               lst.Add(new clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
               M.EjecutarSP("RegistrarVenta", ref lst);
               return Mensaje=lst[7].Valor.ToString();
           }catch (Exception ex){
               throw ex;
           }
       }
    }
}
