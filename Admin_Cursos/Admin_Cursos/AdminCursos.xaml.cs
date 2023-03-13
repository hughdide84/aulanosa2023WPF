using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Admin_Cursos
{
    /// <summary>
    /// Lógica de interacción para AdminCursos.xaml
    /// </summary>
    public partial class AdminCursos : Page
    {
        public AdminCursos()
        {
            InitializeComponent();
        }

        private void RefrescarDatos()
        {
            //lista = ProductosApi.ListarProductos();
            //this.dgListado.ItemsSource = lista;
        }

        private void BtnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            RefrescarDatos();
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            NuevoCurso nuevocurso = new NuevoCurso();
            nuevocurso.ShowDialog();
            RefrescarDatos();
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            //ProductoDTO? productoSel = dgListado.SelectedItem as ProductoDTO;

            //if (productoSel != null)
            //{
            //    ProductoEditar pantalla = new ProductoEditar(productoSel);
            //    pantalla.ShowDialog();
            //    RefrescarDatos();
            //}
            //else
            //{
            //    MessageBox.Show("Debe seleccionar producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            //ProductoDTO? productoSel = dgListado.SelectedItem as ProductoDTO;

            //if (productoSel != null)
            //{
            //    ProductosApi.EliminarProducto(productoSel.id);
            //    RefrescarDatos();
            //}
            //else
            //{
            //    MessageBox.Show("Debe seleccionar producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }
    }
}
