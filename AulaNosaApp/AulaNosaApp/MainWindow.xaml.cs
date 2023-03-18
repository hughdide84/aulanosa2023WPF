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
            cbbUsuario.SelectedIndex = 0;
        }

        private void btnAcceder_Click(object sender, RoutedEventArgs e)
        {
            spnAcceso.Visibility = Visibility.Hidden;
            spnMenuIzqda.Visibility = Visibility.Visible;
            grdMenuSuperior.Visibility = Visibility.Visible;
            frmPrincipal.Visibility = Visibility.Visible;
            frmPrincipal.Source = null;
            cbbUsuario.SelectedIndex = 0;
            txbNombreUsuarioLogueado.Text = tbUsuario.Text;
            txbRolUsuarioLogueado.Text = "Admin";
        }

		private void btnCerrarSesion_Selected(object sender, RoutedEventArgs e)
		{
            spnAcceso.Visibility = Visibility.Visible;
            spnMenuIzqda.Visibility = Visibility.Collapsed;
            grdMenuSuperior.Visibility = Visibility.Collapsed;
            frmPrincipal.Visibility = Visibility.Hidden;
            cbbUsuario.SelectedIndex = 0;
        }

		private void btnUsuarios_Click(object sender, RoutedEventArgs e)
		{
            frmPrincipal.Navigate(new Uri("/Paginas/AdministracionUsuarios/AdministracionUsuarios.xaml", UriKind.Relative));
        }

		private void btnCursos_Click(object sender, RoutedEventArgs e)
		{
            frmPrincipal.Navigate(new Uri("/Paginas/AdministracionCursos/AdministracionCursos.xaml", UriKind.Relative));
        }

		private void btnEstudios_Click(object sender, RoutedEventArgs e)
		{
            frmPrincipal.Navigate(new Uri("/Paginas/AdministracionEstudios/AdministracionEstudios.xaml", UriKind.Relative));
        }

		private void btnCalendarioFct_Click(object sender, RoutedEventArgs e)
		{
            frmPrincipal.Navigate(new Uri("/Paginas/Calendario/investigacionCalendario.xaml", UriKind.Relative));
        }

		private void btnCalendarioPext_Click(object sender, RoutedEventArgs e)
		{
            frmPrincipal.Navigate(new Uri("/Paginas/Calendario/investigacionCalendario.xaml", UriKind.Relative));
        }
	}
}
