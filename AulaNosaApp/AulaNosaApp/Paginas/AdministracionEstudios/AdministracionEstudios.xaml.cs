using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
using AulaNosaApp.Servicios.AdministracionUsuarios;
using AulaNosaApp.Util;
using AulaNosaApp.Ventanas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AulaNosaApp.Paginas
{
    /// <summary>
    /// Lógica de interacción para CORE_Administración_de_estudios.xaml
    /// </summary>
    public partial class CORE_Administración_de_estudios : Page
    {
        public List<EstudioDTO> lista;
        public ObservableCollection<EstudioDTO> listaGrid { get; set; }
        bool filtrosActivados = false;

        public CORE_Administración_de_estudios()
        {
            InitializeComponent();
            RefrescarDatos();
        }

        private void RefrescarDatos()
        {
            lista = EstudioApi.ListarEstudios();
            this.dgListado.ItemsSource = lista;
        }

        private void btnRefrescarEstudios_Click(object sender, RoutedEventArgs e)
        {
            RefrescarDatos();
        }

        private void btnNuevoEstudios_Click(object sender, RoutedEventArgs e)
        {
            EstudioAlta pantalla = new EstudioAlta();
            pantalla.Show();
        }

        private void btnEditarEstudios_Click(object sender, RoutedEventArgs e)
        {
            btnEditarEstudios.IsEnabled = false;
            btnEliminarEstudios.IsEnabled = false;
            dgListado.SelectedItem = null;
            EstudioEditar pantalla = new EstudioEditar();
            pantalla.Show();
        }

        private void btnEliminarEstudios_Click(object sender, RoutedEventArgs e)
        {
            var resultado = MessageBox.Show("¿Desea eliminar este estudio?", "Eliminar Estudio", MessageBoxButton.YesNo);
            if (resultado == MessageBoxResult.Yes)
            {
                // Eliminar estudios
                EstudioApi.EliminarEstudio(Statics.estudioSeleccionado.id);
                // Refrescar DataGrid de estudios
                RefrescarDatos();
                // Deseleccionar seleccion
                btnEditarEstudios.IsEnabled = false;
                btnEliminarEstudios.IsEnabled = false;
                dgListado.SelectedItem = null;
            }
            else
            {
                // Refrescar DataGrid de estudios
                RefrescarDatos();
            }
        }

        private void btnConsultarEstudios_Click(object sender, RoutedEventArgs e)
        {
            if (!filtrosActivados)
            {
                lblIDEstudios.Visibility = Visibility.Visible;
                tbxConsultarEstudios.Visibility = Visibility.Visible;
                btnBuscarEstudios.Visibility = Visibility.Visible;
                filtrosActivados = true;
            }
            else
            {
                lblIDEstudios.Visibility = Visibility.Collapsed;
                tbxConsultarEstudios.Visibility = Visibility.Collapsed;
                btnBuscarEstudios.Visibility = Visibility.Collapsed;
                filtrosActivados = false;
            }
        }

        private void btnBuscarEstudios_Click(object sender, RoutedEventArgs e)
        {
            // Recoger por ID
            EstudioDTO estudioID = EstudioApi.filtrarEstudioId(tbxConsultarEstudios.Text);
            List<EstudioDTO> estudioIdRetornado = new List<EstudioDTO>();
            if (estudioID != null)
            {
                estudioIdRetornado.Add(estudioID);
            }
            // Mostrarlo en un DataGrid
            dgListado.ItemsSource = null;
            dgListado.Items.Clear();
            dgListado.ItemsSource = estudioIdRetornado;
        }

        private void dgListado_Selected(object sender, RoutedEventArgs e)
        {
            btnEditarEstudios.IsEnabled = true;
            btnEliminarEstudios.IsEnabled = true;
            Statics.estudioSeleccionado = dgListado.SelectedItem as EstudioDTO;
        }
    }
}
