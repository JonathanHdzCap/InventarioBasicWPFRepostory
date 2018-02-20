using Capa_de_Presentacion1;
using CapaLogicaNegocio;
using DevComponents.DotNetBar;
using System;
using LoginWPF.Windows;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using Models;
namespace LoginWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        //private UserEntity objUser;
        //private InventarioService.LoginClient proxyLogin;
        clsUsuarios U = new clsUsuarios();

        public LoginWindow()
        {
            //proxyLogin = new InventarioService.LoginClient();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextUser.Text.Trim() == string.Empty || TextUser.Text.Trim() == "User")
            {
                MessageBoxEx.Show("Ingresa un Usuario Válido", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TextUser.Focus();
                return;               
            }
            else
            {
                if (TextPsw.Password.Trim() == string.Empty || TextPsw.Password.Trim() == "123456")
                {
                    MessageBoxEx.Show("Ingresa una Contraseña valida", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TextPsw.Focus();
                    return;
                }
            }

            ////Se loguea el Usuario
            String Mensaje = "";
            U.User = TextUser.Text.Trim();
            U.Password = TextPsw.Password.Trim();
            Mensaje = U.IniciarSesion();
            if (Mensaje == "Su Contraseña es Incorrecta.")
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                TextPsw.Clear();
                TextPsw.Focus();
            }
            else
                if (Mensaje == "El Nombre de Usuario no Existe.")
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                TextUser.Clear();
                TextPsw.Clear();
                TextUser.Focus();
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MenuWindow menu = new MenuWindow();
                //RecuperarDatosSesion();
                menu.Show();
                this.Hide();
            }
        }

        private void TextUser_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(TextUser.Text.Trim() == "User")
            {
                TextUser.Text = "";
                TextUser.Foreground = Brushes.White;
            }
        }

        private void TextUser_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextUser.Text.Trim() == "")
            {
                TextUser.Foreground = Brushes.DimGray;
                TextUser.Text = "User";
            }
        }

        private void TextPsw_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextPsw.Password.Trim() == "")
            {
                TextPsw.Foreground = Brushes.DimGray;
                TextPsw.Password = "123456";
            }
        }

        private void TextPsw_GotKeyboardFocus_1(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (TextPsw.Password.Trim() == "123456")
            {
                TextPsw.Password = "";
                TextPsw.Foreground = Brushes.White;
            }
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxEx.Show("¿Está Seguro que Desea Salir.?", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void RecuperarDatosSesion()
        {
            DataRow row;
            DataTable dt = new DataTable();
            dt = U.DevolverDatosSesion(TextUser.Text.Trim(), TextPsw.Password.Trim());
            if (dt.Rows.Count == 1)
            {
                row = dt.Rows[0];
                Program.IdEmpleadoLogueado = Convert.ToInt32(row[0].ToString());
                Program.NombreEmpleadoLogueado = row[1].ToString();
            }
        }
    }
}
