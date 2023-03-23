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
            // Tomar los atributos del elemento a editar para mostrarlos
            tbxIdModificarUsuario.Text = Statics.usuarioSeleccionado.id.ToString();
            tbxNombreModificarUsuario.Text = Statics.usuarioSeleccionado.nombre;
            pwbContrasenaModificarUsuario.Password = Statics.usuarioSeleccionado.password;
            tbxEmailModificarUsuario.Text = Statics.usuarioSeleccionado.email;
            if (Statics.usuarioSeleccionado.rol.Contains("ADMIN"))
            {
                cbbEdicionUsuarioRol.SelectedIndex = 0;
            }
            else if (Statics.usuarioSeleccionado.rol.Contains("EDITOR"))
            {
                cbbEdicionUsuarioRol.SelectedIndex = 1;
            }
            else if (Statics.usuarioSeleccionado.rol.Contains("PROFE"))
            {
                cbbEdicionUsuarioRol.SelectedIndex = 2;
            }
            else
            {
                cbbEdicionUsuarioRol.SelectedIndex = 3;
            }
        }


        private void btnUsuarioModificar_Click(object sender, RoutedEventArgs e)
        {
            int numeroDevuelto = 0;
            bool nombreUsuarioNoNumerico = int.TryParse(tbxNombreModificarUsuario.Text, out numeroDevuelto);
            // Verificar si se introdujo un nombre y verificar que este no contenga @ para no confundirlo con un correo
            if (tbxNombreModificarUsuario.Text.Length == 0)
            {
                lblErrorNombre.Content = "Nombre de usuario vacio";
            }
            else if (tbxNombreModificarUsuario.Text.Contains("@"))
            {
                lblErrorNombre.Content = "No se permiten correos electronicos como nombre de usuario";
            }
            else if (nombreUsuarioNoNumerico)
            {
                lblErrorNombre.Content = "No se permite un numero solo como nombre de usuario";
            }
            else
            {
                lblErrorNombre.Content = "";
            }
            // Verificar que se introdujo una contraseña de tres caracteres o mas
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
            // Verificar si se introdujo un email y que este contenga @ y .
            if (tbxEmailModificarUsuario.Text.Length == 0)
            {
                lblErrorEmail.Content = "Email vacio";
            }
            else if (!tbxEmailModificarUsuario.Text.Contains("@") && !tbxEmailModificarUsuario.Text.Contains("."))
            {
                lblErrorEmail.Content = "Se debe introducir un formato correcto de correo electronico";
            }
            else
            {
                lblErrorEmail.Content = "";
            }
            // Si se cumplen todos los requisitos, entrara en la accion de modificar el usuario
            if ((tbxNombreModificarUsuario.Text.Length > 0 && !tbxNombreModificarUsuario.Text.Contains("@") && !nombreUsuarioNoNumerico) && pwbContrasenaModificarUsuario.Password.Length > 3 && (tbxEmailModificarUsuario.Text.Length > 0 && tbxEmailModificarUsuario.Text.Contains("@") && tbxEmailModificarUsuario.Text.Contains(".")))
            {
                // Crear un objeto
                UsuarioDTO usuario = new UsuarioDTO();
                usuario.id = Statics.usuarioSeleccionado.id;
                usuario.nombre = tbxNombreModificarUsuario.Text;
                usuario.password = pwbContrasenaModificarUsuario.Password;
                usuario.email = tbxEmailModificarUsuario.Text;
                if (cbbEdicionUsuarioRol.SelectedIndex == 0)
                {
                    usuario.rol = "ADMIN";
                }
                else if (cbbEdicionUsuarioRol.SelectedIndex == 1)
                {
                    usuario.rol = "EDITOR";
                }
                else if (cbbEdicionUsuarioRol.SelectedIndex == 2)
                {
                    usuario.rol = "PROFE";
                }
                else
                {
                    usuario.rol = "ALUMNO";
                }
                // Modificar usuario
                UsuariosApi.modificarUsuario(usuario);
                // Cerrar ventana
                Close();
            }
        }

        // Accion al clickear el boton de salir
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            // Cerrar ventana
            Close();
        }
    }
}
