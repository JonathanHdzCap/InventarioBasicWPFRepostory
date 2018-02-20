using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_de_Presentacion1
{
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.      
        /// </summary>
        public static int Evento;

        //Datos del Cliente
        public static int IdCliente;
        public static String DocumentoIdentidad;
        public static String NombreCliente;
        public static String ApellidosCliente;

        //Datos del Producto
        public static int IdProducto;
        public static String Descripcion;
        public static String Marca;
        public static Int32 Stock;
        public static Decimal PrecioVenta;

        //Datos del Empleado
        public static int IdCargo;
        public static String EstadoCivil = "";
        public static int IdEmpleado;

        //Variables de Sesion
        public static int IdEmpleadoLogueado;
        public static String NombreEmpleadoLogueado;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}

