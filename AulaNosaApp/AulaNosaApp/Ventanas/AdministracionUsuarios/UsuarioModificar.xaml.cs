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
            // Rellenar los datos con los datos del usuario seleccionado por defecto
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
            // Verificar que se ha introducido el nombre de usuario
            if (tbxNombreModificarUsuario.Text.Length == 0)
            {
                MessageBox.Show("Nombre de usuario vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Verificar que se ha introducido la contrasena
            if (pwbContrasenaModificarUsuario.Password.Length == 0)
            {
                MessageBox.Show("Contraseña vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Verificar que se ha introducido el email
            if (tbxEmailModificarUsuario.Text.Length == 0)
            {
                MessageBox.Show("Email vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Si se ha introducido todo
            if (tbxNombreModificarUsuario.Text.Length > 0 && pwbContrasenaModificarUsuario.Password.Length > 0 && tbxEmailModificarUsuario.Text.Length > 0) {
                int contUsuariosIguales = 0;
                // Almacenar todos los usuarios actuales en una lista
                client = new RestClient(Constantes.client);
                request = new RestRequest("/api/usuario", Method.Get);
                var response = client.Execute<List<Usuario>>(request);
                var apiResponse = response.Data;
                // Ir al metodo Put para modificar usuarios
                request = new RestRequest("/api/usuario", Method.Put);
                // Crear objeto Usuario con todos los parametros
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
                // Comparar si el nombre de usuario que se ha puesto esta en la BBDD
                // (si solo hay uno, es el usuario que estas modificando, es decir, toma el Usuario actual antes de modificarlo)
                for (int i = 0; i < apiResponse.Count; i++)
                {
                    if (apiResponse[i].nombre.Equals(usuario.nombre))
                    {
                        contUsuariosIguales += 1;
                    }
                }
                // Si hay mas de uno que se llamaria igual, mostrara un error
                if (contUsuariosIguales > 1)
                {
                    MessageBox.Show("Error: ya existe usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    // Si hay uno o cero, se actualiza
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
