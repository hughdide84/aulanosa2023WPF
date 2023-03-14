using AulaNosaApp.Util;
using AulaNosaApp.Ventanas;
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

namespace AulaNosaApp.Paginas
{
    /// <summary>
    /// Lógica de interacción para UsuarioAdm.xaml
    /// </summary>
    public partial class UsuarioAdm : Page
    {

        RestClient client;
        RestRequest request;
        List<Usuario> usuariosLista;

        public UsuarioAdm()
        {
            InitializeComponent();
            cbbFiltroUsuario.SelectedIndex = 0;
            refrescarUsuarios();
        }

        private void btnRefrescarPantallaUsuarios_Click(object sender, RoutedEventArgs e)
        {
            refrescarUsuarios();
        }

        private void btnCrearNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            UsuarioCrear usuarioCrearVentana = new UsuarioCrear();
            usuarioCrearVentana.Show();
        }

        private void btnEditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            var usuarioSeleccionado = dgvUsuarios.SelectedItem as Usuario;
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("No se ha seleccionado ningun usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
               UsuarioModificar usuarioModificarVentana = new UsuarioModificar();
               usuarioModificarVentana.Show();
            }
        }

        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            var usuarioSeleccionado = dgvUsuarios.SelectedItem as Usuario;
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("No se ha seleccionado ningun usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var resultado = MessageBox.Show("¿Desea eliminar este usuario?", "Eliminar Usuario", MessageBoxButton.YesNo);
                if (resultado == MessageBoxResult.Yes)
                {
                    request = new RestRequest("/api/usuario/"+usuarioSeleccionado.id, Method.Delete);
                    var response = client.Execute(request);
                    refrescarUsuarios();
                }
                else
                {
                    refrescarUsuarios();
                }
            }
        }

        private void btnBuscarFiltroUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (tbxFiltroUsuario.Text.Length == 0) {
                MessageBox.Show("Busqueda vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

            }
        }

        void refrescarUsuarios()
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario", Method.Get);
            var response = client.Execute<List<Usuario>>(request);
            var apiResponse = response.Data;
            usuariosLista = apiResponse;
            dgvUsuarios.ItemsSource = null;
            dgvUsuarios.Items.Clear();
            dgvUsuarios.ItemsSource = usuariosLista;
        }
    }
}
