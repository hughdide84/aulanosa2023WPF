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
            // Ocultar paneles de gestion para mostrar solo el menu de acceso
            spnMenuIzqda.Visibility = Visibility.Collapsed;
            grdMenuSuperior.Visibility = Visibility.Collapsed;
        }

        // Accion del boton de iniciar sesion
        private void btnAcceder_Click(object sender, RoutedEventArgs e)
        {
            // Ocultar menu de acceso
            spnAcceso.Visibility = Visibility.Hidden;
            // Mostrar paneles de gestion
            spnMenuIzqda.Visibility = Visibility.Visible;
            grdMenuSuperior.Visibility = Visibility.Visible;
            frmPrincipal.Visibility = Visibility.Visible;
            frmPrincipal.Source = null;
            // Pestaña de informacion usuario/cerrar sesion
            cbbUsuario.SelectedIndex = 0;
            // Mostrar nombre y rol del usuario
            txbNombreUsuarioLogueado.Text = tbUsuario.Text;
            txbRolUsuarioLogueado.Text = "Admin";
        }

        // Accion del boton de cerrar sesion
		private void btnCerrarSesion_Selected(object sender, RoutedEventArgs e)
		{
            spnAcceso.Visibility = Visibility.Visible;
            spnMenuIzqda.Visibility = Visibility.Collapsed;
            grdMenuSuperior.Visibility = Visibility.Collapsed;
            frmPrincipal.Visibility = Visibility.Hidden;
            cbbUsuario.SelectedIndex = 0;
        }

        // Panel de usuarios
		private void btnUsuarios_Click(object sender, RoutedEventArgs e)
		{
            frmPrincipal.Navigate(new Uri("/Paginas/AdministracionUsuarios/AdministracionUsuarios.xaml", UriKind.Relative));
        }

        // Panel de cursos
		private void btnCursos_Click(object sender, RoutedEventArgs e)
		{
            frmPrincipal.Navigate(new Uri("/Paginas/AdministracionCursos/AdministracionCursos.xaml", UriKind.Relative));
        }

        // Panel de estudios
		private void btnEstudios_Click(object sender, RoutedEventArgs e)
		{
            frmPrincipal.Navigate(new Uri("/Paginas/AdministracionEstudios/AdministracionEstudios.xaml", UriKind.Relative));
        }

        // Panel del calendario FCT
		private void btnCalendarioFct_Click(object sender, RoutedEventArgs e)
		{
            frmPrincipal.Navigate(new Uri("/Paginas/Calendario/investigacionCalendario.xaml", UriKind.Relative));
        }

        // Panel del calendario PEXT
		private void btnCalendarioPext_Click(object sender, RoutedEventArgs e)
		{
            frmPrincipal.Navigate(new Uri("/Paginas/Calendario/investigacionCalendario.xaml", UriKind.Relative));
        }

        private void btnAlumnadoExterno_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(new Uri("/Paginas/GestionAlumnadoExterno/GestionAlumnadoExterno.xaml", UriKind.Relative));
        }
    }
}
