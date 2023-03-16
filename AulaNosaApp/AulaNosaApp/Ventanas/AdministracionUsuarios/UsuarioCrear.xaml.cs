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
    /// Lógica de interacción para UsuarioCrear.xaml
    /// </summary>
    public partial class UsuarioCrear : Window
    {
        RestClient client;
        RestRequest request;
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
                lblNombreEstado.Content = "Nombre de usuario vacio";
            }else if (tbxNombreCrearUsuario.Text.Contains("@"))
            {
                lblNombreEstado.Content = "No se permiten correos electronicos como nombre de usuario";
            }
            else
            {
                lblNombreEstado.Content = "";
            }
            // Verificar que se ha introducido la contrasena
            if (pwbContrasenaCrearUsuario.Password.Length == 0)
            {
                lblContrasenaEstado.Content = "Contraseña vacia";
            }else if (pwbContrasenaCrearUsuario.Password.Length < 3)
            {
                lblContrasenaEstado.Content = "Minimo tres caracteres de contraseña";
            }
            else
            {
                lblContrasenaEstado.Content = "";
            }
            // Verificar que se ha introducido el email
            if (tbxEmailCrearUsuario.Text.Length == 0)
            {
                lblEmailEstado.Content = "Email vacio";
            }
            else if (!tbxEmailCrearUsuario.Text.Contains("@"))
            {
                lblEmailEstado.Content = "Se debe introducir un formato correcto de correo electronico";
            }
            else
            {
                lblEmailEstado.Content = "";
            }
            // Si se ha introducido todo
            if ((tbxNombreCrearUsuario.Text.Length > 0 && !tbxNombreCrearUsuario.Text.Contains("@")) && pwbContrasenaCrearUsuario.Password.Length > 3 && (tbxEmailCrearUsuario.Text.Length > 0 && tbxEmailCrearUsuario.Text.Contains("@"))) {
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
            }
        }

        // Cerrar ventana
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
