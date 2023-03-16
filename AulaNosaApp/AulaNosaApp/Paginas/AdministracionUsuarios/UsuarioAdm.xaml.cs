using AulaNosaApp.Ventanas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AulaNosaApp.Paginas
{
    /// <summary>
    /// Lógica de interacción para UsuarioAdm.xaml
    /// </summary>
    public partial class UsuarioAdm : Page
    {
        public UsuarioAdm()
        {
            InitializeComponent();
            cbbFiltroUsuario.SelectedIndex = 0;
        }


        private void btnCrearNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            UsuarioCrear usuarioCrearVentana = new UsuarioCrear();
            usuarioCrearVentana.Show();
        }

        private void btnEditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            UsuarioModificar usuarioModificarVentana = new UsuarioModificar();
            usuarioModificarVentana.Show();
        }

        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
           var resultado = MessageBox.Show("¿Desea eliminar este usuario?", "Eliminar Usuario", MessageBoxButton.YesNo);
            if (resultado == MessageBoxResult.Yes)
            {

            }
            else
            {

            }
        }

        private void btnBuscarFiltroUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (tbxFiltroUsuario.Text.Length == 0) {
                MessageBox.Show("Busqueda vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

            }
        }
    }
}
