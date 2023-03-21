using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
using AulaNosaApp.Ventanas.GestionAlumnadoExterno;
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

namespace AulaNosaApp.Paginas.GestionAlumnadoExterno
{
    /// <summary>
    /// Lógica de interacción para GestionAlumnadoExterno.xaml
    /// </summary>
    public partial class GestionAlumnadoExterno : Page
    {
        List<AlumnoExternoDTO> lista = null;
        public GestionAlumnadoExterno()
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
            lista = AlumnoExternoApi.ListarAlumnosExternos();
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
                AlumnoExternoApi.EliminarAlumnoExterno(productoSel.id);
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
            cmbConsultar.Items.Add("Email");
            cmbConsultar.Items.Add("Teléfono");
            cmbConsultar.Items.Add("Universidad");
            cmbConsultar.Items.Add("Titulación");
            cmbConsultar.Items.Add("Especialidad");
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
                int id;
                if (int.TryParse(tbxConsultar.Text, out id))
                {
                    AlumnoExternoDTO coincidencia = AlumnoExternoApi.ListarAlumnoExternoPorId(id);
                    lista = new List<AlumnoExternoDTO> { coincidencia };
                    dtgListado.ItemsSource = lista;
                }
                else
                {
                    MessageBox.Show("El valor ingresado no es un número válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
