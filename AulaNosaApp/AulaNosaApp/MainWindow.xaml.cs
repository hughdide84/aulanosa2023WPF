using AulaNosaApp.DTO;
using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Servicios;
using AulaNosaApp.Servicios.AdministracionCursos;
using AulaNosaApp.Util;
using Org.BouncyCastle.Asn1.Ocsp;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AulaNosaApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CursoDTO> listaCursos;
        List<EstudioDTO> listaEstudios;
        public MainWindow()
        {
            InitializeComponent();
            // Ocultar paneles de gestion para mostrar solo el menu de acceso
            spnMenuIzqda.Visibility = Visibility.Collapsed;
            grdMenuSuperior.Visibility = Visibility.Collapsed;
            spnFCT.Visibility = Visibility.Collapsed;
            spnPFC.Visibility = Visibility.Collapsed;
            spnPEXT.Visibility = Visibility.Collapsed;
            spnAdmin.Visibility = Visibility.Collapsed;
            // Usuario y contraseña
            tbxUsuario.Text = string.Empty;
            pbxContrasena.Password = string.Empty;
            // Rellenar ComboBox de cursos y estudios
            recargarPrinicpal();
            // Seleccion de curso y estudio
            Statics.idCursoElegido = listaCursos[cbbCursos.SelectedIndex].id;
            seleccionEstudio();
        }

        // Accion del boton de iniciar sesion
        private void iniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            var client = new RestClient(Constantes.client);
            var request = new RestRequest("/api/usuario/nombreEs/" + tbxUsuario.Text, Method.Get);
            RestResponse respuesta = client.Execute(request);

            Statics.usuarioLogin = client.Execute<UsuarioDTO>(request).Data;

            if (Statics.usuarioLogin == null || Statics.usuarioLogin.password == null)
            {
                // No existe el usuario
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Statics.usuarioLogin.nombre == tbxUsuario.Text && Statics.usuarioLogin.password == pbxContrasena.Password)
            {
                if (Statics.usuarioLogin.rol == "ALUMNO")
                {
                    // No permite entrar si es rol de alumno
                    MessageBox.Show("Tipo de usuario no apto para acceder.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
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
                    txbNombreUsuarioLogueado.Text = Statics.usuarioLogin.nombre;
                    txbRolUsuarioLogueado.Text = Statics.usuarioLogin.rol;
                    // Ocultar paneles en funcion del rol que tenga                   
                    if (Statics.usuarioLogin.rol == "ADMIN")
                    {
                        // Si es Admin
                        spnAdmin.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        // Si es editor/profesor
                        spnAdmin.Visibility = Visibility.Collapsed;
                    }
                    // Rellenar ComboBox de cursos y estudios
                    recargarPrinicpal();
                    // Seleccion de curso y estudio
                    Statics.idCursoElegido = listaCursos[cbbCursos.SelectedIndex].id;
                    seleccionEstudio();
                }
            }
            else
            {
                // No permite entrar si los datos estan mal
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Accion del boton de cerrar sesion
        private void btnCerrarSesion_Selected(object sender, RoutedEventArgs e)
        {
            spnAcceso.Visibility = Visibility.Visible;
            spnMenuIzqda.Visibility = Visibility.Collapsed;
            grdMenuSuperior.Visibility = Visibility.Collapsed;
            frmPrincipal.Visibility = Visibility.Hidden;
            cbbUsuario.SelectedIndex = 0;
            tbxUsuario.Text = string.Empty;
            pbxContrasena.Password = string.Empty;
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

        // Informacion PFC
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(new Uri("/Paginas/InfoPFC/InfoPFC.xaml", UriKind.Relative));
        }

        // Gestion Alumno Externo
        private void btnAlumnadoExterno_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(new Uri("/Paginas/GestionAlumnadoExterno/GestionAlumnadoExterno.xaml", UriKind.Relative));
        }

        // Alumno - Empresa
        private void btnAlumnoEmpresa_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(new Uri("/Paginas/AlumnoEmpresa/AlumEmpResumen.xaml", UriKind.Relative));
        }

        // Empresa - Alumnos
        private void btnEmpresaAlumnos_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(new Uri("/Paginas/EmpresaAlumnos/EmpAlumResumen.xaml", UriKind.Relative));
        }

        // Gestion Alumnado
        private void btnAlumnado_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(new Uri("/Paginas/GestionAlumnado/GestionAlumnado.xaml", UriKind.Relative));
        }

        // Gestion Proyectos
        private void btnProyectos_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(new Uri("/Paginas/GestionProyectos/GestionProyectos.xaml", UriKind.Relative));
        }

        // Gestion Matriculas
        private void btnMatriculas_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(new Uri("/Paginas/AdministracionMatriculas/AdministracionMatriculas.xaml", UriKind.Relative));
        }

        // Gestion Empresas
        private void btnEmpresas_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal.Navigate(new Uri("/Paginas/GestionEmpresas/GestionEmpresas.xaml", UriKind.Relative));
        }

        // Boton de recargar contenido de ambos ComboBox
        private void btnRecargarContenido_Click(object sender, RoutedEventArgs e)
        {
            recargarPrinicpal();
        }

        // Accion de seleccion de un item del ComboBox de cursos
        private void cbbCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Statics.idCursoElegido = listaCursos[cbbCursos.SelectedIndex].id;
        }

        // Accion de seleccion de un item del ComboBox de estudios
        private void cbbEstudios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Statics.idEstudioElegido = listaEstudios[cbbEstudios.SelectedIndex].id;

            spnFCT.Visibility = Visibility.Collapsed;
            spnPFC.Visibility = Visibility.Collapsed;
            spnPEXT.Visibility = Visibility.Collapsed;

            seleccionEstudio();
        }

        // Recargar ComboBoxes de cursos y estudios
        void recargarPrinicpal()
        {
            listaCursos = CursosApi.listarCursos();
            listaEstudios = EstudioApi.ListarEstudios();

            cbbCursos.SelectedItem = null;
            cbbEstudios.SelectedItem = null;

            cbbCursos.ItemsSource = null;
            cbbEstudios.ItemsSource = null;

            cbbCursos.Items.Clear();
            cbbEstudios.Items.Clear();

            List<String> listaNombresCursos = new List<String>();
            foreach (var curso in listaCursos)
            {
                listaNombresCursos.Add(curso.nombre);
            }
            cbbCursos.ItemsSource = listaNombresCursos;

            List<String> listaNombresEstudios = new List<String>();
            foreach (var estudio in listaEstudios)
            {
                listaNombresEstudios.Add(estudio.nombre);
            }

            cbbEstudios.ItemsSource = listaNombresEstudios;

            cbbCursos.SelectedItem = 0;
            cbbEstudios.SelectedItem = 0;
            cbbCursos.SelectedIndex = 0;
            cbbEstudios.SelectedIndex = 0;

            Statics.idCursoElegido = listaCursos[cbbCursos.SelectedIndex].id;
            seleccionEstudio();
        }

        // Funcion que se llama al cambiar o seleccionar un estudio
        void seleccionEstudio()
        {
            if (listaEstudios[cbbEstudios.SelectedIndex].fct)
            {
                spnFCT.Visibility = Visibility.Visible;
                spnPFC.Visibility = Visibility.Visible;
            }
            else
            {
                spnFCT.Visibility = Visibility.Hidden;
                spnPFC.Visibility = Visibility.Hidden;
            }

            if (listaEstudios[cbbEstudios.SelectedIndex].pext)
            {
                spnPEXT.Visibility = Visibility.Visible;
            }
            else
            {
                spnPEXT.Visibility = Visibility.Collapsed;
            }
        }
    }
}
