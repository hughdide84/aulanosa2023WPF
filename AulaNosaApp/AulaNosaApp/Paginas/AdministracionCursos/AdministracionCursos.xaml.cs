using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Servicios.AdministracionCursos;
using AulaNosaApp.Servicios.AdministracionUsuarios;
using AulaNosaApp.Util;
using AulaNosaApp.Ventanas;
using RestSharp;
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

        RestClient client;
        RestRequest request;
        bool filtrosActivados = false;
        List<CursoDTO> cursosLista;

        public AdministracionCursos()
        {
            InitializeComponent();
            cbbConsultar.SelectedIndex = 0;
            cbbCursosActivosFiltro.SelectedIndex = 0;
            refrescarCursos();
        }

        void refrescarCursos()
        {
            cursosLista = CursosApi.listarCursos();
            dgvListado.ItemsSource = null;
            dgvListado.Items.Clear();
            dgvListado.ItemsSource = cursosLista;
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            refrescarCursos();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            NuevoCurso nuevoCurso = new NuevoCurso();
            nuevoCurso.Show();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            var cursoSeleccionado = dgvListado.SelectedItem as CursoDTO;
            Statics.cursoSeleccionado = cursoSeleccionado;
            EditarCurso editarCurso = new EditarCurso();
            editarCurso.Show();
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            dgvListado.SelectedItem = null;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var cursoSeleccionado = dgvListado.SelectedItem as CursoDTO;
            var resultado = MessageBox.Show("¿Desea eliminar este curso?", "Eliminar Curso", MessageBoxButton.YesNo);
            if (resultado == MessageBoxResult.Yes)
            {
                CursosApi.eliminarCurso(cursoSeleccionado.id);
                refrescarCursos();
                btnModificar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
                dgvListado.SelectedItem = null;
            }
            else
            {
                refrescarCursos();
            }
        }

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

        private void dgvListado_Selected(object sender, RoutedEventArgs e)
        {
            btnModificar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
        }

        private void cbbiIdFiltro_Selected(object sender, RoutedEventArgs e)
        {
            if (filtrosActivados)
            {
                tbxConsultarId.Visibility = Visibility.Visible;
                cbbCursosActivosFiltro.Visibility = Visibility.Collapsed;
            }
        }

        private void cbbiCursosActivosFiltro_Selected(object sender, RoutedEventArgs e)
        {
            if (filtrosActivados)
            {
                tbxConsultarId.Visibility = Visibility.Collapsed;
                cbbCursosActivosFiltro.Visibility = Visibility.Visible;
            }
        }

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
                    CursoDTO cursoId = CursosApi.filtrarCursoId(tbxConsultarId.Text);
                    List<CursoDTO> cursoIdRetornado = new List<CursoDTO>();
                    if (cursoId != null)
                    {
                        cursoIdRetornado.Add(cursoId);
                    }
                    dgvListado.ItemsSource = null;
                    dgvListado.Items.Clear();
                    dgvListado.ItemsSource = cursoIdRetornado;
                }
            }
            else
            {
                if (cbbCursosActivosFiltro.SelectedIndex == 0)
                {
                    List<CursoDTO> cursosActivos = CursosApi.listarCursosActivos();
                    dgvListado.ItemsSource = null;
                    dgvListado.Items.Clear();
                    dgvListado.ItemsSource = cursosActivos;
                }
                else
                {
                    List<CursoDTO> cursosFinalizados = CursosApi.listarCursosFinalizados();
                    dgvListado.ItemsSource = null;
                    dgvListado.Items.Clear();
                    dgvListado.ItemsSource = cursosFinalizados;
                }
            }
        }
    }
}