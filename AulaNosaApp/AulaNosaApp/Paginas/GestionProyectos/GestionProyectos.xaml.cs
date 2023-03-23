using AulaNosaApp.DTO;
using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Servicios;
using AulaNosaApp.Servicios.AdministracionCursos;
using AulaNosaApp.Util;
using AulaNosaApp.Ventanas.GestionProyectos;
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

namespace AulaNosaApp.Paginas.GestionProyectos
{
    /// <summary>
    /// Lógica de interacción para GestionProyectos.xaml
    /// </summary>
    public partial class GestionProyectos : Page
    {
        bool filtrosActivados = false;
        List<ProyectoDTO> proyectosLista;

        public GestionProyectos()
        {
            InitializeComponent();
            cbbConsultar.SelectedIndex = 0;
            refrescarProyectos();
        }

        // Refrescar lista de cursos
        void refrescarProyectos()
        {
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            cbbConsultar.Visibility = Visibility.Collapsed;
            tbxConsultarId.Text = "";
            tbxConsultarId.Visibility = Visibility.Collapsed;
            btnBuscar.Visibility = Visibility.Collapsed;
            proyectosLista = ProyectoApi.listarProyectos();
            //for (int i = 0; i < proyectosLista.Count; i++)
            //{
            //    if (proyectosLista[i].documento.Checked == true)
            //    {
            //        cbxDocumento.IsThreeState = true;
            //    }
            //}
            dgvListado.ItemsSource = null;
            dgvListado.Items.Clear();
            dgvListado.ItemsSource = proyectosLista;
        }

        // Boton de refrescar cursos
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            refrescarProyectos();
        }

        // Boton de crear curso (abre ventana de creacion de curso)
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            ProyectoCrear proyectoCrear = new ProyectoCrear();
            proyectoCrear.Show();
        }

        // Boton de modificar curso (abre ventana de modificacion de curso)
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            var proyectoSeleccionado = dgvListado.SelectedItem as ProyectoDTO;
            Statics.proyectoSeleccionado = proyectoSeleccionado;
            ProyectoModificar proyectoModificar = new ProyectoModificar();
            proyectoModificar.Show();
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            dgvListado.SelectedItem = null;
        }

        // Boton de eliminar curso
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var proyectoSeleccionado = dgvListado.SelectedItem as ProyectoDTO;
            var resultado = MessageBox.Show("¿Desea eliminar este proyecto?", "Eliminar Proyecto", MessageBoxButton.YesNo);
            if (resultado == MessageBoxResult.Yes)
            {
                ProyectoApi.eliminarProyecto(proyectoSeleccionado.id);
                refrescarProyectos();
                btnModificar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
                dgvListado.SelectedItem = null;
            }
            else
            {
                refrescarProyectos();
            }
        }

        // Mostrar/Ocultar el panel de filtros
        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            if (!filtrosActivados)
            {
                cbbConsultar.Visibility = Visibility.Visible;
                btnBuscar.Visibility = Visibility.Visible;
                tbxConsultarId.Visibility = Visibility.Visible;
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

        // Habilitar botones de editar y eliminar usuario al clickear uno
        private void dgvListado_Selected(object sender, RoutedEventArgs e)
        {
            btnModificar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
        }

        // Boton de buscar
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (tbxConsultarId.Text.Length == 0)
            {
                MessageBox.Show("Busqueda vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ProyectoDTO proyectoId = ProyectoApi.filtrarProyectoId(int.Parse(tbxConsultarId.Text));
                List<ProyectoDTO> proyectoIdRetornado = new List<ProyectoDTO>();
                if (proyectoId != null)
                {
                    proyectoIdRetornado.Add(proyectoId);
                }
                dgvListado.ItemsSource = null;
                dgvListado.Items.Clear();
                dgvListado.ItemsSource = proyectoIdRetornado;
            }
        }
    }
}
