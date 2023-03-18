using AulaNosaApp.Servicios.AdministracionUsuarios;
using AulaNosaApp.Util;
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
    /// Lógica de interacción para UsuarioCrear.xaml
    /// </summary>
    public partial class UsuarioCrear : Window
    {
        public UsuarioCrear()
        {
            InitializeComponent();
            cbbCreacionUsuarioRol.SelectedIndex = 0;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            // Verificar que se ha introducido el nombre de usuario
            if (tbxNombreCrearUsuario.Text.Length == 0)
            {
                lblErrorNombre.Content = "Nombre de usuario vacio";
            }
            else if (tbxNombreCrearUsuario.Text.Contains("@"))
            {
                lblErrorNombre.Content = "No se permiten correos electronicos como nombre de usuario";
            }
            else
            {
                lblErrorNombre.Content = "";
            }
            // Verificar que se ha introducido la contrasena
            if (pwbContrasenaCrearUsuario.Password.Length == 0)
            {
                lblErrorContrasena.Content = "Contraseña vacia";
            }
            else if (pwbContrasenaCrearUsuario.Password.Length < 3)
            {
                lblErrorContrasena.Content = "Minimo tres caracteres de contraseña";
            }
            else
            {
                lblErrorContrasena.Content = "";
            }
            // Verificar que se ha introducido el email
            if (tbxEmailCrearUsuario.Text.Length == 0)
            {
                lblErrorEmail.Content = "Email vacio";
            }
            else if (!tbxEmailCrearUsuario.Text.Contains("@"))
            {
                lblErrorEmail.Content = "Se debe introducir un formato correcto de correo electronico";
            }
            else
            {
                lblErrorEmail.Content = "";
            }
            // Si se ha introducido todo
            if ((tbxNombreCrearUsuario.Text.Length > 0 && !tbxNombreCrearUsuario.Text.Contains("@")) && pwbContrasenaCrearUsuario.Password.Length > 3 && (tbxEmailCrearUsuario.Text.Length > 0 && tbxEmailCrearUsuario.Text.Contains("@")))
            {
                // Crear objeto Usuario con todos los parametros
                UsuarioDTO usuario = new UsuarioDTO();
                usuario.id = Statics.ultimoIdUsuario + 1;
                usuario.nombre = tbxNombreCrearUsuario.Text;
                usuario.password = pwbContrasenaCrearUsuario.Password;
                usuario.email = tbxEmailCrearUsuario.Text;
                if (cbbCreacionUsuarioRol.SelectedIndex == 0)
                {
                    usuario.rol = "ADMIN";
                }
                else
                {
                    usuario.rol = "EDITOR";
                }
                // Funcion de crear usuario
                AdmUsuariosAPI.crearUsuario(usuario);
                // Cerrar ventana
                Close();
            }
        }

        // Cerrar ventana
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
