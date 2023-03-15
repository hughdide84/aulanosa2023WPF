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
            if (tbxNombreCrearUsuario.Text.Length == 0)
            {
                MessageBox.Show("Nombre de usuario vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (pwbContrasenaCrearUsuario.Password.Length == 0)
            {
                MessageBox.Show("Contraseña vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (tbxEmailCrearUsuario.Text.Length == 0)
            {
                MessageBox.Show("Email vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (tbxNombreCrearUsuario.Text.Length > 0 && pwbContrasenaCrearUsuario.Password.Length > 0 && tbxEmailCrearUsuario.Text.Length > 0) {
                bool existeUsuario = false;
                client = new RestClient(Constantes.client);
                request = new RestRequest("/api/usuario", Method.Get);
                var response = client.Execute<List<Usuario>>(request);
                var apiResponse = response.Data;
                request = new RestRequest("/api/usuario", Method.Post);
                Usuario usuario = new Usuario();
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
                for (int i=0; i<apiResponse.Count; i++)
                {
                    if (apiResponse[i].nombre.Equals(usuario.nombre))
                    {
                        existeUsuario = true;
                    }
                }
                if (existeUsuario)
                {
                    MessageBox.Show("Error: ya existe usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    request.AddJsonBody(usuario);
                    client.Execute<Usuario>(request);
                    MessageBox.Show("Usuario creado", "Exito", MessageBoxButton.OK);
                    Statics.ultimoIdUsuario += 1;
                }
                
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
