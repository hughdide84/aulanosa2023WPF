using System;
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

namespace AulaNosaApp
{
    /// <summary>
    /// Lógica de interacción para AdministracionCursos.xaml
    /// </summary>
    public partial class AdministracionCursos : Page
    {
        public AdministracionCursos()
        {
            InitializeComponent();
        }

        private void RefrescarDatos()
        {
            cmbConsultar.Visibility = Visibility.Hidden;
            tbxConsultar.Visibility = Visibility.Hidden;
            //lista = ProductosApi.ListarProductos();
            //this.grdListado.ItemsSource = lista;
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

            //ProductoDTO? productoSel = grdListado.SelectedItem as ProductoDTO;
            //if (productoSel != null)
            //{
            //    EditarCurso editarcurso = new EditarCurso(productoSel);
            //    editarcurso.ShowDialog();
            //    RefrescarDatos();
            //}
            //else
            //{
            //    MessageBox.Show("Debe seleccionar un producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            //ProductoDTO? productoSel = grdListado.SelectedItem as ProductoDTO;

            //if (productoSel != null)
            //{
            //    ProductosApi.EliminarProducto(productoSel.id);
            //    RefrescarDatos();
            //}
            //else
            //{
            //    MessageBox.Show("Debe seleccionar un producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            if (tbxConsultar.Visibility == Visibility.Visible && tbxConsultar.Text != "")
            {
                MessageBox.Show("No existe nada de momento en BBDD", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                filtrar();
            }
            else
            {
                cmbConsultar.Items.Clear();
                cmbConsultar.Items.Add("Id");
                cmbConsultar.Items.Add("Nombre");

                if (cmbConsultar.Visibility == Visibility.Visible)
                {
                    cmbConsultar.Visibility = Visibility.Hidden;
                    tbxConsultar.Visibility = Visibility.Hidden;
                }
                else
                {
                    cmbConsultar.Visibility = Visibility.Visible;
                    tbxConsultar.Visibility = Visibility.Visible;
                }
            }
        }

        private void filtrar()
        {
            if (cmbConsultar.SelectedIndex == 0)
            {
                //lista = ProductosApi.ListarProductosPorId(tbxConsultar);
                //this.grdListado.ItemsSource = lista;
            }
            else if (cmbConsultar.SelectedIndex == 1)
            {
                //lista = ProductosApi.ListarProductosPorNombre(tbxConsultar);
                //this.grdListado.ItemsSource = lista;
            }
        }
    }
}
