using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
using AulaNosaApp.Servicios.AdministracionCursos;
using AulaNosaApp.Util;
using AulaNosaApp.Ventanas.AdministracionMatriculas;
using AulaNosaApp.Ventanas.AdministracionPagos;
using RestSharp;
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

namespace AulaNosaApp.Paginas.GestionMatriculas
{
    /// <summary>
    /// Lógica de interacción para GestionMatriculas.xaml
    /// </summary>
    public partial class GestionMatriculas : Page
    {

        RestClient client;
        RestRequest request;
        List<MatriculaDTO> matriculaLista;

        public GestionMatriculas()
        {
            InitializeComponent();
            refrescarLista();
        }

        // Boton de refrescar lista
        private void btnRefrescarMatriculas_Click(object sender, RoutedEventArgs e)
        {
            refrescarLista();
        }

        // Boton de crear matricula
        private void btnNuevaMatricula_Click(object sender, RoutedEventArgs e)
        {
            AgregarMatricula agregarMatricula = new AgregarMatricula();
            agregarMatricula.Show();
        }

        // Boton de editar matricula
        private void btnEditarMatricula_Click(object sender, RoutedEventArgs e)
        {
            Statics.matriculaSeleccionada = dgvMatriculas.SelectedItem as MatriculaDTO;
            EditarMatricula editarMatricula = new EditarMatricula();
            editarMatricula.Show();
            btnEditarMatricula.IsEnabled = false;
            btnMostrarPagos.IsEnabled = false;
            dgvMatriculas.SelectedItem = null;
        }

        // Boton de mostrar pagos
        private void btnMostrarPagos_Click(object sender, RoutedEventArgs e)
        {
            AdministracionPagos administracionPagos = new AdministracionPagos();
            administracionPagos.Show();
            btnEditarMatricula.IsEnabled = false;
            btnMostrarPagos.IsEnabled = false;
            dgvMatriculas.SelectedItem = null;
        }

        // Refrescar lista
        void refrescarLista()
        {
            matriculaLista = MatriculaApi.listarMatriculas();
            dgvMatriculas.ItemsSource = null;
            dgvMatriculas.Items.Clear();
            dgvMatriculas.ItemsSource = matriculaLista;
        }

        // Seleccionar un elemento del DataGrid
        private void dgvMatriculas_Selected(object sender, RoutedEventArgs e)
        {
            btnEditarMatricula.IsEnabled = true;
            btnMostrarPagos.IsEnabled = true;
        }
    }
}
