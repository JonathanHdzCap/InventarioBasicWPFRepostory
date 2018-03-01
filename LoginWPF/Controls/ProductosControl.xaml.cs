using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginWPF.Windows.Controls
{
    /// <summary>
    /// Interaction logic for ProductosControl.xaml
    /// </summary>
    public partial class ProductosControl : UserControl
    {
        int Listado = 0;
        private clsProducto P = new clsProducto();

        public ProductosControl()
        {
            InitializeComponent();
            CargarListado();
        }

        private void CargarListado()
        {
            List<clsProducto> listProductos = new List<clsProducto>();
            listProductos = P.Listar();
            gridProductos.ItemsSource = listProductos;
            gridProductos.Items[0].GetType();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductosAdd windowAddProductos = new ProductosAdd();
            windowAddProductos.ShowDialog();
        }

        private void gridProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}