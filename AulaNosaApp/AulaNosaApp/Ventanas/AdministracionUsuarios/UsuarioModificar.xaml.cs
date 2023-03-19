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
            tbxIdModificarUsuario.Text = Statics.usuarioSeleccionado.id.ToString();
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
                lblErrorNombre.Content = "Nombre de usuario vacio";
            }
            else if (tbxNombreModificarUsuario.Text.Contains("@"))
            {
                lblErrorNombre.Content = "No se permiten correos electronicos como nombre de usuario";
            }
            else
            {
                lblErrorNombre.Content = "";
            }
            if (pwbContrasenaModificarUsuario.Password.Length == 0)
            {
                lblErrorContrasena.Content = "Contraseña vacia";
            }
            else if (pwbContrasenaModificarUsuario.Password.Length < 3)
            {
                lblErrorContrasena.Content = "Minimo tres caracteres de contraseña";
            }
            else
            {
                lblErrorContrasena.Content = "";
            }
            if (tbxEmailModificarUsuario.Text.Length == 0)
            {
                lblErrorEmail.Content = "Email vacio";
            }
            else if (!tbxEmailModificarUsuario.Text.Contains("@"))
            {
                lblErrorEmail.Content = "Se debe introducir un formato correcto de correo electronico";
            }
            else
            {
                lblErrorEmail.Content = "";
            }
            if ((tbxNombreModificarUsuario.Text.Length > 0 && !tbxNombreModificarUsuario.Text.Contains("@")) && pwbContrasenaModificarUsuario.Password.Length > 3 && (tbxEmailModificarUsuario.Text.Length > 0 && tbxEmailModificarUsuario.Text.Contains("@")))
            {
                client = new RestClient(Constantes.client);
                request = new RestRequest("/api/usuario", Method.Get);
                var response = client.Execute<List<UsuarioDTO>>(request);
                var apiResponse = response.Data;
                request = new RestRequest("/api/usuario", Method.Put);
                UsuarioDTO usuario = new UsuarioDTO();
                usuario.id = Statics.usuarioSeleccionado.id;
                usuario.nombre = tbxNombreModificarUsuario.Text;
                usuario.password = pwbContrasenaModificarUsuario.Password;
                usuario.email = tbxEmailModificarUsuario.Text;
                if (cbbEdicionUsuarioRol.SelectedIndex == 0)
                {
                    usuario.rol = "ADMIN";
                }
                else
                {
                    usuario.rol = "EDITOR";
                }
                UsuariosApi.modificarUsuario(usuario);
                Close();
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
