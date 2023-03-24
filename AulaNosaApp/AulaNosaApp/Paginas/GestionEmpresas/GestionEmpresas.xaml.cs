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
        List<EmpresaDTO> empresas;
        List<EmpresaDTO> empresasFiltradas = new List<EmpresaDTO>();

        public GestionEmpresas()
        {
            InitializeComponent();
            refrescarEmpresas();
        }

        // Botón que al accionarse refresca el listado de empresas
        private void btnRefrescarPantallaEmpresas_Click(object sender, RoutedEventArgs e)
        {
            refrescarEmpresas();
        }

        // Boton que al accionarse abre la plantilla de creación de empresas (Ventanas/AdministracionEmpresas/EmpresaAlta)
        private void btnCrearNuevaEmpresa_Click(object sender, RoutedEventArgs e)
        {
            EmpresaAlta empresaAlta = new EmpresaAlta();
            empresaAlta.Show();
        }

        // Boton que al accionarse abre la plantilla de edición de empresas (Ventanas/AdministracionEmpresas/EmpresaEditar)
        private void btnEditarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            // Cargamos los datos de la empresa seleccionada en una variable estática (Util/Statics)
            Statics.empresaSeleccionada = dgvEmpresas.SelectedItem as EmpresaDTO;

            EmpresaEditar empresaEditar = new EmpresaEditar();
            empresaEditar.Show();

            btnEditarEmpresa.IsEnabled = false;
            btnEliminarEmpresa.IsEnabled = false;
            dgvEmpresas.SelectedItem = null;
        }

        // Boton que al accionarse elimina la empresa que hayamos seleccionado en el listado de empresas
        private void btnEliminarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            Statics.empresaSeleccionada = dgvEmpresas.SelectedItem as EmpresaDTO;
            var resultado = MessageBox.Show("¿Desea eliminar esta empresa?", "Eliminar Usuario", MessageBoxButton.YesNo);

            if (resultado == MessageBoxResult.Yes)
            {
                EmpresaAPI.eliminarEmpresa(Statics.empresaSeleccionada.id);
                refrescarEmpresas();

                btnEditarEmpresa.IsEnabled = false;
                btnEliminarEmpresa.IsEnabled = false;
                dgvEmpresas.SelectedItem = null;
            }
            else
            {
                refrescarEmpresas();
            }
        }

        // Función que habilita los botones para Editar y Eliminar empresas cuando seleccionamos una del listado
        private void dgvEmpresas_Selected(object sender, RoutedEventArgs e)
        {
            btnEditarEmpresa.IsEnabled = true;
            btnEliminarEmpresa.IsEnabled = true;
        }

        // Función que refresca el DataGridView que muestra el listado de empresas
        void refrescarEmpresas()
        {
            empresas = EmpresaAPI.listarEmpresas();
            empresasFiltradas.Clear();

            foreach (EmpresaDTO empresa in empresas)
            {
                if (empresa.idCurso == Statics.idCursoElegido && empresa.idEstudios == Statics.idEstudioElegido)
                {
                    empresasFiltradas.Add(empresa);
                }
            }

            dgvEmpresas.ItemsSource = null;
            dgvEmpresas.Items.Clear();
            dgvEmpresas.ItemsSource = empresasFiltradas;
        }
    }
}
