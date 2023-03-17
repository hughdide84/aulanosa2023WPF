using AulaNosaApp.DTO;
using AulaNosaApp.Ventanas;
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

namespace AulaNosaApp.Paginas
{
    /// <summary>
    /// Lógica de interacción para AlumnoExterno.xaml
    /// </summary>
    public partial class AlumnoExterno : Page
    {
        List<AlumnoExternoDTO> lista = null;
        public AlumnoExterno()
        {
            InitializeComponent();
            RefrescarDatos();
        }

        //Refrescar datos del DataGrid
        private void RefrescarDatos()
        {
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            cmbConsultar.Visibility = Visibility.Hidden;
            tbxConsultar.Visibility = Visibility.Hidden;
            btnBuscar.Visibility = Visibility.Hidden;
           // lista = CursosApi.ListarCursos();
            dtgListado.ItemsSource = lista;
        }

        //Actualiza los registros
        private void BtnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            RefrescarDatos();
        }

        //Crear un registro
        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            CrearAlumnoExterno nuevoalumnoext = new CrearAlumnoExterno();
            nuevoalumnoext.ShowDialog();
            RefrescarDatos();
        }

        //Modificar un registro
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            AlumnoExternoDTO productoSel = dtgListado.SelectedItem as AlumnoExternoDTO;
            if (productoSel != null)
            {
                ModificarAlumnoExterno editaralumnoext = new ModificarAlumnoExterno(productoSel);
                editaralumnoext.ShowDialog();
                RefrescarDatos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Eliminar un registro
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            AlumnoExternoDTO productoSel = dtgListado.SelectedItem as AlumnoExternoDTO;
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

        //Habilitar búsqueda
        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
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

        //Filtrar los datos
        private void Filtrar()
        {
            if (cmbConsultar.SelectedIndex == 0)
            {
                lista.Clear();
                AlumnoExternoDTO coincidencia = CursosApi.ListarCursoPorId((int)BigInteger.Parse(tbxConsultar.Text));
                lista.Add(coincidencia);
                dtgListado.ItemsSource = lista;
            }
            else if (cmbConsultar.SelectedIndex == 1)
            {
                lista.Clear();
                AlumnoExternoDTO coincidencia = CursosApi.ListarCursoPorNombre(tbxConsultar.Text);
                lista.Add(coincidencia);
                dtgListado.ItemsSource = lista;
            }
            else if (cmbConsultar.SelectedIndex == 2)
            {
                lista.Clear();
                lista = CursosApi.ListarCursoPorEstado(Char.Parse(tbxConsultar.Text));
                dtgListado.ItemsSource = lista;
            }
        }

        //Filtrar registros
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (tbxConsultar.Visibility == Visibility.Visible && tbxConsultar.Text != "")
            {
                Filtrar();
            }
            else if (tbxConsultar.Visibility == Visibility.Visible && tbxConsultar.Text == "")
            {
                MessageBox.Show("El buscador no puede estar vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Permitir modificar o eliminar un registro
        private void DtgListado_Selected(object sender, RoutedEventArgs e)
        {
            btnModificar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
        }
    }
}
