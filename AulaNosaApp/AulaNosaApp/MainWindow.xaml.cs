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

namespace AulaNosaApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            spnMenuIzqda.Visibility = Visibility.Collapsed;
            grdMenuSuperior.Visibility = Visibility.Collapsed;
            spnAdmin.Visibility = Visibility.Collapsed;
            spnFCT.Visibility = Visibility.Collapsed;
            spnPFC.Visibility = Visibility.Collapsed;
            spnPEXT.Visibility = Visibility.Collapsed;
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(new Uri("/Paginas/AdministracionUsuarios/UsuarioAdm.xaml", UriKind.Relative));
        }

        private void btnCursos_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(new Uri("", UriKind.Relative));
        }

        private void btnEstudios_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(new Uri("", UriKind.Relative));
        }

        private void btnAcceder_Click(object sender, RoutedEventArgs e)
        {
            String rol = "Admin";

            spnMenuIzqda.Visibility = Visibility.Visible;
            grdMenuSuperior.Visibility = Visibility.Visible;
            spnAcceso.Visibility = Visibility.Collapsed;

            if (rol.Equals("Admin")) { 
                spnAdmin.Visibility = Visibility.Visible; 
                spnPFC.Visibility = Visibility.Visible;
            } else {
                spnFCT.Visibility = Visibility.Visible;
                spnPEXT.Visibility = Visibility.Visible;
            }

            
        }

        
    }
}
