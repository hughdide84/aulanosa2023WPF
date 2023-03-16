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
    public partial class UsuarioAdm : Page
    {

        RestClient client;
        RestRequest request;

        public UsuarioAdm()
        {
            InitializeComponent();
            cbbFiltroUsuario.SelectedIndex = 0;
            refrescarUsuarios(); // Refrescar DataGrid de usuarios
        }

        private void btnRefrescarPantallaUsuarios_Click(object sender, RoutedEventArgs e)
        {
            refrescarUsuarios();
        }

        // Crear usuario
        private void btnCrearNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            // Ventana de creacion de usuario
            UsuarioCrear usuarioCrearVentana = new UsuarioCrear();
            usuarioCrearVentana.Show();
        }

        // Editar usuario
        private void btnEditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el Usuario seleccionado
            var usuarioSeleccionado = dgvUsuarios.SelectedItem as UsuarioDTO;
            if (usuarioSeleccionado == null)
            {
                // Error al no seleccionar ningun usuario
                MessageBox.Show("No se ha seleccionado ningun usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
               // Almacenar el usuario seleccionado y abrir la ventana de modificacion de usuario
               Statics.usuarioSeleccionado = usuarioSeleccionado;
               UsuarioModificar usuarioModificarVentana = new UsuarioModificar();
               usuarioModificarVentana.Show();
            }
        }

        // Eliminar usuario
        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el Usuario seleccionado
            var usuarioSeleccionado = dgvUsuarios.SelectedItem as UsuarioDTO;
            if (usuarioSeleccionado == null)
            {
                // Error al no seleccionar ningun usuario
                MessageBox.Show("No se ha seleccionado ningun usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Mostrar ventana de confirmacion de si quiere eliminar el usuario
                var resultado = MessageBox.Show("¿Desea eliminar este usuario?", "Eliminar Usuario", MessageBoxButton.YesNo);
                if (resultado == MessageBoxResult.Yes)
                {
                    // Eliminar usuario
                    AdmUsuariosAPI.eliminarUsuario(usuarioSeleccionado.id);
                    // Refrescar DataGrid de usuarios
                    refrescarUsuarios();
                }
                else
                {
                    // Refrescar DataGrid de usuarios
                    refrescarUsuarios();
                }
            }
        }

        private void btnBuscarFiltroUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (tbxFiltroUsuario.Text.Length == 0) {
                // Error al hacer una busqueda vacia
                MessageBox.Show("Busqueda vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (cbbFiltroUsuario.SelectedIndex == 0)
                {
                    // Recoger por ID
                    UsuarioDTO usuarioId = AdmUsuariosAPI.filtrarUsuarioId(tbxFiltroUsuario.Text);
                    List<UsuarioDTO> usuarioIdRetornado = new List<UsuarioDTO>();
                    usuarioIdRetornado.Add(usuarioId);
                    // Mostrarlo en un DataGrid
                    dgvUsuarios.ItemsSource = null;
                    dgvUsuarios.Items.Clear();
                    dgvUsuarios.ItemsSource = usuarioIdRetornado;
                }
                else if(cbbFiltroUsuario.SelectedIndex == 1)
                {
                    // Falta API Buscar por nombre de usuario
                }
                else if (cbbFiltroUsuario.SelectedIndex == 2)
                {
                    // Falta API Buscar por rol
                }
                else if (cbbFiltroUsuario.SelectedIndex == 3)
                {
                    // Falta API Buscar por email
                }
            }
        }


        private void dgvUsuarios_Selected(object sender, RoutedEventArgs e)
        {
            btnEditarUsuario.Visibility = Visibility.Visible;
            btnEliminarUsuario.Visibility = Visibility.Visible;
        }

        // Refresca el DataGrid de usuarios
        void refrescarUsuarios()
        {
            Statics.usuariosLista = AdmUsuariosAPI.listarUsuarios();
            dgvUsuarios.ItemsSource = null;
            dgvUsuarios.Items.Clear();
            dgvUsuarios.ItemsSource = Statics.usuariosLista;
            if (Statics.usuariosLista != null)
            {
                Statics.ultimoIdUsuario = Statics.usuariosLista[Statics.usuariosLista.Count - 1].id;
            }
        }
    }
}
