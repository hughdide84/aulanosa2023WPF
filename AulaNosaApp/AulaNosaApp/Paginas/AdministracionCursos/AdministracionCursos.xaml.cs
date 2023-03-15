using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Servicios.AdministracionCursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        List<CursoDTO> lista = null;

        public AdministracionCursos()
        {
            InitializeComponent();
            RefrescarDatos();
        }

        private void RefrescarDatos()
        {
            cmbConsultar.Visibility = Visibility.Hidden;
            tbxConsultar.Visibility = Visibility.Hidden;
            btnBuscar.Visibility = Visibility.Hidden;
            lista = CursosApi.ListarCursos();
            dtgListado.ItemsSource = lista;
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            RefrescarDatos();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            NuevoCurso nuevocurso = new NuevoCurso();
            nuevocurso.ShowDialog();
            RefrescarDatos();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            CursoDTO productoSel = dtgListado.SelectedItem as CursoDTO;
            if (productoSel != null)
            {
                EditarCurso editarcurso = new EditarCurso(productoSel);
                editarcurso.ShowDialog();
                RefrescarDatos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            CursoDTO productoSel = dtgListado.SelectedItem as CursoDTO;
            if (productoSel != null)
            {
                CursosApi.EliminarCurso(productoSel.id);
                RefrescarDatos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            cmbConsultar.Items.Clear();
            cmbConsultar.Items.Add("Id");
            cmbConsultar.Items.Add("Nombre");
            cmbConsultar.Items.Add("Estado");
            cmbConsultar.SelectedIndex = 0;

            if (cmbConsultar.Visibility == Visibility.Visible)
            {
                cmbConsultar.Visibility = Visibility.Hidden;
                tbxConsultar.Visibility = Visibility.Hidden;
                btnBuscar.Visibility = Visibility.Hidden;
            }
            else
            {
                cmbConsultar.Visibility = Visibility.Visible;
                tbxConsultar.Visibility = Visibility.Visible;
                btnBuscar.Visibility = Visibility.Visible;
            }
        }

        private void filtrar()
        {
            if (cmbConsultar.SelectedIndex == 0)
            {
                lista.Clear();
                CursoDTO coincidencia = CursosApi.ListarCursoPorId((int)BigInteger.Parse(tbxConsultar.Text));
                lista.Add(coincidencia);
                dtgListado.ItemsSource = lista;
            }
            else if (cmbConsultar.SelectedIndex == 1)
            {
                lista.Clear();
                CursoDTO coincidencia = CursosApi.ListarCursoPorNombre(tbxConsultar.Text);
                lista.Add(coincidencia);
                dtgListado.ItemsSource = lista;
            }
            else if (cmbConsultar.SelectedIndex == 2)
            {
                lista.Clear();
                lista = CursosApi.ListarCursoPorEstado(tbxConsultar.Text);
                dtgListado.ItemsSource = lista;
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (tbxConsultar.Visibility == Visibility.Visible && tbxConsultar.Text != "")
            {
                MessageBox.Show("No existe nada de momento en BBDD", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                filtrar();
            }
            else if (tbxConsultar.Visibility == Visibility.Visible && tbxConsultar.Text == "")
            {
                MessageBox.Show("El buscador no puede estar vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}