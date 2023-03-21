using AulaNosaApp.DTO;
using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Servicios;
using AulaNosaApp.Servicios.AdministracionCursos;
using AulaNosaApp.Util;
using AulaNosaApp.Ventanas.GestionAlumnado;
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
            cbbCursosActivosFiltro.SelectedIndex = 0;
            refrescarAlumnos();
        }

        // Refrescar lista de cursos
        void refrescarAlumnos()
        {
            alumnosLista = AlumnoApi.ListarAlumnos();
            dgvListado.ItemsSource = null;
            dgvListado.Items.Clear();
            dgvListado.ItemsSource = alumnosLista;
        }

        // Boton de refrescar cursos
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            refrescarAlumnos();
        }

        // Boton de crear curso (abre ventana de creacion de curso)
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            AgregarAlumno nuevoAlumno = new AgregarAlumno();
            nuevoAlumno.Show();
        }

        // Boton de modificar curso (abre ventana de modificacion de curso)
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            var alumnoSeleccionado = dgvListado.SelectedItem as AlumnoDTO;
            Statics.alumnoSeleccionado = alumnoSeleccionado;
            EditarAlumno editarAlumno = new EditarAlumno();
            editarAlumno.Show();
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            dgvListado.SelectedItem = null;
        }

        // Boton de eliminar curso
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var alumnoSeleccionado = dgvListado.SelectedItem as AlumnoDTO;
            var resultado = MessageBox.Show("¿Desea eliminar este alumno?", "Eliminar Alumno", MessageBoxButton.YesNo);
            if (resultado == MessageBoxResult.Yes)
            {
                CursosApi.eliminarCurso(alumnoSeleccionado.id);
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
                    cbbCursosActivosFiltro.Visibility = Visibility.Collapsed;
                }
                else
                {
                    tbxConsultarId.Visibility = Visibility.Collapsed;
                    cbbCursosActivosFiltro.Visibility = Visibility.Visible;
                }
                filtrosActivados = true;
            }
            else
            {
                filtrosActivados = false;
                cbbConsultar.Visibility = Visibility.Collapsed;
                btnBuscar.Visibility = Visibility.Collapsed;
                tbxConsultarId.Visibility = Visibility.Collapsed;
                cbbCursosActivosFiltro.Visibility = Visibility.Collapsed;
                cbbConsultar.SelectedIndex = 0;
                cbbCursosActivosFiltro.SelectedIndex = 0;
            }
        }

        // Habilitar botones de editar y eliminar usuario al clickear uno
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
                cbbCursosActivosFiltro.Visibility = Visibility.Collapsed;
            }
        }

        // Filtros de cursos activos/desactivos
        private void cbbiCursosActivosFiltro_Selected(object sender, RoutedEventArgs e)
        {
            if (filtrosActivados)
            {
                tbxConsultarId.Visibility = Visibility.Collapsed;
                cbbCursosActivosFiltro.Visibility = Visibility.Visible;
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
