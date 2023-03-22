using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
using AulaNosaApp.Servicios.AdministracionUsuarios;
using AulaNosaApp.Util;
using AulaNosaApp.Ventanas;
using AulaNosaApp.Ventanas.AdministracionEmpresas;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AulaNosaApp.Paginas.GestionEmpresas
{
    /// <summary>
    /// Lógica de interacción para GestionEmpresas.xaml
    /// </summary>
    public partial class GestionEmpresas : Page
    {
        RestClient client;
        RestRequest request;
        List<EmpresaDTO> empresasLista;
        bool filtrosActivados = false;

        public GestionEmpresas()
        {
            InitializeComponent();
            cbbFiltroEmpresa.SelectedIndex = 0;
            actualizarEmpresas();
        }

        private void btnRefrescarPantallaEmpresas_Click(object sender, RoutedEventArgs e)
        {
            actualizarEmpresas();
        }

        // Boton de crear empresa (abre ventana de creacion de empresa)
        private void btnCrearNuevaEmpresa_Click(object sender, RoutedEventArgs e)
        {
            EmpresaAlta empresaAlta = new EmpresaAlta();
            empresaAlta.Show();
        }

        // Boton de editar empresa (abre ventana de editar de empresa)
        private void btnEditarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            // Obtenemos la empresa seleccionada
            Statics.empresaSeleccionada = dgvEmpresas.SelectedItem as EmpresaDTO;
            EmpresaEditar empresaEditar = new EmpresaEditar();
            empresaEditar.Show();
            btnEditarEmpresa.IsEnabled = false;
            btnEliminarEmpresa.IsEnabled = false;
            dgvEmpresas.SelectedItem = null;
        }

        // Boton de eliminar empresa
        private void btnEliminarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            Statics.empresaSeleccionada = dgvEmpresas.SelectedItem as EmpresaDTO;
            var resultado = MessageBox.Show("¿Desea eliminar esta empresa?", "Eliminar Usuario", MessageBoxButton.YesNo);

            if (resultado == MessageBoxResult.Yes)
            {
                EmpresaAPI.eliminarEmpresa(Statics.empresaSeleccionada.id);
                actualizarEmpresas();
                btnEditarEmpresa.IsEnabled = false;
                btnEliminarEmpresa.IsEnabled = false;
                dgvEmpresas.SelectedItem = null;
            }
            else
            {
                actualizarEmpresas();
            }
        }

        // Mostrar/Ocultar el panel de filtros
        private void btnConsultaEmpresa_Click(object sender, RoutedEventArgs e)
        {
            if (!filtrosActivados)
            {
                cbbFiltroEmpresa.Visibility = Visibility.Visible;
                tbxFiltroEmpresa.Visibility = Visibility.Visible;
                btnBuscarFiltroEmpresa.Visibility = Visibility.Visible;
                filtrosActivados = true;
            }
            else
            {
                cbbFiltroEmpresa.Visibility = Visibility.Collapsed;
                tbxFiltroEmpresa.Visibility = Visibility.Collapsed;
                btnBuscarFiltroEmpresa.Visibility = Visibility.Collapsed;
                filtrosActivados = false;
            }
        }

        // Habilitar botones de editar y eliminar empresa al clickear uno
        private void dgvEmpresas_Selected(object sender, RoutedEventArgs e)
        {
            btnEditarEmpresa.IsEnabled = true;
            btnEliminarEmpresa.IsEnabled = true;
        }

        // Actualizar lista de empresas
        void actualizarEmpresas()
        {
            empresasLista = EmpresaAPI.listarEmpresas();
            dgvEmpresas.ItemsSource = null;
            dgvEmpresas.Items.Clear();
            dgvEmpresas.ItemsSource = empresasLista;
        }

        private void dgvEmpresas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
