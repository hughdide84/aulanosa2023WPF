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
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Source = new Uri("/Paginas/AdministracionUsuarios/UsuarioAdm.xaml", UriKind.Relative);
        }

        private void btnAlumnoEmpresa_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Source = new Uri("/Paginas/AlumnoEmpresa/AlumEmpResumen.xaml", UriKind.Relative);
        }

        private void btnEmpresaAlumnos_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Source = new Uri("/Paginas/EmpresaAlumnos/EmpAlumResumen.xaml", UriKind.Relative);
        }

        private void btnAcceder_Click(object sender, RoutedEventArgs e)
        {
            spnMenuIzqda.Visibility = Visibility.Visible;
            grdMenuSuperior.Visibility = Visibility.Visible;
            spnAcceso.Visibility = Visibility.Hidden;
            txbNombreUsuarioLogueado.Text = tbUsuario.Text;
            txbRolUsuarioLogueado.Text = "Admin";
            cbbUsuario.SelectedIndex = 0;
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            spnMenuIzqda.Visibility = Visibility.Collapsed;
            grdMenuSuperior.Visibility = Visibility.Collapsed;
            spnAcceso.Visibility = Visibility.Visible;
        }
    }
}
