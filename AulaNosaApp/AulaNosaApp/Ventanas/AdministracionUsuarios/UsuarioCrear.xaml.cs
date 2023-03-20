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

        // Accion al clickear el boton de creacion del usuario
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si se introdujo un nombre y verificar que este no contenga @ para no confundirlo con un correo o sea un numero solo
            int numeroDevuelto = 0;
            bool nombreUsuarioNoNumerico = int.TryParse(tbxNombreCrearUsuario.Text, out numeroDevuelto);
            if (tbxNombreCrearUsuario.Text.Length == 0)
            {
                lblErrorNombre.Content = "Nombre de usuario vacio";
            }
            else if (tbxNombreCrearUsuario.Text.Contains("@"))
            {
                lblErrorNombre.Content = "No se permiten correos electronicos como nombre de usuario";
            }else if (nombreUsuarioNoNumerico)
            {
                lblErrorNombre.Content = "No se permite un numero solo como nombre de usuario";
            }
            else
            {
                lblErrorNombre.Content = "";
            }
            // Verificar que se introdujo una contraseña de tres caracteres o mas
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
            // Verificar si se introdujo un email y que este contenga @ y .
            if (tbxEmailCrearUsuario.Text.Length == 0)
            {
                lblErrorEmail.Content = "Email vacio";
            }
            else if (!tbxEmailCrearUsuario.Text.Contains("@") && !tbxEmailCrearUsuario.Text.Contains("."))
            {
                lblErrorEmail.Content = "Se debe introducir un formato correcto de correo electronico";
            }
            else
            {
                lblErrorEmail.Content = "";
            }
            // Si se cumplen todos los requisitos, entrara en la accion de crear el usuario
            if ((tbxNombreCrearUsuario.Text.Length > 0 && !tbxNombreCrearUsuario.Text.Contains("@") && !nombreUsuarioNoNumerico) && pwbContrasenaCrearUsuario.Password.Length > 3 && (tbxEmailCrearUsuario.Text.Length > 0 && (tbxEmailCrearUsuario.Text.Contains("@") && tbxEmailCrearUsuario.Text.Contains("."))))
            {
                // Crear un objeto
                UsuarioDTO usuario = new UsuarioDTO();
                usuario.id = 1; // (al ser un id autoincremental, este sera el ultimo id registrado + 1, pero se pone aqui un id por que el objeto tiene que tener un valor en el atributo)
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
                // Crear usuario
                UsuariosApi.crearUsuario(usuario);
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
