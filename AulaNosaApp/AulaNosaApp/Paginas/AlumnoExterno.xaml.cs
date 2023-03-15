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
        }

        private void CrearAlumnExt_Click(object sender, RoutedEventArgs e)
        {
            CrearAlumnoExterno crearAlumnExt = new CrearAlumnoExterno();
            crearAlumnExt.Show();
        }

        private void ModifAlumnExt_Click(object sender, RoutedEventArgs e)
        {
            ModificarAlumnoExterno modificarAlumnoExterno = new ModificarAlumnoExterno();
            modificarAlumnoExterno.Show();
        }
    }
}
