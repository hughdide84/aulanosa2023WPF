using AulaNosaApp.Util;
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
using System.Windows.Shapes;

namespace AulaNosaApp.Ventanas
{
    /// <summary>
    /// Lógica de interacción para UsuarioModificar.xaml
    /// </summary>
    public partial class UsuarioModificar : Window
    {
        RestClient client;
        RestRequest request;
        public UsuarioModificar()
        {
            InitializeComponent();
            tbxNombreModificarUsuario.Text = Statics.usuarioSeleccionado.nombre;
            pwbContrasenaModificarUsuario.Password = Statics.usuarioSeleccionado.password;
            tbxEmailModificarUsuario.Text = Statics.usuarioSeleccionado.email;
            if (Statics.usuarioSeleccionado.rol.Contains("ADMIN"))
            {
                cbbEdicionUsuarioRol.SelectedIndex = 0;
            }
            else
            {
                cbbEdicionUsuarioRol.SelectedIndex = 1;
            }
        }

        private void btnUsuarioModificar_Click(object sender, RoutedEventArgs e)
        {
            if (tbxNombreModificarUsuario.Text.Length == 0)
            {
                MessageBox.Show("Nombre de usuario vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (pwbContrasenaModificarUsuario.Password.Length == 0)
            {
                MessageBox.Show("Contraseña vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (tbxEmailModificarUsuario.Text.Length == 0)
            {
                MessageBox.Show("Email vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (tbxNombreModificarUsuario.Text.Length > 0 && pwbContrasenaModificarUsuario.Password.Length > 0 && tbxEmailModificarUsuario.Text.Length > 0) {
                int contUsuariosIguales = 0;
                client = new RestClient(Constantes.client);
                request = new RestRequest("/api/usuario", Method.Get);
                var response = client.Execute<List<Usuario>>(request);
                var apiResponse = response.Data;
                request = new RestRequest("/api/usuario", Method.Put);
                Usuario usuario = new Usuario();
                usuario.id = Statics.usuarioSeleccionado.id;
                usuario.nombre = tbxNombreModificarUsuario.Text;
                usuario.password = pwbContrasenaModificarUsuario.Password;
                usuario.email = tbxEmailModificarUsuario.Text;
                if (cbbEdicionUsuarioRol.SelectedIndex == 0)
                {
                    usuario.rol = "ROLE_ADMIN";
                }
                else
                {
                    usuario.rol = "ROLE_EDITOR";
                }
                for (int i = 0; i < apiResponse.Count; i++)
                {
                    if (apiResponse[i].nombre.Equals(usuario.nombre))
                    {
                        contUsuariosIguales += 1;
                    }
                }
                if (contUsuariosIguales > 1)
                {
                    MessageBox.Show("Error: ya existe usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    request.AddJsonBody(usuario);
                    client.Execute<Usuario>(request);
                    MessageBox.Show("Usuario modificado", "Exito", MessageBoxButton.OK);
                }
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
