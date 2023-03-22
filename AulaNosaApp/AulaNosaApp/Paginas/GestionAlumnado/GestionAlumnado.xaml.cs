using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
using AulaNosaApp.Util;
using AulaNosaApp.Ventanas.GestionAlumnado;
using AulaNosaApp.Ventanas.GestionAlumnadoExterno;
using RestSharp;
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

namespace AulaNosaApp.Paginas.GestionAlumnos
{
    /// <summary>
    /// Lógica de interacción para GestionAlumnos.xaml
    /// </summary>
    public partial class GestionAlumnos : Page
    {
        
        bool filtrosActivados = false;
        List<AlumnoDTO> alumnosLista;

        public GestionAlumnos()
        {
            InitializeComponent();
            cbbConsultar.SelectedIndex = 0;
            refrescarAlumnos();
        }

        // Refrescar lista de alumnos
        void refrescarAlumnos()
        {
            alumnosLista = AlumnoApi.ListarAlumnos();
            dgvListado.ItemsSource = null;
            dgvListado.Items.Clear();
            dgvListado.ItemsSource = alumnosLista;
        }

        // Boton de refrescar alumnos
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            refrescarAlumnos();
        }

        // Boton de crear alumno (abre ventana de creacion de alumno)
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            AgregarAlumno nuevoAlumno = new AgregarAlumno();
            nuevoAlumno.Show();
        }

        // Boton de modificar alumno (abre ventana de modificacion de alumno)
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            AlumnoDTO productoSel = dgvListado.SelectedItem as AlumnoDTO;
            if (productoSel != null)
            {
                EditarAlumno editaralumnoext = new EditarAlumno(productoSel);
                editaralumnoext.ShowDialog();
                refrescarAlumnos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Boton de eliminar Alumno
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var alumnoSeleccionado = dgvListado.SelectedItem as AlumnoDTO;
            var resultado = MessageBox.Show("¿Desea eliminar este alumno?", "Eliminar Alumno", MessageBoxButton.YesNo);
            if (resultado == MessageBoxResult.Yes)
            {
                AlumnoApi.EliminarAlumno(alumnoSeleccionado.id);
                refrescarAlumnos();
                btnModificar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
                dgvListado.SelectedItem = null;
            }
            else
            {
                refrescarAlumnos();
            }
        }

        // Mostrar/Ocultar el panel de filtros
        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            if (!filtrosActivados)
            {
                cbbConsultar.Visibility = Visibility.Visible;
                btnBuscar.Visibility = Visibility.Visible;
                if (cbbConsultar.SelectedIndex == 0)
                {
                    tbxConsultarId.Visibility = Visibility.Visible;
                }
                else
                {
                    tbxConsultarId.Visibility = Visibility.Collapsed;
                }
                filtrosActivados = true;
            }
            else
            {
                filtrosActivados = false;
                cbbConsultar.Visibility = Visibility.Collapsed;
                btnBuscar.Visibility = Visibility.Collapsed;
                tbxConsultarId.Visibility = Visibility.Collapsed;
                cbbConsultar.SelectedIndex = 0;
            }
        }

        // Habilitar botones de editar y eliminar alumno al clickear uno
        private void dgvListado_Selected(object sender, RoutedEventArgs e)
        {
            btnModificar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
        }

        // Filtros de ID
        private void cbbiIdFiltro_Selected(object sender, RoutedEventArgs e)
        {
            if (filtrosActivados)
            {
                tbxConsultarId.Visibility = Visibility.Visible;
            }
        }

        // Filtros de alumnos activos/desactivos
        private void cbbiAlumnosActivosFiltro_Selected(object sender, RoutedEventArgs e)
        {
            if (filtrosActivados)
            {
                tbxConsultarId.Visibility = Visibility.Collapsed;
            }
        }

        // Boton de buscar
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (cbbConsultar.SelectedIndex == 0)
            {
                if (tbxConsultarId.Text.Length == 0)
                {
                    MessageBox.Show("Busqueda vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int id;
                    if (int.TryParse(tbxConsultarId.Text, out id))
                    {
                        AlumnoDTO coincidencia = AlumnoApi.ListarAlumnoPorId(id);
                        alumnosLista = new List<AlumnoDTO> { coincidencia };
                        dgvListado.ItemsSource = alumnosLista;
                    }
                    else
                    {
                        MessageBox.Show("El valor ingresado no es un número válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        
    }
        
}
