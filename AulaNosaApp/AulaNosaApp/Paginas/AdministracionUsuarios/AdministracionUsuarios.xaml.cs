using AulaNosaApp.Servicios.AdministracionUsuarios;
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
    public partial class AdministracionUsuarios : Page
    {

        RestClient client;
        RestRequest request;
        List<UsuarioDTO> usuariosLista;
        bool filtrosActivados = false;

        public AdministracionUsuarios()
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
           var usuarioSeleccionado = dgvUsuarios.SelectedItem as UsuarioDTO;
           Statics.usuarioSeleccionado = usuarioSeleccionado;
           UsuarioModificar usuarioModificarVentana = new UsuarioModificar();
           usuarioModificarVentana.Show();
           btnEditarUsuario.IsEnabled = false;
           btnEliminarUsuario.IsEnabled = false;
           dgvUsuarios.SelectedItem = null;
        }

        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            var usuarioSeleccionado = dgvUsuarios.SelectedItem as UsuarioDTO;
            var resultado = MessageBox.Show("¿Desea eliminar este usuario?", "Eliminar Usuario", MessageBoxButton.YesNo);
            if (resultado == MessageBoxResult.Yes)
            {
              UsuariosApi.eliminarUsuario(usuarioSeleccionado.id);
              refrescarUsuarios();
              btnEditarUsuario.IsEnabled = false;
              btnEliminarUsuario.IsEnabled = false;
              dgvUsuarios.SelectedItem = null;
            }else
            {
             refrescarUsuarios();
            }
        }

        private void btnBuscarFiltroUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (tbxFiltroUsuario.Text.Length == 0)
            {
                MessageBox.Show("Busqueda vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (cbbFiltroUsuario.SelectedIndex == 0)
                {
                    UsuarioDTO usuarioId = UsuariosApi.filtrarUsuarioId(tbxFiltroUsuario.Text);
                    List<UsuarioDTO> usuarioIdRetornado = new List<UsuarioDTO>();
                    if(usuarioId != null)
                    {
                        usuarioIdRetornado.Add(usuarioId);
                    }
                    dgvUsuarios.ItemsSource = null;
                    dgvUsuarios.Items.Clear();
                    dgvUsuarios.ItemsSource = usuarioIdRetornado;
                }
                else if (cbbFiltroUsuario.SelectedIndex == 1)
                {
                    List<UsuarioDTO> usuariosListaNombre = UsuariosApi.filtrarUsuarioNombre(tbxFiltroUsuario.Text);
                    dgvUsuarios.ItemsSource = null;
                    dgvUsuarios.Items.Clear();
                    dgvUsuarios.ItemsSource = usuariosListaNombre;
                }
                else if (cbbFiltroUsuario.SelectedIndex == 2)
                {
                    List<UsuarioDTO> usuariosListaRol = UsuariosApi.filtrarUsuarioRol(tbxFiltroUsuario.Text);
                    dgvUsuarios.ItemsSource = null;
                    dgvUsuarios.Items.Clear();
                    dgvUsuarios.ItemsSource = usuariosListaRol;
                }
                else if (cbbFiltroUsuario.SelectedIndex == 3)
                {
                    List<UsuarioDTO> usuariosListaEmail = UsuariosApi.filtrarUsuarioEmail(tbxFiltroUsuario.Text);
                    dgvUsuarios.ItemsSource = null;
                    dgvUsuarios.Items.Clear();
                    dgvUsuarios.ItemsSource = usuariosListaEmail;
                }
            }
        }

        private void dgvUsuarios_Selected(object sender, RoutedEventArgs e)
        {
            btnEditarUsuario.IsEnabled = true;
            btnEliminarUsuario.IsEnabled = true;
        }

        void refrescarUsuarios()
        {
            usuariosLista = UsuariosApi.listarUsuarios();
            dgvUsuarios.ItemsSource = null;
            dgvUsuarios.Items.Clear();
            dgvUsuarios.ItemsSource = usuariosLista;
        }

		private void btnConsultaUsuario_Click(object sender, RoutedEventArgs e)
		{
            if (!filtrosActivados) {
                cbbFiltroUsuario.Visibility = Visibility.Visible;
                tbxFiltroUsuario.Visibility = Visibility.Visible;
                btnBuscarFiltroUsuario.Visibility = Visibility.Visible;
                filtrosActivados = true;
            } else {
                cbbFiltroUsuario.Visibility = Visibility.Collapsed;
                tbxFiltroUsuario.Visibility = Visibility.Collapsed;
                btnBuscarFiltroUsuario.Visibility = Visibility.Collapsed;
                filtrosActivados = false;
            }
        }
	}
}
