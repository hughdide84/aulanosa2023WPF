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
        public UsuarioModificar()
        {
            InitializeComponent();
            cbbEdicionUsuarioRol.SelectedIndex = 0;
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

            if (tbxNombreModificarUsuario.Text.Length > 0 && pwbContrasenaModificarUsuario.Password.Length > 0 && tbxEmailModificarUsuario.Text.Length > 0) { }
        }
    }
}
