using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LoginWPF;
using Capa_de_Presentacion1;
using LoginWPF.Windows.Controls;

namespace LoginWPF.Windows
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //FrmListadoProductos P = new FrmListadoProductos();
            //P.Show();
            Control.Children.Clear();
            ProductosControl gridProductos = new ProductosControl();
            Control.Children.Add(gridProductos);
        }

        private void GridVentas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            FrmRegistroVentas V = new FrmRegistroVentas();
            V.Show();
        }

        private void GridSalir_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            App.Current.Shutdown();
        }

        private void GridEmpleado_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Control.Children.Clear();
            EmpleadosControl gridEmpleados = new EmpleadosControl();
            Control.Children.Add(gridEmpleados);
        }
    }
}
