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
    /// Lógica de interacción para AlumnoExterno.xaml
    /// </summary>
    public partial class AlumnoExterno : Page
    {
        public AlumnoExterno()
        {
            InitializeComponent();
            cbbFiltroAlumnExt.SelectedIndex = 0;
        }

        private void btnRefrescarPantallaAlumnExt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCrearNuevoAlumnExt_Click(object sender, RoutedEventArgs e)
        {
            CrearAlumnoExterno crearAlumnoExterno = new CrearAlumnoExterno();
            crearAlumnoExterno.Show();
        }

        private void btnEditarAlumnExt_Click(object sender, RoutedEventArgs e)
        {
            ModificarAlumnoExterno modificarAlumnoExterno = new ModificarAlumnoExterno();
            modificarAlumnoExterno.Show();
        }

        private void btnEliminarAlumnExt_Click(object sender, RoutedEventArgs e)
        {
            var resultado = MessageBox.Show("¿Desea eliminar este alumno?", "Eliminar Alumno", MessageBoxButton.YesNo);
            if (resultado == MessageBoxResult.Yes)
            {

            }
            else
            {

            }
        }

        private void btnBuscarFiltroAlumnExt_Click(object sender, RoutedEventArgs e)
        {
            if (tbxFiltroAlumnExt.Text.Length == 0)
            {
                MessageBox.Show("Busqueda vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

            }
        }
    }
}
