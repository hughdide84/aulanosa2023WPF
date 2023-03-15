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

        private void btnUsuarioCrear_Click(object sender, RoutedEventArgs e)
        {
            // Verificar que se ha introducido el nombre de usuario
            if (tbxNombreCrearUsuario.Text.Length == 0)
            {
                MessageBox.Show("Nombre de usuario vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Verificar que se ha introducido la contrasena
            if (pwbContrasenaCrearUsuario.Password.Length == 0)
            {
                MessageBox.Show("Contraseña vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Verificar que se ha introducido el email
            if (tbxEmailCrearUsuario.Text.Length == 0)
            {
                MessageBox.Show("Email vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Si se ha introducido todo
            if (tbxNombreCrearUsuario.Text.Length > 0 && pwbContrasenaCrearUsuario.Password.Length > 0 && tbxEmailCrearUsuario.Text.Length > 0) {
                // Crear objeto Usuario con todos los parametros
                UsuarioDTO usuario = new UsuarioDTO();
                usuario.id = Statics.ultimoIdUsuario + 1;
                usuario.nombre = tbxNombreCrearUsuario.Text;
                usuario.password = pwbContrasenaCrearUsuario.Password;
                usuario.email = tbxEmailCrearUsuario.Text;
                if (cbbCreacionUsuarioRol.SelectedIndex == 0)
                {
                    usuario.rol = "ROLE_ADMIN";
                }
                else 
                {
                    usuario.rol = "ROLE_EDITOR";
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
