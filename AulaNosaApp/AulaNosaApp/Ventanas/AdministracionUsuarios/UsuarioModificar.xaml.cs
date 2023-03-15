using AulaNosaApp.Servicios.AdministracionUsuarios;
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
                // Almacenar todos los usuarios actuales en una lista
                client = new RestClient(Constantes.client);
                request = new RestRequest("/api/usuario", Method.Get);
                var response = client.Execute<List<UsuarioDTO>>(request);
                var apiResponse = response.Data;
                // Ir al metodo Put para modificar usuarios
                request = new RestRequest("/api/usuario", Method.Put);
                // Crear objeto Usuario con todos los parametros
                UsuarioDTO usuario = new UsuarioDTO();
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
                // Funcion de modificar usuario
                AdmUsuariosAPI.modificarUsuario(usuario);
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
